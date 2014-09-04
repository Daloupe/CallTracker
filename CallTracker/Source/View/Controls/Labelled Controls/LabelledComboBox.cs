using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CallTracker.View
{
    //[ImplementPropertyChanged]
    //[DefaultBindingProperty("ComboText")]
    public partial class LabelledComboBox : LabelledBase
    {
        [Category("!Input")]
        public Color BorderColour
        {
            get { return _ComboBox.BorderColor; }
            set { _ComboBox.BorderColor = value; }
        }

        [Category("!Input")]
        public string DefaultText
        {
            get { return _ComboBox.Text; }
            set { _ComboBox.Text = value; }
        }

        [Category("!Input")]
        [DefaultValue(-1)]
        public int InitialIndex
        {
            get;
            set;
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
            //this.ContextMenuStripChanged += base.LabelledTextBox_ContextMenuStripChanged;
        }

        private void LabelledComboBox_Load(object sender, EventArgs e)
        {

        }

        public void BindComboBox(List<string> _dataSource, BindingSource _bindingSource)
        {
            //_ComboBox.DataSource = null;
            _ComboBox.DataBindings.Clear();
            if (_dataSource.Count > 0)
            {
                _ComboBox.DataSource = _dataSource;
                _ComboBox.SelectedIndex = InitialIndex;
            }
            _ComboBox.DataBindings.Add("SelectedItem", _bindingSource, PropertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void BindComboBox(Array _dataSource, BindingSource _bindingSource)
        {
            //_ComboBox.DataSource = null;
            _ComboBox.DataBindings.Clear();
            if (_dataSource.Length > 0)
            {
                _ComboBox.DataSource = _dataSource;
                _ComboBox.SelectedIndex = InitialIndex;
            }
            _ComboBox.DataBindings.Add("SelectedItem", _bindingSource, PropertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void BindComboBox(BindingList<string> _dataSource, BindingSource _bindingSource)
        {
            //_ComboBox.DataSource = null;
            _ComboBox.DataBindings.Clear();
            if (_dataSource.Count > 0)
            {
                _ComboBox.DataSource = _dataSource;
                _ComboBox.SelectedIndex = InitialIndex;
            }
            _ComboBox.DataBindings.Add("SelectedItem", _bindingSource, PropertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void UnbindComboBox()
        {
                _ComboBox.DataBindings.Clear();
                _ComboBox.DataSource = null;
        }

        public void UpdateBindingSource(BindingSource bindingSource)
        {
            _ComboBox.DataBindings.Clear();
            if (_ComboBox.Items.Count > 0)
                _ComboBox.SelectedIndex = InitialIndex;
            _ComboBox.DataBindings.Add("SelectedItem", bindingSource, PropertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void UpdateComboBox(BindingList<string> _dataSource)
        {
            //_ComboBox.DataSource = null;
            //_ComboBox.DataBindings.Clear();
            if (_dataSource.Count > 0)
            {
                _ComboBox.DataSource = _dataSource;
                //_ComboBox.SelectedIndex = InitialIndex;
            }
         //   _ComboBox.DataBindings.Add("SelectedItem", _bindingSource, PropertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void _ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_ComboBox.Select(0, 0);
            ParentForm.Validate();
        }

        private void _ComboBox_DataSourceChanged(object sender, EventArgs e)
        {
            ParentForm.Validate();
        }

        private void _ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            this.Parent.Focus();
            //_ComboBox.Select(0, 0);
            
        }
    }
}
