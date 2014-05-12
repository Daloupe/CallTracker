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

        public ViewSmartPasteBinds() : base()
        {
            InitializeComponent();

            GetPosition = () => Properties.Settings.Default.ViewSmartPasteBinds_Position;
            GetSize = () => Properties.Settings.Default.ViewSmartPasteBinds_Size;
            SetPosition = value => Properties.Settings.Default.ViewSmartPasteBinds_Position = value;
            SetSize = value => Properties.Settings.Default.ViewSmartPasteBinds_Size = value;

            base.Init();

            pasteBindBindingSource.DataSource = MainForm.DataStore.PasteBinds;

            _Data.DataSource = CustomerContact.PropertyStrings;
            _Data.DisplayMember = "Name";
            _Data.ValueMember = "Path";

            _AltData.DataSource = CustomerContact.PropertyStrings;
            _AltData.DisplayMember = "Name";
            _AltData.ValueMember = "Path";
        }

        private void ViewSmartPasteBinds_Shown(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }

    }
}
