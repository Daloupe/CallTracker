using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CallTracker.View;
using CallTracker.Model;

namespace CallTracker.View
{
    public partial class EditGridLinks : UserControl
    {
        private Main parent;
        public EditGridLinks()
        {
            InitializeComponent();
        }

        public void Init(Main _parent)
        {
            parent = _parent;
            gridLinksBindingSource.DataSource = _parent.DataStore.GridLinks.GridLinkList;

            comboBox0.DataSource = new BindingSource(GridLinksModel.SystemItems, null);
            comboBox0.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[0], "System", false, DataSourceUpdateMode.OnPropertyChanged));
            
            comboBox1.DataSource = new BindingSource(GridLinksModel.SystemItems, null);
            comboBox1.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[1], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox2.DataSource = new BindingSource(GridLinksModel.SystemItems, null);
            comboBox2.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[2], "System", false, DataSourceUpdateMode.OnPropertyChanged));
            
            comboBox3.DataSource = new BindingSource(GridLinksModel.SystemItems, null);
            comboBox3.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[3], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox4.DataSource = new BindingSource(GridLinksModel.SystemItems, null);
            comboBox4.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[4], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox5.DataSource = new BindingSource(GridLinksModel.SystemItems, null);
            comboBox5.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[5], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox6.DataSource = new BindingSource(GridLinksModel.SystemItems, null);
            comboBox6.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[6], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox7.DataSource = new BindingSource(GridLinksModel.SystemItems, null);
            comboBox7.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[7], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox8.DataSource = new BindingSource(GridLinksModel.SystemItems, null);
            comboBox8.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[8], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            comboBox9.DataSource = new BindingSource(GridLinksModel.SystemItems, null);
            comboBox9.DataBindings.Add(new Binding("SelectedValue", this.gridLinksBindingSource[9], "System", false, DataSourceUpdateMode.OnPropertyChanged));

            
        }

        private void _Done_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Gainsboro,
              e.ClipRectangle.Left,
              e.ClipRectangle.Top,
              e.ClipRectangle.Width - 1 ,
              e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
