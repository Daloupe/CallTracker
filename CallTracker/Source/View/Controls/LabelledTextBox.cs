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
    [DefaultBindingProperty("TextField")]
    public partial class LabelledTextBox : LabelledBase
    {
        public LabelledTextBox()
        {
            InitializeComponent();
            //lasttime = DateTime.UtcNow;
            this.ContextMenuStripChanged += base.LabelledTextBox_ContextMenuStripChanged;
            if (ContextMenuStrip != null)
            {
                //this.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
                //this.ContextMenuStrip.Closing += ContextMenuStrip_Closing;
                this._MenuButton.Show();
                //this.ContextMenuStrip.Show();
                //this.ContextMenuStrip.BindingContext = this.ParentForm.BindingContext;
            }
        }

        [Category("A1")]
        public HorizontalAlignment TextAlign
        {
            get { return _DataField.TextAlign; }
            set { _DataField.TextAlign = value; }
        }

        [Bindable(true)]
        [Browsable(false)]
        public string TextField
        {
            get { return _DataField.Text; }
            set { _DataField.Text = value; }
        }

        private void _DataField_TextChanged(object sender, EventArgs e)
        {
            this.ParentForm.Validate();
        }

        private void LabelledTextBox_Load(object sender, EventArgs e)
        {
            //if (ContextMenuStrip != null)
            //{
            //    this.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            //    this.ContextMenuStrip.Closing += ContextMenuStrip_Closing;
            //    this._MenuButton.Show();
            //    //this.ContextMenuStrip.Show();
            //    //this.ContextMenuStrip.BindingContext = this.ParentForm.BindingContext;
            //}
        }
        //public override void ContextMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        //{;
        //    ContextMenuStrip menu = (ContextMenuStrip)sender;
        //    if (menu.Tag != null)
        //    {
        //        menu.Tag = null;
        //        e.Cancel = true;
        //    }
        //    opened = false;
        //    menu.SourceControl.BackgroundImage = Properties.Resources.TinyArrow2;
        //    menu.Closing -= ContextMenuStrip_Closing;
        //}

        //public override void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        //{
        //    ContextMenuStrip menu = (ContextMenuStrip)sender;
        //    Console.WriteLine(ContextMenuStrip.Tag == null);
        //    if (menu.Tag == null)
        //        e.Cancel = true;
        //    menu.Tag = null;
        //    menu.Opening -= ContextMenuStrip_Opening;
        //}

        //protected override void LabelledTextBox_ContextMenuStripChanged(object sender, EventArgs e)
        //{
        //    if (ContextMenuStrip != null)
        //    {
        //        _MenuButton.Show();
        //    }
        //    else
        //    {
        //        _MenuButton.Hide();
        //    }
        //}

        //private void _MenuButton_MouseUp_1(object sender, MouseEventArgs e)
        //{

        //}
    }
}
