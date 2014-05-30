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
            this.dataArea1 = new CallTracker.View.DataArea();
            this.serviceModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataField1 = new CallTracker.Source.View.Controls.Product_Panels.DataField();
            this.dataDropDown1 = new CallTracker.View.DataDropDown();
            this.panelHeading1 = new CallTracker.View.PanelHeading();
            ((System.ComponentModel.ISupportInitialize)(this.serviceModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataArea1
            // 
            this.dataArea1.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.serviceModelBindingSource, "NitResults", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataArea1.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataArea1.LabelText = "NIT:";
            this.dataArea1.LabelWidth = 35;
            this.dataArea1.Location = new System.Drawing.Point(0, 67);
            this.dataArea1.Margin = new System.Windows.Forms.Padding(0);
            this.dataArea1.Name = "dataArea1";
            this.dataArea1.Padding = new System.Windows.Forms.Padding(3);
            this.dataArea1.Size = new System.Drawing.Size(180, 63);
            this.dataArea1.TabIndex = 44;
            this.dataArea1.TextField = "";
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
            this.dataDropDown1.DataBindings.Add(new System.Windows.Forms.Binding("DataText", this.serviceModelBindingSource, "CauPing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataDropDown1.DataSelectedItem = "";
            this.dataDropDown1.DataSelectedValue = "";
            this.dataDropDown1.DataText = "";
            this.dataDropDown1.Font = new System.Drawing.Font("Verdana", 7F);
            this.dataDropDown1.LabelText = "CAU:";
            this.dataDropDown1.LabelWidth = 36;
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
            this.panelHeading1.LabelText = "//LAT";
            this.panelHeading1.Location = new System.Drawing.Point(0, 0);
            this.panelHeading1.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeading1.Name = "panelHeading1";
            this.panelHeading1.Padding = new System.Windows.Forms.Padding(2);
            this.panelHeading1.Size = new System.Drawing.Size(180, 17);
            this.panelHeading1.TabIndex = 46;
            // 
            // LATPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.panelHeading1);
            this.Controls.Add(this.dataDropDown1);
            this.Controls.Add(this.dataArea1);
            this.Controls.Add(this.dataField1);
            this.Name = "LATPanel";
            ((System.ComponentModel.ISupportInitialize)(this.serviceModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Source.View.Controls.Product_Panels.DataField dataField1;
        internal System.Windows.Forms.BindingSource serviceModelBindingSource;
        private DataArea dataArea1;
        private DataDropDown dataDropDown1;
        private PanelHeading panelHeading1;
    }
}
