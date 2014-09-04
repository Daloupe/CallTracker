using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using CallTracker.DataSets;
using PropertyChanged;

namespace CallTracker.View
{   
    [ImplementPropertyChanged]
    public partial class EditBookmarks : Form
    {
        private Main MainForm;

        public EditBookmarks()
        {
            InitializeComponent();
            MainForm = Application.OpenForms.OfType<Main>().First();
            Int16 query = (from a in Main.ServicesStore.servicesDataSet.ProblemStyles
                           where a.Description == MainForm.toolStripServiceSelector.Text
                           select a).First().Id;
            bookmarksBindingSource.Filter = "ProblemStyleId in (" + query + ")";
            bookmarksBindingSource.DataSource = Main.ServicesStore.servicesDataSet;

            listBox1.DataSource = bookmarksBindingSource;
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
            var newRow = Main.ServicesStore.servicesDataSet.Bookmarks.NewBookmarksRow();
            newRow.Name = "New Bookmark";
            newRow.ProblemStyleId = (from a in Main.ServicesStore.servicesDataSet.ProblemStyles
                                    where a.Description == MainForm.toolStripServiceSelector.Text
                                    select a).First().Id;
            newRow.Url = "http://";
            Main.ServicesStore.servicesDataSet.Bookmarks.AddBookmarksRow(newRow);
            listBox1.DataSource = bookmarksBindingSource;
            listBox1.DisplayMember = "Name";
        }

        private void _Name_KeyUp(object sender, KeyEventArgs e)
        {
            bookmarksBindingSource.ResetCurrentItem();
            MainForm.bookmarksContextualToolStripMenuItem.dirty = true;
        }

        private void EditBookmarks_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ////listBox1.DataSource = null;
            //if (bookmarksBindingSource.Count == 1) return;
            //bookmarksBindingSource.Current;
            //Main.ServicesStore.servicesDataSet.Bookmarks.Rows.Find()
            ////listBox1.DataSource = bookmarksBindingSource;
            ////listBox1.DisplayMember = "Name";
            //MainForm.bookmarksContextualToolStripMenuItem.dirty = true;
        }

    }
}
