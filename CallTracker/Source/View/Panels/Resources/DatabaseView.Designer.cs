﻿namespace CallTracker.View
{
    partial class DatabaseView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInstallCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ratePlanCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.departmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.servicesDataSet = new CallTracker.DataSets.ServicesDataSet();
            this._Cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this._DatabaseSelect = new System.Windows.Forms.ComboBox();
            this.servicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.internalContactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.externalContactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactHoursDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem,
            this.showInstallCodesToolStripMenuItem,
            this.toolStripSeparator1,
            this.ratePlanCalculatorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 76);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // showInstallCodesToolStripMenuItem
            // 
            this.showInstallCodesToolStripMenuItem.CheckOnClick = true;
            this.showInstallCodesToolStripMenuItem.Name = "showInstallCodesToolStripMenuItem";
            this.showInstallCodesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.showInstallCodesToolStripMenuItem.Text = "Show Install Codes";
            this.showInstallCodesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // ratePlanCalculatorToolStripMenuItem
            // 
            this.ratePlanCalculatorToolStripMenuItem.Name = "ratePlanCalculatorToolStripMenuItem";
            this.ratePlanCalculatorToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ratePlanCalculatorToolStripMenuItem.Text = "Rate Plan Calculator";
            this.ratePlanCalculatorToolStripMenuItem.Click += new System.EventHandler(this.ratePlanCalculatorToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.departmentIDDataGridViewTextBoxColumn,
            this.serviceIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.internalContactDataGridViewTextBoxColumn,
            this.externalContactDataGridViewTextBoxColumn,
            this.contactHoursDataGridViewTextBoxColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.DataMember = "Departments";
            this.dataGridView1.DataSource = this.databaseBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(577, 193);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBorder);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyDown);
            // 
            // departmentsBindingSource
            // 
            this.departmentsBindingSource.DataMember = "Departments";
            this.departmentsBindingSource.DataSource = this.databaseBindingSource;
            // 
            // databaseBindingSource
            // 
            this.databaseBindingSource.DataSource = this.servicesDataSet;
            this.databaseBindingSource.Position = 0;
            // 
            // servicesDataSet
            // 
            this.servicesDataSet.DataSetName = "ServicesDataSet";
            this.servicesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // _Cancel
            // 
            this._Cancel.BackColor = System.Drawing.Color.LightGray;
            this._Cancel.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this._Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cancel.Location = new System.Drawing.Point(506, 198);
            this._Cancel.Name = "_Cancel";
            this._Cancel.Size = new System.Drawing.Size(75, 22);
            this._Cancel.TabIndex = 15;
            this._Cancel.Text = "Done";
            this._Cancel.UseVisualStyleBackColor = false;
            this._Cancel.Click += new System.EventHandler(this._Done_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(374, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Database Editor";
            // 
            // _DatabaseSelect
            // 
            this._DatabaseSelect.FormattingEnabled = true;
            this._DatabaseSelect.Location = new System.Drawing.Point(3, 198);
            this._DatabaseSelect.Name = "_DatabaseSelect";
            this._DatabaseSelect.Size = new System.Drawing.Size(183, 20);
            this._DatabaseSelect.TabIndex = 18;
            this._DatabaseSelect.SelectedIndexChanged += new System.EventHandler(this._DatabaseSelect_SelectedIndexChanged);
            // 
            // servicesBindingSource
            // 
            this.servicesBindingSource.DataMember = "Services";
            this.servicesBindingSource.DataSource = this.databaseBindingSource;
            // 
            // departmentIDDataGridViewTextBoxColumn
            // 
            this.departmentIDDataGridViewTextBoxColumn.DataPropertyName = "DepartmentID";
            this.departmentIDDataGridViewTextBoxColumn.HeaderText = "DepartmentID";
            this.departmentIDDataGridViewTextBoxColumn.Name = "departmentIDDataGridViewTextBoxColumn";
            this.departmentIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serviceIDDataGridViewTextBoxColumn
            // 
            this.serviceIDDataGridViewTextBoxColumn.DataPropertyName = "ServiceID";
            this.serviceIDDataGridViewTextBoxColumn.HeaderText = "ServiceID";
            this.serviceIDDataGridViewTextBoxColumn.Name = "serviceIDDataGridViewTextBoxColumn";
            this.serviceIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // internalContactDataGridViewTextBoxColumn
            // 
            this.internalContactDataGridViewTextBoxColumn.DataPropertyName = "InternalContact";
            this.internalContactDataGridViewTextBoxColumn.HeaderText = "InternalContact";
            this.internalContactDataGridViewTextBoxColumn.Name = "internalContactDataGridViewTextBoxColumn";
            this.internalContactDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // externalContactDataGridViewTextBoxColumn
            // 
            this.externalContactDataGridViewTextBoxColumn.DataPropertyName = "ExternalContact";
            this.externalContactDataGridViewTextBoxColumn.HeaderText = "ExternalContact";
            this.externalContactDataGridViewTextBoxColumn.Name = "externalContactDataGridViewTextBoxColumn";
            this.externalContactDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contactHoursDataGridViewTextBoxColumn
            // 
            this.contactHoursDataGridViewTextBoxColumn.DataPropertyName = "ContactHours";
            this.contactHoursDataGridViewTextBoxColumn.HeaderText = "ContactHours";
            this.contactHoursDataGridViewTextBoxColumn.Name = "contactHoursDataGridViewTextBoxColumn";
            this.contactHoursDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DatabaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this._DatabaseSelect);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this._Cancel);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Name = "DatabaseView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(584, 222);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button _Cancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource databaseBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInstallCodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ratePlanCalculatorToolStripMenuItem;
        private System.Windows.Forms.ComboBox _DatabaseSelect;
        private System.Windows.Forms.BindingSource departmentsBindingSource;
        private DataSets.ServicesDataSet servicesDataSet;
        private System.Windows.Forms.BindingSource servicesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn internalContactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn externalContactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactHoursDataGridViewTextBoxColumn;
    }
}
