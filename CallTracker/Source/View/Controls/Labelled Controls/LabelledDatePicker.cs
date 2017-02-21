using System;
using System.ComponentModel;
using System.Drawing;
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

        //[Category("!Input")]
        [Bindable(true)]
        //[Browsable(true)]
        public DateTime DateField
        {
            get { return _DateTimePicker.Value; }
            set { _DateTimePicker.Value = value; }
        }
        //[Category("!Input")]
        [Bindable(true)]
        //[Browsable(true)]
        public string DateText
        {
            get { return _DateTimePicker.Text; }
            set { _DateTimePicker.Text = value; }
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
            //this.ContextMenuStripChanged += base.LabelledTextBox_ContextMenuStripChanged;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            //if (ContextMenuStrip != null)
            //{    
            //    this._MenuButton.Show();
            //    this.ContextMenuStrip.Show();
            //    this.ContextMenuStrip.BindingContext = this.ParentForm.BindingContext;
            //    _DateTimePicker.ValueChanged += _DateTimePicker_ValueChanged;
            //}
        }

        public void BindDatePickerBox( BindingSource _bindingSource)
        {
            _DateTimePicker.DataBindings.Clear();
            _DateTimePicker.DataBindings.Add("Value", _bindingSource, PropertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

    }
}
