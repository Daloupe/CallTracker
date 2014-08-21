using System;
using System.Windows.Forms;

namespace FloatingToolTip
{
    public partial class Form1 : Form
    {
        
        public Form1(string arg)
        {
            InitializeComponent();
            this.Left = Cursor.Position.X - this.Width;
            this.Top = Cursor.Position.Y;
            
                label1.Text = arg;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Opacity = 0.01;
            //label1.Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            for (double value = 1; value <= 100; value += 1)
            {
                this.Opacity += 0.01;
                System.Threading.Thread.Sleep(11 - TOGGLE_EFFECT_SPEED);
            }
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Interval = 200;
            timer1.Stop();
            for (double value = 1; value <= 100; value += 1)
            {
                this.Opacity -= 0.01;
                System.Threading.Thread.Sleep(11 - TOGGLE_EFFECT_SPEED);
            }
            this.Close();
        }

        //private void FadeOut(object sender, EventArgs e)
        //{
        //    this.Top += 1;
        //    this.Opacity -= 1;
        //    this.Invalidate();
        //    if(Opacity == 0)
        //        this.Close();
        //}

        private const int TOGGLE_EFFECT_SPEED = 2;





        //private void blendWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    bool blendIn = (bool)e.Argument;

        //    // Loop through all opacity values
        //    for (double value = 1; value <= 100; value += 1)
        //    {
        //        // Report the current progress on the worker
        //        backgroundWorker1.ReportProgress(0, blendIn ? value : 100 - value);

        //        // Suspends the current thread by the specified blend speed
        //        System.Threading.Thread.Sleep(11 - TOGGLE_EFFECT_SPEED);
        //    }

        //    // Set the worker result as the inverse tag value
        //    e.Result = !blendIn;
        //}

        //private void blendWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    double opValue = (double)e.UserState;

        //    // Show and repaint the whole main notes window?
        //    if (opValue == 1.0)
        //    {
        //        Show();
        //        Invalidate(true);
        //    }

        //    // Set the main notes window opacity value
        //    Opacity = (double)e.UserState / 100;
        //}

        //private void blendWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    bool tagFlag = (bool)e.Result;

        //    // Hide the main notes window?
        //    if (tagFlag)
        //    {
        //        Hide();
        //    }

        //    // Set the main notes window tag value
        //    Tag = tagFlag;
        //}
    }
}
