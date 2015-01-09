using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using PropertyChanged;

using CallTracker.Model;

namespace CallTracker.View
{   
    [ImplementPropertyChanged]
    public partial class EditSystems : Form
    {
        private Main MainForm;
        private Int16 id;

        public EditSystems()
        {
            InitializeComponent();
            MainForm = Application.OpenForms.OfType<Main>().First();
            id = (from a in Main.ServicesStore.servicesDataSet.ProblemStyles
                           where a.Description == MainForm.toolStripServiceSelector.Text
                           select a).First().Id;
            systemLinksBindingSource.Filter = "ProblemStyleId in (" + id + ")";
            systemLinksBindingSource.DataSource = Main.ServicesStore.servicesDataSet;

            listBox1.DataSource = systemLinksBindingSource;
            listBox1.DisplayMember = "Name";

            editBookmarksToolStripMenuItem.Text = MainForm.toolStripServiceSelector.Text + @" Systems";
        }

        private void _Ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            EventLogger.LogNewEvent("Saving Services");
            Main.ServicesStore.WriteData();
            MainForm = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Name.Enabled = true;
            _Url.Enabled = true;

            //listBox1.DataSource = null;
            var newRow = Main.ServicesStore.servicesDataSet.SystemLinks.NewSystemLinksRow();
            newRow.Name = "New System";
            newRow.ProblemStyleId = id;//(from a in Main.ServicesStore.servicesDataSet.ProblemStyles
                                    //where a.Description == MainForm.toolStripServiceSelector.Text
                                    //select a).First().Id;
            newRow.Url = "http://";
            Main.ServicesStore.servicesDataSet.SystemLinks.AddSystemLinksRow(newRow);
            //listBox1.DataSource = systemLinksBindingSource;
            //listBox1.DisplayMember = "Name";
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void _Name_KeyUp(object sender, KeyEventArgs e)
        {
            systemLinksBindingSource.ResetCurrentItem();
            MainForm.systemsContextualToolStripMenuItem.dirty = true;
        }

        private void EditBookmarks_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            systemLinksBindingSource.RemoveCurrent();
            MainForm.systemsContextualToolStripMenuItem.dirty = true;
            if (systemLinksBindingSource.Count > 0) return;
            _Name.Enabled = false;
            _Url.Enabled = false;
        }

        private void EditSystems_VisibleChanged(object sender, EventArgs e)
        {
            if (systemLinksBindingSource.Count <= 0) return;
            _Name.Enabled = true;
            _Url.Enabled = true;
        }

    }
}
