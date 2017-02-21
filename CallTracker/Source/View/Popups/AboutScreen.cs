using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CallTracker.View
{
    public partial class AboutScreen : Form
    {
        public AboutScreen()
        {
            InitializeComponent();
            //if (Program.Optus40 != null)
            //{
            //    Wingman.Font = Program.Optus40;
            //}
            if (!Program.Fonts.Families.Any()) return;
            Wingman.Font = new Font(Program.Fonts.Families[0], 40, FontStyle.Bold);
            WingmanBG.Font = new Font(Program.Fonts.Families[0], 40, FontStyle.Bold);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@".\Change Log.txt");
            Hide();
        }
    }
}
