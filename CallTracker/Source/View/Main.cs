using System;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;

using PropertyChanged;

using CallTracker.Model;
using CallTracker.Helpers;

using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace CallTracker.View
{
    [ImplementPropertyChanged]
    public partial class Main : Form
    {
        public static string SelectedMenuProduct = String.Empty;
        public Point ControlOffset = new Point(0, -1);

        internal UserDataStore DataStore = new UserDataStore();
        internal static ServicesData ServicesStore = new ServicesData();
        internal CustomerContact SelectedContact { get; set; }

        internal EditLogins editLogins;
        internal EditGridLinks editGridLinks;
        internal EditSmartPasteBinds editSmartPasteBinds;
        internal EditContact editContact;
        internal CallHistory callHistory;
        internal HelpKeyCommands helpKeyCommands;
        internal DatabaseView databaseView;
        internal Ratecodes Ratecodes;

        internal static ICONNoteGenerator NoteGen;
        public HotkeyController HotKeys;

        public static FadingTooltip FadingToolTip;

        private readonly SplashScreen _splash;
        public Main(SplashScreen splash)
        {
            InitializeComponent();
            _splash = splash;
            _splash.Init(this);

            _splash.UpdateProgress("Main setup",0);
            _splash.StepProgress("Setting up Logs");
            _StatusLabel.Tag = EventLogLevel.Status;
            EventLogger.StatusLabel = _StatusLabel;

            _splash.StepProgress("Setting App Location");
            SetAppLocation();
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            //SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            versionStripMenuItem.Text = "Version " + Properties.Settings.Default.Version;
        }

        private void SetAppLocation()
        {
            Size totalSize = new Size();
            foreach (var screen in Screen.AllScreens)
                totalSize += screen.Bounds.Size;

            if (Properties.Settings.Default.Main_Position != Point.Empty
             && Properties.Settings.Default.Main_Position.X < totalSize.Width
             && Properties.Settings.Default.Main_Position.Y < totalSize.Height)
            {
                StartPosition = FormStartPosition.Manual;
                Location = Properties.Settings.Default.Main_Position;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
                

            EventLogger.LogNewEvent("------------------------------------------------------");
            SetProgressBarStep(7, "Loading Interface", EventLogLevel.Status);

            _splash.UpdateProgress("Loading Data", 10);
            ServicesStore.ReadData();
            _splash.UpdateProgress("Loading Resources", 17);
            DataStore = DataStore.ReadFile();
            _splash.UpdateProgress("Loading User Data", 27);



            SelectedContact = new CustomerContact();

            _splash.UpdateProgress("Loading Views", 30);
            UpdateProgressBar("Loading Views", EventLogLevel.Status);
            //Splash.StepProgress("Edit Contacts");
            editContact = new EditContact(this);
            //Splash.StepProgress("Call History");
            callHistory = new CallHistory();
            //Splash.StepProgress("Edit Logins");
            editLogins = new EditLogins();
            //Splash.StepProgress("Edit Gridlinks");
            editGridLinks = new EditGridLinks();
            //Splash.StepProgress("Edit Smart Paste Binds");
            editSmartPasteBinds = new EditSmartPasteBinds();
            //Splash.StepProgress("Keycommand Help");
            helpKeyCommands = new HelpKeyCommands();
           // Splash.StepProgress("Edit Database");
            databaseView = new DatabaseView();
            //Splash.StepProgress("Edit Ratecodes");
            Ratecodes = new Ratecodes();

            _splash.UpdateProgress("Adding Controls", 40);
            UpdateProgressBar("Added Controls");
            _ViewPanel.Controls.Add(editContact);
            //Splash.StepProgress();
            _ViewPanel.Controls.Add(callHistory);
            //Splash.StepProgress();
            _ViewPanel.Controls.Add(editLogins);
            //Splash.StepProgress();
            _ViewPanel.Controls.Add(editGridLinks);
            //Splash.StepProgress();
            _ViewPanel.Controls.Add(editSmartPasteBinds);
            //Splash.StepProgress();
            _ViewPanel.Controls.Add(helpKeyCommands);
            //Splash.StepProgress();
            _ViewPanel.Controls.Add(databaseView);
            //Splash.StepProgress();
            _ViewPanel.Controls.Add(Ratecodes);

            _splash.UpdateProgress("Initializing Views", 50);
            editContact.OnParentLoad();

            //Splash.StepProgress();
            editContact.Init();
            //Splash.StepProgress();
            callHistory.Init(this, callHistoryToolStripMenuItem);
            //Splash.StepProgress();
            editLogins.Init(this, loginsViewMenuItem);
            //Splash.StepProgress();
            editSmartPasteBinds.Init(this, pasteBindsViewMenuItem);
            //Splash.StepProgress();
            editGridLinks.Init(this, gridLinksViewMenuItem);
            //Splash.StepProgress();
            helpKeyCommands.Init(this, viewKeyCommandsMenuItem);
            //Splash.StepProgress();
            databaseView.Init(this, databaseEditorToolStripMenuItem);
            //Splash.StepProgress();
            Ratecodes.Init(this, ratecodesMenuItem);

            //Splash.StepProgress();
            UpdateProgressBar("Bring to front");
            editContact.BringToFront();
            editContact.Visible = true;

            //if (String.IsNullOrEmpty(DataStore.User))
            //{
            //    Splash.ShowLogins();
            //    this.Shown -= Main_Shown;
            //}

            _splash.UpdateProgress("Connecting Contextual Menu", 70);
            transfersToolStripMenuItem.UpdateObject = new TransfersMenuItem(ServicesStore.servicesDataSet);
            bookmarksContextualToolStripMenuItem.UpdateObject = new BookmarksMenuItem(ServicesStore.servicesDataSet);
            systemsContextualToolStripMenuItem.UpdateObject = new SystemsMenuItem(ServicesStore.servicesDataSet);

            
            toolStripServiceSelector.ComboBox.BindingContext = this.BindingContext;
            toolStripServiceSelector.ComboBox.DataSource = ServicesStore.servicesDataSet.Services.Select(x => x.ProblemStylesRow).Distinct().ToList();
            toolStripServiceSelector.ComboBox.DisplayMember = "Description";
            toolStripServiceSelector.ComboBox.ValueMember = "IFMSCode";
            toolStripServiceSelector.ComboBox.SelectedIndex = 0;

            _splash.UpdateProgress("Creating ICON Note Generator", 80);
            NoteGen = new ICONNoteGenerator(ServicesStore.servicesDataSet);

            _splash.UpdateProgress("Creating Hotkey Controller", 85);
            HotKeys = new HotkeyController(this);

            _splash.UpdateProgress("Attaching Events", 90);
            IETabActivator.OnAction += UpdateProgressBar;
            HotkeyController.OnAction += UpdateProgressBar;

            //this.Enabled = true;

            _splash.UpdateProgress("Finishing", 99);
            _splash.UpdateProgress("", 100);
            UpdateProgressBar(0, "Finished Loading", EventLogLevel.ClearStatus);
            ChangeCallStateMenuItem(logOutToolStripMenuItem);

            FadingToolTip = new FadingTooltip();
        } 

        private void Main_Shown(object sender, EventArgs e)
        {
            Opacity = 1;
            _splash.Close();
            _splash.Dispose();
        }

        public bool CancelLoad = false;
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CancelLoad == false)
            {
                Properties.Settings.Default.Save();
                DataStore.SaveFile(DataStore);
                ServicesStore.WriteData();
            }

            if (ServicesStore != null)
                ServicesStore.servicesDataSet.Dispose();

            if(HotKeys != null)
                HotKeys.Dispose();
        }

        public void RemovePasteBind(PasteBind bind)
        {
            if (DataStore.PasteBinds.Contains(bind))
            {
                DataStore.PasteBinds.Remove(bind);
                //editSmartPasteBinds.pasteBindBindingSource.ResetBindings(true);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Menu //////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        internal void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private ViewControlBase _visibleSetting;
        private ViewControlBase VisibleSetting 
        {
            get { return _visibleSetting; }
            set
            {
                // If the new view isn't null
                if (value != null)
                {
                    statusStrip1.Hide();
                    Height = 257;
                    value.ShowSetting();
                }
                else
                {
                    if (showStatusBarToolStripMenuItem.Checked)
                        statusStrip1.Show();
                    else
                        Height = 239;
                }
                
                // If the previous view isn't null
                if (_visibleSetting != null)
                    _visibleSetting.HideSetting();

                // If the current view is the same as the previous view
                if (_visibleSetting == value)
                {
                    if (showStatusBarToolStripMenuItem.Checked)
                        statusStrip1.Show();
                    else
                        Height = 239;

                    _visibleSetting = null;
                }
                else
                    _visibleSetting = value;
            }
        }

        public void NullVisibleSetting()
        {
            VisibleSetting = null;
        }

        public void settingMenuItem_Click(object sender, EventArgs e)
        {      
            var item = (ToolStripMenuItem)sender;
            
            var view = (ViewControlBase)item.Tag;
            if (view == VisibleSetting)
                view = null;
            VisibleSetting = view;

            if (item.HasDropDownItems)
                item.DropDownItems[0].PerformClick();
        }

        public static T ShowPopupForm<T>() where T : Form, new()
        {
            var findForm = Application.OpenForms.OfType<T>();
            if (!findForm.Any())
            {
                var form = new T();
                form.Show();
            }
            else
            {
                findForm.First().Activate();
            }
            return findForm.First();
        }






        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Status Bar ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void _StatusContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "clearMessagesToolStripMenuItem")
                    EventLogger.ClearMessage = !EventLogger.ClearMessage;
            else      
                foreach (var item in _StatusContextMenu.Items.OfType<ToolStripMenuItem>().Where(item => item.Tag != null))
                {
                    if (item == e.ClickedItem)
                    {
                        item.Checked = true;
                        _StatusLabel.Tag = Enum.Parse(typeof(EventLogLevel), e.ClickedItem.Tag.ToString());
                    }
                    else
                        item.Checked = false;
                }
            
        }

        private void showStatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;

            if (item.Checked)
            {
                this.Height = 257;
                statusStrip1.Show();
            }
            else
            {
                statusStrip1.Hide();
                this.Height = 239;
            }
        }








        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // IPCC Monitor ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private Process _ipccProcess;
        private TestStack.White.Application _ipccApplication;
        private Window _ipccWindow;
        private TestStack.White.UIItems.TextBox _ipccCallStatus;
        //private TestStack.White.UIItems.Button IPCCDialButton;
        //private TestStack.White.UIItems.Button IPCCTransferButton;
        private TimeSpan _callStateTimeElapsed;

        private bool CheckForIpcc()
        {
            if (_ipccProcess == null && monitorIPCCToolStripMenuItem.Checked)
            {
                EventLogger.LogNewEvent("Trying to find IPCC", EventLogLevel.Status);
                if (InitIpccMonitor() == false)
                {
                    EventLogger.LogNewEvent("Unable to Find IPCC", EventLogLevel.Status);
                    return false;
                }
            }
            EventLogger.LogNewEvent("Monitoring IPCC", EventLogLevel.ClearStatus);
            return true;
        }

        private bool InitIpccMonitor()
        {
            foreach (Process pList in Process.GetProcesses())
                if (pList.MainWindowTitle.Contains("IPCC Agent Desktop"))
                    _ipccProcess = pList;

            if (_ipccProcess == null)
            {
                EventLogger.LogNewEvent("Unable to Find IPCC", EventLogLevel.Status);
                return false;
            }

            _ipccProcess.Exited += IPCCProcess_Exited;
            _ipccApplication = TestStack.White.Application.Attach(_ipccProcess);
            _ipccWindow = _ipccApplication.GetWindow(SearchCriteria.ByAutomationId("SoftphoneForm"), InitializeOption.NoCache);
            _ipccCallStatus = _ipccWindow.Get<TestStack.White.UIItems.TextBox>(SearchCriteria.ByAutomationId("StatusBar.Pane3"));
            //IPCCDialButton = IPCCWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnDial"));
            //IPCCTransferButton = IPCCWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnTransfer"));
            
            return true;
        }

        void IPCCProcess_Exited(object sender, EventArgs e)
        {
            _IPCCTimer.Enabled = false;
            monitorIPCCToolStripMenuItem.Checked = false;
            _ipccProcess.Exited -= IPCCProcess_Exited;
            _ipccProcess.Dispose();
            _ipccProcess = null;
        }

        public void DialOrTransfer(string value)
        {
            if (!CheckForIpcc())
                return;

            string dialOrTransfer = "btnDial";
            if (_ipccCallStatus.Name == "AgentStatus: Talking")
                dialOrTransfer = "btnTranfer";

            var button = _ipccWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId(dialOrTransfer));
            button.Click();
        }

        private void monitorIPCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckForIpcc())
                _IPCCTimer.Enabled = monitorIPCCToolStripMenuItem.Checked;
        }

        ToolStripMenuItem _currentItem;
        ToolStripMenuItem CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                switch (_currentItem.Name)
                {
                    case "readyToolStripMenuItem":
                        wrapUpToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = true;
                        notReadyToolStripMenuItem.Enabled = true;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = true;
                        break;
                    case "wrapUpToolStripMenuItem":
                        readyToolStripMenuItem.Enabled = true;
                        talkingToolStripMenuItem.Enabled = false;
                        notReadyToolStripMenuItem.Enabled = true;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = true;
                        break;
                    case "talkingToolStripMenuItem":
                        readyToolStripMenuItem.Enabled = false;
                        wrapUpToolStripMenuItem.Enabled = true;
                        notReadyToolStripMenuItem.Enabled = false;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = false;
                        break;
                    case "notReadyToolStripMenuItem":
                        readyToolStripMenuItem.Enabled = true;
                        wrapUpToolStripMenuItem.Enabled = true;
                        talkingToolStripMenuItem.Enabled = false;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = true;
                        break;
                    case "logOutToolStripMenuItem":
                        readyToolStripMenuItem.Enabled = false;
                        wrapUpToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = false;
                        logInToolStripMenuItem.Enabled = true;
                        notReadyToolStripMenuItem.Enabled = false;
                        break;
                    case "logInToolStripMenuItem":
                        readyToolStripMenuItem.Enabled = false;
                        wrapUpToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = true;
                        notReadyToolStripMenuItem.Enabled = true;
                        break;
                    default:
                        readyToolStripMenuItem.Enabled = false;
                        wrapUpToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = false;
                        logInToolStripMenuItem.Enabled = true;
                        notReadyToolStripMenuItem.Enabled = false;
                        break;
                }
            }
        }
        private void _CallStateTime_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {    
            if (e.ClickedItem != monitorIPCCToolStripMenuItem)
            {
                ChangeCallStateMenuItem((ToolStripMenuItem)e.ClickedItem);
                if (CheckForIpcc())
                    _IPCCTimer.Enabled = monitorIPCCToolStripMenuItem.Checked;
            }
        }

        private void ChangeCallStateMenuItem(string callState)
        {
            foreach (var control in _CallStateTime.DropDownItems.OfType<ToolStripMenuItem>().Where(control => control.Tag.ToString() != "Protected"))
                if (control.Tag.ToString() == callState)
                {
                    CurrentItem = control;
                    CurrentItem.Checked = true;
                }
                else
                    control.Checked = false;
        }

        private void ChangeCallStateMenuItem(ToolStripMenuItem callState)
        {
            foreach (var control in _CallStateTime.DropDownItems.OfType<ToolStripMenuItem>().Where(control => control.Tag.ToString() != "Protected"))
                control.Checked = false;
            CurrentItem = callState;
            CurrentItem.Checked = true;
        }

        private void _IPCCTimer_Tick(object sender, EventArgs e)
        {
            if (_ipccProcess.HasExited)
            {
                _callStateTimeElapsed = TimeSpan.Zero;
                _CallStateTime.BackColor = Color.WhiteSmoke;
                _CallStateTime.ForeColor = Color.DarkSlateGray;
                _CallStateTime.Text = TimeSpanToString(_callStateTimeElapsed);
                _IPCCTimer.Enabled = false;
                monitorIPCCToolStripMenuItem.Checked = false;
                return;
            }

            var status = _ipccCallStatus.Name;
            if (CurrentItem.Name == "logInToolStripMenuItem")
                ChangeCallStateMenuItem(notReadyToolStripMenuItem);

            if (status != _IPCCState.Text)
            {
                switch (status)
                {
                    case "AgentStatus: Wrapup":
                        _IPCCTimer.Interval = 1000;
                        _CallStateTime.BackColor = Color.Firebrick;
                        _CallStateTime.ForeColor = Color.LightGoldenrodYellow;
                        break;
                    case "AgentStatus: Talking":
                        _IPCCTimer.Interval = 1000;
                        _CallStateTime.BackColor = Color.Chocolate;
                        _CallStateTime.ForeColor = Color.PaleGoldenrod;
                        if (_IPCCState.Text.Contains("Reserved") && editContact.autoNewCallToolStripMenuItem.Checked)
                            editContact.bindingNavigatorAddNewItem_Click(_IPCCState, new EventArgs());
                        break;
                    case "AgentStatus: NotReady":
                        _IPCCTimer.Interval = 1000;
                        _CallStateTime.BackColor = Color.Firebrick;
                        _CallStateTime.ForeColor = Color.LightGoldenrodYellow;
                        break;
                    case "AgentStatus: Ready":
                        _IPCCTimer.Interval = 1000;
                        _CallStateTime.BackColor = Color.OliveDrab;
                        _CallStateTime.ForeColor = Color.PaleGoldenrod;
                        break;
                    case "AgentStatus:":
                        _IPCCTimer.Interval = 5000;
                        _CallStateTime.BackColor = Color.WhiteSmoke;
                        _CallStateTime.ForeColor = Color.DarkSlateGray;
                        break;
                    default:
                        _IPCCTimer.Interval = 1000;
                        _CallStateTime.BackColor = Color.WhiteSmoke;
                        _CallStateTime.ForeColor = Color.DarkSlateGray;
                        break;
                }
                _callStateTimeElapsed = TimeSpan.Zero;
                _IPCCState.Text = status;
                ChangeCallStateMenuItem(status);
            }
            else
            {
                _callStateTimeElapsed = _callStateTimeElapsed.Add(new TimeSpan(0, 0, 0, 0, _IPCCTimer.Interval)); //new TimeSpan(_callStateTimeElapsed.Ticks + _IPCCTimer.Interval * 10000);
            }

            _CallStateTime.Text = TimeSpanToString(_callStateTimeElapsed);
        }

        private static string TimeSpanToString(TimeSpan time)
        {
            return time.Hours > 0 ? String.Format("{0}:{1:00}:{2:00}",time.Hours, time.Minutes, time.Seconds) : String.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
        }









        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Resource menu events /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void toolStripServiceSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((ToolStripComboBox)sender).GetCurrentParent().Focus();
            foreach (ContextualToolStripMenuItem item in resourcesToolStripMenuItem.DropDownItems.OfType<ContextualToolStripMenuItem>())
                item.dirty = true;
        }

        private void resourcesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            var menuItem = (ContextualToolStripMenuItem)sender;
            menuItem.UpdateMenu(toolStripServiceSelector.Text);
        }

        public void transfer_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            //Point offsets = new Point();
            //string[] offsetFile = File.ReadAllLines("IPCCOffsets.txt");
            //offsets.X = Convert.ToInt16(Regex.Split(offsetFile[0], ",")[1]);
            //offsets.Y = Convert.ToInt16(Regex.Split(offsetFile[0], ",")[2]);

            //button.Click();
            DialOrTransfer(item.Tag.ToString());
            
            //WindowHelper.IPCCAutomation(item.Tag.ToString(), offsets);
        }

        private void editBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPopupForm<EditBookmarks>();
        }

        private void editSystemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPopupForm<EditSystems>();
        }

        private void OpenURL_Click(object sender, EventArgs e)
        {
            UpdateMenuObject.newItem_Click(sender, e);
        }





        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Progress Bar /////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void UpdateProgressBar(int percent, string eventString, EventLogLevel logLevel = EventLogLevel.Verbose)
        {
            EventLogger.LogNewEvent(eventString, logLevel);
            //_StatusProgressBar.Value = percent;
        }

        public void UpdateProgressBar(string eventString, EventLogLevel logLevel = EventLogLevel.Verbose)
        {
            EventLogger.LogNewEvent(eventString, logLevel);
            //_StatusProgressBar.PerformStep();
        }

        public void SetProgressBarStep(int _steps, string eventString, EventLogLevel logLevel = EventLogLevel.Verbose)
        {
            //_StatusProgressBar.Maximum = _steps + 1;
            UpdateProgressBar(eventString, logLevel);
        }





        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Move Window //////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void _MainMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            Properties.Settings.Default.Main_Position = Location;
        }






        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Misc /////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PaintGrayBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.WhiteSmoke,
             0,
             0,
             ((Control)sender).Width - 1,
             ((Control)sender).Height - 1);
            base.OnPaint(e);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

    }
}
