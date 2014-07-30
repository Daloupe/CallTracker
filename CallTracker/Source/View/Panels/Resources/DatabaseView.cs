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

            databaseBindingSource.DataSource = Main.ServicesStore.servicesDataSet;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = databaseBindingSource;
            List<string> tables = new List<string>();
            foreach(DataTable table in Main.ServicesStore.servicesDataSet.Tables)
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
                ReplaceWithComboBoxColumn("ProblemStyleId", "Problem Style", "ProblemStyleId", "IFMSCode", "Id", 120, Main.ServicesStore.servicesDataSet.ProblemStyles.ToList(), false, 1);
                ChangeColumn("Name", "Service", 150);
                ChangeColumn("ProductCode", "Product Code", 120);
            }
            else if (dataGridView1.DataMember == "Departments")
            {
                ReplaceWithComboBoxColumn("DepartmentNameId", "Department", "DepartmentNameId", "NameLong", "Id", 115, Main.ServicesStore.servicesDataSet.DepartmentNames.ToList(), true);
                ReplaceWithComboBoxColumn("ServiceId", "Service", "ServiceId", "ProductCode", "Id", 115, Main.ServicesStore.servicesDataSet.Services.ToList(), true, 1);
                ChangeColumn("InternalContact", "Internal", 60, DataGridViewColumnSortMode.NotSortable);
                ChangeColumn("ExternalContact", "External", 85, DataGridViewColumnSortMode.NotSortable);
                ChangeColumn("ContactHours", "Contact Hours", 0, DataGridViewColumnSortMode.NotSortable);

                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "ServiceEquipmentMatch")
            {
                ReplaceWithComboBoxColumn("EquipmentId", "Equipment", "EquipmentId", "Description", "Id", 150, Main.ServicesStore.servicesDataSet.Equipment.ToList());
                ReplaceWithComboBoxColumn("ServiceId", "Service", "ServiceId", "ProductCode", "Id", 80, Main.ServicesStore.servicesDataSet.Services.ToList(), false, 1);

                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "ServiceSymptomGroupMatch")
            {
                ReplaceWithComboBoxColumn("ServiceId", "Service", "ServiceId", "ProductCode", "Id", 80, Main.ServicesStore.servicesDataSet.Services.ToList());
                ReplaceWithComboBoxColumn("SymptomGroupId", "Symptom Group", "SymptomGroupId", "IFMSCode", "Id", 80, Main.ServicesStore.servicesDataSet.SymptomGroups.ToList(),false, 1);

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "SymptomGroupSymptomMatch")
            {
                ReplaceWithComboBoxColumn("SymptomGroupId", "Symptom Group", "SymptomGroupId", "IFMSCode", "Id", 80, Main.ServicesStore.servicesDataSet.SymptomGroups.ToList());
                ReplaceWithComboBoxColumn("SymptomId", "Symptom", "SymptomId", "IFMSCode", "Id", 80, Main.ServicesStore.servicesDataSet.Symptoms.ToList(), false, 1);

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "IFMSTier1")
            {
                ReplaceWithComboBoxColumn("ServiceId", "Service", "ServiceId", "ProductCode", "Id", 80, Main.ServicesStore.servicesDataSet.Services.ToList(), false, 1);
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "IFMSTier1IFMSTier2Match")
            {
                ReplaceWithComboBoxColumn("IFMSTier1Id", "Tier 1", "IFMSTier1Id", "Option", "Id", 250, Main.ServicesStore.servicesDataSet.IFMSTier1.ToList(), false, 0);
                ReplaceWithComboBoxColumn("IFMSTier2Id", "Tier 2", "IFMSTier2Id", "Option", "Id", 250, Main.ServicesStore.servicesDataSet.IFMSTier2.ToList(), false, 1);

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "IFMSTier2")
            {
                ReplaceWithComboBoxColumn("OutcomeId", "Outcome", "OutcomeId", "Acronym", "Id", 80, Main.ServicesStore.servicesDataSet.Outcomes.ToList(), false, 1);

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "IFMSTier2IFMSTier3Match")
            {
                ReplaceWithComboBoxColumn("IFMSTier2Id", "Tier 2", "IFMSTier2Id", "Option", "Id", 250, Main.ServicesStore.servicesDataSet.IFMSTier2.ToList(), false, 0);
                ReplaceWithComboBoxColumn("IFMSTier3Id", "Tier 3", "IFMSTier3Id", "Option", "Id", 250, Main.ServicesStore.servicesDataSet.IFMSTier3.ToList(), false, 1);

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "IFMSTier3")
            {
                ReplaceWithComboBoxColumn("SeverityID", "Severity", "SeverityID", "IFMSCode", "Id", 80, Main.ServicesStore.servicesDataSet.SeverityCodes.ToList(), false, 1);
                ReplaceWithComboBoxColumn("SymptomId", "Symptom", "SymptomId", "IFMSCode", "Id", 80, Main.ServicesStore.servicesDataSet.Symptoms.ToList(), false, 2);

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "IFMSTier3IFMSTier4Match")
            {
                ReplaceWithComboBoxColumn("IFMSTier3Id", "Tier 3", "IFMSTier3Id", "Option", "Id", 250, Main.ServicesStore.servicesDataSet.IFMSTier3.ToList(), false, 0);
                ReplaceWithComboBoxColumn("IFMSTier4Id", "Tier 4", "IFMSTier4Id", "Option", "Id", 250, Main.ServicesStore.servicesDataSet.IFMSTier4.ToList(), false, 1);

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "IFMSTier4")
            {
                //ReplaceWithComboBoxColumn("OutcomeId", "Outcome", "OutcomeId", "Acronym", "Id", 80, Main.ServicesStore.servicesDataSet.Outcomes.ToList(), false, 1);

                //dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "IFMSTier2OutcomeMatch")
            {
                ReplaceWithComboBoxColumn("IFMSTier2Id", "Tier 2", "IFMSTier2Id", "Option", "Id", 250, Main.ServicesStore.servicesDataSet.IFMSTier2.ToList(), false, 0);
                ReplaceWithComboBoxColumn("OutcomeId", "Outcome", "OutcomeId", "Acronym", "Id", 80, Main.ServicesStore.servicesDataSet.Outcomes.ToList(), false, 1);

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "IFMSTier4OutcomeMatch")
            {
                ReplaceWithComboBoxColumn("IFMSTier4Id", "Tier 4", "IFMSTier4Id", "Option", "Id", 250, Main.ServicesStore.servicesDataSet.IFMSTier4.ToList(), false, 0);
                ReplaceWithComboBoxColumn("OutcomeId", "Outcome", "OutcomeId", "Acronym", "Id", 80, Main.ServicesStore.servicesDataSet.Outcomes.ToList(), false, 1);

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "SeverityCodeSymptomMatch")
            {
                ReplaceWithComboBoxColumn("SymptomID", "Symptom", "SymptomID", "IFMSCode", "Id", 120, Main.ServicesStore.servicesDataSet.Symptoms.ToList());
                ReplaceWithComboBoxColumn("SeverityCodeId", "Severity", "SeverityCodeId", "IFMSCode", "Id", 80, Main.ServicesStore.servicesDataSet.SeverityCodes.ToList(), false,1);         

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
        }

        private DataGridViewComboBoxColumn ReplaceWithComboBoxColumn(string _columnName, string _columnHeader, string _idColumnName, string _displayMember, string _valueMember, int _width, object _dataSource, bool _readOnly = false, int _columnIndex = 0)
        {
            dataGridView1.Columns.Remove(_columnName);

            DataGridViewComboBoxColumn dtcol = new DataGridViewComboBoxColumn();
            dtcol.Name = _columnName;
            dtcol.HeaderText = _columnHeader;
            dtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtcol.Width = _width;
            dtcol.SortMode = DataGridViewColumnSortMode.Automatic;
            dtcol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dtcol.ReadOnly = _readOnly;
            dtcol.DataSource = _dataSource;
            dtcol.DisplayMember = _displayMember;
            dtcol.ValueMember = _valueMember;
            dataGridView1.Columns.Insert(_columnIndex, dtcol);
            dtcol.DataPropertyName = _idColumnName;

            return dtcol;
        }

        private void ChangeColumn(string _columnName, string _columnHeader, int _width, DataGridViewColumnSortMode _sortable = DataGridViewColumnSortMode.Automatic)
        {
            dataGridView1.Columns[_columnName].HeaderText = _columnHeader;
            if(_width != 0)
                dataGridView1.Columns[_columnName].Width = _width;
            dataGridView1.Columns[_columnName].SortMode = _sortable;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1)
            {
                dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                dataGridView1.EndEdit();
            }else
            {
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
                dataGridView1.BeginEdit(false);
                
                if(e.RowIndex != -1)
                    contextMenuStrip1.Items[0].Tag = dataGridView1[e.ColumnIndex, e.RowIndex];
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            ((DataGridViewComboBoxCell)item.Tag).Value = DBNull.Value;
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
