using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CallTracker.Model;
using Equin.ApplicationFramework;
using ProtoBuf.Meta;

using PropertyChanged;
using ProtoBuf;

namespace CallTracker.View
{
    public partial class CallHistory : ViewControlBase
    {
        private int CurrentPosition;

        public CallHistory()
        {
            InitializeComponent();
            //dgv = dataGridView1;
            dataGridView1.DataError += dataGridView1_DataError;
            //dataGridView1.CellClick += dataGridView1_CellClick;

           // dataGridView1.AutoGenerateColumns = false;

           // dataGridView1.Columns.Add("Date", "Date");
           // //dataGridView1.Columns.Add("Time", "Time");
           // dataGridView1.Columns.Add("Name", "Name");

           // dataGridView1.Columns["Date"].DataPropertyName = "ContactDateTime";
           // dataGridView1.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
           // dataGridView1.Columns["Date"].MinimumWidth = 90;
           // dataGridView1.Columns["Date"].FillWeight = 90;
           // dataGridView1.Columns["Date"].Width = 90;
           // dataGridView1.Columns["Date"].ReadOnly = true;
            
           // //dataGridView1.Columns["Date"].SortMode = DataGridViewColumnSortMode.NotSortable;

           // //dataGridView1.Columns["Time"].DataPropertyName = "ContactTime";
           // //dataGridView1.Columns["Time"].Width = 35;
           // //dataGridView1.Columns["Time"].ReadOnly = true;
           // //dataGridView1.Columns["Time"].SortMode = DataGridViewColumnSortMode.NotSortable;

           // dataGridView1.Columns["Name"].DataPropertyName = "name";
           // dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
           // dataGridView1.Columns["Name"].MinimumWidth = 185;
           // dataGridView1.Columns["Name"].FillWeight = 185;
           // dataGridView1.Columns["Name"].ReadOnly = true;
            

           // DataGridViewComboBoxColumn dtcol = new DataGridViewComboBoxColumn();
           // dataGridView1.Columns.Add(dtcol);
           // dtcol.DataPropertyName = "GetOutcome";
           // dtcol.Name = "Outcome";
           // dtcol.HeaderText = "Outcome";
           // dtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           // dtcol.MinimumWidth = 40;
           // dtcol.FillWeight = 88;
           // dtcol.SortMode = DataGridViewColumnSortMode.Automatic;
           // dtcol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
           // dtcol.ReadOnly = false;
           // dtcol.DataSource = Main.ServicesStore.servicesDataSet.Outcomes.Select(x => x.Acronym).ToList();

           //// dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //private static List<DateFilterItem> _dateFilterItems = new List<DateFilterItem> { new DateFilterItem("All") };

        public override void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            base.Init(_parent, _menuItem);
            bindingSource1 = MainForm.editContact.customerContactsBindingSource;//MainForm._DailyDataBindingSource;//
            //bindingSource1.DataMember = "Contacts";

            //_DateSelect._ComboBox.DataSource = MainForm.editContact._DateSelector.ComboBox.DataSource;

            callHistoryPanel1.SetBindingSource(bindingSource1);//MainForm.editContact.customerContactsBindingSource);//bindingSource1);//
            dataGridView1.DataSource = bindingSource1;//MainForm.editContact.customerContactsBindingSource; //bindingSource1;//

            //bindingSource1.Sort = "ContactDateTime ASC";
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

        private string _filter;
        private int _position;
        //private bool _opening;
        public override void ShowSetting()
        {
            CurrentPosition = MainForm.editContact.customerContactsBindingSource.Position;
            _position = MainForm.DateBindingSource.Position;
            //dataGridView1.Rows[CurrentPosition].Selected = true;
            //_filter = MainForm._DailyDataBindingSource.Filter;//MainForm.ContactsDataStore.Contacts.Filter;
            //_emptyFilter = MainForm._DailyDataBindingSource.Count == 0 ? true : false;//MainForm.editContact.customerContactsBindingSource.Count == 0 ? true : false;

            //if (MainForm.DailyData.TotalCount > 0)//MainForm.ContactsDataStore.Contacts.TotalCount > 0)
            //{
            //    _opening = true;
            //    //var newDateFilterItems = MainForm.editContact.comboBox1.DataSource;
            //    ////var newDateFilterItems = new List<DateFilterItem> { new DateFilterItem("All") };
            //    ////newDateFilterItems.AddRange(MainForm.ContactsDataStore.Contacts.AllItems
            //    ////    .Select(x => x.Contacts.StartDate)
            //    ////    .Distinct()
            //    ////    .Select(y => new DateFilterItem(y)));

            //    //_DateSelect._ComboBox.DataSource = newDateFilterItems;
            //    //_DateSelect._ComboBox.DisplayMember = "ShortDate";
            //    //_DateSelect._ComboBox.ValueMember = "LongDate";

                

            //    //_DateSelect._ComboBox.SelectedValue = ((DailyModel)MainForm._DailyDataBindingSource.Current).Date;

            //    _opening = false;
            //    //if (MainForm.DailyData.IsFiltered)
            //    //    _DateSelect._ComboBox.SelectedValue = ((DailyModel) MainForm._DailyDataBindingSource.Current).Date;
            //    //        //MainForm.SelectedContact.Contacts.StartDate.ToString("dd/MM");
            //    ////else if (MainForm.ContactsDataStore.Contacts.IsFiltered && _emptyFilter)
            //    ////    _DateSelect._ComboBox.Text = DateTime.Today.ToString("dd/MM");
            //    //else
            //    //    _DateSelect._ComboBox.SelectedIndex = 0;
            //}
           // dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
            base.ShowSetting();
            
        }

        public override void HideSetting()
        {
            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            //bindingSource1.Sort = "ContactDateTime ASC";

            base.HideSetting();  
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //if (!String.IsNullOrEmpty(_filter))
            //    MainForm._DailyDataBindingSource.Filter = _filter;//MainForm.editContact.customerContactsBindingSource.Filter = _filter;

            MainForm.DateBindingSource.Position = _position;
            //MainForm.editContact.customerContactsBindingSource.Position = CurrentPosition;

            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            //bindingSource1.Sort = "ContactDateTime ASC";

            if (MainForm.editContact.customerContactsBindingSource.Count > 0)
                MainForm.editContact.customerContactsBindingSource.Position = CurrentPosition;// MainForm.editContact.customerContactsBindingSource.Position = CurrentPosition;

            base._Done_Click(sender, e);
        }

        protected override void _Done_Click(object sender, EventArgs e)
        {
            //MainForm.editContact.customerContactsBindingSource.Position = bindingSource1.Position;

            //MainForm.editContact._CallMenuButton.Text = _DateSelect._ComboBox.Text;

            base._Done_Click(sender, e);
        }


        private void dataGridView1_DataError(object sender,DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is  
            // commited, display an error message. 
            //Console.WriteLine("Error");
            if (e.Exception != null &&
                e.Context == DataGridViewDataErrorContexts.Commit)
            {
                EventLogger.LogNewEvent("Error: "+this.Name+" couldn't commit data to cell");
            }
        }

        private void _ClearHistory_Click(object sender, EventArgs e)
        {
           // _filter = String.Empty;

            MainForm.editContact.DeleteCalls();

            //var dates = new List<DateFilterItem> { new DateFilterItem("All") };
            //_DateSelect._ComboBox.DataSource = dates;
            //_DateSelect._ComboBox.SelectedIndex = 0;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MainForm.editContact.DeleteCalls();
                e.Cancel = true;
            }
            //else if (bindingSource1.Position == e.Row.Index)
            //{
            //    bindingSource1.Position -= 1;
            //}
        }

