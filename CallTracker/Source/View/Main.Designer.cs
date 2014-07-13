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
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginsViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridLinksViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteBindsViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.callHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewKeyCommandsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transfersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.custCareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lATLIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.nexusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dTVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dLSDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mobileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.techSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dSLDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mobileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retentionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dispatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ratecodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LATRatecodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LatRatecodeSearch = new System.Windows.Forms.ToolStripTextBox();
            this.oNCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dTVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.linksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppPanel = new System.Windows.Forms.Panel();
            this.MenuPanel = new System.Windows.Forms.Panel();
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
            this._MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.quitToolStripMenuItem1,
            this.helpToolStripMenuItem,
            this.contextMenuToolStripMenuItem,
            this.resourcesToolStripMenuItem});
            this._MainMenu.Location = new System.Drawing.Point(0, 0);
            this._MainMenu.Name = "_MainMenu";
            this._MainMenu.Padding = new System.Windows.Forms.Padding(0);
            this._MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._MainMenu.Size = new System.Drawing.Size(584, 18);
            this._MainMenu.TabIndex = 2;
            this._MainMenu.Text = "_MainMenu";
            this._MainMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrayBorder);
            this._MainMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this._MainMenu_MouseDown);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(79, 18);
            this.fileToolStripMenuItem.Text = "Call Tracker";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginsViewMenuItem,
            this.gridLinksViewMenuItem,
            this.pasteBindsViewMenuItem,
            this.callHistoryToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 18);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // loginsViewMenuItem
            // 
            this.loginsViewMenuItem.Name = "loginsViewMenuItem";
            this.loginsViewMenuItem.Size = new System.Drawing.Size(163, 22);
            this.loginsViewMenuItem.Text = "Logins";
            this.loginsViewMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // gridLinksViewMenuItem
            // 
            this.gridLinksViewMenuItem.Name = "gridLinksViewMenuItem";
            this.gridLinksViewMenuItem.Size = new System.Drawing.Size(163, 22);
            this.gridLinksViewMenuItem.Text = "Grid Link Binds";
            this.gridLinksViewMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // pasteBindsViewMenuItem
            // 
            this.pasteBindsViewMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pasteBindsViewMenuItem.Name = "pasteBindsViewMenuItem";
            this.pasteBindsViewMenuItem.Size = new System.Drawing.Size(163, 22);
            this.pasteBindsViewMenuItem.Text = "Smart Paste Binds";
            this.pasteBindsViewMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // callHistoryToolStripMenuItem
            // 
            this.callHistoryToolStripMenuItem.Name = "callHistoryToolStripMenuItem";
            this.callHistoryToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.callHistoryToolStripMenuItem.Text = "Call History";
            this.callHistoryToolStripMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
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
            this.viewKeyCommandsMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(42, 18);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewKeyCommandsMenuItem
            // 
            this.viewKeyCommandsMenuItem.Name = "viewKeyCommandsMenuItem";
            this.viewKeyCommandsMenuItem.Size = new System.Drawing.Size(158, 22);
            this.viewKeyCommandsMenuItem.Text = "Key Commands";
            this.viewKeyCommandsMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // resourcesToolStripMenuItem
            // 
            this.resourcesToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.resourcesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transfersToolStripMenuItem,
            this.ratecodesToolStripMenuItem,
            this.linksToolStripMenuItem});
            this.resourcesToolStripMenuItem.Name = "resourcesToolStripMenuItem";
            this.resourcesToolStripMenuItem.Size = new System.Drawing.Size(74, 18);
            this.resourcesToolStripMenuItem.Text = "Resources";
            // 
            // transfersToolStripMenuItem
            // 
            this.transfersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.custCareToolStripMenuItem,
            this.techSupportToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.retentionToolStripMenuItem,
            this.toolStripSeparator1,
            this.dispatchToolStripMenuItem,
            this.nIMToolStripMenuItem});
            this.transfersToolStripMenuItem.Name = "transfersToolStripMenuItem";
            this.transfersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.transfersToolStripMenuItem.Text = "Transfers";
            // 
            // custCareToolStripMenuItem
            // 
            this.custCareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lATLIPToolStripMenuItem,
            this.oNCToolStripMenuItem,
            this.dTVToolStripMenuItem,
            this.dLSDToolStripMenuItem,
            this.mobileToolStripMenuItem});
            this.custCareToolStripMenuItem.Name = "custCareToolStripMenuItem";
            this.custCareToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.custCareToolStripMenuItem.Text = "Cust Care";
            // 
            // lATLIPToolStripMenuItem
            // 
            this.lATLIPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.nexusToolStripMenuItem});
            this.lATLIPToolStripMenuItem.Name = "lATLIPToolStripMenuItem";
            this.lATLIPToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.lATLIPToolStripMenuItem.Text = "LAT/LIP";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(105, 22);
            this.toolStripMenuItem2.Text = "52520";
            // 
            // nexusToolStripMenuItem
            // 
            this.nexusToolStripMenuItem.Name = "nexusToolStripMenuItem";
            this.nexusToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.nexusToolStripMenuItem.Text = "Nexus";
            // 
            // oNCToolStripMenuItem
            // 
            this.oNCToolStripMenuItem.Name = "oNCToolStripMenuItem";
            this.oNCToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.oNCToolStripMenuItem.Text = "ONC";
            // 
            // dTVToolStripMenuItem
            // 
            this.dTVToolStripMenuItem.Name = "dTVToolStripMenuItem";
            this.dTVToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.dTVToolStripMenuItem.Text = "DTV";
            // 
            // dLSDToolStripMenuItem
            // 
            this.dLSDToolStripMenuItem.Name = "dLSDToolStripMenuItem";
            this.dLSDToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.dLSDToolStripMenuItem.Text = "DLSD";
            // 
            // mobileToolStripMenuItem
            // 
            this.mobileToolStripMenuItem.Name = "mobileToolStripMenuItem";
            this.mobileToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.mobileToolStripMenuItem.Text = "Mobile";
            // 
            // techSupportToolStripMenuItem
            // 
            this.techSupportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dSLDToolStripMenuItem,
            this.mobileToolStripMenuItem1});
            this.techSupportToolStripMenuItem.Name = "techSupportToolStripMenuItem";
            this.techSupportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.techSupportToolStripMenuItem.Text = "Tech Support";
            // 
            // dSLDToolStripMenuItem
            // 
            this.dSLDToolStripMenuItem.Name = "dSLDToolStripMenuItem";
            this.dSLDToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.dSLDToolStripMenuItem.Text = "DSLD";
            // 
            // mobileToolStripMenuItem1
            // 
            this.mobileToolStripMenuItem1.Name = "mobileToolStripMenuItem1";
            this.mobileToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.mobileToolStripMenuItem1.Text = "Mobile";
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salesToolStripMenuItem.Text = "Sales";
            // 
            // retentionToolStripMenuItem
            // 
            this.retentionToolStripMenuItem.Name = "retentionToolStripMenuItem";
            this.retentionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.retentionToolStripMenuItem.Text = "Retention";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // dispatchToolStripMenuItem
            // 
            this.dispatchToolStripMenuItem.Name = "dispatchToolStripMenuItem";
            this.dispatchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dispatchToolStripMenuItem.Text = "Dispatch";
            // 
            // nIMToolStripMenuItem
            // 
            this.nIMToolStripMenuItem.Name = "nIMToolStripMenuItem";
            this.nIMToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nIMToolStripMenuItem.Text = "NIM";
            // 
            // ratecodesToolStripMenuItem
            // 
            this.ratecodesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LATRatecodeMenuItem,
            this.oNCToolStripMenuItem1,
            this.dTVToolStripMenuItem1});
            this.ratecodesToolStripMenuItem.Name = "ratecodesToolStripMenuItem";
            this.ratecodesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ratecodesToolStripMenuItem.Text = "Ratecodes";
            // 
            // LATRatecodeMenuItem
            // 
            this.LATRatecodeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LatRatecodeSearch});
            this.LATRatecodeMenuItem.Name = "LATRatecodeMenuItem";
            this.LATRatecodeMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LATRatecodeMenuItem.Text = "LAT/LIP";
            this.LATRatecodeMenuItem.Click += new System.EventHandler(this.settingMenuItem_Click);
            // 
            // LatRatecodeSearch
            // 
            this.LatRatecodeSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.LatRatecodeSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.LatRatecodeSearch.AutoSize = false;
            this.LatRatecodeSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.LatRatecodeSearch.Font = new System.Drawing.Font("Verdana", 7F);
            this.LatRatecodeSearch.HideSelection = false;
            this.LatRatecodeSearch.MaxLength = 5;
            this.LatRatecodeSearch.Name = "LatRatecodeSearch";
            this.LatRatecodeSearch.Size = new System.Drawing.Size(50, 19);
            this.LatRatecodeSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyDown);
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
            // linksToolStripMenuItem
            // 
            this.linksToolStripMenuItem.Name = "linksToolStripMenuItem";
            this.linksToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.linksToolStripMenuItem.Text = "Links";
            // 
            // contextMenuToolStripMenuItem
            // 
            this.contextMenuToolStripMenuItem.Name = "contextMenuToolStripMenuItem";
            this.contextMenuToolStripMenuItem.Size = new System.Drawing.Size(95, 18);
            this.contextMenuToolStripMenuItem.Text = "Context Menu";
            // 
            // AppPanel
            // 
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
            this.MenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuPanel.Controls.Add(this._MainMenu);
            this.MenuPanel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MenuPanel.Location = new System.Drawing.Point(-1, -1);
            this.MenuPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(586, 20);
            this.MenuPanel.TabIndex = 27;
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
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteBindsViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginsViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridLinksViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewKeyCommandsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem1;
        private System.Windows.Forms.Panel AppPanel;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.ToolStripMenuItem callHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transfersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem custCareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lATLIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem nexusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oNCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dTVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dLSDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mobileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem techSupportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dSLDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mobileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retentionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem dispatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nIMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ratecodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LATRatecodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oNCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dTVToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem linksToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox LatRatecodeSearch;
        private System.Windows.Forms.ToolStripMenuItem contextMenuToolStripMenuItem;
    }
}