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
            this.dataField1 = new CallTracker.Source.View.Controls.Product_Panels.DataField();
            this.panelHeading1 = new CallTracker.View.PanelHeading();
            this.dataField2 = new CallTracker.Source.View.Controls.Product_Panels.DataField();
            this.panelHeading2 = new CallTracker.View.PanelHeading();
            this.dataField3 = new CallTracker.Source.View.Controls.Product_Panels.DataField();
            this.dataField4 = new CallTracker.Source.View.Controls.Product_Panels.DataField();
            this.dataDropDown1 = new CallTracker.View.DataDropDown();
            this.dataField5 = new CallTracker.Source.View.Controls.Product_Panels.DataField();
            ((System.ComponentModel.ISupportInitialize)(this.serviceModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // serviceModelBindingSource
            // 
            this.serviceModelBindingSource.DataSource = typeof(CallTracker.Model.ServiceModel);
            // 
            // dataField1
            // 
            this.dataField1.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "Node", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField1.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField1.LabelText = "Node:";
            this.dataField1.LabelWidth = 84;
            this.dataField1.Location = new System.Drawing.Point(0, 17);
            this.dataField1.Margin = new System.Windows.Forms.Padding(0);
            this.dataField1.Name = "dataField1";
            this.dataField1.Padding = new System.Windows.Forms.Padding(3);
            this.dataField1.Size = new System.Drawing.Size(180, 25);
            this.dataField1.TabIndex = 37;
            this.dataField1.TextField = "";
            // 
            // panelHeading1
            // 
            this.panelHeading1.Font = new System.Drawing.Font("Verdana", 7F);
            this.panelHeading1.LabelText = "//DTV";
            this.panelHeading1.Location = new System.Drawing.Point(0, 0);
            this.panelHeading1.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeading1.Name = "panelHeading1";
            this.panelHeading1.Padding = new System.Windows.Forms.Padding(2);
            this.panelHeading1.Size = new System.Drawing.Size(180, 17);
            this.panelHeading1.TabIndex = 46;
            // 
            // dataField2
            // 
            this.dataField2.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "DTVSmartCard", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField2.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField2.LabelText = "Smart Card:";
            this.dataField2.LabelWidth = 68;
            this.dataField2.Location = new System.Drawing.Point(0, 109);
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
            this.panelHeading2.LabelText = "//STB";
            this.panelHeading2.Location = new System.Drawing.Point(0, 92);
            this.panelHeading2.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeading2.Name = "panelHeading2";
            this.panelHeading2.Padding = new System.Windows.Forms.Padding(2);
            this.panelHeading2.Size = new System.Drawing.Size(180, 17);
            this.panelHeading2.TabIndex = 49;
            // 
            // dataField3
            // 
            this.dataField3.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "DTVLot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField3.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField3.LabelText = "Lot:";
            this.dataField3.LabelWidth = 26;
            this.dataField3.Location = new System.Drawing.Point(0, 134);
            this.dataField3.Margin = new System.Windows.Forms.Padding(0);
            this.dataField3.Name = "dataField3";
            this.dataField3.Padding = new System.Windows.Forms.Padding(3);
            this.dataField3.Size = new System.Drawing.Size(70, 25);
            this.dataField3.TabIndex = 50;
            this.dataField3.TextField = "";
            // 
            // dataField4
            // 
            this.dataField4.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "DTVBox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField4.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField4.LabelText = "Box:";
            this.dataField4.LabelWidth = 28;
            this.dataField4.Location = new System.Drawing.Point(70, 134);
            this.dataField4.Margin = new System.Windows.Forms.Padding(0);
            this.dataField4.Name = "dataField4";
            this.dataField4.Padding = new System.Windows.Forms.Padding(3);
            this.dataField4.Size = new System.Drawing.Size(110, 25);
            this.dataField4.TabIndex = 51;
            this.dataField4.TextField = "";
            // 
            // dataDropDown1
            // 
            this.dataDropDown1.DataBindings.Add(new System.Windows.Forms.Binding("DataText", this.serviceModelBindingSource, "ConnectionType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataDropDown1.DataSelectedItem = "";
            this.dataDropDown1.DataSelectedValue = "";
            this.dataDropDown1.DataText = "";
            this.dataDropDown1.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataDropDown1.LabelText = "Connection:";
            this.dataDropDown1.LabelWidth = 85;
            this.dataDropDown1.Location = new System.Drawing.Point(0, 67);
            this.dataDropDown1.Margin = new System.Windows.Forms.Padding(0);
            this.dataDropDown1.Name = "dataDropDown1";
            this.dataDropDown1.Padding = new System.Windows.Forms.Padding(3);
            this.dataDropDown1.Size = new System.Drawing.Size(179, 25);
            this.dataDropDown1.TabIndex = 52;
            // 
            // dataField5
            // 
            this.dataField5.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "DTVMsg", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField5.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField5.LabelText = "MSG:";
            this.dataField5.LabelWidth = 84;
            this.dataField5.Location = new System.Drawing.Point(0, 42);
            this.dataField5.Margin = new System.Windows.Forms.Padding(0);
            this.dataField5.Name = "dataField5";
            this.dataField5.Padding = new System.Windows.Forms.Padding(3);
            this.dataField5.Size = new System.Drawing.Size(180, 25);
            this.dataField5.TabIndex = 53;
            this.dataField5.TextField = "";
            // 
            // DTVPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.dataField5);
            this.Controls.Add(this.dataDropDown1);
            this.Controls.Add(this.dataField4);
            this.Controls.Add(this.dataField3);
            this.Controls.Add(this.panelHeading2);
            this.Controls.Add(this.dataField2);
            this.Controls.Add(this.panelHeading1);
            this.Controls.Add(this.dataField1);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Name = "DTVPanel";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(180, 245);
            ((System.ComponentModel.ISupportInitialize)(this.serviceModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Source.View.Controls.Product_Panels.DataField dataField1;
        internal System.Windows.Forms.BindingSource serviceModelBindingSource;
        private PanelHeading panelHeading1;
        private Source.View.Controls.Product_Panels.DataField dataField2;
        private PanelHeading panelHeading2;
        private Source.View.Controls.Product_Panels.DataField dataField3;
        private Source.View.Controls.Product_Panels.DataField dataField4;
        private DataDropDown dataDropDown1;
        private Source.View.Controls.Product_Panels.DataField dataField5;
    }
}
