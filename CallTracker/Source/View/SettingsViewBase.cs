﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CallTracker.View
{
    public partial class SettingsViewBase : UserControl
    {
        public ToolStripMenuItem MenuControl { get; protected set; }
        protected Main MainForm { get; set; }

        public virtual void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            MenuControl = _menuItem;
            MenuControl.Tag = this;
            MainForm = _parent;

            this.Visible = true;
            this.SendToBack();
            this.Visible = false;
            //this.BringToFront();
        }

        protected virtual void _Done_Click(object sender, EventArgs e)
        {
            MainForm.VisibleSetting = null;
        }

        public virtual void HideSetting()
        {
            MenuControl.Checked = false;
            this.SendToBack();
            this.Visible = false;
        }

        public virtual void ShowSetting()
        {
            MenuControl.Checked = true;
            this.BringToFront();
            this.Visible = true;
        }

        protected virtual void PaintBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Gainsboro,
              e.ClipRectangle.Left,
              e.ClipRectangle.Top,
              e.ClipRectangle.Width - 1,
              e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SettingsViewBase
            // 
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Name = "SettingsViewBase";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(584, 222);
            this.ResumeLayout(false);

        }
    }
}
