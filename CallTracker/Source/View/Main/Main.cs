using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;
using PropertyChanged;

using CallTracker.Model;
using CallTracker.Helpers;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;
using WatiN.Core;
using Control = System.Windows.Forms.Control;
using Form = System.Windows.Forms.Form;

namespace CallTracker.View
{
    [ImplementPropertyChanged]
    public partial class Main : Form
    {
        public static string SelectedMenuProduct = String.Empty;
        public readonly Point ControlOffset = new Point(0, -1);

        internal UserDataStore UserDataStore = new UserDataStore();
        internal DailyDataRepository DailyDataDataStore;
        internal static ServicesData ServicesStore = new ServicesData();

        private CustomerContact _selectedContact;
        internal CustomerContact SelectedContact
        {
            get {return _selectedContact; }
            set
            {
                if (_IPCCState.Text == "Talking")
                        CurrentContact = _selectedContact;
                else if (_selectedContact != null)
                    _selectedContact.FinishUp();
                _selectedContact = value;
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
            EventLogger.StatusLabel = _StatusLabel;

            _splash.StepProgress("Setting App Location");
            SetAppLocation();

            //versionStripMenuItem.Text = "Version " + Properties.Settings.Default.Version;

            CoreAppXmlConfiguration.Instance.BusyTimeout = 2000;
            CoreAppXmlConfiguration.Instance.FindWindowTimeout = 2000;
            CoreAppXmlConfiguration.Instance.PopupTimeout= 2000;
            CoreAppXmlConfiguration.Instance.TooltipWaitTime = 2000;
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
            _splash.UpdateProgress("Loading Resources", 15);
            UserDataStore = UserDataStore.ReadFile();
            _splash.UpdateProgress("Loading User Data", 20);
            DailyDataDataStore = DailyDataRepository.ReadData();
            _splash.UpdateProgress("Loading Contact Data", 25);


            DateFilterItems = new BindingList<DateFilterItem>(DailyDataDataStore.DailyData.Select(x => x.Date).ToList());
            DateBindingSource.DataSource = DateFilterItems;
            _DailyDataBindingSource.DataSource = DailyDataDataStore.DailyData;
            IsDifferentShift();
            DateBindingSource.PositionChanged += _DateSelector_PositionChanged;

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

            StatsView = new StatsView();

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

            _ViewPanel.Controls.Add(StatsView);

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
            UpdateProgressBar("Bring to front");
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
            IETabActivator.OnAction += UpdateProgressBar;
            HotkeyController.OnAction += UpdateProgressBar;

            _splash.UpdateProgress("Finishing", 99);
            _splash.UpdateProgress("", 100);
            UpdateProgressBar(0, "Finished Loading", EventLogLevel.ClearStatus);
            ChangeCallStateMenuItem(logOutToolStripMenuItem);

            FadingToolTip = new FadingTooltip();
            AboutScreen = new AboutScreen();
            BindSmartPasteForm = new BindSmartPasteForm(this);
            BugReport = new BugReport();

            DidYouKnow = new DidYouKnow();
            if (Properties.Settings.Default.ShowTipsOnStartup)
                DidYouKnow.Show();
        }

        void _DateSelector_PositionChanged(object sender, EventArgs e)
        {
            //_DailyDataBindingSource.Filter = "Date = " + ((DateFilterItem)DateBindingSource.Current).LongDate;
            _DailyDataBindingSource.Position = DateBindingSource.Position;
            //_DailyDataBindingSource.IndexOf(DailyData.FirstOrDefault(x => x.Date == ((DateFilterItem)DateBindingSource.Current).LongDate));
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
            EventLogger.SaveLog();
            if (HotKeys != null)
            {
                HotkeyController.OnAction -= UpdateProgressBar;
                HotKeys.Dispose();
            }

            IETabActivator.OnAction -= UpdateProgressBar;      

            if (FadingToolTip != null)
                FadingToolTip.Dispose();

            if (CancelLoad == false)
            {
                DisposeIPCC();

                Properties.Settings.Default.Save();
                if (SelectedContact != null)
                    SelectedContact.FinishUp();

                editContact.customerContactsBindingSource.RemoveFilter();
                DailyDataDataStore.DailyData.RemoveFilter();
                UserDataStore.SaveFile(UserDataStore);
                DailyDataDataStore.WriteData();
                ServicesStore.WriteData();
            }

            if (ServicesStore != null)
                ServicesStore.servicesDataSet.Dispose();

            if (DateBindingSource != null)
                DateBindingSource.Dispose();
        }

        public void RemovePasteBind(PasteBind bind)
        {
            if (UserDataStore.PasteBinds.Contains(bind))
            {
                UserDataStore.PasteBinds.Remove(bind);
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
            Properties.Settings.Default.ShowStatusBar = showStatusBarToolStripMenuItem.Checked;
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
        //private TestStack.White.UIItems.TableItems.Table _ipccCallGrid;
        private TimeSpan _callStateTimeElapsed;

        private bool CheckForIpcc()
        {
            if (monitorIPCCToolStripMenuItem.Checked)
            {
                if (_ipccProcess == null)
                {
                    EventLogger.LogNewEvent("Trying to find IPCC", EventLogLevel.Status);
                    if (InitIpccMonitor() == false)
                    {
                        //EventLogger.LogNewEvent("Unable to Find IPCC", EventLogLevel.Status);
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
            foreach (Process pList in Process.GetProcesses())
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
            _ipccWindow = _ipccApplication.GetWindow(SearchCriteria.ByAutomationId("SoftphoneForm"), InitializeOption.NoCache);
            _ipccCallStatus = _ipccWindow.Get<TestStack.White.UIItems.TextBox>(SearchCriteria.ByAutomationId("StatusBar.Pane3"));
            _ipccDialButton = _ipccWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnDial"));
            _ipccTransferButton = _ipccWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnTransfer"));
            //_ipccCallGrid = _ipccWindow.Get<TestStack.White.UIItems.TableItems.Table>(SearchCriteria.ByAutomationId("m_callGrid"));

            return true;
        }

        void IPCCProcess_Exited(object sender, EventArgs e)
        {        
            monitorIPCCToolStripMenuItem.Checked = false;
            DisposeIPCC();
        }

        void DisposeIPCC()
        {
            _IPCCTimer.Enabled = false;
            if (_ipccProcess != null)
            {
                _ipccProcess.Exited -= IPCCProcess_Exited;
                _ipccProcess.Dispose();
                _ipccProcess = null;
            }
        }

        public void DialOrTransfer(string value)
        {
            if (!CheckForIpcc())
                return;
            
            if (_IPCCState.Text == "Talking")
                _ipccTransferButton.Click();
            else
                _ipccDialButton.Click();

            _ipccApplication.WaitWhileBusy();
            //var dialPadWindow = _ipccWindow.Get<Window>(SearchCriteria.ByAutomationId("DialPadForm"));
            var dialPadWindow = _ipccApplication.GetWindow(SearchCriteria.ByAutomationId("DialPadForm"), InitializeOption.NoCache);
            if (dialPadWindow == null)
            {
                EventLogger.LogNewEvent("Unable to Find CTI Dial Pad", EventLogLevel.Status);
                return;
            }

            var dialPadNumber = dialPadWindow.Get<TestStack.White.UIItems.ListBoxItems.ComboBox>(SearchCriteria.ByAutomationId("dialedNumberComboBox"));
            dialPadNumber.SetValue(value);

        }

        private void monitorIPCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckForIpcc())
                monitorIPCCToolStripMenuItem.Checked = false;

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
                        talkingToolStripMenuItem.Enabled = true;
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
        private void _CallStateTime_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == monitorIPCCToolStripMenuItem) return;

            ChangeCallStateMenuItem((ToolStripMenuItem)e.ClickedItem);
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
                _callStateTimeElapsed = TimeSpan.Zero;
                _CallStateTime.BackColor = Color.WhiteSmoke;
                _CallStateTime.ForeColor = Color.DarkSlateGray;
                _CallStateTime.Text = TimeSpanToString(_callStateTimeElapsed);
                _IPCCTimer.Enabled = false;
                monitorIPCCToolStripMenuItem.Checked = false;
                return;
            }

            //if (CurrentItem.Name == "logInToolStripMenuItem")
            //    ChangeCallStateMenuItem(notReadyToolStripMenuItem);

            // If IPCC monitoring is off, pass in values from IPCC menu for testing.
            string status;
            if (monitorIPCCToolStripMenuItem.Checked)
            {
                status = _ipccCallStatus.Name;
                status = status.Remove(0, Math.Max(13, status.Length));
            }
            else
                status = CurrentItem.Tag.ToString();

            if (status != _IPCCState.Text)
            {
                var dailyData = (DailyModel) _DailyDataBindingSource.Current;
                if (String.IsNullOrEmpty(_IPCCState.Text))
                {
                    if(IsDifferentShift())
                        dailyData = (DailyModel) _DailyDataBindingSource.Current;
                    dailyData.AddCallEvent(CallEventTypes.LogIn);
                }

                switch (status)
                {
                    case "Wrapup":
                        IPCCLevel("red");
                        if (CurrentContact != null)
                        {
                            CurrentContact.AddCallEvent(CallEventTypes.CallEnd);
                            CurrentContact = null;
                        }
                        SelectedContact.AddCallEvent(CallEventTypes.Wrapup);
                        break;
                    case "Reserved":
                        _IPCCTimer.Interval = 500;
                        dailyData.AddCallEvent(CallEventTypes.Reserved);
                        if (editContact.autoNewCallToolStripMenuItem.Checked)
                        {
                            editContact.bindingNavigatorAddNewItem_Click(_IPCCState, new EventArgs());
                            SelectedContact.AddCallEvent(CallEventTypes.Reserved);
                        }

                        //if (Properties.Settings.Default.PullIPCCCallData)
                        //{
                        //    EventLogger.LogAndSaveNewEvent("Getting Svc No From IPCC");
                        //    var serviceNumber =
                        //        _ipccWindow.Get<TestStack.White.UIItems.TableItems.TableCell>(
                        //            SearchCriteria.ByText("Svc No"));
                        //    SelectedContact.FindDNMatch(serviceNumber.Value.ToString());
                        //    SelectedContact.FindMobileMatch(serviceNumber.Value.ToString());

                        //    EventLogger.LogAndSaveNewEvent("Getting Caller ID From IPCC");
                        //    var contactNumber =
                        //        _ipccWindow.Get<TestStack.White.UIItems.TableItems.TableCell>(
                        //            SearchCriteria.ByText("Caller ID"));
                        //    SelectedContact.FindDNMatch(contactNumber.Value.ToString());
                        //    SelectedContact.FindMobileMatch(contactNumber.Value.ToString());

                        //    EventLogger.LogAndSaveNewEvent("Getting Acc No From IPCC");
                        //    var accountNumber =
                        //        _ipccWindow.Get<TestStack.White.UIItems.TableItems.TableCell>(
                        //            SearchCriteria.ByText("Acc No"));
                        //    SelectedContact.FindCMBSMatch(accountNumber.Value.ToString());
                        //    SelectedContact.FindICONMatch(accountNumber.Value.ToString());

                        //    EventLogger.LogAndSaveNewEvent("Getting ID ok From IPCC");
                        //    var idok =
                        //        _ipccWindow.Get<TestStack.White.UIItems.TableItems.TableCell>(
                        //            SearchCriteria.ByText("IVR Status"));
                        //    if (idok.Value.ToString().Contains("OK"))
                        //        SelectedContact.IDok = true;

                        //    EventLogger.LogAndSaveNewEvent("Getting IVR Selection From IPCC");
                        //    var ivrSelection =
                        //        _ipccWindow.Get<TestStack.White.UIItems.TableItems.TableCell>(
                        //            SearchCriteria.ByText("IVR Selection"));
                        //}

                        break;
                    case "Talking":
                        IPCCLevel("amber");
                        if (CurrentContact != null)
                            CurrentContact.AddCallEvent(CallEventTypes.Talking);
                        else
                            SelectedContact.AddCallEvent(CallEventTypes.Talking);                   
                        break;
                    case "Hold":
                        IPCCLevel("red");
                        if (CurrentContact != null)
                            CurrentContact.AddCallEvent(CallEventTypes.Hold);
                        else
                            SelectedContact.AddCallEvent(CallEventTypes.Hold);
                        break;
                    case "NotReady":
                        IPCCLevel("red");
                        if (SelectedContact != null)
                            SelectedContact.AddCallEvent(CallEventTypes.NotReady);
                        break;
                    case "Ready":
                        IPCCLevel("green");
                        dailyData.AddCallEvent(CallEventTypes.Ready);
                        if (SelectedContact != null)
                            SelectedContact.AddCallEvent(CallEventTypes.Ready);
                        break;
                    case "":
                        IPCCLevel("white");
                        dailyData.AddCallEvent(CallEventTypes.LogOut);
                        if (CurrentContact != null)
                        {
                            CurrentContact.AddCallEvent(CallEventTypes.CallEnd);
                            CurrentContact = null;
                        }
                        SelectedContact.AddCallEvent(CallEventTypes.LogOut);
                        break;
                    default:
                        _IPCCTimer.Interval = 1000;
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

        private void IPCCLevel(string level)
        {
            switch (level)
            {
                case "white":
                    _IPCCTimer.Interval = 2000;
                    _CallStateTime.BackColor = Color.WhiteSmoke;
                    _CallStateTime.ForeColor = Color.DarkSlateGray;
                    break;
                case "green":
                    _IPCCTimer.Interval = 1000;
                    _CallStateTime.BackColor = Color.OliveDrab;
                    _CallStateTime.ForeColor = Color.PaleGoldenrod;
                    break;
                case "amber":
                    _IPCCTimer.Interval = 1000;
                    _CallStateTime.BackColor = Color.Chocolate;
                    _CallStateTime.ForeColor = Color.PaleGoldenrod;
                    break;
                case "red":
                    _IPCCTimer.Interval = 1000;
                    _CallStateTime.BackColor = Color.Firebrick;
                    _CallStateTime.ForeColor = Color.LightGoldenrodYellow;
                    break;
            }
        }








        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Resource menu events /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void toolStripServiceSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((ToolStripComboBox)sender).OwnerItem.GetCurrentParent().Focus();
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

        public void SetProgressBarStep(int steps, string eventString, EventLogLevel logLevel = EventLogLevel.Verbose)
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
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
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
        // Working Date Checker /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        internal bool IsDifferentShift()
        {
            // If Date is right, or Agent isn't logged out, then don't do anything.
            if (_DailyDataBindingSource.Count > 0)
                if (((DailyModel) _DailyDataBindingSource.Current).Date.LongDate == DateTime.Today || !String.IsNullOrEmpty(_IPCCState.Text))
                {return false;}

            
            // If today doesnt exist, create it, otherwise change the day.
            if (DailyDataDataStore.DailyData.All(x => x.Date.LongDate != DateTime.Today))
            {
                DailyDataDataStore.DailyData.AddNew();
                DateFilterItems.AddNew();

                DateBindingSource.Position = DateFilterItems.Count - 1;
                _DailyDataBindingSource.Position = DailyDataDataStore.DailyData.Count - 1;

                Properties.Settings.Default.WorkingDate = DateTime.Today;
                File.Delete("Data\\Log.txt");
            }
            else if (((DailyModel)_DailyDataBindingSource.Current).Date.LongDate != DateTime.Today)
            {
                DateBindingSource.Position = DateFilterItems.IndexOf(DateFilterItems.FirstOrDefault(x => x.LongDate == DateTime.Today));
                _DailyDataBindingSource.Position = DateBindingSource.Position;

                Properties.Settings.Default.WorkingDate = DateTime.Today;
                File.Delete("Data\\Log.txt");
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
            Properties.Settings.Default.PullIPCCCallData = pullIPCCCallDataToolStripMenuItem.Checked;
        }

        private void clearMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.WarningLevel = clearMessagesToolStripMenuItem.Checked;
        }

        private void autoSearchToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoSearch = autoSearchEnabledToolStripMenuItem.Checked;
        }

        private void autoSearchActiveWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoSearchIgnoreActiveWindow = autoSearchActiveWindowToolStripMenuItem.Checked;
        }

        private void toolTipAsControlBoxToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ToolTipAsControlBox = toolTipAsControlBoxToolStripMenuItem.Checked;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutScreen.Show();
        }

        private void newPageIfRequiredToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoSearchOpenNew = newPageIfRequiredToolStripMenuItem.Checked;
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

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugReport.Show();
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