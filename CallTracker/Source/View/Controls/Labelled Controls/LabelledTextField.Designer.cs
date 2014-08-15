namespace CallTracker.View
{
    partial class LabelledTextField
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
            this._DataField = new CallTracker.View.BorderedTextField();
            ((System.ComponentModel.ISupportInitialize)(this._MenuButton)).BeginInit();
            this.SuspendLayout();
            // 
            // _Label
            // 
            this._Label.AutoSize = false;
            this._Label.Dock = System.Windows.Forms.DockStyle.Top;
            this._Label.Location = new System.Drawing.Point(0, 0);
            this._Label.Size = new System.Drawing.Size(164, 17);
            // 
            // _MenuButton
            // 
            this._MenuButton.Size = new System.Drawing.Size(16, 16);
            this._MenuButton.Visible = false;
            // 
            // _DataField
            // 
            this._DataField.BorderColor = System.Drawing.Color.Gray;
            this._DataField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._DataField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._DataField.Location = new System.Drawing.Point(0, 16);
            this._DataField.Name = "_DataField";
            this._DataField.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this._DataField.Size = new System.Drawing.Size(180, 77);
            this._DataField.TabIndex = 31;
            this._DataField.Text = "";
            this._DataField.TextChanged += new System.EventHandler(this._DataField_TextChanged);
            // 
            // LabelledTextField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlHeight = 93;
            this.Controls.Add(this._DataField);
            this.LabelAutoSize = false;
            this.LabelOffset = new System.Drawing.Point(0, 0);
            this.LabelSize = new System.Drawing.Size(164, 17);
            this.Name = "LabelledTextField";
            this.Size = new System.Drawing.Size(180, 93);
            this.Controls.SetChildIndex(this._DataField, 0);
            this.Controls.SetChildIndex(this._MenuButton, 0);
            this.Controls.SetChildIndex(this._Label, 0);
            ((System.ComponentModel.ISupportInitialize)(this._MenuButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BorderedTextField _DataField;

    }
}
