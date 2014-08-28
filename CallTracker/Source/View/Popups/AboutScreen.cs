using System;
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
            if (Program.Fonts.Families.Count() > 0)
                Wingman.Font = new Font(Program.Fonts.Families[0], 40, FontStyle.Bold);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