        //private void _DateSelect_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (MainForm._DailyDataBindingSource == null || _opening) return;//MainForm.editContact.customerContactsBindingSource == null || _opening) return;

        //    //MainForm._DailyDataBindingSource.Filter = "Date = " + _DateSelect._ComboBox.SelectedValue;

        //    ////if (_DateSelect._ComboBox.Text == "All" || String.IsNullOrEmpty(_DateSelect._ComboBox.Text))
        //    ////    MainForm.editContact.FilterCalls();
        //    ////else
        //    ////    MainForm.editContact.FilterCalls(_DateSelect._ComboBox.SelectedValue.ToString());
        //   // dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        //    //bindingSource1.Sort = "ContactDateTime ASC";
        //    //bindingSource1.ApplySort(TypeDescriptor.GetProperties(typeof(CustomerContact))["ContactDateTime"], ListSortDirection.Ascending);
        //}
    }

     [ImplementPropertyChanged]
     [ProtoContract]
    public class DateFilterItem
    {
        [ProtoMember(1)]
        public DateTime LongDate { get; set; }
        [ProtoMember(2)]
         public string ShortDate { get; set; }

        public DateFilterItem()
        {
            LongDate = DateTime.Today;
            ShortDate = LongDate.ToString("dd/MM");
        }

        public DateFilterItem(DateTime systemDate)
        {
            LongDate = systemDate;
            ShortDate = LongDate.ToString("dd/MM");
        }

        public DateFilterItem(string displayString)
        {
            LongDate = DateTime.Today;
            ShortDate = displayString;
        }
    }
}
