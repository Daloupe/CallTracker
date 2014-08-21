using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using CallTracker.Model;
using CallTracker.Helpers;

namespace CallTracker.View
{
    public partial class ServicePanel : UserControl
    {
        private EditContact EditContacts;

        internal static BindingList<string> Equipment;
        internal static BindingList<string> Symptoms;

        //internal ToolStripItemCollection Severity;
        internal List<ServicePanelDetails> ServiceFields;
        internal ServicePanelDetails currentFlowPanel;

        public ServicePanel()
        {
            InitializeComponent();

            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.DoubleBuffer, true);
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            //bindingSource1 = new BindingSource();
        }
        public void PreInit(EditContact _Parent)
        {
            EditContacts = _Parent;
            ServiceFields = new List<ServicePanelDetails>
            {
                new ServicePanelDetails(ServiceTypes.NONE),
                new ServicePanelDetails(ServiceTypes.LAT, _LATPanel, EditContacts._LAT, EditContacts._ServiceMenuLAT),
                new ServicePanelDetails(ServiceTypes.LIP, _ONCPanel, EditContacts._LIP, EditContacts._ServiceMenuLIP, new List<LabelledBase>{_SpeedTestHeading, _SpeedTestUp, _SpeedTestDown}),
                new ServicePanelDetails(ServiceTypes.ONC, _ONCPanel, EditContacts._ONC, EditContacts._ServiceMenuONC),
                new ServicePanelDetails(ServiceTypes.DTV, _DTVPanel, EditContacts._DTV, EditContacts._ServiceMenuDTV),
                new ServicePanelDetails(ServiceTypes.MTV, _MTVPanel, EditContacts._MTV, EditContacts._ServiceMenuMTV),
                new ServicePanelDetails(ServiceTypes.NFV, _NBNPanel, EditContacts._NFV, EditContacts._ServiceMenuNFV),
                new ServicePanelDetails(ServiceTypes.NBF, _NBNPanel, EditContacts._NBF, EditContacts._ServiceMenuNBF, new List<LabelledBase>{_Bras, _Sip}),
            };
            currentFlowPanel = ServiceFields[0];
        }

        public void Init()
        {
            EditContacts.customerContactsBindingSource.PositionChanged += customerContactsBindingSource_PositionChanged;
            bindingSource1.DataSource = EditContacts.customerContactsBindingSource;

            Main.ServicesStore.servicesDataSet.Equipment.RowChanged += Equipment_RowChanged;
            Main.ServicesStore.servicesDataSet.Symptoms.RowChanged += Symptoms_RowChanged;
            Main.ServicesStore.servicesDataSet.ServiceSymptomGroupMatch.RowChanged += Symptoms_RowChanged;
            Main.ServicesStore.servicesDataSet.SymptomGroupSymptomMatch.RowChanged += Symptoms_RowChanged;
            Main.ServicesStore.servicesDataSet.SymptomGroups.RowChanged += Symptoms_RowChanged;
            Main.ServicesStore.servicesDataSet.SeverityCodes.RowChanged += Severity_RowChanged;
            Main.ServicesStore.servicesDataSet.SeverityCodeSymptomMatch.RowChanged += Severity_RowChanged;

            EditContacts._Symptom.SelectedIndexChanged += _Symptom_SelectedIndexChanged;

            _CauPing.BindComboBox(Main.ServicesStore.servicesDataSet.EquipmentEquipmentStatusesMatch
                                     .Where(x => x.EquipmentRow.Type == "CAU")
                                     .Select(x => x.EquipmentStatusesRow.Status)
                                     .ToList(), bindingSource1);
            _DTVConnection.BindComboBox(Main.ServicesStore.servicesDataSet.EquipmentEquipmentStatusesMatch
                                     .Where(x => x.EquipmentRow.Type == "STB")
                                     .Select(x => x.EquipmentStatusesRow.Status)
                                     .ToList(), bindingSource1);
            _ModemStatus.BindComboBox(new List<string> { "Online", "Offline" }, bindingSource1);
            _ModemRF.BindComboBox(new List<string> { "Yes", "No" }, bindingSource1);
            _Sip.BindComboBox(new List<string> { "1", "2", "3", "4", "5", "6"}, bindingSource1);

            foreach (FlowLayoutPanel control in this.Controls.OfType<FlowLayoutPanel>())
            {
                control.Location = new Point(0, 12);
                control.BringToFront();
                control.Hide();
            };
        }

        void customerContactsBindingSource_PositionChanged(object sender, EventArgs e)
        {
            bindingSource1.Position = EditContacts.customerContactsBindingSource.Position;
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

        void _Symptom_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSeverity();
        }

        //private void bindingSource1_BindingComplete(object sender, BindingCompleteEventArgs e)
        //{
        //    // Check if the data source has been updated, and that no error has occured.
        //    if (e.BindingCompleteContext ==
        //        BindingCompleteContext.DataSourceUpdate && e.Exception == null)

        //        // If not, end the current edit.
        //        e.Binding.BindingManagerBase.EndCurrentEdit();
        //}

        public virtual void ConnectEvents(EventHandler action)
        {
            foreach (Control control in Controls)
                control.MouseHover += action;
        }

        public virtual void RemoveEvents(EventHandler action)
        {
            foreach (Control control in Controls)
                control.MouseHover -= action;
        }

