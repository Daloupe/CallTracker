namespace CallTracker.View
{
    partial class LATPanel
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
            this.labelledBase1 = new CallTracker.View.LabelledBase();
            this._NitResults = new CallTracker.View.LabelledTextField();
            this.serviceModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataDropDown1 = new CallTracker.View.LabelledComboBoxLong();
            this.labelledTextBoxLong1 = new CallTracker.View.LabelledTextBoxLong();
            ((System.ComponentModel.ISupportInitialize)(this.serviceModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelledBase1
            // 
            this.labelledBase1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledBase1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(30)))));
            this.labelledBase1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelledBase1.ControlHeight = 12;
            this.labelledBase1.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledBase1.LabelActiveColor = System.Drawing.Color.Empty;
            this.labelledBase1.LabelAutoSize = true;
            this.labelledBase1.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this.labelledBase1.LabelInactiveColor = System.Drawing.Color.Empty;
            this.labelledBase1.LabelOffset = new System.Drawing.Point(1, -2);
            this.labelledBase1.LabelSize = new System.Drawing.Size(38, 22);
            this.labelledBase1.LabelText = "//LAT";
            this.labelledBase1.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelledBase1.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledBase1.Location = new System.Drawing.Point(0, 0);
            this.labelledBase1.Margin = new System.Windows.Forms.Padding(0);
            this.labelledBase1.Name = "labelledBase1";
            this.labelledBase1.PropertyName = null;
            this.labelledBase1.Size = new System.Drawing.Size(180, 12);
            this.labelledBase1.TabIndex = 61;
            // 
            // _NitResults
            // 
            this._NitResults.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._NitResults.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._NitResults.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._NitResults.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._NitResults.ControlHeight = 93;
            this._NitResults.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "NitResults", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._NitResults.Font = new System.Drawing.Font("Verdana", 7F);
            this._NitResults.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._NitResults.LabelAutoSize = false;
            this._NitResults.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._NitResults.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._NitResults.LabelOffset = new System.Drawing.Point(0, 0);
            this._NitResults.LabelSize = new System.Drawing.Size(171, 17);
            this._NitResults.LabelText = "  nit results";
            this._NitResults.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._NitResults.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._NitResults.Location = new System.Drawing.Point(4, 59);
            this._NitResults.Margin = new System.Windows.Forms.Padding(0);
            this._NitResults.Name = "_NitResults";
            this._NitResults.PropertyName = null;
            this._NitResults.Size = new System.Drawing.Size(171, 93);
            this._NitResults.TabIndex = 60;
            this._NitResults.TextField = "";
            // 
            // serviceModelBindingSource
            // 
            this.serviceModelBindingSource.DataSource = typeof(CallTracker.Model.ServiceModel);
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
            this.dataDropDown1.LabelActiveColor = System.Drawing.Color.Empty;
            this.dataDropDown1.LabelAutoSize = true;
            this.dataDropDown1.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this.dataDropDown1.LabelInactiveColor = System.Drawing.Color.Empty;
            this.dataDropDown1.LabelOffset = new System.Drawing.Point(0, 0);
            this.dataDropDown1.LabelSize = new System.Drawing.Size(52, 23);
            this.dataDropDown1.LabelText = "cau ping";
            this.dataDropDown1.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dataDropDown1.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataDropDown1.Location = new System.Drawing.Point(4, 37);
            this.dataDropDown1.Name = "dataDropDown1";
            this.dataDropDown1.PropertyName = "CauPing";
            this.dataDropDown1.Size = new System.Drawing.Size(171, 20);
            this.dataDropDown1.TabIndex = 59;
            // 
            // labelledTextBoxLong1
            // 
            this.labelledTextBoxLong1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledTextBoxLong1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBoxLong1.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBoxLong1.ControlHeight = 20;
            this.labelledTextBoxLong1.ControlMargin = new System.Windows.Forms.Padding(2);
            this.labelledTextBoxLong1.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "Node", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelledTextBoxLong1.DefaultText = "";
            this.labelledTextBoxLong1.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledTextBoxLong1.LabelActiveColor = System.Drawing.Color.Firebrick;
            this.labelledTextBoxLong1.LabelAutoSize = false;
            this.labelledTextBoxLong1.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this.labelledTextBoxLong1.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBoxLong1.LabelOffset = new System.Drawing.Point(0, 0);
            this.labelledTextBoxLong1.LabelSize = new System.Drawing.Size(52, 20);
            this.labelledTextBoxLong1.LabelText = "node";
            this.labelledTextBoxLong1.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelledTextBoxLong1.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledTextBoxLong1.Location = new System.Drawing.Point(4, 16);
            this.labelledTextBoxLong1.Margin = new System.Windows.Forms.Padding(2);
            this.labelledTextBoxLong1.Name = "labelledTextBoxLong1";
            this.labelledTextBoxLong1.PropertyName = null;
            this.labelledTextBoxLong1.Size = new System.Drawing.Size(171, 20);
            this.labelledTextBoxLong1.TabIndex = 58;
            this.labelledTextBoxLong1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.labelledTextBoxLong1.TextField = "";
            // 
            // LATPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.labelledBase1);
            this.Controls.Add(this._NitResults);
            this.Controls.Add(this.dataDropDown1);
            this.Controls.Add(this.labelledTextBoxLong1);
            this.Name = "LATPanel";
            ((System.ComponentModel.ISupportInitialize)(this.serviceModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.BindingSource serviceModelBindingSource;
        private LabelledComboBoxLong dataDropDown1;
        private LabelledTextBoxLong labelledTextBoxLong1;
        private LabelledTextField _NitResults;
        private LabelledBase labelledBase1;
    }
}
