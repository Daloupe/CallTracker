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
        private BindingSource source1 = new BindingSource();
        private BindingSource source2 = new BindingSource();

        public BindSmartPasteForm()
        {
            InitializeComponent();
            parent = Application.OpenForms.OfType<Main>().First();
            
        }

        private void BindSmartPasteForm_Load(object sender, EventArgs e)
        {
            source1.DataSource = CustomerContact.PropertyStrings;
            _Data.DataSource = source1;
            _Data.DisplayMember = "Name";
            _Data.ValueMember = "Path";
            _Data.DataBindings.Add(new Binding(
                                      "SelectedValue",
                                      this.pasteBindBindingSource,
                                      "Data",
                                      true,
                                      DataSourceUpdateMode.OnPropertyChanged));

            source2.DataSource = CustomerContact.PropertyStrings;
            _AltData.DataSource = source2;
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
            parent.RemovePasteBind((PasteBind)pasteBindBindingSource.DataSource);
            this.Close();
        }

        private void _Ok_Click(object sender, EventArgs e)
        {
            //parent.editSmartPasteBinds.dataGridView1.Invalidate();
            //parent.editSmartPasteBinds.pasteBindBindingSource.ResetBindings(true);
            this.Close();
        }

        public void UpdateFields(PasteBind _query)
        {
            pasteBindBindingSource.DataSource = _query;

            //if (String.IsNullOrEmpty(_query.Data))
            //    _query.Data = "Name";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            parent = null;
        }

    }
    

}
