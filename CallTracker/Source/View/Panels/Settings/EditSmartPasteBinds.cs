using System;
using System.Windows.Forms;

using CallTracker.Model;

namespace CallTracker.View
{
    public partial class EditSmartPasteBinds : ViewControlBase
    {
        //private BindingSource source1 = new BindingSource();
        //private BindingSource source2 = new BindingSource();

        public EditSmartPasteBinds()
        {
            InitializeComponent();
            dgv = dataGridView1;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        public override void Init(Main mainForm, ToolStripMenuItem menuItem) 
        {
            base.Init(mainForm, menuItem);

            _ElementType.DataSource = Enum.GetValues(typeof(ElementTypes));

            MainForm.BindsDataStore.PasteBinds.Changed += OnListChanged;

            pasteBindBindingSource.DataSource = MainForm.BindsDataStore.PasteBinds;

            //source1.DataSource = CustomerContact.PropertyStrings;
            //_Data.DataSource = source1;
            //_Data.DisplayMember = "Name";
            //_Data.ValueMember = "Path";
            //_Data.DataBindings.Add(new Binding(
            //                          "Text",
            //                          this.pasteBindBindingSource,
            //                          "Data",
            //                          true,
            //                          DataSourceUpdateMode.OnPropertyChanged));

            //source2.DataSource = CustomerContact.PropertyStrings;
            //_AltData.DataSource = source2;
            //_AltData.DisplayMember = "Name";
            //_AltData.ValueMember = "Path";
            //_AltData.DataBindings.Add(new Binding(
            //                          "Text",
            //                          this.pasteBindBindingSource,
            //                          "AltData",
            //                          true,
            //                          DataSourceUpdateMode.OnPropertyChanged));
        }

        
        private void dataGridView1_DataError(object sender,
        DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null &&
                e.Context == DataGridViewDataErrorContexts.Commit)
            {
                EventLogger.LogNewEvent("Error: " + Name + " couldn't commit data to cell");
            }
        }

        public void SelectQuery(PasteBind query)
        {
            pasteBindBindingSource.Position = pasteBindBindingSource.IndexOf(query);
        }

        protected override void _Done_Click(object sender, EventArgs e)
        {
            base._Done_Click(sender, e);
        }

        protected override void PaintBorder(object sender, PaintEventArgs e)
        {
            base.PaintBorder(sender, e);
        }

        private void propertyLock_CheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Enabled = !propertyLock.Checked;
        }

        public void OnListChanged()
        {
            pasteBindBindingSource.ResetBindings(true);
        }

        private void _FireOnChangeNoWait_CheckedChanged(object sender, EventArgs e)
        {
            if (_FireOnChangeNoWait.Checked)
                _FireOnChange.Checked = false;
        }

        private void _FireOnChange_CheckedChanged(object sender, EventArgs e)
        {
            if (_FireOnChange.Checked)
                _FireOnChangeNoWait.Checked = false;
        }
    }
}
