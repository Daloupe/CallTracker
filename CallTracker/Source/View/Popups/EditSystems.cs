using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using CallTracker.DataSets;
using PropertyChanged;

namespace CallTracker.View
{   
    [ImplementPropertyChanged]
    public partial class EditSystems : Form
    {
        private Main MainForm;

        public EditSystems()
        {
            InitializeComponent();
            MainForm = Application.OpenForms.OfType<Main>().First();
            Int16 query = (from a in Main.ServicesStore.servicesDataSet.ProblemStyles
                           where a.Description == MainForm.toolStripServiceSelector.Text
                           select a).First().Id;
            systemLinksBindingSource.Filter = "ProblemStyleId in (" + query + ")";
            systemLinksBindingSource.DataSource = Main.ServicesStore.servicesDataSet;

            listBox1.DataSource = systemLinksBindingSource;
            listBox1.DisplayMember = "Name";
        }

        private void _Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            MainForm = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            ServicesDataSet.SystemLinksRow newRow = Main.ServicesStore.servicesDataSet.SystemLinks.NewSystemLinksRow();
            newRow.Name = "New System";
            newRow.ProblemStyleId = (from a in Main.ServicesStore.servicesDataSet.ProblemStyles
                                    where a.Description == MainForm.toolStripServiceSelector.Text
                                    select a).First().Id;
            newRow.Url = "http://";
            Main.ServicesStore.servicesDataSet.SystemLinks.AddSystemLinksRow(newRow);
            listBox1.DataSource = systemLinksBindingSource;
            listBox1.DisplayMember = "Name";
        }

        private void _Name_KeyUp(object sender, KeyEventArgs e)
        {
            systemLinksBindingSource.ResetCurrentItem();
            MainForm.systemsContextualToolStripMenuItem.dirty = true;
        }

        private void EditBookmarks_Load(object sender, EventArgs e)
        {
            
        }

    }
}
