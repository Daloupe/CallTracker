using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CallTracker.Model;
using Equin.ApplicationFramework;
using ProtoBuf.Meta;

namespace CallTracker.View
{
    public partial class CallHistory : ViewControlBase
    {
        private int CurrentPosition;

        public CallHistory()
        {
            InitializeComponent();
            //dgv = dataGridView1;
            dataGridView1.DataError += dataGridView1_DataError;
            //dataGridView1.CellClick += dataGridView1_CellClick;

           // dataGridView1.AutoGenerateColumns = false;

           // dataGridView1.Columns.Add("Date", "Date");
           // //dataGridView1.Columns.Add("Time", "Time");
           // dataGridView1.Columns.Add("Name", "Name");

           // dataGridView1.Columns["Date"].DataPropertyName = "ContactDateTime";
           // dataGridView1.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
           // dataGridView1.Columns["Date"].MinimumWidth = 90;
           // dataGridView1.Columns["Date"].FillWeight = 90;
           // dataGridView1.Columns["Date"].Width = 90;
           // dataGridView1.Columns["Date"].ReadOnly = true;
            
           // //dataGridView1.Columns["Date"].SortMode = DataGridViewColumnSortMode.NotSortable;

           // //dataGridView1.Columns["Time"].DataPropertyName = "ContactTime";
           // //dataGridView1.Columns["Time"].Width = 35;
           // //dataGridView1.Columns["Time"].ReadOnly = true;
           // //dataGridView1.Columns["Time"].SortMode = DataGridViewColumnSortMode.NotSortable;

           // dataGridView1.Columns["Name"].DataPropertyName = "name";
           // dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
           // dataGridView1.Columns["Name"].MinimumWidth = 185;
           // dataGridView1.Columns["Name"].FillWeight = 185;
           // dataGridView1.Columns["Name"].ReadOnly = true;
            

           // DataGridViewComboBoxColumn dtcol = new DataGridViewComboBoxColumn();
           // dataGridView1.Columns.Add(dtcol);
           // dtcol.DataPropertyName = "GetOutcome";
           // dtcol.Name = "Outcome";
           // dtcol.HeaderText = "Outcome";
           // dtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           // dtcol.MinimumWidth = 40;
           // dtcol.FillWeight = 88;
           // dtcol.SortMode = DataGridViewColumnSortMode.Automatic;
           // dtcol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
           // dtcol.ReadOnly = false;
           // dtcol.DataSource = Main.ServicesStore.servicesDataSet.Outcomes.Select(x => x.Acronym).ToList();

           //// dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //private static List<DateFilterItem> _dateFilterItems = new List<DateFilterItem> { new DateFilterItem("All") };

        public override void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            base.Init(_parent, _menuItem);
            //bindingSource1.DataSource = MainForm.editContact.customerContactsBindingSource;

            //_DateSelect._ComboBox.DataSource = new List<DateFilterItem> { new DateFilterItem("All") };
            

            //callHistoryPanel1.SetBindingSource(bindingSource1);
            //dataGridView1.DataSource = bindingSource1;
            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        protected override void _Done_Click(object sender, EventArgs e)
        {
            //MainForm.editContact.customerContactsBindingSource.Position = bindingSource1.Position;

            CurrentPosition = bindingSource1.Position;//bindingSource1.Count - bindingSource1.Position - 1;

            MainForm.editContact._CallMenuButton.Text = _DateSelect._ComboBox.Text;

            _isFilteredOnOpen = false;
            base._Done_Click(sender, e);
        }

        protected override void PaintBorder(object sender, PaintEventArgs e)
        {
            base.PaintBorder(sender, e);
        }

        private void propertyLock_CheckedChanged(object sender, EventArgs e)
        {
            //flowLayoutPanel1.Enabled = !propertyLock.Checked;
        }

        private string _filter;
        private bool _isFilteredOnOpen = true;
        private bool _emptyFilter;
        private bool _opening;
        public override void ShowSetting()
        {
            MainForm.editContact.customerContactsBindingSource.EndEdit();
            bindingSource1.DataSource = MainForm.editContact.customerContactsBindingSource;
            callHistoryPanel1.SetBindingSource(bindingSource1);
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            
            CurrentPosition = MainForm.editContact.customerContactsBindingSource.Position;
            _filter = MainForm.editContact.customerContactsBindingSource.Filter;
            _isFilteredOnOpen = !String.IsNullOrEmpty(_filter);

            _emptyFilter = MainForm.editContact.customerContactsBindingSource.Count == 0 ? true : false;
            if (MainForm.ContactsDataStore.Contacts.Count > 0)
            {
                _opening = true;
                MainForm.ContactsDataStore.Contacts.RemoveFilter();
                var newDateFilterItems = new List<DateFilterItem>{ new DateFilterItem("All") };
                newDateFilterItems.AddRange(MainForm.ContactsDataStore.Contacts
                    .Select(x => x.Contacts.StartDate)
                    .Distinct()
                    .Select(y => new DateFilterItem(y)));

                //var oldFilterItems = _dateFilterItems.ToList();

                //foreach (var item in oldFilterItems)
                //    if (!newDateFilterItems.Exists(x => x.ShortDate == item.ShortDate))
                //        _dateFilterItems.Remove(item);

                //foreach (var item in newDateFilterItems)
                //    if (!oldFilterItems.Exists(x => x.ShortDate == item.ShortDate))
                //        _dateFilterItems.Add(item);
                _DateSelect._ComboBox.DataSource = newDateFilterItems;  
                _DateSelect._ComboBox.DisplayMember = "ShortDate";
                _DateSelect._ComboBox.ValueMember = "LongDate";

                _opening = false;

                if (_isFilteredOnOpen && !_emptyFilter)
                    _DateSelect._ComboBox.Text = MainForm.SelectedContact.Contacts.StartDate.ToString("dd/MM");
                else if (_isFilteredOnOpen && _emptyFilter)
                    _DateSelect._ComboBox.Text = DateTime.Today.ToString("dd/MM");
                else
                    _DateSelect._ComboBox.SelectedIndex = 0;
            }

            //if (bindingSource1.Count == 1)
            //{
            //    callHistoryPanel1.SetBindingSource(MainForm.callHistory.bindingSource1);
            //    dataGridView1.DataSource = MainForm.callHistory.bindingSource1;
            //    dataGridView1.Refresh();
            //}
            //MainForm.editContact.customerContactsBindingSource.Sort = "ContactDateTime DESC";//.Contacts.ApplySort("ContactDateTime ASC");
           // dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);

            //MainForm.editContact.customerContactsBindingSource.Position = bindingSource1.Count - CurrentPosition - 1;
            base.ShowSetting();
            
        }

        public override void HideSetting()
        {
            callHistoryPanel1.RemoveBindingSource();
            dataGridView1.DataSource = null;

            if (MainForm.editContact.customerContactsBindingSource.Count > 0)
                MainForm.editContact.customerContactsBindingSource.Position = CurrentPosition;


            if (_isFilteredOnOpen)
                MainForm.editContact.customerContactsBindingSource.Filter = _filter;

            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            base.HideSetting();  
        }

        private void Cancel_Click(object sender, EventArgs e)
        {

            base._Done_Click(sender, e);
        }

        private void dataGridView1_DataError(object sender,DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is  
            // commited, display an error message. 
            Console.WriteLine("Error");
            if (e.Exception != null &&
                e.Context == DataGridViewDataErrorContexts.Commit)
            {
                EventLogger.LogNewEvent("Error: "+this.Name+" couldn't commit data to cell");
            }
        }

        private void _ClearHistory_Click(object sender, EventArgs e)
        {
            _isFilteredOnOpen = false;

            MainForm.editContact.customerContactsBindingSource.RemoveFilter();
            MainForm.ContactsDataStore.Contacts.RaiseListChangedEvents = false;
            MainForm.editContact.customerContactsBindingSource.SuspendBinding();
            MainForm.ContactsDataStore.Contacts.Clear();
            MainForm.ContactsDataStore.Contacts.RaiseListChangedEvents = true;
            MainForm.editContact.customerContactsBindingSource.ResumeBinding();
            MainForm.ContactsDataStore.Contacts.ResetBindings();

            var dates = new List<DateFilterItem> { new DateFilterItem("All") };
            _DateSelect._ComboBox.DataSource = dates;
            _DateSelect._ComboBox.SelectedIndex = 0;

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MainForm.editContact.customerContactsBindingSource.RemoveFilter();
                if (dataGridView1.Rows.Count == 1)
                {
                    bindingSource1.AddNew();
                    bindingSource1.Position = 0;

                    var dates = new List<DateFilterItem> { new DateFilterItem("All"), new DateFilterItem(DateTime.Today) };
                    _DateSelect._ComboBox.DataSource = dates;
                    _DateSelect._ComboBox.SelectedValue = MainForm.SelectedContact.Contacts.StartDate;
                    _isFilteredOnOpen = false;
                }
            }
            else if (bindingSource1.Position == e.Row.Index)
            {
                bindingSource1.Position -= 1;
            }
        }

