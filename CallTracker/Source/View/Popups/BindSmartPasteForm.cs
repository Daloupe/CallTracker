using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

using CallTracker.Model;

namespace CallTracker.View
{
    public partial class BindSmartPasteForm : Form
    {
        private Main _parent;
        //private BindingSource source1;
        //private BindingSource source2;
        private readonly AutoCompleteStringCollection _systemAutoCompleteSource;

        public BindSmartPasteForm()
        {
            InitializeComponent();
            _parent = Application.OpenForms.OfType<Main>().First();
            //source1 = new BindingSource();
            //source2 = new BindingSource();
            _systemAutoCompleteSource = new AutoCompleteStringCollection();
        }

        private void BindSmartPasteForm_Load(object sender, EventArgs e)
        {
            UpdateAutoComplete();
            _System.AutoCompleteCustomSource = _systemAutoCompleteSource;

            //source1.DataSource = CustomerContact.PropertyStrings;
            //_Data.DataSource = source1;
            //_Data.DisplayMember = "Name";
            //_Data.ValueMember = "Path";
            //_Data.DataBindings.Add(new Binding(
            //                          "Text",
            //                          this.pasteBindBindingSource,
            //                          "Data",
            //                          false,
            //                          DataSourceUpdateMode.OnPropertyChanged));

            //source2.DataSource = CustomerContact.PropertyStrings;
            //_AltData.DataSource = source2;
            //_AltData.DisplayMember = "Name";
            //_AltData.ValueMember = "Path";
            //_AltData.DataBindings.Add(new Binding(
            //                          "Text",
            //                          this.pasteBindBindingSource,
            //                          "AltData",
            //                          false,
            //                          DataSourceUpdateMode.OnPropertyChanged));
        }

        private void _Cancel_Click(object sender, EventArgs e)
        {
            _parent.RemovePasteBind((PasteBind)pasteBindBindingSource.DataSource);
            Close();
        }

        private void _Ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SelectQuery(PasteBind query)
        {
            pasteBindBindingSource.DataSource = query;
            UpdateAutoComplete();
        }

        private void UpdateAutoComplete()
        {
            var distinctById = _parent.UserDataStore.PasteBinds
                                                    .GroupBy(a => a.System)
                                                    .Select(b => b.First())
                                                    .Select(c => c.System)
                                                    .ToArray();
            _systemAutoCompleteSource.Clear();
            _systemAutoCompleteSource.AddRange(distinctById);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _parent = null;
        }

        private void _Help_Click(object sender, EventArgs e)
        {
            Process.Start(@"Data\Data Names.txt");
        }

    }
}
