﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CallTracker.View
{
    public partial class ONCPanel : PanelBase
    {
        public ONCPanel()
        {
            InitializeComponent();
        }

        public override void SetDataSource(object _source)
        {
            serviceModelBindingSource.DataSource = _source;
        }
    }
}
