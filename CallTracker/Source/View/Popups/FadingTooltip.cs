using System;
using System.Windows.Forms;

namespace CallTracker.View
{
    public partial class FadingTooltip : Form
    {
        public FadingTooltip()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void FadingTooltip_Load(object sender, EventArgs e)
        {
            FadeOutDelay = 200;
            FadeTime = 350;
            MoveInterval = 2;
        }

        private int _timeCounter;
        public int FadeOutDelay;
        
        private float _opacityStep;
        private float _fadeTime;
        public float FadeTime 
        {
            get
            {
                return _fadeTime;
            } 
            set 
            { 
                _fadeTime = value;
                _opacityStep = _fadeTimer.Interval /_fadeTime;
            } 
        }

        private int _distanceStep;
        private int _moveInterval;
        public int MoveInterval
        {
            get
            {
                return _moveInterval;
            }
            set
            {
                _moveInterval = value;
                _distanceStep = _fadeTimer.Interval * _moveInterval;
            }
        }

        public void ShowandFade(string text)
        {
            if(Visible)
            {
                _fadeTimer.Stop();
                _timeCounter = 0;
            }
            label1.Text = text;
            var point = MousePosition;
            if (Cursor.Current == Cursors.Default || Cursor.Current == Cursors.Arrow)
                point.Offset(11, 0);
            else if (Cursor.Current == Cursors.IBeam)
                point.Offset(7, -8);
            else
                point.Offset(11, 0);
            //point.Offset(-Width, 0);//-Cursor.Size.Height + Height);
            DesktopLocation = point;
            Opacity = .99;
            Show();
            _fadeTimer.Start();
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            _timeCounter += _fadeTimer.Interval;

            if (_timeCounter < FadeOutDelay) return;
            
            if(Opacity != 0)
                Opacity -= _opacityStep;

            if (_timeCounter % _distanceStep == 0)
                Top -= 1;

            if (_timeCounter < FadeTime + FadeOutDelay) return;  
            _fadeTimer.Stop();
            _timeCounter = 0;
            Hide();
        }
    }
}
