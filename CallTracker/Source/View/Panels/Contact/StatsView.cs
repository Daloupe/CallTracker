using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CallTracker.Model;


using CallTracker.Helpers;

namespace CallTracker.View
{
    public partial class StatsView : ViewControlBase
    {
        private readonly StatSection _phoneTotals;
        private readonly StatSection _averages;
        private readonly StatSection _callTotals;
        //private readonly List<LabelledTextBoxLong> _phoneTotalsList;
        //private readonly List<LabelledTextBoxLong> _averagesList;
        //private readonly List<LabelledTextBoxLong> _callTotalsList;
        //private List<LabelledTextBoxLong> currentList;

        //private LabelledHeading _activeHeading;
        //private LabelledHeading ActiveHeading
        //{
        //    get { return _activeHeading; }
        //    set
        //    {
        //        if (_activeHeading != null)
        //        {
        //            _activeHeading.BackColor = Color.FromArgb(83, 173, 179);
        //            _activeHeading.LabelBorderColor = Color.LightSeaGreen;
        //            _activeHeading.LabelActiveColor = Color.FromArgb(83, 173, 179);
        //        }

        //        _activeHeading = value;

        //        _activeHeading.BackColor = Color.DarkSlateGray;
        //        _activeHeading.LabelBorderColor = Color.DarkSlateGray;
        //        _activeHeading.LabelActiveColor = Color.DarkSlateGray;
        //    }
        //}

        //private List<LabelledTextBoxLong> _activeList;
        //private List<LabelledTextBoxLong> ActiveList
        //{
        //    get { return _activeList; }
        //    set
        //    {
        //        if (_activeList != null)
        //        {
        //            foreach (var control in _activeList)
        //            {
        //                control.TFBackColor = Color.FromArgb(236, 240, 242);
        //                control.TFTextColor = Color.LightGray;
        //                control.BorderColour = Color.White;
        //                control.BackColor = Color.FromArgb(83, 173, 179);
        //                control.LabelBorderColor = Color.LightSeaGreen;
        //                control.LabelActiveColor = Color.FromArgb(83, 173, 179);
        //            }
        //        }

        //        _activeList = value;
                
        //        foreach (var control in _activeList)
        //        {
        //            control.TFBackColor = Color.White;
        //            control.TFTextColor = Color.Black;
        //            control.BorderColour = Color.DarkSlateGray;
        //            control.BackColor = Color.DarkSlateGray;
        //            control.LabelBorderColor = Color.DarkSlateGray;
        //            control.LabelActiveColor = Color.DarkSlateGray;
        //        }
        //    }
        //}

        private StatSection _activeSection;

        private StatSection activeSection
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

            _phoneTotals = new StatSection(new List<LabelledTextBoxLong> {_PLogin, _PReady, _PNotReady, _PCalls}, _PHeading);

            _averages = new StatSection(new List<LabelledTextBoxLong> {_AReady, _APNotReady, _APHandlingTime,_ACNotReady, _ACHandlingTime, _ACTalkTime, _ACWrapUp, _ACHold},_AHeading);

            _callTotals = new StatSection(new List<LabelledTextBoxLong> { _CNotReady, _CHandlingTime, _CTalkTime, _CWrapUp, _CHold}, _CHeading);

            activeSection = _averages;

            //_phoneTotalsList = new List<LabelledTextBoxLong>
            //{
            //    _PLogin, _PReady, _PNotReady, _PCalls
            //};
            //_phoneTotalsList.ForEach(x => x.Tag = _phoneTotalsList);
            //_PHeading.Tag = _phoneTotalsList;

            //_averagesList = new List<LabelledTextBoxLong>
            //{
            //    _AReady, _APNotReady, _APHandlingTime,
            //    _ACNotReady, _ACHandlingTime, _ACTalkTime, _ACWrapUp, _ACHold
            //};
            //_averagesList.ForEach(x => x.Tag = _averagesList);
            //_AHeading.Tag = _averagesList;

            //_callTotalsList = new List<LabelledTextBoxLong>
            //{
            //    _CNotReady, _CHandlingTime, _CTalkTime, _CWrapUp, _CHold
            //};
            //_callTotalsList.ForEach(x => x.Tag = _callTotalsList);
            //_CHeading.Tag = _callTotalsList;

