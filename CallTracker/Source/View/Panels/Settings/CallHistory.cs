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

namespace CallTracker.View
{
    public partial class CallHistory : ViewControlBase
    {
        private int CurrentPosition;

        public CallHistory()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Date", "Date");
            dataGridView1.Columns.Add("Time", "Time");
            dataGridView1.Columns.Add("Name", "Name");

            dataGridView1.Columns["Date"].DataPropertyName = "ContactDate";
            dataGridView1.Columns["Date"].Width = 75;
            dataGridView1.Columns["Date"].ReadOnly = true;

            dataGridView1.Columns["Time"].DataPropertyName = "ContactTime";
            dataGridView1.Columns["Time"].Width = 50;
            dataGridView1.Columns["Time"].ReadOnly = true;

            dataGridView1.Columns["Name"].DataPropertyName = "Name";
            dataGridView1.Columns["Name"].ReadOnly = true;  
        }

        public override void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            base.Init(_parent, _menuItem);
            dataGridView1.DataSource = MainForm.editContact.customerContactsBindingSource;
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

        private void _ClearHistory_Click(object sender, EventArgs e)
        {
            MainForm.DataStore.Contacts = new BindingList<CustomerContact>();
            MainForm.editContact.DeleteCalls();
        }
    }
}
