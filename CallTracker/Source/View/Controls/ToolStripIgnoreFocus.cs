using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace CallTracker.View
{
    public class ToolStripMenuIgnoreFocus : MenuStrip
    {
        private Color _borderColor = Color.WhiteSmoke;
        private ButtonBorderStyle _buttonBorderStyle = ButtonBorderStyle.Solid;
        private static int WM_PAINT = 0x000F;
        private const int WM_MOUSEACTIVATE = 0x21;

        public ToolStripMenuIgnoreFocus()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Renderer = new MyRenderer();
            
        }
        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == WM_PAINT)
            //{
            //    var g = Graphics.FromHwnd(Handle);
            //    var bounds = new Rectangle(0, 0, Width - 1, Height - 1);
            //    ControlPaint.DrawBorder(g, bounds, _borderColor, _buttonBorderStyle);
            //}
            if (m.Msg == WM_MOUSEACTIVATE && this.CanFocus && !this.Focused)
                this.Focus();

            base.WndProc(ref m);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.WhiteSmoke,
             0,
             0,
             Width - 1,
             Height - 1);
            base.OnPaint(e);
        }


        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }

        }

        private class MyColors : ProfessionalColorTable
        {
            Color culoare = Color.LightSlateGray;

            public override Color MenuItemSelected
            {
                get { return culoare; }
            }

            public override Color MenuItemBorder
            {
                get { return culoare; }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get { return culoare; }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get { return culoare; }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get { return culoare; }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get { return culoare; }
            }

            public override Color MenuBorder
            {
                get { return culoare; }
            }
        }
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

        //public class TestColorTable : ProfessionalColorTable
        //{
        //    public override Color MenuItemSelected
        //    {
        //        get { return Color.Red; }
        //    }

        //    public override Color MenuBorder  //added for changing the menu border
        //    {
        //        get { return Color.Green; }
        //    }

        //}

        //public ToolStripMenuIgnoreFocus()
        //    : base()
        //{
        //    //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
        //    //UpdateStyles();
        //}

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}
    }
}
