using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using CallTracker.Model;
using CallTracker.Helpers;

namespace CallTracker.View
{
    public partial class EditContact : UserControl
    {
        private UserDataStore DataStore;
        internal Main MainForm;
        //internal List<CheckBox> ServiceCheckboxes;

        public EditContact(Main _mainform)
        {
            InitializeComponent();
            MainForm = _mainform;
            Location = MainForm.ControlOffset;

            // Fault Panel Mouse Wheel Focus////////////////////////////////////////////////////////////////////
            splitContainer2.MouseWheel += splitContainer2_MouseWheel;
            splitContainer2.MouseHover += splitContainer2_MouseEnter;

            _ServicePanel.MouseHover += splitContainer2_MouseEnter;
            foreach (Control control in _ServicePanel.Controls)
            {
                control.MouseHover += splitContainer2_MouseEnter;
                foreach (LabelledBase control2 in control.Controls.OfType<LabelledBase>())
                    control2._Label.MouseHover += splitContainer2_MouseEnter;
            }

            HfcPanel.MouseHover += splitContainer2_MouseEnter;
            foreach (Control control in HfcPanel.Controls)
                control.MouseHover += splitContainer2_MouseEnter;
            ////////////////////////////////////////////////////////////////////////////////////////////////////     

            ServicePanel.Symptoms = new BindingList<string>();
            ServicePanel.Equipment = new BindingList<string>();
            _ServicePanel.PreInit(this);
        }

        public void OnParentLoad()
        {
            _ServicePanel.Init();

            DataStore = MainForm.DataStore;
            customerContactsBindingSource.PositionChanged += contactsListBindingSource_PositionChanged;
            //customerContactsBindingSource.Filter = "Id = 100";
            customerContactsBindingSource.DataSource = DataStore.Contacts;

            customerContactsBindingSource.MoveLast();
            //customerContactsBindingSource.Position = DataStore.Contacts.Count;

           

            _Outcome.BindComboBox(Main.ServicesStore.servicesDataSet.Outcomes.Select(x => x.Description).ToList(), customerContactsBindingSource);
            _BookingType.BindComboBox(Enum.GetValues(typeof(BookingType)).Cast<BookingType>().Select(x => x.ToString()).ToList(), customerContactsBindingSource);
            _BookingTimeSlot.BindComboBox(Enum.GetValues(typeof(BookingTimeslot)).Cast<BookingTimeslot>().Select(x => x.ToString()).ToList(), customerContactsBindingSource);
            _Action.BindComboBox(new List<string>(), customerContactsBindingSource);

            if (customerContactsBindingSource.Count == 0)
            {
                //DataStore.Contacts.Add(new CustomerContact(1));
                flowLayoutPanel1.Enabled = false;
                ServiceTypePanel.Enabled = false;
                FaultPanel.Enabled = false;
                _Note.Enabled = false;
            }
        }

        public void Init()
        {
            _PR.AttachMenu(_PRContextMenu);
            _NPR.AttachMenu(_PRContextMenu);
            _Dn.AttachMenu(_DialContextMenu);
            _Name.AttachMenu(_NameContextMenu);
            _Mobile.AttachMenu(_DialContextMenu);
            _Symptom.AttachMenu(_SeverityMenuStrip);
            _Username.AttachMenu(_UsernameContextMenu);
            _ServicePanel._ServiceHeading.AttachMenu(_ServiceContextMenu);
            //_OutcomeTooltip.SetToolTip(_Outcome, "Problem Report");
            //ServiceCheckboxes = new List<CheckBox> { _LAT, _LIP, _ONC, _DTV, _MTV, _NFV, _NBF };
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
                MainForm.SelectedContact.NestedChange -= SelectedContact_NestedChange;
                _Note.DataBindings.Clear();

                _ServicePanel.ChangeService(ServiceTypes.NONE);
            }
            else
            {
                flowLayoutPanel1.Enabled = true;
                ServiceTypePanel.Enabled = true;
                FaultPanel.Enabled = true;
                _Note.Enabled = true;


                MainForm.SelectedContact.NestedChange -= SelectedContact_NestedChange;
                MainForm.SelectedContact = (CustomerContact)customerContactsBindingSource.Current;
                MainForm.SelectedContact.NestedChange += SelectedContact_NestedChange;

                _BookingDate.BindDatePickerBox(customerContactsBindingSource);

                _NoteContextMenuStrip.Items[0].PerformClick();
                //CurrentService = MainForm.SelectedContact.Fault.AffectedServices;
                UpdateCurrentPanel();
                _Outcome.BindComboBox(Main.ServicesStore.servicesDataSet.Outcomes.Select(x => x.Description).ToList(), customerContactsBindingSource);
                UpdateActions();
            }
        }

