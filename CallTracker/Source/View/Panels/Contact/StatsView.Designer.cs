namespace CallTracker.View
{
    partial class StatsView
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this._Cancel = new System.Windows.Forms.Button();
            this._DateSelect = new CallTracker.View.LabelledComboBoxLong();
            this._StatsPanel = new System.Windows.Forms.Panel();
            this._HandlingTimeA = new CallTracker.View.LabelledTextBoxLong();
            this._ReadyA = new CallTracker.View.LabelledTextBoxLong();
            this._NotReadyA = new CallTracker.View.LabelledTextBoxLong();
            this._WrapUpA = new CallTracker.View.LabelledTextBoxLong();
            this._TalkTimeA = new CallTracker.View.LabelledTextBoxLong();
            this.labelledHeading2 = new CallTracker.View.LabelledHeading();
            this.labelledHeading1 = new CallTracker.View.LabelledHeading();
            this._HandlingTime = new CallTracker.View.LabelledTextBoxLong();
            this._Ready = new CallTracker.View.LabelledTextBoxLong();
            this._NotReady = new CallTracker.View.LabelledTextBoxLong();
            this._WrapUp = new CallTracker.View.LabelledTextBoxLong();
            this._Calls = new CallTracker.View.LabelledTextBoxLong();
            this._TalkTime = new CallTracker.View.LabelledTextBoxLong();
            this._Login = new CallTracker.View.LabelledTextBoxLong();
            this._Hold = new CallTracker.View.LabelledTextBoxLong();
            this._HoldA = new CallTracker.View.LabelledTextBoxLong();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this._StatsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(CallTracker.Model.DailyModel);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(441, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "//Stats";
            // 
            // _Cancel
            // 
            this._Cancel.BackColor = System.Drawing.Color.LightGray;
            this._Cancel.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this._Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cancel.Location = new System.Drawing.Point(522, 218);
            this._Cancel.Name = "_Cancel";
            this._Cancel.Size = new System.Drawing.Size(60, 20);
            this._Cancel.TabIndex = 15;
            this._Cancel.Text = "Done";
            this._Cancel.UseVisualStyleBackColor = false;
            this._Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // _DateSelect
            // 
            this._DateSelect.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._DateSelect.BackColor = System.Drawing.Color.LightGray;
            this._DateSelect.BorderColour = System.Drawing.Color.WhiteSmoke;
            this._DateSelect.ControlHeight = 20;
            this._DateSelect.DataSource = null;
            this._DateSelect.DefaultText = "";
            this._DateSelect.Font = new System.Drawing.Font("Verdana", 7F);
            this._DateSelect.HasContextMenu = false;
            this._DateSelect.LabelActiveColor = System.Drawing.Color.Empty;
            this._DateSelect.LabelAutoSize = true;
            this._DateSelect.LabelBorderColor = System.Drawing.Color.Empty;
            this._DateSelect.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._DateSelect.LabelInactiveColor = System.Drawing.Color.Empty;
            this._DateSelect.LabelMargin = new System.Windows.Forms.Padding(0);
            this._DateSelect.LabelOffset = new System.Drawing.Point(0, 0);
            this._DateSelect.LabelPadding = new System.Windows.Forms.Padding(0);
            this._DateSelect.LabelSize = new System.Drawing.Size(55, 23);
            this._DateSelect.LabelText = "date filter";
            this._DateSelect.LabelTextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._DateSelect.LabelTextColor = System.Drawing.SystemColors.ControlText;
            this._DateSelect.LabelToolTip = "";
            this._DateSelect.Location = new System.Drawing.Point(2, 218);
            this._DateSelect.MenuButtonDock = System.Windows.Forms.DockStyle.Left;
            this._DateSelect.MenuButtonImage = null;
            this._DateSelect.Name = "_DateSelect";
            this._DateSelect.OverlapLabel = false;
            this._DateSelect.PropertyName = "LongDate";
            this._DateSelect.Size = new System.Drawing.Size(130, 20);
            this._DateSelect.TabIndex = 17;
            // 
            // _StatsPanel
            // 
            this._StatsPanel.BackColor = System.Drawing.Color.LightGray;
            this._StatsPanel.Controls.Add(this._HoldA);
            this._StatsPanel.Controls.Add(this._Hold);
            this._StatsPanel.Controls.Add(this._HandlingTimeA);
            this._StatsPanel.Controls.Add(this._ReadyA);
            this._StatsPanel.Controls.Add(this._NotReadyA);
            this._StatsPanel.Controls.Add(this._WrapUpA);
            this._StatsPanel.Controls.Add(this._TalkTimeA);
            this._StatsPanel.Controls.Add(this.labelledHeading2);
            this._StatsPanel.Controls.Add(this.labelledHeading1);
            this._StatsPanel.Controls.Add(this._HandlingTime);
            this._StatsPanel.Controls.Add(this._Ready);
            this._StatsPanel.Controls.Add(this._NotReady);
            this._StatsPanel.Controls.Add(this._WrapUp);
            this._StatsPanel.Controls.Add(this._Calls);
            this._StatsPanel.Controls.Add(this._TalkTime);
            this._StatsPanel.Controls.Add(this._Login);
            this._StatsPanel.Location = new System.Drawing.Point(2, 4);
            this._StatsPanel.Name = "_StatsPanel";
            this._StatsPanel.Size = new System.Drawing.Size(580, 213);
            this._StatsPanel.TabIndex = 18;
            // 
            // _HandlingTimeA
            // 
            this._HandlingTimeA.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._HandlingTimeA.BackColor = System.Drawing.Color.DarkSlateGray;
            this._HandlingTimeA.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._HandlingTimeA.ControlHeight = 20;
            this._HandlingTimeA.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._HandlingTimeA.DefaultText = "";
            this._HandlingTimeA.Font = new System.Drawing.Font("Verdana", 7F);
            this._HandlingTimeA.HasContextMenu = false;
            this._HandlingTimeA.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._HandlingTimeA.LabelAutoSize = false;
            this._HandlingTimeA.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._HandlingTimeA.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._HandlingTimeA.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._HandlingTimeA.LabelMargin = new System.Windows.Forms.Padding(0);
            this._HandlingTimeA.LabelOffset = new System.Drawing.Point(0, 0);
            this._HandlingTimeA.LabelPadding = new System.Windows.Forms.Padding(0);
            this._HandlingTimeA.LabelSize = new System.Drawing.Size(70, 20);
            this._HandlingTimeA.LabelText = "aht";
            this._HandlingTimeA.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._HandlingTimeA.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._HandlingTimeA.LabelToolTip = "";
            this._HandlingTimeA.Location = new System.Drawing.Point(145, 186);
            this._HandlingTimeA.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._HandlingTimeA.MenuButtonImage = null;
            this._HandlingTimeA.Name = "_HandlingTimeA";
            this._HandlingTimeA.PropertyName = null;
            this._HandlingTimeA.Size = new System.Drawing.Size(127, 20);
            this._HandlingTimeA.TabIndex = 13;
            this._HandlingTimeA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._HandlingTimeA.TextField = "";
            // 
            // _ReadyA
            // 
            this._ReadyA.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._ReadyA.BackColor = System.Drawing.Color.DarkSlateGray;
            this._ReadyA.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._ReadyA.ControlHeight = 20;
            this._ReadyA.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._ReadyA.DefaultText = "";
            this._ReadyA.Font = new System.Drawing.Font("Verdana", 7F);
            this._ReadyA.HasContextMenu = false;
            this._ReadyA.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._ReadyA.LabelAutoSize = false;
            this._ReadyA.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._ReadyA.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._ReadyA.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._ReadyA.LabelMargin = new System.Windows.Forms.Padding(0);
            this._ReadyA.LabelOffset = new System.Drawing.Point(0, 0);
            this._ReadyA.LabelPadding = new System.Windows.Forms.Padding(0);
            this._ReadyA.LabelSize = new System.Drawing.Size(70, 20);
            this._ReadyA.LabelText = "wait time";
            this._ReadyA.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._ReadyA.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._ReadyA.LabelToolTip = "";
            this._ReadyA.Location = new System.Drawing.Point(145, 90);
            this._ReadyA.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._ReadyA.MenuButtonImage = null;
            this._ReadyA.Name = "_ReadyA";
            this._ReadyA.PropertyName = null;
            this._ReadyA.Size = new System.Drawing.Size(127, 20);
            this._ReadyA.TabIndex = 12;
            this._ReadyA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._ReadyA.TextField = "";
            // 
            // _NotReadyA
            // 
            this._NotReadyA.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._NotReadyA.BackColor = System.Drawing.Color.DarkSlateGray;
            this._NotReadyA.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._NotReadyA.ControlHeight = 20;
            this._NotReadyA.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._NotReadyA.DefaultText = "";
            this._NotReadyA.Font = new System.Drawing.Font("Verdana", 7F);
            this._NotReadyA.HasContextMenu = false;
            this._NotReadyA.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._NotReadyA.LabelAutoSize = false;
            this._NotReadyA.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._NotReadyA.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._NotReadyA.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._NotReadyA.LabelMargin = new System.Windows.Forms.Padding(0);
            this._NotReadyA.LabelOffset = new System.Drawing.Point(0, 0);
            this._NotReadyA.LabelPadding = new System.Windows.Forms.Padding(0);
            this._NotReadyA.LabelSize = new System.Drawing.Size(70, 20);
            this._NotReadyA.LabelText = "not ready";
            this._NotReadyA.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._NotReadyA.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._NotReadyA.LabelToolTip = "";
            this._NotReadyA.Location = new System.Drawing.Point(145, 66);
            this._NotReadyA.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._NotReadyA.MenuButtonImage = null;
            this._NotReadyA.Name = "_NotReadyA";
            this._NotReadyA.PropertyName = null;
            this._NotReadyA.Size = new System.Drawing.Size(127, 20);
            this._NotReadyA.TabIndex = 11;
            this._NotReadyA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._NotReadyA.TextField = "";
            // 
            // _WrapUpA
            // 
            this._WrapUpA.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._WrapUpA.BackColor = System.Drawing.Color.DarkSlateGray;
            this._WrapUpA.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._WrapUpA.ControlHeight = 20;
            this._WrapUpA.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._WrapUpA.DefaultText = "";
            this._WrapUpA.Font = new System.Drawing.Font("Verdana", 7F);
            this._WrapUpA.HasContextMenu = false;
            this._WrapUpA.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._WrapUpA.LabelAutoSize = false;
            this._WrapUpA.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._WrapUpA.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._WrapUpA.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._WrapUpA.LabelMargin = new System.Windows.Forms.Padding(0);
            this._WrapUpA.LabelOffset = new System.Drawing.Point(0, 0);
            this._WrapUpA.LabelPadding = new System.Windows.Forms.Padding(0);
            this._WrapUpA.LabelSize = new System.Drawing.Size(70, 20);
            this._WrapUpA.LabelText = "wrap up";
            this._WrapUpA.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._WrapUpA.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._WrapUpA.LabelToolTip = "";
            this._WrapUpA.Location = new System.Drawing.Point(145, 138);
            this._WrapUpA.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._WrapUpA.MenuButtonImage = null;
            this._WrapUpA.Name = "_WrapUpA";
            this._WrapUpA.PropertyName = null;
            this._WrapUpA.Size = new System.Drawing.Size(127, 20);
            this._WrapUpA.TabIndex = 10;
            this._WrapUpA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._WrapUpA.TextField = "";
            // 
            // _TalkTimeA
            // 
            this._TalkTimeA.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._TalkTimeA.BackColor = System.Drawing.Color.DarkSlateGray;
            this._TalkTimeA.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._TalkTimeA.ControlHeight = 20;
            this._TalkTimeA.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._TalkTimeA.DefaultText = "";
            this._TalkTimeA.Font = new System.Drawing.Font("Verdana", 7F);
            this._TalkTimeA.HasContextMenu = false;
            this._TalkTimeA.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._TalkTimeA.LabelAutoSize = false;
            this._TalkTimeA.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._TalkTimeA.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._TalkTimeA.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._TalkTimeA.LabelMargin = new System.Windows.Forms.Padding(0);
            this._TalkTimeA.LabelOffset = new System.Drawing.Point(0, 0);
            this._TalkTimeA.LabelPadding = new System.Windows.Forms.Padding(0);
            this._TalkTimeA.LabelSize = new System.Drawing.Size(70, 20);
            this._TalkTimeA.LabelText = "talk time";
            this._TalkTimeA.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._TalkTimeA.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._TalkTimeA.LabelToolTip = "";
            this._TalkTimeA.Location = new System.Drawing.Point(145, 114);
            this._TalkTimeA.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._TalkTimeA.MenuButtonImage = null;
            this._TalkTimeA.Name = "_TalkTimeA";
            this._TalkTimeA.PropertyName = null;
            this._TalkTimeA.Size = new System.Drawing.Size(127, 20);
            this._TalkTimeA.TabIndex = 9;
            this._TalkTimeA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._TalkTimeA.TextField = "";
            // 
            // labelledHeading2
            // 
            this.labelledHeading2.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledHeading2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.labelledHeading2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelledHeading2.ControlHeight = 10;
            this.labelledHeading2.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledHeading2.HasContextMenu = false;
            this.labelledHeading2.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this.labelledHeading2.LabelAutoSize = true;
            this.labelledHeading2.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this.labelledHeading2.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this.labelledHeading2.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this.labelledHeading2.LabelMargin = new System.Windows.Forms.Padding(0);
            this.labelledHeading2.LabelOffset = new System.Drawing.Point(2, -3);
            this.labelledHeading2.LabelPadding = new System.Windows.Forms.Padding(0);
            this.labelledHeading2.LabelSize = new System.Drawing.Size(98, 22);
            this.labelledHeading2.LabelText = "PER CALL AVERAGE";
            this.labelledHeading2.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelledHeading2.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledHeading2.LabelToolTip = "";
            this.labelledHeading2.Location = new System.Drawing.Point(145, 5);
            this.labelledHeading2.Margin = new System.Windows.Forms.Padding(0);
            this.labelledHeading2.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this.labelledHeading2.MenuButtonImage = null;
            this.labelledHeading2.Name = "labelledHeading2";
            this.labelledHeading2.PropertyName = null;
            this.labelledHeading2.Size = new System.Drawing.Size(127, 10);
            this.labelledHeading2.TabIndex = 8;
            // 
            // labelledHeading1
            // 
            this.labelledHeading1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledHeading1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.labelledHeading1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelledHeading1.ControlHeight = 10;
            this.labelledHeading1.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledHeading1.HasContextMenu = false;
            this.labelledHeading1.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this.labelledHeading1.LabelAutoSize = true;
            this.labelledHeading1.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this.labelledHeading1.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this.labelledHeading1.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this.labelledHeading1.LabelMargin = new System.Windows.Forms.Padding(0);
            this.labelledHeading1.LabelOffset = new System.Drawing.Point(2, -3);
            this.labelledHeading1.LabelPadding = new System.Windows.Forms.Padding(0);
            this.labelledHeading1.LabelSize = new System.Drawing.Size(45, 22);
            this.labelledHeading1.LabelText = "TOTALS";
            this.labelledHeading1.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelledHeading1.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledHeading1.LabelToolTip = "";
            this.labelledHeading1.Location = new System.Drawing.Point(3, 5);
            this.labelledHeading1.Margin = new System.Windows.Forms.Padding(0);
            this.labelledHeading1.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this.labelledHeading1.MenuButtonImage = null;
            this.labelledHeading1.Name = "labelledHeading1";
            this.labelledHeading1.PropertyName = null;
            this.labelledHeading1.Size = new System.Drawing.Size(127, 10);
            this.labelledHeading1.TabIndex = 7;
            // 
            // _HandlingTime
            // 
            this._HandlingTime.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._HandlingTime.BackColor = System.Drawing.Color.DarkSlateGray;
            this._HandlingTime.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._HandlingTime.ControlHeight = 20;
            this._HandlingTime.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._HandlingTime.DefaultText = "";
            this._HandlingTime.Font = new System.Drawing.Font("Verdana", 7F);
            this._HandlingTime.HasContextMenu = false;
            this._HandlingTime.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._HandlingTime.LabelAutoSize = false;
            this._HandlingTime.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._HandlingTime.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._HandlingTime.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._HandlingTime.LabelMargin = new System.Windows.Forms.Padding(0);
            this._HandlingTime.LabelOffset = new System.Drawing.Point(0, 0);
            this._HandlingTime.LabelPadding = new System.Windows.Forms.Padding(0);
            this._HandlingTime.LabelSize = new System.Drawing.Size(70, 20);
            this._HandlingTime.LabelText = "handling time";
            this._HandlingTime.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._HandlingTime.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._HandlingTime.LabelToolTip = "";
            this._HandlingTime.Location = new System.Drawing.Point(3, 186);
            this._HandlingTime.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._HandlingTime.MenuButtonImage = null;
            this._HandlingTime.Name = "_HandlingTime";
            this._HandlingTime.PropertyName = null;
            this._HandlingTime.Size = new System.Drawing.Size(127, 20);
            this._HandlingTime.TabIndex = 6;
            this._HandlingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._HandlingTime.TextField = "";
            // 
            // _Ready
            // 
            this._Ready.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Ready.BackColor = System.Drawing.Color.DarkSlateGray;
            this._Ready.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._Ready.ControlHeight = 20;
            this._Ready.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Ready.DefaultText = "";
            this._Ready.Font = new System.Drawing.Font("Verdana", 7F);
            this._Ready.HasContextMenu = false;
            this._Ready.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._Ready.LabelAutoSize = false;
            this._Ready.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._Ready.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Ready.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._Ready.LabelMargin = new System.Windows.Forms.Padding(0);
            this._Ready.LabelOffset = new System.Drawing.Point(0, 0);
            this._Ready.LabelPadding = new System.Windows.Forms.Padding(0);
            this._Ready.LabelSize = new System.Drawing.Size(70, 20);
            this._Ready.LabelText = "ready";
            this._Ready.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Ready.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Ready.LabelToolTip = "";
            this._Ready.Location = new System.Drawing.Point(3, 90);
            this._Ready.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._Ready.MenuButtonImage = null;
            this._Ready.Name = "_Ready";
            this._Ready.PropertyName = null;
            this._Ready.Size = new System.Drawing.Size(127, 20);
            this._Ready.TabIndex = 5;
            this._Ready.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._Ready.TextField = "";
            // 
            // _NotReady
            // 
            this._NotReady.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._NotReady.BackColor = System.Drawing.Color.DarkSlateGray;
            this._NotReady.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._NotReady.ControlHeight = 20;
            this._NotReady.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._NotReady.DefaultText = "";
            this._NotReady.Font = new System.Drawing.Font("Verdana", 7F);
            this._NotReady.HasContextMenu = false;
            this._NotReady.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._NotReady.LabelAutoSize = false;
            this._NotReady.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._NotReady.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._NotReady.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._NotReady.LabelMargin = new System.Windows.Forms.Padding(0);
            this._NotReady.LabelOffset = new System.Drawing.Point(0, 0);
            this._NotReady.LabelPadding = new System.Windows.Forms.Padding(0);
            this._NotReady.LabelSize = new System.Drawing.Size(70, 20);
            this._NotReady.LabelText = "not ready";
            this._NotReady.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._NotReady.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._NotReady.LabelToolTip = "";
            this._NotReady.Location = new System.Drawing.Point(3, 66);
            this._NotReady.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._NotReady.MenuButtonImage = null;
            this._NotReady.Name = "_NotReady";
            this._NotReady.PropertyName = null;
            this._NotReady.Size = new System.Drawing.Size(127, 20);
            this._NotReady.TabIndex = 4;
            this._NotReady.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._NotReady.TextField = "";
            // 
            // _WrapUp
            // 
            this._WrapUp.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._WrapUp.BackColor = System.Drawing.Color.DarkSlateGray;
            this._WrapUp.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._WrapUp.ControlHeight = 20;
            this._WrapUp.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._WrapUp.DefaultText = "";
            this._WrapUp.Font = new System.Drawing.Font("Verdana", 7F);
            this._WrapUp.HasContextMenu = false;
            this._WrapUp.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._WrapUp.LabelAutoSize = false;
            this._WrapUp.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._WrapUp.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._WrapUp.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._WrapUp.LabelMargin = new System.Windows.Forms.Padding(0);
            this._WrapUp.LabelOffset = new System.Drawing.Point(0, 0);
            this._WrapUp.LabelPadding = new System.Windows.Forms.Padding(0);
            this._WrapUp.LabelSize = new System.Drawing.Size(70, 20);
            this._WrapUp.LabelText = "wrap up";
            this._WrapUp.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._WrapUp.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._WrapUp.LabelToolTip = "";
            this._WrapUp.Location = new System.Drawing.Point(3, 138);
            this._WrapUp.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._WrapUp.MenuButtonImage = null;
            this._WrapUp.Name = "_WrapUp";
            this._WrapUp.PropertyName = null;
            this._WrapUp.Size = new System.Drawing.Size(127, 20);
            this._WrapUp.TabIndex = 3;
            this._WrapUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._WrapUp.TextField = "";
            // 
            // _Calls
            // 
            this._Calls.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Calls.BackColor = System.Drawing.Color.DarkSlateGray;
            this._Calls.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._Calls.ControlHeight = 20;
            this._Calls.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Calls.DefaultText = "";
            this._Calls.Font = new System.Drawing.Font("Verdana", 7F);
            this._Calls.HasContextMenu = false;
            this._Calls.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._Calls.LabelAutoSize = false;
            this._Calls.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._Calls.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Calls.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._Calls.LabelMargin = new System.Windows.Forms.Padding(0);
            this._Calls.LabelOffset = new System.Drawing.Point(0, 0);
            this._Calls.LabelPadding = new System.Windows.Forms.Padding(0);
            this._Calls.LabelSize = new System.Drawing.Size(70, 20);
            this._Calls.LabelText = "calls";
            this._Calls.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Calls.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Calls.LabelToolTip = "";
            this._Calls.Location = new System.Drawing.Point(3, 42);
            this._Calls.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._Calls.MenuButtonImage = null;
            this._Calls.Name = "_Calls";
            this._Calls.PropertyName = null;
            this._Calls.Size = new System.Drawing.Size(127, 20);
            this._Calls.TabIndex = 2;
            this._Calls.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._Calls.TextField = "";
            // 
            // _TalkTime
            // 
            this._TalkTime.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._TalkTime.BackColor = System.Drawing.Color.DarkSlateGray;
            this._TalkTime.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._TalkTime.ControlHeight = 20;
            this._TalkTime.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._TalkTime.DefaultText = "";
            this._TalkTime.Font = new System.Drawing.Font("Verdana", 7F);
            this._TalkTime.HasContextMenu = false;
            this._TalkTime.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._TalkTime.LabelAutoSize = false;
            this._TalkTime.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._TalkTime.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._TalkTime.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._TalkTime.LabelMargin = new System.Windows.Forms.Padding(0);
            this._TalkTime.LabelOffset = new System.Drawing.Point(0, 0);
            this._TalkTime.LabelPadding = new System.Windows.Forms.Padding(0);
            this._TalkTime.LabelSize = new System.Drawing.Size(70, 20);
            this._TalkTime.LabelText = "talk time";
            this._TalkTime.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._TalkTime.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._TalkTime.LabelToolTip = "";
            this._TalkTime.Location = new System.Drawing.Point(3, 114);
            this._TalkTime.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._TalkTime.MenuButtonImage = null;
            this._TalkTime.Name = "_TalkTime";
            this._TalkTime.PropertyName = null;
            this._TalkTime.Size = new System.Drawing.Size(127, 20);
            this._TalkTime.TabIndex = 1;
            this._TalkTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._TalkTime.TextField = "";
            // 
            // _Login
            // 
            this._Login.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Login.BackColor = System.Drawing.Color.DarkSlateGray;
            this._Login.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._Login.ControlHeight = 20;
            this._Login.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Login.DefaultText = "";
            this._Login.Font = new System.Drawing.Font("Verdana", 7F);
            this._Login.HasContextMenu = false;
            this._Login.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._Login.LabelAutoSize = false;
            this._Login.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._Login.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Login.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._Login.LabelMargin = new System.Windows.Forms.Padding(0);
            this._Login.LabelOffset = new System.Drawing.Point(0, 0);
            this._Login.LabelPadding = new System.Windows.Forms.Padding(0);
            this._Login.LabelSize = new System.Drawing.Size(70, 20);
            this._Login.LabelText = "login";
            this._Login.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Login.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Login.LabelToolTip = "";
            this._Login.Location = new System.Drawing.Point(3, 18);
            this._Login.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._Login.MenuButtonImage = null;
            this._Login.Name = "_Login";
            this._Login.PropertyName = null;
            this._Login.Size = new System.Drawing.Size(127, 20);
            this._Login.TabIndex = 0;
            this._Login.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._Login.TextField = "";
            // 
            // _Hold
            // 
            this._Hold.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Hold.BackColor = System.Drawing.Color.DarkSlateGray;
            this._Hold.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._Hold.ControlHeight = 20;
            this._Hold.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Hold.DefaultText = "";
            this._Hold.Font = new System.Drawing.Font("Verdana", 7F);
            this._Hold.HasContextMenu = false;
            this._Hold.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._Hold.LabelAutoSize = false;
            this._Hold.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._Hold.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Hold.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._Hold.LabelMargin = new System.Windows.Forms.Padding(0);
            this._Hold.LabelOffset = new System.Drawing.Point(0, 0);
            this._Hold.LabelPadding = new System.Windows.Forms.Padding(0);
            this._Hold.LabelSize = new System.Drawing.Size(70, 20);
            this._Hold.LabelText = "hold";
            this._Hold.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Hold.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Hold.LabelToolTip = "";
            this._Hold.Location = new System.Drawing.Point(3, 162);
            this._Hold.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._Hold.MenuButtonImage = null;
            this._Hold.Name = "_Hold";
            this._Hold.PropertyName = null;
            this._Hold.Size = new System.Drawing.Size(127, 20);
            this._Hold.TabIndex = 14;
            this._Hold.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._Hold.TextField = "";
            // 
            // _HoldA
            // 
            this._HoldA.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._HoldA.BackColor = System.Drawing.Color.DarkSlateGray;
            this._HoldA.BorderColour = System.Drawing.Color.DarkSlateGray;
            this._HoldA.ControlHeight = 20;
            this._HoldA.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Events", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._HoldA.DefaultText = "";
            this._HoldA.Font = new System.Drawing.Font("Verdana", 7F);
            this._HoldA.HasContextMenu = false;
            this._HoldA.LabelActiveColor = System.Drawing.Color.DarkSlateGray;
            this._HoldA.LabelAutoSize = false;
            this._HoldA.LabelBorderColor = System.Drawing.Color.DarkSlateGray;
            this._HoldA.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._HoldA.LabelInactiveColor = System.Drawing.Color.DarkSlateGray;
            this._HoldA.LabelMargin = new System.Windows.Forms.Padding(0);
            this._HoldA.LabelOffset = new System.Drawing.Point(0, 0);
            this._HoldA.LabelPadding = new System.Windows.Forms.Padding(0);
            this._HoldA.LabelSize = new System.Drawing.Size(70, 20);
            this._HoldA.LabelText = "hold";
            this._HoldA.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._HoldA.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._HoldA.LabelToolTip = "";
            this._HoldA.Location = new System.Drawing.Point(145, 162);
            this._HoldA.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._HoldA.MenuButtonImage = null;
            this._HoldA.Name = "_HoldA";
            this._HoldA.PropertyName = null;
            this._HoldA.Size = new System.Drawing.Size(127, 20);
            this._HoldA.TabIndex = 15;
            this._HoldA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._HoldA.TextField = "";
            // 
            // StatsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this._StatsPanel);
            this.Controls.Add(this._DateSelect);
            this.Controls.Add(this._Cancel);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Name = "StatsView";
            this.Padding = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.Size = new System.Drawing.Size(584, 241);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this._StatsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button _Cancel;
        internal LabelledComboBoxLong _DateSelect;
        internal System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel _StatsPanel;
        private LabelledTextBoxLong _Login;
        private LabelledTextBoxLong _TalkTime;
        private LabelledTextBoxLong _HandlingTime;
        private LabelledTextBoxLong _Ready;
        private LabelledTextBoxLong _NotReady;
        private LabelledTextBoxLong _WrapUp;
        private LabelledTextBoxLong _Calls;
        private LabelledTextBoxLong _HandlingTimeA;
        private LabelledTextBoxLong _ReadyA;
        private LabelledTextBoxLong _NotReadyA;
        private LabelledTextBoxLong _WrapUpA;
        private LabelledTextBoxLong _TalkTimeA;
        private LabelledHeading labelledHeading2;
        private LabelledHeading labelledHeading1;
        private LabelledTextBoxLong _HoldA;
        private LabelledTextBoxLong _Hold;
    }
}
