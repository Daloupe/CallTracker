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

        //internal static BindingList<string> Equipment = new BindingList<string>();
        //internal static List<string> Symptoms;

        //internal ToolStripItemCollection Severity;
        internal List<ServicePanelDetails> ServiceFields;
        internal ServicePanelDetails currentFlowPanel;

        public ServicePanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);

            //SetStyle(ControlStyles.DoubleBuffer, true);
            //SetStyle(ControlStyles.DoubleBuffer, true);
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            //bindingSource1 = new BindingSource();


        }
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}
        public void PreInit(EditContact editContacts)
        {

            EditContacts = editContacts;
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
            //EditContacts.customerContactsBindingSource.PositionChanged += customerContactsBindingSource_PositionChanged;
            bindingSource1 = EditContacts.customerContactsBindingSource;

            //bindingSource1 = EditContacts.customerContactsBindingSource;

            //CauPings = Main.ServicesStore.servicesDataSet.EquipmentEquipmentStatusesMatch
            //    .Where(x => x.EquipmentRow.Type == "CAU")
            //    .Select(x => x.EquipmentStatusesRow.Status)
            //    .ToList();
            //DTVConnection = Main.ServicesStore.servicesDataSet.EquipmentEquipmentStatusesMatch
            //    .Where(x => x.EquipmentRow.Type == "STB")
            //    .Select(x => x.EquipmentStatusesRow.Status)
            //    .ToList();
            //ModemStatus = new List<string> { "Online", "Offline" };
            //ModemRF = new List<string> { "Yes", "No" };
            //Sips = new List<string> { "1", "2", "3", "4", "5", "6" };

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
                                     .ToList(), bindingSource1, true);
            _DTVLights.BindComboBox(Main.ServicesStore.servicesDataSet.EquipmentEquipmentStatusesMatch
                                     .Where(x => x.EquipmentRow.Type == "STB")
                                     .Select(x => x.EquipmentStatusesRow.Status)
                                     .ToList(), bindingSource1, true);
            _ModemStatus.BindComboBox(new List<string> { "Online", "Offline" }, bindingSource1, true);
            _ModemRF.BindComboBox(new List<string> { "Yes", "No" }, bindingSource1, true);
            _Sip.BindComboBox(new List<string> { "1", "2", "3", "4", "5", "6" }, bindingSource1, true);

            foreach (var control in Controls.OfType<FlowLayoutPanel>())
            {
                control.Location = new Point(0, 35);
                control.BringToFront();
                control.Hide();
            };

            _Node.AttachMenu(_NodeContextMenu);
            _ONCNode.AttachMenu(_NodeContextMenu);
            _DTVNode.AttachMenu(_NodeContextMenu);
            _CSA.AttachMenu(_CVCContextMenu);
            _AVC.AttachMenu(_AVCContextMenu);
            _GSID.AttachMenu(_PRIContextMenu);

            
            _Equipment.AttachMenu(_EquipmentMenu);//, EditContacts.BindingContext);
            _Equipment.BringToFront();
            _Equipment.Hide();
            //UpdateStyles();
        }

        //void customerContactsBindingSource_PositionChanged(object sender, EventArgs e)
        //{
        //    bindingSource1.Position = EditContacts.customerContactsBindingSource.Position;
        //}

        void Symptoms_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            UpdateSymptoms();
        }

        void Equipment_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            UpdateEquipment();
        }

        void Severity_RowChanged(object sender, DataRowChangeEventArgs e)
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
        public void ChangeService(ServiceTypes service)
        {
            EditContacts._isChangingService = true;
            if (currentFlowPanel.ServiceType.IsNot(service))
            {
                currentFlowPanel.HidePanel();
                currentFlowPanel = ServiceFields.First(x => x.ServiceType == service);
                _ServiceHeading.LabelText = "//" + currentFlowPanel.ProductCode;
                currentFlowPanel.ShowPanel();
            }

            if (currentFlowPanel.ServiceType.IsNot(ServiceTypes.NONE))
            {
                _Equipment.Show();
                EditContacts.MainForm.toolStripServiceSelector.Text = currentFlowPanel.Service.ProblemStylesRow.Description;
            }
            else
                _Equipment.Hide();

            SuspendLayout();
            UpdateSymptoms();
            UpdateEquipment();
            UpdateSeverity();
            ResumeLayout();

            if (EditContacts.MainForm.SelectedContact != null)
                EditContacts.MainForm.SelectedContact.Fault.AffectedServiceType = currentFlowPanel.ServiceType;

            EditContacts._isChangingService = false;
        }

        public void UpdateSymptoms()
        {
            if (currentFlowPanel.ServiceType.Is(ServiceTypes.NONE))
            {
                if (EditContacts.MainForm.SelectedContact != null)
                    EditContacts.MainForm.SelectedContact.Fault.Symptom = "";
                EditContacts._Symptom._ComboBox.DataSource = null;
                return;
            }
            var query = (from a in Main.ServicesStore.servicesDataSet.Symptoms
                         from b in a.GetSymptomGroupSymptomMatchRows()
                         from c in currentFlowPanel.Service.GetServiceSymptomGroupMatchRows()
                         where b.SymptomGroupsRow == c.SymptomGroupsRow &&
                               c.ServicesRow == currentFlowPanel.Service
                         select a.IFMSCode).Distinct().ToList();

            EditContacts._Symptom.BindComboBox(query, bindingSource1);
            
            if (!query.Contains(EditContacts.MainForm.SelectedContact.Fault.Symptom))
                EditContacts.MainForm.SelectedContact.Fault.Symptom = query[0];

            //if (String.IsNullOrEmpty(EditContacts.MainForm.SelectedContact.Fault.Symptom))
            //    EditContacts._Symptom._ComboBox.SelectedIndex = 0;
            //EditContacts._Note.DataBindings[0].ReadValue();
        }

        public void UpdateEquipment()
        {
            if (currentFlowPanel.ServiceType.Is(ServiceTypes.NONE))
            {
                if (EditContacts.MainForm.SelectedContact != null)
                    EditContacts.MainForm.SelectedContact.Service.Equipment = "";
                _Equipment._ComboBox.DataSource = null;
                return;
            }

            var query = (from a in Main.ServicesStore.servicesDataSet.Equipment
                         from b in a.GetServiceEquipmentMatchRows()
                         where b.ServicesRow == currentFlowPanel.Service
                         select a.Description).Distinct().ToList();

            _Equipment.BindComboBox(query, bindingSource1, true);
        }

        public void UpdateSeverity()
        {
            var symp = EditContacts._Symptom._ComboBox.Text ?? "NONE";
            var query = (from a in Main.ServicesStore.servicesDataSet.SeverityCodes
                         from b in a.GetSeverityCodeSymptomMatchRows()
                         where b.SymptomsRow.IFMSCode == symp
                         select a.IFMSCode).Distinct().ToArray();


            var current = String.Empty;
            if (EditContacts.MainForm.SelectedContact != null)
                current = EditContacts.MainForm.SelectedContact.Fault.Severity;

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

        //[DllImport("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        //private const int WM_SETREDRAW = 11;

        //public static void SuspendDrawing(Control parent)
        //{
        //    SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        //}

        //public static void ResumeDrawing(Control parent)
        //{
        //    SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
        //    parent.Refresh();
        //}

        private void _DTVPanel_MouseEnter(object sender, EventArgs e)
        {
        }

        private void _NBNContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (((ContextMenuStrip)sender).SourceControl.Name)
            {
                case "_PRI":
                    HotkeyController.NavigateOrNewIE(
                    "https://staff.optusnet.com.au/tools/nsi/avc_detail.html?gsid=" +
                    EditContacts.MainForm.SelectedContact.Service.PRI.Remove(0,3), "NSI");
                    break;
                case "_AVC":
                    HotkeyController.NavigateOrNewIE(
                    "https://staff.optusnet.com.au/tools/nsi/avc_detail.html?avcid=" +
                    EditContacts.MainForm.SelectedContact.Service.AVC, "NSI");
                    break;
                case "_CVC":
                    HotkeyController.NavigateOrNewIE(
                    "https://staff.optusnet.com.au/tools/nsi/avc_detail.html?cvcid=" +
                    EditContacts.MainForm.SelectedContact.Service.CVC, "NSI");
                    break;
            }
        }

        private void _NodeContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            HotkeyController.NavigateOrNewIE(
                "http://ifmsprod.optus.com.au/IFMSWeb1P/PR%20Manage/F139_SearchByNode.aspx?id=" +
                EditContacts.MainForm.SelectedContact.Service.Node, "IFMS");
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

        public ServicePanelDetails(ServiceTypes serviceType, FlowLayoutPanel panel = null, CheckBox checkBox = null, ToolStripMenuItem menuItem = null, List<LabelledBase> hiddenControls = null)
        {
            ServiceType = serviceType;
            ProductCode = Enum.GetName(typeof(ServiceTypes), ServiceType);
            HiddenControls = hiddenControls ?? new List<LabelledBase>();
            Panel = panel;
            CheckBox = checkBox;
            ContextMenuItem = menuItem;
            if (ServiceType.IsNot(ServiceTypes.NONE))
            {
                CheckBox.Tag = ServiceType;
                ContextMenuItem.Tag = serviceType;
                Service = Main.ServicesStore.servicesDataSet.Services.First(x => x.ProductCode == ProductCode);
            }
        }

        public void ShowPanel()
        {
            if (ServiceType.IsNot(ServiceTypes.NONE))
            {
                CheckBox.ForeColor = Color.DarkRed;
                foreach (var control in HiddenControls)
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
