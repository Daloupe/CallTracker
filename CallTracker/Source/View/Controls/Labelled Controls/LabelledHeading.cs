using System;

namespace CallTracker.View
{
    public partial class LabelledHeading : LabelledBase
    {
        public LabelledHeading()
        {
            InitializeComponent();
            ContextMenuStripChanged += base.LabelledTextBox_ContextMenuStripChanged;
        }

        private void LabelledTextBox_Load(object sender, EventArgs e)
        {
            if (ContextMenuStrip != null)
            {
                _MenuButton.Show();
                ContextMenuStrip.Show();
                ContextMenuStrip.BindingContext = ParentForm.BindingContext;
            }
        }
    }
}
