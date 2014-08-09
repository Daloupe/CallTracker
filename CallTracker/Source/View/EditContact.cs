using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.RegularExpressions;

using CallTracker.Model;
using CallTracker.Data;
using CallTracker.Helpers;

namespace CallTracker.View
{

    public partial class EditContact : UserControl
    {
        private UserDataStore DataStore;
        //private Dictionary<string, PanelBase> ServicePanels;
        public static Dictionary<ServiceTypes, ServiceView> ServiceViews;
        public Main MainForm;

        public EditContact(Main _mainform)
        {
            InitializeComponent();
            
            _OutcomeTooltip.SetToolTip(_Outcome, "Problem Report");

            MainForm = _mainform;
            
            Location = MainForm.ControlOffset;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            splitContainer2.MouseWheel += splitContainer2_MouseWheel;
            splitContainer2.Panel2.MouseWheel += splitContainer2_MouseWheel;
            HfcPanel.MouseEnter += splitContainer2_MouseEnter;

            ServiceViews = new Dictionary<ServiceTypes, ServiceView>
            {
                {ServiceTypes.LAT, new ServiceView(this, "LAT")},
                {ServiceTypes.LIP, new ServiceView(this, "LIP")},
                {ServiceTypes.ONC, new ServiceView(this, "ONC")},
                {ServiceTypes.NFV, new ServiceView(this, "NFV")},
                {ServiceTypes.NBF, new ServiceView(this, "NBF")},
                {ServiceTypes.DTV, new ServiceView(this, "DTV")},
                {ServiceTypes.MTV, new ServiceView(this, "MTV")},
                {ServiceTypes.NONE, null}
            };
            foreach(var view in ServiceViews)
            {
                if (view.Key != ServiceTypes.NONE)
                    view.Value.ContextMenuItem.Tag = view.Value.CheckBox.Tag = view.Key;
            }
            ServiceView.Symptoms = new BindingList<string>();
            ServiceView.Equipment = new BindingList<string>();
        }

        public void OnParentLoad()
        {
            _PR.AttachMenu(_PRContextMenu);
            _NPR.AttachMenu(_PRContextMenu);
            _Dn.AttachMenu(_DialContextMenu);
            _Mobile.AttachMenu(_DialContextMenu);
            _Symptom.AttachMenu(_SeverityMenuStrip);

            _Outcome.BindComboBox(Main.ServicesStore.servicesDataSet.Outcomes.Select(x => x.Acronym).ToList(), customerContactsBindingSource);
            _BookingType.BindComboBox(Enum.GetValues(typeof(BookingType)), customerContactsBindingSource);
            _BookingTimeSlot.BindComboBox(Enum.GetValues(typeof(BookingTimeslot)), customerContactsBindingSource);

            DataStore = MainForm.DataStore;

            customerContactsBindingSource.PositionChanged += contactsListBindingSource_PositionChanged;
            customerContactsBindingSource.DataSource = DataStore.Contacts;
            customerContactsBindingSource.Position = DataStore.Contacts.Count;

            if (customerContactsBindingSource.Count == 0)
            {
                flowLayoutPanel1.Enabled = false;
                ServiceTypePanel.Enabled = false;
                FaultPanel.Enabled = false;
                _Note.Enabled = false;
            }
        }

