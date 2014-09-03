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
            this.panel3 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.featureHeading = new System.Windows.Forms.Label();
            this.info1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.showTipsOnStartup = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new CallTracker.View.ToolStripMenuIgnoreFocus();
            this.quitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tips = new System.Windows.Forms.Label();
            this.tipsPanel = new System.Windows.Forms.Panel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tipsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.panel1.Size = new System.Drawing.Size(414, 222);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(143)))), ((int)(((byte)(169)))));
            this.panel3.Controls.Add(this.richTextBox1);
            this.panel3.Controls.Add(this.tipsPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.panel3.Location = new System.Drawing.Point(3, 46);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.panel3.Size = new System.Drawing.Size(408, 147);
            this.panel3.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(103)))), ((int)(((byte)(129)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(162)))));
            this.richTextBox1.Location = new System.Drawing.Point(0, 15);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(408, 130);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "- Can recognize data in multiple formats. eg CMBS 31-123456-7, 31123456 7, 311234" +
    "5607, 1123456076.";
            this.richTextBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(103)))), ((int)(((byte)(129)))));
            this.panel2.Controls.Add(this.featureHeading);
            this.panel2.Controls.Add(this.info1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.panel2.Size = new System.Drawing.Size(408, 44);
            this.panel2.TabIndex = 4;
            // 
            // featureHeading
            // 
            this.featureHeading.AutoSize = true;
            this.featureHeading.BackColor = System.Drawing.Color.Transparent;
            this.featureHeading.Dock = System.Windows.Forms.DockStyle.Left;
            this.featureHeading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.featureHeading.Font = new System.Drawing.Font("Optus Voice BETA Bold", 18F, System.Drawing.FontStyle.Bold);
            this.featureHeading.Location = new System.Drawing.Point(0, 0);
            this.featureHeading.Margin = new System.Windows.Forms.Padding(0);
            this.featureHeading.Name = "featureHeading";
            this.featureHeading.Size = new System.Drawing.Size(229, 29);
            this.featureHeading.TabIndex = 0;
            this.featureHeading.Text = "Smart Copy - Win+C";
            // 
            // info1
            // 
            this.info1.BackColor = System.Drawing.Color.Transparent;
            this.info1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.info1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.info1.Font = new System.Drawing.Font("Gautami", 8F);
            this.info1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(162)))));
            this.info1.Location = new System.Drawing.Point(0, 25);
            this.info1.Margin = new System.Windows.Forms.Padding(0);
            this.info1.Name = "info1";
            this.info1.Size = new System.Drawing.Size(406, 17);
            this.info1.TabIndex = 1;
            this.info1.Text = "Analyzes the selected text and copies it in to the appropriate field.";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(103)))), ((int)(((byte)(129)))));
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.showTipsOnStartup);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 193);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel4.Size = new System.Drawing.Size(408, 26);
            this.panel4.TabIndex = 6;
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
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(83)))), ((int)(((byte)(109)))));
            this.menuStrip1.Font = new System.Drawing.Font("Gautami", 8F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem1,
            this.toolStripTextBox1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
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
            this.quitToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.quitToolStripMenuItem1.Margin = new System.Windows.Forms.Padding(0, -1, 0, 0);
            this.quitToolStripMenuItem1.Name = "quitToolStripMenuItem1";
            this.quitToolStripMenuItem1.Size = new System.Drawing.Size(22, 15);
            this.quitToolStripMenuItem1.Click += new System.EventHandler(this.ok_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(83)))), ((int)(((byte)(109)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(341, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "Next Tip";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ok_MouseUp);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(83)))), ((int)(((byte)(109)))));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(275, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 22);
            this.button2.TabIndex = 4;
            this.button2.Text = "Prev Tip";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ok_MouseUp);
            // 
            // tips
            // 
            this.tips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(119)))));
            this.tips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tips.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tips.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Bold);
            this.tips.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.tips.Location = new System.Drawing.Point(0, 2);
            this.tips.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.tips.Name = "tips";
            this.tips.Size = new System.Drawing.Size(408, 13);
            this.tips.TabIndex = 2;
            this.tips.Text = "Tips:";
            // 
            // tipsPanel
            // 
            this.tipsPanel.BackColor = System.Drawing.Color.Transparent;
            this.tipsPanel.Controls.Add(this.tips);
            this.tipsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tipsPanel.Location = new System.Drawing.Point(0, 0);
            this.tipsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tipsPanel.Name = "tipsPanel";
            this.tipsPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tipsPanel.Size = new System.Drawing.Size(408, 15);
            this.tipsPanel.TabIndex = 5;
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(83)))), ((int)(((byte)(109)))));
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox1.CausesValidation = false;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Verdana", 7.25F, System.Drawing.FontStyle.Bold);
            this.toolStripTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.toolStripTextBox1.Margin = new System.Windows.Forms.Padding(0, -2, 0, 0);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.ShortcutsEnabled = false;
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 16);
            this.toolStripTextBox1.Text = "Did You Know";
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
            this.DoubleBuffered = true;
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
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tipsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox showTipsOnStartup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label info1;
        private System.Windows.Forms.Label featureHeading;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel4;
        private ToolStripMenuIgnoreFocus menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label tips;
        private System.Windows.Forms.Panel tipsPanel;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}