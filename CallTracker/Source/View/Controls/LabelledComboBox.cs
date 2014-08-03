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
    public partial class LabelledComboBox : LabelledBase
    {
        [Category("A1")]
        public Color BorderColour
        {
            get { return _ComboBox.BorderColor; }
            set { _ComboBox.BorderColor = value; }
        }

        [Category("A1")]
        public string DefaultText
        {
            get { return _ComboBox.Text; }
            set { _ComboBox.Text = value; }
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

        public LabelledComboBox()
        {
            InitializeComponent();
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
            this.ParentForm.Validate();
        }

        private void _ComboBox_DataSourceChanged(object sender, EventArgs e)
        {
            this.ParentForm.Validate();
        }

        private void _ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            this.Parent.Focus();
        }
    }
}
