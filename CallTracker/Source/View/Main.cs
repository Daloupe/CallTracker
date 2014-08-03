using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.ComponentModel;
using System.Text;

using System.Diagnostics;

using ProtoBuf;
using PropertyChanged;

using CallTracker.Model;
using CallTracker.Helpers;
using CallTracker.Data;

//using System.Windows.Automation;
//using TestStack.White.Configuration;
//using TestStack.White.Factory;
//using TestStack.White.UIItems;
//using TestStack.White.UIItems.Finders;
//using TestStack.White.UIItems.WindowItems;
//using TestStack.White.Recording;
//using TestStack.White.UIItemEvents;
//using TestStack.White.UIItems.Actions;

namespace CallTracker.View
{
    [ImplementPropertyChanged]
    public partial class Main : Form
    {
        public static string SelectedMenuProduct = String.Empty;

        public Point ControlOffset = new Point(0, -1);

        internal CustomerContact SelectedContact { get; set; }

        internal UserDataStore DataStore = new UserDataStore();
        internal ResourceData ResourceStore = new ResourceData();
        internal static ServicesData ServicesStore = new ServicesData();
        //private static EventLogger EventLog = new EventLogger();

        internal static ICONNoteGenerator NoteGen;

        internal EditLogins editLogins;
        internal EditGridLinks editGridLinks;
        internal EditSmartPasteBinds editSmartPasteBinds;
        internal EditContact editContact;
        internal CallHistory callHistory;
        internal HelpKeyCommands helpKeyCommands;
        internal LATRatecodes latRateCodes;
        internal DatabaseView databaseView;

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
            ResourceStore = ResourceStore.ReadFile();

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

            editLogins = new EditLogins();
            editGridLinks = new EditGridLinks();
            editSmartPasteBinds = new EditSmartPasteBinds();
            callHistory = new CallHistory();
            helpKeyCommands = new HelpKeyCommands();
            latRateCodes = new LATRatecodes();
            databaseView = new DatabaseView();

            _ViewPanel.Controls.Add(editLogins);
            _ViewPanel.Controls.Add(editGridLinks);
            _ViewPanel.Controls.Add(editSmartPasteBinds);
            _ViewPanel.Controls.Add(callHistory);
            _ViewPanel.Controls.Add(helpKeyCommands);
            _ViewPanel.Controls.Add(latRateCodes);
            _ViewPanel.Controls.Add(databaseView);

            editContact.Init();
            editLogins.Init(this, loginsViewMenuItem);
            editSmartPasteBinds.Init(this, pasteBindsViewMenuItem);
            editGridLinks.Init(this, gridLinksViewMenuItem);
            callHistory.Init(this, callHistoryToolStripMenuItem);
            helpKeyCommands.Init(this, viewKeyCommandsMenuItem);
            latRateCodes.Init(this, LATRatecodeMenuItem);
            databaseView.Init(this, databaseEditorToolStripMenuItem);

            IETabActivator.OnAction += UpdateProgressBar;
            HotkeyController.OnAction += UpdateProgressBar;

            toolStripServiceSelector.ComboBox.BindingContext = this.BindingContext;
            toolStripServiceSelector.ComboBox.DataSource = ServicesStore.servicesDataSet.Services.Select(x => x.ProductCode).ToList();

            transfersToolStripMenuItem.UpdateObject = new TransfersMenuItem(ServicesStore.servicesDataSet);
            NoteGen = new ICONNoteGenerator(ServicesStore.servicesDataSet);
            HotKeys = new HotkeyController(this);

            //this.Enabled = true;
            UpdateProgressBar(0, "Finished Loading", EventLogLevel.ClearStatus);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            DataStore.SaveFile(DataStore);
            ResourceStore.SaveFile(ResourceStore);
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


            //TestStack.White.Application application = TestStack.White.Application.Attach("cmake-gui");
            //Window window = application.GetWindow("CMake 2.8.12.1 - C:/Programming/Rust/piston-master/exam", InitializeOption.WithCache);

          
            //TestStack.White.UIItems.Panel button = window.Get<TestStack.White.UIItems.Panel>("BrowseSourceDirectoryButton");
            //button.Click();

            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            WindowHelper.IPCCAutomation(item.Tag.ToString(), new Point() { X = 732, Y = 63 });
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                settingMenuItem_Click(LATRatecodeMenuItem, new EventArgs());
                latRateCodes.Search(((ToolStripTextBox)sender).Text);
                LatRatecodeSearch.PerformClick();
            };
        }

        public void UpdateAutoComplete()
        {
            LatRatecodeSearch.AutoCompleteCustomSource = systemAutoCompleteSource;
            systemAutoCompleteSource.Clear();
            systemAutoCompleteSource.AddRange(ResourceStore.LATRatePlans.Select(p => p.RateCode).ToArray());
        }

        private void LATRatecodeMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).HideDropDown();
            ((ToolStripMenuItem)sender).Invalidate();
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
                this.Height = 259;
            else
                this.Height = 239;
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            Point[] points = { new Point(10, 10), new Point(100, 10), new Point(50, 100) };
            e.Graphics.DrawPolygon(new Pen(Color.Blue), points);
            Point[] points2 = { new Point(100, 100), new Point(200, 100), new Point(150, 10) };
            e.Graphics.FillPolygon(new SolidBrush(Color.Red), points2);
        }
    }
}
