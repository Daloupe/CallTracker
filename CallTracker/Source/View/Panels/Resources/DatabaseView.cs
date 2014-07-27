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
    public partial class DatabaseView : ViewControlBase
    {
        public DatabaseView()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        public override void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            base.Init(_parent, _menuItem);
            //databaseBindingSource.ListChanged += rateplanBindingSource_ListChanged;

            databaseBindingSource.DataSource = MainForm.ServicesStore.servicesDataSet;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = databaseBindingSource;
            List<string> tables = new List<string>();
            foreach(DataTable table in MainForm.ServicesStore.servicesDataSet.Tables)
                tables.Add(StringHelpers.SeperateCamelCase(table.TableName));
            _DatabaseSelect.DataSource = tables;
        }

        private void _DatabaseSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataMember = StringHelpers.JoinCamelCase(((ComboBox)sender).Text);
            if(dataGridView1.Columns.Contains("Id"))
                dataGridView1.Columns.Remove("Id");

            if (dataGridView1.DataMember == "Services")
            {
                dataGridView1.Columns.Remove("ProductCodeId");

                DataGridViewComboBoxColumn dtcol = new DataGridViewComboBoxColumn();
                dtcol.Name = "ProductCodeId";
                dtcol.HeaderText = "Product Code";
                dtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtcol.Width = 120;
                dtcol.SortMode = DataGridViewColumnSortMode.Automatic;
                dtcol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                dtcol.DataSource = MainForm.ServicesStore.servicesDataSet.ProductCodes.ToList();
                dtcol.DisplayMember = "IFMSCode";
                dtcol.ValueMember = "Id";
                dataGridView1.Columns.Insert(1, dtcol);
                dtcol.DataPropertyName = "ProductCodeId";

                dataGridView1.Columns["Name"].HeaderText = "Service";
                dataGridView1.Columns["Name"].MinimumWidth = 150;
                dataGridView1.Columns["ProblemStyle"].HeaderText = "Problem Style";
                dataGridView1.Columns["ProblemStyle"].Width = 120;
                
                //dataGridView1.AutoResizeColumns();
            }
            else if (dataGridView1.DataMember == "Departments")
            {
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.Columns.Remove("ServiceId");
                dataGridView1.Columns.Remove("DepartmentNameId");

                DataGridViewComboBoxColumn dtcol = new DataGridViewComboBoxColumn();
                dtcol.Name = "Id";
                dtcol.HeaderText = "Department";
                dtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtcol.Width = 115;
                dtcol.SortMode = DataGridViewColumnSortMode.Automatic;
                dtcol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                dtcol.ReadOnly = true;
                dtcol.DataSource = MainForm.ServicesStore.servicesDataSet.DepartmentNames.ToList();
                dtcol.DisplayMember = "NameLong";
                dtcol.ValueMember = "Id";
                dataGridView1.Columns.Insert(0, dtcol);
                dtcol.DataPropertyName = "DepartmentNameId";

                dtcol = new DataGridViewComboBoxColumn();
                dtcol.Name = "ServiceId";
                dtcol.HeaderText = "Service";
                dtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtcol.Width = 50;
                dtcol.SortMode = DataGridViewColumnSortMode.Automatic;
                dtcol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                dtcol.ReadOnly = true;
                dtcol.DataSource = MainForm.ServicesStore.servicesDataSet.Services.ToList();
                dtcol.DisplayMember = "ProblemStyle";
                dtcol.ValueMember = "Id";
                dataGridView1.Columns.Insert(1, dtcol);
                dtcol.DataPropertyName = "ServiceId";

                dataGridView1.Columns["InternalContact"].HeaderText = "Internal";
                dataGridView1.Columns["InternalContact"].Width = 60;
                dataGridView1.Columns["InternalContact"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns["ExternalContact"].HeaderText = "External";
                dataGridView1.Columns["ExternalContact"].Width = 85;
                dataGridView1.Columns["ExternalContact"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns["ContactHours"].HeaderText = "Contact Hours";
                dataGridView1.Columns["ContactHours"].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Sort(dtcol, ListSortDirection.Ascending);
            }
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
        //public void Search(string searchtext)
        //{
        //    textBox1.Text = searchtext;
        //    _Search_Click(null, null);
        //}
        //private void _Search_Click(object sender, EventArgs e)
        //{
        //    string searchValue = textBox1.Text;

        //    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dataGridView1.ClearSelection();
        //    foreach (DataGridViewRow row in dataGridView1.Rows)
        //    {
        //        if (row.Cells[0].Value != null)
        //        {
        //            string cellValue = row.Cells[0].Value.ToString();
        //            if (cellValue.Substring(0,Math.Min(searchValue.Length, cellValue.Length)).Equals(searchValue))
        //            {
        //                row.Selected = true;
        //                dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
        //                break;
        //            }
        //        }
        //    }  
        //}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        //    dataGridView1.Columns[4].Visible = ((ToolStripMenuItem)sender).Checked;
        //    dataGridView1.Columns[5].Visible = ((ToolStripMenuItem)sender).Checked;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dataGridView1.ClearSelection();
            //databaseBindingSource.ListChanged -= rateplanBindingSource_ListChanged;
            
            char[] rowSplitter = { '\n', '\r' };  // Cr and Lf.
            IDataObject dataInClipboard = Clipboard.GetDataObject();
            string stringInClipboard =
                dataInClipboard.GetData(DataFormats.Text).ToString();
            string[] rowsInClipboard = stringInClipboard.Split(rowSplitter,
                StringSplitOptions.RemoveEmptyEntries);
            
            int iRow = 3;
            while (iRow < rowsInClipboard.Length)
            {
                databaseBindingSource.Insert(dataGridView1.SelectedRows[0].Index, new RateplanModel(rowsInClipboard[iRow]));
                iRow += 1;
            }

            //rateplanBindingSource.RemoveAt(0);
            //databaseBindingSource.ListChanged += rateplanBindingSource_ListChanged;
            MainForm.UpdateAutoComplete();
        }

        //void rateplanBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //     MainForm.UpdateAutoComplete();
        //}

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ratePlanCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    string title = "Nexus", url = "http://nexus.optus.com.au";

        //    SystemItem item = MainForm.DataStore.GridLinks.SystemItems.Find(c => c.System == "Rate Plan Calculator");
        //    if(item !=null)
        //    {
        //        title = item.Title;
        //        url = item.Url;
        //    }
        //    HotkeyController.NavigateOrNewIE(title, url);
        }

        //DateTime lastKeyPress = DateTime.UtcNow;
        //private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode < Keys.A || e.KeyCode > Keys.Z)
        //        return;

        //    DateTime nextKeyPress = DateTime.UtcNow;      
        //    string searchString = e.KeyData.ToString();
        //    if ((nextKeyPress - lastKeyPress).TotalMilliseconds <= 600)
        //    {
        //        searchString = textBox1.Text + searchString;
        //    }
        //    Search(searchString);
        //    lastKeyPress = nextKeyPress;
        //}

        private void dataGridView1_KeyDown(object sender, KeyPressEventArgs e)
        {
        //    if (!char.IsLetter(e.KeyChar))
        //        return;

        //    DateTime nextKeyPress = DateTime.UtcNow;
        //    string searchString = char.ToUpper(e.KeyChar).ToString();
        //    if ((nextKeyPress - lastKeyPress).TotalMilliseconds <= 600)
        //    {
        //        searchString = textBox1.Text + searchString;
        //    }
        //    Search(searchString);
        //    lastKeyPress = nextKeyPress;
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
