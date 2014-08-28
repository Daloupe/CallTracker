namespace CallTracker.View
{
    partial class AboutScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Wingman = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._VersionLabel = new System.Windows.Forms.Label();
            this._Version = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Wingman
            // 
            this.Wingman.AutoSize = true;
            this.Wingman.BackColor = System.Drawing.Color.Transparent;
            this.Wingman.Font = new System.Drawing.Font("Optus Voice BETA Bold", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wingman.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.Wingman.Location = new System.Drawing.Point(22, 16);
            this.Wingman.Name = "Wingman";
            this.Wingman.Size = new System.Drawing.Size(256, 64);
            this.Wingman.TabIndex = 0;
            this.Wingman.Text = "Wingman";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Optus Voice BETA Bold", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(173)))));
            this.label1.Location = new System.Drawing.Point(19, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 64);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wingman";
            // 
            // _VersionLabel
            // 
            this._VersionLabel.BackColor = System.Drawing.Color.Transparent;
            this._VersionLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._VersionLabel.Font = new System.Drawing.Font("Gautami", 7.75F);
            this._VersionLabel.ForeColor = System.Drawing.Color.PaleTurquoise;
            this._VersionLabel.Location = new System.Drawing.Point(183, 66);
            this._VersionLabel.Margin = new System.Windows.Forms.Padding(0);
            this._VersionLabel.Name = "_VersionLabel";
            this._VersionLabel.Size = new System.Drawing.Size(49, 14);
            this._VersionLabel.TabIndex = 4;
            this._VersionLabel.Text = "Version: 0.32.3";
            // 
            // _Version
            // 
            this._Version.BackColor = System.Drawing.Color.Transparent;
            this._Version.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::CallTracker.Properties.Settings.Default, "Version", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Version.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Version.Font = new System.Drawing.Font("Gautami", 7.75F);
            this._Version.ForeColor = System.Drawing.Color.PaleTurquoise;
            this._Version.Location = new System.Drawing.Point(225, 66);
            this._Version.Margin = new System.Windows.Forms.Padding(0);
            this._Version.Name = "_Version";
            this._Version.Size = new System.Drawing.Size(65, 14);
            this._Version.TabIndex = 6;
            this._Version.Text = global::CallTracker.Properties.Settings.Default.Version;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Gautami", 7.75F);
            this.label3.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.label3.Location = new System.Drawing.Point(75, 215);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "jesse.poulton@optus.com.au";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CallTracker.Properties.Resources.Close;
            this.pictureBox1.Location = new System.Drawing.Point(289, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 11);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // AboutScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CallTracker.Properties.Resources.blue_gradient_300;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(300, 238);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._Version);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._VersionLabel);
            this.Controls.Add(this.Wingman);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Wingman;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label _VersionLabel;
        internal System.Windows.Forms.Label _Version;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}