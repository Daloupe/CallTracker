namespace CallTracker.View
{
    partial class Note
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
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._label_situation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Situation = new CallTracker.View.dbRTBox();
            this.customerContactBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._Action = new CallTracker.View.dbRTBox();
            this._Outcome = new CallTracker.View.dbRTBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerContactBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CadetBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 5F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(202, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(7, 216);
            this.button1.TabIndex = 0;
            this.button1.Text = "Hello";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resizeHandle_MouseDown);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.resizeHandle_MouseMove);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resizeHandle_MouseUp);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this._label_situation);
            this.flowLayoutPanel1.Controls.Add(this._Situation);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this._Action);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this._Outcome);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(203, 216);
            this.flowLayoutPanel1.TabIndex = 50;
            // 
            // _label_situation
            // 
            this._label_situation.Font = new System.Drawing.Font("Verdana", 7F);
            this._label_situation.ForeColor = System.Drawing.Color.DarkSlateGray;
            this._label_situation.Location = new System.Drawing.Point(3, 0);
            this._label_situation.Name = "_label_situation";
            this._label_situation.Size = new System.Drawing.Size(180, 12);
            this._label_situation.TabIndex = 10;
            this._label_situation.Text = "Situation:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 7F);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "Action:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 7F);
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(3, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "Outcome:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 218);
            this.panel1.TabIndex = 2;
            // 
            // _Situation
            // 
            this._Situation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Situation.DataBindings.Add(new System.Windows.Forms.Binding("Rtf", this.customerContactBindingSource, "SituationNote", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Situation.Location = new System.Drawing.Point(3, 12);
            this._Situation.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this._Situation.Name = "_Situation";
            this._Situation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this._Situation.Size = new System.Drawing.Size(197, 44);
            this._Situation.TabIndex = 0;
            this._Situation.Text = "";
            this._Situation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Note_MouseClick);
            this._Situation.Enter += new System.EventHandler(this.Note_Enter);
            this._Situation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Note_KeyDown);
            this._Situation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Note_KeyPress);
            this._Situation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Note_KeyUp);
            this._Situation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Note_MouseDown);
            this._Situation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Note_MouseOver);
            this._Situation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Note_MouseUp);
            this._Situation.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Note_PreviewKeyDown);
            // 
            // customerContactBindingSource
            // 
            this.customerContactBindingSource.DataSource = typeof(CallTracker.Model.CustomerContact);
            // 
            // _Action
            // 
            this._Action.AutoWordSelection = true;
            this._Action.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Action.DataBindings.Add(new System.Windows.Forms.Binding("Rtf", this.customerContactBindingSource, "ActionNote", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Action.Location = new System.Drawing.Point(3, 68);
            this._Action.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this._Action.Name = "_Action";
            this._Action.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this._Action.Size = new System.Drawing.Size(197, 101);
            this._Action.TabIndex = 1;
            this._Action.Text = "";
            this._Action.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Note_MouseClick);
            this._Action.Enter += new System.EventHandler(this.Note_Enter);
            this._Action.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Note_KeyDown);
            this._Action.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Note_KeyPress);
            this._Action.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Note_KeyUp);
            this._Action.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Note_MouseDown);
            this._Action.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Note_MouseOver);
            this._Action.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Note_MouseUp);
            this._Action.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Note_PreviewKeyDown);
            // 
            // _Outcome
            // 
            this._Outcome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Outcome.DataBindings.Add(new System.Windows.Forms.Binding("Rtf", this.customerContactBindingSource, "OutcomeNote", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Outcome.Location = new System.Drawing.Point(3, 181);
            this._Outcome.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this._Outcome.Name = "_Outcome";
            this._Outcome.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this._Outcome.Size = new System.Drawing.Size(197, 32);
            this._Outcome.TabIndex = 2;
            this._Outcome.Text = "";
            this._Outcome.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Note_MouseClick);
            this._Outcome.Enter += new System.EventHandler(this.Note_Enter);
            this._Outcome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Note_KeyDown);
            this._Outcome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Note_KeyPress);
            this._Outcome.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Note_KeyUp);
            this._Outcome.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Note_MouseDown);
            this._Outcome.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Note_MouseOver);
            this._Outcome.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Note_MouseUp);
            this._Outcome.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Note_PreviewKeyDown);
            // 
            // Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(211, 218);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Note";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Note";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerContactBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label _label_situation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CallTracker.View.dbRTBox _Situation;
        private dbRTBox _Action;
        private dbRTBox _Outcome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource customerContactBindingSource;
    }
}