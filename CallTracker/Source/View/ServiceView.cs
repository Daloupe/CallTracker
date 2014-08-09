using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
using System.Data;

using CallTracker.Model;
using CallTracker.Helpers;
using CallTracker.Data;

namespace CallTracker.View
{
    public class ServiceView
    {
        public PanelBase Panel;
        public ToolStripMenuItem ContextMenuItem;
        public CheckBox CheckBox;

        public DataSets.ServicesDataSet.ServicesRow ServiceType;

        public static BindingList<string> Equipment;
        public static BindingList<string> Symptoms;
        public ToolStripItemCollection  Severity;

        private EditContact Parent;
        private string ProductCode;

        public bool IsInitialized = false;

        public ServiceView(EditContact _parent, string ifmsProductCode)
        {
            Parent = _parent;
            ProductCode = ifmsProductCode;
            Panel = (PanelBase)(Activator.CreateInstance(Type.GetType("CallTracker.View." + ProductCode + "Panel")));
            ContextMenuItem = ((ToolStripMenuItem)Parent.GetType().GetField("_ServiceMenu" + ProductCode).GetValue(Parent));
            CheckBox = ((CheckBox)Parent.GetType().GetField("_" + ProductCode).GetValue(Parent));

            ServiceType = (from a in Main.ServicesStore.servicesDataSet.Services
                           where a.ProductCode == ProductCode
                           select a).First();
        }

        public void Init()
        {
            //ServiceType = (from a in Main.ServicesStore.servicesDataSet.Services
            //               where a.ProductCode == ProductCode
            //               select a).First();

            UpdateSymptoms();
            UpdateEquipment();
            //UpdateSeverity();

            IsInitialized = true;
        }

        public void AddRowChangedEvents()
        {
            Main.ServicesStore.servicesDataSet.Equipment.RowChanged += Equipment_RowChanged;
            Main.ServicesStore.servicesDataSet.Symptoms.RowChanged += Symptoms_RowChanged;
            Main.ServicesStore.servicesDataSet.ServiceSymptomGroupMatch.RowChanged += Symptoms_RowChanged;
            Main.ServicesStore.servicesDataSet.SymptomGroupSymptomMatch.RowChanged += Symptoms_RowChanged;
            Main.ServicesStore.servicesDataSet.SymptomGroups.RowChanged += Symptoms_RowChanged;
            Main.ServicesStore.servicesDataSet.SeverityCodes.RowChanged += Severity_RowChanged;
            Main.ServicesStore.servicesDataSet.SeverityCodeSymptomMatch.RowChanged += Severity_RowChanged;

            Parent._Symptom.SelectedIndexChanged += _Symptom_SelectedIndexChanged;

            UpdateSymptoms();
            UpdateEquipment();
            UpdateSeverity();
        }

        void _Symptom_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSeverity();
        }

        public void RemoveRowChangedEvents()
        {
            Main.ServicesStore.servicesDataSet.Equipment.RowChanged -= Equipment_RowChanged;
            Main.ServicesStore.servicesDataSet.Symptoms.RowChanged -= Symptoms_RowChanged;
            Main.ServicesStore.servicesDataSet.ServiceSymptomGroupMatch.RowChanged -= Symptoms_RowChanged;
            Main.ServicesStore.servicesDataSet.SymptomGroupSymptomMatch.RowChanged -= Symptoms_RowChanged;
            Main.ServicesStore.servicesDataSet.SymptomGroups.RowChanged -= Symptoms_RowChanged;
            Main.ServicesStore.servicesDataSet.SeverityCodes.RowChanged -= Severity_RowChanged;
            Main.ServicesStore.servicesDataSet.SeverityCodeSymptomMatch.RowChanged -= Severity_RowChanged;

            Parent._Symptom.SelectedIndexChanged -= _Symptom_SelectedIndexChanged;
        }

        void Symptoms_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
        {
            UpdateSymptoms();
        }

        void Equipment_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
        {
            UpdateEquipment();
        }

        void Severity_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
        {
            UpdateSeverity();
        }

        public void UpdateSymptoms()
        {
            var query = (from a in Main.ServicesStore.servicesDataSet.Symptoms
                        from b in a.GetSymptomGroupSymptomMatchRows()
                        from c in ServiceType.GetServiceSymptomGroupMatchRows()
                        where b.SymptomGroupsRow == c.SymptomGroupsRow &&
                              c.ServicesRow == ServiceType
                        select a.IFMSCode).Distinct().ToList();

            if (query.Count > 0)
            {
                Symptoms.RaiseListChangedEvents = false;
                Symptoms.Clear();

                foreach (var item in query)
                    Symptoms.Add(item);

                Symptoms.RaiseListChangedEvents = true;
                Symptoms.ResetBindings();

                if (Parent._Symptom._ComboBox.DataSource == null)
                    Parent._Symptom.BindComboBox(Symptoms, Parent.customerContactsBindingSource);

                if (!Symptoms.Contains(Parent.MainForm.SelectedContact.Fault.Symptom))
                    Parent.MainForm.SelectedContact.Fault.Symptom = Symptoms[0];
            }              
        }

        public void UpdateEquipment()
        {
            var query = (from a in Main.ServicesStore.servicesDataSet.Equipment
                         from b in a.GetServiceEquipmentMatchRows()
                         where b.ServicesRow == ServiceType
                         select a.Description).Distinct().ToList();

            if (query.Count > 0)
            {
                Equipment.RaiseListChangedEvents = false;
                Equipment.Clear();

                foreach (var item in query)
                    Equipment.Add(item);

                Equipment.RaiseListChangedEvents = true;
                Equipment.ResetBindings();

                if (Parent._Equipment._ComboBox.DataSource == null)
                    Parent._Equipment.BindComboBox(Equipment, Parent.customerContactsBindingSource);
            }
        }

        public void UpdateSeverity()
        {
            string symp = Parent._Symptom._ComboBox.Text ?? "NONE";
            var query = (from a in Main.ServicesStore.servicesDataSet.SeverityCodes
                         from b in a.GetSeverityCodeSymptomMatchRows()
                         where b.SymptomsRow.IFMSCode == symp
                         select a.IFMSCode).Distinct().ToArray<string>();


            string current = Parent.MainForm.SelectedContact.Fault.Severity;

            foreach (ToolStripMenuItem item in Parent._SeverityMenuStrip.Items)
            {
                if (query.Contains(item.Text))
                {
                    item.Enabled = true;
                    if (String.IsNullOrEmpty(current) || !query.Contains(current))
                    {
                        Parent._SeverityMenuStrip.Text = current = item.Text;
                    }
                    if (item.Text == current)
                    {
                        item.PerformClick();
                    }
                }
                else
                {
                    item.Checked = false;
                    item.Enabled = false;
                }
            }
        }
    }
}