        private void _DateSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainForm.editContact.customerContactsBindingSource == null || _opening == true) return;// || _emptyFilter) return;

            if (_DateSelect._ComboBox.Text == "All")
            {
                //bindingSource1.RaiseListChangedEvents = false;
                MainForm.editContact.customerContactsBindingSource.RemoveFilter();
                //bindingSource1.RaiseListChangedEvents = true;
                //bindingSource1.ResetBindings(false);
            }
            else
            {
                MainForm.editContact.customerContactsBindingSource.RaiseListChangedEvents = false;
                MainForm.editContact.customerContactsBindingSource.Filter = "Contacts.StartDate = " + _DateSelect._ComboBox.SelectedValue;
                MainForm.editContact.customerContactsBindingSource.RaiseListChangedEvents = true;
                MainForm.editContact.customerContactsBindingSource.ResetBindings(false);
            }
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }


    }
    public class DateFilterItem
    {
        public DateTime LongDate { get; set; }
        public string ShortDate { get; set; }

        public DateFilterItem(DateTime systemDate)
        {
            LongDate = systemDate;
            ShortDate = LongDate.ToString("dd/MM");
        }

        public DateFilterItem(string displayString)
        {
            LongDate = DateTime.Today;
            ShortDate = displayString;
        }
    }
}
