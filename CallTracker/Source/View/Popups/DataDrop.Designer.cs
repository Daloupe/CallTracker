using System.Windows.Forms;

namespace CallTracker.View
{
    partial class DataDrop
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
            this._Data = new CallTracker.View.BorderedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new CallTracker.View.ToolStripMenuIgnoreFocus();
            this.bindSmartPasteToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.Controls.Add(this._Data);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 21);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(232, 27);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // _Data
            // 
            this._Data.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._Data.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this._Data.BorderColor = System.Drawing.Color.Gray;
            this._Data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Data.Location = new System.Drawing.Point(2, 4);
            this._Data.Margin = new System.Windows.Forms.Padding(2);
            this._Data.Name = "_Data";
            this._Data.Size = new System.Drawing.Size(227, 19);
            this._Data.TabIndex = 9;
            this._Data.KeyDown += new System.Windows.Forms.KeyEventHandler(this._Data_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 52);
            this.panel1.TabIndex = 2;
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
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this._MainMenu_MouseDown);
            // 
            // bindSmartPasteToolStripMenuItem
            // 
            this.bindSmartPasteToolStripMenuItem.AutoSize = false;
            this.bindSmartPasteToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.bindSmartPasteToolStripMenuItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bindSmartPasteToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.bindSmartPasteToolStripMenuItem.Name = "bindSmartPasteToolStripMenuItem";
            this.bindSmartPasteToolStripMenuItem.ReadOnly = true;
            this.bindSmartPasteToolStripMenuItem.Size = new System.Drawing.Size(60, 18);
            this.bindSmartPasteToolStripMenuItem.Text = "Data Drop";
            // 
            // DataDrop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(238, 52);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataDrop";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bind Smart Paste";
            this.Activated += new System.EventHandler(this.DataDrop_Activated);
            this.Deactivate += new System.EventHandler(this.DataDrop_Leave);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private BorderedTextBox _Data;
        private System.Windows.Forms.Panel panel1;
        private ToolStripMenuIgnoreFocus menuStrip1;
        private ToolStripTextBox bindSmartPasteToolStripMenuItem;
    }
}