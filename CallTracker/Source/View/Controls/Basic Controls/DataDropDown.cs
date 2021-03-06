﻿using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CallTracker.View
{
    [DefaultBindingProperty("DataText")]
    public partial class DataDropDown : IDataField
    {
        public DataDropDown()
        {
            InitializeComponent();
        }

        [Category("A1")]
        public string LabelText 
        {
            get { return _Label.Text; }
            set { _Label.Text = value; }
        }
        [Category("A1")]
        public int LabelWidth
        {
            get { return _Label.Width; }
            set { _Label.Width = value; }
        }

        [Bindable(true)]
        [Browsable(false)]
        public string DataText
        {
            get { return _DataField.Text; }
            set { _DataField.Text = value; }
        }

        [Bindable(true)]
        [Browsable(false)]
        public string DataSelectedItem
        {
            get { return _DataField.SelectedText; }
            set { _DataField.SelectedItem = value; }
        }

        [Bindable(true)]
        [Browsable(false)]
        public string DataSelectedValue
        {
            get { return _DataField.SelectedText; }
            set { _DataField.SelectedValue = value; }
        }

        //[Bindable(true)]
        [Browsable(false)]
        public object DataSource
        {
            get { return _DataField.DataSource; }
            set { _DataField.DataSource = value; }
        }

        private void PaintGrayBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Gray,
              _DataField.Left - 1,
              _DataField.Top - 1,
              _DataField.Width + 1,
              _DataField.Height + 1);
        }
    }
}
