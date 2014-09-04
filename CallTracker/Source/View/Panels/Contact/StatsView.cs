using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CallTracker.Helpers;
using CallTracker.Model;

namespace CallTracker.View
{
    public partial class StatsView : ViewControlBase
    {
        //private int CurrentPosition;

        public StatsView()
        {
            InitializeComponent();
        }

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

        private int _position;
        public override void ShowSetting()
        {
            var average = TimeSpan.Zero;
            var day = (DailyModel) MainForm._DailyDataBindingSource.Current;
            var stats = day.ComputeStatistics();

            _Login._DataField.Text = String.Format("{0}:{1:00}:{2:00}", stats.Login.Hours, stats.Login.Minutes, stats.Login.Seconds);
            _Calls._DataField.Text = stats.Calls.ToString();

            _TalkTime._DataField.Text = String.Format("{0}:{1:00}:{2:00}", stats.TalkTime.Hours, stats.TalkTime.Minutes, stats.TalkTime.Seconds);
            average = new TimeSpan(stats.TalkTime.Ticks/stats.Calls);

            Console.WriteLine(stats.TalkTime);
            Console.WriteLine(average);
            _TalkTimeA._DataField.Text = String.Format("{0}:{1:00}:{2:00}", average.Hours, average.Minutes, average.Seconds);
            
            _WrapUp._DataField.Text = String.Format("{0}:{1:00}:{2:00}", stats.Wrapup.Hours, stats.Wrapup.Minutes, stats.Wrapup.Seconds);
            average = new TimeSpan(stats.Wrapup.Ticks / stats.Calls);
            _WrapUpA._DataField.Text = String.Format("{0}:{1:00}:{2:00}", average.Hours, average.Minutes, average.Seconds);
            
            _NotReady._DataField.Text = String.Format("{0}:{1:00}:{2:00}", stats.NotReady.Hours, stats.NotReady.Minutes, stats.NotReady.Seconds);
            average = new TimeSpan(stats.NotReady.Ticks / stats.Calls);
            _NotReadyA._DataField.Text = String.Format("{0}:{1:00}:{2:00}", average.Hours, average.Minutes, average.Seconds);
            
            _Ready._DataField.Text = String.Format("{0}:{1:00}:{2:00}", stats.Ready.Hours, stats.Ready.Minutes, stats.Ready.Seconds);
            average = new TimeSpan(stats.Ready.Ticks / stats.Calls);
            _ReadyA._DataField.Text = String.Format("{0}:{1:00}:{2:00}", average.Hours, average.Minutes, average.Seconds);
            
            _HandlingTime._DataField.Text = String.Format("{0}:{1:00}:{2:00}", stats.HandlingTime.Hours, stats.HandlingTime.Minutes, stats.HandlingTime.Seconds);
            average = new TimeSpan(stats.HandlingTime.Ticks / stats.Calls);
            _HandlingTimeA._DataField.Text = String.Format("{0}:{1:00}:{2:00}", average.Hours, average.Minutes, average.Seconds);
            
            //bindingSource1 = MainForm.editContact.customerContactsBindingSource;

            //CurrentPosition = MainForm.editContact.customerContactsBindingSource.Position;
            //_position = MainForm.DateBindingSource.Position;

            base.ShowSetting();      
        }

        public override void HideSetting()
        {
            //bindingSource1 = null;

            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            base.HideSetting();  
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //MainForm.DateBindingSource.Position = _position;

            ////dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

            //if (MainForm.editContact.customerContactsBindingSource.Count > 0)
            //    MainForm.editContact.customerContactsBindingSource.Position = CurrentPosition;
            base._Done_Click(sender, e);
        }

        protected override void _Done_Click(object sender, EventArgs e)
        {
            base._Done_Click(sender, e);
        }

    }
}
