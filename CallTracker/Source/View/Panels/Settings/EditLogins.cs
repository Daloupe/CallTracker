﻿using System;
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
    public partial class EditLogins : ViewControlBase
    {
        public EditLogins()
        {
            InitializeComponent();
            dgv = dataGridView1;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        public override void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            base.Init(_parent, _menuItem);
            loginsModelBindingSource.DataSource = MainForm.DataStore.Logins;
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
        protected override void _Done_Click(object sender, EventArgs e)
        {
            base._Done_Click(sender, e);
        }

        protected override void PaintBorder(object sender, PaintEventArgs e)
        {
            base.PaintBorder(sender, e);
        }

        private void propertyLock_CheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Enabled = !propertyLock.Checked;
        }
    }
}
