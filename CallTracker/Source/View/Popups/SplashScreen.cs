using System;

using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

using System.IO;

namespace CallTracker.View
{
    public partial class SplashScreen : Form
    {
        Main _mainForm;
        
        public SplashScreen()
        {
            InitializeComponent();
            var fontCount = Program.Fonts.Families.Count();
            if (fontCount > 0)
                Wingman.Font = new Font(Program.Fonts.Families[0], 40, FontStyle.Bold);
            if (fontCount > 1)
                _LoadingText.Font = new Font(Program.Fonts.Families[1], 12, FontStyle.Regular);
     
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            //_Version.Text = Properties.Settings.Default.Version;
        }
        public void Init(Main mainForm)
        {
            _mainForm = mainForm; 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _mainForm.quitToolStripMenuItem_Click(sender, e);
            _mainForm.CancelLoad = true;
        }

        public void UpdateProgress(string _update, int _value)
        {
            _LoadingText.Text = _update;
            _LoadingBar.Value = _value;
            Application.DoEvents();
        }
        public void StepProgress()
        {
            _LoadingBar.PerformStep();
        }
        public void StepProgress(string _update)
        {
            _LoadingText.Text = _update;
            _LoadingBar.PerformStep();
            Application.DoEvents();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(2, 188, 201)),
             0,
             0,
             ((Control)sender).Width - 1,
             ((Control)sender).Height - 1);
            base.OnPaint(e);
        }

        public void pictureBox3_Click(object sender, EventArgs e)
        {
            _mainForm.Opacity = 100;
            this.Close();      
        }

        private void SplashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        public void ShowLogins()
        {
            timer1.Enabled = true;

        }

        private void _SetupLoginsPanel_VisibleChanged(object sender, EventArgs e)
        {
            
        }
    }
}
