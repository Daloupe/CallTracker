using System.ComponentModel;

namespace CallTracker.View
{
    [DefaultBindingProperty("TextField")]
    public partial class DataArea : IDataField
    {
        public DataArea()
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
