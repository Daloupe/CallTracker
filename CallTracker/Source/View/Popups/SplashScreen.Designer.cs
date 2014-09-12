namespace CallTracker.View
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            this.Wingman = new System.Windows.Forms.Label();
            this._LoadingBar = new System.Windows.Forms.ProgressBar();
            this.WingmanBG = new System.Windows.Forms.Label();
            this._LoadingText = new System.Windows.Forms.Label();
            this._CancelLoading = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this._Version = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._CancelLoading)).BeginInit();
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
            // _LoadingBar
            // 
            this._LoadingBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(173)))));
            this._LoadingBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this._LoadingBar.Location = new System.Drawing.Point(25, 180);
            this._LoadingBar.Name = "_LoadingBar";
            this._LoadingBar.Size = new System.Drawing.Size(250, 23);
            this._LoadingBar.Step = 1;
            this._LoadingBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._LoadingBar.TabIndex = 1;
            // 
            // WingmanBG
            // 
            this.WingmanBG.AutoSize = true;
            this.WingmanBG.BackColor = System.Drawing.Color.Transparent;
            this.WingmanBG.Font = new System.Drawing.Font("Optus Voice BETA Bold", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WingmanBG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(173)))));
            this.WingmanBG.Location = new System.Drawing.Point(19, 66);
            this.WingmanBG.Name = "WingmanBG";
            this.WingmanBG.Size = new System.Drawing.Size(256, 64);
            this.WingmanBG.TabIndex = 2;
            this.WingmanBG.Text = "Wingman";
            // 
            // _LoadingText
            // 
            this._LoadingText.BackColor = System.Drawing.Color.Transparent;
            this._LoadingText.Font = new System.Drawing.Font("Gautami", 11.75F);
            this._LoadingText.ForeColor = System.Drawing.Color.PowderBlue;
            this._LoadingText.Location = new System.Drawing.Point(19, 204);
            this._LoadingText.Name = "_LoadingText";
            this._LoadingText.Size = new System.Drawing.Size(250, 28);
            this._LoadingText.TabIndex = 3;
            // 
            // _CancelLoading
            // 
            this._CancelLoading.BackColor = System.Drawing.Color.Transparent;
            this._CancelLoading.Cursor = System.Windows.Forms.Cursors.Hand;
            this._CancelLoading.Enabled = false;
            this._CancelLoading.Image = global::CallTracker.Properties.Resources.Close;
            this._CancelLoading.Location = new System.Drawing.Point(289, 2);
            this._CancelLoading.Name = "_CancelLoading";
            this._CancelLoading.Size = new System.Drawing.Size(10, 11);
            this._CancelLoading.TabIndex = 5;
            this._CancelLoading.TabStop = false;
            this._CancelLoading.Visible = false;
            this._CancelLoading.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // _Version
            // 
            this._Version.BackColor = System.Drawing.Color.Transparent;
            this._Version.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::CallTracker.Properties.Settings.Default, "Version", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Version.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Version.Font = new System.Drawing.Font("Gautami", 7.75F);
            this._Version.ForeColor = System.Drawing.Color.PaleTurquoise;
            this._Version.Location = new System.Drawing.Point(225, 67);
            this._Version.Margin = new System.Windows.Forms.Padding(0);
            this._Version.Name = "_Version";
            this._Version.Size = new System.Drawing.Size(65, 14);
            this._Version.TabIndex = 11;
            this._Version.Text = global::CallTracker.Properties.Settings.Default.Version;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Gautami", 7.75F);
            this.label3.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.label3.Location = new System.Drawing.Point(183, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Version: 0.32.3";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CallTracker.Properties.Resources.blue_gradient_300;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(300, 238);
            this.Controls.Add(this._Version);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._LoadingBar);
            this.Controls.Add(this._LoadingText);
            this.Controls.Add(this._CancelLoading);
            this.Controls.Add(this.Wingman);
            this.Controls.Add(this.WingmanBG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SplashScreen_FormClosed);
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this._CancelLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Wingman;
        private System.Windows.Forms.ProgressBar _LoadingBar;
        private System.Windows.Forms.Label WingmanBG;
        private System.Windows.Forms.PictureBox _CancelLoading;
        internal System.Windows.Forms.Label _LoadingText;
        internal System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label _Version;
        internal System.Windows.Forms.Label label3;
    }
}