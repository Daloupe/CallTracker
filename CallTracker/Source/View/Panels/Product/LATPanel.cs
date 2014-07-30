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
    public partial class LATPanel : PanelBase
    {
        public LATPanel()
        {
            InitializeComponent();

            //Symptoms = new List<string>
            //{
            //    "NDT",
            //    "COS",
            //    "NRR",
            //    "DTN",
            //    "DRP"
            //};
        }

        public override void SetDataSource(object _source)
        {
            serviceModelBindingSource.DataSource = _source;
            dataDropDown1.DataSource = Main.ServicesStore.servicesDataSet.EquipmentEquipmentStatusesMatch
                                                                         .Where(x => x.EquipmentRow.Type == "CAU")
                                                                         .Select(x=> x.EquipmentStatusesRow.Status)
                                                                         .ToList();
        }

    }
}
