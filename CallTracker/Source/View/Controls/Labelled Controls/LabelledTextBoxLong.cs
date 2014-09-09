using System;

using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;

namespace CallTracker.View
{
    [DefaultBindingProperty("TextField")]
    public partial class LabelledTextBoxLong : LabelledBase
    {
        [Category("!Textfield")]
        public HorizontalAlignment TextAlign
        {
            get { return _DataField.TextAlign; }
            set { _DataField.TextAlign = value; }
        }

        [Category("!Textfield")]
        public string DefaultText
        {
            get { return _DataField.Text; }
            set { _DataField.Text = value; }
        }

        [Category("!Textfield")]
        public string TextfieldToolTip
        {
            get { return _TextfieldToolTip.GetToolTip(_DataField); }
            set { _TextfieldToolTip.SetToolTip(_DataField, value); }
        }

        [Category("!Textfield")]
        public Color BorderColour
        {
            get { return _DataField.BorderColor; }
            set { _DataField.BorderColor = value; }
        }

        [Category("!Textfield")]
        public bool TFReadOnly
        {
            get { return _DataField.ReadOnly; }
            set { _DataField.ReadOnly = value; }
        }

        [Category("!Textfield")]
        public Cursor TFCursor
        {
            get { return _DataField.Cursor; }
            set { _DataField.Cursor = value; }
        }

        [Category("!Textfield")]
        public Color TFTextColor
        {
            get { return _DataField.ForeColor; }
            set { _DataField.ForeColor = value; }
        }

        [Category("!Textfield")]
        public Color TFBackColor
        {
            get { return _DataField.BackColor; }
            set { _DataField.BackColor = value; }
        }

        [Category("!Textfield")]
        [DefaultValue(true)]
        public bool UseActiveLabel
        {
            get;
            set;
        }

        [Category("!Textfield")]
        [DefaultValue(typeof(Padding), "3,3,3,3")]
        public Padding ControlMargin
        {
            get { return Margin; }
            set { Margin = value; }
        }

        [Category("!Textfield")]
        [Bindable(true)]
        [Browsable(true)]
        public string TextField
        {
            get { return _DataField.Text; }
            set { _DataField.Text = value; }
        }

        public LabelledTextBoxLong()
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
            //this.ContextMenuStripChanged += base.LabelledTextBox_ContextMenuStripChanged;
        }

        private void _DataField_TextChanged(object sender, EventArgs e)
        {
            if (!UseActiveLabel) return;
            if (!String.IsNullOrEmpty(_DataField.Text))
                BackColor = LabelActiveColor;
            else
                BackColor = LabelInactiveColor;
        }

        private void LabelledTextBox_Load(object sender, EventArgs e)
        {
            
            //if (ContextMenuStrip != null)
            //{
            //    this._MenuButton.Show();
            //    this.ContextMenuStrip.Show();
            //    this.ContextMenuStrip.BindingContext = this.ParentForm.BindingContext;
            //}
        }

        //public void FillPolygonPointFillMode(PaintEventArgs e)
        //{

        //    // Create solid brush.
        //    SolidBrush blueBrush = new SolidBrush(Color.White);

        //    // Create points that define polygon.

        //    Point point1 = new Point(this.Height / 2 + 3, this.Width / 2 - 2);
        //    Point point2 = new Point(this.Height / 2, this.Width / 2 + 2);
        //    Point point3 = new Point(this.Height / 2 - 3, this.Width / 2 - 2);
        //    Point point4 = new Point(this.Height / 2 + 3, this.Width / 2 - 2);
       
        //    Point[] curvePoints = { point1, point2, point3, point4};

        //    // Define fill mode.
        //    FillMode newFillMode = FillMode.Winding;

        //    // Draw polygon to screen.
        //    e.Graphics.FillPolygon(blueBrush, curvePoints, newFillMode);
        //}

        private void _MenuButton_Paint(object sender, PaintEventArgs e)
        {

            //FillPolygonPointFillMode(e);
            //base.OnPaint(e);
        }

        private void LabelledTextBoxLong_ContextMenuStripChanged(object sender, EventArgs e)
        {
            _DataField.ContextMenuStrip = ContextMenuStrip;
        }

        private bool _focus;

        private void _DataField_Leave(object sender, EventArgs e)
        {
            _focus = false;
        }

        private void _DataField_MouseDown(object sender, MouseEventArgs e)
        {
            //base.OnMouseDown(e);
            if (_focus) return;

            _DataField.SelectAll();
            _focus = true;
        }

        private void _DataField_KeyUp(object sender, KeyEventArgs e)
        {
            if (DataBindings[0].DataSourceUpdateMode == DataSourceUpdateMode.OnPropertyChanged)
                ParentForm.Validate();
        }
    }

        
}
