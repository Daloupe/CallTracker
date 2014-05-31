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
            this.DeleteCallDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginsViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridLinksViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteBindsViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewKeyCommandsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppPanel = new System.Windows.Forms.Panel();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.editContact = new CallTracker.View.EditContact(this);
            this.editGridLinks = new CallTracker.View.EditGridLinks();
            this.editSmartPasteBinds = new CallTracker.View.EditSmartPasteBinds();
            this.editLogins = new CallTracker.View.EditLogins();
            this.helpKeyCommands = new CallTracker.View.HelpKeyCommands();
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
            this.helpToolStripMenuItem});
            this._MainMenu.Location = new System.Drawing.Point(0, 0);
            this._MainMenu.Name = "_MainMenu";
            this._MainMenu.Padding = new System.Windows.Forms.Padding(0);
            this._MainMenu.Size = new System.Drawing.Size(584, 18);
            this._MainMenu.TabIndex = 2;
            this._MainMenu.Text = "_MainMenu";
            this._MainMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrayBorder);
            this._MainMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this._MainMenu_MouseDown);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteCallDataMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(79, 18);
            this.fileToolStripMenuItem.Text = "Call Tracker";
            // 
            // DeleteCallDataMenuItem
            // 
            this.DeleteCallDataMenuItem.Name = "DeleteCallDataMenuItem";
            this.DeleteCallDataMenuItem.Size = new System.Drawing.Size(149, 22);
            this.DeleteCallDataMenuItem.Text = "Delete All Calls";
            this.DeleteCallDataMenuItem.Click += new System.EventHandler(this.DeleteCallDataMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginsViewMenuItem,
            this.gridLinksViewMenuItem,
            this.pasteBindsViewMenuItem});
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
            // AppPanel
            // 
            this.AppPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppPanel.Controls.Add(this.editContact);
            this.AppPanel.Controls.Add(this.MenuPanel);
            this.AppPanel.Controls.Add(this.editGridLinks);
            this.AppPanel.Controls.Add(this.editSmartPasteBinds);
            this.AppPanel.Controls.Add(this.editLogins);
            this.AppPanel.Controls.Add(this.helpKeyCommands);
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
            // editContact
            // 
            this.editContact.Font = new System.Drawing.Font("Verdana", 7F);
            this.editContact.Location = new System.Drawing.Point(0, 18);
            this.editContact.Margin = new System.Windows.Forms.Padding(0);
            this.editContact.Name = "editContact";
            this.editContact.Padding = new System.Windows.Forms.Padding(3);
            this.editContact.ProductBit = ((short)(0));
            this.editContact.Size = new System.Drawing.Size(584, 222);
            this.editContact.TabIndex = 28;
            // 
            // editGridLinks
            // 
            this.editGridLinks.BackColor = System.Drawing.Color.LightSlateGray;
            this.editGridLinks.Font = new System.Drawing.Font("Verdana", 7F);
            this.editGridLinks.Location = new System.Drawing.Point(0, 18);
            this.editGridLinks.Name = "editGridLinks";
            this.editGridLinks.Padding = new System.Windows.Forms.Padding(3);
            this.editGridLinks.Size = new System.Drawing.Size(584, 222);
            this.editGridLinks.TabIndex = 31;
            this.editGridLinks.Visible = false;
            // 
            // editSmartPasteBinds
            // 
            this.editSmartPasteBinds.BackColor = System.Drawing.Color.LightSlateGray;
            this.editSmartPasteBinds.Font = new System.Drawing.Font("Verdana", 7F);
            this.editSmartPasteBinds.Location = new System.Drawing.Point(0, 18);
            this.editSmartPasteBinds.Name = "editSmartPasteBinds";
            this.editSmartPasteBinds.Padding = new System.Windows.Forms.Padding(3);
            this.editSmartPasteBinds.Size = new System.Drawing.Size(584, 222);
            this.editSmartPasteBinds.TabIndex = 30;
            this.editSmartPasteBinds.Visible = false;
            // 
            // editLogins
            // 
            this.editLogins.BackColor = System.Drawing.Color.LightSlateGray;
            this.editLogins.Font = new System.Drawing.Font("Verdana", 7F);
            this.editLogins.Location = new System.Drawing.Point(0, 18);
            this.editLogins.Name = "editLogins";
            this.editLogins.Padding = new System.Windows.Forms.Padding(3);
            this.editLogins.Size = new System.Drawing.Size(584, 222);
            this.editLogins.TabIndex = 29;
            this.editLogins.Visible = false;
            // 
            // helpKeyCommands
            // 
            this.helpKeyCommands.BackColor = System.Drawing.Color.LightSlateGray;
            this.helpKeyCommands.Font = new System.Drawing.Font("Verdana", 7F);
            this.helpKeyCommands.Location = new System.Drawing.Point(0, 18);
            this.helpKeyCommands.Name = "helpKeyCommands";
            this.helpKeyCommands.Padding = new System.Windows.Forms.Padding(3);
            this.helpKeyCommands.Size = new System.Drawing.Size(584, 222);
            this.helpKeyCommands.TabIndex = 32;
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
        private System.Windows.Forms.ToolStripMenuItem DeleteCallDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem1;
        private System.Windows.Forms.Panel AppPanel;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private EditLogins editLogins;
        private EditGridLinks editGridLinks;
        public EditSmartPasteBinds editSmartPasteBinds;
        public EditContact editContact;
        private HelpKeyCommands helpKeyCommands;

    }
}