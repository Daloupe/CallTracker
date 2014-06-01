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
    public partial class IDataField : UserControl
    {
        protected string propertyName;
        [Category("A1")]
        public string PropertyName
        {
            get { return propertyName; }
            set { propertyName = value; }
        }
    }
    [DefaultBindingProperty("TextField")]
    public partial class DataField : IDataField
    {
        public DataField()
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
        public string TextField
        {
            get { return _DataField.Text; }
            set { _DataField.Text = value; }
        }
    }
}
