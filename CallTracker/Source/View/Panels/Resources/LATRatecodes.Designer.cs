﻿namespace CallTracker.View
{
    partial class LATRatecodes
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInstallCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ratePlanCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rateCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOSLATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOSLIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nILATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nILIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rateplanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._ClearHistory = new System.Windows.Forms.Button();
            this._Cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new CallTracker.View.BorderedTextBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateplanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem,
            this.showInstallCodesToolStripMenuItem,
            this.toolStripSeparator1,
            this.ratePlanCalculatorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 76);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // showInstallCodesToolStripMenuItem
            // 
            this.showInstallCodesToolStripMenuItem.CheckOnClick = true;
            this.showInstallCodesToolStripMenuItem.Name = "showInstallCodesToolStripMenuItem";
            this.showInstallCodesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.showInstallCodesToolStripMenuItem.Text = "Show Install Codes";
            this.showInstallCodesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // ratePlanCalculatorToolStripMenuItem
            // 
            this.ratePlanCalculatorToolStripMenuItem.Name = "ratePlanCalculatorToolStripMenuItem";
            this.ratePlanCalculatorToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ratePlanCalculatorToolStripMenuItem.Text = "Rate Plan Calculator";
            this.ratePlanCalculatorToolStripMenuItem.Click += new System.EventHandler(this.ratePlanCalculatorToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rateCodeDataGridViewTextBoxColumn,
            this.planNameDataGridViewTextBoxColumn,
            this.cOSLATDataGridViewTextBoxColumn,
            this.cOSLIPDataGridViewTextBoxColumn,
            this.nILATDataGridViewTextBoxColumn,
            this.nILIPDataGridViewTextBoxColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.DataSource = this.rateplanBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(577, 193);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBorder);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyDown);
            // 
            // rateCodeDataGridViewTextBoxColumn
            // 
            this.rateCodeDataGridViewTextBoxColumn.DataPropertyName = "RateCode";
            this.rateCodeDataGridViewTextBoxColumn.HeaderText = "Rate Code";
            this.rateCodeDataGridViewTextBoxColumn.Name = "rateCodeDataGridViewTextBoxColumn";
            this.rateCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // planNameDataGridViewTextBoxColumn
            // 
            this.planNameDataGridViewTextBoxColumn.DataPropertyName = "PlanName";
            this.planNameDataGridViewTextBoxColumn.FillWeight = 350F;
            this.planNameDataGridViewTextBoxColumn.HeaderText = "Plan Name";
            this.planNameDataGridViewTextBoxColumn.Name = "planNameDataGridViewTextBoxColumn";
            this.planNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOSLATDataGridViewTextBoxColumn
            // 
            this.cOSLATDataGridViewTextBoxColumn.DataPropertyName = "COSLAT";
            this.cOSLATDataGridViewTextBoxColumn.HeaderText = "Change: Lat";
            this.cOSLATDataGridViewTextBoxColumn.Name = "cOSLATDataGridViewTextBoxColumn";
            this.cOSLATDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cOSLIPDataGridViewTextBoxColumn
            // 
            this.cOSLIPDataGridViewTextBoxColumn.DataPropertyName = "COSLIP";
            this.cOSLIPDataGridViewTextBoxColumn.HeaderText = "Change: Lip";
            this.cOSLIPDataGridViewTextBoxColumn.Name = "cOSLIPDataGridViewTextBoxColumn";
            this.cOSLIPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nILATDataGridViewTextBoxColumn
            // 
            this.nILATDataGridViewTextBoxColumn.DataPropertyName = "NILAT";
            this.nILATDataGridViewTextBoxColumn.HeaderText = "Install: Lat";
            this.nILATDataGridViewTextBoxColumn.Name = "nILATDataGridViewTextBoxColumn";
            this.nILATDataGridViewTextBoxColumn.ReadOnly = true;
            this.nILATDataGridViewTextBoxColumn.Visible = false;
            // 
            // nILIPDataGridViewTextBoxColumn
            // 
            this.nILIPDataGridViewTextBoxColumn.DataPropertyName = "NILIP";
            this.nILIPDataGridViewTextBoxColumn.HeaderText = "Install: Lip";
            this.nILIPDataGridViewTextBoxColumn.Name = "nILIPDataGridViewTextBoxColumn";
            this.nILIPDataGridViewTextBoxColumn.ReadOnly = true;
            this.nILIPDataGridViewTextBoxColumn.Visible = false;
            // 
            // rateplanBindingSource
            // 
            this.rateplanBindingSource.DataSource = typeof(CallTracker.Model.RateplanModel);
            // 
            // _ClearHistory
            // 
            this._ClearHistory.BackColor = System.Drawing.Color.LightGray;
            this._ClearHistory.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this._ClearHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._ClearHistory.Location = new System.Drawing.Point(92, 198);
            this._ClearHistory.Name = "_ClearHistory";
            this._ClearHistory.Size = new System.Drawing.Size(57, 22);
            this._ClearHistory.TabIndex = 16;
            this._ClearHistory.Text = "Search";
            this._ClearHistory.UseVisualStyleBackColor = false;
            this._ClearHistory.Click += new System.EventHandler(this._Search_Click);
            // 
            // _Cancel
            // 
            this._Cancel.BackColor = System.Drawing.Color.LightGray;
            this._Cancel.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this._Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cancel.Location = new System.Drawing.Point(506, 198);
            this._Cancel.Name = "_Cancel";
            this._Cancel.Size = new System.Drawing.Size(75, 22);
            this._Cancel.TabIndex = 15;
            this._Cancel.Text = "Done";
            this._Cancel.UseVisualStyleBackColor = false;
            this._Cancel.Click += new System.EventHandler(this._Done_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(374, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "LAT Ratecodes";
            // 
            // textBox1
            // 
            this.textBox1.BorderColor = System.Drawing.Color.Gray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(4, 198);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(85, 22);
            this.textBox1.TabIndex = 19;
            // 
            // LATRatecodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this._ClearHistory);
            this.Controls.Add(this._Cancel);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Name = "LATRatecodes";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(584, 222);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateplanBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button _Cancel;
        private System.Windows.Forms.Button _ClearHistory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource rateplanBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInstallCodesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn rateCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn planNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOSLATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOSLIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nILATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nILIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ratePlanCalculatorToolStripMenuItem;
        private BorderedTextBox textBox1;
    }
}