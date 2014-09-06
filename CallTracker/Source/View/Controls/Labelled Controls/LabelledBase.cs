﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CallTracker.View
{

    public partial class LabelledBase : IDataField
    {
        
        [Category("!Label")]
        public string LabelText
        {
            get { return _Label.Text; }
            set { _Label.Text = value; }
        }

        [Category("!Label")]
        public Font LabelFont
        {
            get { return _Label.Font; }
            set { _Label.Font = value; }
        }

        [Category("!Label")]
        public Point LabelOffset
        {
            get { return _Label.Location; }
            set { _Label.Location = value; }
        }

        [Category("!Label")]
        public Size LabelSize
        {
            get { return _Label.Size; }
            set { _Label.Size = value; }
        }

        [Category("!Label")]
        public Padding LabelPadding
        {
            get { return _Label.Padding; }
            set { _Label.Padding = value; }
        }

        [Category("!Label")]
        public Padding LabelMargin
        {
            get { return _Label.Margin; }
            set { _Label.Margin = value; }
        }

        [Category("!Label")]
        public bool LabelAutoSize
        {
            get { return _Label.AutoSize; }
            set { _Label.AutoSize = value; }
        }


        [Category("!Label")]
        public Color LabelTextColor
        {
            get { return _Label.ForeColor; }
            set { _Label.ForeColor = value; }
        }

        [Category("!Label")]
        public Color LabelInactiveColor
        {
            get;
            set;
        }

        [Category("!Label")]
        public Color LabelActiveColor
        {
            get;
            set;
        }

        [Category("!Label")]
        public ContentAlignment LabelTextAlign
        {
            get { return _Label.TextAlign; }
            set { _Label.TextAlign = value; }
        }

        [Category("!Main")]
        public int ControlHeight
        {
            get { return this.Height; }
            set { this.Height = value; }
        }

        [Category("!Label")]
        public Color LabelBorderColor
        {
            get; 
            set;

        }

        [Category("!Label")]
        public string LabelToolTip
        {
            get { return _ToolTip.GetToolTip(_Label); }
            set { _ToolTip.SetToolTip(_Label, value); }

        }

        [Category("!MenuButton")]
        public DockStyle MenuButtonDock
        {
            get { return _MenuButton.Dock; }
            set { _MenuButton.Dock = value; }
        }

        [Category("!MenuButton")]
        public Image MenuButtonImage
        {
            get { return _MenuButton.Image; }
            set { _MenuButton.Image = value; }
        }

        public bool HasContextMenu { get; set; }

        public LabelledBase()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            this.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            lasttime = DateTime.UtcNow;
            this.ContextMenuStripChanged += LabelledTextBox_ContextMenuStripChanged;
        }

        public virtual void AttachMenu(ContextMenuStrip menu)
        {
            ContextMenuStrip = menu;
            HasContextMenu = true;
        }

        //public virtual void AttachMenu(ContextMenuStrip menu, BindingContext context )
        //{
        //    ContextMenuStrip = menu;

        //    this._MenuButton.Show();
        //    this.ContextMenuStrip.Opacity = 0;
        //    this.ContextMenuStrip.Show(this, 9, 9);
        //    this.ContextMenuStrip.BindingContext = context;
        //    this.ContextMenuStrip.Opacity = 100;
        //}

        protected DateTime lasttime;
        protected bool opened;
        protected virtual void _MenuButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                return;
            if (this.ContextMenuStrip.Visible == false)
            {
                this.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
                this.ContextMenuStrip.Show(this._MenuButton, 9, 9);
                opened = true;
            }
            else
            {
                this.ContextMenuStrip.Hide();
                opened = false;       
            }
        }

        public virtual void ContextMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            ContextMenuStrip menu = (ContextMenuStrip)sender;
            menu.Closing -= ContextMenuStrip_Closing;

            if (DateTime.UtcNow.Subtract(lasttime).Milliseconds > 9 && opened == false )
            {
                e.Cancel = true;
                return;
            }
            menu.SourceControl.BackgroundImage = Properties.Resources.TinyArrow2;
            lasttime = DateTime.UtcNow;
        }

        protected virtual void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        { 
            ContextMenuStrip menu = (ContextMenuStrip)sender;
            menu.Opening -= ContextMenuStrip_Opening;

            if (DateTime.UtcNow.Subtract(lasttime).Milliseconds < 9 && opened == true)
            {
                e.Cancel = true;
                return;
            }
            lasttime = DateTime.UtcNow;
            this._MenuButton.BackgroundImage = Properties.Resources.TinyArrow;
            menu.Closing += ContextMenuStrip_Closing;
        }

        protected virtual void LabelledTextBox_ContextMenuStripChanged(object sender, EventArgs e)
        {
            if (ContextMenuStrip != null)
            {
                _MenuButton.Show();
                HasContextMenu = true;
                this.ContextMenuStrip.Opacity = 100;
            }
            else
            {
                HasContextMenu = false;
                _MenuButton.Hide();
            }


        }

        private void LabelledBase_Load(object sender, EventArgs e)
        {
            if (ContextMenuStrip != null)
            {
                this._MenuButton.Show();
                this.ContextMenuStrip.Opacity = 0;
                this.ContextMenuStrip.BindingContext = ParentForm.BindingContext;
                this.ContextMenuStrip.Show(this, 9, 9);
            }
        }

        private void _Label_Click(object sender, EventArgs e)
        {
            Parent.Focus();
        }

        //public void SetupContextMenu(BindingContext bindingContext)
        //{
        //    //ContextMenuStrip.Opacity = 0;
        //    //ContextMenuStrip.Show(this, 9, 9);
        //    //ContextMenuStrip.BindingContext = bindingContext;
        //    //this.ContextMenuStrip.Opacity = 100;
        //}

    }
}
