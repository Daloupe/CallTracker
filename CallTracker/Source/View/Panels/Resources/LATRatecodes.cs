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
    public partial class LATRatecodes : ViewControlBase
    {
        public LATRatecodes()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        public override void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            base.Init(_parent, _menuItem);
            rateplanBindingSource.ListChanged += rateplanBindingSource_ListChanged;
            rateplanBindingSource.DataSource = MainForm.ResourceStore.LATRatePlans;
            dataGridView1.DataSource = rateplanBindingSource;        
        }


        protected override void _Done_Click(object sender, EventArgs e)
        {
            //CurrentPosition = MainForm.editContact.customerContactsBindingSource.Position;
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
            base.ShowSetting();
            //CurrentPosition = MainForm.editContact.customerContactsBindingSource.Position;
        }

        public override void HideSetting()
        {
            base.HideSetting();
            //MainForm.editContact.customerContactsBindingSource.Position = CurrentPosition;
        }
        public void Search(string searchtext)
        {
            textBox1.Text = searchtext;
            _Search_Click(null, null);
        }
        private void _Search_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ClearSelection();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                    if (row.Cells[0].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
            }  
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns[4].Visible = ((ToolStripMenuItem)sender).Checked;
            dataGridView1.Columns[5].Visible = ((ToolStripMenuItem)sender).Checked;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dataGridView1.ClearSelection();
            rateplanBindingSource.ListChanged -= rateplanBindingSource_ListChanged;
            
            char[] rowSplitter = { '\n', '\r' };  // Cr and Lf.
            IDataObject dataInClipboard = Clipboard.GetDataObject();
            string stringInClipboard =
                dataInClipboard.GetData(DataFormats.Text).ToString();
            string[] rowsInClipboard = stringInClipboard.Split(rowSplitter,
                StringSplitOptions.RemoveEmptyEntries);
            
            int iRow = 3;
            while (iRow < rowsInClipboard.Length)
            {
                rateplanBindingSource.Insert(dataGridView1.SelectedRows[0].Index, new RateplanModel(rowsInClipboard[iRow]));
                iRow += 1;
            }

            //rateplanBindingSource.RemoveAt(0);
            rateplanBindingSource.ListChanged += rateplanBindingSource_ListChanged;
            MainForm.UpdateAutoComplete();
        }

        void rateplanBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
             MainForm.UpdateAutoComplete();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ratePlanCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Nexus", url = "http://nexus.optus.com.au";

            SystemItem item = MainForm.DataStore.GridLinks.SystemItems.Find(c => c.System == "Rate Plan Calculator");
            if(item !=null)
            {
                title = item.Title;
                url = item.Url;
            }
            HotkeyController.NavigateOrNewIE(title, url);
        }


        //// PasteInData pastes clipboard data into the grid passed to it.
        //static void PasteInData(ref DataGridView dgv)
        //{
        //    char[] rowSplitter = { '\n', '\r' };  // Cr and Lf.
        //    char columnSplitter = '\t';         // Tab.

        //    IDataObject dataInClipboard = Clipboard.GetDataObject();

        //    string stringInClipboard =
        //        dataInClipboard.GetData(DataFormats.Text).ToString();

        //    string[] rowsInClipboard = stringInClipboard.Split(rowSplitter,
        //        StringSplitOptions.RemoveEmptyEntries);

        //    int r = dgv.SelectedCells[0].RowIndex;
        //    int c = dgv.SelectedCells[0].ColumnIndex;

        //    if (dgv.Rows.Count < (r + rowsInClipboard.Length))
        //        dgv.Rows.Add(r + rowsInClipboard.Length - dgv.Rows.Count);

        //    // Loop through lines:

        //    int iRow = 0;
        //    while (iRow < rowsInClipboard.Length)
        //    {
        //        // Split up rows to get individual cells:

        //        string[] valuesInRow =
        //            rowsInClipboard[iRow].Split(columnSplitter);

        //        // Cycle through cells.
        //        // Assign cell value only if within columns of grid:

        //        int jCol = 0;
        //        while (jCol < valuesInRow.Length)
        //        {
        //            if ((dgv.ColumnCount - 1) >= (c + jCol))
        //                dgv.Rows[r + iRow].Cells[c + jCol].Value =
        //                valuesInRow[jCol];

        //            jCol += 1;
        //        } // end while

        //        iRow += 1;
        //    } // end while
        //} // PasteInData

    }
}
