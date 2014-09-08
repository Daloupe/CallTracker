using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

using CallTracker.Model;

namespace CallTracker.View
{
    public partial class BindSmartPasteForm : Form
    {
        private Main _mainForm;
        //private BindingSource source1;
        //private BindingSource source2;
        private readonly AutoCompleteStringCollection _systemAutoCompleteSource;

        public BindSmartPasteForm(Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;//Application.OpenForms.OfType<Main>().First();
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
            _mainForm.RemovePasteBind((PasteBind)pasteBindBindingSource.DataSource);
            pasteBindBindingSource.SuspendBinding();
            Hide();
        }

        private void _Ok_Click(object sender, EventArgs e)
        {
            pasteBindBindingSource.SuspendBinding();
            Hide();
        }

        public void SelectQuery(PasteBind query)
        {
            pasteBindBindingSource.DataSource = query;
            pasteBindBindingSource.ResumeBinding();
            UpdateAutoComplete();
        }

        private void UpdateAutoComplete()
        {
            var distinctById = _mainForm.BindsDataStore.PasteBinds
                                                    .GroupBy(a => a.System)
                                                    .Select(b => b.First())
                                                    .Select(c => c.System)
                                                    .ToArray();
            _systemAutoCompleteSource.Clear();
            _systemAutoCompleteSource.AddRange(distinctById);
        }

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    _mainForm = null;
        //}

        private void _Help_Click(object sender, EventArgs e)
        {
            Process.Start(@"Bind_ReadMe.txt");
        }

        private void _FireOnChangeNoWait_CheckedChanged(object sender, EventArgs e)
        {
            if (_FireOnChangeNoWait.Checked)
                _FireOnChange.Checked = false;
        }

        private void _FireOnChange_CheckedChanged(object sender, EventArgs e)
        {
            if (_FireOnChange.Checked)
                _FireOnChangeNoWait.Checked = false;
        }

    }
}
