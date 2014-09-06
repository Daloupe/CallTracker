namespace AutomationTester
{
    partial class Form1
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
            this._log = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.applicationsClear = new System.Windows.Forms.Button();
            this.applicationsGet = new System.Windows.Forms.Button();
            this.applicationsString = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.applicationsSearchBy = new System.Windows.Forms.ComboBox();
            this.applicationsCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.windowsClear = new System.Windows.Forms.Button();
            this.windowsGet = new System.Windows.Forms.Button();
            this.windowsString = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.windowsSearchBy = new System.Windows.Forms.ComboBox();
            this.windowsCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listDesktopWindows = new System.Windows.Forms.Button();
            this.listModalWindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.listApplicationWindows = new System.Windows.Forms.Button();
            this.applicationName = new System.Windows.Forms.TextBox();
            this.applicationTitle = new System.Windows.Forms.TextBox();
            this.listMdiChildButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.controlTypeCombo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.controlName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.listExeWindowsButton = new System.Windows.Forms.Button();
            this.listWindowControlsButton = new System.Windows.Forms.Button();
            this.getWindowControlButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _log
            // 
            this._log.AcceptsTab = true;
            this._log.Location = new System.Drawing.Point(-2, 213);
            this._log.Name = "_log";
            this._log.ReadOnly = true;
            this._log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this._log.Size = new System.Drawing.Size(515, 86);
            this._log.TabIndex = 0;
            this._log.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.applicationsClear);
            this.panel1.Controls.Add(this.applicationsGet);
            this.panel1.Controls.Add(this.applicationsString);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.applicationsSearchBy);
            this.panel1.Controls.Add(this.applicationsCombo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 45);
            this.panel1.TabIndex = 1;
            // 
            // applicationsClear
            // 
            this.applicationsClear.Location = new System.Drawing.Point(441, 16);
            this.applicationsClear.Name = "applicationsClear";
            this.applicationsClear.Size = new System.Drawing.Size(53, 20);
            this.applicationsClear.TabIndex = 7;
            this.applicationsClear.Text = "Clear";
            this.applicationsClear.UseVisualStyleBackColor = true;
            this.applicationsClear.Click += new System.EventHandler(this.applicationsClear_Click);
            // 
            // applicationsGet
            // 
            this.applicationsGet.Location = new System.Drawing.Point(381, 16);
            this.applicationsGet.Name = "applicationsGet";
            this.applicationsGet.Size = new System.Drawing.Size(53, 20);
            this.applicationsGet.TabIndex = 6;
            this.applicationsGet.Text = "Get";
            this.applicationsGet.UseVisualStyleBackColor = true;
            this.applicationsGet.Click += new System.EventHandler(this.applicationsGet_Click);
            // 
            // applicationsString
            // 
            this.applicationsString.Location = new System.Drawing.Point(258, 16);
            this.applicationsString.Name = "applicationsString";
            this.applicationsString.Size = new System.Drawing.Size(117, 20);
            this.applicationsString.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Search String";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search By";
            // 
            // applicationsSearchBy
            // 
            this.applicationsSearchBy.FormattingEnabled = true;
            this.applicationsSearchBy.Items.AddRange(new object[] {
            "Process Name",
            "Process Id",
            "Exe Name"});
            this.applicationsSearchBy.Location = new System.Drawing.Point(130, 16);
            this.applicationsSearchBy.Name = "applicationsSearchBy";
            this.applicationsSearchBy.Size = new System.Drawing.Size(121, 21);
            this.applicationsSearchBy.TabIndex = 2;
            // 
            // applicationsCombo
            // 
            this.applicationsCombo.FormattingEnabled = true;
            this.applicationsCombo.Location = new System.Drawing.Point(3, 16);
            this.applicationsCombo.Name = "applicationsCombo";
            this.applicationsCombo.Size = new System.Drawing.Size(121, 21);
            this.applicationsCombo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Applications";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-2, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(515, 108);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.windowsClear);
            this.panel2.Controls.Add(this.windowsGet);
            this.panel2.Controls.Add(this.windowsString);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.windowsSearchBy);
            this.panel2.Controls.Add(this.windowsCombo);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(3, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 45);
            this.panel2.TabIndex = 9;
            // 
            // windowsClear
            // 
            this.windowsClear.Location = new System.Drawing.Point(441, 16);
            this.windowsClear.Name = "windowsClear";
            this.windowsClear.Size = new System.Drawing.Size(53, 20);
            this.windowsClear.TabIndex = 7;
            this.windowsClear.Text = "Clear";
            this.windowsClear.UseVisualStyleBackColor = true;
            this.windowsClear.Click += new System.EventHandler(this.windowsClear_Click);
            // 
            // windowsGet
            // 
            this.windowsGet.Location = new System.Drawing.Point(381, 16);
            this.windowsGet.Name = "windowsGet";
            this.windowsGet.Size = new System.Drawing.Size(53, 20);
            this.windowsGet.TabIndex = 6;
            this.windowsGet.Text = "Get";
            this.windowsGet.UseVisualStyleBackColor = true;
            this.windowsGet.Click += new System.EventHandler(this.windowsGet_Click);
            // 
            // windowsString
            // 
            this.windowsString.Location = new System.Drawing.Point(258, 16);
            this.windowsString.Name = "windowsString";
            this.windowsString.Size = new System.Drawing.Size(117, 20);
            this.windowsString.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Search String";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Search By";
            // 
            // windowsSearchBy
            // 
            this.windowsSearchBy.FormattingEnabled = true;
            this.windowsSearchBy.Items.AddRange(new object[] {
            "Application",
            "Automation Id",
            "Name",
            "Title"});
            this.windowsSearchBy.Location = new System.Drawing.Point(130, 16);
            this.windowsSearchBy.Name = "windowsSearchBy";
            this.windowsSearchBy.Size = new System.Drawing.Size(121, 21);
            this.windowsSearchBy.TabIndex = 2;
            // 
            // windowsCombo
            // 
            this.windowsCombo.FormattingEnabled = true;
            this.windowsCombo.Location = new System.Drawing.Point(3, 16);
            this.windowsCombo.Name = "windowsCombo";
            this.windowsCombo.Size = new System.Drawing.Size(121, 21);
            this.windowsCombo.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Windows";
            // 
            // listDesktopWindows
            // 
            this.listDesktopWindows.Location = new System.Drawing.Point(242, 111);
            this.listDesktopWindows.Name = "listDesktopWindows";
            this.listDesktopWindows.Size = new System.Drawing.Size(81, 34);
            this.listDesktopWindows.TabIndex = 11;
            this.listDesktopWindows.Text = "List Desktop Windows";
            this.listDesktopWindows.UseVisualStyleBackColor = true;
            this.listDesktopWindows.Click += new System.EventHandler(this.listDesktopWindows_Click);
            // 
            // listModalWindowsCheckBox
            // 
            this.listModalWindowsCheckBox.AutoSize = true;
            this.listModalWindowsCheckBox.Location = new System.Drawing.Point(98, 190);
            this.listModalWindowsCheckBox.Name = "listModalWindowsCheckBox";
            this.listModalWindowsCheckBox.Size = new System.Drawing.Size(121, 17);
            this.listModalWindowsCheckBox.TabIndex = 12;
            this.listModalWindowsCheckBox.Text = "List Modal Windows";
            this.listModalWindowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // listApplicationWindows
            // 
            this.listApplicationWindows.Location = new System.Drawing.Point(325, 111);
            this.listApplicationWindows.Name = "listApplicationWindows";
            this.listApplicationWindows.Size = new System.Drawing.Size(91, 34);
            this.listApplicationWindows.TabIndex = 13;
            this.listApplicationWindows.Text = "List Application Windows";
            this.listApplicationWindows.UseVisualStyleBackColor = true;
            this.listApplicationWindows.Click += new System.EventHandler(this.listApplicationWindows_Click);
            // 
            // applicationName
            // 
            this.applicationName.Location = new System.Drawing.Point(-2, 126);
            this.applicationName.Name = "applicationName";
            this.applicationName.Size = new System.Drawing.Size(94, 20);
            this.applicationName.TabIndex = 14;
            // 
            // applicationTitle
            // 
            this.applicationTitle.Location = new System.Drawing.Point(98, 125);
            this.applicationTitle.Name = "applicationTitle";
            this.applicationTitle.Size = new System.Drawing.Size(138, 20);
            this.applicationTitle.TabIndex = 15;
            this.applicationTitle.Text = "StatisticsForm";
            // 
            // listMdiChildButton
            // 
            this.listMdiChildButton.Location = new System.Drawing.Point(242, 149);
            this.listMdiChildButton.Name = "listMdiChildButton";
            this.listMdiChildButton.Size = new System.Drawing.Size(62, 34);
            this.listMdiChildButton.TabIndex = 16;
            this.listMdiChildButton.Text = "List MDI Child";
            this.listMdiChildButton.UseVisualStyleBackColor = true;
            this.listMdiChildButton.Click += new System.EventHandler(this.listMdiChildButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-2, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Application Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(95, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Application Title/Exe";
            // 
            // controlTypeCombo
            // 
            this.controlTypeCombo.FormattingEnabled = true;
            this.controlTypeCombo.Items.AddRange(new object[] {
            "Application",
            "Automation Id",
            "Name",
            "Title"});
            this.controlTypeCombo.Location = new System.Drawing.Point(98, 163);
            this.controlTypeCombo.Name = "controlTypeCombo";
            this.controlTypeCombo.Size = new System.Drawing.Size(138, 21);
            this.controlTypeCombo.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(95, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Control Type";
            // 
            // controlName
            // 
            this.controlName.Location = new System.Drawing.Point(-2, 164);
            this.controlName.Name = "controlName";
            this.controlName.Size = new System.Drawing.Size(94, 20);
            this.controlName.TabIndex = 15;
            this.controlName.Text = "Search:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(-2, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Control Name";
            // 
            // listExeWindowsButton
            // 
            this.listExeWindowsButton.Location = new System.Drawing.Point(422, 111);
            this.listExeWindowsButton.Name = "listExeWindowsButton";
            this.listExeWindowsButton.Size = new System.Drawing.Size(91, 34);
            this.listExeWindowsButton.TabIndex = 21;
            this.listExeWindowsButton.Text = "List Exe Windows";
            this.listExeWindowsButton.UseVisualStyleBackColor = true;
            this.listExeWindowsButton.Click += new System.EventHandler(this.listExeWindowsButton_Click);
            // 
            // listWindowControlsButton
            // 
            this.listWindowControlsButton.Location = new System.Drawing.Point(310, 149);
            this.listWindowControlsButton.Name = "listWindowControlsButton";
            this.listWindowControlsButton.Size = new System.Drawing.Size(81, 34);
            this.listWindowControlsButton.TabIndex = 22;
            this.listWindowControlsButton.Text = "List Window Controls";
            this.listWindowControlsButton.UseVisualStyleBackColor = true;
            this.listWindowControlsButton.Click += new System.EventHandler(this.listWindowControlsButton_Click);
            // 
            // getWindowControlButton
            // 
            this.getWindowControlButton.Location = new System.Drawing.Point(397, 149);
            this.getWindowControlButton.Name = "getWindowControlButton";
            this.getWindowControlButton.Size = new System.Drawing.Size(81, 34);
            this.getWindowControlButton.TabIndex = 23;
            this.getWindowControlButton.Text = "Get Window Control";
            this.getWindowControlButton.UseVisualStyleBackColor = true;
            this.getWindowControlButton.Click += new System.EventHandler(this.getWindowControlButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 301);
            this.Controls.Add(this.getWindowControlButton);
            this.Controls.Add(this.listWindowControlsButton);
            this.Controls.Add(this.listExeWindowsButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.controlTypeCombo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listMdiChildButton);
            this.Controls.Add(this.controlName);
            this.Controls.Add(this.applicationTitle);
            this.Controls.Add(this.applicationName);
            this.Controls.Add(this.listApplicationWindows);
            this.Controls.Add(this.listModalWindowsCheckBox);
            this.Controls.Add(this.listDesktopWindows);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this._log);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox _log;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button applicationsClear;
        private System.Windows.Forms.Button applicationsGet;
        private System.Windows.Forms.TextBox applicationsString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox applicationsSearchBy;
        private System.Windows.Forms.ComboBox applicationsCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button windowsClear;
        private System.Windows.Forms.Button windowsGet;
        private System.Windows.Forms.TextBox windowsString;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox windowsSearchBy;
        private System.Windows.Forms.ComboBox windowsCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button listDesktopWindows;
        private System.Windows.Forms.CheckBox listModalWindowsCheckBox;
        private System.Windows.Forms.Button listApplicationWindows;
        private System.Windows.Forms.TextBox applicationName;
        private System.Windows.Forms.TextBox applicationTitle;
        private System.Windows.Forms.Button listMdiChildButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox controlTypeCombo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox controlName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button listExeWindowsButton;
        private System.Windows.Forms.Button listWindowControlsButton;
        private System.Windows.Forms.Button getWindowControlButton;
    }
}

