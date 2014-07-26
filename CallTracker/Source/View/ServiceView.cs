using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CallTracker.Model;
using CallTracker.Helpers;
using CallTracker.Data;

namespace CallTracker.View
{
    public class ServiceView
    {
        static Symptoms SymptomClass = new Symptoms();

        public PanelBase Panel;
        public ToolStripMenuItem ContextMenuItem;
        public CheckBox CheckBox;

        public ServiceTypes ServiceType;

        public List<string> Equipment;

        public List<string> Symptoms;
        public string ProductCode;
        public string ProblemStyle;
        public string SymptomGroup;

        public ServiceView(PanelBase panel, string[] symptoms, ToolStripMenuItem menuItem, CheckBox checkBox, string ifmsProductCode, string ifmsProduct2Code, string ifmsServiceCode)
        {
            Console.WriteLine(Data.Symptoms.Phone[0].ToString());
            Panel = panel;
            Symptoms = FindProperty.GetLists(symptoms, SymptomClass.GetType());
            ContextMenuItem = menuItem;
            CheckBox = checkBox;
            ProductCode = ifmsProductCode;
            ProblemStyle = ifmsProduct2Code;
            SymptomGroup = ifmsServiceCode;
        }
    }
}
