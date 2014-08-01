using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        private Main MainForm;

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
        }

        public void OnParentLoad()
        {
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
            //_Severity.DataSource = Main.ServicesStore.servicesDataSet.SeverityCodes.Select(x => x.IFMSCode).ToList(); //Enum.GetValues(typeof(FaultSeverity));
            _Outcome.DataSource = Main.ServicesStore.servicesDataSet.Outcomes.Select(x => x.Acronym).ToList(); //Enum.GetValues(typeof(Outcomes));
            _BookingTimeSlot.DataSource = Enum.GetValues(typeof(BookingTimeslot));
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

                if(_Note.DataBindings.Count == 0)
                    foreach (MenuItem item in _Note.ContextMenu.MenuItems)
                        if (item.Checked == true)
                            _Note.DataBindings.Add(new Binding("Text", customerContactsBindingSource, item.Tag.ToString(), true, DataSourceUpdateMode.OnPropertyChanged));

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
                    return;

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

        private const int SPLITTER_2_MIN = 70;
        private const int SPLITTER_2_MAX = 258;
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
            if ((splitContainer2.SplitterDistance > 254 && e.Delta > 0) || (splitContainer2.SplitterDistance < 74 && e.Delta < 0))
                return;
            splitContainer2.SplitterDistance += e.Delta / 10;
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

        private void _Dial_click(object sender, EventArgs e)
        {
            WindowHelper.IPCCAutomation(((ToolStripMenuItem)sender).GetCurrentParent().Tag.ToString(), new Point() { X = 305, Y = 63 });
        }

        private void _Transfer_click(object sender, EventArgs e)
        {
            WindowHelper.IPCCAutomation(((ToolStripMenuItem)sender).GetCurrentParent().Tag.ToString(), new Point() { X = 735, Y = 63 });
        }

        private void _DialContextMenu_clicked(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
                _DialContextMenu.Tag = ((TextBox)sender).Text;
        }

        private void _PRMenu_Clicked(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                if (((TextBox)sender).Name == "_NPR")
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
            _OutcomeTooltip.SetToolTip(_Outcome, Main.ServicesStore.servicesDataSet.Outcomes.First(x => x.Acronym == _Outcome.Text).Description);
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
