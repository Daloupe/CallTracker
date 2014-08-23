using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using CallTracker.Model;

namespace CallTracker.View
{
    public partial class CallHistory : ViewControlBase
    {
        private int CurrentPosition;

        public CallHistory()
        {
            InitializeComponent();
            dgv = dataGridView1;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.CellClick += dataGridView1_CellClick;

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add("Date", "Date");
            //dataGridView1.Columns.Add("Time", "Time");
            dataGridView1.Columns.Add("Name", "Name");

            dataGridView1.Columns["Date"].DataPropertyName = "ContactDateTime";
            dataGridView1.Columns["Date"].Width = 40;
            dataGridView1.Columns["Date"].ReadOnly = true;
            
            //dataGridView1.Columns["Date"].SortMode = DataGridViewColumnSortMode.NotSortable;

            //dataGridView1.Columns["Time"].DataPropertyName = "ContactTime";
            //dataGridView1.Columns["Time"].Width = 35;
            //dataGridView1.Columns["Time"].ReadOnly = true;
            //dataGridView1.Columns["Time"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns["Name"].DataPropertyName = "Name";
            dataGridView1.Columns["Name"].Width = 235;
            dataGridView1.Columns["Name"].ReadOnly = false;
            

            DataGridViewComboBoxColumn dtcol = new DataGridViewComboBoxColumn();
            dataGridView1.Columns.Add(dtcol);
            dtcol.DataPropertyName = "GetOutcome";
            dtcol.Name = "Outcome";
            dtcol.HeaderText = "Outcome";
            dtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtcol.Width = 65;
            dtcol.SortMode = DataGridViewColumnSortMode.Automatic;
            dtcol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dtcol.ReadOnly = false;
            dtcol.DataSource = Main.ServicesStore.servicesDataSet.Outcomes.Select(x => x.Acronym).ToList();

            dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public override void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            base.Init(_parent, _menuItem);
            bindingSource1 = MainForm.editContact.customerContactsBindingSource;
            callHistoryPanel1.SetBindingSource(bindingSource1);
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

        }

        protected override void _Done_Click(object sender, EventArgs e)
        {
            //MainForm.editContact.customerContactsBindingSource.Position = bindingSource1.Position;

            CurrentPosition = bindingSource1.Position;//bindingSource1.Count - bindingSource1.Position - 1;
            
            Console.WriteLine(CurrentPosition);
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

        private Equin.ApplicationFramework.IItemFilter<CustomerContact> _filter;
        private bool _isFilteredOnOpen;
        public override void ShowSetting()
        {
            _isFilteredOnOpen = _isFiltered;
            CurrentPosition = MainForm.editContact.customerContactsBindingSource.Position;
            _filter = MainForm.editContact.Contacts.Filter;
            if (MainForm.ContactsDataStore._contactsList.Count > 0)
            {
                var dates = new List<string> {"All"};
                dates.AddRange(
                    MainForm.ContactsDataStore._contactsList.Select(x => x.Contacts.StartDate.ToString("dd/MM"))
                        .Distinct()
                        .ToList());

                _DateSelect._ComboBox.DataSource = dates;

                if (_isFilteredOnOpen)
                    _DateSelect._ComboBox.SelectedItem = MainForm.SelectedContact.Contacts.StartDate.ToString("dd/MM");
                else
                    _DateSelect._ComboBox.SelectedIndex = 0;
            }

            //MainForm.editContact.customerContactsBindingSource.Sort = "ContactDateTime DESC";//.Contacts.ApplySort("ContactDateTime ASC");
           // dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);

            //MainForm.editContact.customerContactsBindingSource.Position = bindingSource1.Count - CurrentPosition - 1;
            base.ShowSetting();
            
        }

        public override void HideSetting()
        {
            MainForm.editContact.customerContactsBindingSource.Position = CurrentPosition;
            //dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            base.HideSetting();  
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            
            if (_isFilteredOnOpen)
            {
                MainForm.editContact.Contacts.ApplyFilter(_filter);
                _isFiltered = true;
            }
            else
            {
                _isFiltered = false;
            }

            base._Done_Click(sender, e);
        }

        private void dataGridView1_DataError(object sender,
        DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is  
            // commited, display an error message. 
            if (e.Exception != null &&
                e.Context == DataGridViewDataErrorContexts.Commit)
            {
                EventLogger.LogNewEvent("Error: "+this.Name+" couldn't commit data to cell");
            }
        }

        private void _ClearHistory_Click(object sender, EventArgs e)
        {
            bindingSource1.SuspendBinding();
            bindingSource1.Clear();
            Properties.Settings.Default.NextContactsId = 0;
            bindingSource1.ResumeBinding();
            bindingSource1.AddNew();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MainForm.ContactsDataStore.Contacts.Count == 1)
            {
                MainForm.ContactsDataStore.Contacts.AddNew();
                MainForm.editContact.customerContactsBindingSource.Position = 1;
            }else if(bindingSource1.Position == e.Row.Index)
            {
                bindingSource1.Position -= 1;
            }
        }

        private bool _isFiltered = true;
        private void _DateSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainForm.editContact.Contacts == null) return;

            var selectedDate = _DateSelect._ComboBox.Text;
            
            if (String.IsNullOrEmpty(selectedDate)) return;

            if (selectedDate == "All")
            {
                MainForm.editContact.Contacts.RemoveFilter();
                _isFiltered = false;
            }
            else
            {
                MainForm.editContact.Contacts.ApplyFilter(x => x.Contacts.StartDate.ToString("dd/MM") == selectedDate);
                _isFiltered = true;
            }
        }
    }
}
