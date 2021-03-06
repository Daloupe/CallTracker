﻿namespace CallTracker.View
{
    partial class ONCPanel
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
            this.dataField1 = new CallTracker.View.DataField();
            this.dataDropDown1 = new CallTracker.View.DataDropDown();
            this.panelHeading1 = new CallTracker.View.PanelHeading();
            this.dataDropDown2 = new CallTracker.View.DataDropDown();
            this.dataField2 = new CallTracker.View.DataField();
            this.panelHeading2 = new CallTracker.View.PanelHeading();
            this.dataField3 = new CallTracker.View.DataField();
            this.dataField4 = new CallTracker.View.DataField();
            this.panelHeading3 = new CallTracker.View.PanelHeading();
            this.dataField5 = new CallTracker.View.DataField();
            this.dataField6 = new CallTracker.View.DataField();
            ((System.ComponentModel.ISupportInitialize)(this.serviceModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // serviceModelBindingSource
            // 
            this.serviceModelBindingSource.DataSource = typeof(CallTracker.Model.ServiceModel);
            // 
            // dataField1
            // 
            this.dataField1.BackColor = System.Drawing.Color.Ivory;
            this.dataField1.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "Node", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField1.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField1.LabelText = "Node:";
            this.dataField1.LabelWidth = 35;
            this.dataField1.Location = new System.Drawing.Point(0, 17);
            this.dataField1.Margin = new System.Windows.Forms.Padding(0);
            this.dataField1.Name = "dataField1";
            this.dataField1.Padding = new System.Windows.Forms.Padding(3);
            this.dataField1.Size = new System.Drawing.Size(180, 25);
            this.dataField1.TabIndex = 37;
            this.dataField1.TextField = "";
            // 
            // dataDropDown1
            // 
            this.dataDropDown1.DataBindings.Add(new System.Windows.Forms.Binding("DataText", this.serviceModelBindingSource, "ModemStatus", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataDropDown1.DataSelectedItem = "";
            this.dataDropDown1.DataSelectedValue = "";
            this.dataDropDown1.DataText = "";
            this.dataDropDown1.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataDropDown1.LabelText = "Modem Status:";
            this.dataDropDown1.LabelWidth = 85;
            this.dataDropDown1.Location = new System.Drawing.Point(0, 42);
            this.dataDropDown1.Margin = new System.Windows.Forms.Padding(0);
            this.dataDropDown1.Name = "dataDropDown1";
            this.dataDropDown1.Padding = new System.Windows.Forms.Padding(3);
            this.dataDropDown1.Size = new System.Drawing.Size(179, 25);
            this.dataDropDown1.TabIndex = 45;
            // 
            // panelHeading1
            // 
            this.panelHeading1.Font = new System.Drawing.Font("Verdana", 7F);
            this.panelHeading1.LabelText = "//ONC";
            this.panelHeading1.Location = new System.Drawing.Point(0, 0);
            this.panelHeading1.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeading1.Name = "panelHeading1";
            this.panelHeading1.Padding = new System.Windows.Forms.Padding(2);
            this.panelHeading1.Size = new System.Drawing.Size(180, 17);
            this.panelHeading1.TabIndex = 46;
            // 
            // dataDropDown2
            // 
            this.dataDropDown2.DataBindings.Add(new System.Windows.Forms.Binding("DataText", this.serviceModelBindingSource, "RFIssues", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataDropDown2.DataSelectedItem = "";
            this.dataDropDown2.DataSelectedValue = "";
            this.dataDropDown2.DataText = "";
            this.dataDropDown2.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataDropDown2.LabelText = "RF Issues:";
            this.dataDropDown2.LabelWidth = 85;
            this.dataDropDown2.Location = new System.Drawing.Point(0, 67);
            this.dataDropDown2.Margin = new System.Windows.Forms.Padding(0);
            this.dataDropDown2.Name = "dataDropDown2";
            this.dataDropDown2.Padding = new System.Windows.Forms.Padding(3);
            this.dataDropDown2.Size = new System.Drawing.Size(179, 25);
            this.dataDropDown2.TabIndex = 47;
            // 
            // dataField2
            // 
            this.dataField2.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "CMMac", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField2.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField2.LabelText = "CM:";
            this.dataField2.LabelWidth = 34;
            this.dataField2.Location = new System.Drawing.Point(0, 151);
            this.dataField2.Margin = new System.Windows.Forms.Padding(0);
            this.dataField2.Name = "dataField2";
            this.dataField2.Padding = new System.Windows.Forms.Padding(3);
            this.dataField2.Size = new System.Drawing.Size(180, 25);
            this.dataField2.TabIndex = 48;
            this.dataField2.TextField = "";
            // 
            // panelHeading2
            // 
            this.panelHeading2.Font = new System.Drawing.Font("Verdana", 7F);
            this.panelHeading2.LabelText = "//Modem MAC";
            this.panelHeading2.Location = new System.Drawing.Point(0, 134);
            this.panelHeading2.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeading2.Name = "panelHeading2";
            this.panelHeading2.Padding = new System.Windows.Forms.Padding(2);
            this.panelHeading2.Size = new System.Drawing.Size(180, 17);
            this.panelHeading2.TabIndex = 49;
            // 
            // dataField3
            // 
            this.dataField3.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "MTAMac", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField3.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField3.LabelText = "MTA:";
            this.dataField3.LabelWidth = 34;
            this.dataField3.Location = new System.Drawing.Point(0, 176);
            this.dataField3.Margin = new System.Windows.Forms.Padding(0);
            this.dataField3.Name = "dataField3";
            this.dataField3.Padding = new System.Windows.Forms.Padding(3);
            this.dataField3.Size = new System.Drawing.Size(180, 25);
            this.dataField3.TabIndex = 50;
            this.dataField3.TextField = "";
            // 
            // dataField4
            // 
            this.dataField4.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "ModemSN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField4.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField4.LabelText = "SN:";
            this.dataField4.LabelWidth = 34;
            this.dataField4.Location = new System.Drawing.Point(0, 201);
            this.dataField4.Margin = new System.Windows.Forms.Padding(0);
            this.dataField4.Name = "dataField4";
            this.dataField4.Padding = new System.Windows.Forms.Padding(3);
            this.dataField4.Size = new System.Drawing.Size(180, 25);
            this.dataField4.TabIndex = 51;
            this.dataField4.TextField = "";
            // 
            // panelHeading3
            // 
            this.panelHeading3.Font = new System.Drawing.Font("Verdana", 7F);
            this.panelHeading3.LabelText = "//Speed Test Results";
            this.panelHeading3.Location = new System.Drawing.Point(0, 92);
            this.panelHeading3.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeading3.Name = "panelHeading3";
            this.panelHeading3.Padding = new System.Windows.Forms.Padding(2);
            this.panelHeading3.Size = new System.Drawing.Size(180, 17);
            this.panelHeading3.TabIndex = 52;
            // 
            // dataField5
            // 
            this.dataField5.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "DownloadSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField5.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField5.LabelText = "Down:";
            this.dataField5.LabelWidth = 36;
            this.dataField5.Location = new System.Drawing.Point(89, 109);
            this.dataField5.Margin = new System.Windows.Forms.Padding(0);
            this.dataField5.Name = "dataField5";
            this.dataField5.Padding = new System.Windows.Forms.Padding(3);
            this.dataField5.Size = new System.Drawing.Size(91, 25);
            this.dataField5.TabIndex = 53;
            this.dataField5.TextField = "";
            // 
            // dataField6
            // 
            this.dataField6.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "UploadSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField6.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField6.LabelText = "Up:";
            this.dataField6.LabelWidth = 34;
            this.dataField6.Location = new System.Drawing.Point(0, 109);
            this.dataField6.Margin = new System.Windows.Forms.Padding(0);
            this.dataField6.Name = "dataField6";
            this.dataField6.Padding = new System.Windows.Forms.Padding(3);
            this.dataField6.Size = new System.Drawing.Size(89, 25);
            this.dataField6.TabIndex = 54;
            this.dataField6.TextField = "";
            // 
            // ONCPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.dataField6);
            this.Controls.Add(this.dataField5);
            this.Controls.Add(this.panelHeading3);
            this.Controls.Add(this.dataField4);
            this.Controls.Add(this.dataField3);
            this.Controls.Add(this.panelHeading2);
            this.Controls.Add(this.dataField2);
            this.Controls.Add(this.dataDropDown2);
            this.Controls.Add(this.panelHeading1);
            this.Controls.Add(this.dataDropDown1);
            this.Controls.Add(this.dataField1);
            this.Name = "ONCPanel";
            ((System.ComponentModel.ISupportInitialize)(this.serviceModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private View.DataField dataField1;
        internal System.Windows.Forms.BindingSource serviceModelBindingSource;
        private DataDropDown dataDropDown1;
        private PanelHeading panelHeading1;
        private DataDropDown dataDropDown2;
        private View.DataField dataField2;
        private PanelHeading panelHeading2;
        private View.DataField dataField3;
        private View.DataField dataField4;
        private PanelHeading panelHeading3;
        private View.DataField dataField5;
        private View.DataField dataField6;
    }
}
