using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;

using PropertyChanged;

using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Control = System.Windows.Forms.Control;
using Form = System.Windows.Forms.Form;

using CallTracker.Model;
using CallTracker.Helpers;
using CallTracker.Properties;

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

        private readonly SplashScreen _splash;
        public Main(SplashScreen splash)
        {
            InitializeComponent();
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            
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
            var totalSize = new Size();
            foreach (var screen in Screen.AllScreens)
                totalSize += screen.Bounds.Size;

            if (Settings.Default.Main_Position == Point.Empty ||
                Settings.Default.Main_Position.X >= totalSize.Width ||
                Settings.Default.Main_Position.Y >= totalSize.Height) return;

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
            DateFilterItems = new BindingList<DateFilterItem>(DailyDataDataStore.DailyData.Select(x => x.Date).ToList());
            DateBindingSource.DataSource = DateFilterItems;
            _DailyDataBindingSource.DataSource = DailyDataDataStore.DailyData;
            IsDifferentShift();
            DateBindingSource.PositionChanged += _DateSelector_PositionChanged;

            //SelectedContact = new CustomerContact();

            EventLogger.LogNewEvent("Startup: Loading Views");
            _splash.UpdateProgress("Loading Views", 30);
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

            StatsView = new StatsView();

            EventLogger.LogNewEvent("Startup: Adding Controls");
            _splash.UpdateProgress("Adding Controls", 40);
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

            _splash.UpdateProgress("Attaching Events", 90);
            //IETabActivator.OnAction += UpdateProgressBar;
            //HotkeyController.OnAction += UpdateProgressBar;

            _splash.UpdateProgress("Finishing", 99);
            _splash.UpdateProgress("", 100);
            EventLogger.LogNewEvent("Finished Loading", EventLogLevel.ClearStatus);
            ChangeCallStateMenuItem(logOutToolStripMenuItem);

            FadingToolTip = new FadingTooltip();
            AboutScreen = new AboutScreen();
            BindSmartPasteForm = new BindSmartPasteForm(this);
            BugReport = new BugReport();

            SetSettings();

            DidYouKnow = new DidYouKnow();
            if (Settings.Default.ShowTipsOnStartup)
                DidYouKnow.Show();

            EventLogger.SaveLog();
        }

        void _DateSelector_PositionChanged(object sender, EventArgs e)
        {
            //_DailyDataBindingSource.Filter = "Date = " + ((DateFilterItem)DateBindingSource.Current).LongDate;
            _DailyDataBindingSource.Position = DateBindingSource.Position;
            //_DailyDataBindingSource.IndexOf(DailyData.FirstOrDefault(x => x.Date == ((DateFilterItem)DateBindingSource.Current).LongDate));
        }

        private void SetSettings()
        {
            advancedModeToolStripMenuItem.Checked = Settings.Default.AdvancedMode;

            showStatusBarToolStripMenuItem.Checked = Settings.Default.ShowStatusBar;
            clearMessagesToolStripMenuItem.Checked = Settings.Default.WarningLevel;
            
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








        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // IPCC Monitor ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private Process _ipccProcess = null;
        private TestStack.White.Application _ipccApplication;
        private Window _ipccWindow;
        private TestStack.White.UIItems.TextBox _ipccCallStatus;
        private TestStack.White.UIItems.Button _ipccDialButton;
        private TestStack.White.UIItems.Button _ipccTransferButton;

        private AutomationElement _ipccCallDataTable;
        //private string[,] _gridData;

        private UIItemContainer _ipccDialWindow;
        private TestStack.White.UIItems.ListBoxItems.ComboBox _ipccDialNumberComboBox;

        //private TimeSpan _callStateTimeElapsed;

        private bool CheckForIpcc()
        {
            if (monitorIPCCToolStripMenuItem.Checked)
            {
                if (_ipccProcess == null)
                {
                    EventLogger.LogNewEvent("Trying to find IPCC", EventLogLevel.Status);
                    if (InitIpccMonitor() == false)
                    {
                        _IPCCState.Text = Resources.IPCC_Unmonitored_String;
                        return false;
                    }
                }
                EventLogger.LogNewEvent("Monitoring IPCC", EventLogLevel.ClearStatus);
                return true;
            }
            EventLogger.LogNewEvent("Monitoring Not Enabled", EventLogLevel.Brief);
            return false;
        }

        private bool InitIpccMonitor()
        {
            foreach (var pList in Process.GetProcesses())
                if (pList.MainWindowTitle.Contains("IPCC Agent Desktop"))
                {
                    _ipccProcess = pList;
                    break;
                }

            if (_ipccProcess == null)
            {
                EventLogger.LogNewEvent("Unable to Find IPCC", EventLogLevel.Status);
                return false;
            }

            _ipccProcess.Exited += IPCCProcess_Exited;
            _ipccApplication = TestStack.White.Application.Attach(_ipccProcess);
            //Must be NoCache.
            _ipccWindow = _ipccApplication.GetWindow(SearchCriteria.ByAutomationId("SoftphoneForm"), InitializeOption.NoCache);
            _ipccDialButton = _ipccWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnDial"));
            _ipccTransferButton = _ipccWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnTransfer"));
            _ipccCallStatus = _ipccWindow.Get<TestStack.White.UIItems.TextBox>(SearchCriteria.ByAutomationId("StatusBar.Pane3"));

            //InitIPCCCallDataGrid();
            _ipccCallDataTable = _ipccWindow.Get<TestStack.White.UIItems.TableItems.Table>(SearchCriteria.ByAutomationId("m_callGrid")).AutomationElement;

            _ipccDialWindow = null;
            _ipccDialNumberComboBox = null;

            return true;
        }

        //private void InitIPCCCallDataGrid()
        //{
        //    _ipccCallDataTable = _ipccWindow.Get<TestStack.White.UIItems.TableItems.Table>(SearchCriteria.ByAutomationId("m_callGrid")).AutomationElement;
        //    var headerLine = _ipccCallDataTable.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Header));

        //    _gridData = new string[headerLine.Count, 2];
        //    var headerIndex = 0;
        //    foreach (AutomationElement header in headerLine)
        //    {
        //        _gridData[headerIndex++, 0] = header.Current.Name;
        //    }
        //}

        void IPCCProcess_Exited(object sender, EventArgs e)
        {
            EventLogger.LogAndSaveNewEvent("IPCC Exited", EventLogLevel.Status);
            //_callStateTimeElapsed = TimeSpan.Zero;
            _CallStateTime.BackColor = Color.WhiteSmoke;
            _CallStateTime.ForeColor = Color.DarkSlateGray;
            _CallStateTime.Text = @"00:00";//TimeSpanToString(_callStateTimeElapsed);
            monitorIPCCToolStripMenuItem.Checked = false;
            _IPCCState.Text = Resources.IPCC_Unmonitored_String;
            DisposeIPCC();
        }

        void DisposeIPCC()
        {
            _IPCCTimer.Enabled = false;
            if (_ipccProcess == null) return;

            _ipccProcess.Exited -= IPCCProcess_Exited;
            _ipccProcess.Dispose();
            _ipccProcess = null;
        }

        //private static Stopwatch watch = new Stopwatch();
        //watch.Reset();
        //watch.Start();
        //watch.Stop();
        //EventLogger.LogNewEvent("ByAutomationId: " + watch.ElapsedTicks);
        //EventLogger.SaveLog();
        public void DialOrTransfer(string value)
        {
            if (!CheckForIpcc())
                return;
            
            switch (_IPCCState.Text)
            {
                case "Talking":
                    _ipccTransferButton.Click();
                    break;
                case "NotReady":
                    _ipccDialButton.Click();
                    break;
                default:
                    return;
            }

            if (_ipccDialWindow == null)
            {
                _ipccDialWindow = _ipccWindow.MdiChild(SearchCriteria.ByAutomationId("DialPadForm"));
                if (_ipccDialWindow == null)
                {
                    EventLogger.LogNewEvent("IPCC Dial Error: CTI Dial Pad Not Found", EventLogLevel.Status);
                    return;
                }
                EventLogger.LogNewEvent("IPCC Dial: CTI Dial Pad Found", EventLogLevel.Brief);
            }

            if (_ipccDialNumberComboBox == null)
            {
                _ipccDialNumberComboBox = _ipccDialWindow.Get<TestStack.White.UIItems.ListBoxItems.ComboBox>(SearchCriteria.ByAutomationId("dialedNumberComboBox"));
                if (_ipccDialNumberComboBox == null)
                {
                    EventLogger.LogNewEvent("IPCC Dial Error: Number ComboBox Not Found", EventLogLevel.Status);
                    return;
                }
                EventLogger.LogNewEvent("IPCC Dial: Number ComboBox Found", EventLogLevel.Brief);
            }

            _ipccDialNumberComboBox.EditableText = value;
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

        private bool DoesIPCCExist()
        {
            if (_ipccProcess == null) return false;
            return !_ipccProcess.HasExited;
        }

        private void _IPCCTimer_Tick(object sender, EventArgs e)
        {
            // Exit if IPCC doesn't exist and IPCC monitoring is on.
            if (!DoesIPCCExist() && monitorIPCCToolStripMenuItem.Checked)
            {
                //_callStateTimeElapsed = TimeSpan.Zero;
                _CallStateTime.BackColor = Color.WhiteSmoke;
                _CallStateTime.ForeColor = Color.DarkSlateGray;
                _CallStateTime.Text = @"00:00";//TimeSpanToString(_callStateTimeElapsed);
                _IPCCTimer.Enabled = false;
                monitorIPCCToolStripMenuItem.Checked = false;
                _IPCCState.Text = Resources.IPCC_Unmonitored_String;
                return;
            }

            //if (CurrentItem.Name == "logInToolStripMenuItem")
            //    ChangeCallStateMenuItem(notReadyToolStripMenuItem);

            // If IPCC monitoring is off, pass in values from IPCC menu for testing.
            string status;
            if (monitorIPCCToolStripMenuItem.Checked)
            {
                status = _ipccCallStatus.Name;
                status = status.Remove(0, Math.Min(13, status.Length));
            }
            else
                status = CurrentItem.Tag.ToString();

            var dailyData = (DailyModel) _DailyDataBindingSource.Current;

            if (status != _IPCCState.Text)
            {
                EventLogger.LogAndSaveNewEvent("Status Changed: " + status);

                if (String.IsNullOrEmpty(_IPCCState.Text))
                {
                    if (IsDifferentShift())
                        dailyData = (DailyModel)_DailyDataBindingSource.Current;
                    dailyData.AddCallEvent(CallEventTypes.LogIn);
                    //if (SelectedContact != null)
                    //    if (SelectedContact.Events.LastCallEvent.EventType.Is(CallEventTypes.CallEnd))
                    //        SelectedContact.AddCallEvent((CallEventTypes.CallStart));
                }

                switch (status)
                {
                    case "Wrapup":
                        IPCCLevel("red");
                        if (CurrentContact != null)
                        {
                            CurrentContact.AddCallEvent(CallEventTypes.CallEnd);
                            CurrentContact = null;
                            if (SelectedContact != null)
                                SelectedContact.AddCallEvent((CallEventTypes.CallStart));
                        }
                        if (SelectedContact != null)
                            SelectedContact.AddCallEvent(CallEventTypes.Wrapup);
                        break;
                    case "Reserved":
                        _IPCCTimer.Interval = 125;
                        dailyData.AddCallEvent(CallEventTypes.CallStart);
                        if (autoNewCallToolStripMenuItem.Checked)
                        {
                            editContact.bindingNavigatorAddNewItem_Click(_IPCCState, new EventArgs());
                            SelectedContact.AddCallEvent(CallEventTypes.Reserved);
                        }
                        ChangeCallStateMenuItem(talkingToolStripMenuItem);
                        break;
                    case "Talking":
                        IPCCLevel("amber");

                        if(Settings.Default.PullIPCCCallData)
                            PullIPCCCallData();

                        if (CurrentContact != null)
                            CurrentContact.AddCallEvent(CallEventTypes.Talking);
                        else if (SelectedContact != null)
                            SelectedContact.AddCallEvent(CallEventTypes.Talking);                   
                        break;
                    case "Hold":
                        IPCCLevel("red");
                        if (CurrentContact != null)
                            CurrentContact.AddCallEvent(CallEventTypes.Hold);
                        else if (SelectedContact != null)
                            SelectedContact.AddCallEvent(CallEventTypes.Hold);
                        break;
                    case "NotReady":
                        IPCCLevel("red");
                        if (String.IsNullOrEmpty(_IPCCState.Text) || SelectedContact == null)
                        {
                            dailyData.AddCallEvent(CallEventTypes.NotReady);
                            if (SelectedContact != null)
                                SelectedContact.AddCallEvent(CallEventTypes.LogIn);
                        }
                        else
                        {
                            dailyData.AddCallEvent(CallEventTypes.CallStart);
                            SelectedContact.AddCallEvent(CallEventTypes.NotReady);
                        }
                        break;
                    case "Ready":
                        IPCCLevel("green");
                        dailyData.AddCallEvent(CallEventTypes.Ready);
                        if (SelectedContact != null)
                            SelectedContact.AddCallEvent(CallEventTypes.Ready);
                        break;
                    case "":
                        IPCCLevel("white");
                        FinalizeEvents(dailyData);
                        break;
                    default:
                        _IPCCTimer.Interval = 500;
                        break;
                }
                ////_callStateTimeElapsed = TimeSpan.Zero;
                _IPCCState.Text = status;
                //ChangeCallStateMenuItem(status);
            }
            //else
            //{
            //    _callStateTimeElapsed = _callStateTimeElapsed.Add(new TimeSpan(0, 0, 0, 0, _IPCCTimer.Interval)); //new TimeSpan(_callStateTimeElapsed.Ticks + _IPCCTimer.Interval * 10000);
            //}
            
            if (StatsView.Visible)
            {
                if (!((DateTime.Now - _statsViewUpdate).TotalSeconds > 1)) return;
                StatsView.UpdateStats(dailyData);
                _statsViewUpdate = DateTime.Now;
            }
            else
                _CallStateTime.Text = SelectedContact != null ? TimeSpanToString(DateTime.Now - SelectedContact.Events.LastCallEvent.Timestamp) : TimeSpanToString(DateTime.Now - dailyData.Events.LastCallEvent.Timestamp);
        }
        private DateTime _statsViewUpdate = DateTime.Now;

        private void FinalizeEvents(DailyModel dailyData)
        {
            if (CurrentContact != null)
            {
                if (CurrentContact.Events.LastCallEvent.EventType.Is(CallEventTypes.NotReady))
                {
                    dailyData.ImportCallEvent(SelectedContact.Events.LastCallEvent.Copy());
                    SelectedContact.ChangeLastEventType(CallEventTypes.CallEnd);
                }
                CurrentContact.AddCallEvent(CallEventTypes.LogOut);
                CurrentContact = null;
            }
            else if (SelectedContact != null)
            {
                if (SelectedContact.Events.LastCallEvent.EventType.Is(CallEventTypes.NotReady))
                {
                    dailyData.ImportCallEvent(SelectedContact.Events.LastCallEvent.Copy());
                    SelectedContact.ChangeLastEventType(CallEventTypes.CallEnd);
                }
                SelectedContact.AddCallEvent(CallEventTypes.LogOut);
            }

            dailyData.AddCallEvent(CallEventTypes.LogOut);
        }

        private void PullIPCCCallData()
        {
            if (SelectedContact == null) return;

            var cacheRequest = new CacheRequest { AutomationElementMode = AutomationElementMode.Full, TreeScope = TreeScope.Children };
            cacheRequest.Add(AutomationElement.NameProperty);
            cacheRequest.Add(ValuePattern.Pattern);
            cacheRequest.Push();
            var gridLines = _ipccCallDataTable.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Custom));
            cacheRequest.Pop();

            object cachedPattern;
            string value;
            gridLines[0].CachedChildren[7].TryGetCachedPattern(ValuePattern.Pattern, out cachedPattern);
            if (cachedPattern != null)
            {
                value = ((ValuePattern) cachedPattern).Current.Value;
                if (value.Contains("LAT"))
                {
                    SelectedContact.Fault.LAT = true;
                    SelectedContact.Service.WasSearched["SCAMPSDN"] = true;
                    SelectedContact.Service.WasSearched["DIMPSDN"] = true;
                }
                else if (value.Contains("LIP"))
                {
                    SelectedContact.Fault.LIP = true;
                }
                else if (value.Contains("CAB"))
                {
                    SelectedContact.Fault.ONC = true;
                }
                else if (value.Contains("DTV"))
                {
                    SelectedContact.Fault.DTV = true;
                }
                else if (value.Contains("MTV"))
                {
                    SelectedContact.Fault.MTV = true;
                }
                else if (value.Contains("NBN"))
                {
                    //SelectedContact.Fault.LAT = true;
                }

                if (value.Length > 8)
                {
                    var substring = value.Substring(value.Length - 8, 8);
                    if (substring.IsDigits())
                        SelectedContact.Fault.PR = substring;
                }
            }

            gridLines[0].CachedChildren[4].TryGetCachedPattern(ValuePattern.Pattern, out cachedPattern);
            if (cachedPattern != null)
            {
                value = ((ValuePattern) cachedPattern).Current.Value;
                if (!SelectedContact.FindDNMatch(value))
                    SelectedContact.FindMobileMatch(value);
            }

            gridLines[0].CachedChildren[5].TryGetCachedPattern(ValuePattern.Pattern, out cachedPattern);
            if (cachedPattern != null)
            {
                value = ((ValuePattern)cachedPattern).Current.Value;
                if (!SelectedContact.FindDNMatch(value))
                    SelectedContact.FindMobileMatch(value);
            }

            gridLines[0].CachedChildren[6].TryGetCachedPattern(ValuePattern.Pattern, out cachedPattern);
            if (cachedPattern != null)
            {
                value = ((ValuePattern)cachedPattern).Current.Value;
                if (!SelectedContact.FindICONMatch(value))
                    SelectedContact.FindCMBSMatch(value);
            }

            gridLines[0].CachedChildren[9].TryGetCachedPattern(ValuePattern.Pattern, out cachedPattern);
            if (cachedPattern != null)
            {
                value = ((ValuePattern)cachedPattern).Current.Value;
                if (value.Contains("OK"))
                    SelectedContact.IDok = true;
            }
        }

        private static string TimeSpanToString(TimeSpan time)
        {
            return time.Hours > 0 ? String.Format("{0}:{1:00}:{2:00}",time.Hours, time.Minutes, time.Seconds) : String.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
        }

        private void IPCCLevel(string level)
        {
            switch (level)
            {
                case "white": // logged off.
                    _IPCCTimer.Interval = 500;
                    _CallStateTime.BackColor = Color.WhiteSmoke;
                    _CallStateTime.ForeColor = Color.DarkSlateGray;
                    break;
                case "green": // ready
                    _IPCCTimer.Interval = 250;
                    _CallStateTime.BackColor = Color.OliveDrab;
                    _CallStateTime.ForeColor = Color.PaleGoldenrod;
                    break;
                case "amber": // Talking
                    _IPCCTimer.Interval = 500;
                    _CallStateTime.BackColor = Color.Chocolate;
                    _CallStateTime.ForeColor = Color.PaleGoldenrod;
                    break;
                case "red": // Not Ready, Hold, Wrap Up, 178,34,34
                    _IPCCTimer.Interval = 250;
                    _CallStateTime.BackColor = Color.FromArgb(178, 34, 34);
                    _CallStateTime.ForeColor = Color.FromArgb(178, 34, 34);//.LightGoldenrodYellow;
                    break;
            }
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
                    case "logInToolStripMenuItem":
                        logInToolStripMenuItem.Enabled = false;
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = false;
                        wrapUpToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = true;
                        notReadyToolStripMenuItem.Enabled = true;
                        break;
                    case "notReadyToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = true;
                        wrapUpToolStripMenuItem.Enabled = true;
                        talkingToolStripMenuItem.Enabled = false;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = true;
                        break;
                    case "readyToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = true;
                        wrapUpToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = false;
                        notReadyToolStripMenuItem.Enabled = true;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = true;
                        break;
                    case "reservedToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = false;
                        wrapUpToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = true;
                        logOutToolStripMenuItem.Enabled = false;
                        notReadyToolStripMenuItem.Enabled = true;
                        break;
                    case "talkingToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = true;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = false;
                        wrapUpToolStripMenuItem.Enabled = true;
                        notReadyToolStripMenuItem.Enabled = false;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = false;
                        break;
                    case "holdToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = true;
                        notReadyToolStripMenuItem.Enabled = false;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = false;
                        break;
                    case "wrapUpToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = true;
                        talkingToolStripMenuItem.Enabled = false;
                        notReadyToolStripMenuItem.Enabled = true;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = true;
                        break;
                    case "logOutToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = false;
                        wrapUpToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = false;
                        logInToolStripMenuItem.Enabled = true;
                        notReadyToolStripMenuItem.Enabled = false;
                        break;
                }
            }
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

        private void OpenURL_Click(object sender, EventArgs e)
        {
            UpdateMenuObject.newItem_Click(sender, e);
        }





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
        }






        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Working Date Checker /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        internal bool IsDifferentShift()
        {
            // If Date is right, or Agent isn't logged out, then don't do anything.
            if (_DailyDataBindingSource.Count > 0)
                if (((DailyModel) _DailyDataBindingSource.Current).Date.LongDate == DateTime.Today || _IPCCState.Text != Resources.IPCC_Unmonitored_String)
                {return false;}

            
            // If today doesnt exist, create it, otherwise change the day.
            if (DailyDataDataStore.DailyData.All(x => x.Date.LongDate != DateTime.Today))
            {
                DailyDataDataStore.DailyData.AddNew();
                DateFilterItems.AddNew();

                DateBindingSource.Position = DateFilterItems.Count - 1;
                _DailyDataBindingSource.Position = DailyDataDataStore.DailyData.Count - 1;

                Settings.Default.WorkingDate = DateTime.Today;
                File.Delete("Log.txt");
            }
            else if (((DailyModel)_DailyDataBindingSource.Current).Date.LongDate != DateTime.Today)
            {
                DateBindingSource.Position = DateFilterItems.IndexOf(DateFilterItems.FirstOrDefault(x => x.LongDate == DateTime.Today));
                _DailyDataBindingSource.Position = DateBindingSource.Position;

                Settings.Default.WorkingDate = DateTime.Today;
                File.Delete("Log.txt");
            }

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

            foreach (var control in settingsToolStripMenuItem.DropDownItems.OfType<CTToolStripItem>().Where(control => control.Advanced))
            {
                ((ToolStripItem)control).Visible = Settings.Default.AdvancedMode;
            }

            foreach (var control in helpToolStripMenuItem.DropDownItems.OfType<CTToolStripItem>().Where(control => control.Advanced))
            {
                ((ToolStripItem)control).Visible = Settings.Default.AdvancedMode;
            }

            foreach (var control in _CallStateTime.DropDownItems.OfType<CTToolStripItem>().Where(control => control.Advanced))
            {
                ((ToolStripItem)control).Visible = Settings.Default.AdvancedMode;
            }

            foreach (var control in editContact._CallHistoryContextMenu.Items.OfType<CTToolStripItem>().Where(control => control.Advanced))
            {
                ((ToolStripItem)control).Visible = Settings.Default.AdvancedMode;
            }

            
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

    }
}











