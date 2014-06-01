namespace CallTracker.View
{
    partial class CallHistory
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._Done = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.callHistoryPanel1 = new CallTracker.View.CallHistoryPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.propertyLock = new System.Windows.Forms.CheckBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // _Done
            // 
            this._Done.BackColor = System.Drawing.Color.LightGray;
            this._Done.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this._Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Done.Location = new System.Drawing.Point(506, 197);
            this._Done.Name = "_Done";
            this._Done.Size = new System.Drawing.Size(75, 22);
            this._Done.TabIndex = 10;
            this._Done.Text = "Done";
            this._Done.UseVisualStyleBackColor = false;
            this._Done.Click += new System.EventHandler(this._Done_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
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
            this.splitContainer1.Panel2.Controls.Add(this.callHistoryPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(578, 191);
            this.splitContainer1.SplitterDistance = 353;
            this.splitContainer1.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(353, 191);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBorder);
            // 
            // callHistoryPanel1
            // 
            this.callHistoryPanel1.AutoScroll = true;
            this.callHistoryPanel1.BackColor = System.Drawing.Color.LightGray;
            this.callHistoryPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.callHistoryPanel1.Font = new System.Drawing.Font("Verdana", 7F);
            this.callHistoryPanel1.Location = new System.Drawing.Point(0, 0);
            this.callHistoryPanel1.Name = "callHistoryPanel1";
            this.callHistoryPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.callHistoryPanel1.Size = new System.Drawing.Size(221, 191);
            this.callHistoryPanel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(3, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "//Call History";
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
            this.propertyLock.Location = new System.Drawing.Point(360, 197);
            this.propertyLock.Name = "propertyLock";
            this.propertyLock.Padding = new System.Windows.Forms.Padding(3);
            this.propertyLock.Size = new System.Drawing.Size(38, 22);
            this.propertyLock.TabIndex = 14;
            this.propertyLock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.propertyLock.UseVisualStyleBackColor = false;
            this.propertyLock.CheckedChanged += new System.EventHandler(this.propertyLock_CheckedChanged);
            // 
            // CallHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.propertyLock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._Done);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Name = "CallHistory";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(584, 222);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _Done;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox propertyLock;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CallHistoryPanel callHistoryPanel1;
    }
}