        public void Init()
        {
            //_PR.AttachMenu(_PRContextMenu);
            //_NPR.AttachMenu(_PRContextMenu);
            //_Dn.AttachMenu(_DialContextMenu);
            //_Mobile.AttachMenu(_DialContextMenu);
            //_Symptom.AttachMenu(_SeverityMenuStrip);

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Contact Navigator ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        void contactsListBindingSource_PositionChanged(object sender, EventArgs e)
        {

            if (customerContactsBindingSource.Count == 0)
            {
                flowLayoutPanel1.Enabled = false;
                ServiceTypePanel.Enabled = false;
                FaultPanel.Enabled = false;
                _Note.Enabled = false;

                _Note.DataBindings.Clear();

                CurrentService = ServiceViews[ServiceTypes.NONE];
            }
            else
            {
                flowLayoutPanel1.Enabled = true;
                ServiceTypePanel.Enabled = true;
                FaultPanel.Enabled = true;
                _Note.Enabled = true;

                MainForm.SelectedContact.NestedChange -= SelectedContact_NestedChange;
                MainForm.SelectedContact = DataStore.Contacts[customerContactsBindingSource.Position];
                MainForm.SelectedContact.NestedChange += SelectedContact_NestedChange;

                _NoteContextMenuStrip.Items[0].PerformClick();
                CurrentService = ServiceViews[MainForm.SelectedContact.Fault.AffectedServiceType];

            }
            //_Note.DataBindings.Clear();
            //_Note.DataBindings.Add(new Binding("Text", customerContactsBindingSource, "Note", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        void SelectedContact_NestedChange(object sender, PropertyChangedEventArgs e)
        {
            // Swap Panels
            if(e.PropertyName == "AffectedServices")
                UpdateCurrentPanel();

            // Update Note
            if (_Note.DataBindings.Count > 0)
                _Note.DataBindings[0].ReadValue();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DataStore.Contacts.Add(new CustomerContact(1));
            customerContactsBindingSource.Position = DataStore.Contacts.Count;
            _WorkReadyTimer.Enabled = false;
            _WorkReadyTimerDisplay.Text = "Work Ready: 00:00";
            _WorkReadyTimerDisplay.BackColor = Color.FromArgb(180, 238, 121);
        }

        public void DeleteCalls()
        {
            //DataStore.Contacts.Add(new CustomerContact(1));
            customerContactsBindingSource.DataSource = DataStore.Contacts;
            customerContactsBindingSource.Position = DataStore.Contacts.Count;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Product Codes ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private ServiceView currentService;
        private ServiceView CurrentService
        {
            get { return currentService; }
            set
            {
                if (value == currentService)
                {
                    currentService.Panel.SetDataSource(MainForm.SelectedContact.Service);
                    return;
                }

                ServiceView.Symptoms.Clear();
                _Symptom._ComboBox.DataSource = null;
                _Symptom._ComboBox.DataBindings.Clear();
                ServiceView.Equipment.Clear();
                _Equipment._ComboBox.DataSource = null;
                _Equipment._ComboBox.DataBindings.Clear();

                if (currentService != null)
                {
                    currentService.RemoveRowChangedEvents();
                    splitContainer2.Panel2.Controls.Remove(currentService.Panel);
                    currentService.ContextMenuItem.Checked = false;
                    currentService.Panel.RemoveEvents(splitContainer2_MouseEnter);
                    currentService.CheckBox.ForeColor = Color.Black;
                }

                currentService = value;

                if (currentService != null)
                {
                    if (currentService.IsInitialized == false)
                        currentService.Init();
                    currentService.AddRowChangedEvents();
                    splitContainer2.Panel2.Controls.Add(currentService.Panel);
                    currentService.ContextMenuItem.Checked = true;
                    currentService.Panel.ConnectEvents(splitContainer2_MouseEnter);
                    currentService.Panel.SetDataSource(MainForm.SelectedContact.Service);
                    MainForm.SelectedContact.Fault.AffectedServiceType = ((ServiceTypes)Enum.Parse(typeof(ServiceTypes), currentService.ServiceType.ProductCode, true));
                    currentService.CheckBox.Checked = true;
                    currentService.CheckBox.ForeColor = Color.DarkRed;
                }
                else
                {
                    MainForm.SelectedContact.Fault.AffectedServiceType = ServiceTypes.NONE;
                }
              
            }
        }

        private void UpdateCurrentPanel()
        {
            //if (ServiceLock)
            //    return;

            ServiceTypes affectedServices = MainForm.SelectedContact.Fault.AffectedServices;

            foreach (ServiceTypes service in Enum.GetValues(typeof(ServiceTypes)))
            {
                if ((affectedServices & service) != 0 || affectedServices == 0)
                {                  
                    CurrentService = ServiceViews[service];                
                    break;
                }
            }
        }

        //private bool ServiceLock;

        private void _ServiceMenu_Click(object sender, EventArgs e)
        {
            //ServiceLock = true;
            CurrentService = ServiceViews[(ServiceTypes)((ToolStripMenuItem)sender).Tag];
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !HandlingRightClick)
            {
                CheckBox cb = (CheckBox)sender;
                HandlingRightClick = true;
                if(cb.Checked == false)
                {
                    cb.Checked = true;
                }
                //ServiceLock = true;
                CurrentService = ServiceViews[(ServiceTypes)((CheckBox)sender).Tag];
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            HandlingRightClick = false;
            //CheckBox cb = (CheckBox)sender;
            //if (CurrentService != null && CurrentService.CheckBox.Checked == false)
            //{
            //    ServiceLock = false;
            //    UpdateCurrentPanel();
            //}
        }

        private bool HandlingRightClick { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Note /////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SwitchNote(object sender, EventArgs e)
        {
            ToolStripMenuItem cm = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem item in _NoteContextMenuStrip.Items.OfType<ToolStripMenuItem>())
            {
                if (item == cm)
                    item.Checked = true;
                else
                    item.Checked = false;
            }
            _Note.DataBindings.Clear();
            string tag = cm.Tag.ToString();
            _Note.DataBindings.Add(new Binding("Text", customerContactsBindingSource, tag, true, DataSourceUpdateMode.OnPropertyChanged));
            if (tag == "ICONNote")
            {
                _Note.DataBindings[0].ReadValue();
                _Note.ReadOnly = true;
            }
            else
                _Note.ReadOnly = false;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_Note.Text);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Splitter /////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private const int SPLITTER_1_MIN = 0;
        private const int SPLITTER_1_MAX = 180;
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (splitContainer1.SplitterDistance > SPLITTER_1_MAX)
                splitContainer1.SplitterDistance = SPLITTER_1_MAX;
        }

        private void splitContainer1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int dist = splitContainer1.SplitterDistance;

            if (dist == SPLITTER_1_MAX)
                dist = SPLITTER_1_MIN;
            else if (dist == SPLITTER_1_MIN)
                dist = SPLITTER_1_MAX;
            else if (dist < SPLITTER_1_MAX / 2)
                dist = SPLITTER_1_MIN;
            else
                dist = SPLITTER_1_MAX;

            splitContainer1.SplitterDistance = dist;
        }

        private static List<int> SplitterRows = new List<int> { 153, 122, 99, 67, 35, 0};
        private const int SPLITTER_2_MIN = 0;
        private const int SPLITTER_2_MAX = 155;
        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (splitContainer2.SplitterDistance > SPLITTER_2_MAX)
                splitContainer2.SplitterDistance = SPLITTER_2_MAX;
            else if (splitContainer2.SplitterDistance < SPLITTER_2_MIN)
                splitContainer2.SplitterDistance = SPLITTER_2_MIN;
        }

