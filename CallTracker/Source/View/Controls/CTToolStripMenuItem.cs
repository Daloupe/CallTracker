using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CallTracker.View
{
    public class CTToolStripMenuItem : ToolStripMenuItem
    {
        [Category("!Toggles")]
        public bool Advanced { get; set; }
    }
}
