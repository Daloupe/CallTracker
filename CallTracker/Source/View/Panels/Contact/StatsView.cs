using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CallTracker.Helpers;
using CallTracker.Model;

namespace CallTracker.View
{
    public partial class StatsView : ViewControlBase
    {
        private readonly StatSection _phoneTotals;
        private readonly StatSection _averages;
        private readonly StatSection _callTotals;

        private StatSection _activeSection;
        public StatSection activeSection
        {
            get { return _activeSection; }
            set
            {
                if(_activeSection != null)
                    _activeSection.Deselect();
                _activeSection = value;
                if (_activeSection != null)
                    _activeSection.Select();
            }
        }
        public StatsView()
        {
            InitializeComponent();

            var fontCount = Program.Fonts.Families.Length;
            if (fontCount > 0)
                _Title.Font = new Font(Program.Fonts.Families[0], 20, FontStyle.Bold);

            _phoneTotals = new StatSection(this, _PHeading, new List<LabelledTextBoxLong> {_PLogin, _PReady, _PNotReady, _PCph, _PCalls});

            _averages = new StatSection(this, _AHeading, new List<LabelledTextBoxLong> {_AReady, _APNotReady, _APHandlingTime,_ACNotReady, _ACHandlingTime, _ACTalkTime, _ACWrapUp, _ACHold});

            _callTotals = new StatSection(this, _CHeading, new List<LabelledTextBoxLong> { _CNotReady, _CHandlingTime, _CTalkTime, _CWrapUp, _CHold});

            activeSection = _averages;
            //currentList = new List<LabelledTextBoxLong>
            //{
            //    _CurrNotReady, _CurrHandlingTime, _CurrTalkTime, _CurrWrapUp, _CurrHold, _CurrCall
            //};
        }


        private void _PHeading_Click(object sender, EventArgs e)
        {
            var section = (StatSection)((BorderedLabel)sender).Parent.Tag;
            activeSection = section;
        }

        private void _Control_MouseEnter(object sender, EventArgs e)
        {
            var section = (StatSection)((BorderedLabel)sender).Parent.Tag;
            section.Highlight();
        }

        private void _Control_MouseLeave(object sender, EventArgs e)
        {
            var section = (StatSection)((BorderedLabel)sender).Parent.Tag;
            section.Unhighlight();
        }

        public override void Init(Main mainForm, ToolStripMenuItem menuItem)
        {
            base.Init(mainForm, menuItem);
        }

        protected override void PaintBorder(object sender, PaintEventArgs e)
        {
            base.PaintBorder(sender, e);
        }
        public override void ShowSetting()
        {
            UpdateStats((DailyModel)MainForm._DailyDataBindingSource.Current);
            base.ShowSetting();      
        }

        public void UpdateStats(DailyModel day)
        {
            var phoneStats = day.ComputeStatistics();
            var callStats = day.CallTotals;

            WindowHelper.SuspendDrawing(this);

            _PLogin._DataField.Text = FormatTimeSpanHMMSS(phoneStats.Login);
            _PReady._DataField.Text = FormatTimeSpanHMMSS(phoneStats.Ready);
            _PNotReady._DataField.Text = FormatTimeSpanHMMSS(phoneStats.NotReady);
            _PCalls._DataField.Text = phoneStats.Calls.ToString(CultureInfo.InvariantCulture);

            _CTalkTime._DataField.Text = FormatTimeSpanHMMSS(callStats.TalkTime);
            _CWrapUp._DataField.Text = FormatTimeSpanHMMSS(callStats.Wrapup);
            _CHold._DataField.Text = FormatTimeSpanHMMSS(callStats.Hold);
            _CHandlingTime._DataField.Text = FormatTimeSpanHMMSS(callStats.HandlingTime);
            _CNotReady._DataField.Text = FormatTimeSpanHMMSS(callStats.NotReady);

            if (MainForm.SelectedContact != null)
            {
                var current = MainForm.SelectedContact.Events.ComputeStatistics();
                _CurrNotReady._DataField.Text = FormatTimeSpanHMMSS(current.NotReady);
                _CurrHold._DataField.Text = FormatTimeSpanHMMSS(current.Hold);
                _CurrTalkTime._DataField.Text = FormatTimeSpanHMMSS(current.TalkTime);
                _CurrHandlingTime._DataField.Text = FormatTimeSpanHMMSS(current.HandlingTime);
                _CurrWrapUp._DataField.Text = FormatTimeSpanHMMSS(current.Wrapup);
                _CurrCall._DataField.Text = (MainForm.editContact.customerContactsBindingSource.Position + 1).ToString(CultureInfo.InvariantCulture);
            }

            if (phoneStats.Calls > 0)
            {
                var aht = new TimeSpan((callStats.HandlingTime + phoneStats.NotReady).Ticks/phoneStats.Calls);
                var cph = Math.Round((3600/aht.TotalSeconds), 2).ToString(CultureInfo.InvariantCulture);
                _PCph._DataField.Text = cph;

                _APHandlingTime._DataField.Text = FormatTimeSpanHMMSS(aht);

                _ACTalkTime._DataField.Text =
                    FormatTimeSpanHMMSS(new TimeSpan(callStats.TalkTime.Ticks/phoneStats.Calls));
                _ACWrapUp._DataField.Text =
                    FormatTimeSpanHMMSS(new TimeSpan(callStats.Wrapup.Ticks/phoneStats.Calls));
                _ACNotReady._DataField.Text =
                    FormatTimeSpanHMMSS(new TimeSpan(callStats.NotReady.Ticks/phoneStats.Calls));
                _ACHold._DataField.Text =
                    FormatTimeSpanHMMSS(new TimeSpan(callStats.Hold.Ticks/phoneStats.Calls));
                _ACHandlingTime._DataField.Text =
                    FormatTimeSpanHMMSS(new TimeSpan(callStats.HandlingTime.Ticks/phoneStats.Calls));
                _AReady._DataField.Text =
                    FormatTimeSpanHMMSS(new TimeSpan(phoneStats.Ready.Ticks/phoneStats.Calls));
                _APNotReady._DataField.Text =
                    FormatTimeSpanHMMSS(new TimeSpan((callStats.NotReady + phoneStats.NotReady).Ticks/phoneStats.Calls));
            }

            WindowHelper.ResumeDrawing(this);
        }

