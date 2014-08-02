namespace CallTracker.View
{
    partial class LabelledComboBox
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
            this._ComboBox = new CallTracker.View.BorderedCombobox();
            ((System.ComponentModel.ISupportInitialize)(this._MenuButton)).BeginInit();
            this.SuspendLayout();
            // 
            // _MenuButton
            // 
            this._MenuButton.Size = new System.Drawing.Size(7, 10);
            this._MenuButton.Visible = false;
            // 
            // _ComboBox
            // 
            this._ComboBox.BorderColor = System.Drawing.Color.WhiteSmoke;
            this._ComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._ComboBox.FormattingEnabled = true;
            this._ComboBox.Location = new System.Drawing.Point(0, 10);
            this._ComboBox.MaxDropDownItems = 15;
            this._ComboBox.Name = "_ComboBox";
            this._ComboBox.Size = new System.Drawing.Size(180, 20);
            this._ComboBox.TabIndex = 31;
            this._ComboBox.SelectedIndexChanged += new System.EventHandler(this._ComboBox_SelectedIndexChanged);
            this._ComboBox.DataSourceChanged += new System.EventHandler(this._ComboBox_DataSourceChanged);
            // 
            // LabelledComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._ComboBox);
            this.Name = "LabelledComboBox";
            this.Load += new System.EventHandler(this.LabelledComboBox_Load);
            this.Controls.SetChildIndex(this._ComboBox, 0);
            this.Controls.SetChildIndex(this._Label, 0);
            this.Controls.SetChildIndex(this._MenuButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this._MenuButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal BorderedCombobox _ComboBox;



    }
}
