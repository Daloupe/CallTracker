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
            get { return this.Margin; }
            set { this.Margin = value; }
        }

        [Category("!Input")]
        [DefaultValue(-1)]
        public int InitialIndex
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
                DefaultValueAttribute attr = (DefaultValueAttribute)prop.Attributes[typeof(DefaultValueAttribute)];
                if (attr != null)
                {
                    prop.SetValue(this, attr.Value);
                }
            }    
            //this.ContextMenuStripChanged += base.LabelledTextBox_ContextMenuStripChanged;
        }

        private void LabelledComboBox_Load(object sender, EventArgs e)
        {
            //if (ContextMenuStrip != null)
            //{
                
            //    this._MenuButton.Show();
            //    this.ContextMenuStrip.Show();
            //    this.ContextMenuStrip.BindingContext = this.ParentForm.BindingContext;
            //}
        }

        public void BindComboBox(List<string> _dataSource, BindingSource _bindingSource)
        {
            _ComboBox.DataSource = null;
            _ComboBox.DataBindings.Clear();
            
            if (_dataSource.Count > 0)
            {
                _ComboBox.DataSource = _dataSource;
                _ComboBox.SelectedIndex = InitialIndex;
                _ComboBox.Leave += _ComboBox_Leave<List<string>>;
            }
            _ComboBox.DataBindings.Add("Text", _bindingSource, PropertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        //public void BindComboBox(Array _dataSource, BindingSource _bindingSource)
        //{
        //    _ComboBox.DataSource = null;
        //    _ComboBox.DataBindings.Clear();
        //    _ComboBox.DataBindings.Add("Text", _bindingSource, PropertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        //    _ComboBox.DataSource = _dataSource;
        //    //_ComboBox.Leave += _ComboBox_Leave<Array>;
        //}

        public void BindComboBox(BindingList<string> _dataSource, BindingSource _bindingSource)
        {
            //Console.WriteLine("yep");
            _ComboBox.DataSource = null;
            _ComboBox.DataBindings.Clear();
            
            if (_dataSource.Count > 0)
            {
                _ComboBox.DataSource = _dataSource;
                _ComboBox.SelectedIndex = InitialIndex;
                _ComboBox.Leave += _ComboBox_Leave<BindingList<string>>;
            }
            _ComboBox.DataBindings.Add("Text", _bindingSource, PropertyName, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void _ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ComboBox.Select(0, 0);
            this.ParentForm.Invalidate();
        }

        private void _ComboBox_DataSourceChanged(object sender, EventArgs e)
        {
            this.ParentForm.Invalidate();
        }

        private void _ComboBox_DropDown(object sender, EventArgs e)
        {
            if (ContextMenuStrip != null)
                _MenuButton.Hide();
            _Label.Hide();
        }

        private void _ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            this.Parent.Parent.Focus();
            _ComboBox.Select(0, 0);
            if(ContextMenuStrip != null)
                _MenuButton.Show();
            _Label.Show();
            
        }

        private void _ComboBox_Leave<T>(object sender, EventArgs e) where T : IEnumerable<string>
        {
            bool ok = false;
            if (_ComboBox.DataSource != null)
                foreach (string data in ((T)_ComboBox.DataSource))
                {
                    if (data.ToLower() == _ComboBox.Text.ToLower())
                        ok = true;
                }
            if (!ok)
                _ComboBox.Text = String.Empty;
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
