using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CallTracker.View;
using CallTracker.Model;

namespace CallTracker.View
{
    public partial class EditSmartPasteBinds : ViewControlBase
    {
        private BindingSource source1 = new BindingSource();
        private BindingSource source2 = new BindingSource();

        public EditSmartPasteBinds()
        {
            InitializeComponent();
        }

        public override void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            base.Init(_parent, _menuItem);

            MainForm.DataStore.PasteBinds.Changed += OnListChanged;

            pasteBindBindingSource.DataSource = MainForm.DataStore.PasteBinds;

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
        public void SelectQuery(PasteBind _query)
        {
            pasteBindBindingSource.Position = pasteBindBindingSource.IndexOf(_query);
        }

        protected override void _Done_Click(object sender, EventArgs e)
        {
            base._Done_Click(sender, e);
        }

        protected override void PaintBorder(object sender, PaintEventArgs e)
        {
            base.PaintBorder(sender, e);
        }

        private void propertyLock_CheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Enabled = !propertyLock.Checked;
        }

        public void OnListChanged()
        {
            pasteBindBindingSource.ResetBindings(true);
        }
    }
}
