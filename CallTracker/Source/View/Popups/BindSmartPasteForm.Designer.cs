using System.Windows.Forms;

namespace CallTracker.View
{
    partial class BindSmartPasteForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._TitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._FireOnChange = new System.Windows.Forms.CheckBox();
            this._FireOnChangeNoWait = new System.Windows.Forms.CheckBox();
            this._PasteWithSendKeys = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this._Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Help = new System.Windows.Forms.Button();
            this._Save = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bindSmartPasteToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this._AutoFill = new System.Windows.Forms.CheckBox();
            this._System = new CallTracker.View.BorderedTextBox();
            this.pasteBindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new CallTracker.View.BorderedTextBox();
            this._Title = new CallTracker.View.BorderedTextBox();
            this._Url = new CallTracker.View.BorderedTextBox();
            this._Element = new CallTracker.View.BorderedTextBox();
            this._Data = new CallTracker.View.BorderedTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pasteBindBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this._System);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this._TitleLabel);
            this.flowLayoutPanel1.Controls.Add(this._Title);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this._Url);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this._Element);
            this.flowLayoutPanel1.Controls.Add(this._FireOnChange);
            this.flowLayoutPanel1.Controls.Add(this._FireOnChangeNoWait);
            this.flowLayoutPanel1.Controls.Add(this._PasteWithSendKeys);
            this.flowLayoutPanel1.Controls.Add(this._AutoFill);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this._Data);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(230, 280);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "System:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label6.Size = new System.Drawing.Size(55, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Name:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(3, 59);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 1);
            this.panel2.TabIndex = 22;
            // 
            // _TitleLabel
            // 
            this._TitleLabel.Location = new System.Drawing.Point(3, 66);
            this._TitleLabel.Margin = new System.Windows.Forms.Padding(3);
            this._TitleLabel.Name = "_TitleLabel";
            this._TitleLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._TitleLabel.Size = new System.Drawing.Size(55, 19);
            this._TitleLabel.TabIndex = 0;
            this._TitleLabel.Text = "Title:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Element:";
            // 
            // _FireOnChange
            // 
            this._FireOnChange.AutoSize = true;
            this._FireOnChange.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pasteBindBindingSource, "FireOnChange", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._FireOnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._FireOnChange.Location = new System.Drawing.Point(3, 141);
            this._FireOnChange.Name = "_FireOnChange";
            this._FireOnChange.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this._FireOnChange.Size = new System.Drawing.Size(114, 16);
            this._FireOnChange.TabIndex = 25;
            this._FireOnChange.Text = "Fire OnChange";
            this._FireOnChange.UseVisualStyleBackColor = true;
            this._FireOnChange.CheckedChanged += new System.EventHandler(this._FireOnChange_CheckedChanged);
            // 
            // _FireOnChangeNoWait
            // 
            this._FireOnChangeNoWait.AutoSize = true;
            this._FireOnChangeNoWait.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pasteBindBindingSource, "FireOnChangeNoWait", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._FireOnChangeNoWait.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._FireOnChangeNoWait.Location = new System.Drawing.Point(123, 141);
            this._FireOnChangeNoWait.Name = "_FireOnChangeNoWait";
            this._FireOnChangeNoWait.Size = new System.Drawing.Size(93, 16);
            this._FireOnChangeNoWait.TabIndex = 26;
            this._FireOnChangeNoWait.Text = "With No Wait";
            this._FireOnChangeNoWait.UseVisualStyleBackColor = true;
            this._FireOnChangeNoWait.CheckedChanged += new System.EventHandler(this._FireOnChangeNoWait_CheckedChanged);
            // 
            // _PasteWithSendKeys
            // 
            this._PasteWithSendKeys.AutoSize = true;
            this._PasteWithSendKeys.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pasteBindBindingSource, "PasteWithSendKeys", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._PasteWithSendKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._PasteWithSendKeys.Location = new System.Drawing.Point(3, 163);
            this._PasteWithSendKeys.Name = "_PasteWithSendKeys";
            this._PasteWithSendKeys.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this._PasteWithSendKeys.Size = new System.Drawing.Size(145, 16);
            this._PasteWithSendKeys.TabIndex = 27;
            this._PasteWithSendKeys.Text = "Paste with SendKeys";
            this._PasteWithSendKeys.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(3, 188);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(224, 1);
            this.panel4.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 195);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data:";
            // 
            // _Cancel
            // 
            this._Cancel.BackColor = System.Drawing.Color.LightGray;
            this._Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._Cancel.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this._Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cancel.Location = new System.Drawing.Point(158, 304);
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
            this.panel1.Controls.Add(this._Help);
            this.panel1.Controls.Add(this._Save);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this._Cancel);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 330);
            this.panel1.TabIndex = 2;
            // 
            // _Help
            // 
            this._Help.BackColor = System.Drawing.Color.LightGray;
            this._Help.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._Help.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this._Help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Help.Location = new System.Drawing.Point(3, 304);
            this._Help.Name = "_Help";
            this._Help.Size = new System.Drawing.Size(68, 21);
            this._Help.TabIndex = 4;
            this._Help.Text = "Help";
            this._Help.UseVisualStyleBackColor = false;
            this._Help.Click += new System.EventHandler(this._Help_Click);
            // 
            // _Save
            // 
            this._Save.BackColor = System.Drawing.Color.LightGray;
            this._Save.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._Save.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this._Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Save.Location = new System.Drawing.Point(77, 304);
            this._Save.Name = "_Save";
            this._Save.Size = new System.Drawing.Size(75, 21);
            this._Save.TabIndex = 3;
            this._Save.Text = "Save";
            this._Save.UseVisualStyleBackColor = false;
            this._Save.Click += new System.EventHandler(this._Ok_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(236, 18);
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
            this.bindSmartPasteToolStripMenuItem.Text = "Bind Smart Paste";
            // 
            // _AutoFill
            // 
            this._AutoFill.AutoSize = true;
            this._AutoFill.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pasteBindBindingSource, "AutoFill", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._AutoFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._AutoFill.Location = new System.Drawing.Point(154, 163);
            this._AutoFill.Name = "_AutoFill";
            this._AutoFill.Size = new System.Drawing.Size(61, 16);
            this._AutoFill.TabIndex = 32;
            this._AutoFill.Text = "AutoFill";
            this._AutoFill.UseVisualStyleBackColor = true;
            // 
            // _System
            // 
            this._System.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._System.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this._System.BorderColor = System.Drawing.Color.Gray;
            this._System.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._System.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "System", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._System.Location = new System.Drawing.Point(64, 6);
            this._System.Name = "_System";
            this._System.Size = new System.Drawing.Size(161, 19);
            this._System.TabIndex = 9;
            // 
            // pasteBindBindingSource
            // 
            this.pasteBindBindingSource.DataSource = typeof(CallTracker.Model.PasteBind);
            // 
            // textBox1
            // 
            this.textBox1.BorderColor = System.Drawing.Color.Gray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(64, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 19);
            this.textBox1.TabIndex = 13;
            // 
            // _Title
            // 
            this._Title.BorderColor = System.Drawing.Color.Gray;
            this._Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Title.Dock = System.Windows.Forms.DockStyle.Right;
            this._Title.Location = new System.Drawing.Point(64, 66);
            this._Title.Name = "_Title";
            this._Title.Size = new System.Drawing.Size(161, 19);
            this._Title.TabIndex = 1;
            // 
            // _Url
            // 
            this._Url.BorderColor = System.Drawing.Color.Gray;
            this._Url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Url.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Url", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Url.Location = new System.Drawing.Point(64, 91);
            this._Url.Name = "_Url";
            this._Url.Size = new System.Drawing.Size(161, 19);
            this._Url.TabIndex = 14;
            // 
            // _Element
            // 
            this._Element.BorderColor = System.Drawing.Color.Gray;
            this._Element.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Element.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Element", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Element.Dock = System.Windows.Forms.DockStyle.Right;
            this._Element.Location = new System.Drawing.Point(64, 116);
            this._Element.Name = "_Element";
            this._Element.Size = new System.Drawing.Size(161, 19);
            this._Element.TabIndex = 3;
            // 
            // _Data
            // 
            this._Data.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this._Data.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this._Data.BorderColor = System.Drawing.Color.Gray;
            this._Data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Data.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Data", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Data.Location = new System.Drawing.Point(64, 195);
            this._Data.Multiline = true;
            this._Data.Name = "_Data";
            this._Data.Size = new System.Drawing.Size(161, 75);
            this._Data.TabIndex = 5;
            // 
            // BindSmartPasteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.CancelButton = this._Save;
            this.ClientSize = new System.Drawing.Size(238, 330);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BindSmartPasteForm";
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pasteBindBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label _TitleLabel;
        private BorderedTextBox _Title;
        private System.Windows.Forms.Label label2;
        private BorderedTextBox _Element;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _Cancel;
        private System.Windows.Forms.Label label4;
        private BorderedTextBox _System;
        private System.Windows.Forms.BindingSource pasteBindBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private BorderedTextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button _Save;
        private ToolStripTextBox bindSmartPasteToolStripMenuItem;
        private BorderedTextBox _Url;
        private BorderedTextBox _Data;
        private Button _Help;
        private Panel panel2;
        private Panel panel4;
        private CheckBox _FireOnChange;
        private CheckBox _FireOnChangeNoWait;
        private CheckBox _PasteWithSendKeys;
        private CheckBox _AutoFill;
    }
}