            //ActiveHeading = _AHeading;
            //ActiveList = _averagesList;
            //currentList = new List<LabelledTextBoxLong>
            //{
            //    _CurrNotReady, _CurrHandlingTime, _CurrTalkTime, _CurrWrapUp, _CurrHold, _CurrCall
            //};
        }

        //public bool PreFilterMessage(ref Message m)
        //{
        //    if (m.Msg == WindowHelper.WM_LBUTTONDOWN)
        //    {
        //        var pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
        //        var hWnd = WindowHelper.WindowFromPoint(pos);
        //        if (hWnd != IntPtr.Zero && hWnd != m.HWnd && FromHandle(hWnd) != null)
        //        {
        //            WindowHelper.SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public override void Init(Main mainForm, ToolStripMenuItem menuItem)
        {
            base.Init(mainForm, menuItem);
            //_DateSelect._ComboBox.DataSource = MainForm.DateBindingSource;
            //_DateSelect._ComboBox.DisplayMember = "ShortDate";
            //_DateSelect._ComboBox.ValueMember = "LongDate";
            

            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        protected override void PaintBorder(object sender, PaintEventArgs e)
        {
            base.PaintBorder(sender, e);
        }

        private void propertyLock_CheckedChanged(object sender, EventArgs e)
        {
            //flowLayoutPanel1.Enabled = !propertyLock.Checked;
        }

        //private int _position;
        public override void ShowSetting()
        {
            var average = TimeSpan.Zero;
            var day = (DailyModel) MainForm._DailyDataBindingSource.Current;
            var phoneStats = day.ComputeStatistics();
            var callStats = day.CallTotals;


            _PLogin._DataField.Text = FormatTimeSpanHMMSS(phoneStats.Login);
            _PCalls._DataField.Text = phoneStats.Calls.ToString();
            _PNotReady._DataField.Text = FormatTimeSpanHMMSS(phoneStats.NotReady);
            _PReady._DataField.Text = FormatTimeSpanHMMSS(phoneStats.Ready);

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
                _CurrCall._DataField.Text = (MainForm.editContact.customerContactsBindingSource.Position + 1).ToString();
            }

            if (phoneStats.Calls > 0)
            {
                _ACTalkTime._DataField.Text = FormatTimeSpanHMMSS(new TimeSpan(
                    callStats.TalkTime.Ticks / phoneStats.Calls));

                _ACWrapUp._DataField.Text = FormatTimeSpanHMMSS(new TimeSpan(
                    callStats.Wrapup.Ticks / phoneStats.Calls));

                _ACNotReady._DataField.Text = FormatTimeSpanHMMSS(new TimeSpan(
                    callStats.NotReady.Ticks / phoneStats.Calls));

                _ACHold._DataField.Text = FormatTimeSpanHMMSS(new TimeSpan(
                    callStats.Hold.Ticks / phoneStats.Calls));

                _ACHandlingTime._DataField.Text = FormatTimeSpanHMMSS(new TimeSpan(
                    callStats.HandlingTime.Ticks / phoneStats.Calls));


                _AReady._DataField.Text = FormatTimeSpanHMMSS(new TimeSpan(
                    phoneStats.Ready.Ticks / phoneStats.Calls));

                _APHandlingTime._DataField.Text = FormatTimeSpanHMMSS(new TimeSpan(
                    (callStats.HandlingTime + phoneStats.NotReady).Ticks / phoneStats.Calls));

                _APNotReady._DataField.Text = FormatTimeSpanHMMSS(new TimeSpan(
                    (callStats.NotReady + phoneStats.NotReady).Ticks / phoneStats.Calls));
            }

            base.ShowSetting();      
        }

