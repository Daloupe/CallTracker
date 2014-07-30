using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;

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

        public BindingList<string> Equipment;
        public BindingList<string> Symptoms;
        public BindingList<string> Severity;

        private EditContact Parent;

        public ServiceView(EditContact _parent, string ifmsProductCode)
        {
            Parent = _parent;

            Panel = (PanelBase)(Activator.CreateInstance(Type.GetType("CallTracker.View." + ifmsProductCode + "Panel")));
            ContextMenuItem = ((ToolStripMenuItem)Parent.GetType().GetField("_ServiceMenu" + ifmsProductCode).GetValue(Parent));
            CheckBox = ((CheckBox)Parent.GetType().GetField("_" + ifmsProductCode).GetValue(Parent));

            ServiceType = (from a in Main.ServicesStore.servicesDataSet.Services
                           where a.ProductCode == ifmsProductCode
                          select a).First();
            Symptoms = new BindingList<string>();
            Equipment = new BindingList<string>();
            Severity = new BindingList<string>();
            UpdateSymptoms();
            UpdateEquipment();
            UpdateSeverity();
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
            Parent._Symptom.DataSource = null;
            Symptoms.Clear();
            var query = (from a in Main.ServicesStore.servicesDataSet.Symptoms
                        from b in a.GetSymptomGroupSymptomMatchRows()
                        from c in ServiceType.GetServiceSymptomGroupMatchRows()
                        where b.SymptomGroupsRow == c.SymptomGroupsRow &&
                              c.ServicesRow == ServiceType
                        select a.IFMSCode).Distinct().ToList();
            
            foreach (var item in query)
                Symptoms.Add(item);

            Parent._Symptom.DataSource = Symptoms;
        }

        public void UpdateEquipment()
        {
            Parent._Equipment.DataSource = null;
            Equipment.Clear();
            var query = (from a in Main.ServicesStore.servicesDataSet.Equipment
                         from b in a.GetServiceEquipmentMatchRows()
                         where b.ServicesRow == ServiceType
                         select a.Description).Distinct().ToList();

            foreach (var item in query)
                Equipment.Add(item);

            Parent._Equipment.DataSource = Equipment;
        }

        public void UpdateSeverity()
        {
            Parent._Severity.DataSource = null;
            Severity.Clear();
            string symp = Parent._Symptom.Text ?? "NONE";
            var query = (from a in Main.ServicesStore.servicesDataSet.SeverityCodes
                         from b in a.GetSeverityCodeSymptomMatchRows()
                         where b.SymptomsRow.IFMSCode == symp
                         select a.IFMSCode).Distinct().ToList();

            foreach (var item in query)
                Severity.Add(item);

            Parent._Severity.DataSource = Severity;
        }
    }
}
