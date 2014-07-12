namespace CallTracker.View
{
    partial class DataField
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
            this._Label = new System.Windows.Forms.Label();
            this._DataField = new CallTracker.View.BorderedTextBox();
            this.SuspendLayout();
            // 
            // _Label
            // 
            this._Label.Dock = System.Windows.Forms.DockStyle.Left;
            this._Label.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label.Location = new System.Drawing.Point(3, 3);
            this._Label.Margin = new System.Windows.Forms.Padding(0);
            this._Label.Name = "_Label";
            this._Label.Size = new System.Drawing.Size(34, 19);
            this._Label.TabIndex = 26;
            this._Label.Text = "AVC:";
            this._Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _DataField
            // 
            this._DataField.BackColor = System.Drawing.SystemColors.Window;
            this._DataField.BorderColor = System.Drawing.Color.Gray;
            this._DataField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._DataField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._DataField.Font = new System.Drawing.Font("Verdana", 7F);
            this._DataField.Location = new System.Drawing.Point(37, 3);
            this._DataField.Margin = new System.Windows.Forms.Padding(0);
            this._DataField.Name = "_DataField";
            this._DataField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._DataField.Size = new System.Drawing.Size(140, 19);
            this._DataField.TabIndex = 27;
            this._DataField.TextChanged += new System.EventHandler(this._DataField_TextChanged);
            // 
            // DataField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this._DataField);
            this.Controls.Add(this._Label);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DataField";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(180, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _Label;
        public BorderedTextBox _DataField;
    }
}