        //public delegate void AddListItem();
        //public AddListItem myDelegate;
        public void ChangeService(ServiceTypes _service)
        {
            currentFlowPanel.HidePanel();
            currentFlowPanel = ServiceFields.First(x => x.ServiceType == _service);

            _ServiceHeading.LabelText = "//" + currentFlowPanel.ProductCode;

            currentFlowPanel.ShowPanel();
            if (currentFlowPanel.ServiceType.IsNot(ServiceTypes.NONE))
            {
                EditContacts.MainForm.toolStripServiceSelector.Text = currentFlowPanel.Service.ProblemStylesRow.Description;
                SuspendLayout();
                UpdateSymptoms();
                UpdateEquipment();
                UpdateSeverity();
                ResumeLayout();
            }
            EditContacts.MainForm.SelectedContact.Fault.AffectedServiceType = currentFlowPanel.ServiceType;
        }

        public void UpdateSymptoms()
        {
            var query = (from a in Main.ServicesStore.servicesDataSet.Symptoms
                         from b in a.GetSymptomGroupSymptomMatchRows()
                         from c in currentFlowPanel.Service.GetServiceSymptomGroupMatchRows()
                         where b.SymptomGroupsRow == c.SymptomGroupsRow &&
                               c.ServicesRow == currentFlowPanel.Service
                         select a.IFMSCode).Distinct().ToList();

            if (query.Count > 0)
            {
                Symptoms.RaiseListChangedEvents = false;
                Symptoms.Clear();

                foreach (var item in query)
                    Symptoms.Add(item);

                Symptoms.RaiseListChangedEvents = true;
                Symptoms.ResetBindings();

                if (EditContacts._Symptom._ComboBox.DataSource == null)
                    EditContacts._Symptom.BindComboBox(Symptoms, EditContacts.customerContactsBindingSource);

                if (!Symptoms.Contains(EditContacts.MainForm.SelectedContact.Fault.Symptom))
                    EditContacts.MainForm.SelectedContact.Fault.Symptom = Symptoms[0];
            }
        }

        public void UpdateEquipment()
        {
            var query = (from a in Main.ServicesStore.servicesDataSet.Equipment
                         from b in a.GetServiceEquipmentMatchRows()
                         where b.ServicesRow == currentFlowPanel.Service
                         select a.Description).Distinct().ToList();

            if (query.Count > 0)
            {
                Equipment.RaiseListChangedEvents = false;
                Equipment.Clear();

                foreach (var item in query)
                    Equipment.Add(item);

                Equipment.RaiseListChangedEvents = true;
                Equipment.ResetBindings();

                if (EditContacts._Equipment._ComboBox.DataSource == null)
                    EditContacts._Equipment.BindComboBox(Equipment, EditContacts.customerContactsBindingSource);
            }
        }

        public void UpdateSeverity()
        {
            string symp = EditContacts._Symptom._ComboBox.Text ?? "NONE";
            var query = (from a in Main.ServicesStore.servicesDataSet.SeverityCodes
                         from b in a.GetSeverityCodeSymptomMatchRows()
                         where b.SymptomsRow.IFMSCode == symp
                         select a.IFMSCode).Distinct().ToArray<string>();


            string current = EditContacts.MainForm.SelectedContact.Fault.Severity;

            foreach (ToolStripMenuItem item in EditContacts._SeverityMenuStrip.Items)
            {
                if (query.Contains(item.Text))
                {
                    item.Enabled = true;
                    if (String.IsNullOrEmpty(current) || !query.Contains(current))
                    {
                        EditContacts._SeverityMenuStrip.Text = current = item.Text;
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

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }

        private void _DTVPanel_MouseEnter(object sender, EventArgs e)
        {
        }
    }

    public class ServicePanelDetails
    {
        public ServiceTypes ServiceType;
        public string ProductCode;
        public DataSets.ServicesDataSet.ServicesRow Service;
        public List<LabelledBase> HiddenControls;
        public FlowLayoutPanel Panel;
        public CheckBox CheckBox;
        public ToolStripMenuItem ContextMenuItem;

        public ServicePanelDetails(ServiceTypes _serviceType, FlowLayoutPanel _panel = null, CheckBox _checkBox = null, ToolStripMenuItem _menuItem = null, List<LabelledBase> _hiddenControls = null)
        {
            ServiceType = _serviceType;
            ProductCode = Enum.GetName(typeof(ServiceTypes), ServiceType);
            HiddenControls = _hiddenControls ?? new List<LabelledBase>();
            Panel = _panel;
            CheckBox = _checkBox;
            ContextMenuItem = _menuItem;
            if (ServiceType.IsNot(ServiceTypes.NONE))
            {
                CheckBox.Tag = ServiceType;
                ContextMenuItem.Tag = _serviceType;
                Service = Main.ServicesStore.servicesDataSet.Services.First(x => x.ProductCode == ProductCode);
            }
        }

        public void ShowPanel()
        {
            if (ServiceType.IsNot(ServiceTypes.NONE))
            {
                CheckBox.ForeColor = Color.DarkRed;
                foreach (LabelledBase control in HiddenControls)
                    control.Hide();
                Panel.Show();
                ContextMenuItem.Checked = true;
            }
        }

        public void HidePanel()
        {     
            if (ServiceType.IsNot(ServiceTypes.NONE))
            {
                CheckBox.ForeColor = Color.Black;
                Panel.Hide();
                foreach (LabelledBase control in HiddenControls)
                    control.Show();
                ContextMenuItem.Checked = false;
            }
        }
    }
}
