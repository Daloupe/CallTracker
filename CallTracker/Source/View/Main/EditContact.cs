using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using CallTracker.Model;
using CallTracker.Helpers;
using Utilities.RegularExpressions;

namespace CallTracker.View
{
    public partial class EditContact : UserControl
    {
        internal Main MainForm;
        private bool _updateNote = true;

        public EditContact(Main mainform)
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);

            MainForm = mainform;
            Location = MainForm.ControlOffset;

            // Fault Panel Mouse Wheel Focus////////////////////////////////////////////////////////////////////
            splitContainer2.MouseWheel += splitContainer2_MouseWheel;
            splitContainer2.MouseHover += splitContainer2_MouseEnter;

            _ServicePanel.MouseHover += splitContainer2_MouseEnter;
            foreach (Control control in _ServicePanel.Controls)
            {
                control.MouseHover += splitContainer2_MouseEnter;
                foreach (var control2 in control.Controls.OfType<LabelledBase>())
                    control2._Label.MouseHover += splitContainer2_MouseEnter;
            }

            HfcPanel.MouseHover += splitContainer2_MouseEnter;
            foreach (Control control in HfcPanel.Controls)
                control.MouseHover += splitContainer2_MouseEnter;
            ////////////////////////////////////////////////////////////////////////////////////////////////////     

            //ServicePanel.Symptoms = new BindingList<string>();
            //ServicePanel.Equipment = new BindingList<string>();
            _ServicePanel.PreInit(this);
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

        public void OnParentLoad()
        {
            _ServicePanel.Init();

            MainForm._DailyDataBindingSource.ListChanged += _DailyDataBindingSource_PositionChanged;
            MainForm._DailyDataBindingSource.PositionChanged +=_DailyDataBindingSource_PositionChanged;
            customerContactsBindingSource.PositionChanged += contactsListBindingSource_PositionChanged;

            customerContactsBindingSource.DataSource = ((DailyModel)MainForm._DailyDataBindingSource.Current).Contacts;

            _Outcome.BindComboBox(Main.ServicesStore.servicesDataSet.Outcomes.Select(x => x.Description).ToList(), customerContactsBindingSource);
            _BookingType.BindComboBox(Enum.GetValues(typeof(BookingType)).Cast<BookingType>().Select(x => x.ToString()).ToList(), customerContactsBindingSource);
            _BookingTimeSlot.BindComboBox(Enum.GetValues(typeof(BookingTimeslot)).Cast<BookingTimeslot>().Select(x => x.ToString()).ToList(), customerContactsBindingSource);
            //_Action.BindComboBox(new List<string>(), customerContactsBindingSource);

            customerContactsBindingSource.MoveLast();

            _DateSelector.ComboBox.DataSource = MainForm.DateBindingSource;
            _DateSelector.ComboBox.DisplayMember = "ShortDate";
            _DateSelector.ComboBox.ValueMember = "LongDate";

            if (customerContactsBindingSource.Count != 0) return;

            flowLayoutPanel1.Enabled = false;
            ServiceTypePanel.Enabled = false;
            FaultPanel.Enabled = false;
            _Note.Enabled = false;
        }

        void _DailyDataBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (MainForm._DailyDataBindingSource.Count == 0)
                return;

