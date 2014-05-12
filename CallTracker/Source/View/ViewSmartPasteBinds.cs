using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

using CallTracker.Model;

namespace CallTracker.View
{
    public partial class ViewSmartPasteBinds : SettingsFormBase
    {

        public ViewSmartPasteBinds()
            : base() //List<PasteBind> _binds
        {
            InitializeComponent();
            base.Init();

            var mainForm = Application.OpenForms.OfType<Main>().First();

            pasteBindBindingSource.DataSource = mainForm.PasteBinds;
            customerContactBindingSource1.DataSource = CustomerContact.ContactDataStrings;
            //dataGridView1.Columns[5].DataPropertyName = "ContactDataStrings";
        }

        private void ViewSmartPasteBinds_Shown(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        
        }

    }
}
