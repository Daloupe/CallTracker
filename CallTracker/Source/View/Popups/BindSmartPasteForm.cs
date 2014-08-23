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
        private Main parent;
        private BindingSource source1;
        private BindingSource source2;
        private AutoCompleteStringCollection systemAutoCompleteSource;

        public BindSmartPasteForm()
        {
            InitializeComponent();
            parent = Application.OpenForms.OfType<Main>().First();
            source1 = new BindingSource();
            source2 = new BindingSource();
            systemAutoCompleteSource = new AutoCompleteStringCollection();
        }

        private void BindSmartPasteForm_Load(object sender, EventArgs e)
        {
            UpdateAutoComplete();
            _System.AutoCompleteCustomSource = systemAutoCompleteSource;

            source1.DataSource = CustomerContact.PropertyStrings;
            _Data.DataSource = source1;
            _Data.DisplayMember = "Name";
            _Data.ValueMember = "Path";
            _Data.DataBindings.Add(new Binding(
                                      "Text",
                                      this.pasteBindBindingSource,
                                      "Data",
                                      false,
                                      DataSourceUpdateMode.OnPropertyChanged));

            source2.DataSource = CustomerContact.PropertyStrings;
            _AltData.DataSource = source2;
            _AltData.DisplayMember = "Name";
            _AltData.ValueMember = "Path";
            _AltData.DataBindings.Add(new Binding(
                                      "Text",
                                      this.pasteBindBindingSource,
                                      "AltData",
                                      false,
                                      DataSourceUpdateMode.OnPropertyChanged));
        }

        private void _Cancel_Click(object sender, EventArgs e)
        {
            parent.RemovePasteBind((PasteBind)pasteBindBindingSource.DataSource);
            this.Close();
        }

        private void _Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SelectQuery(PasteBind _query)
        {
            pasteBindBindingSource.DataSource = _query;
            UpdateAutoComplete();
        }

        private void UpdateAutoComplete()
        {
            var distinctById = parent.UserDataStore.PasteBinds
                                               .GroupBy(a => a.System)
                                               .Select(b => b.First())
                                               .Select(c => c.System)
                                               .ToArray<string>();
            systemAutoCompleteSource.Clear();
            systemAutoCompleteSource.AddRange(distinctById);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            parent = null;
        }

    }
}
