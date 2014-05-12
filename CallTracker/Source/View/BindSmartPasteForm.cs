using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CallTracker.Model;

namespace CallTracker.View
{
    public partial class BindSmartPasteForm : Form
    {
        Main parent;
        public BindSmartPasteForm()//Main _parent)
        {
            InitializeComponent();
            parent = Application.OpenForms.OfType<Main>().First();
            _Data.DataSource = CustomerContact.ContactDataStrings;
            _AltData.DataSource = CustomerContact.ContactDataStrings;
        }

        private void _Cancel_Click(object sender, EventArgs e)
        {
            pasteBindBindingSource.DataSource = null;
            parent.RemovePasteBind((PasteBind)pasteBindBindingSource.DataSource);
            this.Close();
        }

        private void _Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateFields(PasteBind _query)
        {
            pasteBindBindingSource.DataSource = _query;
            if (String.IsNullOrEmpty(_query.Data))
                _query.Data = _Data.Text;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //if (e.CloseReason == CloseReason.WindowsShutDown
            //    || e.CloseReason == CloseReason.ApplicationExitCall
            //    || e.CloseReason == CloseReason.TaskManagerClosing)
            //    return;

            //e.Cancel = true;
            ////assuming you want the close-button to only hide the form, 
            ////and are overriding the form's OnFormClosing method:
            //this.Hide();
        }
    }
    

}
