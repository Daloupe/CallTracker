using System.Windows.Forms;
using System.Drawing;

namespace CallTracker.View
{
    partial class AddAROForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this._Suburb = new CallTracker.View.BorderedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._Node = new CallTracker.View.BorderedTextBox();
            this._TitleLabel = new System.Windows.Forms.Label();
            this._PR = new CallTracker.View.BorderedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Date = new System.Windows.Forms.DateTimePicker();
            this._Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bindSmartPasteToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this._Suburb);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this._Node);
            this.flowLayoutPanel1.Controls.Add(this._TitleLabel);
            this.flowLayoutPanel1.Controls.Add(this._PR);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this._Date);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(191, 107);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(49, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Suburb:";
            // 
            // _Suburb
            // 
            this._Suburb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._Suburb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this._Suburb.BorderColor = System.Drawing.Color.Gray;
            this._Suburb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Suburb.Location = new System.Drawing.Point(58, 6);
            this._Suburb.Name = "_Suburb";
            this._Suburb.Size = new System.Drawing.Size(128, 19);
            this._Suburb.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label6.Size = new System.Drawing.Size(49, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Node:";
            // 
            // _Node
            // 
            this._Node.BorderColor = System.Drawing.Color.Gray;
            this._Node.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Node.Location = new System.Drawing.Point(58, 31);
            this._Node.Name = "_Node";
            this._Node.Size = new System.Drawing.Size(128, 19);
            this._Node.TabIndex = 13;
            // 
            // _TitleLabel
            // 
            this._TitleLabel.Location = new System.Drawing.Point(3, 56);
            this._TitleLabel.Margin = new System.Windows.Forms.Padding(3);
            this._TitleLabel.Name = "_TitleLabel";
            this._TitleLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._TitleLabel.Size = new System.Drawing.Size(49, 19);
            this._TitleLabel.TabIndex = 0;
            this._TitleLabel.Text = "PR:";
            // 
            // _PR
            // 
            this._PR.BorderColor = System.Drawing.Color.Gray;
            this._PR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._PR.Dock = System.Windows.Forms.DockStyle.Right;
            this._PR.Location = new System.Drawing.Point(58, 56);
            this._PR.Name = "_PR";
            this._PR.Size = new System.Drawing.Size(128, 19);
            this._PR.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date:";
            // 
            // _Date
            // 
            this._Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Date.Location = new System.Drawing.Point(58, 81);
            this._Date.Name = "_Date";
            this._Date.Size = new System.Drawing.Size(130, 19);
            this._Date.TabIndex = 14;
            // 
            // _Cancel
            // 
            this._Cancel.BackColor = System.Drawing.Color.LightGray;
            this._Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._Cancel.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this._Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cancel.Location = new System.Drawing.Point(118, 247);
            this._Cancel.Name = "_Cancel";
            this._Cancel.Size = new System.Drawing.Size(75, 21);
            this._Cancel.TabIndex = 1;
            this._Cancel.Text = "Delete";
            this._Cancel.UseVisualStyleBackColor = false;
            this._Cancel.Click += new System.EventHandler(this._Cancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.flowLayoutPanel4);
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this._Cancel);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 275);
            this.panel1.TabIndex = 2;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel4.Controls.Add(this.checkBox11);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(61, 202);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.flowLayoutPanel4.Size = new System.Drawing.Size(54, 67);
            this.flowLayoutPanel4.TabIndex = 21;
            // 
            // checkBox11
            // 
            this.checkBox11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox11.Location = new System.Drawing.Point(5, 8);
            this.checkBox11.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(47, 20);
            this.checkBox11.TabIndex = 5;
            this.checkBox11.Tag = "64";
            this.checkBox11.Text = "MTV";
            this.checkBox11.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel3.Controls.Add(this.checkBox4);
            this.flowLayoutPanel3.Controls.Add(this.checkBox5);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 202);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(54, 67);
            this.flowLayoutPanel3.TabIndex = 20;
            // 
            // checkBox4
            // 
            this.checkBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox4.Location = new System.Drawing.Point(5, 8);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(47, 20);
            this.checkBox4.TabIndex = 6;
            this.checkBox4.Tag = "8";
            this.checkBox4.Text = "NFV";
            this.checkBox4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox5.Location = new System.Drawing.Point(5, 38);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(47, 20);
            this.checkBox5.TabIndex = 3;
            this.checkBox5.Tag = "16";
            this.checkBox5.Text = "NBF";
            this.checkBox5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel2.Controls.Add(this.checkBox1);
            this.flowLayoutPanel2.Controls.Add(this.checkBox2);
            this.flowLayoutPanel2.Controls.Add(this.checkBox3);
            this.flowLayoutPanel2.Controls.Add(this.checkBox10);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 132);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(112, 66);
            this.flowLayoutPanel2.TabIndex = 19;
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox1.Location = new System.Drawing.Point(5, 8);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(55, 20);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Tag = "1";
            this.checkBox1.Text = "LAT";
            this.checkBox1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox2.Location = new System.Drawing.Point(5, 38);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(55, 20);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Tag = "2";
            this.checkBox2.Text = "LIP";
            this.checkBox2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox3.Location = new System.Drawing.Point(60, 8);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(47, 20);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Tag = "4";
            this.checkBox3.Text = "ONC";
            this.checkBox3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.Checked = true;
            this.checkBox10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox10.Location = new System.Drawing.Point(60, 38);
            this.checkBox10.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(47, 20);
            this.checkBox10.TabIndex = 4;
            this.checkBox10.Tag = "32";
            this.checkBox10.Text = "DTV";
            this.checkBox10.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(118, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this._Ok_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 7F);
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindSmartPasteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(197, 18);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bindSmartPasteToolStripMenuItem
            // 
            this.bindSmartPasteToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.bindSmartPasteToolStripMenuItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bindSmartPasteToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.bindSmartPasteToolStripMenuItem.Name = "bindSmartPasteToolStripMenuItem";
            this.bindSmartPasteToolStripMenuItem.ReadOnly = true;
            this.bindSmartPasteToolStripMenuItem.Size = new System.Drawing.Size(113, 18);
            this.bindSmartPasteToolStripMenuItem.Text = "Add ARO";
            // 
            // AddAROForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.CancelButton = this._Cancel;
            this.ClientSize = new System.Drawing.Size(199, 275);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAROForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bind Smart Paste";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BindSmartPasteForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label _TitleLabel;
        private BorderedTextBox _PR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _Cancel;
        private System.Windows.Forms.Label label4;
        private BorderedTextBox _Suburb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private BorderedTextBox _Node;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
        private ToolStripTextBox bindSmartPasteToolStripMenuItem;
        private FlowLayoutPanel flowLayoutPanel4;
        private CheckBox checkBox10;
        private CheckBox checkBox11;
        private FlowLayoutPanel flowLayoutPanel3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private FlowLayoutPanel flowLayoutPanel2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private DateTimePicker _Date;
    }
}