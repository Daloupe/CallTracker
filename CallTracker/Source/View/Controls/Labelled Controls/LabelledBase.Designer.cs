namespace CallTracker.View
{
    partial class LabelledBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelledBase));
            this._MenuButton = new System.Windows.Forms.PictureBox();
            this._Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._MenuButton)).BeginInit();
            this.SuspendLayout();
            // 
            // _MenuButton
            // 
            this._MenuButton.BackColor = System.Drawing.Color.Transparent;
            this._MenuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_MenuButton.BackgroundImage")));
            this._MenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._MenuButton.Dock = System.Windows.Forms.DockStyle.Right;
            this._MenuButton.Location = new System.Drawing.Point(164, 0);
            this._MenuButton.Margin = new System.Windows.Forms.Padding(0);
            this._MenuButton.Name = "_MenuButton";
            this._MenuButton.Size = new System.Drawing.Size(16, 32);
            this._MenuButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._MenuButton.TabIndex = 30;
            this._MenuButton.TabStop = false;
            this._MenuButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this._MenuButton_MouseClick);
            // 
            // _Label
            // 
            this._Label.AutoSize = true;
            this._Label.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._Label.Font = new System.Drawing.Font("Gautami", 7F);
            this._Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Label.Location = new System.Drawing.Point(1, -2);
            this._Label.Margin = new System.Windows.Forms.Padding(0);
            this._Label.MaximumSize = new System.Drawing.Size(300, 70);
            this._Label.MinimumSize = new System.Drawing.Size(9, 6);
            this._Label.Name = "_Label";
            this._Label.Size = new System.Drawing.Size(30, 22);
            this._Label.TabIndex = 26;
            this._Label.Text = "AVC:";
            this._Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelledBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this._MenuButton);
            this.Controls.Add(this._Label);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LabelledBase";
            this.Size = new System.Drawing.Size(180, 32);
            ((System.ComponentModel.ISupportInitialize)(this._MenuButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label _Label;
        protected System.Windows.Forms.PictureBox _MenuButton;

    }
}
