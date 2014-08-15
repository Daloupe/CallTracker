namespace CallTracker.View
{
    partial class LabelledDatePicker
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
            this._DateTimePicker = new CallTracker.View.BorderedDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this._MenuButton)).BeginInit();
            this.SuspendLayout();
            // 
            // _MenuButton
            // 
            this._MenuButton.Size = new System.Drawing.Size(16, 13);
            // 
            // _DateTimePicker
            // 
            this._DateTimePicker.BorderColor = System.Drawing.Color.SlateGray;
            this._DateTimePicker.CalendarTitleBackColor = System.Drawing.Color.SlateGray;
            this._DateTimePicker.CustomFormat = "dd/MM";
            this._DateTimePicker.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._DateTimePicker.Location = new System.Drawing.Point(0, 13);
            this._DateTimePicker.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this._DateTimePicker.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this._DateTimePicker.Name = "_DateTimePicker";
            this._DateTimePicker.Size = new System.Drawing.Size(180, 19);
            this._DateTimePicker.TabIndex = 31;
            // 
            // LabelledDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._DateTimePicker);
            this.Name = "LabelledDatePicker";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Controls.SetChildIndex(this._DateTimePicker, 0);
            this.Controls.SetChildIndex(this._MenuButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this._MenuButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal BorderedDateTimePicker _DateTimePicker;




    }
}
