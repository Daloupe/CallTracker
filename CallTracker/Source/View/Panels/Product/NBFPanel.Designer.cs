namespace CallTracker.View
{
    partial class NBFPanel
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
            this.dataField6 = new CallTracker.Source.View.Controls.Product_Panels.DataField();
            this.serviceModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataField5 = new CallTracker.Source.View.Controls.Product_Panels.DataField();
            this.dataField4 = new CallTracker.Source.View.Controls.Product_Panels.DataField();
            this.dataField3 = new CallTracker.Source.View.Controls.Product_Panels.DataField();
            this.dataField2 = new CallTracker.Source.View.Controls.Product_Panels.DataField();
            this.dataField1 = new CallTracker.Source.View.Controls.Product_Panels.DataField();
            this.dataField7 = new CallTracker.Source.View.Controls.Product_Panels.DataField();
            this.panelHeading1 = new CallTracker.View.PanelHeading();
            ((System.ComponentModel.ISupportInitialize)(this.serviceModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataField6
            // 
            this.dataField6.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "Bras", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField6.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField6.LabelText = "Bras:";
            this.dataField6.LabelWidth = 34;
            this.dataField6.Location = new System.Drawing.Point(0, 39);
            this.dataField6.Margin = new System.Windows.Forms.Padding(0);
            this.dataField6.Name = "dataField6";
            this.dataField6.Padding = new System.Windows.Forms.Padding(3);
            this.dataField6.Size = new System.Drawing.Size(90, 23);
            this.dataField6.TabIndex = 42;
            this.dataField6.TextField = "";
            // 
            // serviceModelBindingSource
            // 
            this.serviceModelBindingSource.DataSource = typeof(CallTracker.Model.ServiceModel);
            // 
            // dataField5
            // 
            this.dataField5.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "AVC", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField5.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField5.LabelText = "INC:";
            this.dataField5.LabelWidth = 34;
            this.dataField5.Location = new System.Drawing.Point(0, 137);
            this.dataField5.Margin = new System.Windows.Forms.Padding(0);
            this.dataField5.Name = "dataField5";
            this.dataField5.Padding = new System.Windows.Forms.Padding(3);
            this.dataField5.Size = new System.Drawing.Size(180, 25);
            this.dataField5.TabIndex = 41;
            this.dataField5.TextField = "";
            // 
            // dataField4
            // 
            this.dataField4.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "NNI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField4.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField4.LabelText = "NNI:";
            this.dataField4.LabelWidth = 34;
            this.dataField4.Location = new System.Drawing.Point(0, 112);
            this.dataField4.Margin = new System.Windows.Forms.Padding(0);
            this.dataField4.Name = "dataField4";
            this.dataField4.Padding = new System.Windows.Forms.Padding(3);
            this.dataField4.Size = new System.Drawing.Size(180, 25);
            this.dataField4.TabIndex = 40;
            this.dataField4.TextField = "";
            // 
            // dataField3
            // 
            this.dataField3.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "CVC", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField3.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField3.LabelText = "CVC:";
            this.dataField3.LabelWidth = 34;
            this.dataField3.Location = new System.Drawing.Point(0, 87);
            this.dataField3.Margin = new System.Windows.Forms.Padding(0);
            this.dataField3.Name = "dataField3";
            this.dataField3.Padding = new System.Windows.Forms.Padding(3);
            this.dataField3.Size = new System.Drawing.Size(180, 25);
            this.dataField3.TabIndex = 39;
            this.dataField3.TextField = "";
            // 
            // dataField2
            // 
            this.dataField2.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "CSA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField2.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField2.LabelText = "CSA:";
            this.dataField2.LabelWidth = 34;
            this.dataField2.Location = new System.Drawing.Point(0, 62);
            this.dataField2.Margin = new System.Windows.Forms.Padding(0);
            this.dataField2.Name = "dataField2";
            this.dataField2.Padding = new System.Windows.Forms.Padding(3);
            this.dataField2.Size = new System.Drawing.Size(180, 25);
            this.dataField2.TabIndex = 38;
            this.dataField2.TextField = "";
            // 
            // dataField1
            // 
            this.dataField1.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "AVC", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField1.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField1.LabelText = "AVC:";
            this.dataField1.LabelWidth = 34;
            this.dataField1.Location = new System.Drawing.Point(0, 16);
            this.dataField1.Margin = new System.Windows.Forms.Padding(0);
            this.dataField1.Name = "dataField1";
            this.dataField1.Padding = new System.Windows.Forms.Padding(3);
            this.dataField1.Size = new System.Drawing.Size(180, 23);
            this.dataField1.TabIndex = 37;
            this.dataField1.TextField = "";
            // 
            // dataField7
            // 
            this.dataField7.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "Bras", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataField7.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataField7.LabelText = "SIP:";
            this.dataField7.LabelWidth = 34;
            this.dataField7.Location = new System.Drawing.Point(90, 39);
            this.dataField7.Margin = new System.Windows.Forms.Padding(0);
            this.dataField7.Name = "dataField7";
            this.dataField7.Padding = new System.Windows.Forms.Padding(3);
            this.dataField7.Size = new System.Drawing.Size(90, 23);
            this.dataField7.TabIndex = 43;
            this.dataField7.TextField = "";
            // 
            // panelHeading1
            // 
            this.panelHeading1.Font = new System.Drawing.Font("Verdana", 7F);
            this.panelHeading1.LabelText = "//NBN";
            this.panelHeading1.Location = new System.Drawing.Point(0, 0);
            this.panelHeading1.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeading1.Name = "panelHeading1";
            this.panelHeading1.Padding = new System.Windows.Forms.Padding(2);
            this.panelHeading1.Size = new System.Drawing.Size(180, 17);
            this.panelHeading1.TabIndex = 47;
            // 
            // NBFPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.panelHeading1);
            this.Controls.Add(this.dataField7);
            this.Controls.Add(this.dataField6);
            this.Controls.Add(this.dataField5);
            this.Controls.Add(this.dataField4);
            this.Controls.Add(this.dataField3);
            this.Controls.Add(this.dataField2);
            this.Controls.Add(this.dataField1);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Name = "NBFPanel";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(180, 245);
            ((System.ComponentModel.ISupportInitialize)(this.serviceModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Source.View.Controls.Product_Panels.DataField dataField1;
        private Source.View.Controls.Product_Panels.DataField dataField2;
        private Source.View.Controls.Product_Panels.DataField dataField3;
        private Source.View.Controls.Product_Panels.DataField dataField4;
        private Source.View.Controls.Product_Panels.DataField dataField5;
        private Source.View.Controls.Product_Panels.DataField dataField6;
        internal System.Windows.Forms.BindingSource serviceModelBindingSource;
        private Source.View.Controls.Product_Panels.DataField dataField7;
        private PanelHeading panelHeading1;
    }
}
