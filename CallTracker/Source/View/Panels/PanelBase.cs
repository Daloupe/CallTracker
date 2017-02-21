using System;
using System.Windows.Forms;

namespace CallTracker.View
{
    public partial class PanelBase : UserControl
    {
        public PanelBase()
        {
            InitializeComponent();
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.DoubleBuffer, true);
            //SetStyle(ControlStyles.DoubleBuffer, true);
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
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
    }
}
