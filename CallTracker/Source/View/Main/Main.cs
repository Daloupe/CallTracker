using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;

using PropertyChanged;

using TestStack.White.Configuration;
//using Control = System.Windows.Forms.Control;
//using Form = System.Windows.Forms.Form;

using CallTracker.Model;
using CallTracker.Helpers;
using CallTracker.Properties;
using Utilities.RegularExpressions;

namespace CallTracker.View
{
    [ImplementPropertyChanged]
    public partial class Main : Form
    {
        public static string SelectedMenuProduct = String.Empty;
        public readonly Point ControlOffset = new Point(0, -1);

        //internal UserDataStore UserDataStore = new UserDataStore();
        internal DailyDataRepository DailyDataDataStore = new DailyDataRepository();
        internal static ServicesData ServicesStore = new ServicesData();
        internal LoginDataStore LoginsDataStore = new LoginDataStore();
        internal BindsDataStore BindsDataStore = new BindsDataStore();

        private CustomerContact _selectedContact;
        internal CustomerContact SelectedContact
        {
            get {return _selectedContact; }
            set
            {
                if (_IPCCState.Text == @"Talking")
                        CurrentContact = _selectedContact;
                else if (_selectedContact != null)
                    _selectedContact.FinishUp();
                _selectedContact = value;
                //if (CurrentContact == null && _selectedContact != null && (_IPCCState.Text != String.Empty || _IPCCState.Text != Resources.IPCC_Unmonitored_String))
                //    _selectedContact.AddCallEvent(CallEventTypes.CallStart);
            }
        }

        private CustomerContact _currentContact;
        internal CustomerContact CurrentContact
        {
            get { return _currentContact; }
            set
            {
                if (_currentContact != null)
                    _currentContact.FinishUp();
                _currentContact = value;
            }
        }

