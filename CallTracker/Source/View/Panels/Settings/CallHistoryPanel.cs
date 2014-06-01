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
    public partial class CallHistoryPanel : PanelBase
    {
        public CallHistoryPanel()
        {
            InitializeComponent();
            
        }

        public void SetBindingSource(BindingSource _source)
        {
            foreach (var control in Controls)
                if (control.GetType().BaseType == typeof(IDataField))
                {
                    IDataField cont = control as IDataField;
                    cont.DataBindings.Add(new Binding("TextField",
                                                        _source,
                                                        cont.PropertyName,
                                                        true,
                                                        DataSourceUpdateMode.OnPropertyChanged));
                }
        }
    }
}