        public void SelectedContact_NestedChange(object sender, PropertyChangedEventArgs e)
        {
            // Swap Panels
            if (e.PropertyName == "AffectedServices")
                UpdateCurrentPanel();

            //if (e.PropertyName == "Outcome")
            //    UpdateActions();

            // Update Note
            if (_Note.DataBindings.Count > 0)
                _Note.DataBindings[0].ReadValue();
        }

        public void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //customerContactsBindingSource.Add(new CustomerContact());
            //customerContactsBindingSource.Position = DataStore.Contacts.Count;
            customerContactsBindingSource.AddNew();
        }

        public void DeleteCalls()
        {
            customerContactsBindingSource.DataSource = DataStore.Contacts;
            customerContactsBindingSource.Position = DataStore.Contacts.Count;
        }

        public void UpdateActions()
        {
            List<string> query = (from a in Main.ServicesStore.servicesDataSet.Actions
                                  where a.OutcomesRow.Description == MainForm.SelectedContact.Fault.Outcome
                                  select a.Description).ToList();
            if(query.Count > 0)
                _Action.BindComboBox(query, customerContactsBindingSource);

            if (!query.Contains(MainForm.SelectedContact.Fault.Action))
                MainForm.SelectedContact.Fault.Action = "";
        }





        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Service //////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private ServiceTypes currentService;
        private ServiceTypes CurrentService
        {
            get { return currentService; }
            set
            {
                if (value == currentService && currentService.IsNot(ServiceTypes.NONE))
                    return;
                ServicePanel.Symptoms.Clear();
                _Symptom._ComboBox.DataSource = null;
                _Symptom._ComboBox.DataBindings.Clear();
                ServicePanel.Equipment.Clear();
                _Equipment._ComboBox.DataSource = null;
                _Equipment._ComboBox.DataBindings.Clear();

                //_ServicePanel.currentFlowPanel.CheckBox.ForeColor = Color.Black;
                currentService = value;
                //MainForm.SelectedContact.Fault.AffectedServiceType = currentService;
                _ServicePanel.ChangeService(currentService);
                //if (currentService.IsNot(ServiceTypes.NONE))
                //{
                //    MainForm.toolStripServiceSelector.Text = _ServicePanel.currentFlowPanel.Service.ProblemStylesRow.Description;
                //}
            }
        }

        //private void UpdateMainService()
        //{

        //    ServiceTypes affectedServices = MainForm.SelectedContact.Fault.AffectedServices;

        //    foreach (ServiceTypes service in Enum.GetValues(typeof(ServiceTypes)))
        //    {
        //        if ((affectedServices & service) != 0 || affectedServices.Is(ServiceTypes.NONE))
        //        {
        //            CurrentService = service;
        //            break;
        //        }
        //    }
        //}

        private void UpdateCurrentPanel()
        {
            //Console.WriteLine("Updating panel");
            ServiceTypes affectedServices = MainForm.SelectedContact.Fault.AffectedServices;

            foreach (ServiceTypes service in Enum.GetValues(typeof(ServiceTypes)))
            {
                if ((affectedServices & service) != 0 || affectedServices == 0)
                {
                    //foreach (CheckBox control in ServiceTypePanel.Controls)
                    //{
                    //    if ((ServiceTypes)control.Tag == service)// && service.Is(MainForm.SelectedContact.Fault.AffectedServiceType))
                    //    {
                    //        control.ForeColor = Color.DarkRed;
                    //        CurrentService = service;   
                    //    }
                    //}
                    CurrentService = service;  
                    break;
                }
            }
        }

        private void _ServiceMenu_Click(object sender, EventArgs e)
        {
            _ServicePanel.currentFlowPanel.CheckBox.Checked = true;
            CurrentService = (ServiceTypes)((ToolStripMenuItem)sender).Tag;
        }

        private bool HandlingRightClick { get; set; }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (e.Button == MouseButtons.Right && !HandlingRightClick)
            {  
                HandlingRightClick = true;
                if (cb.Checked == false)
                {
                    cb.Checked = true;
                    CurrentService = (ServiceTypes)cb.Tag;
                }
                else
                {
                    if (((ServiceTypes)cb.Tag) != _ServicePanel.currentFlowPanel.ServiceType)
                        CurrentService = (ServiceTypes)cb.Tag;
                    else
                        UpdateCurrentPanel();  
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (cb.Checked == false)
                    cb.Checked = true;
                else
                    cb.Checked = false;        
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            HandlingRightClick = false;
        }







        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Note /////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SwitchNote(object sender, EventArgs e)
        {
            ToolStripMenuItem cm = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem item in _NoteContextMenuStrip.Items.OfType<ToolStripMenuItem>())
                item.Checked = false;
            cm.Checked = true;
            _Note.DataBindings.Clear();
            string tag = cm.Tag.ToString();
            _Note.DataBindings.Add(new Binding("Text", customerContactsBindingSource, tag, true, DataSourceUpdateMode.OnPropertyChanged));
            
            //_Note.ReadOnly = false;
            if (tag == "ICONNote")
            {
                _Note.DataBindings[0].ReadValue();
                //_Note.ReadOnly = true;
            }
            else if (tag == "PRTemplate")
                _Note.DataBindings[0].ReadValue();
                
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_Note.Text);
            _Note.SelectAll();
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

        private static List<int> SplitterRows = new List<int> { 0, 25, 55, 84, 114, 135, 164};// 153, 122, 99, 67, 35, 0};
        private const int SPLITTER_2_MIN = 0;
        private const int SPLITTER_2_MAX = 164;
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
        // Outcome Context Menu /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void _Outcome_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_OutcomeTooltip.SetToolTip(_Outcome._ComboBox, Main.ServicesStore.servicesDataSet.Outcomes.First(x => x.Acronym == _Outcome._ComboBox.Text).Description);

            UpdateActions();
            if (MainForm.SelectedContact.Fault.Outcome == "Outage")
            {
                //_BookingType._ComboBox.SelectedItem = BookingType.NRQ;
                //customerContactsBindingSource.ResetCurrentItem();

                MainForm.SelectedContact.UpdatePrTemplateReplacements(PRGenerators.AROAnswers);

                if (((ToolStripMenuItem)_NoteContextMenuStrip.Items["pRTemplateToolStripMenuItem"]).Checked)
                    _Note.DataBindings[0].ReadValue();
            }
            
        }







        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // DN Mobile Menu ///////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void _NewCallMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem ownerItem = e.ClickedItem.OwnerItem as ToolStripMenuItem;
            if (ownerItem == null) return;
            foreach (ToolStripMenuItem item in ownerItem.DropDownItems)
                item.Checked = false;
        }

        private void _Dial_click(object sender, EventArgs e)
        {
            MainForm.DialOrTransfer("0" + ((LabelledTextBoxLong)_DialContextMenu.SourceControl.Parent)._DataField.Text);
        }







        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // PR Context Menu ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void _PRContextMenu_Opened(object sender, EventArgs e)
        {
            var menu = (ContextMenuStrip)sender;
            //if (menu.Tag == null)
            //    e.Cancel = true;
            //menu.Tag = null;
            if (menu.SourceControl == null)
                return;
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

        private void _PRContextMenu_Clicked(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
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


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Symptom Context Menu ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void _Symptom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!currentService.Is(ServiceTypes.NONE))
                _ServicePanel.UpdateSeverity();
        }






        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Severity Context Menu ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void _SeverityMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripMenuItem item in _SeverityMenuStrip.Items)
                item.Checked = false;

            _SeverityMenuStrip.Text = e.ClickedItem.Text;
            ((ToolStripMenuItem)e.ClickedItem).Checked = true;
        }

        private void SeverityItem_CheckedChanged(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            if (item.Checked)
            {
                item.BackColor = Color.LightSlateGray;
                item.ForeColor = Color.Black;
            }
            else
            {
                item.BackColor = Color.WhiteSmoke;
                item.ForeColor = Color.Black;
            }
        }
       
        private void _SearchSCAMPS_click(object sender, EventArgs e)
        {
            HotkeyController.CreateNewIE("https://scamps.optusnet.com.au/cm.html?q=" + ((ToolStripMenuItem)sender).Tag.ToString());
        }

        private void _TextFieldContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            e.ClickedItem.Tag = ((LabelledTextBoxLong)((ContextMenuStrip)sender).SourceControl.Parent)._DataField.Text;
        }




        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Call history Context Menu ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void callHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.settingMenuItem_Click(MainForm.callHistoryToolStripMenuItem, e);
        }

        private void clearCallHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customerContactsBindingSource.SuspendBinding();
            customerContactsBindingSource.Clear();
            Properties.Settings.Default.NextContactsId = 0;
            customerContactsBindingSource.ResumeBinding();
            customerContactsBindingSource.AddNew();
        }

        private DateTime _lasttime;
        private bool _opened;
        protected virtual void _MenuButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (_CallHistoryContextMenu.Visible == false)
            {
                _CallHistoryContextMenu.Opening += ContextMenuStrip_Opening;
                _CallHistoryContextMenu.Show(_CallMenuButton.Owner, _CallMenuButton.Bounds.X + _CallMenuButton.Width, _CallMenuButton.Bounds.Y);
                _opened = true;
            }
            else
            {
                _CallHistoryContextMenu.Hide();
                _opened = false;
            }
        }

        public virtual void ContextMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            var menu = (ContextMenuStrip)sender;
            menu.Closing -= ContextMenuStrip_Closing;

            if (DateTime.UtcNow.Subtract(_lasttime).Milliseconds > 9 && _opened == false)
            {
                e.Cancel = true;
                return;
            }
            _CallMenuButton.Image = Properties.Resources.ContextMenu_Closed_Dark;
            _lasttime = DateTime.UtcNow;
        }

        protected virtual void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            var menu = (ContextMenuStrip)sender;
            menu.Opening -= ContextMenuStrip_Opening;

            if (DateTime.UtcNow.Subtract(_lasttime).Milliseconds < 9 && _opened == true)
            {
                e.Cancel = true;
                return;
            }
            _lasttime = DateTime.UtcNow;
            _CallMenuButton.Image = Properties.Resources.ContextMenu_Open_Dark;
            menu.Closing += ContextMenuStrip_Closing;
        }







        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Name Menu ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void _NameContextMenu_Opening(object sender, CancelEventArgs e)
        {
            _IDokToolStripMenuItem.Checked = MainForm.SelectedContact.IDok;
        }

        private void _IDok_Click(object sender, EventArgs e)
        {
            MainForm.SelectedContact.IDok = _IDokToolStripMenuItem.Checked;
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

        private void PaintLightGrayBorder(object sender, PaintEventArgs e)
        {

        }

        private void PaintGrayBorderMain(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.WhiteSmoke,
              0,
              0,
              ((Control)sender).Width - 1,
              ((Control)sender).Height - 1);

        }

        private void _DialContextMenu_Opening(object sender, CancelEventArgs e)
        {
            //if (((ContextMenuStrip)sender).SourceControl != null)
            //    Console.WriteLine(((ContextMenuStrip)sender).SourceControl.Name);
        }

        private void _Important_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;
            checkBox.ImageIndex = checkBox.Checked ? 1 : 0;
        }
    }
}