            if (((DailyModel) MainForm._DailyDataBindingSource.Current).Contacts.Count < 2)
            {
                
                customerContactsBindingSource.SuspendBinding();
                customerContactsBindingSource.DataSource = ((DailyModel) MainForm._DailyDataBindingSource.Current).Contacts;
                customerContactsBindingSource.ResumeBinding();
                
            }
            else
            {
                customerContactsBindingSource.PositionChanged -= contactsListBindingSource_PositionChanged;
                //customerContactsBindingSource.RaiseListChangedEvents = false;
                //_ServicePanel.ChangingDays();
                customerContactsBindingSource.DataSource = ((DailyModel)MainForm._DailyDataBindingSource.Current).Contacts;
                //customerContactsBindingSource.RaiseListChangedEvents = true;
                customerContactsBindingSource.PositionChanged += contactsListBindingSource_PositionChanged;
                //_ServicePanel.ChangedDays();
                //if (customerContactsBindingSource.Count < 2)
                //    customerContactsBindingSource.ResetBindings(false);
                //else
                    customerContactsBindingSource.MoveLast();
            }   
        }

        public void Init()
        {
            _PR.AttachMenu(_PRContextMenu);
            _NPR.AttachMenu(_PRContextMenu);
            _Dn.AttachMenu(_DialContextMenu);
            _Cmbs.AttachMenu(_CMBSContextMenu);
            _Icon.AttachMenu(_ICONContextMenu);
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
        public void contactsListBindingSource_PositionChanged(object sender, EventArgs e)
        {
            EventLogger.SaveLog();
            if (customerContactsBindingSource.Count == 0 || customerContactsBindingSource.Position == -1)
            {
                DisableInterface();
            }
            else
            {
                _isDisabled = false;

                if (MainForm.SelectedContact != null)
                    MainForm.SelectedContact.NestedChange -= SelectedContact_NestedChange;
                MainForm.SelectedContact = (CustomerContact)customerContactsBindingSource.Current;//((ObjectView<CustomerContact>)customerContactsBindingSource.Current).Object;
                if (MainForm.SelectedContact != null)
                    MainForm.SelectedContact.NestedChange += SelectedContact_NestedChange;

                flowLayoutPanel1.Enabled = true;
                ServiceTypePanel.Enabled = true;
                FaultPanel.Enabled = true;
                _Note.Enabled = true;

                _NoteContextMenuStrip.Items[0].PerformClick();
                _BookingDate.BindDatePickerBox(customerContactsBindingSource);
                _Outcome.BindComboBox(Main.ServicesStore.servicesDataSet.Outcomes.Select(x => x.Description).ToList(), customerContactsBindingSource);

                UpdateCurrentPanel();
                UpdateActions();
                _ImportantToolStripMenuItem.Checked = MainForm.SelectedContact.Important;
            }
        }

        private bool _isDisabled;
        public void DisableInterface()
        {
            if (_isDisabled)
                return;

            _isDisabled = true;
            if (MainForm.SelectedContact != null)
            {
                MainForm.SelectedContact.NestedChange -= SelectedContact_NestedChange;
                MainForm.SelectedContact = null;
            }

            flowLayoutPanel1.Enabled = false;
            ServiceTypePanel.Enabled = false;
            FaultPanel.Enabled = false;
            _Note.Enabled = false;

            _Note.DataBindings.Clear();
            _BookingDate._DateTimePicker.DataBindings.Clear();
            _Outcome._ComboBox.DataBindings.Clear();

            CurrentService = ServiceTypes.NONE;
            //_ServicePanel.ChangeService(ServiceTypes.NONE);         
        }

        public void SelectedContact_NestedChange(object sender, PropertyChangedEventArgs e)
        {
            // Swap Panels
            if (e.PropertyName == "AffectedServices")
                UpdateCurrentPanel();

            //if (e.PropertyName == "Outcome")
            //    UpdateActions();

            // Update Note
            if (_Note.DataBindings.Count > 0 && _updateNote)
                _Note.DataBindings[0].ReadValue();
        }

        public void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //_DateSelector.ComboBox.SelectedValue = DateTime.Today;
            MainForm.IsDifferentShift();
            customerContactsBindingSource.AddNew();    
            customerContactsBindingSource.MoveLast();
        }

        public void DeleteCalls()
        {
            customerContactsBindingSource.Position = -1;

            customerContactsBindingSource.RaiseListChangedEvents = false;
            customerContactsBindingSource.SuspendBinding();

            ((DailyModel)MainForm._DailyDataBindingSource.Current).Contacts.ClearList();

            customerContactsBindingSource.ResumeBinding();
            customerContactsBindingSource.RaiseListChangedEvents = true;
            customerContactsBindingSource.ResetBindings(false);
        }

        public void FilterCalls(string value = "")
        {
            customerContactsBindingSource.RaiseListChangedEvents = false;

            if(String.IsNullOrEmpty(value))
                ((DailyModel)MainForm._DailyDataBindingSource.Current).Contacts.RemoveFilter();
            else
                ((DailyModel)MainForm._DailyDataBindingSource.Current).Contacts.ApplyFilter("Date = " + value);
            
            customerContactsBindingSource.RaiseListChangedEvents = true;
            customerContactsBindingSource.ResetBindings(false);
        }

        public void UpdateActions()
        {
            var query = (from a in Main.ServicesStore.servicesDataSet.Actions
                                  where a.OutcomesRow.Description == MainForm.SelectedContact.Fault.Outcome
                                  select a.Description).ToList();
            if(query.Count > 0)
                _Action.BindComboBox(query, customerContactsBindingSource);

            if (MainForm.SelectedContact == null) return;
            if (!query.Contains(MainForm.SelectedContact.Fault.Action))
                MainForm.SelectedContact.Fault.Action = "";
        }





        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Service //////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private ServiceTypes _currentService;
        private ServiceTypes CurrentService
        {
            get { return _currentService; }
            set
            {
                _currentService = value;
                _ServicePanel.ChangeService(_currentService);
            }
        }

        private void UpdateCurrentPanel()
        {
            var affectedServices = MainForm.SelectedContact.Fault.AffectedServices;

            foreach (ServiceTypes service in Enum.GetValues(typeof(ServiceTypes)))
            {
                if ((affectedServices & service) == 0 && affectedServices != 0) continue;
                CurrentService = service;  
                break;
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
            var cb = (CheckBox)sender;
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
                cb.Checked = cb.Checked == false;        
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
            var cm = (ToolStripMenuItem)sender;
            foreach (var item in _NoteContextMenuStrip.Items.OfType<ToolStripMenuItem>())
                item.Checked = false;
            cm.Checked = true;
            _Note.DataBindings.Clear();
            var tag = cm.Tag.ToString();
            _Note.DataBindings.Add(new Binding("Text", customerContactsBindingSource, tag, true, DataSourceUpdateMode.OnPropertyChanged));
            
            switch (tag)
            {
                case "ICONNote":
                    _Note.DataBindings[0].ReadValue();
                    break;
                case "PRTemplate":
                    _Note.DataBindings[0].ReadValue();
                    break;
            }
                
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(_Note.Text))
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

        private static List<int> SplitterRows = new List<int> { 0, 25, 55, 84, 114, 144, 164};// 153, 122, 99, 67, 35, 0};
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
                _updateNote = false;

                MainForm.SelectedContact.Booking.Type = BookingType.NRQ.ToString();

                MainForm.SelectedContact.UpdatePrTemplateReplacements(PRGenerators.AROAnswers);

                if (((ToolStripMenuItem)_NoteContextMenuStrip.Items["pRTemplateToolStripMenuItem"]).Checked)
                    _Note.DataBindings[0].ReadValue();

                _updateNote = true;
            }
            else
            {
                MainForm.SelectedContact.ClearPrTemplateReplacements();

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
            if (e.Button != MouseButtons.Right) return;
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
            if (!_currentService.Is(ServiceTypes.NONE))
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
            HotkeyController.NavigateOrNewIE("https://scamps.optusnet.com.au/cm.html?q=" + ((ToolStripMenuItem)sender).Tag.ToString(), "SCAMPS");
        }

        private void _SearchDIMPSUsername_click(object sender, EventArgs e)
        {
            HotkeyController.NavigateOrNewIE("https://dimps.optusnet.com.au/display.html?username=" + ((ToolStripMenuItem)sender).Tag.ToString().ToLower(), "DIMPS");
        }

        private void _SearchDIMPSDn_click(object sender, EventArgs e)
        {
            HotkeyController.NavigateOrNewIE("https://dimps.optusnet.com.au/search/servno?servno=" + ((ToolStripMenuItem)sender).Tag.ToString(), "DIMPS");
        }

        private void _SearchDIMPSCmbs_click(object sender, EventArgs e)
        {
            HotkeyController.NavigateOrNewIE("https://dimps.optusnet.com.au/search/account?account_no=" + ((ToolStripMenuItem)sender).Tag.ToString(), "DIMPS");
        }

        private void _SearchNexusService_click(object sender, EventArgs e)
        {
            HotkeyController.NavigateOrNewIE("http://nexus.optus.com.au/index.php?#service/" + ((ToolStripMenuItem)sender).Tag.ToString(), "Nexus");
        }

        private void _SearchNexusAccount_click(object sender, EventArgs e)
        {
            HotkeyController.NavigateOrNewIE("http://nexus.optus.com.au/index.php?#account/" + ((ToolStripMenuItem)sender).Tag.ToString(), "Nexus");
        }
        private void _SearchICON_click(object sender, EventArgs e)
        {
           
        }

        private void _SearchUNMT_click(object sender, EventArgs e)
        {
            HotkeyController.NavigateOrNewIE("https://staff.optusnet.com.au/tools/usernames/users.html?username=" + ((ToolStripMenuItem)sender).Tag.ToString() + "&namespace=optus", "Staff");
        }

        private void _SearchIFMS_click(object sender, EventArgs e)
        {
            HotkeyController.NavigateOrNewIE("http://ifmsprod.optus.com.au/IFMSWeb1P/PR%20Manage/F012_ProblemDetail.aspx?SD_NO=" + ((ToolStripMenuItem)sender).Tag.ToString(), "IFMS");
        }

        private void _TextFieldContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            LabelledTextBoxLong field;
            var fieldtest = ((ContextMenuStrip) sender).SourceControl;
            if (fieldtest.GetType() != typeof (LabelledTextBoxLong))
                field = (LabelledTextBoxLong)fieldtest.Parent;
            else
                field = (LabelledTextBoxLong)fieldtest;

            var searchString = field._DataField.Text;
            Match match;
            switch (field._Label.Text)
            {
                case "cmbs":
                    match = new CMBSPattern().Match(MainForm.SelectedContact.CMBS);
                    if(match.Success)
                        searchString = match.Result("3$1${2}0$3");
                    break;
                case "dn":
                    match = new DNPattern().Match(MainForm.SelectedContact.DN);
                    if(match.Success)
                        searchString = match.Result("0$1$2$3");
                    break;
                case "mobile":
                    match = new MobilePattern().Match(MainForm.SelectedContact.Mobile);
                    if(match.Success)
                        searchString = match.Result("0$1$2");
                    break;
            }
            Console.WriteLine(searchString);

            e.ClickedItem.Tag = searchString ?? String.Empty;
        }

        private void _DialContextMenu_Opening(object sender, CancelEventArgs e)
        {
            //if (((ContextMenuStrip)sender).SourceControl != null)
            //    Console.WriteLine(((ContextMenuStrip)sender).SourceControl.Name);
        }




        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Call history Context Menu ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void callHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.settingMenuItem_Click(MainForm.callHistoryToolStripMenuItem, e);
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

            if (DateTime.UtcNow.Subtract(_lasttime).Milliseconds < 9 && _opened)
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

        private void PaintGrayBorderMain(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.WhiteSmoke,
              0,
              0,
              ((Control)sender).Width - 1,
              ((Control)sender).Height - 1);

        }



        private void _Important_CheckedChanged(object sender, EventArgs e)
        {
            _ImportantToolStripMenuItem.Image = _ImportantToolStripMenuItem.Checked ? Properties.Resources.flag_on : Properties.Resources.flag_off;           
        }

        private void _ImportantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.SelectedContact.Important = _ImportantToolStripMenuItem.Checked;
        }

        private void _IDOk_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;
            checkBox.ImageIndex = checkBox.Checked ? 1 : 0;
        }

        private void _Cmbs_Leave(object sender, EventArgs e)
        {
            Console.WriteLine("left");
        }




    }
}
