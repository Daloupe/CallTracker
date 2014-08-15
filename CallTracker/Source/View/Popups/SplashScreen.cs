using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CallTracker.View
{
    public partial class SplashScreen : Form
    {
        Main MainForm;
        
        public SplashScreen()
        {
            InitializeComponent();   
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            _Version.Text = "Version: " + Properties.Settings.Default.Version;
        }
        public void Init(Main _mainForm)
        {
            MainForm = _mainForm;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainForm.quitToolStripMenuItem_Click(sender, e);
            MainForm.CancelLoad = true;
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
            MainForm.Opacity = 100;
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
