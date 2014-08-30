using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace CallTracker.View
{
    public class MyPanel : Panel
    {
        //private Color _borderColor = Color.WhiteSmoke;
        //private ButtonBorderStyle _buttonBorderStyle = ButtonBorderStyle.Solid;
        //private static int WM_PAINT = 0x000F;
        public MyPanel()
        {
            SetStyle(ControlStyles.DoubleBuffer, true); //ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | 
            //BorderStyle = BorderStyle.FixedSingle;

            //BorderColor = Color.WhiteSmoke;
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}

        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);

        //    if (m.Msg == WM_PAINT)
        //    {
        //        Graphics g = Graphics.FromHwnd(Handle);
        //        Rectangle bounds = new Rectangle(0, 0, Width, Height);
        //        ControlPaint.DrawBorder(g, bounds, BorderColor, _buttonBorderStyle);
        //    }
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    e.Graphics.DrawRectangle(Pens.Blue,
        //     0,
        //     0,
        //     Width + 1,
        //     Height + 1);

        //}

        //[Category("Appearance")]
        //public Color BorderColor
        //{
        //    get { return _borderColor; }
        //    set
        //    {
        //        _borderColor = value;
        //        Invalidate(); // causes control to be redrawn
        //    }
        //}   
    }

    public class MyFlowLayoutPanel : FlowLayoutPanel
    {
        //public MyFlowLayoutPanel()
        //{
        //    SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        //}
    }
}
