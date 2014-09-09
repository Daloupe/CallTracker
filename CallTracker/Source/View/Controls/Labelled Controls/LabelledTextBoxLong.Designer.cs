namespace CallTracker.View
{
    partial class LabelledTextBoxLong
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
            this._DataField = new CallTracker.View.BorderedTextBox();
            this._TextfieldToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._MenuButton)).BeginInit();
            this.SuspendLayout();
            // 
            // _MenuButton
            // 
            this._MenuButton.Location = new System.Drawing.Point(166, 0);
            this._MenuButton.Size = new System.Drawing.Size(8, 20);
            this._MenuButton.Paint += new System.Windows.Forms.PaintEventHandler(this._MenuButton_Paint);
            // 
            // _Label
            // 
            this._Label.Dock = System.Windows.Forms.DockStyle.Left;
            this._Label.Font = new System.Drawing.Font("Gautami", 8.25F);
            this._Label.Location = new System.Drawing.Point(0, 0);
            this._Label.Size = new System.Drawing.Size(34, 23);
            // 
            // _DataField
            // 
            this._DataField.BackColor = System.Drawing.SystemColors.Window;
            this._DataField.BorderColor = System.Drawing.Color.WhiteSmoke;
            this._DataField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._DataField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._DataField.Font = new System.Drawing.Font("Verdana", 7F);
            this._DataField.Location = new System.Drawing.Point(34, 0);
            this._DataField.Margin = new System.Windows.Forms.Padding(0);
            this._DataField.MaximumSize = new System.Drawing.Size(500, 20);
            this._DataField.MinimumSize = new System.Drawing.Size(10, 20);
            this._DataField.Name = "_DataField";
            this._DataField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._DataField.Size = new System.Drawing.Size(132, 20);
            this._DataField.TabIndex = 27;
            this._DataField.TextChanged += new System.EventHandler(this._DataField_TextChanged);
            this._DataField.KeyUp += new System.Windows.Forms.KeyEventHandler(this._DataField_KeyUp);
            this._DataField.Leave += new System.EventHandler(this._DataField_Leave);
            this._DataField.MouseDown += new System.Windows.Forms.MouseEventHandler(this._DataField_MouseDown);
            // 
            // _TextfieldToolTip
            // 
            this._TextfieldToolTip.AutomaticDelay = 50;
            this._TextfieldToolTip.AutoPopDelay = 5000;
            this._TextfieldToolTip.InitialDelay = 50;
            this._TextfieldToolTip.ReshowDelay = 10;
            // 
            // LabelledTextBoxLong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlHeight = 20;
            this.Controls.Add(this._DataField);
            this.LabelDock = System.Windows.Forms.DockStyle.Left;
            this.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this.LabelOffset = new System.Drawing.Point(0, 0);
            this.LabelSize = new System.Drawing.Size(34, 23);
            this.Name = "LabelledTextBoxLong";
            this.Size = new System.Drawing.Size(174, 20);
            this.Load += new System.EventHandler(this.LabelledTextBox_Load);
            this.ContextMenuStripChanged += new System.EventHandler(this.LabelledTextBoxLong_ContextMenuStripChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this._MenuButton_Paint);
            this.Controls.SetChildIndex(this._MenuButton, 0);
            this.Controls.SetChildIndex(this._Label, 0);
            this.Controls.SetChildIndex(this._DataField, 0);
            ((System.ComponentModel.ISupportInitialize)(this._MenuButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public BorderedTextBox _DataField;
        private System.Windows.Forms.ToolTip _TextfieldToolTip;
    }
}
