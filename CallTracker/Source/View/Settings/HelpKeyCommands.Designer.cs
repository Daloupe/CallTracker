namespace CallTracker.View
{
    partial class HelpKeyCommands : SettingsViewBase
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
            this.label6 = new System.Windows.Forms.Label();
            this._Done = new System.Windows.Forms.Button();
            this.pasteBindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pasteBindBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(3, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "//Key Command Help";
            // 
            // _Done
            // 
            this._Done.BackColor = System.Drawing.Color.LightGray;
            this._Done.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this._Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Done.Location = new System.Drawing.Point(506, 197);
            this._Done.Name = "_Done";
            this._Done.Size = new System.Drawing.Size(75, 22);
            this._Done.TabIndex = 10;
            this._Done.Text = "Done";
            this._Done.UseVisualStyleBackColor = false;
            this._Done.Click += new System.EventHandler(this._Done_Click);
            // 
            // pasteBindBindingSource
            // 
            this.pasteBindBindingSource.DataSource = typeof(CallTracker.Model.PasteBind);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 185);
            this.panel1.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(227, 130);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label13.Size = new System.Drawing.Size(161, 49);
            this.label13.TabIndex = 19;
            this.label13.Text = "- Teaches program which data field to bind to the active element.";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(208, 102);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label14.Size = new System.Drawing.Size(109, 29);
            this.label14.TabIndex = 18;
            this.label14.Text = "Smart Paste Bind: Win + Shift +  B";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(413, 130);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label12.Size = new System.Drawing.Size(149, 49);
            this.label12.TabIndex = 17;
            this.label12.Text = "- Smart Pastes all known elements on a page, not just the active element.";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(28, 130);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label11.Size = new System.Drawing.Size(161, 49);
            this.label11.TabIndex = 16;
            this.label11.Text = "- Looks at active element and pastes appropriate data field.";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(28, 38);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label10.Size = new System.Drawing.Size(169, 31);
            this.label10.TabIndex = 15;
            this.label10.Text = "- Analyses selected text and copies into appropriate data field.";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(413, 37);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label9.Size = new System.Drawing.Size(159, 31);
            this.label9.TabIndex = 14;
            this.label9.Text = "- Enters your log in details if you\'re on a login screen.";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(227, 37);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label8.Size = new System.Drawing.Size(175, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "- Jumps straight to a system.";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(227, 57);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label5.Size = new System.Drawing.Size(169, 32);
            this.label5.TabIndex = 12;
            this.label5.Text = "- Automatically logs in if it detects a log in page.";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(208, 9);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(100, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "GridLinks:       Win + NumPad";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(398, 9);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(72, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "AutoLogin: Win + ~";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(398, 102);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(109, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "AutoFill:              Win + Control + V";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 102);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(85, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Smart Paste: Win + V";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(9, 9);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label7.Size = new System.Drawing.Size(75, 29);
            this.label7.TabIndex = 7;
            this.label7.Text = "Smart Copy: Win + C";
            // 
            // HelpKeyCommands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._Done);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Name = "HelpKeyCommands";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(584, 222);
            ((System.ComponentModel.ISupportInitialize)(this.pasteBindBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _Done;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.BindingSource pasteBindBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}
