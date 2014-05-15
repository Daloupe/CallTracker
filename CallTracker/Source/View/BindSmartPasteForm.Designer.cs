using System.Windows.Forms;
using System.Drawing;

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
            this._System = new CallTracker.View.BorderedTextBox();
            this.pasteBindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new CallTracker.View.BorderedTextBox();
            this._TitleLabel = new System.Windows.Forms.Label();
            this._Title = new CallTracker.View.BorderedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Element = new CallTracker.View.BorderedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Url = new CallTracker.View.BorderedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Data = new CallTracker.View.BorderedCombobox();
            this.label5 = new System.Windows.Forms.Label();
            this._AltData = new CallTracker.View.BorderedCombobox();
            this._Cancel = new System.Windows.Forms.Button();
            this.customerContactBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bindSmartPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pasteBindBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerContactBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this._System);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this._TitleLabel);
            this.flowLayoutPanel1.Controls.Add(this._Title);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this._Element);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this._Url);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this._Data);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this._AltData);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(230, 211);
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
            // _System
            // 
            this._System.BorderColor = System.Drawing.Color.Gray;
            this._System.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._System.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "System", true));
            this._System.Location = new System.Drawing.Point(64, 6);
            this._System.Name = "_System";
            this._System.Size = new System.Drawing.Size(161, 19);
            this._System.TabIndex = 9;
            // 
            // pasteBindBindingSource
            // 
            this.pasteBindBindingSource.DataSource = typeof(CallTracker.Model.PasteBind);
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
            // textBox1
            // 
            this.textBox1.BorderColor = System.Drawing.Color.Gray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Name", true));
            this.textBox1.Location = new System.Drawing.Point(64, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 19);
            this.textBox1.TabIndex = 13;
            // 
            // _TitleLabel
            // 
            this._TitleLabel.Location = new System.Drawing.Point(3, 56);
            this._TitleLabel.Margin = new System.Windows.Forms.Padding(3);
            this._TitleLabel.Name = "_TitleLabel";
            this._TitleLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._TitleLabel.Size = new System.Drawing.Size(55, 19);
            this._TitleLabel.TabIndex = 0;
            this._TitleLabel.Text = "Title:";
            // 
            // _Title
            // 
            this._Title.BorderColor = System.Drawing.Color.Gray;
            this._Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Title", true));
            this._Title.Dock = System.Windows.Forms.DockStyle.Right;
            this._Title.Location = new System.Drawing.Point(64, 56);
            this._Title.Name = "_Title";
            this._Title.Size = new System.Drawing.Size(161, 19);
            this._Title.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Element:";
            // 
            // _Element
            // 
            this._Element.BorderColor = System.Drawing.Color.Gray;
            this._Element.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Element.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Element", true));
            this._Element.Dock = System.Windows.Forms.DockStyle.Right;
            this._Element.Location = new System.Drawing.Point(64, 81);
            this._Element.Name = "_Element";
            this._Element.Size = new System.Drawing.Size(161, 19);
            this._Element.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(55, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // _Url
            // 
            this._Url.BorderColor = System.Drawing.Color.Gray;
            this._Url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Url.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Url", true));
            this._Url.Dock = System.Windows.Forms.DockStyle.Right;
            this._Url.Location = new System.Drawing.Point(64, 106);
            this._Url.Multiline = true;
            this._Url.Name = "_Url";
            this._Url.Size = new System.Drawing.Size(161, 44);
            this._Url.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data:";
            // 
            // _Data
            // 
            this._Data.BorderColor = System.Drawing.Color.Gray;
            this._Data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Data.FormattingEnabled = true;
            this._Data.Location = new System.Drawing.Point(64, 156);
            this._Data.Name = "_Data";
            this._Data.Size = new System.Drawing.Size(162, 20);
            this._Data.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 182);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label5.Size = new System.Drawing.Size(55, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Alt Data:";
            // 
            // _AltData
            // 
            this._AltData.BorderColor = System.Drawing.Color.Gray;
            this._AltData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._AltData.FormattingEnabled = true;
            this._AltData.Location = new System.Drawing.Point(64, 182);
            this._AltData.Name = "_AltData";
            this._AltData.Size = new System.Drawing.Size(162, 20);
            this._AltData.TabIndex = 11;
            // 
            // _Cancel
            // 
            this._Cancel.BackColor = System.Drawing.Color.LightGray;
            this._Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._Cancel.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this._Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cancel.Location = new System.Drawing.Point(158, 236);
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
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this._Cancel);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 263);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(77, 236);
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
            this.bindSmartPasteToolStripMenuItem.Name = "bindSmartPasteToolStripMenuItem";
            this.bindSmartPasteToolStripMenuItem.Size = new System.Drawing.Size(113, 18);
            this.bindSmartPasteToolStripMenuItem.Text = "Bind Smart Paste";
            // 
            // BindSmartPasteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.CancelButton = this._Cancel;
            this.ClientSize = new System.Drawing.Size(238, 263);
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
            ((System.ComponentModel.ISupportInitialize)(this.pasteBindBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerContactBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label _TitleLabel;
        private BorderedTextBox _Title;
        private System.Windows.Forms.Label label2;
        private BorderedTextBox _Element;
        private System.Windows.Forms.Label label1;
        private BorderedTextBox _Url;
        private System.Windows.Forms.Label label3;
        private BorderedCombobox _Data;
        private System.Windows.Forms.Button _Cancel;
        private System.Windows.Forms.BindingSource customerContactBindingSource;
        private System.Windows.Forms.Label label4;
        private BorderedTextBox _System;
        private System.Windows.Forms.BindingSource pasteBindBindingSource;
        private System.Windows.Forms.Label label5;
        private BorderedCombobox _AltData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private BorderedTextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bindSmartPasteToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}