using System;
using System.Windows.Forms;

using CallTracker.Model;

namespace CallTracker.View
{
    public partial class EditGridLinks : ViewControlBase
    {
        BindingSource[] bs = new BindingSource[10];

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
                bs[x] = new BindingSource { DataSource = MainForm.BindsDataStore.GridLinks.SystemItems };
            }

            comboBox0.DataSource = bs[0];
            comboBox0.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[0], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox1.DataSource = bs[1];
            comboBox1.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[1], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox2.DataSource = bs[2];
            comboBox2.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[2], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox3.DataSource = bs[3];
            comboBox3.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[3], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox4.DataSource = bs[4];
            comboBox4.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[4], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox5.DataSource = bs[5];
            comboBox5.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[5], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox6.DataSource = bs[6];
            comboBox6.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[6], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox7.DataSource = bs[7];
            comboBox7.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[7], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox8.DataSource = bs[8];
            comboBox8.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[8], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox9.DataSource = bs[9];
            comboBox9.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[9], "System", false, DataSourceUpdateMode.OnPropertyChanged));
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
            base._Done_Click(sender, e);
        }

        protected override void PaintBorder(object sender, PaintEventArgs e)
        {
            base.PaintBorder(sender, e);
        }

        private void _SetDefaults_Click(object sender, EventArgs e)
        {
            MainForm.BindsDataStore.GridLinks.Populate();
        }

    }
}
