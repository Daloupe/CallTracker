﻿namespace CallTracker.View
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
            this.customerContactsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactsListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.faultModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.MenuPanel = new System.Windows.Forms.Panel();
            this._MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteCallDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smartPasteBindsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.featuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppPanel = new System.Windows.Forms.Panel();
            this.contact1 = new CallTracker.Source.View.Contact();
            ((System.ComponentModel.ISupportInitialize)(this.customerContactsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactAddressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faultModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.MenuPanel.SuspendLayout();
            this._MainMenu.SuspendLayout();
            this.AppPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerContactsBindingSource
            // 
            this.customerContactsBindingSource.AllowNew = true;
            // 
            // contactsListBindingSource
            // 
            this.contactsListBindingSource.AllowNew = true;
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
            this._MainMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this._MainMenu_MouseDown);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.DeleteCallDataMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(79, 18);
            this.fileToolStripMenuItem.Text = "Call Tracker";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
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
            this.loginsToolStripMenuItem,
            this.smartPasteBindsToolStripMenuItem,
            this.gridLinksToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(62, 18);
            this.viewToolStripMenuItem.Text = "Settings";
            // 
            // loginsToolStripMenuItem
            // 
            this.loginsToolStripMenuItem.Name = "loginsToolStripMenuItem";
            this.loginsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.loginsToolStripMenuItem.Text = "Logins";
            this.loginsToolStripMenuItem.Click += new System.EventHandler(this.loginsToolStripMenuItem_Click);
            // 
            // smartPasteBindsToolStripMenuItem
            // 
            this.smartPasteBindsToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smartPasteBindsToolStripMenuItem.Name = "smartPasteBindsToolStripMenuItem";
            this.smartPasteBindsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.smartPasteBindsToolStripMenuItem.Text = "Smart Paste Binds";
            this.smartPasteBindsToolStripMenuItem.Click += new System.EventHandler(this.smartPasteBindsToolStripMenuItem_Click);
            // 
            // gridLinksToolStripMenuItem
            // 
            this.gridLinksToolStripMenuItem.Name = "gridLinksToolStripMenuItem";
            this.gridLinksToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.gridLinksToolStripMenuItem.Text = "Grid Link Binds";
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
            this.viewHotkeysToolStripMenuItem,
            this.featuresToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(42, 18);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHotkeysToolStripMenuItem
            // 
            this.viewHotkeysToolStripMenuItem.Name = "viewHotkeysToolStripMenuItem";
            this.viewHotkeysToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.viewHotkeysToolStripMenuItem.Text = "View Hotkeys";
            // 
            // featuresToolStripMenuItem
            // 
            this.featuresToolStripMenuItem.Name = "featuresToolStripMenuItem";
            this.featuresToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.featuresToolStripMenuItem.Text = "Features";
            // 
            // AppPanel
            // 
            this.AppPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppPanel.Controls.Add(this.contact1);
            this.AppPanel.Controls.Add(this.MenuPanel);
            this.AppPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppPanel.Location = new System.Drawing.Point(0, 0);
            this.AppPanel.Name = "AppPanel";
            this.AppPanel.Size = new System.Drawing.Size(586, 250);
            this.AppPanel.TabIndex = 25;
            // 
            // contact1
            // 
            this.contact1.Location = new System.Drawing.Point(0, 20);
            this.contact1.Name = "contact1";
            this.contact1.Size = new System.Drawing.Size(585, 217);
            this.contact1.TabIndex = 28;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(586, 250);
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
            ((System.ComponentModel.ISupportInitialize)(this.customerContactsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactAddressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faultModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.MenuPanel.ResumeLayout(false);
            this._MainMenu.ResumeLayout(false);
            this._MainMenu.PerformLayout();
            this.AppPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.BindingSource customerContactBindingSource;
        private System.Windows.Forms.BindingSource contactAddressBindingSource;
        private System.Windows.Forms.BindingSource customerContactsBindingSource;
        private System.Windows.Forms.BindingSource contactsListBindingSource;
        private System.Windows.Forms.BindingSource mainBindingSource;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.BindingSource customerServiceBindingSource;
        private System.Windows.Forms.BindingSource faultModelBindingSource;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.MenuStrip _MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteCallDataMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smartPasteBindsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridLinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHotkeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem featuresToolStripMenuItem;
        private System.Windows.Forms.Panel AppPanel;
        private Source.View.Contact contact1;

    }
}