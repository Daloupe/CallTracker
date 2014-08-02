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
        
        [Category("A1")]
        public string LabelText
        {
            get { return _Label.Text; }
            set { _Label.Text = value; }
        }

        [Category("A1")]
        public Font LabelFont
        {
            get { return _Label.Font; }
            set { _Label.Font = value; }
        }

        [Category("A1")]
        public Point LabelOffset
        {
            get { return _Label.Location; }
            set { _Label.Location = value; }
        }

        [Category("A1")]
        public Size LabelSize
        {
            get { return _Label.Size; }
            set { _Label.Size = value; }
        }

        [Category("A1")]
        public bool LabelAutoSize
        {
            get { return _Label.AutoSize; }
            set { _Label.AutoSize = value; }
        }

        [Category("A1")]
        public ContentAlignment LabelTextAlign
        {
            get { return _Label.TextAlign; }
            set { _Label.TextAlign = value; }
        }

        [Category("A1")]
        public int ControlHeight
        {
            get { return this.Height; }
            set { this.Height = value; }
        }

        public LabelledBase()
        {
            InitializeComponent();
            lasttime = DateTime.UtcNow;
        }

        public virtual void AttachMenu(ContextMenuStrip menu)
        {
            ContextMenuStrip = menu;
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

            if (DateTime.UtcNow.Subtract(lasttime).Milliseconds > 9 && opened == false )
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

            if (DateTime.UtcNow.Subtract(lasttime).Milliseconds < 9 && opened == true)
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
