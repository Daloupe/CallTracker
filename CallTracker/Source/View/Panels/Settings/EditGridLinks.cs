using System;
using System.Windows.Forms;
using CallTracker.Helpers;
using CallTracker.Model;

namespace CallTracker.View
{
    public partial class EditGridLinks : ViewControlBase
    {
        readonly BindingSource[] _bs = new BindingSource[10];

        public EditGridLinks()
        {
            InitializeComponent();
            dgv = dataGridView1;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.AutoGenerateColumns = false;
        }

        public override void Init(Main mainForm, ToolStripMenuItem menuItem)
        {
            base.Init(mainForm, menuItem);

            systemItemBindingSource.DataSource = MainForm.BindsDataStore.GridLinks.SystemItems;
            gridLinksBindingSource.DataSource = MainForm.BindsDataStore.GridLinks.GridLinkList;

            for (var x = 0; x <10; x++)
            {
                _bs[x] = new BindingSource { DataSource = MainForm.BindsDataStore.GridLinks.SystemItems };
            }

            comboBox0.DataSource = _bs[0];
            comboBox0.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[0], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox1.DataSource = _bs[1];
            comboBox1.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[1], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox2.DataSource = _bs[2];
            comboBox2.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[2], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox3.DataSource = _bs[3];
            comboBox3.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[3], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox4.DataSource = _bs[4];
            comboBox4.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[4], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox5.DataSource = _bs[5];
            comboBox5.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[5], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox6.DataSource = _bs[6];
            comboBox6.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[6], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox7.DataSource = _bs[7];
            comboBox7.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[7], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox8.DataSource = _bs[8];
            comboBox8.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[8], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox9.DataSource = _bs[9];
            comboBox9.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[9], "System", false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void dataGridView1_DataError(object sender,
        DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is  
            // commited, display an error message. 
            if (e.Exception != null &&
                e.Context == DataGridViewDataErrorContexts.Commit)
            {
                EventLogger.LogNewEvent("Error: "+this.Name+" couldn't commit data to cell");
            }
        }

        protected override void _Done_Click(object sender, EventArgs e)
        {
            EventLogger.LogNewEvent("Saving GridLinks");
            MainForm.BindsDataStore.WriteData();
            base._Done_Click(sender, e);
        }

        protected override void PaintBorder(object sender, PaintEventArgs e)
        {
            base.PaintBorder(sender, e);
        }

        private void _SetDefaults_Click(object sender, EventArgs e)
        {
            WindowHelper.SuspendDrawing(this);
            MainForm.BindsDataStore.GridLinks.Populate();
            systemItemBindingSource.DataSource = MainForm.BindsDataStore.GridLinks.SystemItems;
            gridLinksBindingSource.DataSource = MainForm.BindsDataStore.GridLinks.GridLinkList;

            comboBox0.DataBindings.Clear();
            comboBox0.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[0], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox1.DataBindings.Clear();
            comboBox1.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[1], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox2.DataBindings.Clear();
            comboBox2.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[2], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox3.DataBindings.Clear();
            comboBox3.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[3], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox4.DataBindings.Clear();
            comboBox4.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[4], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox5.DataBindings.Clear();
            comboBox5.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[5], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox6.DataBindings.Clear();
            comboBox6.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[6], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox7.DataBindings.Clear();
            comboBox7.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[7], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox8.DataBindings.Clear();
            comboBox8.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[8], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox9.DataBindings.Clear();
            comboBox9.DataBindings.Add(new Binding("SelectedValue", gridLinksBindingSource[9], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            WindowHelper.ResumeDrawing(this);
        }

    }
}
