using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CallTracker.View
{
    public partial class DTVPanel : PanelBase
    {
        public DTVPanel()
        {
            InitializeComponent();
            //this.MouseEnter += NBF_MouseEnter;

        }

        public override void SetDataSource(object _source)
        {
            serviceModelBindingSource.DataSource = _source;
            dataDropDown1.BindComboBox(Main.ServicesStore.servicesDataSet.EquipmentEquipmentStatusesMatch
                                     .Where(x => x.EquipmentRow.Type == "STB")
                                     .Select(x => x.EquipmentStatusesRow.Status)
                                     .ToList(), serviceModelBindingSource);
        }
    }
}
