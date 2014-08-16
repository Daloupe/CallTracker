using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CallTracker.View;
using CallTracker.Model;
using CallTracker.Helpers;

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
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        protected override void _Done_Click(object sender, EventArgs e)
        {
            CurrentPosition = MainForm.editContact.customerContactsBindingSource.Position;
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

        public override void ShowSetting()
        {
            callHistoryPanel1.SetBindingSource(MainForm.editContact.customerContactsBindingSource);
            base.ShowSetting();
            CurrentPosition = MainForm.editContact.customerContactsBindingSource.Position;
        }

        public override void HideSetting()
        {
            callHistoryPanel1.RemoveBindingSource();
            base.HideSetting();
            MainForm.editContact.customerContactsBindingSource.Position = CurrentPosition;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
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

            //if (dataGridView1.RowCount <= 1)
            //{
          
            //    MainForm.DataStore.Contacts.RaiseListChangedEvents = false;
            //    //MainForm.DataStore.Contacts.Add(new CustomerContact(1));
            //    MainForm.DataStore.Contacts.RemoveAt(0);
            //    MainForm.DataStore.Contacts.RaiseListChangedEvents = true;
            //    MainForm.DataStore.Contacts.ResetBindings();
                
            //    //MainForm.editContact.customerContactsBindingSource.Position = 1;
            //    //MainForm.editContact.customerContactsBindingSource.RemoveAt(0);
            //    return;
            //}

            MainForm.DataStore.Contacts.Add(new CustomerContact(1));
            MainForm.editContact.customerContactsBindingSource.Position = MainForm.DataStore.Contacts.Count;

            MainForm.SelectedContact.NestedChange -= MainForm.editContact.SelectedContact_NestedChange;
            //MainForm.editContact.customerContactsBindingSource.RaiseListChangedEvents = false;
            MainForm.editContact.customerContactsBindingSource.SuspendBinding();
            //bindingSource1.SuspendBinding();
            callHistoryPanel1.RemoveBindingSource();
            
            dataGridView1.DataSource = null;
            MainForm.DataStore.Contacts.Clear();
            MainForm.editContact.customerContactsBindingSource.ResumeBinding();
            //MainForm.DataStore.Contacts = new SortableBindingList<CustomerContact>();
            MainForm.DataStore.Contacts.Add(new CustomerContact(1));
            MainForm.editContact.customerContactsBindingSource.Position = 1;
            
            
            //MainForm.editContact.DeleteCalls();
            //MainForm.editContact.customerContactsBindingSource.Position = 0;


            
            //dataGridView1.DataSource = MainForm.editContact.customerContactsBindingSource;


            
            //bindingSource1.ResumeBinding();
            callHistoryPanel1.SetBindingSource(MainForm.editContact.customerContactsBindingSource);
            dataGridView1.DataSource = bindingSource1;
            //MainForm.editContact.customerContactsBindingSource.RaiseListChangedEvents = true;

            MainForm.editContact.customerContactsBindingSource.ResetBindings(true);

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if(MainForm.DataStore.Contacts.Count == 1)
            {
                MainForm.DataStore.Contacts.Add(new CustomerContact(1));
                MainForm.editContact.customerContactsBindingSource.Position = 1;
            }else if(bindingSource1.Position == e.Row.Index)
            {
                bindingSource1.Position -= 1;
            }
        }
    }
}