        private static string TimeSpanToHour(TimeSpan time)
        {
            return Math.Round((time.TotalMinutes / 60), 2).ToString(CultureInfo.InvariantCulture);
        }

        private static string FormatTimeSpanHMMSS(TimeSpan time)
        {
            if (time.TotalMinutes > 20)
                return Math.Round((time.TotalMinutes / 60),2).ToString(CultureInfo.InvariantCulture);

            return Math.Round(time.TotalSeconds, 0).ToString(CultureInfo.InvariantCulture);

            //String.Format("{0}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);
            //String.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
            //return String.Format("{0:0}:{1:00}", time.Minutes, time.Seconds);
        }

        private static string FormatTimeSpanSeconds(TimeSpan time)
        {
            return String.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
        }

        public override void HideSetting()
        {
            base.HideSetting();  
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            base._Done_Click(sender, e);
        }

        protected override void _Done_Click(object sender, EventArgs e)
        {
            base._Done_Click(sender, e);
        }

        public class StatSection
        {
            private readonly List<LabelledTextBoxLong> _controls;
            private readonly LabelledHeading _heading;
            //private LabelledHeading ClickMap;
            private bool _active;
            private bool _highlighted;

            private readonly StatsView _parentView;

            public StatSection(StatsView parentView, LabelledHeading heading, List<LabelledTextBoxLong> controls)
            {
                _controls = controls;
                foreach (var control in _controls)
                {
                    control.LabelClick += Section_Click;
                    control.LabelMouseEnter += _Control_MouseEnter;
                    control.LabelMouseLeave += _Control_MouseLeave;
                }

                _heading = heading;
                _heading.LabelClick += Section_Click;
                _heading.LabelMouseEnter += _Control_MouseEnter;
                _heading.LabelMouseLeave += _Control_MouseLeave;

                //ClickMap = clickMap;
                //ClickMap.LabelClick += Section_Click;
                //ClickMap.MouseEnter += _Control_MouseEnter;

                _active = false;
                _highlighted = false;

                _parentView = parentView;
            }

            private void Section_Click(object sender, EventArgs e)
            {
                _parentView.activeSection = this;
            }

            private void _Control_MouseEnter(object sender, EventArgs e)
            {
                Highlight();
            }

            private void _Control_MouseLeave(object sender, EventArgs e)
            {
                Unhighlight();
            }

            public void Highlight()
            {
                if (_active || _highlighted) return;
                _heading.BackColor = Color.FromArgb(67, 130, 134);
                //Heading.LabelMouseEnter -= _Control_MouseEnter;
                //Heading.LabelMouseLeave += _Control_MouseLeave;

                foreach (var control in _controls)
                {
                    control.BackColor = Color.FromArgb(67, 130, 134);
                    //control.LabelMouseEnter -= _Control_MouseEnter;
                    //control.LabelMouseLeave += _Control_MouseLeave;
                }

                //ClickMap.LabelMouseEnter -= _Control_MouseEnter;
                //ClickMap.LabelMouseLeave += _Control_MouseLeave;
                _highlighted = true;
            }

            public void Unhighlight()
            {
                var color = _active ? Color.DarkSlateGray : Color.FromArgb(83, 173, 179);
                _heading.BackColor = color;
                //Heading.LabelMouseEnter += _Control_MouseEnter;
                //Heading.LabelMouseLeave -= _Control_MouseLeave;

                foreach (var control in _controls)
                {
                    control.BackColor = color;
                    //control.LabelMouseEnter += _Control_MouseEnter;
                    //control.LabelMouseLeave -= _Control_MouseLeave;
                }

                //ClickMap.LabelMouseEnter += _Control_MouseEnter;
                //ClickMap.LabelMouseLeave -= _Control_MouseLeave;
                _highlighted = false;
            }

            public void Select()
            {
                if (_active) return;

                _heading.BackColor = Color.DarkSlateGray;
                //Heading.LabelClick -= Section_Click;

                foreach (var control in _controls)
                {
                    control.TFBackColor = Color.White;
                    control.TFTextColor = Color.Black;
                    control.BorderColour = Color.DarkSlateGray;
                    control.BackColor = Color.DarkSlateGray;
                    control.LabelBorderColor = Color.DarkSlateGray;
                    //control.LabelClick -= Section_Click;
                }

                //ClickMap.LabelClick -= Section_Click;
                _active = true;
            }

            public void Deselect()
            {
                _heading.BackColor = Color.FromArgb(83, 173, 179);
                //Heading.LabelClick += Section_Click;

                foreach (var control in _controls)
                {
                    control.TFBackColor = Color.FromArgb(236, 240, 242);
                    control.TFTextColor = Color.LightSlateGray;
                    control.BorderColour = Color.White;
                    control.BackColor = Color.FromArgb(83, 173, 179);
                    control.LabelBorderColor = Color.FromArgb(236, 240, 242);
                    //control.LabelClick += Section_Click;
                }

                //ClickMap.LabelClick += Section_Click;
                _active = false;
            }
        }
    }
}
