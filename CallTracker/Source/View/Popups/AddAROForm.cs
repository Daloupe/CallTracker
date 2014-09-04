using System;
using System.Linq;
using System.Windows.Forms;

using CallTracker.Model;

namespace CallTracker.View
{
    public partial class AddAROForm : Form
    {
        private Main parent;

        public AddAROForm()
        {
            InitializeComponent();
            parent = Application.OpenForms.OfType<Main>().First();
        }

        private void BindSmartPasteForm_Load(object sender, EventArgs e)
        {
            _Suburb.Text = parent.SelectedContact.Address.Suburb;
            _PR.Text = parent.SelectedContact.Fault.NPR;
            _Node.Text = parent.SelectedContact.Service.Node;
            _Date.Text = DateTime.Now.ToShortDateString();
        }

        private void _Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SelectQuery(PasteBind _query)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            parent = null;
        }

    }
}
