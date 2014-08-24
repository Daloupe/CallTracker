using System;
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
            //dgv = dataGridView1;
            dataGridView1.DataError += dataGridView1_DataError;
        }

        public override void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            base.Init(_parent, _menuItem);
            bindingSource1 = MainForm.editContact.customerContactsBindingSource;

            callHistoryPanel1.SetBindingSource(bindingSource1);
            dataGridView1.DataSource = bindingSource1;

            _DateSelect._ComboBox.DataSource = MainForm.DateBindingSource;
            _DateSelect._ComboBox.DisplayMember = "ShortDate";
            _DateSelect._ComboBox.ValueMember = "LongDate";

            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }
        protected override void PaintBorder(object sender, PaintEventArgs e)
        {
            base.PaintBorder(sender, e);
        }

        private void propertyLock_CheckedChanged(object sender, EventArgs e)
        {
            //flowLayoutPanel1.Enabled = !propertyLock.Checked;
        }

        private int _position;
        public override void ShowSetting()
        {
            CurrentPosition = MainForm.editContact.customerContactsBindingSource.Position;
            _position = MainForm.DateBindingSource.Position;

            base.ShowSetting();      
        }

        public override void HideSetting()
        {
            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            base.HideSetting();  
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            MainForm.DateBindingSource.Position = _position;

            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

            if (MainForm.editContact.customerContactsBindingSource.Count > 0)
                MainForm.editContact.customerContactsBindingSource.Position = CurrentPosition;
            base._Done_Click(sender, e);
        }

        protected override void _Done_Click(object sender, EventArgs e)
        {
            base._Done_Click(sender, e);
        }


        private void dataGridView1_DataError(object sender,DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null &&
                e.Context == DataGridViewDataErrorContexts.Commit)
            {
                EventLogger.LogNewEvent("Error: "+this.Name+" couldn't commit data to cell");
            }
        }

        private void _ClearHistory_Click(object sender, EventArgs e)
        {
            MainForm.editContact.DeleteCalls();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MainForm.editContact.DeleteCalls();
                e.Cancel = true;
            }
        }

        //private void _DateSelect_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //   // dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

        //}
    }
}