//var callGrid = _ipccWindow.Get<TestStack.White.UIItems.TableItems.Table>(SearchCriteria.ByAutomationId("m_callGrid"));
//                            var callGridRow = callGrid.Rows[0];
//                            // Caller ID
//                            if (callGridRow.Cells[3].Value != null)
//                            {
//                                SelectedContact.FindMobileMatch(callGridRow.Cells[3].Value.ToString());
//                                SelectedContact.FindDNMatch(callGridRow.Cells[3].Value.ToString());
//                            }
//                            // Service No
//                            if (callGridRow.Cells[4].Value != null)
//                            {
//                                SelectedContact.FindMobileMatch(callGridRow.Cells[4].Value.ToString());
//                                SelectedContact.FindDNMatch(callGridRow.Cells[4].Value.ToString());
//                            }
//                            // Acc No
//                            if (callGridRow.Cells[5].Value != null)
//                            {
//                                SelectedContact.FindCMBSMatch(callGridRow.Cells[5].Value.ToString());
//                                SelectedContact.FindICONMatch(callGridRow.Cells[5].Value.ToString());
//                            }
//                            // IVR Selection
//                            if (callGridRow.Cells[6].Value != null)
//                            {
//                                var selection = callGridRow.Cells[6].Value.ToString();
//                                if (selection.Contains("LAT"))
//                                    SelectedContact.Fault.LAT = true;
//                                else if (selection.Contains("LIP"))
//                                    SelectedContact.Fault.LIP = true;
//                                else if (selection.Contains("ONC"))
//                                    SelectedContact.Fault.ONC = true;
//                                else if (selection.Contains("NBN"))
//                                    SelectedContact.Fault.NFV = true;
//                                else if (selection.Contains("MTV"))
//                                    SelectedContact.Fault.MTV = true;
//                            }
//                            // ID ok
//                            if (callGridRow.Cells[8].Value != null)
//                            {
//                                if (callGridRow.Cells[8].Value.ToString().Contains("OK"))
//                                    SelectedContact.IDok = true;
//                            }