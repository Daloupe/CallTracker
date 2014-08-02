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
    [DefaultBindingProperty("DataBindingSource")]
    public partial class LabelledComboBoxLong : LabelledBase
    {
        [Category("A1")]
        public Color BorderColour
        {
            get { return _ComboBox.BorderColor; }
            set { _ComboBox.BorderColor = value; }
        }
        [Category("A1")]
        [DefaultValue(typeof(Padding), "3,3,3,3")]
        public Padding ControlMargin
        {
            get { return this.Margin; }
            set { this.Margin = value; }
        }

        [Category("A1")]
        [Bindable(true)]
        [Browsable(true)]
        public ControlBindingsCollection DataBindingSource
        {
            get { return _ComboBox.DataBindings; }
        }

        [Browsable(true)]
        public event EventHandler SelectedIndexChanged
        {
            add { _ComboBox.SelectedIndexChanged += value; }
            remove { _ComboBox.SelectedIndexChanged -= value; }
        }

        public object DataSource
        {
            get { return _ComboBox.DataSource; }
            set { _ComboBox.DataSource = value; }
        }

        public LabelledComboBoxLong()
        {
            InitializeComponent();
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
            {
                DefaultValueAttribute attr = (DefaultValueAttribute)prop.Attributes[typeof(DefaultValueAttribute)];
                if (attr != null)
                {
                    prop.SetValue(this, attr.Value);
                }
            }

            _ComboBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
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

        private void _ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Parent.Focus();
            this.ParentForm.Validate();
        }

        private void _ComboBox_DataSourceChanged(object sender, EventArgs e)
        {
            this.ParentForm.Validate();
        }
    }
}
