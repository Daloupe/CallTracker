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
        [Category("!Input")]
        public HorizontalAlignment TextAlign
        {
            get { return _DataField.TextAlign; }
            set { _DataField.TextAlign = value; }
        }

        [Category("!Input")]
        public string DefaultText
        {
            get { return _DataField.Text; }
            set { _DataField.Text = value; }
        }

        [Category("!Input")]
        public Color BorderColour
        {
            get { return _DataField.BorderColor; }
            set { _DataField.BorderColor = value; }
        }

        [Category("!Input")]
        [Bindable(true)]
        [Browsable(true)]
        public string TextField
        {
            get { return _DataField.Text; }
            set { _DataField.Text = value; }
        }

        [Category("!Input")]
        public Color TextFieldBackColour
        {
            get { return _DataField.BackColor; }
            set { _DataField.BackColor = value; }
        }

        public LabelledTextBox()
        {
            InitializeComponent();
            //this.ContextMenuStripChanged += base.LabelledTextBox_ContextMenuStripChanged;
        }

        private void _DataField_TextChanged(object sender, EventArgs e)
        {
            this.ParentForm.Validate();
            if (!String.IsNullOrEmpty(_DataField.Text))
                this.BackColor = LabelActiveColor;
            else
                this.BackColor = LabelInactiveColor;
        }

        private void LabelledTextBox_Load(object sender, EventArgs e)
        {
            //if (ContextMenuStrip != null)
            //{
            //    this._MenuButton.Show();
            //    this.ContextMenuStrip.Show();
            //    this.ContextMenuStrip.BindingContext = this.ParentForm.BindingContext;
            //}
        }
    }
}
