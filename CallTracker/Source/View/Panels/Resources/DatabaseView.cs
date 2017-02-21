using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using CallTracker.Model;
using CallTracker.Helpers;

namespace CallTracker.View
{
    public partial class DatabaseView : ViewControlBase
    {
        public DatabaseView()
        {
            InitializeComponent();
            dgv = dataGridView1;
            dataGridView1.DataError +=dataGridView1_DataError;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.AutoGenerateColumns = false;
        }

        public override void Init(Main mainForm, ToolStripMenuItem menuItem)
        {
            base.Init(mainForm, menuItem);
            //databaseBindingSource.ListChanged += rateplanBindingSource_ListChanged;

            databaseBindingSource.DataSource = Main.ServicesStore.servicesDataSet;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = databaseBindingSource;
            var tables = new List<string>();
            foreach(DataTable table in Main.ServicesStore.servicesDataSet.Tables)
                tables.Add(StringHelpers.SeperateCamelCase(table.TableName));
            _DatabaseSelect.DataSource = tables;
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

        private void _DatabaseSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
           string newTable = StringHelpers.JoinCamelCase(((ComboBox)sender).Text);
           if (newTable == dataGridView1.DataMember)
               return;
            dataGridView1.Columns.Clear();
            dataGridView1.DataMember = newTable;
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
                ReplaceWithComboBoxColumn("OutcomeId", "Outcome", "OutcomeId", "Description", "Id", 150, Main.ServicesStore.servicesDataSet.Actions.ToList(), false, 1);

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "SeverityCodeSymptomMatch")
            {
                ReplaceWithComboBoxColumn("SymptomID", "Symptom", "SymptomID", "IFMSCode", "Id", 120, Main.ServicesStore.servicesDataSet.Symptoms.ToList());
                ReplaceWithComboBoxColumn("SeverityCodeId", "Severity", "SeverityCodeId", "IFMSCode", "Id", 80, Main.ServicesStore.servicesDataSet.SeverityCodes.ToList(), false,1);         

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "EquipmentEquipmentStatusesMatch")
            {
                ReplaceWithComboBoxColumn("EquipmentID", "Equipment", "EquipmentID", "Type", "Id", 200, Main.ServicesStore.servicesDataSet.Equipment.ToList());
                ReplaceWithComboBoxColumn("EquipmentStatusesID", "Status", "EquipmentStatusesID", "Status", "Id", 200, Main.ServicesStore.servicesDataSet.EquipmentStatuses.ToList(), false, 1);
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (dataGridView1.DataMember == "Actions")
            {
                ReplaceWithComboBoxColumn("OutcomeId", "Outcomes", "OutcomeId", "Description", "Id", 200, Main.ServicesStore.servicesDataSet.Outcomes.ToList());
            }
        }

        private DataGridViewComboBoxColumn ReplaceWithComboBoxColumn(string _columnName, string _columnHeader, string _idColumnName, string _displayMember, string _valueMember, int _width, object _dataSource, bool _readOnly = false, int _columnIndex = 0)
        {
            if(dataGridView1.Columns.Contains(_columnName))
            {
                dataGridView1.Columns.Remove(_columnName);

                var dtcol = new DataGridViewComboBoxColumn();
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
            return null;
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
            EventLogger.LogNewEvent("Saving Services");
            Main.ServicesStore.WriteData();
            base._Done_Click(sender, e);
        }

        protected override void PaintBorder(object sender, PaintEventArgs e)
        {
            base.PaintBorder(sender, e);
        }

        public override void ShowSetting()
        {
            base.ShowSetting();
        }

        public override void HideSetting()
        {
            base.HideSetting();
        }

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == -1)
        //    {
        //        dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
        //        dataGridView1.EndEdit();
        //    }else
        //    {
        //        dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        //        dataGridView1.BeginEdit(false);
                
        //        if(e.RowIndex != -1)
        //            contextMenuStrip1.Items[0].Tag = dataGridView1[e.ColumnIndex, e.RowIndex];
        //    }
        //}

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            ((DataGridViewComboBoxCell)item.Tag).Value = DBNull.Value;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void automaticSortToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (automaticSortToolStripMenuItem.Checked == false)
                dataGridView1.SetColumnSortMode(DataGridViewColumnSortMode.NotSortable);
            else
                dataGridView1.SetColumnSortMode(DataGridViewColumnSortMode.Automatic);
        }
    }
}
