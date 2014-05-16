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
        BindingSource[] bs = new BindingSource[10];

        public EditGridLinks()
        {
            InitializeComponent();
        }

        public void Init(Main _parent)
        {

            parent = _parent;
            gridLinksBindingSource.DataSource = _parent.DataStore.GridLinks.GridLinkList;

            for (var x = 0; x <10; x++)
            {
                bs[x] = new BindingSource();
                bs[x].DataSource = parent.DataStore.GridLinks.SystemItems;
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

            this.Visible = true;
            this.SendToBack();
            this.Visible = false;
            this.BringToFront();
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
    }
}
