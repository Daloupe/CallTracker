namespace CallTracker.View
{
    partial class Main
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
            this._MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.callHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginsViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridLinksViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteBindsViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewKeyCommandsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripServiceSelector = new System.Windows.Forms.ToolStripComboBox();
            this.transfersToolStripMenuItem = new ContextualToolStripMenuItem();
            this.CustCareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RetentionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dispatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearanceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.linksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customerCareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.retentionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearanceCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppPanel = new System.Windows.Forms.Panel();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.ratecodesToolStripMenuItem = new ContextualToolStripMenuItem();
            this.LATRatecodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LatRatecodeSearch = new System.Windows.Forms.ToolStripTextBox();
            this.oNCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dTVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._MainMenu.SuspendLayout();
            this.AppPanel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _MainMenu
            // 
            this._MainMenu.AutoSize = false;
            this._MainMenu.BackColor = System.Drawing.Color.LightGray;
            this._MainMenu.Font = new System.Drawing.Font("Verdana", 7F);
            this._MainMenu.GripMargin = new System.Windows.Forms.Padding(0);
            this._MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this._MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.quitToolStripMenuItem1,
            this.helpToolStripMenuItem,
            this.resourcesToolStripMenuItem,
            this.contextMenuToolStripMenuItem});
            this._MainMenu.Location = new System.Drawing.Point(0, 0);
            this._MainMenu.Name = "_MainMenu";
            this._MainMenu.Padding = new System.Windows.Forms.Padding(0);
            this._MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._MainMenu.Size = new System.Drawing.Size(584, 17);
            this._MainMenu.TabIndex = 2;
            this._MainMenu.Text = "_MainMenu";
            this._MainMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrayBorder);
            this._MainMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this._MainMenu_MouseDown);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.callHistoryToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(79, 17);
            this.fileToolStripMenuItem.Text = "Call Tracker";
            // 
            // callHistoryToolStripMenuItem
            // 
            this.callHistoryToolStripMenuItem.Name = "callHistoryToolStripMenuItem";
            this.callHistoryToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.callHistoryToolStripMenuItem.Text = "Call History";
            this.callHistoryToolStripMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginsViewMenuItem,
            this.gridLinksViewMenuItem,
            this.advancedToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.viewToolStripMenuItem.Text = "Settings";
            // 
            // loginsViewMenuItem
            // 
            this.loginsViewMenuItem.Name = "loginsViewMenuItem";
            this.loginsViewMenuItem.Size = new System.Drawing.Size(121, 22);
            this.loginsViewMenuItem.Text = "Logins";
            this.loginsViewMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // gridLinksViewMenuItem
            // 
            this.gridLinksViewMenuItem.Name = "gridLinksViewMenuItem";
            this.gridLinksViewMenuItem.Size = new System.Drawing.Size(121, 22);
            this.gridLinksViewMenuItem.Text = "Grid Links";
            this.gridLinksViewMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteBindsViewMenuItem,
            this.databaseEditorToolStripMenuItem});
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.advancedToolStripMenuItem.Text = "Advanced";
            // 
            // pasteBindsViewMenuItem
            // 
            this.pasteBindsViewMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pasteBindsViewMenuItem.Name = "pasteBindsViewMenuItem";
            this.pasteBindsViewMenuItem.Size = new System.Drawing.Size(163, 22);
            this.pasteBindsViewMenuItem.Text = "Smart Paste Binds";
            this.pasteBindsViewMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // databaseEditorToolStripMenuItem
            // 
            this.databaseEditorToolStripMenuItem.Name = "databaseEditorToolStripMenuItem";
            this.databaseEditorToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.databaseEditorToolStripMenuItem.Text = "Database Editor";
            this.databaseEditorToolStripMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(127, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem1
            // 
            this.quitToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.quitToolStripMenuItem1.Image = global::CallTracker.Properties.Resources.Close;
            this.quitToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.quitToolStripMenuItem1.Name = "quitToolStripMenuItem1";
            this.quitToolStripMenuItem1.Size = new System.Drawing.Size(22, 17);
            this.quitToolStripMenuItem1.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewKeyCommandsMenuItem,
            this.versionStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(42, 17);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewKeyCommandsMenuItem
            // 
            this.viewKeyCommandsMenuItem.Name = "viewKeyCommandsMenuItem";
            this.viewKeyCommandsMenuItem.Size = new System.Drawing.Size(158, 22);
            this.viewKeyCommandsMenuItem.Text = "Key Commands";
            this.viewKeyCommandsMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // versionStripMenuItem
            // 
            this.versionStripMenuItem.Enabled = false;
            this.versionStripMenuItem.Name = "versionStripMenuItem";
            this.versionStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.versionStripMenuItem.Text = "Version 0.0.0";
            // 
            // resourcesToolStripMenuItem
            // 
            this.resourcesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripServiceSelector,
            this.transfersToolStripMenuItem,
            this.ratecodesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripSeparator3,
            this.linksToolStripMenuItem});
            this.resourcesToolStripMenuItem.Name = "resourcesToolStripMenuItem";
            this.resourcesToolStripMenuItem.Size = new System.Drawing.Size(74, 17);
            this.resourcesToolStripMenuItem.Text = "Resources";
            // 
            // toolStripServiceSelector
            // 
            this.toolStripServiceSelector.BackColor = System.Drawing.Color.LightGray;
            this.toolStripServiceSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripServiceSelector.Font = new System.Drawing.Font("Verdana", 7F);
            this.toolStripServiceSelector.Name = "toolStripServiceSelector";
            this.toolStripServiceSelector.Size = new System.Drawing.Size(121, 20);
            this.toolStripServiceSelector.SelectedIndexChanged += new System.EventHandler(this.toolStripServiceSelector_SelectedIndexChanged);
            // 
            // transfersToolStripMenuItem
            // 
            this.transfersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustCareToolStripMenuItem,
            this.FaultsToolStripMenuItem,
            this.SalesToolStripMenuItem,
            this.FSToolStripMenuItem,
            this.RetentionToolStripMenuItem,
            this.toolStripSeparator1,
            this.dispatchToolStripMenuItem,
            this.nIMToolStripMenuItem});
            this.transfersToolStripMenuItem.Name = "transfersToolStripMenuItem";
            this.transfersToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.transfersToolStripMenuItem.Text = "Numbers To Know";
            this.transfersToolStripMenuItem.UpdateObject = null;
            this.transfersToolStripMenuItem.DropDownOpening += new System.EventHandler(this.resourcesToolStripMenuItem_DropDownOpening);
            // 
            // CustCareToolStripMenuItem
            // 
            this.CustCareToolStripMenuItem.Name = "CustCareToolStripMenuItem";
            this.CustCareToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.CustCareToolStripMenuItem.Text = "Cust Care";
            this.CustCareToolStripMenuItem.Click += new System.EventHandler(this.transfer_Click);
            // 
            // FaultsToolStripMenuItem
            // 
            this.FaultsToolStripMenuItem.Name = "FaultsToolStripMenuItem";
            this.FaultsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.FaultsToolStripMenuItem.Text = "Tech Support";
            this.FaultsToolStripMenuItem.Click += new System.EventHandler(this.transfer_Click);
            // 
            // SalesToolStripMenuItem
            // 
            this.SalesToolStripMenuItem.Name = "SalesToolStripMenuItem";
            this.SalesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.SalesToolStripMenuItem.Text = "Sales";
            this.SalesToolStripMenuItem.Click += new System.EventHandler(this.transfer_Click);
            // 
            // FSToolStripMenuItem
            // 
            this.FSToolStripMenuItem.Name = "FSToolStripMenuItem";
            this.FSToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.FSToolStripMenuItem.Text = "Financial Services";
            this.FSToolStripMenuItem.Click += new System.EventHandler(this.transfer_Click);
            // 
            // RetentionToolStripMenuItem
            // 
            this.RetentionToolStripMenuItem.Name = "RetentionToolStripMenuItem";
            this.RetentionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.RetentionToolStripMenuItem.Text = "Retention";
            this.RetentionToolStripMenuItem.Click += new System.EventHandler(this.transfer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // dispatchToolStripMenuItem
            // 
            this.dispatchToolStripMenuItem.Name = "dispatchToolStripMenuItem";
            this.dispatchToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.dispatchToolStripMenuItem.Text = "Dispatch";
            this.dispatchToolStripMenuItem.Click += new System.EventHandler(this.transfer_Click);
            // 
            // nIMToolStripMenuItem
            // 
            this.nIMToolStripMenuItem.Name = "nIMToolStripMenuItem";
            this.nIMToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.nIMToolStripMenuItem.Text = "NIM";
            this.nIMToolStripMenuItem.Click += new System.EventHandler(this.transfer_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearanceCodeToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem2.Text = "Bookmarks";
            // 
            // clearanceCodeToolStripMenuItem
            // 
            this.clearanceCodeToolStripMenuItem.Name = "clearanceCodeToolStripMenuItem";
            this.clearanceCodeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.clearanceCodeToolStripMenuItem.Text = "Clearance Codes";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // linksToolStripMenuItem
            // 
            this.linksToolStripMenuItem.Name = "linksToolStripMenuItem";
            this.linksToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.linksToolStripMenuItem.Text = "Links";
            // 
            // contextMenuToolStripMenuItem
            // 
            this.contextMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.clearanceCodesToolStripMenuItem});
            this.contextMenuToolStripMenuItem.Name = "contextMenuToolStripMenuItem";
            this.contextMenuToolStripMenuItem.Size = new System.Drawing.Size(95, 17);
            this.contextMenuToolStripMenuItem.Text = "Context Menu";
            this.contextMenuToolStripMenuItem.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerCareToolStripMenuItem,
            this.salesToolStripMenuItem1,
            this.retentionToolStripMenuItem1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem1.Text = "Transfer";
            // 
            // customerCareToolStripMenuItem
            // 
            this.customerCareToolStripMenuItem.Name = "customerCareToolStripMenuItem";
            this.customerCareToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.customerCareToolStripMenuItem.Text = "Customer Care";
            // 
            // salesToolStripMenuItem1
            // 
            this.salesToolStripMenuItem1.Name = "salesToolStripMenuItem1";
            this.salesToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.salesToolStripMenuItem1.Text = "Sales";
            // 
            // retentionToolStripMenuItem1
            // 
            this.retentionToolStripMenuItem1.Name = "retentionToolStripMenuItem1";
            this.retentionToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.retentionToolStripMenuItem1.Text = "Retention";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DoubleClickEnabled = true;
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem3.Text = "Ratecodes";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.AutoToolTip = true;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox2.ToolTipText = "Ratecode Search";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem4.Text = "Links";
            // 
            // clearanceCodesToolStripMenuItem
            // 
            this.clearanceCodesToolStripMenuItem.Name = "clearanceCodesToolStripMenuItem";
            this.clearanceCodesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.clearanceCodesToolStripMenuItem.Text = "Clearance Codes";
            // 
            // AppPanel
            // 
            this.AppPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AppPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppPanel.Controls.Add(this.MenuPanel);
            this.AppPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppPanel.Location = new System.Drawing.Point(0, 0);
            this.AppPanel.Name = "AppPanel";
            this.AppPanel.Size = new System.Drawing.Size(586, 242);
            this.AppPanel.TabIndex = 25;
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this._MainMenu);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuPanel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(584, 17);
            this.MenuPanel.TabIndex = 27;
            this.MenuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrayBorder);
            // 
            // ratecodesToolStripMenuItem
            // 
            this.ratecodesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LATRatecodeMenuItem,
            this.oNCToolStripMenuItem1,
            this.dTVToolStripMenuItem1});
            this.ratecodesToolStripMenuItem.Name = "ratecodesToolStripMenuItem";
            this.ratecodesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ratecodesToolStripMenuItem.Text = "Ratecodes";
            this.ratecodesToolStripMenuItem.UpdateObject = null;
            // 
            // LATRatecodeMenuItem
            // 
            this.LATRatecodeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LatRatecodeSearch});
            this.LATRatecodeMenuItem.Name = "LATRatecodeMenuItem";
            this.LATRatecodeMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LATRatecodeMenuItem.Text = "LAT/LIP";
            this.LATRatecodeMenuItem.CheckedChanged += new System.EventHandler(this.LATRatecodeMenuItem_CheckedChanged);
            this.LATRatecodeMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // LatRatecodeSearch
            // 
            this.LatRatecodeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.LatRatecodeSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.LatRatecodeSearch.AutoSize = false;
            this.LatRatecodeSearch.AutoToolTip = true;
            this.LatRatecodeSearch.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.LatRatecodeSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.LatRatecodeSearch.Font = new System.Drawing.Font("Verdana", 7F);
            this.LatRatecodeSearch.HideSelection = false;
            this.LatRatecodeSearch.MaxLength = 5;
            this.LatRatecodeSearch.Name = "LatRatecodeSearch";
            this.LatRatecodeSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LatRatecodeSearch.Size = new System.Drawing.Size(100, 19);
            this.LatRatecodeSearch.ToolTipText = "Ratecode Search";
            // 
            // oNCToolStripMenuItem1
            // 
            this.oNCToolStripMenuItem1.Name = "oNCToolStripMenuItem1";
            this.oNCToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.oNCToolStripMenuItem1.Text = "ONC";
            // 
            // dTVToolStripMenuItem1
            // 
            this.dTVToolStripMenuItem1.Name = "dTVToolStripMenuItem1";
            this.dTVToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.dTVToolStripMenuItem1.Text = "DTV";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(586, 242);
            this.ControlBox = false;
            this.Controls.Add(this.AppPanel);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this._MainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Call Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this._MainMenu.ResumeLayout(false);
            this._MainMenu.PerformLayout();
            this.AppPanel.ResumeLayout(false);
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.BindingSource customerContactBindingSource;
        private System.Windows.Forms.MenuStrip _MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewKeyCommandsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem1;
        private System.Windows.Forms.Panel AppPanel;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.ToolStripMenuItem resourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contextMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginsViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridLinksViewMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customerCareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem retentionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripComboBox toolStripServiceSelector;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem clearanceCodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteBindsViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearanceCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem callHistoryToolStripMenuItem;
        private ContextualToolStripMenuItem transfersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CustCareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FaultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RetentionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem dispatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nIMToolStripMenuItem;
        private ContextualToolStripMenuItem ratecodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LATRatecodeMenuItem;
        private System.Windows.Forms.ToolStripTextBox LatRatecodeSearch;
        private System.Windows.Forms.ToolStripMenuItem oNCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dTVToolStripMenuItem1;
    }
}