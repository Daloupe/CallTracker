using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PropertyChanged;

namespace CallTracker.View
{
    [ImplementPropertyChanged]
    [DefaultBindingProperty("DataBindingSource")]
    public partial class LabelledComboBox : LabelledBase
    {
        public LabelledComboBox()
        {
            InitializeComponent();
            this.ContextMenuStripChanged += base.LabelledTextBox_ContextMenuStripChanged;
        }

        private void LabelledComboBox_Load(object sender, EventArgs e)
        {
            //if (ContextMenuStrip != null)
            //{
            //    //this.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            //    //this.ContextMenuStrip.Closing += ContextMenuStrip_Closing;
            //    this._MenuButton.Show();
            //    //this.ContextMenuStrip.Show();
            //    //this.ContextMenuStrip.BindingContext = this.ParentForm.BindingContext;
            //}
            //this.ContextMenuStripChanged += base.LabelledTextBox_ContextMenuStripChanged;
        }

        [Category("A1")]
        [Bindable(true)]
        [Browsable(true)]
        public ControlBindingsCollection DataBindingSource
        {
            get { return _ComboBox.DataBindings; }
        }

        [Browsable(true)]
        public event EventHandler SelectedIndexChanged
        {
            add { _ComboBox.SelectedIndexChanged += value; }
            remove { _ComboBox.SelectedIndexChanged -= value; }
        }
        public object DataSource
        {
            get { return _ComboBox.DataSource; }
            set { _ComboBox.DataSource = value; }
        }

        private void _ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ParentForm.Validate();
        }

        private void _ComboBox_DataSourceChanged(object sender, EventArgs e)
        {
            this.ParentForm.Validate();
        }

        //public override void ContextMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        //{
        //    //this.ContextMenuStrip.Opening -= ContextMenuStrip_Opening;
        //    //Console.WriteLine(((PictureBox)this.ContextMenuStrip.Tag).Parent.Name);
        //    //ContextMenuStrip menu = (ContextMenuStrip)sender;
        //    //Console.WriteLine(((PictureBox)ContextMenuStrip.Tag).Name);
        //    if (ContextMenuStrip.Tag != null)
        //    {
        //        ContextMenuStrip.Tag = null;
        //        e.Cancel = true;
        //    }
        //    this.BackgroundImage = Properties.Resources.TinyArrow2;
        //}

        //public override void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        //{
        //    //this.ContextMenuStrip.Closing -= ContextMenuStrip_Closing;
        //    //Console.WriteLine(((PictureBox)this.ContextMenuStrip.Tag).Parent.Name);
        //    //ContextMenuStrip menu = (ContextMenuStrip)sender;
        //    //Console.WriteLine(((PictureBox)ContextMenuStrip.Tag).Name);
        //    if (ContextMenuStrip.Tag == null)
        //        e.Cancel = true;
        //    ContextMenuStrip.Tag = null;
        //}
    }
}
