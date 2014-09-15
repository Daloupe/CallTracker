using RichTextBoxLinks;

namespace CallTracker.View
{
    partial class DidYouKnow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.examplePanel = new System.Windows.Forms.Panel();
            this.exampleTextPanel = new System.Windows.Forms.Panel();
            this.exampleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.exampleHeadingPanel = new System.Windows.Forms.Panel();
            this._CloseExample = new System.Windows.Forms.PictureBox();
            this.exampleHeading = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tipsPanel = new System.Windows.Forms.Panel();
            this.tipsTextPanel = new System.Windows.Forms.Panel();
            this.richTextBox1 = new RichTextBoxLinks.RichTextBoxEx();
            this.panel4 = new System.Windows.Forms.Panel();
            this.prevTip = new System.Windows.Forms.Button();
            this.nextTip = new System.Windows.Forms.Button();
            this.showTipsOnStartup = new System.Windows.Forms.CheckBox();
            this.headingPanel = new System.Windows.Forms.Panel();
            this.heading = new System.Windows.Forms.Label();
            this.menuStrip1 = new CallTracker.View.ToolStripMenuIgnoreFocus();
            this.quitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.panel1.SuspendLayout();
            this.examplePanel.SuspendLayout();
            this.exampleTextPanel.SuspendLayout();
            this.exampleHeadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._CloseExample)).BeginInit();
            this.tipsPanel.SuspendLayout();
            this.tipsTextPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.headingPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.examplePanel);
            this.panel1.Controls.Add(this.tipsPanel);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.headingPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.panel1.Size = new System.Drawing.Size(414, 222);
            this.panel1.TabIndex = 3;
            // 
            // examplePanel
            // 
            this.examplePanel.Controls.Add(this.exampleTextPanel);
            this.examplePanel.Controls.Add(this.exampleHeadingPanel);
            this.examplePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.examplePanel.Location = new System.Drawing.Point(3, 147);
            this.examplePanel.Name = "examplePanel";
            this.examplePanel.Size = new System.Drawing.Size(408, 47);
            this.examplePanel.TabIndex = 7;
            // 
            // exampleTextPanel
            // 
            this.exampleTextPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(143)))), ((int)(((byte)(169)))));
            this.exampleTextPanel.Controls.Add(this.exampleRichTextBox);
            this.exampleTextPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exampleTextPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.exampleTextPanel.Location = new System.Drawing.Point(0, 14);
            this.exampleTextPanel.Margin = new System.Windows.Forms.Padding(0);
            this.exampleTextPanel.Name = "exampleTextPanel";
            this.exampleTextPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.exampleTextPanel.Size = new System.Drawing.Size(408, 33);
            this.exampleTextPanel.TabIndex = 5;
            // 
            // exampleRichTextBox
            // 
            this.exampleRichTextBox.AutoWordSelection = true;
            this.exampleRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(103)))), ((int)(((byte)(129)))));
            this.exampleRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exampleRichTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.exampleRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exampleRichTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(162)))));
            this.exampleRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.exampleRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.exampleRichTextBox.Name = "exampleRichTextBox";
            this.exampleRichTextBox.ReadOnly = true;
            this.exampleRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.exampleRichTextBox.Size = new System.Drawing.Size(408, 31);
            this.exampleRichTextBox.TabIndex = 4;
            this.exampleRichTextBox.Text = "";
            // 
            // exampleHeadingPanel
            // 
            this.exampleHeadingPanel.BackColor = System.Drawing.Color.Transparent;
            this.exampleHeadingPanel.Controls.Add(this._CloseExample);
            this.exampleHeadingPanel.Controls.Add(this.exampleHeading);
            this.exampleHeadingPanel.Controls.Add(this.label3);
            this.exampleHeadingPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.exampleHeadingPanel.Location = new System.Drawing.Point(0, 0);
            this.exampleHeadingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.exampleHeadingPanel.Name = "exampleHeadingPanel";
            this.exampleHeadingPanel.Size = new System.Drawing.Size(408, 14);
            this.exampleHeadingPanel.TabIndex = 5;
            // 
            // _CloseExample
            // 
            this._CloseExample.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(119)))));
            this._CloseExample.Cursor = System.Windows.Forms.Cursors.Hand;
            this._CloseExample.Dock = System.Windows.Forms.DockStyle.Right;
            this._CloseExample.Image = global::CallTracker.Properties.Resources.TipExampleClose;
            this._CloseExample.Location = new System.Drawing.Point(394, 0);
            this._CloseExample.Margin = new System.Windows.Forms.Padding(0);
            this._CloseExample.Name = "_CloseExample";
            this._CloseExample.Size = new System.Drawing.Size(14, 14);
            this._CloseExample.TabIndex = 4;
            this._CloseExample.TabStop = false;
            this._CloseExample.Click += new System.EventHandler(this._CloseExample_Click);
            // 
            // exampleHeading
            // 
            this.exampleHeading.AutoSize = true;
            this.exampleHeading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(119)))));
            this.exampleHeading.Dock = System.Windows.Forms.DockStyle.Left;
            this.exampleHeading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exampleHeading.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Bold);
            this.exampleHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.exampleHeading.Location = new System.Drawing.Point(0, 0);
            this.exampleHeading.Margin = new System.Windows.Forms.Padding(0);
            this.exampleHeading.Name = "exampleHeading";
            this.exampleHeading.Size = new System.Drawing.Size(58, 12);
            this.exampleHeading.TabIndex = 3;
            this.exampleHeading.Text = "Example:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(119)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(408, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tips:";
            // 
            // tipsPanel
            // 
            this.tipsPanel.BackColor = System.Drawing.Color.Transparent;
            this.tipsPanel.Controls.Add(this.tipsTextPanel);
            this.tipsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tipsPanel.Location = new System.Drawing.Point(3, 33);
            this.tipsPanel.Name = "tipsPanel";
            this.tipsPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tipsPanel.Size = new System.Drawing.Size(408, 114);
            this.tipsPanel.TabIndex = 6;
            // 
            // tipsTextPanel
            // 
            this.tipsTextPanel.BackColor = System.Drawing.Color.Transparent;
            this.tipsTextPanel.Controls.Add(this.richTextBox1);
            this.tipsTextPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tipsTextPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.tipsTextPanel.Location = new System.Drawing.Point(0, 2);
            this.tipsTextPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tipsTextPanel.Name = "tipsTextPanel";
            this.tipsTextPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.tipsTextPanel.Size = new System.Drawing.Size(408, 112);
            this.tipsTextPanel.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(143)))), ((int)(((byte)(169)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(162)))));
            this.richTextBox1.LinkColor = System.Drawing.Color.DarkGoldenrod;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(408, 110);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(103)))), ((int)(((byte)(129)))));
            this.panel4.Controls.Add(this.prevTip);
            this.panel4.Controls.Add(this.nextTip);
            this.panel4.Controls.Add(this.showTipsOnStartup);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 193);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel4.Size = new System.Drawing.Size(408, 26);
            this.panel4.TabIndex = 6;
            // 
            // prevTip
            // 
            this.prevTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(83)))), ((int)(((byte)(109)))));
            this.prevTip.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.prevTip.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.prevTip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.prevTip.Location = new System.Drawing.Point(276, 2);
            this.prevTip.Name = "prevTip";
            this.prevTip.Size = new System.Drawing.Size(64, 22);
            this.prevTip.TabIndex = 4;
            this.prevTip.Text = "Prev Tip";
            this.prevTip.UseVisualStyleBackColor = false;
            this.prevTip.Click += new System.EventHandler(this.prevTip_Click);
            this.prevTip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ok_MouseUp);
            // 
            // nextTip
            // 
            this.nextTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(83)))), ((int)(((byte)(109)))));
            this.nextTip.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.nextTip.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.nextTip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.nextTip.Location = new System.Drawing.Point(342, 2);
            this.nextTip.Name = "nextTip";
            this.nextTip.Size = new System.Drawing.Size(64, 22);
            this.nextTip.TabIndex = 3;
            this.nextTip.Text = "Next Tip";
            this.nextTip.UseVisualStyleBackColor = false;
            this.nextTip.Click += new System.EventHandler(this.nextTip_Click);
            this.nextTip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ok_MouseUp);
            // 
            // showTipsOnStartup
            // 
            this.showTipsOnStartup.Checked = global::CallTracker.Properties.Settings.Default.ShowTipsOnStartup;
            this.showTipsOnStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTipsOnStartup.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CallTracker.Properties.Settings.Default, "ShowTipsOnStartup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.showTipsOnStartup.Dock = System.Windows.Forms.DockStyle.Left;
            this.showTipsOnStartup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.showTipsOnStartup.Location = new System.Drawing.Point(0, 2);
            this.showTipsOnStartup.Name = "showTipsOnStartup";
            this.showTipsOnStartup.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.showTipsOnStartup.Size = new System.Drawing.Size(133, 22);
            this.showTipsOnStartup.TabIndex = 0;
            this.showTipsOnStartup.Text = "Show On Startup";
            this.showTipsOnStartup.UseVisualStyleBackColor = true;
            // 
            // headingPanel
            // 
            this.headingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(103)))), ((int)(((byte)(129)))));
            this.headingPanel.Controls.Add(this.heading);
            this.headingPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headingPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.headingPanel.Location = new System.Drawing.Point(3, 2);
            this.headingPanel.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.headingPanel.Name = "headingPanel";
            this.headingPanel.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.headingPanel.Size = new System.Drawing.Size(408, 31);
            this.headingPanel.TabIndex = 4;
            // 
            // heading
            // 
            this.heading.AutoSize = true;
            this.heading.BackColor = System.Drawing.Color.Transparent;
            this.heading.Dock = System.Windows.Forms.DockStyle.Left;
            this.heading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.heading.Font = new System.Drawing.Font("Optus Voice BETA Bold", 18F, System.Drawing.FontStyle.Bold);
            this.heading.Location = new System.Drawing.Point(0, 0);
            this.heading.Margin = new System.Windows.Forms.Padding(0);
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(229, 29);
            this.heading.TabIndex = 0;
            this.heading.Text = "Smart Copy - Win+C";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(83)))), ((int)(((byte)(109)))));
            this.menuStrip1.Font = new System.Drawing.Font("Gautami", 8F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem1,
            this.toolStripTextBox1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(414, 16);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuPaintGrayBorder);
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this._MainMenu_MouseDown);
            // 
            // quitToolStripMenuItem1
            // 
            this.quitToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.quitToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.quitToolStripMenuItem1.Image = global::CallTracker.Properties.Resources.Close;
            this.quitToolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.quitToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.quitToolStripMenuItem1.Margin = new System.Windows.Forms.Padding(0, -1, 0, 0);
            this.quitToolStripMenuItem1.Name = "quitToolStripMenuItem1";
            this.quitToolStripMenuItem1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.quitToolStripMenuItem1.Size = new System.Drawing.Size(18, 15);
            this.quitToolStripMenuItem1.Click += new System.EventHandler(this.ok_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(83)))), ((int)(((byte)(109)))));
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox1.CausesValidation = false;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Verdana", 7.25F);
            this.toolStripTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.toolStripTextBox1.Margin = new System.Windows.Forms.Padding(0, -2, 0, 0);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.ShortcutsEnabled = false;
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 16);
            this.toolStripTextBox1.Text = "Tips";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // DidYouKnow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(143)))), ((int)(((byte)(169)))));
            this.BackgroundImage = global::CallTracker.Properties.Resources.blue_gradient_300;
            this.ClientSize = new System.Drawing.Size(414, 238);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DidYouKnow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Did You Know?";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DidYouKnow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrayBorder);
            this.panel1.ResumeLayout(false);
            this.examplePanel.ResumeLayout(false);
            this.exampleTextPanel.ResumeLayout(false);
            this.exampleHeadingPanel.ResumeLayout(false);
            this.exampleHeadingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._CloseExample)).EndInit();
            this.tipsPanel.ResumeLayout(false);
            this.tipsTextPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.headingPanel.ResumeLayout(false);
            this.headingPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox showTipsOnStartup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label heading;
        private System.Windows.Forms.Panel headingPanel;
        private System.Windows.Forms.Panel tipsTextPanel;
        private RichTextBoxEx richTextBox1;
        private System.Windows.Forms.Panel panel4;
        private ToolStripMenuIgnoreFocus menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem1;
        private System.Windows.Forms.Button prevTip;
        private System.Windows.Forms.Button nextTip;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.Panel examplePanel;
        private System.Windows.Forms.Panel exampleHeadingPanel;
        private System.Windows.Forms.Label exampleHeading;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel exampleTextPanel;
        private System.Windows.Forms.RichTextBox exampleRichTextBox;
        private System.Windows.Forms.Panel tipsPanel;
        private System.Windows.Forms.PictureBox _CloseExample;
    }
}