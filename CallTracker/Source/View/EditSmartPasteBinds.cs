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
        private BindingSource source1 = new BindingSource();
        private BindingSource source2 = new BindingSource();

        public EditSmartPasteBinds()
        {
            InitializeComponent();
        }

        public void Init(Main _parent)
        {
            pasteBindBindingSource.DataSource = _parent.DataStore.PasteBinds;

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

        private void _Done_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Gainsboro,
              e.ClipRectangle.Left,
              e.ClipRectangle.Top,
              e.ClipRectangle.Width - 1 ,
              e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }
    }
}
