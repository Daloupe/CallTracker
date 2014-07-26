namespace CallTracker.View
{
    partial class EditLogins
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
            this._Done = new System.Windows.Forms.Button();
            this.textBox1 = new CallTracker.View.BorderedTextBox();
            this.loginsModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.systemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this._Element = new CallTracker.View.BorderedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new CallTracker.View.BorderedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new CallTracker.View.BorderedTextBox();
            this._AsTextFields = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this._FindByName = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this._FormElement = new CallTracker.View.BorderedTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new CallTracker.View.BorderedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.propertyLock = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.loginsModelBindingSource)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            // textBox1
            // 
            this.textBox1.BorderColor = System.Drawing.Color.Gray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loginsModelBindingSource, "Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(6, 48);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 19);
            this.textBox1.TabIndex = 7;
            // 
            // loginsModelBindingSource
            // 
            this.loginsModelBindingSource.DataSource = typeof(CallTracker.Model.LoginsModel);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
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
            this.usernameDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.loginsModelBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
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
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this._Element);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.textBox2);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.textBox3);
            this.flowLayoutPanel1.Controls.Add(this._AsTextFields);
            this.flowLayoutPanel1.Controls.Add(this.checkBox4);
            this.flowLayoutPanel1.Controls.Add(this._FindByName);
            this.flowLayoutPanel1.Controls.Add(this.checkBox3);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this._FormElement);
            this.flowLayoutPanel1.Controls.Add(this.checkBox1);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.textBox4);
            this.flowLayoutPanel1.Enabled = false;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(205, 343);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBorder);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 10);
            this.label2.TabIndex = 6;
            this.label2.Text = "URL:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _Element
            // 
            this._Element.BorderColor = System.Drawing.Color.Gray;
            this._Element.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Element.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loginsModelBindingSource, "Url", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Element.Location = new System.Drawing.Point(6, 16);
            this._Element.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this._Element.Name = "_Element";
            this._Element.Size = new System.Drawing.Size(189, 19);
            this._Element.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 10);
            this.label1.TabIndex = 8;
            this.label1.Text = "Title:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(6, 73);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 1);
            this.panel2.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 10);
            this.label3.TabIndex = 10;
            this.label3.Text = "UN Element:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.BorderColor = System.Drawing.Color.Gray;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loginsModelBindingSource, "UsernameElement", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(6, 90);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(189, 19);
            this.textBox2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 109);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 10);
            this.label4.TabIndex = 12;
            this.label4.Text = "PW Element:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.BorderColor = System.Drawing.Color.Gray;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loginsModelBindingSource, "PasswordElement", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox3.Location = new System.Drawing.Point(6, 122);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(189, 19);
            this.textBox3.TabIndex = 11;
            // 
            // _AsTextFields
            // 
            this._AsTextFields.AutoSize = true;
            this._AsTextFields.Location = new System.Drawing.Point(6, 144);
            this._AsTextFields.Name = "_AsTextFields";
            this._AsTextFields.Size = new System.Drawing.Size(98, 16);
            this._AsTextFields.TabIndex = 17;
            this._AsTextFields.Text = "As TextFields";
            this._AsTextFields.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(6, 166);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(80, 16);
            this.checkBox4.TabIndex = 24;
            this.checkBox4.Text = "Type Text";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // _FindByName
            // 
            this._FindByName.AutoSize = true;
            this._FindByName.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.loginsModelBindingSource, "FindByName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._FindByName.Location = new System.Drawing.Point(6, 188);
            this._FindByName.Name = "_FindByName";
            this._FindByName.Size = new System.Drawing.Size(100, 16);
            this._FindByName.TabIndex = 25;
            this._FindByName.Text = "Find By Name";
            this._FindByName.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.loginsModelBindingSource, "FindInForm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox3.Location = new System.Drawing.Point(6, 210);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(118, 16);
            this.checkBox3.TabIndex = 18;
            this.checkBox3.Text = "Find Within Form";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(6, 235);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 1);
            this.panel1.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 239);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(189, 10);
            this.label7.TabIndex = 20;
            this.label7.Text = "Form Element:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // _FormElement
            // 
            this._FormElement.BorderColor = System.Drawing.Color.Gray;
            this._FormElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._FormElement.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loginsModelBindingSource, "FormElement", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._FormElement.Location = new System.Drawing.Point(6, 252);
            this._FormElement.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this._FormElement.Name = "_FormElement";
            this._FormElement.Size = new System.Drawing.Size(189, 19);
            this._FormElement.TabIndex = 19;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.loginsModelBindingSource, "SubmitAsForm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Location = new System.Drawing.Point(6, 274);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 16);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Submit As Form";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(6, 299);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 1);
            this.panel3.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 303);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 10);
            this.label5.TabIndex = 14;
            this.label5.Text = "Submit Element:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            this.textBox4.BorderColor = System.Drawing.Color.Gray;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loginsModelBindingSource, "SubmitElement", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox4.Location = new System.Drawing.Point(6, 316);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(189, 19);
            this.textBox4.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(3, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "//Edit Logins";
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
            this.propertyLock.TabIndex = 14;
            this.propertyLock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.propertyLock.UseVisualStyleBackColor = false;
            this.propertyLock.CheckedChanged += new System.EventHandler(this.propertyLock_CheckedChanged);
            // 
            // EditLogins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.propertyLock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._Done);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Name = "EditLogins";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(584, 222);
            ((System.ComponentModel.ISupportInitialize)(this.loginsModelBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _Done;
        private System.Windows.Forms.BindingSource loginsModelBindingSource;
        private BorderedTextBox textBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private BorderedTextBox _Element;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private BorderedTextBox textBox2;
        private System.Windows.Forms.Label label4;
        private BorderedTextBox textBox3;
        private System.Windows.Forms.Label label5;
        private BorderedTextBox textBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn systemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox propertyLock;
        private System.Windows.Forms.CheckBox _AsTextFields;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private BorderedTextBox _FormElement;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox _FindByName;
    }
}
