using System;
using System.Windows.Forms;

namespace CallTracker.View
{
    public partial class CustomDgv : DataGridView
    {

        private const int CAPTIONHEIGHT = 21;
        private const int BORDERWIDTH = 2;

        public CustomDgv()
        {
            InitializeComponent();

            //// make scrollbar visible & add handler
            //int width = VerticalScrollBar.Width;

            //VerticalScrollBar.Location =
            //new Point(ClientRectangle.Width - width - BORDERWIDTH, CAPTIONHEIGHT);

            //VerticalScrollBar.Size =
            //new Size(width, ClientRectangle.Height - CAPTIONHEIGHT - BORDERWIDTH);

            //VerticalScrollBar.Visible = true;

            VerticalScrollBar.VisibleChanged += new EventHandler(VerticalScrollBar_VisibleChanged);
        }

        void VerticalScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            VerticalScrollBar.Visible = true;
            //if (!VerticalScrollBar.Visible)
            //{
            //    int width = VerticalScrollBar.Width;

            //    VerticalScrollBar.Location =
            //    new Point(ClientRectangle.Width - width - BORDERWIDTH, CAPTIONHEIGHT);

            //    VerticalScrollBar.Size =
            //    new Size(width, ClientRectangle.Height - CAPTIONHEIGHT - BORDERWIDTH);

            //    VerticalScrollBar.Visible = true;
            //}
        }
    }
    
}
