using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

using System.Diagnostics;

using ProtoBuf;
using PropertyChanged;

using CallTracker.Model;
using CallTracker.Helpers;
using CallTracker.Data;
using CustomControls;

using System.Windows.Automation;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Recording;
using TestStack.White.UIItemEvents;
using TestStack.White.UIItems.Actions;

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

        private SplashScreen Splash;
        public Main(SplashScreen _splash)
        {
            InitializeComponent();
            Splash = _splash;
            Splash.Init(this);

            Splash.UpdateProgress("Main setup",0);
            Splash.StepProgress("Setting up Logs");
            _StatusLabel.Tag = EventLogLevel.Status;
            EventLogger.StatusLabel = _StatusLabel;

            Splash.StepProgress("Setting App Location");
            SetAppLocation();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.DoubleBuffer, true);
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

            Splash.UpdateProgress("Loading Data", 10);
            ServicesStore.ReadData();
            Splash.UpdateProgress("Loading Resources", 17);
            DataStore = DataStore.ReadFile();
            Splash.UpdateProgress("Loading User Data", 27);



            SelectedContact = new CustomerContact();

            Splash.UpdateProgress("Loading View", 30);
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

            Splash.UpdateProgress("Adding Controls", 40);
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

            Splash.UpdateProgress("Initializing Views", 50);
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

            Splash.UpdateProgress("Connecting Contextual Menu", 70);
            transfersToolStripMenuItem.UpdateObject = new TransfersMenuItem(ServicesStore.servicesDataSet);
            bookmarksContextualToolStripMenuItem.UpdateObject = new BookmarksMenuItem(ServicesStore.servicesDataSet);
            systemsContextualToolStripMenuItem.UpdateObject = new SystemsMenuItem(ServicesStore.servicesDataSet);

            
            toolStripServiceSelector.ComboBox.BindingContext = this.BindingContext;
            toolStripServiceSelector.ComboBox.DataSource = ServicesStore.servicesDataSet.Services.Select(x => x.ProblemStylesRow).Distinct().ToList();
            toolStripServiceSelector.ComboBox.DisplayMember = "Description";
            toolStripServiceSelector.ComboBox.ValueMember = "IFMSCode";
            toolStripServiceSelector.ComboBox.SelectedIndex = 0;

            Splash.UpdateProgress("Creating ICON Note Generator", 80);
            NoteGen = new ICONNoteGenerator(ServicesStore.servicesDataSet);

            Splash.UpdateProgress("Creating Hotkey Controller", 85);
            HotKeys = new HotkeyController(this);

            Splash.UpdateProgress("Attaching Events", 90);
            IETabActivator.OnAction += UpdateProgressBar;
            HotkeyController.OnAction += UpdateProgressBar;

            //this.Enabled = true;

            Splash.UpdateProgress("Finishing", 99);
            Splash.UpdateProgress("", 100);
            UpdateProgressBar(0, "Finished Loading", EventLogLevel.ClearStatus);
            ChangeCallStateMenuItem(logOutToolStripMenuItem);       
        } 

        private void Main_Shown(object sender, EventArgs e)
        {
            this.Opacity = 100;
            Splash.Close();
            Splash.Dispose();
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

        public void RemovePasteBind(PasteBind _bind)
        {
            if (DataStore.PasteBinds.Contains(_bind))
            {
                DataStore.PasteBinds.Remove(_bind);
                //editSmartPasteBinds.pasteBindBindingSource.ResetBindings(true);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Menu //////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        internal void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private ViewControlBase visibleSetting;
        private ViewControlBase VisibleSetting 
        {
            get { return visibleSetting; }
            set
            {
                // If the new view isn't null
                if (value != null)
                {
                    statusStrip1.Hide();
                    this.Height = 257;
                    value.ShowSetting();
                }
                else
                {
                    if (showStatusBarToolStripMenuItem.Checked == true)
                        statusStrip1.Show();
                    else
                        this.Height = 239;
                }
                
                // If the previous view isn't null
                if (visibleSetting != null)
                    visibleSetting.HideSetting();

                // If the current view is the same as the previous view
                if (visibleSetting == value)
                {
                    if (showStatusBarToolStripMenuItem.Checked == true)
                        statusStrip1.Show();
                    else
                        this.Height = 239;

                    visibleSetting = null;
                }
                else
                    visibleSetting = value;
            }
        }

        public void NullVisibleSetting()
        {
            VisibleSetting = null;
        }

        public void settingMenuItem_Click(object sender, EventArgs e)
        {      
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            
            ViewControlBase view = (ViewControlBase)item.Tag;
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
                T form = new T();
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
                foreach (ToolStripMenuItem item in _StatusContextMenu.Items.OfType<ToolStripMenuItem>())
                {
                    if (item.Tag != null)
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
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (item.Checked == true)
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
        private Process IPCCProcess;
        private TestStack.White.Application IPCCApplication;
        private Window IPCCWindow;
        private TestStack.White.UIItems.TextBox IPCCCallStatus;
        //private TestStack.White.UIItems.Button IPCCDialButton;
        //private TestStack.White.UIItems.Button IPCCTransferButton;

        private bool CheckForIPCC()
        {
            if (IPCCProcess == null && monitorIPCCToolStripMenuItem.Checked == true)
                if (InitIPCCMonitor() == false)
                    return false;
            return true;
        }

        private bool InitIPCCMonitor()
        {
            foreach (Process pList in Process.GetProcesses())
                if (pList.MainWindowTitle.Contains("IPCC Agent Desktop"))
                    IPCCProcess = pList;

            if (IPCCProcess == null)
            {
                EventLogger.LogNewEvent("Unable to Find IPCC", EventLogLevel.Status);
                return false;
            }

            IPCCProcess.Exited += IPCCProcess_Exited;
            IPCCApplication = TestStack.White.Application.Attach(IPCCProcess);//@"C:\Program Files\Optus\IPCC Agent Desktop\IPCCAgentDesktop.exe");
            IPCCWindow = IPCCApplication.GetWindow(SearchCriteria.ByAutomationId("SoftphoneForm"), InitializeOption.NoCache);
            IPCCCallStatus = IPCCWindow.Get<TestStack.White.UIItems.TextBox>(SearchCriteria.ByAutomationId("StatusBar.Pane3"));
            //IPCCDialButton = IPCCWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnDial"));
            //IPCCTransferButton = IPCCWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnTransfer"));
            
            return true;
        }

        void IPCCProcess_Exited(object sender, EventArgs e)
        {
            _IPCCTimer.Enabled = false;
            monitorIPCCToolStripMenuItem.Checked = false;
            IPCCProcess.Exited -= IPCCProcess_Exited;
            IPCCProcess.Dispose();
            IPCCProcess = null;
        }

        private DateTime _CallStateTimeElapsed;
        private void _WorkReadyTimer_Tick(object sender, EventArgs e)
        {
            _CallStateTimeElapsed = _CallStateTimeElapsed.AddMilliseconds(1000);
            _CallStateTime.Text = _CallStateTimeElapsed.ToString("mm:ss");
        }

        private void monitorIPCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckForIPCC())
                _IPCCTimer.Enabled = monitorIPCCToolStripMenuItem.Checked;
        }

        ToolStripMenuItem currentItem;
        ToolStripMenuItem CurrentItem
        {
            get { return currentItem; }
            set
            {
                currentItem = value;
                switch (currentItem.Name)
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
                _IPCCTimer.Enabled = true;
            }
        }

        private void ChangeCallStateMenuItem(string _callState)
        {
            foreach (ToolStripMenuItem control in _CallStateTime.DropDownItems.OfType<ToolStripMenuItem>())
                if (control.Tag.ToString() == _callState)
                {
                    CurrentItem = control;
                    CurrentItem.Checked = true;
                }
                else
                    control.Checked = false;
        }

        private void ChangeCallStateMenuItem(ToolStripMenuItem _callState)
        {
            foreach (ToolStripMenuItem control in _CallStateTime.DropDownItems.OfType<ToolStripMenuItem>())
                control.Checked = false;
            CurrentItem = _callState;
            CurrentItem.Checked = true;
        }

        private void _IPCCTimer_Tick(object sender, EventArgs e)
        {
            _CallStateTimeElapsed = _CallStateTimeElapsed.AddMilliseconds(_IPCCTimer.Interval);

            //string status = IPCCCallStatus.Name;
            if (CurrentItem.Name == "logInToolStripMenuItem")
                ChangeCallStateMenuItem(notReadyToolStripMenuItem);

            string status = CurrentItem.Tag.ToString();
            if (status != _IPCCState.Text)
            {
                CurrentItem.Checked = false;
                
                _CallStateTimeElapsed = new DateTime();
                switch (status)
                {
                    case "AgentStatus: WrapUp":
                        _IPCCTimer.Interval = 1000;
                        _CallStateTime.BackColor = Color.Firebrick;
                        _CallStateTime.ForeColor = Color.LightGoldenrodYellow;

                        break;
                    case "AgentStatus: Talking":
                        _IPCCTimer.Interval = 1000;
                        _CallStateTime.BackColor = Color.Chocolate;
                        _CallStateTime.ForeColor = Color.PaleGoldenrod;
                        if (_IPCCState.Text == "AgentStatus: Ready" && editContact.autoNewCallToolStripMenuItem.Checked == true)
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

                _IPCCState.Text = status;
                ChangeCallStateMenuItem(status);
            }
            _CallStateTime.Text = _CallStateTimeElapsed.ToString("mm:ss");
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
            ContextualToolStripMenuItem menuItem = (ContextualToolStripMenuItem)sender;
            menuItem.UpdateMenu(toolStripServiceSelector.Text);
        }

        public void transfer_Click(object sender, EventArgs e)
        {
            if (!CheckForIPCC())
                return;

            string dialOrTransfer = "btnDial";
            if (IPCCCallStatus.Name == "AgentStatus: Talking")
                dialOrTransfer = "btnTranfer";

            TestStack.White.UIItems.Button button = IPCCWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId(dialOrTransfer));
            button.Click();
            //Point offsets = new Point();
            //string[] offsetFile = File.ReadAllLines("IPCCOffsets.txt");
            //offsets.X = Convert.ToInt16(Regex.Split(offsetFile[0], ",")[1]);
            //offsets.Y = Convert.ToInt16(Regex.Split(offsetFile[0], ",")[2]);

            //button.Click();

            ToolStripMenuItem item = (ToolStripMenuItem)sender;
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
        public void UpdateProgressBar(int percent, string _event, EventLogLevel _logLevel = EventLogLevel.Verbose)
        {
            EventLogger.LogNewEvent(_event, _logLevel);
            //_StatusProgressBar.Value = percent;
        }

        public void UpdateProgressBar(string _event, EventLogLevel _logLevel = EventLogLevel.Verbose)
        {
            EventLogger.LogNewEvent(_event, _logLevel);
            //_StatusProgressBar.PerformStep();
        }

        public void SetProgressBarStep(int _steps, string _event, EventLogLevel _logLevel = EventLogLevel.Verbose)
        {
            //_StatusProgressBar.Maximum = _steps + 1;
            UpdateProgressBar(_event, _logLevel);
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
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                Properties.Settings.Default.Main_Position = Location;
            }
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
