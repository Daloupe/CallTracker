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
        public BindSmartPasteForm()
        {
            InitializeComponent();
            parent = Application.OpenForms.OfType<Main>().First();

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

        private void _Cancel_Click(object sender, EventArgs e)
        {
            parent.RemovePasteBind(((PasteBind)pasteBindBindingSource.DataSource));
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
                _query.Data = "Name";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            parent = null;
        }

    }
    

}
