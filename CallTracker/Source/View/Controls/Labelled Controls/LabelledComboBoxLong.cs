using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using PropertyChanged;

namespace CallTracker.View
{
    [ImplementPropertyChanged]
    public partial class LabelledComboBoxLong : LabelledBase
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

        [Category("!Main")]
        [DefaultValue(typeof(Padding), "3,3,3,3")]
        public Padding ControlMargin
        {
            get { return Margin; }
            set { Margin = value; }
        }

        [Category("!Input")]
        [DefaultValue(-1)]
        public int InitialIndex
        {
            get;
            set;
        }

        [Category("!Input")]
        [DefaultValue(true)]
        public bool OverlapLabel
        {
            get;
            set;
        }

        //[Category("!Input")]
        //[Bindable(true)]
        //[Browsable(true)]
        //public ControlBindingsCollection DataBindingSource
        //{
        //    get { return _ComboBox.DataBindings; }
        //}

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
                var attr = (DefaultValueAttribute)prop.Attributes[typeof(DefaultValueAttribute)];
                if (attr != null)
                {
                    prop.SetValue(this, attr.Value);
                }
            }
          
        }

        private void LabelledComboBox_Load(object sender, EventArgs e)
        {
        }

        public void BindComboBox<T>(List<T> dataSource, BindingSource bindingSource, bool nullable = false)
        {
            _ComboBox.NullableMode = nullable;
            if (_ComboBox.NullableMode)
            {
                _ComboBox.Leave -= _ComboBox_Leave<List<T>>;
                _ComboBox.SetDataBinding(dataSource, bindingSource, PropertyName, String.Empty);
                _ComboBox.Leave += _ComboBox_Leave<List<T>>;
            }
            else
            {
                _ComboBox.DataBindings.Clear();
                _ComboBox.Leave -= _ComboBox_Leave<List<T>>;
                _ComboBox.DataSource = dataSource;
                _ComboBox.SelectedIndex = InitialIndex;
                if (dataSource.Count > 0)
                {                 
                    _ComboBox.Leave += _ComboBox_Leave<List<T>>;
                }
                _ComboBox.DataBindings.Add("SelectedItem", bindingSource, PropertyName, true, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

        public void UnbindComboBox<T>()
        {
            if (_ComboBox.NullableMode)
            {
                _ComboBox.Leave -= _ComboBox_Leave<List<T>>;
                _ComboBox.UnSetDataBinding();
            }
            else
            {
                _ComboBox.DataBindings.Clear();
                _ComboBox.Leave -= _ComboBox_Leave<List<T>>;
                _ComboBox.DataSource = null;
            }
        }

        public void UpdateBindingSource(BindingSource bindingSource)
        {
            if (_ComboBox.NullableMode)
            {
                _ComboBox.UpdateNullableBindingSource(bindingSource);
            }
            else
            {
                _ComboBox.DataBindings.Clear();
                if (_ComboBox.Items.Count > 0)
                    _ComboBox.SelectedIndex = InitialIndex;
                _ComboBox.DataBindings.Add("SelectedItem", bindingSource, PropertyName, true, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

        public void UpdateComboBox(List<string> dataSource)
        {
            if (dataSource.Count > 0)
            {
                _ComboBox.DataSource = dataSource;
                //_ComboBox.SelectedIndex = InitialIndex;
            }
        }

        private void _ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ComboBox.Select(0, 0);
            ParentForm.Validate();
        }

        private void _ComboBox_DropDown(object sender, EventArgs e)
        {
            if (!OverlapLabel)
                return;
            if (ContextMenuStrip != null)
                _MenuButton.Hide();
            _Label.Hide();
        }

        private void _ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            _ComboBox.Select(0, 0);
            Parent.Parent.Focus();        
            if (!OverlapLabel)
                return;
            if(ContextMenuStrip != null)
                _MenuButton.Show();
            _Label.Show();         
        }

        private void _ComboBox_Leave<T>(object sender, EventArgs e) where T : IEnumerable
        {
            bool ok = false;
            if (_ComboBox.DataSource != null)
                foreach (var data in ((T)_ComboBox.DataSource))
                {
                    if (String.Equals(data.ToString(), _ComboBox.Text, StringComparison.CurrentCultureIgnoreCase))
                        ok = true;
                }
            if (!ok)
                _ComboBox.Text = String.Empty;
        }

        private void _ComboBox_Leave_1(object sender, EventArgs e)
        {
            _ComboBox.Select(0, 0);
        }
        //private void _ComboBox_Leave(object sender, EventArgs e)
        //{
        //    bool ok = false;
        //    if (_ComboBox.DataSource != null)
        //        foreach (string data in ((BindingList<string>)_ComboBox.DataSource))
        //        {
        //            if (data.ToLower() == _ComboBox.Text.ToLower())
        //                ok = true;
        //        }
        //    if (!ok)
        //        _ComboBox.Text = String.Empty;
        //}
    }
}
