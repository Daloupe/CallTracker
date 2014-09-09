namespace CallTracker.View
{
    partial class CallHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._DateSelect = new CallTracker.View.LabelledComboBoxLong();
            this._ClearHistory = new System.Windows.Forms.Button();
            this._Cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new CallTracker.View.CustomDataGrid();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.callHistoryPanel1 = new CallTracker.View.CallHistoryPanel();
            this._Done = new System.Windows.Forms.Button();
            this.Important = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ContactDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getOutcomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // _DateSelect
            // 
            this._DateSelect.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._DateSelect.BackColor = System.Drawing.Color.LightGray;
            this._DateSelect.BorderColour = System.Drawing.Color.WhiteSmoke;
            this._DateSelect.ControlHeight = 20;
            this._DateSelect.DataSource = null;
            this._DateSelect.DefaultText = "";
            this._DateSelect.Font = new System.Drawing.Font("Verdana", 7F);
            this._DateSelect.HasContextMenu = false;
            this._DateSelect.LabelActiveColor = System.Drawing.Color.Empty;
            this._DateSelect.LabelAutoSize = true;
            this._DateSelect.LabelBorderColor = System.Drawing.Color.Empty;
            this._DateSelect.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._DateSelect.LabelInactiveColor = System.Drawing.Color.Empty;
            this._DateSelect.LabelMargin = new System.Windows.Forms.Padding(0);
            this._DateSelect.LabelOffset = new System.Drawing.Point(0, 0);
            this._DateSelect.LabelPadding = new System.Windows.Forms.Padding(0);
            this._DateSelect.LabelSize = new System.Drawing.Size(55, 23);
            this._DateSelect.LabelText = "date filter";
            this._DateSelect.LabelTextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._DateSelect.LabelTextColor = System.Drawing.SystemColors.ControlText;
            this._DateSelect.LabelToolTip = "";
            this._DateSelect.Location = new System.Drawing.Point(2, 218);
            this._DateSelect.MenuButtonDock = System.Windows.Forms.DockStyle.Left;
            this._DateSelect.MenuButtonImage = null;
            this._DateSelect.Name = "_DateSelect";
            this._DateSelect.OverlapLabel = false;
            this._DateSelect.PropertyName = "LongDate";
            this._DateSelect.Size = new System.Drawing.Size(130, 20);
            this._DateSelect.TabIndex = 17;
            // 
            // _ClearHistory
            // 
            this._ClearHistory.BackColor = System.Drawing.Color.LightGray;
            this._ClearHistory.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this._ClearHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._ClearHistory.Location = new System.Drawing.Point(366, 218);
            this._ClearHistory.Name = "_ClearHistory";
            this._ClearHistory.Size = new System.Drawing.Size(82, 20);
            this._ClearHistory.TabIndex = 16;
            this._ClearHistory.Text = "Delete Calls";
            this._ClearHistory.UseVisualStyleBackColor = false;
            this._ClearHistory.Click += new System.EventHandler(this._ClearHistory_Click);
            // 
            // _Cancel
            // 
            this._Cancel.BackColor = System.Drawing.Color.LightGray;
            this._Cancel.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this._Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cancel.Location = new System.Drawing.Point(522, 218);
            this._Cancel.Name = "_Cancel";
            this._Cancel.Size = new System.Drawing.Size(60, 20);
            this._Cancel.TabIndex = 15;
            this._Cancel.Text = "Done";
            this._Cancel.UseVisualStyleBackColor = false;
            this._Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(233, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "//Call History";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(2, 3);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.callHistoryPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(580, 213);
            this.splitContainer1.SplitterDistance = 368;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Important,
            this.ContactDateTime,
            this.nameDataGridViewTextBoxColumn,
            this.getOutcomeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(368, 213);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBorder);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(CallTracker.Model.CustomerContact);
            // 
            // callHistoryPanel1
            // 
            this.callHistoryPanel1.AutoSize = true;
            this.callHistoryPanel1.BackColor = System.Drawing.Color.LightGray;
            this.callHistoryPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.callHistoryPanel1.Font = new System.Drawing.Font("Verdana", 7F);
            this.callHistoryPanel1.Location = new System.Drawing.Point(0, 0);
            this.callHistoryPanel1.Name = "callHistoryPanel1";
            this.callHistoryPanel1.Size = new System.Drawing.Size(210, 213);
            this.callHistoryPanel1.TabIndex = 0;
            // 
            // _Done
            // 
            this._Done.BackColor = System.Drawing.Color.LightGray;
            this._Done.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this._Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Done.Location = new System.Drawing.Point(450, 218);
            this._Done.Name = "_Done";
            this._Done.Size = new System.Drawing.Size(70, 20);
            this._Done.TabIndex = 10;
            this._Done.Text = "Load Call";
            this._Done.UseVisualStyleBackColor = false;
            this._Done.Click += new System.EventHandler(this._Done_Click);
            // 
            // Important
            // 
            this.Important.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Important.DataPropertyName = "Important";
            this.Important.FillWeight = 20F;
            this.Important.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Important.HeaderText = "";
            this.Important.MinimumWidth = 20;
            this.Important.Name = "Important";
            this.Important.ReadOnly = true;
            this.Important.ToolTipText = "Flagged As Important";
            this.Important.Width = 20;
            // 
            // ContactDateTime
            // 
            this.ContactDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ContactDateTime.DataPropertyName = "ContactDateTime";
            this.ContactDateTime.FillWeight = 85F;
            this.ContactDateTime.HeaderText = "Date";
            this.ContactDateTime.Name = "ContactDateTime";
            this.ContactDateTime.ReadOnly = true;
            this.ContactDateTime.Width = 85;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 175F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 175;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.nameDataGridViewTextBoxColumn.Width = 175;
            // 
            // getOutcomeDataGridViewTextBoxColumn
            // 
            this.getOutcomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.getOutcomeDataGridViewTextBoxColumn.DataPropertyName = "GetOutcome";
            this.getOutcomeDataGridViewTextBoxColumn.FillWeight = 62F;
            this.getOutcomeDataGridViewTextBoxColumn.HeaderText = "Outcome";
            this.getOutcomeDataGridViewTextBoxColumn.MinimumWidth = 62;
            this.getOutcomeDataGridViewTextBoxColumn.Name = "getOutcomeDataGridViewTextBoxColumn";
            this.getOutcomeDataGridViewTextBoxColumn.ReadOnly = true;
            this.getOutcomeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CallHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this._DateSelect);
            this.Controls.Add(this._ClearHistory);
            this.Controls.Add(this._Cancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._Done);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Name = "CallHistory";
            this.Padding = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.Size = new System.Drawing.Size(584, 241);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _Done;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button _Cancel;
        private System.Windows.Forms.Button _ClearHistory;
        internal LabelledComboBoxLong _DateSelect;
        internal CustomDataGrid dataGridView1;
        internal System.Windows.Forms.BindingSource bindingSource1;
        internal CallHistoryPanel callHistoryPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Important;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn getOutcomeDataGridViewTextBoxColumn;
    }
}
