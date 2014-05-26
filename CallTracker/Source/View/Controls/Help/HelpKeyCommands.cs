using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CallTracker.View;
using CallTracker.Model;

namespace CallTracker.View
{
    public partial class HelpKeyCommands : ViewControlBase
    {

        public HelpKeyCommands()
        {
            InitializeComponent();

        }

        public override void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            base.Init(_parent, _menuItem);
     
        }

        protected override void _Done_Click(object sender, EventArgs e)
        {
            base._Done_Click(sender, e);
        }

        protected override void PaintBorder(object sender, PaintEventArgs e)
        {
            base.PaintBorder(sender, e);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

    }
}
