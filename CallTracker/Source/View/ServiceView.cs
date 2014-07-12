using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CallTracker.Model;

namespace CallTracker.View
{
    public class ServiceView
    {
        public PanelBase Panel;
        public ToolStripMenuItem ContextMenuItem;
        public CheckBox CheckBox;

        public ServiceTypes ServiceType;

        public List<string> Symptoms;
        public string ProductCode;
        public string ProblemStyle;
        public string SymptomGroup;

        public ServiceView(PanelBase panel, List<string> symptoms, ToolStripMenuItem menuItem, CheckBox checkBox, string ifmsProductCode, string ifmsProduct2Code, string ifmsServiceCode)
        {
            Panel = panel;
            Symptoms = symptoms;
            ContextMenuItem = menuItem;
            CheckBox = checkBox;
            ProductCode = ifmsProductCode;
            ProblemStyle = ifmsProduct2Code;
            SymptomGroup = ifmsServiceCode;
        }
    }
}
