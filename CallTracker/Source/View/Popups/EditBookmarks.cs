using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using PropertyChanged;

namespace CallTracker.View
{   
    [ImplementPropertyChanged]
    public partial class EditBookmarks : Form
    {
        private Main MainForm;
        private Int16 id;
        public EditBookmarks()
        {
            InitializeComponent();
            MainForm = Application.OpenForms.OfType<Main>().First();
            id = (from a in Main.ServicesStore.servicesDataSet.ProblemStyles
                           where a.Description == MainForm.toolStripServiceSelector.Text
                           select a).First().Id;
            
            bookmarksBindingSource.DataSource = Main.ServicesStore.servicesDataSet;//.Bookmarks.Where(p => p.ProblemStyleId == query).ToList();
            bookmarksBindingSource.DataMember = "Bookmarks";
            bookmarksBindingSource.Filter = "ProblemStyleId in (" + id + ")";

            listBox1.DataSource = bookmarksBindingSource;
            listBox1.DisplayMember = "Name";

            editBookmarksToolStripMenuItem.Text = MainForm.toolStripServiceSelector.Text + @" Bookmarks";
        }

        private void _Ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            MainForm = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Name.Enabled = true;
            _Url.Enabled = true;

            //listBox1.DataSource = null;
            var newRow = Main.ServicesStore.servicesDataSet.Bookmarks.NewBookmarksRow();
            newRow.Name = "New Bookmark";
            newRow.ProblemStyleId = id;
            //newRow.ProblemStyleId = (from a in Main.ServicesStore.servicesDataSet.ProblemStyles
            //                        where a.Description == MainForm.toolStripServiceSelector.Text
            //                        select a).First().Id;
            newRow.Url = "http://";
            Main.ServicesStore.servicesDataSet.Bookmarks.AddBookmarksRow(newRow);
            //listBox1.DataSource = bookmarksBindingSource;
            //listBox1.DisplayMember = "Name";
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
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
            bookmarksBindingSource.RemoveCurrent();
            MainForm.bookmarksContextualToolStripMenuItem.dirty = true;
            if (bookmarksBindingSource.Count > 0) return;
            _Name.Enabled = false;
            _Url.Enabled = false;
        }

        private void EditBookmarks_VisibleChanged(object sender, EventArgs e)
        {
            if (bookmarksBindingSource.Count <= 0) return;
            _Name.Enabled = true;
            _Url.Enabled = true;
        }

    }
}
