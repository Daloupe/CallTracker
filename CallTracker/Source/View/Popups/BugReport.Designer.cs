using System.Windows.Forms;

namespace CallTracker.View
{
    partial class BugReport
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
            this.label3 = new System.Windows.Forms.Label();
            this._Info = new CallTracker.View.BorderedTextBox();
            this._Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Save = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bindSmartPasteToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this._Info);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(230, 176);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Info:";
            // 
            // _Info
            // 
            this._Info.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this._Info.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this._Info.BorderColor = System.Drawing.Color.Gray;
            this._Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Info.Location = new System.Drawing.Point(3, 31);
            this._Info.Multiline = true;
            this._Info.Name = "_Info";
            this._Info.Size = new System.Drawing.Size(225, 141);
            this._Info.TabIndex = 5;
            // 
            // _Cancel
            // 
            this._Cancel.BackColor = System.Drawing.Color.LightGray;
            this._Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._Cancel.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this._Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cancel.Location = new System.Drawing.Point(158, 199);
            this._Cancel.Name = "_Cancel";
            this._Cancel.Size = new System.Drawing.Size(75, 21);
            this._Cancel.TabIndex = 1;
            this._Cancel.Text = "Cancel";
            this._Cancel.UseVisualStyleBackColor = false;
            this._Cancel.Click += new System.EventHandler(this._Cancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._Save);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this._Cancel);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 225);
            this.panel1.TabIndex = 2;
            // 
            // _Save
            // 
            this._Save.BackColor = System.Drawing.Color.LightGray;
            this._Save.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._Save.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this._Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Save.Location = new System.Drawing.Point(3, 199);
            this._Save.Name = "_Save";
            this._Save.Size = new System.Drawing.Size(75, 21);
            this._Save.TabIndex = 3;
            this._Save.Text = "Send";
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
            this.bindSmartPasteToolStripMenuItem.Text = "Bug Report";
            // 
            // BugReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.CancelButton = this._Cancel;
            this.ClientSize = new System.Drawing.Size(238, 225);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BugReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bind Smart Paste";
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _Cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button _Save;
        private ToolStripTextBox bindSmartPasteToolStripMenuItem;
        private BorderedTextBox _Info;
    }
}