        private void splitContainer2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int dist = splitContainer2.SplitterDistance;

            if (dist == SPLITTER_2_MAX)
                dist = SPLITTER_2_MIN;
            else if (dist == SPLITTER_2_MIN)
                dist = SPLITTER_2_MAX;
            else if (dist < SPLITTER_2_MAX - SPLITTER_2_MIN)
                dist = SPLITTER_2_MIN;
            else
                dist = SPLITTER_2_MAX;

            splitContainer2.SplitterDistance = dist;
        }

        void splitContainer2_MouseWheel(object sender, MouseEventArgs e)
        {
           
            int dist = splitContainer2.SplitterDistance;

            if (e.Delta > 0)
            {
                int newNeg = SplitterRows.Where(item => dist < item).OrderBy(item => Math.Abs(item - dist)).FirstOrDefault();
                if (newNeg > dist)
                    splitContainer2.SplitterDistance = newNeg;
            }
            else
            {
                int newNeg = SplitterRows.Where(item => dist > item).OrderBy(item => Math.Abs(item - dist)).FirstOrDefault();
                if (newNeg < dist)
                    splitContainer2.SplitterDistance = newNeg;
            }
        }

        void splitContainer2_MouseEnter(object sender, EventArgs e)
        {
            splitContainer2.Focus();
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
        private void PaintGrayBorderMain(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.WhiteSmoke,
              0,
              0,
              ((Control)sender).Width - 1,
              ((Control)sender).Height - 1);
         
        }

        private void _Dial_click(object sender, EventArgs e)
        {
            Point offsets = new Point();
            string[] offsetFile = File.ReadAllLines("IPCCOffsets.txt");

            offsets.X = Convert.ToInt16(Regex.Split(offsetFile[1], ",")[1]);
            offsets.Y = Convert.ToInt16(Regex.Split(offsetFile[1], ",")[2]);

            WindowHelper.IPCCAutomation(((LabelledTextBoxLong)_DialContextMenu.SourceControl)._DataField.Text, offsets);
        }

        private void _Transfer_click(object sender, EventArgs e)
        {
            Point offsets = new Point();
            string[] offsetFile = File.ReadAllLines("IPCCOffsets.txt");

            offsets.X = Convert.ToInt16(Regex.Split(offsetFile[0], ",")[1]);
            offsets.Y = Convert.ToInt16(Regex.Split(offsetFile[0], ",")[2]);

            WindowHelper.IPCCAutomation(((LabelledTextBoxLong)_DialContextMenu.SourceControl)._DataField.Text, offsets);
        }

        private void _PRContextMenu_Clicked(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                if (((LabelledTextBox)sender).Name == "_NPR")
                {
                    dispatchToolStripMenuItem.Enabled = false;
                    stapleToParentToolStripMenuItem.Enabled = false;
                    clearAndCloseToolStripMenuItem.Enabled = false;
                }
                else
                {
                    dispatchToolStripMenuItem.Enabled = true;
                    stapleToParentToolStripMenuItem.Enabled = true;
                    clearAndCloseToolStripMenuItem.Enabled = true;
                }
        }

