using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using CallTracker.View;
using CallTracker.Model;
using CallTracker.Helpers;

namespace CallTracker.View
{
    public partial class Ratecodes : ViewControlBase
    {

        public Ratecodes()
        {
            InitializeComponent();
            //dataGridView1.AutoGenerateColumns = false;
        }

        public override void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            base.Init(_parent, _menuItem);
            rateplanBindingSource.DataSource = Main.ServicesStore.servicesDataSet;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = rateplanBindingSource;
            MainForm.toolStripServiceSelector.SelectedIndexChanged += toolStripServiceSelector_SelectedIndexChanged;
            _ServiceSelector.SelectedIndex = 0;
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

            SearchForString(searchValue);
        }

        private void SearchForString(string _input)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ClearSelection();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string cellValue = row.Cells[0].Value.ToString();
                    if (cellValue.Substring(0, Math.Min(_input.Length, cellValue.Length)).Equals(_input))
                    {
                        row.Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
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
            char[] rowSplitter = { '\n', '\r' };  // Cr and Lf.
            IDataObject dataInClipboard = Clipboard.GetDataObject();
            string stringInClipboard =
                dataInClipboard.GetData(DataFormats.Text).ToString();
            string[] rowsInClipboard = stringInClipboard.Split(rowSplitter,
                StringSplitOptions.RemoveEmptyEntries);
            
            int iRow = 3;
            while (iRow < rowsInClipboard.Length)
            {
                char columnSplitter = '\t';
                string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);
                switch (_ServiceSelector.Text)
                {
                    case "LAT/LIP":
                        DataSets.ServicesDataSet.LATLIPRatecodesRow newLATRow = Main.ServicesStore.servicesDataSet.LATLIPRatecodes.NewLATLIPRatecodesRow();
                        newLATRow.Ratecode = valuesInRow[0];
                        newLATRow.Description = valuesInRow[1];
                        newLATRow.LATChangeCode = valuesInRow[2];
                        newLATRow.LIPChangeCode = valuesInRow[3];
                        Main.ServicesStore.servicesDataSet.LATLIPRatecodes.AddLATLIPRatecodesRow(newLATRow);  
                        break;
                    case "ONC":
                        DataSets.ServicesDataSet.ONCRatecodesRow newONCRow = Main.ServicesStore.servicesDataSet.ONCRatecodes.NewONCRatecodesRow();
                        newONCRow.Ratecode = valuesInRow[0];
                        newONCRow.Description = valuesInRow[1];
                        newONCRow.ChangeCode = valuesInRow[2];
                        Main.ServicesStore.servicesDataSet.ONCRatecodes.AddONCRatecodesRow(newONCRow);  
                        break;
                    case "DTV":
                        DataSets.ServicesDataSet.DTVRatecodesRow newDTVRow = Main.ServicesStore.servicesDataSet.DTVRatecodes.NewDTVRatecodesRow();
                        newDTVRow.Ratecode = valuesInRow[0];
                        newDTVRow.Description = valuesInRow[1];
                        newDTVRow.ChangeCode = valuesInRow[2];
                        Main.ServicesStore.servicesDataSet.DTVRatecodes.AddDTVRatecodesRow(newDTVRow);  
                        break;
                    default:
                        break;
                }
                         
                iRow += 1;
            }
        }

        //void rateplanBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //     //MainForm.UpdateAutoComplete();
        //}

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

        DateTime lastKeyPress = DateTime.UtcNow;
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
            if (!char.IsLetter(e.KeyChar))
                return;

            DateTime nextKeyPress = DateTime.UtcNow;
            string searchString = char.ToUpper(e.KeyChar).ToString();
            if ((nextKeyPress - lastKeyPress).TotalMilliseconds <= 600)
            {
                searchString = textBox1.Text + searchString;
            }
            Search(searchString);
            lastKeyPress = nextKeyPress;
            e.Handled = true;
        }

        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.ColumnIndex != 1)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGridView1.KeyPress -= dataGridView1_KeyDown;
        }

        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.KeyPress += dataGridView1_KeyDown;
        }

        private void LATRatecodes_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible == true)
            {
                //_ServiceSelector.Text = MainForm.toolStripServiceSelector.Text;
                //if (String.IsNullOrEmpty(_ServiceSelector.Text))
                //    _ServiceSelector.Text = "LAT/LIP";
                dataGridView1.Focus();
            }
        }

        void toolStripServiceSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedService = MainForm.toolStripServiceSelector.Text;
            
            if (selectedService == "NBN" || selectedService == "MeTV")
            {
                MenuControl.Enabled = false;
                if (String.IsNullOrEmpty(_ServiceSelector.Text))
                    _ServiceSelector.Text = "LAT/LIP";
            }
            else
            {
                MenuControl.Enabled = true;
                _ServiceSelector.Text = selectedService;
            }
        }

        private void _ServiceSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(_ServiceSelector.Text)
            {
                case "LAT/LIP":
                    dataGridView1.DataMember = "LATLIPRatecodes";
                    dataGridView1.Columns["LATChangeCode"].HeaderText = "LAT Change Code";
                    dataGridView1.Columns["LATChangeCode"].Width = 110;
                    dataGridView1.Columns["LATChangeCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridView1.Columns["LIPChangeCode"].HeaderText = "LIP Change Code";
                    dataGridView1.Columns["LIPChangeCode"].Width = 110;
                    dataGridView1.Columns["LIPChangeCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridView1.Columns["Ratecode"].Width = 90;
                    dataGridView1.Columns["Description"].Width = 280;
                    break;
                case "ONC":
                    dataGridView1.DataMember = "ONCRatecodes";   
                    dataGridView1.Columns["ChangeCode"].HeaderText = "Change Code";
                    dataGridView1.Columns["ChangeCode"].Width = 70;
                    dataGridView1.Columns["Ratecode"].Width = 60;
                    dataGridView1.Columns["Description"].Width = 340;
                    break;
                case "DTV":
                    dataGridView1.DataMember = "DTVRatecodes";   
                    dataGridView1.Columns["ChangeCode"].HeaderText = "Change Code";
                    dataGridView1.Columns["ChangeCode"].Width = 70;
                    dataGridView1.Columns["Ratecode"].Width = 60;
                    dataGridView1.Columns["Description"].Width = 340;
                    break;
                default:
                    break;
            }
            if (dataGridView1.Columns.Contains("Id"))
                dataGridView1.Columns.Remove("Id");

            dataGridView1.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Focus();
        }

    }
}
