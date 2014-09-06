using System;
using System.Windows.Forms;
using CallTracker.Helpers;
namespace CallTracker.View
{
    public partial class FadingTooltip : Form
    {
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
                _opacityStep = _fadeTimer.Interval / _fadeTime;
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

        public FadingTooltip()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            FadeOutDelay = 200;
            FadeTime = 350;
            MoveInterval = 2;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT

                return createParams;
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            const int WM_MOUSEACTIVATE = 0x21;
            const int MA_NOACTIVATE = 0x0003;

            switch (m.Msg)
            {
                case WM_MOUSEACTIVATE:
                    m.Result = (IntPtr)MA_NOACTIVATE;
                    return;
            }
            base.DefWndProc(ref m);
        }


        public void ShowandFade(string text)
        {
            label1.Text = text;
            if(Visible)
            {
                _fadeTimer.Stop();
                _timeCounter = 0;
            }

            var point = MousePosition;
            if (Cursor.Current == Cursors.Default || Cursor.Current == Cursors.Arrow)
                point.Offset(11, 0);
            else if (Cursor.Current == Cursors.IBeam)
                point.Offset(7, -8);
            else
                point.Offset(11, 0);
            DesktopLocation = point;

            Opacity = .99;
            WindowHelper.ShowWindow(Handle, 8);
            //Show();
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