        private DailyModel _selectedDate;
        internal DailyModel SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_IPCCState.Text == Resources.IPCC_Unmonitored_String || String.IsNullOrEmpty(_IPCCState.Text))
                    CurrentDate = value;
                _selectedDate = value;
            }
        }
        internal DailyModel CurrentDate { get; set; }

        internal BindingList<DateFilterItem> DateFilterItems { get; set; }
        internal BindingSource DateBindingSource = new BindingSource();

        internal EditLogins editLogins;
        internal EditGridLinks editGridLinks;
        internal EditSmartPasteBinds editSmartPasteBinds;
        internal EditContact editContact;
        internal CallHistory callHistory;
        internal HelpKeyCommands helpKeyCommands;
        internal DatabaseView databaseView;
        internal Ratecodes Ratecodes;
        internal AboutScreen AboutScreen;
        internal StatsView StatsView;
        internal DidYouKnow DidYouKnow;

        internal static ICONNoteGenerator NoteGen;
        public HotkeyController HotKeys;

        public static FadingTooltip FadingToolTip;

        public static BindSmartPasteForm BindSmartPasteForm;
        public static BugReport BugReport;
        public static DataDrop DataDrop;

        private readonly SplashScreen _splash;
        private bool _isStartingUp;

        public Main(SplashScreen splash)
        {
            InitializeComponent();
            _isStartingUp = true;
            //SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            
            _splash = splash;
            _splash.Init(this);

            _splash.UpdateProgress("Main setup",0);
            _splash.StepProgress("Setting up Logs");
            _StatusLabel.Tag = EventLogLevel.Status;
            EventLogger.Init(_StatusLabel);
            _splash.StepProgress("Setting App Location");
            SetAppLocation();

            //versionStripMenuItem.Text = "Version " + Properties.Settings.Default.Version;

            CoreAppXmlConfiguration.Instance.BusyTimeout = 5000;
            CoreAppXmlConfiguration.Instance.FindWindowTimeout = 5000;
            CoreAppXmlConfiguration.Instance.PopupTimeout= 5000;
            CoreAppXmlConfiguration.Instance.TooltipWaitTime = 5000;
        }

        private void SetAppLocation()
        {           
            if(Settings.Default.FirstLoad)
            {
                var screenBounds = Screen.AllScreens[0].Bounds;
                Settings.Default.Main_Position = new Point((screenBounds.Width / 2) - (Width / 2) - 160, (screenBounds.Height / 2) - (Height / 2) + 60);
            }
            else if (!Screen.AllScreens.Any(s => s.WorkingArea.Contains(Settings.Default.Main_Position)))
            {
                var screenBounds = Screen.AllScreens[0].Bounds;
                Settings.Default.Main_Position = new Point((screenBounds.Width / 2) - (Width / 2), (screenBounds.Height / 2) - (Height / 2));
            }

            StartPosition = FormStartPosition.Manual;
            Location = Settings.Default.Main_Position;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            EventLogger.LogAndSaveNewEvent("------------------------------------------------------");
            EventLogger.LogNewEvent("Startup: Loading Data");
            _splash.UpdateProgress("Loading Data", 10);
            ServicesStore.ReadData();
            
            _splash.UpdateProgress("Loading Binds", 15);
            BindsDataStore.ReadData();
            //UserDataStore = UserDataStore.ReadFile();

            _splash.UpdateProgress("Loading Contact Data", 20);
            DailyDataDataStore.ReadData();// = DailyDataRepository.ReadData();
            
            _splash.UpdateProgress("Loading Logins", 25);
            LoginsDataStore.ReadData();


            EventLogger.LogNewEvent("Startup: Setting Date");
            _DailyDataBindingSource.DataSource = DailyDataDataStore.DailyData;
            //SelectedDate = ((DailyModel)_DailyDataBindingSource.Current);

            DateFilterItems = new BindingList<DateFilterItem>(DailyDataDataStore.DailyData.Select(x => x.Date).ToList());
            
            DateBindingSource.DataSource = DateFilterItems;
            DateBindingSource.PositionChanged += _DateSelector_PositionChanged;
            IsDifferentShift();

            Settings.Default.QuitProperly = false;
            //SelectedContact = new CustomerContact();

            EventLogger.LogNewEvent("Startup: Loading Views");
            _splash.UpdateProgress("Loading Views", 30);
            editContact = new EditContact(this);
            callHistory = new CallHistory();
            editLogins = new EditLogins();
            editGridLinks = new EditGridLinks();
            editSmartPasteBinds = new EditSmartPasteBinds();
            helpKeyCommands = new HelpKeyCommands();
            databaseView = new DatabaseView();
            Ratecodes = new Ratecodes();
            StatsView = new StatsView();

            EventLogger.LogNewEvent("Startup: Adding Controls");
            _splash.UpdateProgress("Adding Controls", 40);
            _ViewPanel.Controls.Add(editContact);
            _ViewPanel.Controls.Add(callHistory);
            _ViewPanel.Controls.Add(editLogins);
            _ViewPanel.Controls.Add(editGridLinks);
            _ViewPanel.Controls.Add(editSmartPasteBinds);
            _ViewPanel.Controls.Add(helpKeyCommands);
            _ViewPanel.Controls.Add(databaseView);
            _ViewPanel.Controls.Add(Ratecodes);
            _ViewPanel.Controls.Add(StatsView);

            EventLogger.LogNewEvent("Startup: Initializing Views");
            _splash.UpdateProgress("Initializing Views", 50);
            editContact.OnParentLoad();
            
            _splash.StepProgress("Edit Contacts");
            editContact.Init();
            
            _splash.StepProgress("Call History");
            callHistory.Init(this, callHistoryToolStripMenuItem);
            
            _splash.StepProgress("Edit Logins");
            editLogins.Init(this, loginsViewMenuItem);
            
            _splash.StepProgress("Edit Smart Paste Binds");
            editSmartPasteBinds.Init(this, pasteBindsViewMenuItem);
            
            _splash.StepProgress("Edit Gridlinks");
            editGridLinks.Init(this, gridLinksViewMenuItem);
            
            _splash.StepProgress("Keycommand Help");
            helpKeyCommands.Init(this, viewKeyCommandsMenuItem);
            
            _splash.StepProgress("Edit Database");
            databaseView.Init(this, databaseEditorToolStripMenuItem);

            _splash.StepProgress("Edit Ratecodes");
            Ratecodes.Init(this, ratecodesMenuItem);
            StatsView.Init(this, viewStatsToolStripMenuItem);

            //Splash.StepProgress();
            editContact.BringToFront();
            editContact.Visible = true;

            _splash.UpdateProgress("Connecting Contextual Menu", 70);
            transfersToolStripMenuItem.UpdateObject = new TransfersMenuItem(ServicesStore.servicesDataSet);
            bookmarksContextualToolStripMenuItem.UpdateObject = new BookmarksMenuItem(ServicesStore.servicesDataSet);
            systemsContextualToolStripMenuItem.UpdateObject = new SystemsMenuItem(ServicesStore.servicesDataSet);

            
            toolStripServiceSelector.ComboBox.BindingContext = BindingContext;
            toolStripServiceSelector.ComboBox.DataSource = ServicesStore.servicesDataSet.Services.Select(x => x.ProblemStylesRow).Distinct().ToList();
            toolStripServiceSelector.ComboBox.DisplayMember = "Description";
            toolStripServiceSelector.ComboBox.ValueMember = "IFMSCode";
            toolStripServiceSelector.ComboBox.SelectedIndex = 0;

            _splash.UpdateProgress("Creating ICON Note Generator", 80);
            NoteGen = new ICONNoteGenerator(ServicesStore.servicesDataSet);

            _splash.UpdateProgress("Creating Hotkey Controller", 85);
            HotKeys = new HotkeyController(this);

            _splash.UpdateProgress("Loading Helpers", 90);
            FadingToolTip = new FadingTooltip();
            AboutScreen = new AboutScreen();
            BindSmartPasteForm = new BindSmartPasteForm(this);
            BugReport = new BugReport();
            DataDrop = new DataDrop();
            DidYouKnow = new DidYouKnow();

            _splash.UpdateProgress("Finishing", 99);
            SetVisualSettings();

            if (Settings.Default.FirstLoad)
            {
                //editContact.bindingNavigatorAddNewItem_Click(this, new EventArgs());
                editContact.customerContactsBindingSource.AddNew();
                editContact.customerContactsBindingSource.MoveLast();
                Settings.Default.FirstLoad = false;
            }

            _splash.UpdateProgress("", 100);
            EventLogger.LogNewEvent("Finished Loading", EventLogLevel.ClearStatus);

            ChangeCallStateMenuItem(logOutToolStripMenuItem);
            EventLogger.SaveLog();
        }


        private void SetVisualSettings()
        {
            advancedModeToolStripMenuItem.Checked = Settings.Default.AdvancedMode;

            showStatusBarToolStripMenuItem.Checked = Settings.Default.ShowStatusBar;
            clearMessagesToolStripMenuItem.Checked = Settings.Default.WarningLevel;
        }
        private void SetSettings()
        {
            autoSearchEnabledToolStripMenuItem.Checked = Settings.Default.AutoSearch;
            autoSearchActiveWindowToolStripMenuItem.Checked = Settings.Default.AutoSearchIgnoreActiveWindow;
            newPageIfRequiredToolStripMenuItem.Checked = Settings.Default.AutoSearchOpenNew;       
            
            enableIPCCMonitorOnStartupToolStripMenuItem.Checked = Settings.Default.MonitorIPCC;
            pullIPCCCallDataToolStripMenuItem.Checked = Settings.Default.PullIPCCCallData;
            autoNewCallToolStripMenuItem.Checked = Settings.Default.AutoNewCall;
            if (Settings.Default.MonitorIPCC)
                monitorIPCCToolStripMenuItem.Checked = true;
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            Opacity = 1;
            _splash.Close();
            _splash.Dispose();
            _isStartingUp = false;
            
            if (Settings.Default.ShowTipsOnStartup)
                DidYouKnow.Show();

            SetSettings();
            
            //CancelLoad = false;
        }

        //public bool CancelLoad = true;
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_IPCCTimer.Enabled)
            {
                _IPCCTimer.Enabled = false;
                FinalizeEvents((DailyModel)_DailyDataBindingSource.Current);
            }

            EventLogger.SaveLog();
            EventLogger.LogNewEvent("Shutdown: Saving Settings");
            Settings.Default.Save();

            EventLogger.LogNewEvent("Shutdown: Saving Data");
            if (SelectedContact != null)
                SelectedContact.FinishUp();

            editContact.customerContactsBindingSource.RemoveFilter();
            DailyDataDataStore.DailyData.RemoveFilter();
            DailyDataDataStore.WriteData();
            ServicesStore.WriteData();
            LoginsDataStore.WriteData();
            BindsDataStore.WriteData();

            EventLogger.LogNewEvent("Shutdown: Disposing Objects");
            DisposeIPCC();
            MadSmartPaste.Dispose();
            DateBindingSource.Dispose();
            HotKeys.Dispose();
            FadingToolTip.Dispose();

            Settings.Default.QuitProperly = true;
            EventLogger.SaveLog();
        }

        public void RemovePasteBind(PasteBind bind)
        {
            if (BindsDataStore.PasteBinds.Contains(bind))
            {
                BindsDataStore.PasteBinds.Remove(bind);
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
                //WindowHelper.SuspendDrawing(_ViewPanel);
                // If the new view isn't null
                if (value != null)
                {
                    Height = 257;
                    value.ShowSetting();
                    statusStrip1.Hide();
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

               // WindowHelper.ResumeDrawing(_ViewPanel);
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
            var findForm = Application.OpenForms.OfType<T>().ToList().FirstOrDefault();
            if (findForm == null)
            {
                findForm = new T();
                findForm.Show();
            }
            else
            {
                findForm.Activate();
            }
            return findForm;
        }

        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServicesStore.WriteData();
            LoginsDataStore.WriteData();
            BindsDataStore.WriteData();
            EventLogger.SaveLog();
        }

        private void _EHBSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (!String.IsNullOrEmpty(_EHBSearch.Text))
            {
                var searchText = _EHBSearch.Text.Replace(' ', '+');
                HotkeyController.NavigateOrNewIE("http://nexus.optus.com.au/", "Nexus",
                    "http://nexus.optus.com.au/index.php?#search/" + searchText + "/1");
            }
        }

        private void _EHBSearch_Leave(object sender, EventArgs e)
        {
            _EHBSearch.Text = String.Empty;
        }









        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Day Change ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        void _DateSelector_PositionChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("_DateSelector_PositionChanged Called");
            //_DailyDataBindingSource.Filter = "Date = " + ((DateFilterItem)DateBindingSource.Current).LongDate;
            _DailyDataBindingSource.Position = DateBindingSource.Position;
            SelectedDate = ((DailyModel) _DailyDataBindingSource.Current);
            //_DailyDataBindingSource.IndexOf(DailyData.FirstOrDefault(x => x.Date == ((DateFilterItem)DateBindingSource.Current).LongDate));
        }

        //void DateBindingSource_CurrentChanged(object sender, EventArgs e)
        //{
        //    _DailyDataBindingSource.Position = DateBindingSource.Position;
        //    SelectedDate = ((DailyModel)_DailyDataBindingSource.Current);
        //}





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
            Settings.Default.ShowStatusBar = showStatusBarToolStripMenuItem.Checked;
            //var item = (ToolStripMenuItem)sender;

            if (showStatusBarToolStripMenuItem.Checked)
            {
                Height = 257;
                statusStrip1.Show();
            }
            else
            {
                statusStrip1.Hide();
                Height = 239;
            }
        }










        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Resource menu events /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void toolStripServiceSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            resourcesToolStripMenuItem.GetCurrentParent().Focus();
            //((ToolStripComboBox)sender).GetCurrentParent().Parent.Focus();
            foreach (var item in resourcesToolStripMenuItem.DropDownItems.OfType<ContextualToolStripMenuItem>())
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
            DialOrTransfer(item.Tag.ToString());
        }

        private void editBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPopupForm<EditBookmarks>();
        }

        private void editSystemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPopupForm<EditSystems>();
        }

        private void sMSHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotkeyController.NavigateOrNewIE("http://zsolutions.optus.com.au/fmts_sms/", "CSA Touch-Point SMS Hub", "http://zsolutions.optus.com.au/fmts_sms/index.php?");
        }

        private void transfersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotkeyController.NavigateOrNewIE("http://nexus.optus.com.au/", "Nexus", "http://nexus.optus.com.au/#ehb/8/ntk");
        }

        private void premiumHomeServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotkeyController.NavigateOrNewIE("https://optus.qk.com.au/", "PHS", "https://optus.qk.com.au/extranet/?action=home");
        }

        private void logMeInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotkeyController.NavigateOrNewIE("https://secure.logmeinrescue.com", "LogMeIn Rescue", "https://secure.logmeinrescue.com/Account/Login");
        }
        //private void OpenURL_Click(object sender, EventArgs e)
        //{
        //    UpdateMenuObject.newItem_Click(sender, e);
        //}





        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        //// Progress Bar /////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //public void UpdateProgressBar(int percent, string eventString, EventLogLevel logLevel = EventLogLevel.Verbose)
        //{
        //    EventLogger.LogNewEvent(eventString, logLevel);
        //    //_StatusProgressBar.Value = percent;
        //}

        //public void UpdateProgressBar(string eventString, EventLogLevel logLevel = EventLogLevel.Verbose)
        //{
        //    EventLogger.LogNewEvent(eventString, logLevel);
        //    //_StatusProgressBar.PerformStep();
        //}

        //public void SetProgressBarStep(int steps, string eventString, EventLogLevel logLevel = EventLogLevel.Verbose)
        //{
        //    //_StatusProgressBar.Maximum = _steps + 1;
        //    UpdateProgressBar(eventString, logLevel);
        //}





        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Move Window //////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void _MainMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            Settings.Default.Main_Position = Location;

            //var screenBounds = Screen.AllScreens[0].Bounds;
            //Console.WriteLine(new Point((screenBounds.Width / 2) - (Width / 2) - Location.X, (screenBounds.Height / 2) - (Height / 2) - Location.Y));
        }






        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Working Date Checker /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        internal bool IsDifferentShift()
        {
            // If Date is right, or Agent isn't logged out, then don't do anything.
            if (_DailyDataBindingSource.Count > 0)
                if (((DateFilterItem)DateBindingSource.Current).LongDate == DateTime.Today)
                //if (((DailyModel) _DailyDataBindingSource.Current).Date.LongDate == DateTime.Today)// && !_isStartingUp)
                //    // || _IPCCState.Text != Resources.IPCC_Unmonitored_String)
                {
                    return false;
                }

            
            // If today doesnt exist, create it, otherwise change the day.
            if (DailyDataDataStore.DailyData.All(x => x.Date.LongDate != DateTime.Today))
            {
                DailyDataDataStore.DailyData.AddNew();
                DateFilterItems.AddNew();

                DateBindingSource.Position = DateFilterItems.Count - 1;
                //_DailyDataBindingSource.Position = DailyDataDataStore.DailyData.Count - 1;

                if(Settings.Default.QuitProperly && !_isStartingUp)
                    File.Delete("Log.txt");
            }
            else //if (((DateFilterItem)DateBindingSource.Current).LongDate != DateTime.Today)//((DailyModel) _DailyDataBindingSource.Current).Date.LongDate != DateTime.Today)
            {
                DateBindingSource.Position =
                    DateFilterItems.IndexOf(DateFilterItems.FirstOrDefault(x => x.LongDate == DateTime.Today));
                //_DailyDataBindingSource.Position = DateBindingSource.Position;

                if (Settings.Default.QuitProperly && !_isStartingUp)
                    File.Delete("Log.txt");
            }
            //else
            //{
            //    DateBindingSource.Position = DateFilterItems.IndexOf(DateFilterItems.FirstOrDefault(x => x.LongDate == DateTime.Today));
            //}

            // Archive and Delete
            var daysToDelete = new List<DailyModel>();
            foreach (var day in DailyDataDataStore.DailyData)
            {
                if ((DateTime.Today - day.Date.LongDate).Days > 31)
                {
                    daysToDelete.Add(day);
                    continue;
                }
                if((DateTime.Today - day.Date.LongDate).Days > 7 && !day.IsArchived)
                    day.ArchiveContacts();
            }
            foreach (var day in daysToDelete)
            {
                DateFilterItems.Remove(day.Date);
                DailyDataDataStore.DailyData.Remove(day);
            }

            return true;
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
            //base.OnPaint(e);
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}

        public void AddAppEvent(AppEventTypes newEvent)
        {
            if(SelectedContact != null)
                SelectedContact.AddAppEvent(newEvent);
            else
                ((DailyModel)_DailyDataBindingSource.Current).AddAppEvent(newEvent);
        }

        private void clearMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.WarningLevel = clearMessagesToolStripMenuItem.Checked;
        }

        private void autoSearchToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.AutoSearch = autoSearchEnabledToolStripMenuItem.Checked;
        }

        private void autoSearchActiveWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.AutoSearchIgnoreActiveWindow = autoSearchActiveWindowToolStripMenuItem.Checked;
        }

        private void newPageIfRequiredToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.AutoSearchOpenNew = newPageIfRequiredToolStripMenuItem.Checked;
        }

        private void advancedModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.AdvancedMode = advancedModeToolStripMenuItem.Checked;

            var controls = settingsToolStripMenuItem.DropDownItems.OfType<CTToolStripItem>().ToList();
            controls.AddRange(helpToolStripMenuItem.DropDownItems.OfType<CTToolStripItem>());
            controls.AddRange(_CallStateTime.DropDownItems.OfType<CTToolStripItem>());
            controls.AddRange(autoSearchToolStripMenuItem.DropDownItems.OfType<CTToolStripItem>());
            controls.AddRange(iPCCMonitorToolStripMenuItem.DropDownItems.OfType<CTToolStripItem>());
            controls.AddRange(editContact._CallHistoryContextMenu.Items.OfType<CTToolStripItem>());

            foreach (var control in controls.Where(control => control.Advanced))
            {
                ((ToolStripItem)control).Visible = Settings.Default.AdvancedMode;
            }
            
            //foreach (var control in settingsToolStripMenuItem.DropDownItems.OfType<CTToolStripItem>().Where(control => control.Advanced))
            //{
            //    ((ToolStripItem)control).Visible = Settings.Default.AdvancedMode;
            //}

            //foreach (var control in helpToolStripMenuItem.DropDownItems.OfType<CTToolStripItem>().Where(control => control.Advanced))
            //{
            //    ((ToolStripItem)control).Visible = Settings.Default.AdvancedMode;
            //}

            //foreach (var control in _CallStateTime.DropDownItems.OfType<CTToolStripItem>().Where(control => control.Advanced))
            //{
            //    ((ToolStripItem)control).Visible = Settings.Default.AdvancedMode;
            //}

            //foreach (var control in editContact._CallHistoryContextMenu.Items.OfType<CTToolStripItem>().Where(control => control.Advanced))
            //{
            //    ((ToolStripItem)control).Visible = Settings.Default.AdvancedMode;
            //}
            //foreach (var control in iPCCMonitorToolStripMenuItem.DropDownItems.OfType<CTToolStripItem>().Where(control => control.Advanced))
            //{
            //    ((ToolStripItem)control).Visible = Settings.Default.AdvancedMode;
            //}
            //foreach (var control in autoSearchToolStripMenuItem.DropDownItems.OfType<CTToolStripItem>().Where(control => control.Advanced))
            //{
            //    ((ToolStripItem)control).Visible = Settings.Default.AdvancedMode;
            //}

            
        }

        private void didYouKnowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DidYouKnow.IsDisposed)
            {
                DidYouKnow = new DidYouKnow();
                DidYouKnow.Show();
            }
            else
                DidYouKnow.Show();

        }

        private void _AutoSearchHelp_Click(object sender, EventArgs e)
        {
            DidYouKnow = new DidYouKnow(Convert.ToInt32(((ToolStripMenuItem)sender).Tag));
            DidYouKnow.Show();
            //if (DidYouKnow.IsDisposed)
            //{
                
            //}
            //else
            //    DidYouKnow.ShowAtPosition(Convert.ToInt32(((ToolStripMenuItem)sender).Tag));   
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutScreen.Show();
        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugReport.Show();
        }

        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventLogger.SaveLog();
            Process.Start(@".\Log.txt");
        }

        private void _IPCCState_Click(object sender, EventArgs e)
        {
            _CallStateTime.ShowDropDown();
        }

        private void monitorIPCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckForIpcc())
            {
                monitorIPCCToolStripMenuItem.Checked = false;
                _CallStateTime.Text = @"00:00";
            }
            else
                _IPCCState.Text = String.Empty;

            _IPCCTimer.Enabled = monitorIPCCToolStripMenuItem.Checked;
        }

        private void pullIPCCCallDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.PullIPCCCallData = pullIPCCCallDataToolStripMenuItem.Checked; //((ToolStripMenuItem)sender).Checked;
        }

        private void autoNewCallToolStripMenuItem1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.AutoNewCall = autoNewCallToolStripMenuItem.Checked;
        }

        private void enableIPCCMonitorOnStartupToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.MonitorIPCC = enableIPCCMonitorOnStartupToolStripMenuItem.Checked;
        }

        private void _CallStateTime_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == monitorIPCCToolStripMenuItem || e.ClickedItem == pullIPCCCallDataToolStripMenuItem) return;

            ChangeCallStateMenuItem((ToolStripMenuItem)e.ClickedItem);
            if (e.ClickedItem == logInToolStripMenuItem)
            {
                _IPCCState.Text = String.Empty;
                ChangeCallStateMenuItem(notReadyToolStripMenuItem);
            }
            if (!monitorIPCCToolStripMenuItem.Checked && !_IPCCTimer.Enabled)
                _IPCCTimer.Enabled = true;
        }

    }
}