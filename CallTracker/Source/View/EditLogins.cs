using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CallTracker.View;
using CallTracker.Model;

namespace CallTracker.View
{
    public partial class EditLogins : UserControl
    {
        public EditLogins()
        {
            InitializeComponent();
        }

        public void Init(Main _parent)
        {
            loginsModelBindingSource.DataSource = _parent.DataStore.Logins;
            this.Visible = true;
            this.SendToBack();
            this.Visible = false;
            this.BringToFront();
        }

        private void _Done_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void PaintGrayBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Gainsboro,
              e.ClipRectangle.Left,
              e.ClipRectangle.Top,
              e.ClipRectangle.Width - 1,
              e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }
    }
}
