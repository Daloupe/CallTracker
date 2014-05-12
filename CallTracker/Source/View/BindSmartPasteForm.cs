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

            DataTable dt = new DataTable();

            DataColumn dc1 = new DataColumn("Name");
            DataColumn dc2 = new DataColumn("Path");


            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);

            dt.Rows.Add("Name", "Name");
            dt.Rows.Add("PR", "Fault.PR");

            // Bind the combobox
            _Data.DataSource = dt.Copy();
            _Data.DisplayMember = "Name";
            _Data.ValueMember = "Path";

            this._Data.DataBindings.Add(new Binding(
                                      "SelectedValue",
                                      this.pasteBindBindingSource,
                                      "Data",
                                      true,
                                      DataSourceUpdateMode.OnPropertyChanged));

            // Bind the combobox
            _AltData.DataSource = dt.Copy();
            _AltData.DisplayMember = "Name";
            _AltData.ValueMember = "Path";

            this._AltData.DataBindings.Add(new Binding(
                                      "SelectedValue",
                                      this.pasteBindBindingSource,
                                      "AltData",
                                      true,
                                      DataSourceUpdateMode.OnPropertyChanged));
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
                _query.Data = "Name";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            parent = null;
        }

    }
    

}
