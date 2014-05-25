namespace CallTracker.View
{
    partial class EditSmartPasteBinds : ViewControlBase
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
            this.propertyLock = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this._Done = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.systemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pasteBindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this._Element = new CallTracker.View.BorderedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new CallTracker.View.BorderedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new CallTracker.View.BorderedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Data = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._AltData = new System.Windows.Forms.ComboBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasteBindBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyLock
            // 
            this.propertyLock.BackColor = System.Drawing.Color.Transparent;
            this.propertyLock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.propertyLock.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.propertyLock.Checked = true;
            this.propertyLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.propertyLock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.propertyLock.Image = global::CallTracker.Properties.Resources.padlock_small;
            this.propertyLock.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.propertyLock.Location = new System.Drawing.Point(360, 197);
            this.propertyLock.Name = "propertyLock";
            this.propertyLock.Padding = new System.Windows.Forms.Padding(3);
            this.propertyLock.Size = new System.Drawing.Size(38, 22);
            this.propertyLock.TabIndex = 15;
            this.propertyLock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.propertyLock.UseVisualStyleBackColor = false;
            this.propertyLock.CheckedChanged += new System.EventHandler(this.propertyLock_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(3, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "//Edit Smart Paste Binds";
            // 
            // _Done
            // 
            this._Done.BackColor = System.Drawing.Color.LightGray;
            this._Done.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this._Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Done.Location = new System.Drawing.Point(506, 197);
            this._Done.Name = "_Done";
            this._Done.Size = new System.Drawing.Size(75, 22);
            this._Done.TabIndex = 10;
            this._Done.Text = "Done";
            this._Done.UseVisualStyleBackColor = false;
            this._Done.Click += new System.EventHandler(this._Done_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
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
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(578, 191);
            this.splitContainer1.SplitterDistance = 353;
            this.splitContainer1.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.systemDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pasteBindBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.Size = new System.Drawing.Size(353, 191);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBorder);
            // 
            // systemDataGridViewTextBoxColumn
            // 
            this.systemDataGridViewTextBoxColumn.DataPropertyName = "System";
            this.systemDataGridViewTextBoxColumn.HeaderText = "System";
            this.systemDataGridViewTextBoxColumn.Name = "systemDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Bind Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // pasteBindBindingSource
            // 
            this.pasteBindBindingSource.DataSource = typeof(CallTracker.Model.PasteBind);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this._Element);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.textBox2);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this._Data);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this._AltData);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Enabled = false;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(221, 191);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBorder);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(190, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "URL:";
            // 
            // _Element
            // 
            this._Element.BorderColor = System.Drawing.Color.Gray;
            this._Element.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Element.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Url", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Element.ForeColor = System.Drawing.SystemColors.WindowText;
            this._Element.Location = new System.Drawing.Point(6, 20);
            this._Element.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this._Element.Name = "_Element";
            this._Element.Size = new System.Drawing.Size(190, 19);
            this._Element.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(190, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Title:";
            // 
            // textBox1
            // 
            this.textBox1.BorderColor = System.Drawing.Color.Gray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(6, 56);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 19);
            this.textBox1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(190, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Element:";
            // 
            // textBox2
            // 
            this.textBox2.BorderColor = System.Drawing.Color.Gray;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Element", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(6, 92);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 19);
            this.textBox2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 111);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(190, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Data:";
            // 
            // _Data
            // 
            this._Data.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Data.FormattingEnabled = true;
            this._Data.Location = new System.Drawing.Point(6, 128);
            this._Data.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this._Data.Name = "_Data";
            this._Data.Size = new System.Drawing.Size(190, 20);
            this._Data.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Location = new System.Drawing.Point(6, 148);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label5.Size = new System.Drawing.Size(190, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Alternate Data:";
            // 
            // _AltData
            // 
            this._AltData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._AltData.FormattingEnabled = true;
            this._AltData.Location = new System.Drawing.Point(6, 165);
            this._AltData.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this._AltData.Name = "_AltData";
            this._AltData.Size = new System.Drawing.Size(190, 20);
            this._AltData.TabIndex = 18;
            // 
            // EditSmartPasteBinds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.propertyLock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._Done);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Name = "EditSmartPasteBinds";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(584, 222);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasteBindBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _Done;
        private BorderedTextBox textBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private BorderedTextBox _Element;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private BorderedTextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _Data;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _AltData;
        private System.Windows.Forms.DataGridViewTextBoxColumn systemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.BindingSource pasteBindBindingSource;
        private System.Windows.Forms.CheckBox propertyLock;
    }
}
