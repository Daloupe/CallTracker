namespace CallTracker.View
{
    partial class BindSmartPasteForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this._System = new System.Windows.Forms.TextBox();
            this.pasteBindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._TitleLabel = new System.Windows.Forms.Label();
            this._Title = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Element = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Url = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Data = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._AltData = new System.Windows.Forms.ComboBox();
            this._Ok = new System.Windows.Forms.Button();
            this._Cancel = new System.Windows.Forms.Button();
            this.customerContactBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pasteBindBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerContactBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this._System);
            this.flowLayoutPanel1.Controls.Add(this._TitleLabel);
            this.flowLayoutPanel1.Controls.Add(this._Title);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this._Element);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this._Url);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this._Data);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this._AltData);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(239, 186);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "System:";
            // 
            // _System
            // 
            this._System.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "System", true));
            this._System.Location = new System.Drawing.Point(64, 6);
            this._System.Name = "_System";
            this._System.Size = new System.Drawing.Size(161, 19);
            this._System.TabIndex = 9;
            // 
            // pasteBindBindingSource
            // 
            this.pasteBindBindingSource.DataSource = typeof(CallTracker.Model.PasteBind);
            // 
            // _TitleLabel
            // 
            this._TitleLabel.Location = new System.Drawing.Point(3, 31);
            this._TitleLabel.Margin = new System.Windows.Forms.Padding(3);
            this._TitleLabel.Name = "_TitleLabel";
            this._TitleLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._TitleLabel.Size = new System.Drawing.Size(55, 19);
            this._TitleLabel.TabIndex = 0;
            this._TitleLabel.Text = "Title:";
            // 
            // _Title
            // 
            this._Title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Title", true));
            this._Title.Dock = System.Windows.Forms.DockStyle.Right;
            this._Title.Location = new System.Drawing.Point(64, 31);
            this._Title.Name = "_Title";
            this._Title.Size = new System.Drawing.Size(161, 19);
            this._Title.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Element:";
            // 
            // _Element
            // 
            this._Element.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Element", true));
            this._Element.Dock = System.Windows.Forms.DockStyle.Right;
            this._Element.Location = new System.Drawing.Point(64, 56);
            this._Element.Name = "_Element";
            this._Element.Size = new System.Drawing.Size(161, 19);
            this._Element.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(55, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // _Url
            // 
            this._Url.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pasteBindBindingSource, "Url", true));
            this._Url.Dock = System.Windows.Forms.DockStyle.Right;
            this._Url.Location = new System.Drawing.Point(64, 81);
            this._Url.Multiline = true;
            this._Url.Name = "_Url";
            this._Url.Size = new System.Drawing.Size(161, 44);
            this._Url.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data:";
            // 
            // _Data
            // 
            this._Data.FormattingEnabled = true;
            this._Data.Location = new System.Drawing.Point(64, 131);
            this._Data.Name = "_Data";
            this._Data.Size = new System.Drawing.Size(162, 20);
            this._Data.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 157);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label5.Size = new System.Drawing.Size(55, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Alt Data:";
            // 
            // _AltData
            // 
            this._AltData.FormattingEnabled = true;
            this._AltData.Location = new System.Drawing.Point(64, 157);
            this._AltData.Name = "_AltData";
            this._AltData.Size = new System.Drawing.Size(162, 20);
            this._AltData.TabIndex = 11;
            // 
            // _Ok
            // 
            this._Ok.Location = new System.Drawing.Point(64, 204);
            this._Ok.Name = "_Ok";
            this._Ok.Size = new System.Drawing.Size(75, 21);
            this._Ok.TabIndex = 0;
            this._Ok.Text = "Ok";
            this._Ok.UseVisualStyleBackColor = true;
            this._Ok.Click += new System.EventHandler(this._Ok_Click);
            // 
            // _Cancel
            // 
            this._Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._Cancel.Location = new System.Drawing.Point(150, 204);
            this._Cancel.Name = "_Cancel";
            this._Cancel.Size = new System.Drawing.Size(75, 21);
            this._Cancel.TabIndex = 1;
            this._Cancel.Text = "Cancel";
            this._Cancel.UseVisualStyleBackColor = true;
            this._Cancel.Click += new System.EventHandler(this._Cancel_Click);
            // 
            // BindSmartPasteForm
            // 
            this.AcceptButton = this._Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._Cancel;
            this.ClientSize = new System.Drawing.Size(239, 237);
            this.Controls.Add(this._Cancel);
            this.Controls.Add(this._Ok);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BindSmartPasteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bind Smart Paste";
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pasteBindBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerContactBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label _TitleLabel;
        private System.Windows.Forms.TextBox _Title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _Element;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Url;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _Data;
        private System.Windows.Forms.Button _Ok;
        private System.Windows.Forms.Button _Cancel;
        private System.Windows.Forms.BindingSource customerContactBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _System;
        private System.Windows.Forms.BindingSource pasteBindBindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _AltData;
    }
}