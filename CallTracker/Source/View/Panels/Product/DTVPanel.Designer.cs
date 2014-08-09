namespace CallTracker.View
{
    partial class DTVPanel
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
            this.serviceModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelledBase1 = new CallTracker.View.LabelledBase();
            this.labelledTextBoxLong1 = new CallTracker.View.LabelledTextBoxLong();
            this.labelledTextBoxLong2 = new CallTracker.View.LabelledTextBoxLong();
            this.dataDropDown1 = new CallTracker.View.LabelledComboBoxLong();
            this.labelledBase2 = new CallTracker.View.LabelledBase();
            this.labelledTextBoxLong3 = new CallTracker.View.LabelledTextBoxLong();
            this.labelledTextBox1 = new CallTracker.View.LabelledTextBox();
            this.labelledTextBox2 = new CallTracker.View.LabelledTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.serviceModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // serviceModelBindingSource
            // 
            this.serviceModelBindingSource.DataSource = typeof(CallTracker.Model.ServiceModel);
            // 
            // labelledBase1
            // 
            this.labelledBase1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledBase1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(30)))));
            this.labelledBase1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelledBase1.ControlHeight = 12;
            this.labelledBase1.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledBase1.LabelAutoSize = true;
            this.labelledBase1.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this.labelledBase1.LabelOffset = new System.Drawing.Point(1, -2);
            this.labelledBase1.LabelSize = new System.Drawing.Size(40, 22);
            this.labelledBase1.LabelText = "//DTV";
            this.labelledBase1.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelledBase1.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledBase1.Location = new System.Drawing.Point(0, 0);
            this.labelledBase1.Margin = new System.Windows.Forms.Padding(0);
            this.labelledBase1.Name = "labelledBase1";
            this.labelledBase1.PropertyName = null;
            this.labelledBase1.Size = new System.Drawing.Size(180, 12);
            this.labelledBase1.TabIndex = 54;
            // 
            // labelledTextBoxLong1
            // 
            this.labelledTextBoxLong1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledTextBoxLong1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBoxLong1.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBoxLong1.ControlHeight = 19;
            this.labelledTextBoxLong1.ControlMargin = new System.Windows.Forms.Padding(2);
            this.labelledTextBoxLong1.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "Node", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelledTextBoxLong1.DefaultText = "";
            this.labelledTextBoxLong1.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledTextBoxLong1.LabelAutoSize = true;
            this.labelledTextBoxLong1.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this.labelledTextBoxLong1.LabelOffset = new System.Drawing.Point(0, 0);
            this.labelledTextBoxLong1.LabelSize = new System.Drawing.Size(34, 23);
            this.labelledTextBoxLong1.LabelText = "node";
            this.labelledTextBoxLong1.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelledTextBoxLong1.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledTextBoxLong1.Location = new System.Drawing.Point(5, 15);
            this.labelledTextBoxLong1.Margin = new System.Windows.Forms.Padding(2);
            this.labelledTextBoxLong1.Name = "labelledTextBoxLong1";
            this.labelledTextBoxLong1.PropertyName = null;
            this.labelledTextBoxLong1.Size = new System.Drawing.Size(171, 19);
            this.labelledTextBoxLong1.TabIndex = 55;
            this.labelledTextBoxLong1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.labelledTextBoxLong1.TextField = "";
            // 
            // labelledTextBoxLong2
            // 
            this.labelledTextBoxLong2.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledTextBoxLong2.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBoxLong2.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBoxLong2.ControlHeight = 19;
            this.labelledTextBoxLong2.ControlMargin = new System.Windows.Forms.Padding(2);
            this.labelledTextBoxLong2.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "DTVMsg", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelledTextBoxLong2.DefaultText = "";
            this.labelledTextBoxLong2.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledTextBoxLong2.LabelAutoSize = false;
            this.labelledTextBoxLong2.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this.labelledTextBoxLong2.LabelOffset = new System.Drawing.Point(0, 0);
            this.labelledTextBoxLong2.LabelSize = new System.Drawing.Size(34, 19);
            this.labelledTextBoxLong2.LabelText = "msg";
            this.labelledTextBoxLong2.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelledTextBoxLong2.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledTextBoxLong2.Location = new System.Drawing.Point(5, 36);
            this.labelledTextBoxLong2.Margin = new System.Windows.Forms.Padding(2);
            this.labelledTextBoxLong2.Name = "labelledTextBoxLong2";
            this.labelledTextBoxLong2.PropertyName = null;
            this.labelledTextBoxLong2.Size = new System.Drawing.Size(171, 19);
            this.labelledTextBoxLong2.TabIndex = 56;
            this.labelledTextBoxLong2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.labelledTextBoxLong2.TextField = "";
            // 
            // dataDropDown1
            // 
            this.dataDropDown1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.dataDropDown1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.dataDropDown1.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this.dataDropDown1.ControlHeight = 20;
            this.dataDropDown1.DataSource = null;
            this.dataDropDown1.DefaultText = "";
            this.dataDropDown1.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataDropDown1.LabelAutoSize = true;
            this.dataDropDown1.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this.dataDropDown1.LabelOffset = new System.Drawing.Point(0, 0);
            this.dataDropDown1.LabelSize = new System.Drawing.Size(64, 23);
            this.dataDropDown1.LabelText = "connection";
            this.dataDropDown1.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dataDropDown1.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataDropDown1.Location = new System.Drawing.Point(5, 57);
            this.dataDropDown1.Name = "dataDropDown1";
            this.dataDropDown1.PropertyName = "ConnectionType";
            this.dataDropDown1.Size = new System.Drawing.Size(171, 20);
            this.dataDropDown1.TabIndex = 57;
            // 
            // labelledBase2
            // 
            this.labelledBase2.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledBase2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(30)))));
            this.labelledBase2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelledBase2.ControlHeight = 12;
            this.labelledBase2.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledBase2.LabelAutoSize = true;
            this.labelledBase2.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this.labelledBase2.LabelOffset = new System.Drawing.Point(1, -2);
            this.labelledBase2.LabelSize = new System.Drawing.Size(40, 22);
            this.labelledBase2.LabelText = "//STB";
            this.labelledBase2.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelledBase2.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledBase2.Location = new System.Drawing.Point(0, 81);
            this.labelledBase2.Margin = new System.Windows.Forms.Padding(0);
            this.labelledBase2.Name = "labelledBase2";
            this.labelledBase2.PropertyName = null;
            this.labelledBase2.Size = new System.Drawing.Size(180, 12);
            this.labelledBase2.TabIndex = 58;
            // 
            // labelledTextBoxLong3
            // 
            this.labelledTextBoxLong3.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledTextBoxLong3.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBoxLong3.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBoxLong3.ControlHeight = 19;
            this.labelledTextBoxLong3.ControlMargin = new System.Windows.Forms.Padding(2);
            this.labelledTextBoxLong3.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "DTVSmartCard", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelledTextBoxLong3.DefaultText = "";
            this.labelledTextBoxLong3.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledTextBoxLong3.LabelAutoSize = false;
            this.labelledTextBoxLong3.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this.labelledTextBoxLong3.LabelOffset = new System.Drawing.Point(0, 0);
            this.labelledTextBoxLong3.LabelSize = new System.Drawing.Size(64, 19);
            this.labelledTextBoxLong3.LabelText = "smartcard";
            this.labelledTextBoxLong3.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelledTextBoxLong3.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledTextBoxLong3.Location = new System.Drawing.Point(5, 96);
            this.labelledTextBoxLong3.Margin = new System.Windows.Forms.Padding(2);
            this.labelledTextBoxLong3.Name = "labelledTextBoxLong3";
            this.labelledTextBoxLong3.PropertyName = null;
            this.labelledTextBoxLong3.Size = new System.Drawing.Size(171, 19);
            this.labelledTextBoxLong3.TabIndex = 59;
            this.labelledTextBoxLong3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.labelledTextBoxLong3.TextField = "";
            // 
            // labelledTextBox1
            // 
            this.labelledTextBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledTextBox1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelledTextBox1.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBox1.ControlHeight = 32;
            this.labelledTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "DTVLot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelledTextBox1.DefaultText = "";
            this.labelledTextBox1.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledTextBox1.LabelAutoSize = true;
            this.labelledTextBox1.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this.labelledTextBox1.LabelOffset = new System.Drawing.Point(1, -2);
            this.labelledTextBox1.LabelSize = new System.Drawing.Size(22, 23);
            this.labelledTextBox1.LabelText = "lot";
            this.labelledTextBox1.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelledTextBox1.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledTextBox1.Location = new System.Drawing.Point(5, 117);
            this.labelledTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.labelledTextBox1.Name = "labelledTextBox1";
            this.labelledTextBox1.PropertyName = null;
            this.labelledTextBox1.Size = new System.Drawing.Size(65, 32);
            this.labelledTextBox1.TabIndex = 60;
            this.labelledTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.labelledTextBox1.TextField = "";
            // 
            // labelledTextBox2
            // 
            this.labelledTextBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledTextBox2.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelledTextBox2.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBox2.ControlHeight = 32;
            this.labelledTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "DTVBox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelledTextBox2.DefaultText = "";
            this.labelledTextBox2.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledTextBox2.LabelAutoSize = true;
            this.labelledTextBox2.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this.labelledTextBox2.LabelOffset = new System.Drawing.Point(1, -2);
            this.labelledTextBox2.LabelSize = new System.Drawing.Size(27, 23);
            this.labelledTextBox2.LabelText = "box";
            this.labelledTextBox2.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelledTextBox2.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledTextBox2.Location = new System.Drawing.Point(72, 117);
            this.labelledTextBox2.Margin = new System.Windows.Forms.Padding(0);
            this.labelledTextBox2.Name = "labelledTextBox2";
            this.labelledTextBox2.PropertyName = null;
            this.labelledTextBox2.Size = new System.Drawing.Size(104, 32);
            this.labelledTextBox2.TabIndex = 61;
            this.labelledTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.labelledTextBox2.TextField = "";
            // 
            // DTVPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.labelledTextBox2);
            this.Controls.Add(this.labelledTextBox1);
            this.Controls.Add(this.labelledTextBoxLong3);
            this.Controls.Add(this.labelledBase2);
            this.Controls.Add(this.dataDropDown1);
            this.Controls.Add(this.labelledTextBoxLong2);
            this.Controls.Add(this.labelledTextBoxLong1);
            this.Controls.Add(this.labelledBase1);
            this.Name = "DTVPanel";
            ((System.ComponentModel.ISupportInitialize)(this.serviceModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.BindingSource serviceModelBindingSource;
        private LabelledBase labelledBase1;
        private LabelledTextBoxLong labelledTextBoxLong1;
        private LabelledTextBoxLong labelledTextBoxLong2;
        private LabelledComboBoxLong dataDropDown1;
        private LabelledBase labelledBase2;
        private LabelledTextBoxLong labelledTextBoxLong3;
        private LabelledTextBox labelledTextBox1;
        private LabelledTextBox labelledTextBox2;
    }
}
