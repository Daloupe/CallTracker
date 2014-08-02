using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CallTracker.View
{
    public partial class LabelledBase : IDataField
    {
        public LabelledBase()
        {
            InitializeComponent();
            lasttime = DateTime.UtcNow;
        }

        [Category("A1")]
        public string LabelText
        {
            get { return _Label.Text; }
            set { _Label.Text = value; }
        }

        [Category("A1")]
        public int LabelWidth
        {
            get { return _Label.Width; }
            set { _Label.Width = value; }
        }

        protected DateTime lasttime;
        protected bool opened;
        protected void _MenuButton_MouseClick(object sender, MouseEventArgs e)
        {
            lasttime = DateTime.UtcNow;

            if (this.ContextMenuStrip.Visible == false && this.ContextMenuStrip.Tag != this._MenuButton)
            {
                _MenuButton.BackgroundImage = Properties.Resources.TinyArrow;
                this.ContextMenuStrip.Tag = this._MenuButton;
                this.ContextMenuStrip.Show(_MenuButton, 9, 9);
                opened = true;
            }
            else
            {
                this.ContextMenuStrip.Tag = null;
                this.ContextMenuStrip.Hide();
                opened = false;
            }
        }

        protected void _MenuButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (DateTime.UtcNow.Subtract(lasttime).Milliseconds > 50 && opened == true)
            {
                this.ContextMenuStrip.Tag = this._MenuButton;
                opened = false;
            }
        }

        protected void LabelledTextBox_ContextMenuStripChanged(object sender, EventArgs e)
        {
            if (ContextMenuStrip != null)
            {
                _MenuButton.Show();
            }
            else
                _MenuButton.Hide();
        }
    }
}
