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
    [DefaultBindingProperty("DataText")]
    public partial class DataDropDown : UserControl
    {
        public DataDropDown()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
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
