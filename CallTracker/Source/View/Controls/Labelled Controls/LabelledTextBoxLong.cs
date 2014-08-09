using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CallTracker.View
{
    [DefaultBindingProperty("TextField")]
    public partial class LabelledTextBoxLong : LabelledBase
    {
        [Category("A1")]
        public HorizontalAlignment TextAlign
        {
            get { return _DataField.TextAlign; }
            set { _DataField.TextAlign = value; }
        }

        [Category("A1")]
        public string DefaultText
        {
            get { return _DataField.Text; }
            set { _DataField.Text = value; }
        }

        [Category("A1")]
        public Color BorderColour
        {
            get { return _DataField.BorderColor; }
            set { _DataField.BorderColor = value; }
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
                DefaultValueAttribute attr = (DefaultValueAttribute)prop.Attributes[typeof(DefaultValueAttribute)];
                if (attr != null)
                {
                    prop.SetValue(this, attr.Value);
                }
            }
            this.ContextMenuStripChanged += base.LabelledTextBox_ContextMenuStripChanged;
        }

        private void _DataField_TextChanged(object sender, EventArgs e)
        {
            //this.ParentForm.Validate();
        }

        private void LabelledTextBox_Load(object sender, EventArgs e)
        {
            if (ContextMenuStrip != null)
            {
                this._MenuButton.Show();
                this.ContextMenuStrip.Show();
                this.ContextMenuStrip.BindingContext = this.ParentForm.BindingContext;
            }
        }

        public void FillPolygonPointFillMode(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.White);

            // Create points that define polygon.

            Point point1 = new Point(this.Height / 2 + 3, this.Width / 2 - 2);
            Point point2 = new Point(this.Height / 2, this.Width / 2 + 2);
            Point point3 = new Point(this.Height / 2 - 3, this.Width / 2 - 2);
            Point point4 = new Point(this.Height / 2 + 3, this.Width / 2 - 2);
       
            Point[] curvePoints = { point1, point2, point3, point4};

            // Define fill mode.
            FillMode newFillMode = FillMode.Winding;

            // Draw polygon to screen.
            e.Graphics.FillPolygon(blueBrush, curvePoints, newFillMode);
        }

        private void _MenuButton_Paint(object sender, PaintEventArgs e)
        {

            //FillPolygonPointFillMode(e);
            //base.OnPaint(e);
        }
    }
}
