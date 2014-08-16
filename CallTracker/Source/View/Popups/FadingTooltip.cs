using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace CallTracker.View
{
    public partial class FadingTooltip : Form
    {
        public FadingTooltip(Point location)
        {
            this.Location = location;
            InitializeComponent();
            
        }

        public void ShowandFade()
        {

            this.Show();
            Util.Animate(this, Util.Effect.Slide, 1000, 90);


            this.Dispose();
            //target.Location = new Point(this.Location.X, this.Location.Y - 50);
            
            
            //slideToDestination(this, target, 50, null);
            
            //BeginInvoke(new EventHandler<EventArgs>(FadeUp),
            //   this,
            //   new EventArgs());
        }
             


        private void FadeUp(object sender, EventArgs e)
        {
            //Util.Animate(this, Util.Effect.Roll, 1000, 90);
        }

        private void FadingTooltip_Load(object sender, EventArgs e)
        {
            
            //this.Location = new Point(500,500);
           
            //this.Opacity = 100;
            
        }
        //private void FadingTooltip_VisibleChanged(object sender, EventArgs e)
        //{
        //    Util.Animate(this, Util.Effect.Blend, 1000, 90);
        //}
    }
    public static class Util
    {
        public enum Effect { Roll, Slide, Center, Blend }

        public static void Animate(Control ctl, Effect effect, int msec, int angle)
        {
            int flags = effmap[(int)effect];
            if (ctl.Visible) { flags |= 0x10000; angle += 180; }
            else
            {
                if (ctl.TopLevelControl == ctl) flags |= 0x20000;
                else if (effect == Effect.Blend) throw new ArgumentException();
            }
            flags |= dirmap[(angle % 360) / 45];
            bool ok = AnimateWindow(ctl.Handle, msec, flags);
            if (!ok) throw new Exception("Animation failed");
            ctl.Visible = !ctl.Visible;
        }

        private static int[] dirmap = { 1, 5, 4, 6, 2, 10, 8, 9 };
        private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

        [DllImport("user32.dll")]
        private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);
    }
    
}
