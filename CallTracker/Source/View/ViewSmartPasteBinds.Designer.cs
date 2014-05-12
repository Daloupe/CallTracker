namespace CallTracker.View
{
    partial class ViewSmartPasteBinds
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pasteBindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerContactBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.customerContactBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.systemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Data = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._AltData = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasteBindBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerContactBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerContactBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.systemDataGridViewTextBoxColumn,
            this.elementDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.urlDataGridViewTextBoxColumn,
            this._Data,
            this._AltData});
            this.dataGridView1.DataSource = this.pasteBindBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.Size = new System.Drawing.Size(544, 217);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Visible = false;
            // 
            // pasteBindBindingSource
            // 
            this.pasteBindBindingSource.DataSource = typeof(CallTracker.Model.PasteBind);
            // 
            // customerContactBindingSource1
            // 
            this.customerContactBindingSource1.DataSource = typeof(CallTracker.Model.CustomerContact);
            // 
            // customerContactBindingSource
            // 
            this.customerContactBindingSource.DataSource = typeof(CallTracker.Model.CustomerContact);
            // 
            // systemDataGridViewTextBoxColumn
            // 
            this.systemDataGridViewTextBoxColumn.DataPropertyName = "System";
            this.systemDataGridViewTextBoxColumn.FillWeight = 57F;
            this.systemDataGridViewTextBoxColumn.HeaderText = "System";
            this.systemDataGridViewTextBoxColumn.Name = "systemDataGridViewTextBoxColumn";
            // 
            // elementDataGridViewTextBoxColumn
            // 
            this.elementDataGridViewTextBoxColumn.DataPropertyName = "Element";
            this.elementDataGridViewTextBoxColumn.FillWeight = 79.28934F;
            this.elementDataGridViewTextBoxColumn.HeaderText = "Element";
            this.elementDataGridViewTextBoxColumn.Name = "elementDataGridViewTextBoxColumn";
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.FillWeight = 79.28934F;
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // urlDataGridViewTextBoxColumn
            // 
            this.urlDataGridViewTextBoxColumn.DataPropertyName = "Url";
            this.urlDataGridViewTextBoxColumn.FillWeight = 79.28934F;
            this.urlDataGridViewTextBoxColumn.HeaderText = "Url";
            this.urlDataGridViewTextBoxColumn.Name = "urlDataGridViewTextBoxColumn";
            // 
            // _Data
            // 
            this._Data.DataPropertyName = "Data";
            this._Data.FillWeight = 79.28934F;
            this._Data.HeaderText = "Data";
            this._Data.Name = "_Data";
            this._Data.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._Data.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _AltData
            // 
            this._AltData.DataPropertyName = "AltData";
            this._AltData.FillWeight = 79.28934F;
            this._AltData.HeaderText = "AltData";
            this._AltData.Name = "_AltData";
            this._AltData.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._AltData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ViewSmartPasteBinds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 217);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewSmartPasteBinds";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Smart Paste Binds";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.ViewSmartPasteBinds_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasteBindBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerContactBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerContactBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource pasteBindBindingSource;
        private System.Windows.Forms.BindingSource customerContactBindingSource;
        private System.Windows.Forms.BindingSource customerContactBindingSource1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn systemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn elementDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn _Data;
        private System.Windows.Forms.DataGridViewComboBoxColumn _AltData;
    }
}