        private static string FormatTimeSpanHMMSS(TimeSpan time)
        {
            if (time.Hours > 0)
                return String.Format("{0}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);
            if (time.Minutes > 9)
                return String.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
            
            return String.Format("{0:0}:{1:00}", time.Minutes, time.Seconds);
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

        private void _PHeading_Click(object sender, EventArgs e)
        {
            var section = (StatSection)((BorderedLabel)sender).Parent.Tag;
            activeSection = section;
            //ActiveHeading = _PHeading;
            //ActiveList = _phoneTotalsList;
        }

        //private void _AHeading_Click(object sender, EventArgs e)
        //{
        ////    ActiveHeading = _AHeading;
        ////    ActiveList = _averagesList;
        //}

        //private void _CHeading_Click(object sender, EventArgs e)
        //{
        //    //ActiveHeading = _CHeading;
        //    //ActiveList = _callTotalsList;
        //}

        //private void _Heading_MouseEnter(object sender, EventArgs e)
        //{
        //    var heading = (LabelledHeading)((BorderedLabel)sender).Parent;
        //    if (heading != ActiveHeading)
        //        heading.BackColor = Color.FromArgb(67, 130, 134);
        //}

        //private void _Heading_MouseLeave(object sender, EventArgs e)
        //{
        //    var heading = (LabelledHeading)((BorderedLabel)sender).Parent;
        //    heading.BackColor = heading == ActiveHeading ? Color.DarkSlateGray : Color.FromArgb(83, 173, 179);
        //}

        //private static void Highlight(IEnumerable<LabelledTextBoxLong> list)
        //{
        //    foreach (var control in list)
        //    {
        //        control.BackColor = Color.FromArgb(67, 130, 134);
        //    }
        //}

        //private static void UnHighlight(IEnumerable<LabelledTextBoxLong> list, Color color)
        //{
        //    foreach (var control in list)
        //    {
        //        control.BackColor = color;
        //    }
        //}

        private void _Control_MouseEnter(object sender, EventArgs e)
        {
            var section = (StatSection)((BorderedLabel)sender).Parent.Tag;
            section.Highlight();
            //if(list != ActiveList)
            //    Highlight(list);
        }

        private void _Control_MouseLeave(object sender, EventArgs e)
        {
            var section = (StatSection)((BorderedLabel)sender).Parent.Tag;
            section.Unhighlight();
            //var list = ((BorderedLabel)sender).Parent.Tag as List<LabelledTextBoxLong>;
            //UnHighlight(list, list == ActiveList ? Color.DarkSlateGray : Color.FromArgb(83, 173, 179));
        }

        public class StatSection
        {
            public List<LabelledTextBoxLong> Controls;
            public LabelledHeading Heading;
            public bool Active;

            public StatSection(List<LabelledTextBoxLong> controls, LabelledHeading heading)
            {
                Controls = controls;
                Controls.ForEach(x => x.Tag = this);
                Heading = heading;
                Heading.Tag = this;
                Active = false;
            }

            public void Highlight()
            {
                if (Active) return;
                Heading.BackColor = Color.FromArgb(67, 130, 134);
                foreach (var control in Controls)
                {
                    control.BackColor = Color.FromArgb(67, 130, 134);
                }
            }

            public void Unhighlight()
            {
                var color = Active ? Color.DarkSlateGray : Color.FromArgb(83, 173, 179);
                Heading.BackColor = color;
                foreach (var control in Controls)
                {
                    control.BackColor = color;
                }
            }

            public void Select()
            {
                Heading.BackColor = Color.DarkSlateGray;
                //Heading.LabelBorderColor = Color.DarkSlateGray;
                //Heading.LabelActiveColor = Color.DarkSlateGray;

                foreach (var control in Controls)
                {
                    control.TFBackColor = Color.White;
                    control.TFTextColor = Color.Black;
                    control.BorderColour = Color.DarkSlateGray;
                    control.BackColor = Color.DarkSlateGray;
                    control.LabelBorderColor = Color.DarkSlateGray;
                    control.LabelActiveColor = Color.DarkSlateGray;
                }

                Active = true;
            }

            public void Deselect()
            {
                Heading.BackColor = Color.FromArgb(83, 173, 179);
                //Heading.LabelBorderColor = Color.LightSeaGreen;
                //Heading.LabelActiveColor = Color.FromArgb(83, 173, 179);

                foreach (var control in Controls)
                {
                    control.TFBackColor = Color.FromArgb(236, 240, 242);
                    control.TFTextColor = Color.LightSlateGray;
                    control.BorderColour = Color.White;
                    control.BackColor = Color.FromArgb(83, 173, 179);
                    control.LabelBorderColor = Color.FromArgb(236, 240, 242);//.LightSeaGreen;
                    control.LabelActiveColor = Color.FromArgb(83, 173, 179);
                }

                Active = false;
            }
        }
    }
}
