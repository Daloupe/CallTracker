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
            this.label1 = new System.Windows.Forms.Label();
            this._LoadingText = new System.Windows.Forms.Label();
            this._Version = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._LoginHeading = new System.Windows.Forms.Label();
            this._SetupLoginsPanel = new System.Windows.Forms.Panel();
            this._LoginConfirm = new System.Windows.Forms.PictureBox();
            this._LoginCancel = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this._Name = new CallTracker.View.LabelledTextBox();
            this._Id = new CallTracker.View.LabelledTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this._SetupLoginsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._LoginConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._LoginCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // Wingman
            // 
            this.Wingman.AutoSize = true;
            this.Wingman.BackColor = System.Drawing.Color.Transparent;
            this.Wingman.Font = new System.Drawing.Font("Optus Voice BETA Bold", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wingman.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this.Wingman.Location = new System.Drawing.Point(32, 16);
            this.Wingman.Name = "Wingman";
            this.Wingman.Size = new System.Drawing.Size(256, 64);
            this.Wingman.TabIndex = 0;
            this.Wingman.Text = "Wingman";
            // 
            // _LoadingBar
            // 
            this._LoadingBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(173)))));
            this._LoadingBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(0)))));
            this._LoadingBar.Location = new System.Drawing.Point(31, 180);
            this._LoadingBar.Name = "_LoadingBar";
            this._LoadingBar.Size = new System.Drawing.Size(250, 23);
            this._LoadingBar.Step = 1;
            this._LoadingBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._LoadingBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Optus Voice BETA Bold", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(173)))));
            this.label1.Location = new System.Drawing.Point(27, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 64);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wingman";
            // 
            // _LoadingText
            // 
            this._LoadingText.BackColor = System.Drawing.Color.Transparent;
            this._LoadingText.Font = new System.Drawing.Font("TradeGothicLTPro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LoadingText.ForeColor = System.Drawing.SystemColors.Window;
            this._LoadingText.Location = new System.Drawing.Point(31, 206);
            this._LoadingText.Name = "_LoadingText";
            this._LoadingText.Size = new System.Drawing.Size(250, 17);
            this._LoadingText.TabIndex = 3;
            // 
            // _Version
            // 
            this._Version.BackColor = System.Drawing.Color.Transparent;
            this._Version.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Version.Font = new System.Drawing.Font("Gautami", 7.75F);
            this._Version.ForeColor = System.Drawing.Color.PaleTurquoise;
            this._Version.Location = new System.Drawing.Point(193, 66);
            this._Version.Margin = new System.Windows.Forms.Padding(0);
            this._Version.Name = "_Version";
            this._Version.Size = new System.Drawing.Size(116, 15);
            this._Version.TabIndex = 4;
            this._Version.Text = "Version: 0.32.3";
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
            // _LoginHeading
            // 
            this._LoginHeading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(173)))));
            this._LoginHeading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._LoginHeading.Font = new System.Drawing.Font("Gautami", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LoginHeading.ForeColor = System.Drawing.Color.White;
            this._LoginHeading.Location = new System.Drawing.Point(3, 3);
            this._LoginHeading.Margin = new System.Windows.Forms.Padding(0);
            this._LoginHeading.Name = "_LoginHeading";
            this._LoginHeading.Size = new System.Drawing.Size(244, 20);
            this._LoginHeading.TabIndex = 8;
            this._LoginHeading.Text = "Setup logins";
            this._LoginHeading.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // _SetupLoginsPanel
            // 
            this._SetupLoginsPanel.BackColor = System.Drawing.Color.Transparent;
            this._SetupLoginsPanel.Controls.Add(this._LoginConfirm);
            this._SetupLoginsPanel.Controls.Add(this._LoginCancel);
            this._SetupLoginsPanel.Controls.Add(this._Name);
            this._SetupLoginsPanel.Controls.Add(this._LoginHeading);
            this._SetupLoginsPanel.Controls.Add(this._Id);
            this._SetupLoginsPanel.Enabled = false;
            this._SetupLoginsPanel.Location = new System.Drawing.Point(289, 126);
            this._SetupLoginsPanel.Name = "_SetupLoginsPanel";
            this._SetupLoginsPanel.Size = new System.Drawing.Size(250, 59);
            this._SetupLoginsPanel.TabIndex = 9;
            this._SetupLoginsPanel.Visible = false;
            this._SetupLoginsPanel.VisibleChanged += new System.EventHandler(this._SetupLoginsPanel_VisibleChanged);
            this._SetupLoginsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // _LoginConfirm
            // 
            this._LoginConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(173)))));
            this._LoginConfirm.BackgroundImage = global::CallTracker.Properties.Resources.AddImage;
            this._LoginConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._LoginConfirm.Location = new System.Drawing.Point(205, 4);
            this._LoginConfirm.Name = "_LoginConfirm";
            this._LoginConfirm.Size = new System.Drawing.Size(18, 18);
            this._LoginConfirm.TabIndex = 10;
            this._LoginConfirm.TabStop = false;
            this._LoginConfirm.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // _LoginCancel
            // 
            this._LoginCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(173)))));
            this._LoginCancel.BackgroundImage = global::CallTracker.Properties.Resources.bindingNavigatorDeleteItem_Image;
            this._LoginCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._LoginCancel.Location = new System.Drawing.Point(226, 4);
            this._LoginCancel.Name = "_LoginCancel";
            this._LoginCancel.Size = new System.Drawing.Size(18, 18);
            this._LoginCancel.TabIndex = 9;
            this._LoginCancel.TabStop = false;
            this._LoginCancel.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // _Name
            // 
            this._Name.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(173)))));
            this._Name.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._Name.BorderColour = System.Drawing.Color.WhiteSmoke;
            this._Name.ControlHeight = 30;
            this._Name.DefaultText = "";
            this._Name.Font = new System.Drawing.Font("Verdana", 7F);
            this._Name.LabelActiveColor = System.Drawing.Color.Empty;
            this._Name.LabelAutoSize = true;
            this._Name.LabelBorderColor = System.Drawing.Color.Empty;
            this._Name.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this._Name.LabelInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(173)))));
            this._Name.LabelMargin = new System.Windows.Forms.Padding(0);
            this._Name.LabelOffset = new System.Drawing.Point(1, -2);
            this._Name.LabelPadding = new System.Windows.Forms.Padding(0);
            this._Name.LabelSize = new System.Drawing.Size(40, 22);
            this._Name.LabelText = "NAME:";
            this._Name.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Name.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Name.Location = new System.Drawing.Point(3, 25);
            this._Name.Margin = new System.Windows.Forms.Padding(0);
            this._Name.Name = "_Name";
            this._Name.PropertyName = null;
            this._Name.Size = new System.Drawing.Size(170, 30);
            this._Name.TabIndex = 6;
            this._Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._Name.TextField = "";
            this._Name.TextFieldBackColour = System.Drawing.SystemColors.Window;
            this._Name.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // _Id
            // 
            this._Id.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Id.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(173)))));
            this._Id.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._Id.BorderColour = System.Drawing.Color.WhiteSmoke;
            this._Id.ControlHeight = 30;
            this._Id.DefaultText = "";
            this._Id.Font = new System.Drawing.Font("Verdana", 7F);
            this._Id.LabelActiveColor = System.Drawing.Color.Empty;
            this._Id.LabelAutoSize = true;
            this._Id.LabelBorderColor = System.Drawing.Color.Empty;
            this._Id.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this._Id.LabelInactiveColor = System.Drawing.Color.Empty;
            this._Id.LabelMargin = new System.Windows.Forms.Padding(0);
            this._Id.LabelOffset = new System.Drawing.Point(1, -2);
            this._Id.LabelPadding = new System.Windows.Forms.Padding(0);
            this._Id.LabelSize = new System.Drawing.Size(47, 22);
            this._Id.LabelText = "EMP ID:";
            this._Id.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Id.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Id.Location = new System.Drawing.Point(175, 25);
            this._Id.Margin = new System.Windows.Forms.Padding(0);
            this._Id.Name = "_Id";
            this._Id.PropertyName = null;
            this._Id.Size = new System.Drawing.Size(72, 30);
            this._Id.TabIndex = 7;
            this._Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._Id.TextField = "";
            this._Id.TextFieldBackColour = System.Drawing.SystemColors.Window;
            this._Id.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CallTracker.Properties.Resources.blue_gradient_300;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(300, 238);
            this.Controls.Add(this._LoadingText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._Version);
            this.Controls.Add(this.Wingman);
            this.Controls.Add(this._LoadingBar);
            this.Controls.Add(this._SetupLoginsPanel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SplashScreen_FormClosed);
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this._SetupLoginsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._LoginConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._LoginCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Wingman;
        private System.Windows.Forms.ProgressBar _LoadingBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label _LoadingText;
        private LabelledTextBox _Name;
        private LabelledTextBox _Id;
        private System.Windows.Forms.Label _LoginHeading;
        private System.Windows.Forms.PictureBox _LoginConfirm;
        private System.Windows.Forms.PictureBox _LoginCancel;
        internal System.Windows.Forms.Panel _SetupLoginsPanel;
        internal System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label _Version;
    }
}