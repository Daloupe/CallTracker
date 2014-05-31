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
    public class EditDataGridBase : UserControl
    {
        private CheckBox propertyLock;
        private Label label6;
        private SplitContainer splitContainer1;
        public DataGridView dataGridView1;
        private Button _Done;
    
        public ToolStripMenuItem MenuControl { get; protected set; }
        protected Main MainForm { get; set; }

        public EditDataGridBase()
        {
            InitializeComponent();
        }

        public virtual void Init(Main _parent, ToolStripMenuItem _menuItem)
        {
            MenuControl = _menuItem;
            MenuControl.Tag = this;
            MainForm = _parent;

            this.Visible = true;
            this.SendToBack();
            this.Visible = false;
            //this.BringToFront();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected virtual void _Done_Click(object sender, EventArgs e)
        {
            MainForm.VisibleSetting = null;
        }

        public virtual void HideSetting()
        {
            MenuControl.Checked = false;
            this.SendToBack();
            this.Visible = false;
        }

        public virtual void ShowSetting()
        {
            MenuControl.Checked = true;
            this.BringToFront();
            this.Visible = true;
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

        private void InitializeComponent()
        {
            this.propertyLock = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this._Done = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // propertyLock
            // 
            this.propertyLock.BackColor = System.Drawing.Color.Transparent;
            this.propertyLock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.propertyLock.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.propertyLock.Checked = true;
            this.propertyLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.propertyLock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.propertyLock.Image = global::CallTracker.Properties.Resources.padlock_small;
            this.propertyLock.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.propertyLock.Location = new System.Drawing.Point(365, 197);
            this.propertyLock.Name = "propertyLock";
            this.propertyLock.Padding = new System.Windows.Forms.Padding(3);
            this.propertyLock.Size = new System.Drawing.Size(38, 22);
            this.propertyLock.TabIndex = 18;
            this.propertyLock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.propertyLock.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(3, 201);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 18);
            this.label6.TabIndex = 17;
            this.label6.Text = "//Edit";
            // 
            // _Done
            // 
            this._Done.BackColor = System.Drawing.Color.LightGray;
            this._Done.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this._Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Done.Location = new System.Drawing.Point(506, 197);
            this._Done.Name = "_Done";
            this._Done.Size = new System.Drawing.Size(75, 22);
            this._Done.TabIndex = 16;
            this._Done.Text = "Done";
            this._Done.UseVisualStyleBackColor = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Size = new System.Drawing.Size(578, 191);
            this.splitContainer1.SplitterDistance = 353;
            this.splitContainer1.TabIndex = 19;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.Size = new System.Drawing.Size(353, 191);
            this.dataGridView1.TabIndex = 1;
            // 
            // ViewControlBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.propertyLock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._Done);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ViewControlBase";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(584, 222);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
