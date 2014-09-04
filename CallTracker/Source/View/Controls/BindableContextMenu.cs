using System;
using System.ComponentModel;
using System.Windows.Forms;

using PropertyChanged;
namespace CallTracker.View
{
    [ImplementPropertyChanged]
    public partial class BindableContextMenu : ContextMenuStrip
    {
        [Bindable(true)]
        [Browsable(true)]
        public BindingSource Source { get; set; }


        public string BoundData { get; set; }

        public BindableContextMenu()
        {
            Source = new BindingSource();
           
        }

        [Browsable(true)]
        public event EventHandler DataSourceChanged
        {
            add { Source.DataSourceChanged += value; }
            remove { Source.DataSourceChanged -= value; }
        }

        [Browsable(true)]
        public event EventHandler CurrentItemChanged
        {
            add { Source.CurrentItemChanged += value; }
            remove { Source.CurrentItemChanged -= value; }
        }
    }
}
