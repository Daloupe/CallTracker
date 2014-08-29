using System;
using System.Drawing;
using System.Windows.Forms;

namespace CallTracker.View
{
    public class ViewControlBase : UserControl
    {
        internal DataGridView dgv;
        public ToolStripMenuItem MenuControl { get; protected set; }
        protected Main MainForm { get; set; }

        //public ViewControlBase()
        //{
        //   // SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        //}

        public virtual void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            MenuControl = _menuItem;
            MenuControl.Tag = this;
            MainForm = _parent;

            Location = MainForm.ControlOffset;

            this.Visible = true;
            this.SendToBack();
            this.Visible = false;
            //this.BringToFront();

            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            //SetStyle(ControlStyles.DoubleBuffer, true);
            //SetStyle(ControlStyles.DoubleBuffer, true);
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected virtual void _Done_Click(object sender, EventArgs e)
        {
            MainForm.NullVisibleSetting();
        }

        public virtual void HideSetting()
        {
            //MainForm.Height = previousHeight;
            this.SendToBack();
            this.Visible = false;
            MenuControl.Checked = false;
        }

        //protected int previousHeight;
        public virtual void ShowSetting()
        {
            //previousHeight = MainForm.Height;
            //MainForm.Height = previousHeight - 20;
            this.BringToFront();
            this.Visible = true;
            MenuControl.Checked = true;                
        }

        protected virtual void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1)
            {
                dgv.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                dgv.EndEdit();
            }
            else
            {
                dgv.EditMode = DataGridViewEditMode.EditOnEnter;
                dgv.BeginEdit(false);

            }
        }

        protected virtual void PaintBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.WhiteSmoke,
             0,
             0,
             ((Control)sender).Width + 1,
             ((Control)sender).Height + 1);
            base.OnPaint(e);
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // ViewControlBase
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.BackColor = System.Drawing.Color.LightSlateGray;
        //    this.DoubleBuffered = true;
        //    this.Font = new System.Drawing.Font("Verdana", 7F);
        //    this.Margin = new System.Windows.Forms.Padding(0);
        //    this.Name = "ViewControlBase";
        //    this.Padding = new System.Windows.Forms.Padding(3);
        //    this.Size = new System.Drawing.Size(584, 222);
        //    this.ResumeLayout(false);

        //}
    }
}