        private void callHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.settingMenuItem_Click(MainForm.callHistoryToolStripMenuItem, e);
        }

        private void _Outcome_SelectedIndexChanged(object sender, EventArgs e)
        {
            _OutcomeTooltip.SetToolTip(_Outcome._ComboBox, Main.ServicesStore.servicesDataSet.Outcomes.First(x => x.Acronym == _Outcome._ComboBox.Text).Description);
        }

        private void _NewCallMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem ownerItem = e.ClickedItem.OwnerItem as ToolStripMenuItem;
            if (ownerItem != null)
            {
                //uncheck all item
                foreach (ToolStripMenuItem item in ownerItem.DropDownItems)
                {
                    item.Checked = false;
                }
            }
        }
        private void _PRContextMenu_Opened(object sender, EventArgs e)
        {
            ContextMenuStrip menu = (ContextMenuStrip)sender;
            //if (menu.Tag == null)
            //    e.Cancel = true;
            //menu.Tag = null;
            if (menu.SourceControl.Parent.Name == "_NPR")
            {
                viewPRToolStripMenuItem.Enabled = false;

                dispatchToolStripMenuItem.Enabled = false;
                stapleToParentToolStripMenuItem.Enabled = false;
                clearAndCloseToolStripMenuItem.Enabled = false;
            }
            else
            {
                viewPRToolStripMenuItem.Enabled = false;

                dispatchToolStripMenuItem.Enabled = false;
                stapleToParentToolStripMenuItem.Enabled = false;
                clearAndCloseToolStripMenuItem.Enabled = false;

                //dispatchToolStripMenuItem.Enabled = true;
                //stapleToParentToolStripMenuItem.Enabled = true;
                //clearAndCloseToolStripMenuItem.Enabled = true;
            }
        }

        private void _SeverityMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
                foreach (ToolStripMenuItem item in _SeverityMenuStrip.Items)
                {
                    item.Checked = false;
                }

                _SeverityMenuStrip.Text = e.ClickedItem.Text;
                ((ToolStripMenuItem)e.ClickedItem).Checked = true;
        }

        private void _Symptom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CurrentService != null)
                CurrentService.UpdateSeverity();
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {
            FillPolygonPointFillMode(e);
        }

        public void FillPolygonPointFillMode(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.White);

            // Create points that define polygon.

            Point point1 = new Point(this.Height / 2 + 3, this.Width / 2 - 2);
            Point point2 = new Point(this.Height / 2, this.Width / 2 + 2);
            Point point3 = new Point(this.Height / 2 - 3, this.Width / 2 - 2);
            Point point4 = new Point(this.Height / 2 + 3, this.Width / 2 - 2);

            Point[] curvePoints = { point1, point2, point3, point4 };

            // Define fill mode.
            FillMode newFillMode = FillMode.Winding;

            // Draw polygon to screen.
            e.Graphics.FillPolygon(blueBrush, curvePoints, newFillMode);
        }

        private void hToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if(item.Checked)
            {
                item.BackColor = Color.LightSlateGray;
                item.ForeColor = Color.Black;
            }else
            {
                item.BackColor = Color.WhiteSmoke;
                item.ForeColor = Color.Black;
            }
        }

        private DateTime _WorkReadyTimeElapsed;
        private void _WorkReadyTimer_Tick(object sender, EventArgs e)
        {
            _WorkReadyTimeElapsed = _WorkReadyTimeElapsed.AddMilliseconds(1000);
            _WorkReadyTimerDisplay.Text = "Work Ready: " + _WorkReadyTimeElapsed.ToString("mm:ss");
        }

        private void _WorkReadyTimerDisplay_Click(object sender, EventArgs e)
        {
            if (_WorkReadyTimer.Enabled == false)
            {
                _WorkReadyTimeElapsed = new DateTime();
                _WorkReadyTimer.Enabled = true;
                _WorkReadyTimerDisplay.BackColor = Color.FromArgb(245, 120, 88);
            }
            else
            {
                _WorkReadyTimer.Enabled = false;
                _WorkReadyTimerDisplay.Text = "Work Ready: 00:00";
                _WorkReadyTimerDisplay.BackColor = Color.FromArgb(180, 238, 121);
            }
        } 

    }

    public class EnumList
    {
        public static IEnumerable<KeyValuePair<T, string>> Of<T>()
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(p => new KeyValuePair<T, string>(p, p.ToString()))
                .ToList();
        }
    }
}
