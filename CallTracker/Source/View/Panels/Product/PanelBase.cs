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
    public partial class PanelBase : UserControl
    {
        public PanelBase()
        {
            InitializeComponent();
        }

        public virtual void SetDataSource(object _source)
        {

        }
    }
}
