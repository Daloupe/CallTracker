using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CallTracker.View
{
    [DefaultBindingProperty("TextField")]
    public partial class LabelledHeading : LabelledBase
    {
        public LabelledHeading()
        {
            InitializeComponent();
            this.ContextMenuStripChanged += base.LabelledTextBox_ContextMenuStripChanged;
        }

        private void LabelledTextBox_Load(object sender, EventArgs e)
        {
            if (ContextMenuStrip != null)
            {
                this._MenuButton.Show();
                this.ContextMenuStrip.Show();
                this.ContextMenuStrip.BindingContext = this.ParentForm.BindingContext;
            }
        }
    }
}
