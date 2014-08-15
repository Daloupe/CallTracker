using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CallTracker.Model;

namespace CallTracker.View
{
    public partial class PanelBase : UserControl
    {
        public PanelBase()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public virtual void SetDataSource(object _source)
        {

        }

        //public virtual void SetBindingSource(BindingSource _source)
        //{
        //    serviceModelBindingSource = _source;
        //}
        //public virtual void RemoveBindingSource(BindingSource _source)
        //{
        //    serviceModelBindingSource.Clear();
        //}

        public virtual void ConnectEvents(EventHandler action)
        {
            foreach (Control control in Controls)
                control.MouseEnter += action;
        }

        public virtual void RemoveEvents(EventHandler action)
        {
            foreach (Control control in Controls)
                control.MouseEnter -= action;
        }

        public void ChangeService(ServiceTypes _service)
        { 
            List<string> serviceControls = ServiceFields[_service];

            foreach(LabelledBase control in this.Controls)
                if(serviceControls.Contains(control.Name))
                    control.Show();
                else
                    control.Hide();

            _ServiceHeading.LabelText = "//" + Enum.GetName(typeof(ServiceTypes), _service);
        }

        private Dictionary<ServiceTypes, List<string>> ServiceFields = new Dictionary<ServiceTypes,List<string>>
        {
            {ServiceTypes.NONE, new List<string>()},
            {ServiceTypes.LAT, new List<string>{"_Node", "_CauPing", "_NitResults"}},
            {ServiceTypes.LIP, new List<string>{"_Node", "_CauPing", "_NitResults"}},
            {ServiceTypes.ONC, new List<string>{"_Node", "_CauPing", "_NitResults"}},
            {ServiceTypes.DTV, new List<string>{"_Node", "_CauPing", "_NitResults"}},
            {ServiceTypes.MTV, new List<string>{"_Node", "_CauPing", "_NitResults"}},
            {ServiceTypes.NFV, new List<string>{"_AVC", "_BRAS", "_SIP", "_CSA", "_CVC", "_NNI", "_PRI", "_INC", "_APT"}},
            {ServiceTypes.NBF, new List<string>{"_AVC", "_CSA", "_CVC", "_NNI", "_PRI", "_INC", "_APT"}}
        };
    }

}
