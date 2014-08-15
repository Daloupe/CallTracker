namespace CallTracker.View
{
    partial class PanelBase
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
            this._ServiceHeading = new CallTracker.View.LabelledBase();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // _ServiceHeading
            // 
            this._ServiceHeading.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._ServiceHeading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(30)))));
            this._ServiceHeading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._ServiceHeading.ControlHeight = 12;
            this._ServiceHeading.Font = new System.Drawing.Font("Verdana", 7F);
            this._ServiceHeading.LabelActiveColor = System.Drawing.Color.Empty;
            this._ServiceHeading.LabelAutoSize = true;
            this._ServiceHeading.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this._ServiceHeading.LabelInactiveColor = System.Drawing.Color.Empty;
            this._ServiceHeading.LabelOffset = new System.Drawing.Point(1, -2);
            this._ServiceHeading.LabelSize = new System.Drawing.Size(22, 22);
            this._ServiceHeading.LabelText = "//";
            this._ServiceHeading.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._ServiceHeading.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._ServiceHeading.Location = new System.Drawing.Point(0, 0);
            this._ServiceHeading.Margin = new System.Windows.Forms.Padding(0);
            this._ServiceHeading.Name = "_ServiceHeading";
            this._ServiceHeading.PropertyName = null;
            this._ServiceHeading.Size = new System.Drawing.Size(180, 12);
            this._ServiceHeading.TabIndex = 71;
            // 
            // PanelBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this._ServiceHeading);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Name = "PanelBase";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(180, 572);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        internal LabelledBase _ServiceHeading;



    }
}
