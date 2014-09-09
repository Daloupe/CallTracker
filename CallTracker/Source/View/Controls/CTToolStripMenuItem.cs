using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public interface CTToolStripItem
{
    bool Advanced { get; set; }
}

public class CTToolStripMenuItem : ToolStripMenuItem, CTToolStripItem
{
    [Category("!Toggles")]
    public bool Advanced { get; set; }
}

public class CTToolStripSeparator : ToolStripSeparator, CTToolStripItem
{
    [Category("!Toggles")]
    public bool Advanced { get; set; }
}
