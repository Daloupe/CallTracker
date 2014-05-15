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
    public partial class EditSmartPasteBinds : UserControl
    {
        public EditSmartPasteBinds()
        {
            InitializeComponent();
        }

        public void Init(Main _parent)
        {
            _Data.DataSource = CustomerContact.PropertyStrings;
            _Data.DisplayMember = "Name";
            _Data.ValueMember = "Path";
            _Data.SelectedIndex = 1;

            _Data.DataBindings.Add(new Binding(
                                      "SelectedValue",
                                      this.pasteBindBindingSource,
                                      "Data",
                                      true,
                                      DataSourceUpdateMode.OnPropertyChanged));

            _AltData.DataSource = CustomerContact.PropertyStrings;
            _AltData.BindingContext = new BindingContext();
            _AltData.DisplayMember = "Name";
            _AltData.ValueMember = "Path";

            _AltData.DataBindings.Add(new Binding(
                                      "SelectedValue",
                                      this.pasteBindBindingSource,
                                      "AltData",
                                      true,
                                      DataSourceUpdateMode.OnPropertyChanged));
        }

        private void _Done_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Visible = false;
        }
    }
}
