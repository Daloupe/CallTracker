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
        [Category("A1")]
        public HorizontalAlignment TextAlign
        {
            get { return _DataField.TextAlign; }
            set { _DataField.TextAlign = value; }
        }

        [Category("A1")]
        public Color BorderColour
        {
            get { return _DataField.BorderColor; }
            set { _DataField.BorderColor = value; }
        }

        [Category("A1")]
        [Bindable(true)]
        [Browsable(false)]
        public string TextField
        {
            get { return _DataField.Text; }
            set { _DataField.Text = value; }
        }

        public LabelledTextBox()
        {
            InitializeComponent();
            _DataField.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this.ContextMenuStripChanged += base.LabelledTextBox_ContextMenuStripChanged;
        }

        private void _DataField_TextChanged(object sender, EventArgs e)
        {
            this.ParentForm.Validate();
        }

        private void LabelledTextBox_Load(object sender, EventArgs e)
        {
            if (ContextMenuStrip != null)
            {
                this._MenuButton.Show();
                this.ContextMenuStrip.Show();
                this.ContextMenuStrip.BindingContext = this.ParentForm.BindingContext;
            }
        }
    }
}
