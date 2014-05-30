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
    public partial class LIPPanel : PanelBase
    {
        public LIPPanel()
        {
            InitializeComponent();
            //this.MouseEnter += NBF_MouseEnter;
        }

        public override void SetDataSource(object _source)
        {
            serviceModelBindingSource.DataSource = _source;
        }
    }
}
