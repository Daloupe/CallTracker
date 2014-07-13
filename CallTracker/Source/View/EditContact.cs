﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CallTracker.Model;

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

            MainForm = _mainform;
            DataStore = MainForm.DataStore;

            Location = MainForm.ControlOffset;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            splitContainer2.MouseWheel += splitContainer2_MouseWheel;
            HfcPanel.MouseEnter += splitContainer2_MouseEnter;

            //ServicePanels = new Dictionary<string,PanelBase>
            //{
            //    {"LAT", new LATPanel(_ServiceMenuLAT)},
            //    {"LIP", new LIPPanel(_ServiceMenuLIP)},
            //    {"ONC", new ONCPanel(_ServiceMenuONC)},
            //    {"NFV", new NBFPanel(_ServiceMenuNBF)},
            //    {"NBF", new NBFPanel(_ServiceMenuNBF)},
            //    {"DTV", new DTVPanel(_ServiceMenuDTV)},
            //    {"MTV", new MTVPanel(_ServiceMenuMTV)}
            //};

            ServiceViews = new Dictionary<ServiceTypes, ServiceView>
            {
                {ServiceTypes.LAT, new ServiceView(new LATPanel(), 
                                        new List<string>
                                        {
                                            "NDT",
                                            "COS",
                                            "NRR",
                                            "DTN",
                                            "DRP"
                                        }, 
                                        _ServiceMenuLAT,
                                        _LAT,
                                        "LAT", 
                                        "LAT", 
                                        "3")},
                {ServiceTypes.LIP, new ServiceView(new LIPPanel(), 
                                        new List<string>{
                                            "NDT",
                                            "COS",
                                            "NRR",
                                            "DTN",
                                            "DRP"}, 
                                        _ServiceMenuLIP,
                                        _LIP,
                                        "LAT", 
                                        "LIP", 
                                        "3")},
                {ServiceTypes.ONC, new ServiceView(new ONCPanel(), 
                                        new List<string>{
                                            "CCI",
                                            "DTR",
                                            "DRP",
                                            "LIC"}, 
                                        _ServiceMenuONC, 
                                        _ONC,
                                        "ONC", 
                                        "ONC", 
                                        "7")},
                {ServiceTypes.NFV, new ServiceView(new NFVPanel(), 
                                        new List<string>{
                                            "NDT",
                                            "COS",
                                            "NRR",
                                            "DTN"}, 
                                        _ServiceMenuNFV, 
                                        _NFV,
                                        "NBN", 
                                        "NVF", 
                                        "7")},
                {ServiceTypes.NBF, new ServiceView(new NBFPanel(), 
                                        new List<string>{
                                            "CCI",
                                            "DTR",
                                            "DRP",
                                            "LIC"},
                                        _ServiceMenuNBF,
                                        _NBF,
                                        "NBN", 
                                        "NBF", 
                                        "7")},
                {ServiceTypes.DTV, new ServiceView(new DTVPanel(), 
                                        new List<string>{
                                            "MSG",
                                            "NPI",
                                            "PPX",
                                            "DRP"}, 
                                        _ServiceMenuDTV, 
                                        _DTV,
                                        "DTV", 
                                        "DTV", 
                                        "6")},
                {ServiceTypes.MTV, new ServiceView(new MTVPanel(), 
                                        new List<string>{
                                            "NPI",
                                            "PPX"}, 
                                        _ServiceMenuMTV, 
                                        _MTV,
                                        "DLC", 
                                        "MTV", 
                                        "$")},
                {ServiceTypes.NONE, null}
            };        
            foreach(var view in ServiceViews)
            {
                if (view.Key != ServiceTypes.NONE)
                    view.Value.ContextMenuItem.Tag = view.Value.CheckBox.Tag = view.Value.ServiceType = view.Key;
            }
        }

        public void Init()
        {
            customerContactsBindingSource.PositionChanged += contactsListBindingSource_PositionChanged;
            customerContactsBindingSource.DataSource = DataStore.Contacts;
            customerContactsBindingSource.Position = DataStore.Contacts.Count;

            _Severity.DataSource = Enum.GetValues(typeof(FaultSeverity));
            _Outcome.DataSource = Enum.GetValues(typeof(Outcomes));
            _BookingTimeSlot.DataSource = Enum.GetValues(typeof(BookingTimeslot));

            
                ContextMenu cm = new ContextMenu();
                MenuItem cm1 = new MenuItem("Call Notes", new EventHandler(SwitchNote));
                cm1.Tag = "Note";
                cm1.Checked = true;
                MenuItem cm2 = new MenuItem("Generate ICON Note", new EventHandler(SwitchNote));
                cm2.Tag = "ICONNote";
                cm.MenuItems.Add(cm1);
                cm.MenuItems.Add(cm2);
                _Note.ContextMenu = cm;
            
            //CreateNoteMenu();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Contact Navigator ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        void contactsListBindingSource_PositionChanged(object sender, EventArgs e)
        {
            _Note.DataBindings.Clear();
            _Note.DataBindings.Add(new Binding("Text", customerContactsBindingSource, "Note", true, DataSourceUpdateMode.OnPropertyChanged));

            MainForm.SelectedContact.NestedChange -= SelectedContact_NestedChange;
            MainForm.SelectedContact = DataStore.Contacts[customerContactsBindingSource.Position];
            MainForm.SelectedContact.NestedChange += SelectedContact_NestedChange;

            CurrentService = ServiceViews[MainForm.SelectedContact.Fault.AffectedServiceType];
        }

        void SelectedContact_NestedChange(object sender, PropertyChangedEventArgs e)
        {
            // Swap Panels
            if(e.PropertyName == "AffectedServices")
                UpdateCurrentPanel();

            // Update Note
            if(_Note.DataBindings.Count > 0)
                _Note.DataBindings[0].ReadValue();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DataStore.Contacts.Add(new CustomerContact(1));
            customerContactsBindingSource.Position = DataStore.Contacts.Count;
        }

        public void DeleteCalls()
        {
            DataStore.Contacts.Add(new CustomerContact(1));
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
                    splitContainer2.Panel2.Controls.Remove(currentService.Panel);
                    currentService.ContextMenuItem.Checked = false;
                    currentService.Panel.RemoveEvents(splitContainer2_MouseEnter);
                    currentService.CheckBox.ForeColor = Color.Black;
                }

                currentService = value;

                if (currentService != null)
                {
                    _Symptom.DataSource = currentService.Symptoms;
                    splitContainer2.Panel2.Controls.Add(currentService.Panel);
                    currentService.ContextMenuItem.Checked = true;
                    currentService.Panel.ConnectEvents(splitContainer2_MouseEnter);
                    currentService.Panel.SetDataSource(MainForm.SelectedContact.Service);
                    MainForm.SelectedContact.Fault.AffectedServiceType = currentService.ServiceType;
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

            ServiceTypes affectedServices = (MainForm.SelectedContact.Fault.AffectedServices);

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
                HandlingRightClick = true;
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
            MenuItem cm = (MenuItem)sender;
            foreach (MenuItem item in cm.GetContextMenu().MenuItems)
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
                _Note.DataBindings[0].ReadValue();
        }

        //public void CreateNoteMenu()
        //{
        //    ContextMenu cm = new ContextMenu();
        //    MenuItem cm1 = new MenuItem("Call Notes", new EventHandler(SwitchNote));
        //    cm1.Tag = "Note";
        //    cm1.Checked = true;
        //    MenuItem cm2 = new MenuItem("Generate ICON Note", new EventHandler(SwitchNote));
        //    cm2.Tag = "ICONNote";
        //    cm.MenuItems.Add(cm1);
        //    cm.MenuItems.Add(cm2);
        //    _Note.ContextMenu = cm;
        //}

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




    }
}
