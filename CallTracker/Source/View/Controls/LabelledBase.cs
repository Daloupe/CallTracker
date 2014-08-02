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

        public virtual void AttachMenu(ContextMenuStrip menu)
        {
            ContextMenuStrip = menu;

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
        protected virtual void _MenuButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.ContextMenuStrip.Visible == false)
            {
                this.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
                this.ContextMenuStrip.Show(this._MenuButton, 9, 9);
                opened = true;
            }
            else
            {
                this.ContextMenuStrip.Hide();
                opened = false;       
            }
        }

        public virtual void ContextMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            ContextMenuStrip menu = (ContextMenuStrip)sender;
            menu.Closing -= ContextMenuStrip_Closing;
            Console.WriteLine(DateTime.UtcNow.Subtract(lasttime).Milliseconds);
            int time = DateTime.UtcNow.Subtract(lasttime).Milliseconds;
            if (time > 9 && opened == false )
            {
                e.Cancel = true;
                return;
            }
            menu.SourceControl.BackgroundImage = Properties.Resources.TinyArrow2;
            lasttime = DateTime.UtcNow;
        }

        protected virtual void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        { 
            ContextMenuStrip menu = (ContextMenuStrip)sender;
            menu.Opening -= ContextMenuStrip_Opening;

            int time = DateTime.UtcNow.Subtract(lasttime).Milliseconds;
            if (time < 9 && opened == true)
            {
                e.Cancel = true;
                return;
            }
            lasttime = DateTime.UtcNow;
            this._MenuButton.BackgroundImage = Properties.Resources.TinyArrow;
            menu.Closing += ContextMenuStrip_Closing;
        }

        protected virtual void LabelledTextBox_ContextMenuStripChanged(object sender, EventArgs e)
        {
            if (ContextMenuStrip != null)
                _MenuButton.Show();
            else
                _MenuButton.Hide();
        }
    }
}
