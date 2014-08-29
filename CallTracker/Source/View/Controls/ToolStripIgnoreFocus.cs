using System.Windows.Forms;

namespace CallTracker.View
{
    public class ToolStripMenuIgnoreFocus : MenuStrip
    {
        private const int WM_MOUSEACTIVATE = 0x21;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE && this.CanFocus && !this.Focused)
                this.Focus();

            base.WndProc(ref m);
        }

        //public ToolStripMenuIgnoreFocus()
        //    : base()
        //{
        //    //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
        //    //UpdateStyles();
        //}

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}
