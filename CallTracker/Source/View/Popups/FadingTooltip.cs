using System;
using System.Windows.Forms;

namespace CallTracker.View
{
    public partial class FadingTooltip : Form
    {
        public FadingTooltip()
        {
            InitializeComponent();
        }

        private void FadingTooltip_Load(object sender, EventArgs e)
        {
            FadeOutDelay = 300;
            FadeTime = 250;
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
            label1.Text = text;
            var point = MousePosition;
            
            point.Offset(-Width, -Cursor.Size.Height + Height);
            DesktopLocation = point;
            Opacity = 1;
            Show();
            _fadeTimer.Start();
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            _timeCounter += _fadeTimer.Interval;

            if (_timeCounter < FadeOutDelay) return;
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
