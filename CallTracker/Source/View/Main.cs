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

        internal CustomerContact SelectedContact { get; set; }

        internal UserDataStore DataStore = new UserDataStore();
        //internal ResourceData ResourceStore = new ResourceData();
        internal static ServicesData ServicesStore = new ServicesData();
        //private static EventLogger EventLog = new EventLogger();

        internal static ICONNoteGenerator NoteGen;

        internal EditLogins editLogins;
        internal EditGridLinks editGridLinks;
        internal EditSmartPasteBinds editSmartPasteBinds;
        internal EditContact editContact;
        internal CallHistory callHistory;
        internal HelpKeyCommands helpKeyCommands;
        internal DatabaseView databaseView;
        internal Ratecodes Ratecodes;

        private HotkeyController HotKeys;
        private AutoCompleteStringCollection systemAutoCompleteSource = new AutoCompleteStringCollection();

        public Main()
        {
            InitializeComponent();
            _StatusLabel.Tag = EventLogLevel.Status;
            EventLogger.StatusLabel = _StatusLabel;

            SetAppLocation();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

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

            UpdateProgressBar("Loading Service Store");
            ServicesStore.ReadData();
            UpdateProgressBar("Loading Main Data");
            DataStore = DataStore.ReadFile();
            UpdateProgressBar("Loading Resource Store");
            //ResourceStore = ResourceStore.ReadFile();

            SelectedContact = new CustomerContact();

            UpdateProgressBar("Creating Main View");
            editContact = new EditContact(this);
            _ViewPanel.Controls.Add(editContact);
            editContact.OnParentLoad();
            UpdateProgressBar("Bring to front");
            editContact.BringToFront();
            editContact.Visible = true;

           
        } 

        private void Main_Shown(object sender, EventArgs e)
        {
            UpdateProgressBar("Loading Views", EventLogLevel.Status);

            callHistory = new CallHistory();
            
            editLogins = new EditLogins();
            editGridLinks = new EditGridLinks();
            editSmartPasteBinds = new EditSmartPasteBinds();
            helpKeyCommands = new HelpKeyCommands();
            databaseView = new DatabaseView();
            Ratecodes = new Ratecodes();

            _ViewPanel.Controls.Add(callHistory);
            _ViewPanel.Controls.Add(editLogins);
            _ViewPanel.Controls.Add(editGridLinks);
            _ViewPanel.Controls.Add(editSmartPasteBinds);
            _ViewPanel.Controls.Add(helpKeyCommands);
            _ViewPanel.Controls.Add(databaseView);
            _ViewPanel.Controls.Add(Ratecodes);

            
            callHistory.Init(this, callHistoryToolStripMenuItem);
            editLogins.Init(this, loginsViewMenuItem);
            editSmartPasteBinds.Init(this, pasteBindsViewMenuItem);
            editGridLinks.Init(this, gridLinksViewMenuItem);
            helpKeyCommands.Init(this, viewKeyCommandsMenuItem);         
            databaseView.Init(this, databaseEditorToolStripMenuItem);
            Ratecodes.Init(this, ratecodesMenuItem);

            editContact.Init();

            transfersToolStripMenuItem.UpdateObject = new TransfersMenuItem(ServicesStore.servicesDataSet);

            toolStripServiceSelector.ComboBox.BindingContext = this.BindingContext;
            toolStripServiceSelector.ComboBox.DataSource = ServicesStore.servicesDataSet.Services.Select(x => x.ProblemStylesRow).Distinct().ToList();
            toolStripServiceSelector.ComboBox.DisplayMember = "Description";
            toolStripServiceSelector.ComboBox.ValueMember = "IFMSCode";
            toolStripServiceSelector.ComboBox.SelectedIndex = 0;

            NoteGen = new ICONNoteGenerator(ServicesStore.servicesDataSet);
            HotKeys = new HotkeyController(this);

            IETabActivator.OnAction += UpdateProgressBar;
            HotkeyController.OnAction += UpdateProgressBar;

            //this.Enabled = true;
            UpdateProgressBar(0, "Finished Loading", EventLogLevel.ClearStatus);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            DataStore.SaveFile(DataStore);
            //ResourceStore.SaveFile(ResourceStore);
            ServicesStore.WriteData();
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

        // Menu Bar ////////////////////////////////////////////////////////////////////////////////
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private ViewControlBase visibleSetting;
        private ViewControlBase VisibleSetting 
        {
            get { return visibleSetting; }
            set
            {
                if (value != null)
                {
                    statusStrip1.Hide();
                    value.ShowSetting();
                }else
                    statusStrip1.Show();

                if (visibleSetting != null)
                    visibleSetting.HideSetting();

                if (visibleSetting == value)
                {
                    statusStrip1.Show();
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
            Point offsets = new Point();
            string[] offsetFile = File.ReadAllLines("IPCCOffsets.txt");
            offsets.X = Convert.ToInt16(Regex.Split(offsetFile[0], ",")[1]);
            offsets.Y = Convert.ToInt16(Regex.Split(offsetFile[0], ",")[2]);

            //TestStack.White.Application application = TestStack.White.Application.Attach("cmake-gui");
            //Window window = application.GetWindow("CMake 2.8.12.1 - C:/Programming/Rust/piston-master/exam", InitializeOption.WithCache);

          
            //TestStack.White.UIItems.Panel button = window.Get<TestStack.White.UIItems.Panel>("BrowseSourceDirectoryButton");
            //button.Click();

            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            WindowHelper.IPCCAutomation(item.Tag.ToString(), offsets);
        }

        //private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Return)
        //    {
        //        settingMenuItem_Click(LATRatecodeMenuItem, new EventArgs());
        //        latRateCodes.Search(((ToolStripTextBox)sender).Text);
        //        LatRatecodeSearch.PerformClick();
        //    };
        //}

        //public void UpdateAutoComplete()
        //{
        //    LatRatecodeSearch.AutoCompleteCustomSource = systemAutoCompleteSource;
        //    systemAutoCompleteSource.Clear();
        //    systemAutoCompleteSource.AddRange(ResourceStore.LATRatePlans.Select(p => p.RateCode).ToArray());
        //}

        private void LATRatecodeMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            //((ToolStripMenuItem)sender).HideDropDown();
            //((ToolStripMenuItem)sender).Invalidate();
        }

        // Move Window ////////////////////////////////////////////////////////////////////////////////////
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

        // Misc ////////////////////////////////////////////////////////////////////////////////////
        private void PaintGrayBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.WhiteSmoke,
             0,
             0,
             ((Control)sender).Width - 1,
             ((Control)sender).Height - 1);
            base.OnPaint(e);
        }

        public void UpdateProgressBar(int percent, string _event, EventLogLevel _logLevel = EventLogLevel.Verbose)
        {
            EventLogger.LogNewEvent(_event, _logLevel);
            _StatusProgressBar.Value = percent;
        }

        public void UpdateProgressBar(string _event, EventLogLevel _logLevel = EventLogLevel.Verbose)
        {
            EventLogger.LogNewEvent(_event, _logLevel);
           _StatusProgressBar.PerformStep();
        }

        public void SetProgressBarStep(int _steps, string _event, EventLogLevel _logLevel = EventLogLevel.Verbose)
        {
            _StatusProgressBar.Maximum = _steps + 1;
            UpdateProgressBar(_event, _logLevel);
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

        private void _StatusContextMenu_MouseClick(object sender, MouseEventArgs e)
        {

        }

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

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            Point[] points = { new Point(10, 10), new Point(100, 10), new Point(50, 100) };
            e.Graphics.DrawPolygon(new Pen(Color.Blue), points);
            Point[] points2 = { new Point(100, 100), new Point(200, 100), new Point(150, 10) };
            e.Graphics.FillPolygon(new SolidBrush(Color.Red), points2);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // IPCC Monitor ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private Process IPCCProcess;
        private TestStack.White.Application IPCCApplication;
        private Window IPCCWindow;
        private TestStack.White.UIItems.TextBox IPCCCallStatus;

        private void monitorIPCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IPCCProcess == null && monitorIPCCToolStripMenuItem.Checked == true)
                if (InitIPCCMonitor() == false)
                    return;
            
            _IPCCTimer.Enabled = monitorIPCCToolStripMenuItem.Checked;
        }

        private void _IPCCTimer_Tick(object sender, EventArgs e)
        {
            string status = IPCCCallStatus.Name;
            monitorIPCCToolStripMenuItem.Text = status;
            switch(status)
            {
                case "AgentStatus: Work Ready":
                    editContact._WorkReadyTimerDisplay.PerformClick();
                    _IPCCTimer.Interval = 1000;
                    break;
                case "AgentStatus: On Call":
                    _IPCCTimer.Interval = 2000;
                    break;
                case "AgentStatus: Not Ready":
                    _IPCCTimer.Interval = 2000;
                    break;
                case "AgentStatus: Ready":
                    _IPCCTimer.Interval = 1000;
                    break;
                default:
                    _IPCCTimer.Interval = 1000;
                    break;
            }
            
        }

        private bool InitIPCCMonitor()
        {
            foreach (Process pList in Process.GetProcesses())
                if(pList.MainWindowTitle.Contains("IPCC Agent Desktop"))
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

        
    }
}
