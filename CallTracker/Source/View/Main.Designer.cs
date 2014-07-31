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
            this.components = new System.ComponentModel.Container();
            this.AppPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._StatusContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.clearMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._StatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this._MainMenu = new CallTracker.View.ToolStripMenuIgnoreFocus();
            this.quitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewKeyCommandsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.callHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showStatusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginsViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridLinksViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteBindsViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ratecodesToolStripMenuItem = new ContextualToolStripMenuItem();
            this.LATRatecodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LatRatecodeSearch = new System.Windows.Forms.ToolStripTextBox();
            this.oNCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dTVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearanceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.linksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this._StatusContextMenu.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this._MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // AppPanel
            // 
            this.AppPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AppPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppPanel.Controls.Add(this.statusStrip1);
            this.AppPanel.Controls.Add(this.MenuPanel);
            this.AppPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppPanel.Location = new System.Drawing.Point(0, 0);
            this.AppPanel.Name = "AppPanel";
            this.AppPanel.Size = new System.Drawing.Size(584, 259);
            this.AppPanel.TabIndex = 25;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.LightGray;
            this.statusStrip1.ContextMenuStrip = this._StatusContextMenu;
            this.statusStrip1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._StatusLabel,
            this._StatusProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 237);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(582, 20);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 28;
            // 
            // _StatusContextMenu
            // 
            this._StatusContextMenu.Font = new System.Drawing.Font("Verdana", 7F);
            this._StatusContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lowToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.highToolStripMenuItem,
            this.toolStripSeparator4,
            this.clearMessagesToolStripMenuItem});
            this._StatusContextMenu.Name = "_StatusContextMenu";
            this._StatusContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this._StatusContextMenu.Size = new System.Drawing.Size(177, 98);
            this._StatusContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._StatusContextMenu_ItemClicked);
            // 
            // lowToolStripMenuItem
            // 
            this.lowToolStripMenuItem.Checked = true;
            this.lowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lowToolStripMenuItem.Name = "lowToolStripMenuItem";
            this.lowToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.lowToolStripMenuItem.Tag = "8";
            this.lowToolStripMenuItem.Text = "Low Warnings";
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.mediumToolStripMenuItem.Tag = "4";
            this.mediumToolStripMenuItem.Text = "Medium Warnings";
            // 
            // highToolStripMenuItem
            // 
            this.highToolStripMenuItem.Name = "highToolStripMenuItem";
            this.highToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.highToolStripMenuItem.Tag = "2";
            this.highToolStripMenuItem.Text = "High Warnings";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(173, 6);
            // 
            // clearMessagesToolStripMenuItem
            // 
            this.clearMessagesToolStripMenuItem.Checked = true;
            this.clearMessagesToolStripMenuItem.CheckOnClick = true;
            this.clearMessagesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clearMessagesToolStripMenuItem.Name = "clearMessagesToolStripMenuItem";
            this.clearMessagesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.clearMessagesToolStripMenuItem.Text = "Clear Last Warning";
            // 
            // _StatusLabel
            // 
            this._StatusLabel.AutoSize = false;
            this._StatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this._StatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this._StatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._StatusLabel.Name = "_StatusLabel";
            this._StatusLabel.Size = new System.Drawing.Size(521, 17);
            this._StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _StatusProgressBar
            // 
            this._StatusProgressBar.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this._StatusProgressBar.Name = "_StatusProgressBar";
            this._StatusProgressBar.Size = new System.Drawing.Size(60, 16);
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this._MainMenu);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuPanel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(582, 18);
            this.MenuPanel.TabIndex = 27;
            this.MenuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrayBorder);
            // 
            // _MainMenu
            // 
            this._MainMenu.AutoSize = false;
            this._MainMenu.BackColor = System.Drawing.Color.LightGray;
            this._MainMenu.Font = new System.Drawing.Font("Verdana", 7F);
            this._MainMenu.GripMargin = new System.Windows.Forms.Padding(0);
            this._MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem1,
            this.helpToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.resourcesToolStripMenuItem});
            this._MainMenu.Location = new System.Drawing.Point(0, 0);
            this._MainMenu.Name = "_MainMenu";
            this._MainMenu.Padding = new System.Windows.Forms.Padding(0);
            this._MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this._MainMenu.Size = new System.Drawing.Size(582, 18);
            this._MainMenu.TabIndex = 3;
            this._MainMenu.Text = "_MainMenu";
            this._MainMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this._MainMenu_MouseDown);
            // 
            // quitToolStripMenuItem1
            // 
            this.quitToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.quitToolStripMenuItem1.Image = global::CallTracker.Properties.Resources.Close;
            this.quitToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.quitToolStripMenuItem1.Name = "quitToolStripMenuItem1";
            this.quitToolStripMenuItem1.Size = new System.Drawing.Size(22, 18);
            this.quitToolStripMenuItem1.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewKeyCommandsMenuItem,
            this.versionStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(42, 18);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewKeyCommandsMenuItem
            // 
            this.viewKeyCommandsMenuItem.Name = "viewKeyCommandsMenuItem";
            this.viewKeyCommandsMenuItem.Size = new System.Drawing.Size(158, 22);
            this.viewKeyCommandsMenuItem.Text = "Key Commands";
            // 
            // versionStripMenuItem
            // 
            this.versionStripMenuItem.Enabled = false;
            this.versionStripMenuItem.Name = "versionStripMenuItem";
            this.versionStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.versionStripMenuItem.Text = "Version 0.0.0";
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(79, 18);
            this.fileToolStripMenuItem.Text = "Call Tracker";
            // 
            // callHistoryToolStripMenuItem
            // 
            this.callHistoryToolStripMenuItem.Name = "callHistoryToolStripMenuItem";
            this.callHistoryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.callHistoryToolStripMenuItem.Text = "Call History";
            this.callHistoryToolStripMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showStatusBarToolStripMenuItem,
            this.loginsViewMenuItem,
            this.gridLinksViewMenuItem,
            this.advancedToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewToolStripMenuItem.Text = "Settings";
            // 
            // showStatusBarToolStripMenuItem
            // 
            this.showStatusBarToolStripMenuItem.Checked = true;
            this.showStatusBarToolStripMenuItem.CheckOnClick = true;
            this.showStatusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showStatusBarToolStripMenuItem.Name = "showStatusBarToolStripMenuItem";
            this.showStatusBarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showStatusBarToolStripMenuItem.Text = "Show Status Bar";
            this.showStatusBarToolStripMenuItem.Click += new System.EventHandler(this.showStatusBarToolStripMenuItem_Click);
            // 
            // loginsViewMenuItem
            // 
            this.loginsViewMenuItem.Name = "loginsViewMenuItem";
            this.loginsViewMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loginsViewMenuItem.Text = "Edit Logins";
            this.loginsViewMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // gridLinksViewMenuItem
            // 
            this.gridLinksViewMenuItem.Name = "gridLinksViewMenuItem";
            this.gridLinksViewMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gridLinksViewMenuItem.Text = "Edit Grid Links";
            this.gridLinksViewMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteBindsViewMenuItem,
            this.databaseEditorToolStripMenuItem});
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.advancedToolStripMenuItem.Text = "Advanced";
            // 
            // pasteBindsViewMenuItem
            // 
            this.pasteBindsViewMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pasteBindsViewMenuItem.Name = "pasteBindsViewMenuItem";
            this.pasteBindsViewMenuItem.Size = new System.Drawing.Size(186, 22);
            this.pasteBindsViewMenuItem.Text = "Edit Smart Paste Binds";
            this.pasteBindsViewMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // databaseEditorToolStripMenuItem
            // 
            this.databaseEditorToolStripMenuItem.Name = "databaseEditorToolStripMenuItem";
            this.databaseEditorToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.databaseEditorToolStripMenuItem.Text = "Edit Database";
            this.databaseEditorToolStripMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
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
            this.resourcesToolStripMenuItem.ShowShortcutKeys = false;
            this.resourcesToolStripMenuItem.Size = new System.Drawing.Size(74, 18);
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
            this.LATRatecodeMenuItem.Size = new System.Drawing.Size(113, 22);
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
            this.oNCToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.oNCToolStripMenuItem1.Text = "ONC";
            // 
            // dTVToolStripMenuItem1
            // 
            this.dTVToolStripMenuItem1.Name = "dTVToolStripMenuItem1";
            this.dTVToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.dTVToolStripMenuItem1.Text = "DTV";
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(584, 259);
            this.ControlBox = false;
            this.Controls.Add(this.AppPanel);
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Call Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.AppPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this._StatusContextMenu.ResumeLayout(false);
            this.MenuPanel.ResumeLayout(false);
            this._MainMenu.ResumeLayout(false);
            this._MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.BindingSource customerContactBindingSource;
        private System.Windows.Forms.Panel AppPanel;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar _StatusProgressBar;
        private ToolStripMenuIgnoreFocus _MainMenu;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewKeyCommandsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem callHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginsViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridLinksViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteBindsViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripServiceSelector;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clearanceCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem linksToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip _StatusContextMenu;
        private System.Windows.Forms.ToolStripMenuItem lowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem clearMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showStatusBarToolStripMenuItem;
    }
}