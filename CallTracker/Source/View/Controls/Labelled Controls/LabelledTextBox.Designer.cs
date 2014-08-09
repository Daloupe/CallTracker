namespace CallTracker.View
{
    partial class LabelledTextBox
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
            this._DataField = new CallTracker.View.BorderedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this._MenuButton)).BeginInit();
            this.SuspendLayout();
            // 
            // _MenuButton
            // 
            this._MenuButton.Location = new System.Drawing.Point(164, 0);
            this._MenuButton.Size = new System.Drawing.Size(16, 13);
            this._MenuButton.Visible = false;
            // 
            // _DataField
            // 
            this._DataField.BackColor = System.Drawing.SystemColors.Window;
            this._DataField.BorderColor = System.Drawing.Color.WhiteSmoke;
            this._DataField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._DataField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._DataField.Font = new System.Drawing.Font("Verdana", 7F);
            this._DataField.Location = new System.Drawing.Point(0, 13);
            this._DataField.Margin = new System.Windows.Forms.Padding(0);
            this._DataField.Name = "_DataField";
            this._DataField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._DataField.Size = new System.Drawing.Size(180, 19);
            this._DataField.TabIndex = 27;
            // 
            // LabelledTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._DataField);
            this.Name = "LabelledTextBox";
            this.Load += new System.EventHandler(this.LabelledTextBox_Load);
            this.Controls.SetChildIndex(this._Label, 0);
            this.Controls.SetChildIndex(this._DataField, 0);
            this.Controls.SetChildIndex(this._MenuButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this._MenuButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public BorderedTextBox _DataField;
    }
}
