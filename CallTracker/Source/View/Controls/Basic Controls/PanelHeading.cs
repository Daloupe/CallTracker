using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CallTracker.View
{
    public partial class PanelHeading : UserControl
    {
        public PanelHeading()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        [Category("A1")]
        public string LabelText 
        {
            get { return _Label.Text; }
            set { _Label.Text = value; }
        }

        private void PaintGrayBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.WhiteSmoke,
             -1,
             -1,
             ((Control)sender).Width + 1,
             ((Control)sender).Height + 1);
            base.OnPaint(e);
        }
    }
}
