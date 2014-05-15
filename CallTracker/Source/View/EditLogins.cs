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
    public partial class EditLogins : UserControl
    {
        public EditLogins()
        {
            InitializeComponent();
        }

        public void Init(Main _parent)
        {
            loginsModelBindingSource.DataSource = _parent.DataStore.Logins;
        }

        private void _Done_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Visible = false;
        }
    }
}
