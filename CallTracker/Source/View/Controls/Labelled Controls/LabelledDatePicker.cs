using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PropertyChanged;

namespace CallTracker.View
{
    [ImplementPropertyChanged]
    [DefaultBindingProperty("DateField")]
    public partial class LabelledDatePicker: LabelledBase
    {
        [Category("!Input")]
        public Color BorderColour
        {
            get { return _DateTimePicker.BorderColor; }
            set { _DateTimePicker.BorderColor = value; }
        }

        [Category("!Input")]
        [Bindable(true)]
        [Browsable(true)]
        public DateTime DateField
        {
            get { return _DateTimePicker.Value; }
            set { _DateTimePicker.Value = value; }
        }

        [Browsable(true)]
        public event EventHandler ValueChanged
        {
            add { _DateTimePicker.ValueChanged += value; }
            remove { _DateTimePicker.ValueChanged -= value; }
        }

        public LabelledDatePicker()
        {
            InitializeComponent();
            _DateTimePicker.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this.ContextMenuStripChanged += base.LabelledTextBox_ContextMenuStripChanged;
        }

        private void LabelledComboBox_Load(object sender, EventArgs e)
        {
            if (ContextMenuStrip != null)
            {
                
                this._MenuButton.Show();
                this.ContextMenuStrip.Show();
                this.ContextMenuStrip.BindingContext = this.ParentForm.BindingContext;
            }
        }

        private void _DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //this.ParentForm.Validate();
        }

        private void _DateTimePicker_CloseUp(object sender, EventArgs e)
        {
            //this.Parent.Focus();
        }
    }
}
