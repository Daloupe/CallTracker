namespace CallTracker.View
{
    partial class PanelHeading
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
            this.SuspendLayout();
            // 
            // _Label
            // 
            this._Label.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._Label.Dock = System.Windows.Forms.DockStyle.Left;
            this._Label.Font = new System.Drawing.Font("Verdana", 7F);
            this._Label.ForeColor = System.Drawing.SystemColors.ControlLight;
            this._Label.Location = new System.Drawing.Point(2, 2);
            this._Label.Margin = new System.Windows.Forms.Padding(0);
            this._Label.Name = "_Label";
            this._Label.Size = new System.Drawing.Size(176, 14);
            this._Label.TabIndex = 26;
            this._Label.Text = "//Panel";
            this._Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Label.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrayBorder);
            // 
            // PanelHeading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._Label);
            this.Font = new System.Drawing.Font("Verdana", 6.5F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PanelHeading";
            this.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Size = new System.Drawing.Size(180, 18);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _Label;
    }
}
