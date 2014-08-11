namespace CallTracker.View
{
    partial class EditContact
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
            CallTracker.DataSets.ServicesDataSet servicesDataSet;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditContact));
            this.FaultPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.HfcPanel = new System.Windows.Forms.Panel();
            this._BookingDate = new CallTracker.View.LabelledDatePicker();
            this.customerContactsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._BookingType = new CallTracker.View.LabelledComboBox();
            this._BookingTimeSlot = new CallTracker.View.LabelledComboBox();
            this._Itcase = new CallTracker.View.LabelledTextBox();
            this._Equipment = new CallTracker.View.LabelledComboBoxLong();
            this._Outcome = new CallTracker.View.LabelledComboBox();
            this._Symptom = new CallTracker.View.LabelledComboBox();
            this._NPR = new CallTracker.View.LabelledTextBox();
            this._PR = new CallTracker.View.LabelledTextBox();
            this._ServiceMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._ServiceMenuLAT = new System.Windows.Forms.ToolStripMenuItem();
            this._ServiceMenuLIP = new System.Windows.Forms.ToolStripMenuItem();
            this._ServiceMenuONC = new System.Windows.Forms.ToolStripMenuItem();
            this._ServiceMenuDTV = new System.Windows.Forms.ToolStripMenuItem();
            this._ServiceMenuMTV = new System.Windows.Forms.ToolStripMenuItem();
            this._ServiceMenuNFV = new System.Windows.Forms.ToolStripMenuItem();
            this._ServiceMenuNBF = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelledTextField2 = new CallTracker.View.LabelledTextField();
            this.labelledTextField1 = new CallTracker.View.LabelledTextField();
            this._PRContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewPRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dispatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAndCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stapleToParentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._SeverityMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._NewCallMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this._CallHistoryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.callHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._Icon = new CallTracker.View.LabelledTextBoxLong();
            this._Cmbs = new CallTracker.View.LabelledTextBoxLong();
            this._Username = new CallTracker.View.LabelledTextBoxLong();
            this._Dn = new CallTracker.View.LabelledTextBoxLong();
            this._Name = new CallTracker.View.LabelledTextBoxLong();
            this._Mobile = new CallTracker.View.LabelledTextBoxLong();
            this._Address = new CallTracker.View.LabelledTextBoxLong();
            this._DialContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServiceTypePanel = new System.Windows.Forms.FlowLayoutPanel();
            this._LAT = new System.Windows.Forms.CheckBox();
            this._LIP = new System.Windows.Forms.CheckBox();
            this._ONC = new System.Windows.Forms.CheckBox();
            this._DTV = new System.Windows.Forms.CheckBox();
            this._MTV = new System.Windows.Forms.CheckBox();
            this._NFV = new System.Windows.Forms.CheckBox();
            this._NBF = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this._notePanel = new System.Windows.Forms.Panel();
            this._Note = new System.Windows.Forms.RichTextBox();
            this._NoteContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.noteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateICONNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pRTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingNavigator1 = new CallTracker.View.BindingNavigatorIgnoreFocus();
            this._NewCallButton = new System.Windows.Forms.ToolStripButton();
            this._PrevCallButton = new System.Windows.Forms.ToolStripButton();
            this._CurrentPosition = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._NextCallButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this._WorkReadyTimerDisplay = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._OutcomeTooltip = new System.Windows.Forms.ToolTip(this.components);
            this._WorkReadyTimer = new System.Windows.Forms.Timer(this.components);
            servicesDataSet = new CallTracker.DataSets.ServicesDataSet();
            ((System.ComponentModel.ISupportInitialize)(servicesDataSet)).BeginInit();
            this.FaultPanel.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.HfcPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerContactsBindingSource)).BeginInit();
            this._ServiceMenu.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this._PRContextMenu.SuspendLayout();
            this._SeverityMenuStrip.SuspendLayout();
            this._NewCallMenuStrip.SuspendLayout();
            this._CallHistoryContextMenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this._DialContextMenu.SuspendLayout();
            this.ServiceTypePanel.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this._notePanel.SuspendLayout();
            this._NoteContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // servicesDataSet
            // 
            servicesDataSet.DataSetName = "ServicesDataSet";
            servicesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FaultPanel
            // 
            this.FaultPanel.Controls.Add(this.splitContainer1);
            this.FaultPanel.Location = new System.Drawing.Point(389, 0);
            this.FaultPanel.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.FaultPanel.Name = "FaultPanel";
            this.FaultPanel.Size = new System.Drawing.Size(191, 216);
            this.FaultPanel.TabIndex = 28;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.DarkGray;
            this.splitContainer1.Location = new System.Drawing.Point(1, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(1, 3, 1, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(1);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(275, 216);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 24;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            this.splitContainer1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_MouseDoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.DarkGray;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(1, 3, 2, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer2.Panel1.Controls.Add(this.HfcPanel);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Panel1MinSize = 0;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.MintCream;
            this.splitContainer2.Panel2.ContextMenuStrip = this._ServiceMenu;
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(1);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitContainer2_MouseWheel);
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(180, 216);
            this.splitContainer2.SplitterDistance = 67;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            this.splitContainer2.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrayBorder);
            this.splitContainer2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.splitContainer2_MouseDoubleClick);
            // 
            // HfcPanel
            // 
            this.HfcPanel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.HfcPanel.Controls.Add(this._BookingDate);
            this.HfcPanel.Controls.Add(this._BookingType);
            this.HfcPanel.Controls.Add(this._BookingTimeSlot);
            this.HfcPanel.Controls.Add(this._Itcase);
            this.HfcPanel.Controls.Add(this._Equipment);
            this.HfcPanel.Controls.Add(this._Outcome);
            this.HfcPanel.Controls.Add(this._Symptom);
            this.HfcPanel.Controls.Add(this._NPR);
            this.HfcPanel.Controls.Add(this._PR);
            this.HfcPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HfcPanel.Location = new System.Drawing.Point(0, -92);
            this.HfcPanel.Margin = new System.Windows.Forms.Padding(0);
            this.HfcPanel.Name = "HfcPanel";
            this.HfcPanel.Size = new System.Drawing.Size(180, 159);
            this.HfcPanel.TabIndex = 22;
            // 
            // _BookingDate
            // 
            this._BookingDate.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._BookingDate.BackColor = System.Drawing.Color.DarkGoldenrod;
            this._BookingDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._BookingDate.BorderColour = System.Drawing.Color.DarkGoldenrod;
            this._BookingDate.ControlHeight = 29;
            this._BookingDate.DataBindings.Add(new System.Windows.Forms.Binding("DateField", this.customerContactsBindingSource, "Booking.Date", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._BookingDate.DateField = new System.DateTime(2014, 8, 9, 5, 40, 35, 872);
            this._BookingDate.Font = new System.Drawing.Font("Verdana", 7F);
            this._BookingDate.LabelActiveColor = System.Drawing.Color.Empty;
            this._BookingDate.LabelAutoSize = true;
            this._BookingDate.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this._BookingDate.LabelInactiveColor = System.Drawing.Color.Empty;
            this._BookingDate.LabelOffset = new System.Drawing.Point(2, -3);
            this._BookingDate.LabelSize = new System.Drawing.Size(53, 22);
            this._BookingDate.LabelText = "BOOKING";
            this._BookingDate.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BookingDate.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._BookingDate.Location = new System.Drawing.Point(67, 63);
            this._BookingDate.Margin = new System.Windows.Forms.Padding(0);
            this._BookingDate.Name = "_BookingDate";
            this._BookingDate.PropertyName = null;
            this._BookingDate.Size = new System.Drawing.Size(56, 29);
            this._BookingDate.TabIndex = 61;
            // 
            // customerContactsBindingSource
            // 
            this.customerContactsBindingSource.AllowNew = true;
            this.customerContactsBindingSource.DataSource = typeof(CallTracker.Model.CustomerContact);
            // 
            // _BookingType
            // 
            this._BookingType.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._BookingType.BackColor = System.Drawing.Color.DarkGoldenrod;
            this._BookingType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._BookingType.BorderColour = System.Drawing.Color.DarkGoldenrod;
            this._BookingType.ControlHeight = 29;
            this._BookingType.DataSource = null;
            this._BookingType.DefaultText = "";
            this._BookingType.Font = new System.Drawing.Font("Verdana", 7F);
            this._BookingType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._BookingType.LabelActiveColor = System.Drawing.Color.Empty;
            this._BookingType.LabelAutoSize = true;
            this._BookingType.LabelFont = new System.Drawing.Font("Gautami", 7F, System.Drawing.FontStyle.Underline);
            this._BookingType.LabelInactiveColor = System.Drawing.Color.Empty;
            this._BookingType.LabelOffset = new System.Drawing.Point(2, -3);
            this._BookingType.LabelSize = new System.Drawing.Size(34, 22);
            this._BookingType.LabelText = "TYPE";
            this._BookingType.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BookingType.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._BookingType.Location = new System.Drawing.Point(4, 63);
            this._BookingType.Margin = new System.Windows.Forms.Padding(0);
            this._BookingType.Name = "_BookingType";
            this._BookingType.PropertyName = "Booking.Type";
            this._BookingType.Size = new System.Drawing.Size(59, 29);
            this._BookingType.TabIndex = 60;
            // 
            // _BookingTimeSlot
            // 
            this._BookingTimeSlot.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._BookingTimeSlot.BackColor = System.Drawing.Color.DarkGoldenrod;
            this._BookingTimeSlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._BookingTimeSlot.BorderColour = System.Drawing.Color.DarkGoldenrod;
            this._BookingTimeSlot.ControlHeight = 29;
            this._BookingTimeSlot.DataSource = null;
            this._BookingTimeSlot.DefaultText = "";
            this._BookingTimeSlot.Font = new System.Drawing.Font("Verdana", 7F);
            this._BookingTimeSlot.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._BookingTimeSlot.LabelActiveColor = System.Drawing.Color.Empty;
            this._BookingTimeSlot.LabelAutoSize = true;
            this._BookingTimeSlot.LabelFont = new System.Drawing.Font("Gautami", 7F, System.Drawing.FontStyle.Underline);
            this._BookingTimeSlot.LabelInactiveColor = System.Drawing.Color.Empty;
            this._BookingTimeSlot.LabelOffset = new System.Drawing.Point(2, -3);
            this._BookingTimeSlot.LabelSize = new System.Drawing.Size(58, 22);
            this._BookingTimeSlot.LabelText = "TIMESLOT";
            this._BookingTimeSlot.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._BookingTimeSlot.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._BookingTimeSlot.Location = new System.Drawing.Point(127, 63);
            this._BookingTimeSlot.Margin = new System.Windows.Forms.Padding(0);
            this._BookingTimeSlot.Name = "_BookingTimeSlot";
            this._BookingTimeSlot.PropertyName = "Booking.TimeSlot";
            this._BookingTimeSlot.Size = new System.Drawing.Size(48, 29);
            this._BookingTimeSlot.TabIndex = 59;
            // 
            // _Itcase
            // 
            this._Itcase.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Itcase.BackColor = System.Drawing.Color.DarkGoldenrod;
            this._Itcase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._Itcase.BorderColour = System.Drawing.Color.DarkGoldenrod;
            this._Itcase.ControlHeight = 28;
            this._Itcase.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.customerContactsBindingSource, "Fault.PR", true));
            this._Itcase.DefaultText = "";
            this._Itcase.Font = new System.Drawing.Font("Verdana", 7F);
            this._Itcase.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._Itcase.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._Itcase.LabelAutoSize = true;
            this._Itcase.LabelFont = new System.Drawing.Font("Gautami", 7F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Itcase.LabelInactiveColor = System.Drawing.Color.DarkGoldenrod;
            this._Itcase.LabelOffset = new System.Drawing.Point(2, -3);
            this._Itcase.LabelSize = new System.Drawing.Size(46, 22);
            this._Itcase.LabelText = "IT CASE";
            this._Itcase.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Itcase.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Itcase.Location = new System.Drawing.Point(4, 8);
            this._Itcase.Margin = new System.Windows.Forms.Padding(0);
            this._Itcase.Name = "_Itcase";
            this._Itcase.PropertyName = "PR";
            this._Itcase.Size = new System.Drawing.Size(171, 28);
            this._Itcase.TabIndex = 57;
            this._Itcase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Itcase.TextField = "";
            // 
            // _Equipment
            // 
            this._Equipment.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Equipment.BackColor = System.Drawing.Color.DarkGoldenrod;
            this._Equipment.BorderColour = System.Drawing.Color.DarkGoldenrod;
            this._Equipment.ControlHeight = 20;
            this._Equipment.DataSource = null;
            this._Equipment.DefaultText = "";
            this._Equipment.Font = new System.Drawing.Font("Verdana", 7F);
            this._Equipment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._Equipment.LabelActiveColor = System.Drawing.Color.Empty;
            this._Equipment.LabelAutoSize = false;
            this._Equipment.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this._Equipment.LabelInactiveColor = System.Drawing.Color.Empty;
            this._Equipment.LabelOffset = new System.Drawing.Point(2, 0);
            this._Equipment.LabelSize = new System.Drawing.Size(54, 20);
            this._Equipment.LabelText = "EQUIPMENT";
            this._Equipment.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Equipment.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Equipment.Location = new System.Drawing.Point(4, 40);
            this._Equipment.Name = "_Equipment";
            this._Equipment.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this._Equipment.PropertyName = "Service.Equipment";
            this._Equipment.Size = new System.Drawing.Size(171, 20);
            this._Equipment.TabIndex = 56;
            // 
            // _Outcome
            // 
            this._Outcome.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Outcome.BackColor = System.Drawing.Color.DarkGoldenrod;
            this._Outcome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._Outcome.BorderColour = System.Drawing.Color.DarkGoldenrod;
            this._Outcome.ControlHeight = 29;
            this._Outcome.DataSource = null;
            this._Outcome.DefaultText = "";
            this._Outcome.Font = new System.Drawing.Font("Verdana", 7F);
            this._Outcome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Outcome.LabelActiveColor = System.Drawing.Color.Empty;
            this._Outcome.LabelAutoSize = true;
            this._Outcome.LabelFont = new System.Drawing.Font("Gautami", 7F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Outcome.LabelInactiveColor = System.Drawing.Color.Empty;
            this._Outcome.LabelOffset = new System.Drawing.Point(2, -3);
            this._Outcome.LabelSize = new System.Drawing.Size(59, 22);
            this._Outcome.LabelText = "OUTCOME";
            this._Outcome.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Outcome.LabelTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._Outcome.Location = new System.Drawing.Point(67, 95);
            this._Outcome.Margin = new System.Windows.Forms.Padding(0);
            this._Outcome.Name = "_Outcome";
            this._Outcome.PropertyName = "Fault.Outcome";
            this._Outcome.Size = new System.Drawing.Size(108, 29);
            this._Outcome.TabIndex = 54;
            this._Outcome.SelectedIndexChanged += new System.EventHandler(this._Outcome_SelectedIndexChanged);
            // 
            // _Symptom
            // 
            this._Symptom.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Symptom.BackColor = System.Drawing.Color.DarkGoldenrod;
            this._Symptom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._Symptom.BorderColour = System.Drawing.Color.DarkGoldenrod;
            this._Symptom.ControlHeight = 29;
            this._Symptom.DataSource = null;
            this._Symptom.DefaultText = "";
            this._Symptom.Font = new System.Drawing.Font("Verdana", 7F);
            this._Symptom.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Symptom.LabelActiveColor = System.Drawing.Color.Empty;
            this._Symptom.LabelAutoSize = true;
            this._Symptom.LabelFont = new System.Drawing.Font("Gautami", 7F, System.Drawing.FontStyle.Underline);
            this._Symptom.LabelInactiveColor = System.Drawing.Color.Empty;
            this._Symptom.LabelOffset = new System.Drawing.Point(2, -3);
            this._Symptom.LabelSize = new System.Drawing.Size(59, 22);
            this._Symptom.LabelText = "SYMPTOM";
            this._Symptom.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Symptom.LabelTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._Symptom.Location = new System.Drawing.Point(4, 95);
            this._Symptom.Margin = new System.Windows.Forms.Padding(0);
            this._Symptom.Name = "_Symptom";
            this._Symptom.PropertyName = "Fault.Symptom";
            this._Symptom.Size = new System.Drawing.Size(59, 29);
            this._Symptom.TabIndex = 53;
            this._Symptom.SelectedIndexChanged += new System.EventHandler(this._Symptom_SelectedIndexChanged);
            // 
            // _NPR
            // 
            this._NPR.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._NPR.BackColor = System.Drawing.Color.DarkGoldenrod;
            this._NPR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._NPR.BorderColour = System.Drawing.Color.DarkGoldenrod;
            this._NPR.ControlHeight = 28;
            this._NPR.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.customerContactsBindingSource, "Fault.NPR", true));
            this._NPR.DefaultText = "";
            this._NPR.Font = new System.Drawing.Font("Verdana", 7F);
            this._NPR.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._NPR.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._NPR.LabelAutoSize = true;
            this._NPR.LabelFont = new System.Drawing.Font("Gautami", 7F, System.Drawing.FontStyle.Underline);
            this._NPR.LabelInactiveColor = System.Drawing.Color.DarkGoldenrod;
            this._NPR.LabelOffset = new System.Drawing.Point(2, -3);
            this._NPR.LabelSize = new System.Drawing.Size(74, 22);
            this._NPR.LabelText = "NETWORK PR";
            this._NPR.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._NPR.LabelTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._NPR.Location = new System.Drawing.Point(93, 127);
            this._NPR.Margin = new System.Windows.Forms.Padding(0);
            this._NPR.Name = "_NPR";
            this._NPR.PropertyName = "NPR";
            this._NPR.Size = new System.Drawing.Size(82, 28);
            this._NPR.TabIndex = 52;
            this._NPR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._NPR.TextField = "";
            // 
            // _PR
            // 
            this._PR.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._PR.BackColor = System.Drawing.Color.DarkGoldenrod;
            this._PR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._PR.BorderColour = System.Drawing.Color.DarkGoldenrod;
            this._PR.ControlHeight = 28;
            this._PR.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.customerContactsBindingSource, "Fault.PR", true));
            this._PR.DefaultText = "";
            this._PR.Font = new System.Drawing.Font("Verdana", 7F);
            this._PR.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._PR.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._PR.LabelAutoSize = true;
            this._PR.LabelFont = new System.Drawing.Font("Gautami", 7F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._PR.LabelInactiveColor = System.Drawing.Color.DarkGoldenrod;
            this._PR.LabelOffset = new System.Drawing.Point(2, -3);
            this._PR.LabelSize = new System.Drawing.Size(81, 22);
            this._PR.LabelText = "CUSTOMER PR";
            this._PR.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._PR.LabelTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._PR.Location = new System.Drawing.Point(4, 127);
            this._PR.Margin = new System.Windows.Forms.Padding(0);
            this._PR.Name = "_PR";
            this._PR.PropertyName = "PR";
            this._PR.Size = new System.Drawing.Size(85, 28);
            this._PR.TabIndex = 51;
            this._PR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._PR.TextField = "";
            this.toolTip1.SetToolTip(this._PR, "Shift-Ctrl-Z");
            // 
            // _ServiceMenu
            // 
            this._ServiceMenu.Font = new System.Drawing.Font("Verdana", 7F);
            this._ServiceMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ServiceMenuLAT,
            this._ServiceMenuLIP,
            this._ServiceMenuONC,
            this._ServiceMenuDTV,
            this._ServiceMenuMTV,
            this._ServiceMenuNFV,
            this._ServiceMenuNBF});
            this._ServiceMenu.Name = "contextMenuStrip1";
            this._ServiceMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this._ServiceMenu.Size = new System.Drawing.Size(95, 158);
            // 
            // _ServiceMenuLAT
            // 
            this._ServiceMenuLAT.Name = "_ServiceMenuLAT";
            this._ServiceMenuLAT.Size = new System.Drawing.Size(94, 22);
            this._ServiceMenuLAT.Text = "LAT";
            this._ServiceMenuLAT.Click += new System.EventHandler(this._ServiceMenu_Click);
            // 
            // _ServiceMenuLIP
            // 
            this._ServiceMenuLIP.Name = "_ServiceMenuLIP";
            this._ServiceMenuLIP.Size = new System.Drawing.Size(94, 22);
            this._ServiceMenuLIP.Text = "LIP";
            this._ServiceMenuLIP.Click += new System.EventHandler(this._ServiceMenu_Click);
            // 
            // _ServiceMenuONC
            // 
            this._ServiceMenuONC.Name = "_ServiceMenuONC";
            this._ServiceMenuONC.Size = new System.Drawing.Size(94, 22);
            this._ServiceMenuONC.Text = "ONC";
            this._ServiceMenuONC.Click += new System.EventHandler(this._ServiceMenu_Click);
            // 
            // _ServiceMenuDTV
            // 
            this._ServiceMenuDTV.Name = "_ServiceMenuDTV";
            this._ServiceMenuDTV.Size = new System.Drawing.Size(94, 22);
            this._ServiceMenuDTV.Text = "DTV";
            this._ServiceMenuDTV.Click += new System.EventHandler(this._ServiceMenu_Click);
            // 
            // _ServiceMenuMTV
            // 
            this._ServiceMenuMTV.Name = "_ServiceMenuMTV";
            this._ServiceMenuMTV.Size = new System.Drawing.Size(94, 22);
            this._ServiceMenuMTV.Text = "MTV";
            this._ServiceMenuMTV.Click += new System.EventHandler(this._ServiceMenu_Click);
            // 
            // _ServiceMenuNFV
            // 
            this._ServiceMenuNFV.Name = "_ServiceMenuNFV";
            this._ServiceMenuNFV.Size = new System.Drawing.Size(94, 22);
            this._ServiceMenuNFV.Text = "NFV";
            this._ServiceMenuNFV.Click += new System.EventHandler(this._ServiceMenu_Click);
            // 
            // _ServiceMenuNBF
            // 
            this._ServiceMenuNBF.Name = "_ServiceMenuNBF";
            this._ServiceMenuNBF.Size = new System.Drawing.Size(94, 22);
            this._ServiceMenuNBF.Text = "NBF";
            this._ServiceMenuNBF.Click += new System.EventHandler(this._ServiceMenu_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(182, 216);
            this.flowLayoutPanel2.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Wheat;
            this.panel1.Controls.Add(this.labelledTextField2);
            this.panel1.Controls.Add(this.labelledTextField1);
            this.panel1.Location = new System.Drawing.Point(4, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 202);
            this.panel1.TabIndex = 0;
            // 
            // labelledTextField2
            // 
            this.labelledTextField2.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledTextField2.BackColor = System.Drawing.Color.Tomato;
            this.labelledTextField2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelledTextField2.BorderColour = System.Drawing.Color.Tomato;
            this.labelledTextField2.ControlHeight = 98;
            this.labelledTextField2.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledTextField2.LabelActiveColor = System.Drawing.Color.Empty;
            this.labelledTextField2.LabelAutoSize = false;
            this.labelledTextField2.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this.labelledTextField2.LabelInactiveColor = System.Drawing.Color.Empty;
            this.labelledTextField2.LabelOffset = new System.Drawing.Point(0, 0);
            this.labelledTextField2.LabelSize = new System.Drawing.Size(173, 17);
            this.labelledTextField2.LabelText = "OUTCOME";
            this.labelledTextField2.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelledTextField2.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledTextField2.Location = new System.Drawing.Point(1, 104);
            this.labelledTextField2.Margin = new System.Windows.Forms.Padding(0);
            this.labelledTextField2.Name = "labelledTextField2";
            this.labelledTextField2.PropertyName = null;
            this.labelledTextField2.Size = new System.Drawing.Size(173, 98);
            this.labelledTextField2.TabIndex = 1;
            this.labelledTextField2.TextField = "";
            // 
            // labelledTextField1
            // 
            this.labelledTextField1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledTextField1.BackColor = System.Drawing.Color.Tomato;
            this.labelledTextField1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelledTextField1.BorderColour = System.Drawing.Color.Tomato;
            this.labelledTextField1.ControlHeight = 97;
            this.labelledTextField1.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledTextField1.LabelActiveColor = System.Drawing.Color.Empty;
            this.labelledTextField1.LabelAutoSize = false;
            this.labelledTextField1.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this.labelledTextField1.LabelInactiveColor = System.Drawing.Color.Empty;
            this.labelledTextField1.LabelOffset = new System.Drawing.Point(0, 0);
            this.labelledTextField1.LabelSize = new System.Drawing.Size(174, 17);
            this.labelledTextField1.LabelText = "TESTING DONE";
            this.labelledTextField1.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelledTextField1.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledTextField1.Location = new System.Drawing.Point(0, 1);
            this.labelledTextField1.Margin = new System.Windows.Forms.Padding(0);
            this.labelledTextField1.Name = "labelledTextField1";
            this.labelledTextField1.PropertyName = null;
            this.labelledTextField1.Size = new System.Drawing.Size(174, 97);
            this.labelledTextField1.TabIndex = 0;
            this.labelledTextField1.TextField = "";
            // 
            // _PRContextMenu
            // 
            this._PRContextMenu.Font = new System.Drawing.Font("Verdana", 7F);
            this._PRContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewPRToolStripMenuItem,
            this.toolStripSeparator2,
            this.dispatchToolStripMenuItem,
            this.clearAndCloseToolStripMenuItem,
            this.stapleToParentToolStripMenuItem});
            this._PRContextMenu.Name = "_PRContextMenu";
            this._PRContextMenu.Size = new System.Drawing.Size(161, 98);
            this._PRContextMenu.Opened += new System.EventHandler(this._PRContextMenu_Opened);
            this._PRContextMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this._PRContextMenu_Clicked);
            // 
            // viewPRToolStripMenuItem
            // 
            this.viewPRToolStripMenuItem.Image = global::CallTracker.Properties.Resources.ViewinBrowser_6294;
            this.viewPRToolStripMenuItem.Name = "viewPRToolStripMenuItem";
            this.viewPRToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.viewPRToolStripMenuItem.Text = "View PR";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // dispatchToolStripMenuItem
            // 
            this.dispatchToolStripMenuItem.Name = "dispatchToolStripMenuItem";
            this.dispatchToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.dispatchToolStripMenuItem.Text = "Dispatch";
            // 
            // clearAndCloseToolStripMenuItem
            // 
            this.clearAndCloseToolStripMenuItem.Name = "clearAndCloseToolStripMenuItem";
            this.clearAndCloseToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.clearAndCloseToolStripMenuItem.Text = "Clear and Close";
            // 
            // stapleToParentToolStripMenuItem
            // 
            this.stapleToParentToolStripMenuItem.Name = "stapleToParentToolStripMenuItem";
            this.stapleToParentToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.stapleToParentToolStripMenuItem.Text = "Staple to Parent";
            // 
            // _SeverityMenuStrip
            // 
            this._SeverityMenuStrip.AutoSize = false;
            this._SeverityMenuStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this._SeverityMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._SeverityMenuStrip.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerContactsBindingSource, "Fault.Severity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._SeverityMenuStrip.Font = new System.Drawing.Font("Gautami", 8.25F);
            this._SeverityMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iToolStripMenuItem,
            this.dToolStripMenuItem,
            this.nToolStripMenuItem,
            this.hToolStripMenuItem});
            this._SeverityMenuStrip.Name = "_SeverityMenuStrip";
            this._SeverityMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._SeverityMenuStrip.ShowImageMargin = false;
            this._SeverityMenuStrip.Size = new System.Drawing.Size(40, 96);
            this._SeverityMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._SeverityMenuStrip_ItemClicked);
            // 
            // iToolStripMenuItem
            // 
            this.iToolStripMenuItem.AutoSize = false;
            this.iToolStripMenuItem.Checked = true;
            this.iToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.iToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.iToolStripMenuItem.Font = new System.Drawing.Font("KaiTi", 9.6F);
            this.iToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.iToolStripMenuItem.Name = "iToolStripMenuItem";
            this.iToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.iToolStripMenuItem.ShowShortcutKeys = false;
            this.iToolStripMenuItem.Size = new System.Drawing.Size(30, 24);
            this.iToolStripMenuItem.Text = "I";
            this.iToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.iToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.iToolStripMenuItem.ToolTipText = "Interruption";
            this.iToolStripMenuItem.CheckedChanged += new System.EventHandler(this.hToolStripMenuItem_CheckedChanged);
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.AutoSize = false;
            this.dToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.ShowShortcutKeys = false;
            this.dToolStripMenuItem.Size = new System.Drawing.Size(30, 22);
            this.dToolStripMenuItem.Text = "D";
            this.dToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.dToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.dToolStripMenuItem.ToolTipText = "Degredation";
            this.dToolStripMenuItem.CheckedChanged += new System.EventHandler(this.hToolStripMenuItem_CheckedChanged);
            // 
            // nToolStripMenuItem
            // 
            this.nToolStripMenuItem.AutoSize = false;
            this.nToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.nToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.nToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.nToolStripMenuItem.Name = "nToolStripMenuItem";
            this.nToolStripMenuItem.ShowShortcutKeys = false;
            this.nToolStripMenuItem.Size = new System.Drawing.Size(30, 22);
            this.nToolStripMenuItem.Text = "N";
            this.nToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.nToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.nToolStripMenuItem.ToolTipText = "No Impact";
            this.nToolStripMenuItem.CheckedChanged += new System.EventHandler(this.hToolStripMenuItem_CheckedChanged);
            // 
            // hToolStripMenuItem
            // 
            this.hToolStripMenuItem.AutoSize = false;
            this.hToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.hToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.hToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.hToolStripMenuItem.Name = "hToolStripMenuItem";
            this.hToolStripMenuItem.ShowShortcutKeys = false;
            this.hToolStripMenuItem.Size = new System.Drawing.Size(30, 22);
            this.hToolStripMenuItem.Text = "H";
            this.hToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.hToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.hToolStripMenuItem.ToolTipText = "Hazardous";
            this.hToolStripMenuItem.CheckedChanged += new System.EventHandler(this.hToolStripMenuItem_CheckedChanged);
            // 
            // _NewCallMenuStrip
            // 
            this._NewCallMenuStrip.Font = new System.Drawing.Font("Verdana", 7F);
            this._NewCallMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7});
            this._NewCallMenuStrip.Name = "contextMenuStrip1";
            this._NewCallMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._NewCallMenuStrip.ShowCheckMargin = true;
            this._NewCallMenuStrip.ShowImageMargin = false;
            this._NewCallMenuStrip.Size = new System.Drawing.Size(156, 180);
            this._NewCallMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._NewCallMenuStrip_ItemClicked);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Enabled = false;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem8.Text = "Default Product";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem1.Text = "LAT";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem2.Text = "LIP";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem3.Text = "ONC";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem4.Text = "DTV";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem5.Text = "MTV";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem6.Text = "NFV";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem7.Text = "NBF";
            // 
            // _CallHistoryContextMenu
            // 
            this._CallHistoryContextMenu.Font = new System.Drawing.Font("Verdana", 7F);
            this._CallHistoryContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.callHistoryToolStripMenuItem});
            this._CallHistoryContextMenu.Name = "_CallHistoryContextMenu";
            this._CallHistoryContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._CallHistoryContextMenu.ShowImageMargin = false;
            this._CallHistoryContextMenu.Size = new System.Drawing.Size(141, 26);
            // 
            // callHistoryToolStripMenuItem
            // 
            this.callHistoryToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 7F);
            this.callHistoryToolStripMenuItem.Name = "callHistoryToolStripMenuItem";
            this.callHistoryToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.callHistoryToolStripMenuItem.Text = "Show Call History";
            this.callHistoryToolStripMenuItem.Click += new System.EventHandler(this.callHistoryToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.Controls.Add(this._Icon);
            this.flowLayoutPanel1.Controls.Add(this._Cmbs);
            this.flowLayoutPanel1.Controls.Add(this._Username);
            this.flowLayoutPanel1.Controls.Add(this._Dn);
            this.flowLayoutPanel1.Controls.Add(this._Name);
            this.flowLayoutPanel1.Controls.Add(this._Mobile);
            this.flowLayoutPanel1.Controls.Add(this._Address);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(331, 108);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrayBorder);
            // 
            // _Icon
            // 
            this._Icon.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Icon.BackColor = System.Drawing.Color.SlateGray;
            this._Icon.BorderColour = System.Drawing.Color.SlateGray;
            this._Icon.ControlHeight = 20;
            this._Icon.ControlMargin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Icon.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.customerContactsBindingSource, "ICON", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Icon.DefaultText = "";
            this._Icon.Font = new System.Drawing.Font("Verdana", 7F);
            this._Icon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._Icon.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._Icon.LabelAutoSize = false;
            this._Icon.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Icon.LabelInactiveColor = System.Drawing.Color.SlateGray;
            this._Icon.LabelOffset = new System.Drawing.Point(0, 0);
            this._Icon.LabelSize = new System.Drawing.Size(50, 20);
            this._Icon.LabelText = "ICON";
            this._Icon.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Icon.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Icon.Location = new System.Drawing.Point(3, 6);
            this._Icon.Margin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Icon.Name = "_Icon";
            this._Icon.PropertyName = null;
            this._Icon.Size = new System.Drawing.Size(187, 20);
            this._Icon.TabIndex = 13;
            this._Icon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Icon.TextField = "";
            this.toolTip1.SetToolTip(this._Icon, "Shift-Ctrl-1");
            // 
            // _Cmbs
            // 
            this._Cmbs.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Cmbs.BackColor = System.Drawing.Color.SlateGray;
            this._Cmbs.BorderColour = System.Drawing.Color.SlateGray;
            this._Cmbs.ControlHeight = 20;
            this._Cmbs.ControlMargin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Cmbs.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.customerContactsBindingSource, "CMBS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Cmbs.DefaultText = "";
            this._Cmbs.Font = new System.Drawing.Font("Verdana", 7F);
            this._Cmbs.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._Cmbs.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._Cmbs.LabelAutoSize = false;
            this._Cmbs.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Cmbs.LabelInactiveColor = System.Drawing.Color.SlateGray;
            this._Cmbs.LabelOffset = new System.Drawing.Point(0, 0);
            this._Cmbs.LabelSize = new System.Drawing.Size(40, 20);
            this._Cmbs.LabelText = "CMBS";
            this._Cmbs.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Cmbs.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Cmbs.Location = new System.Drawing.Point(193, 6);
            this._Cmbs.Margin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Cmbs.Name = "_Cmbs";
            this._Cmbs.PropertyName = null;
            this._Cmbs.Size = new System.Drawing.Size(135, 20);
            this._Cmbs.TabIndex = 14;
            this._Cmbs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Cmbs.TextField = "";
            this.toolTip1.SetToolTip(this._Cmbs, "Shift-Ctrl-2");
            // 
            // _Username
            // 
            this._Username.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Username.BackColor = System.Drawing.Color.SlateGray;
            this._Username.BorderColour = System.Drawing.Color.SlateGray;
            this._Username.ControlHeight = 20;
            this._Username.ControlMargin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Username.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.customerContactsBindingSource, "Username", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Username.DefaultText = "";
            this._Username.Font = new System.Drawing.Font("Verdana", 7F);
            this._Username.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._Username.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._Username.LabelAutoSize = false;
            this._Username.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Username.LabelInactiveColor = System.Drawing.Color.SlateGray;
            this._Username.LabelOffset = new System.Drawing.Point(0, 0);
            this._Username.LabelSize = new System.Drawing.Size(50, 20);
            this._Username.LabelText = "Username";
            this._Username.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Username.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Username.Location = new System.Drawing.Point(3, 31);
            this._Username.Margin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Username.Name = "_Username";
            this._Username.PropertyName = null;
            this._Username.Size = new System.Drawing.Size(187, 20);
            this._Username.TabIndex = 15;
            this._Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._Username.TextField = "";
            this.toolTip1.SetToolTip(this._Username, "Shift-Ctrl-Q");
            // 
            // _Dn
            // 
            this._Dn.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Dn.BackColor = System.Drawing.Color.SlateGray;
            this._Dn.BorderColour = System.Drawing.Color.SlateGray;
            this._Dn.ControlHeight = 20;
            this._Dn.ControlMargin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Dn.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.customerContactsBindingSource, "DN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Dn.DefaultText = "";
            this._Dn.Font = new System.Drawing.Font("Verdana", 7F);
            this._Dn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._Dn.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._Dn.LabelAutoSize = false;
            this._Dn.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Dn.LabelInactiveColor = System.Drawing.Color.SlateGray;
            this._Dn.LabelOffset = new System.Drawing.Point(0, 0);
            this._Dn.LabelSize = new System.Drawing.Size(40, 20);
            this._Dn.LabelText = "DN";
            this._Dn.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Dn.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Dn.Location = new System.Drawing.Point(193, 31);
            this._Dn.Margin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Dn.Name = "_Dn";
            this._Dn.PropertyName = "DN";
            this._Dn.Size = new System.Drawing.Size(135, 20);
            this._Dn.TabIndex = 16;
            this._Dn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Dn.TextField = "";
            this.toolTip1.SetToolTip(this._Dn, "Shift-Ctrl-W");
            // 
            // _Name
            // 
            this._Name.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Name.BackColor = System.Drawing.Color.SlateGray;
            this._Name.BorderColour = System.Drawing.Color.SlateGray;
            this._Name.ControlHeight = 20;
            this._Name.ControlMargin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Name.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.customerContactsBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Name.DefaultText = "";
            this._Name.Font = new System.Drawing.Font("Verdana", 7F);
            this._Name.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._Name.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._Name.LabelAutoSize = false;
            this._Name.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Name.LabelInactiveColor = System.Drawing.Color.SlateGray;
            this._Name.LabelOffset = new System.Drawing.Point(0, 0);
            this._Name.LabelSize = new System.Drawing.Size(50, 20);
            this._Name.LabelText = "Name";
            this._Name.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Name.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Name.Location = new System.Drawing.Point(3, 56);
            this._Name.Margin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Name.Name = "_Name";
            this._Name.PropertyName = null;
            this._Name.Size = new System.Drawing.Size(187, 20);
            this._Name.TabIndex = 17;
            this._Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._Name.TextField = "";
            this.toolTip1.SetToolTip(this._Name, "Shift-Ctrl-A");
            // 
            // _Mobile
            // 
            this._Mobile.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Mobile.BackColor = System.Drawing.Color.SlateGray;
            this._Mobile.BorderColour = System.Drawing.Color.SlateGray;
            this._Mobile.ControlHeight = 20;
            this._Mobile.ControlMargin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Mobile.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.customerContactsBindingSource, "Mobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Mobile.DefaultText = "";
            this._Mobile.Dock = System.Windows.Forms.DockStyle.Right;
            this._Mobile.Font = new System.Drawing.Font("Verdana", 7F);
            this._Mobile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._Mobile.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._Mobile.LabelAutoSize = false;
            this._Mobile.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Mobile.LabelInactiveColor = System.Drawing.Color.SlateGray;
            this._Mobile.LabelOffset = new System.Drawing.Point(0, 0);
            this._Mobile.LabelSize = new System.Drawing.Size(40, 20);
            this._Mobile.LabelText = "Mobile";
            this._Mobile.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Mobile.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Mobile.Location = new System.Drawing.Point(193, 56);
            this._Mobile.Margin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Mobile.Name = "_Mobile";
            this._Mobile.PropertyName = null;
            this._Mobile.Size = new System.Drawing.Size(135, 20);
            this._Mobile.TabIndex = 18;
            this._Mobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Mobile.TextField = "";
            this.toolTip1.SetToolTip(this._Mobile, "Shift-Ctrl-S");
            // 
            // _Address
            // 
            this._Address.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Address.BackColor = System.Drawing.Color.SlateGray;
            this._Address.BorderColour = System.Drawing.Color.SlateGray;
            this._Address.ControlHeight = 20;
            this._Address.ControlMargin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Address.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.customerContactsBindingSource, "Address.Address", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Address.DefaultText = "";
            this._Address.Font = new System.Drawing.Font("Verdana", 7F);
            this._Address.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._Address.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._Address.LabelAutoSize = false;
            this._Address.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Address.LabelInactiveColor = System.Drawing.Color.SlateGray;
            this._Address.LabelOffset = new System.Drawing.Point(0, 0);
            this._Address.LabelSize = new System.Drawing.Size(50, 20);
            this._Address.LabelText = "Address";
            this._Address.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Address.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Address.Location = new System.Drawing.Point(3, 81);
            this._Address.Margin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this._Address.Name = "_Address";
            this._Address.PropertyName = null;
            this._Address.Size = new System.Drawing.Size(325, 20);
            this._Address.TabIndex = 19;
            this._Address.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._Address.TextField = "";
            // 
            // _DialContextMenu
            // 
            this._DialContextMenu.Font = new System.Drawing.Font("Verdana", 7F);
            this._DialContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dialToolStripMenuItem,
            this.transferToolStripMenuItem});
            this._DialContextMenu.Name = "_DialContextMenu";
            this._DialContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this._DialContextMenu.ShowImageMargin = false;
            this._DialContextMenu.Size = new System.Drawing.Size(92, 48);
            // 
            // dialToolStripMenuItem
            // 
            this.dialToolStripMenuItem.Name = "dialToolStripMenuItem";
            this.dialToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.dialToolStripMenuItem.Text = "Dial";
            this.dialToolStripMenuItem.Click += new System.EventHandler(this._Dial_click);
            // 
            // transferToolStripMenuItem
            // 
            this.transferToolStripMenuItem.Name = "transferToolStripMenuItem";
            this.transferToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.transferToolStripMenuItem.Text = "Transfer";
            this.transferToolStripMenuItem.Click += new System.EventHandler(this._Transfer_click);
            // 
            // ServiceTypePanel
            // 
            this.ServiceTypePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ServiceTypePanel.BackColor = System.Drawing.Color.LightGray;
            this.ServiceTypePanel.Controls.Add(this._LAT);
            this.ServiceTypePanel.Controls.Add(this._LIP);
            this.ServiceTypePanel.Controls.Add(this._ONC);
            this.ServiceTypePanel.Controls.Add(this._DTV);
            this.ServiceTypePanel.Controls.Add(this._MTV);
            this.ServiceTypePanel.Controls.Add(this._NFV);
            this.ServiceTypePanel.Controls.Add(this._NBF);
            this.ServiceTypePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ServiceTypePanel.Location = new System.Drawing.Point(334, 0);
            this.ServiceTypePanel.Margin = new System.Windows.Forms.Padding(0);
            this.ServiceTypePanel.Name = "ServiceTypePanel";
            this.ServiceTypePanel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ServiceTypePanel.Size = new System.Drawing.Size(54, 216);
            this.ServiceTypePanel.TabIndex = 17;
            this.ServiceTypePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrayBorder);
            // 
            // _LAT
            // 
            this._LAT.AutoSize = true;
            this._LAT.BackColor = System.Drawing.Color.Transparent;
            this._LAT.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.customerContactsBindingSource, "Fault.LAT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._LAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._LAT.Font = new System.Drawing.Font("Gautami", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LAT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._LAT.Location = new System.Drawing.Point(5, 3);
            this._LAT.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._LAT.Name = "_LAT";
            this._LAT.Size = new System.Drawing.Size(45, 27);
            this._LAT.TabIndex = 0;
            this._LAT.Tag = "1";
            this._LAT.Text = "LAT";
            this._LAT.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this._LAT.UseVisualStyleBackColor = false;
            this._LAT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._LAT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _LIP
            // 
            this._LIP.AutoSize = true;
            this._LIP.BackColor = System.Drawing.Color.Transparent;
            this._LIP.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.customerContactsBindingSource, "Fault.LIP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._LIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._LIP.Font = new System.Drawing.Font("Gautami", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LIP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._LIP.Location = new System.Drawing.Point(5, 33);
            this._LIP.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._LIP.Name = "_LIP";
            this._LIP.Size = new System.Drawing.Size(42, 27);
            this._LIP.TabIndex = 1;
            this._LIP.Tag = "2";
            this._LIP.Text = "LIP";
            this._LIP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this._LIP.UseVisualStyleBackColor = false;
            this._LIP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._LIP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _ONC
            // 
            this._ONC.AutoSize = true;
            this._ONC.BackColor = System.Drawing.Color.Transparent;
            this._ONC.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.customerContactsBindingSource, "Fault.ONC", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._ONC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._ONC.Font = new System.Drawing.Font("Gautami", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ONC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._ONC.Location = new System.Drawing.Point(5, 63);
            this._ONC.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._ONC.Name = "_ONC";
            this._ONC.Size = new System.Drawing.Size(48, 27);
            this._ONC.TabIndex = 2;
            this._ONC.Tag = "4";
            this._ONC.Text = "ONC";
            this._ONC.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this._ONC.UseVisualStyleBackColor = false;
            this._ONC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._ONC.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _DTV
            // 
            this._DTV.AutoSize = true;
            this._DTV.BackColor = System.Drawing.Color.Transparent;
            this._DTV.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.customerContactsBindingSource, "Fault.DTV", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._DTV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._DTV.Font = new System.Drawing.Font("Gautami", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._DTV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._DTV.Location = new System.Drawing.Point(5, 93);
            this._DTV.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._DTV.Name = "_DTV";
            this._DTV.Size = new System.Drawing.Size(46, 27);
            this._DTV.TabIndex = 4;
            this._DTV.Tag = "32";
            this._DTV.Text = "DTV";
            this._DTV.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this._DTV.UseVisualStyleBackColor = false;
            this._DTV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._DTV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _MTV
            // 
            this._MTV.AutoSize = true;
            this._MTV.BackColor = System.Drawing.Color.Transparent;
            this._MTV.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.customerContactsBindingSource, "Fault.MTV", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._MTV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._MTV.Font = new System.Drawing.Font("Gautami", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._MTV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._MTV.Location = new System.Drawing.Point(5, 123);
            this._MTV.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._MTV.Name = "_MTV";
            this._MTV.Size = new System.Drawing.Size(48, 27);
            this._MTV.TabIndex = 5;
            this._MTV.Tag = "64";
            this._MTV.Text = "MTV";
            this._MTV.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this._MTV.UseVisualStyleBackColor = false;
            this._MTV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._MTV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _NFV
            // 
            this._NFV.AutoSize = true;
            this._NFV.BackColor = System.Drawing.Color.Transparent;
            this._NFV.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.customerContactsBindingSource, "Fault.NFV", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._NFV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._NFV.Font = new System.Drawing.Font("Gautami", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._NFV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._NFV.Location = new System.Drawing.Point(5, 153);
            this._NFV.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._NFV.Name = "_NFV";
            this._NFV.Size = new System.Drawing.Size(46, 27);
            this._NFV.TabIndex = 6;
            this._NFV.Tag = "8";
            this._NFV.Text = "NFV";
            this._NFV.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this._NFV.UseVisualStyleBackColor = false;
            this._NFV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._NFV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _NBF
            // 
            this._NBF.AutoSize = true;
            this._NBF.BackColor = System.Drawing.Color.Transparent;
            this._NBF.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.customerContactsBindingSource, "Fault.NBF", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._NBF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._NBF.Font = new System.Drawing.Font("Gautami", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._NBF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._NBF.Location = new System.Drawing.Point(5, 183);
            this._NBF.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._NBF.Name = "_NBF";
            this._NBF.Size = new System.Drawing.Size(46, 27);
            this._NBF.TabIndex = 3;
            this._NBF.Tag = "16";
            this._NBF.Text = "NBF";
            this._NBF.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this._NBF.UseVisualStyleBackColor = false;
            this._NBF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._NBF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel4.Controls.Add(this._notePanel);
            this.flowLayoutPanel4.Controls.Add(this.bindingNavigator1);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(1, 0);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(1, 0, 2, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(331, 232);
            this.flowLayoutPanel4.TabIndex = 29;
            // 
            // _notePanel
            // 
            this._notePanel.Controls.Add(this._Note);
            this._notePanel.Location = new System.Drawing.Point(0, 110);
            this._notePanel.Margin = new System.Windows.Forms.Padding(0);
            this._notePanel.Name = "_notePanel";
            this._notePanel.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this._notePanel.Size = new System.Drawing.Size(331, 77);
            this._notePanel.TabIndex = 4;
            this._notePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrayBorder);
            // 
            // _Note
            // 
            this._Note.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Note.ContextMenuStrip = this._NoteContextMenuStrip;
            this._Note.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerContactsBindingSource, "Note", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Note.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Note.Location = new System.Drawing.Point(1, 0);
            this._Note.Margin = new System.Windows.Forms.Padding(0);
            this._Note.Name = "_Note";
            this._Note.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this._Note.Size = new System.Drawing.Size(330, 77);
            this._Note.TabIndex = 1;
            this._Note.Text = "";
            // 
            // _NoteContextMenuStrip
            // 
            this._NoteContextMenuStrip.Font = new System.Drawing.Font("Gautami", 8.25F);
            this._NoteContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noteToolStripMenuItem,
            this.generateICONNoteToolStripMenuItem,
            this.pRTemplateToolStripMenuItem,
            this.toolStripSeparator3,
            this.copyToolStripMenuItem});
            this._NoteContextMenuStrip.Name = "_NoteContextMenuStrip";
            this._NoteContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._NoteContextMenuStrip.Size = new System.Drawing.Size(188, 116);
            this._NoteContextMenuStrip.Text = "Note Options";
            // 
            // noteToolStripMenuItem
            // 
            this.noteToolStripMenuItem.Checked = true;
            this.noteToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noteToolStripMenuItem.Font = new System.Drawing.Font("Gautami", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteToolStripMenuItem.Name = "noteToolStripMenuItem";
            this.noteToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.noteToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.noteToolStripMenuItem.Tag = "Note";
            this.noteToolStripMenuItem.Text = "Call Notes";
            this.noteToolStripMenuItem.Click += new System.EventHandler(this.SwitchNote);
            // 
            // generateICONNoteToolStripMenuItem
            // 
            this.generateICONNoteToolStripMenuItem.Font = new System.Drawing.Font("Gautami", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateICONNoteToolStripMenuItem.Name = "generateICONNoteToolStripMenuItem";
            this.generateICONNoteToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.generateICONNoteToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.generateICONNoteToolStripMenuItem.Tag = "ICONNote";
            this.generateICONNoteToolStripMenuItem.Text = "Generate ICON Note";
            this.generateICONNoteToolStripMenuItem.Click += new System.EventHandler(this.SwitchNote);
            // 
            // pRTemplateToolStripMenuItem
            // 
            this.pRTemplateToolStripMenuItem.Font = new System.Drawing.Font("Gautami", 8.25F);
            this.pRTemplateToolStripMenuItem.Name = "pRTemplateToolStripMenuItem";
            this.pRTemplateToolStripMenuItem.Size = new System.Drawing.Size(187, 28);
            this.pRTemplateToolStripMenuItem.Tag = "PRTemplate";
            this.pRTemplateToolStripMenuItem.Text = "Generate PR Template";
            this.pRTemplateToolStripMenuItem.Click += new System.EventHandler(this.SwitchNote);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(184, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Font = new System.Drawing.Font("Gautami", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyToolStripMenuItem.Image = global::CallTracker.Properties.Resources.Copy_6524;
            this.copyToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.copyToolStripMenuItem.Text = "Copy All";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.AutoSize = false;
            this.bindingNavigator1.BackColor = System.Drawing.Color.LightGray;
            this.bindingNavigator1.BindingSource = this.customerContactsBindingSource;
            this.bindingNavigator1.ContextMenuStrip = this._CallHistoryContextMenu;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Font = new System.Drawing.Font("Verdana", 7F);
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._NewCallButton,
            this._PrevCallButton,
            this._CurrentPosition,
            this.toolStripSeparator4,
            this._NextCallButton,
            this.toolStripSeparator5,
            this._WorkReadyTimerDisplay});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 189);
            this.bindingNavigator1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = this._NextCallButton;
            this.bindingNavigator1.MovePreviousItem = this._PrevCallButton;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.bindingNavigator1.PositionItem = this._CurrentPosition;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator1.Size = new System.Drawing.Size(331, 33);
            this.bindingNavigator1.Stretch = true;
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigatorIgnoreFocus1";
            this.bindingNavigator1.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrayBorder);
            // 
            // _NewCallButton
            // 
            this._NewCallButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._NewCallButton.Font = new System.Drawing.Font("Verdana", 7F);
            this._NewCallButton.Image = ((System.Drawing.Image)(resources.GetObject("_NewCallButton.Image")));
            this._NewCallButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._NewCallButton.Name = "_NewCallButton";
            this._NewCallButton.RightToLeftAutoMirrorImage = true;
            this._NewCallButton.Size = new System.Drawing.Size(71, 27);
            this._NewCallButton.Text = "New Call";
            this._NewCallButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this._NewCallButton.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // _PrevCallButton
            // 
            this._PrevCallButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._PrevCallButton.Image = ((System.Drawing.Image)(resources.GetObject("_PrevCallButton.Image")));
            this._PrevCallButton.Name = "_PrevCallButton";
            this._PrevCallButton.RightToLeftAutoMirrorImage = true;
            this._PrevCallButton.Size = new System.Drawing.Size(23, 27);
            this._PrevCallButton.Text = "Move previous";
            // 
            // _CurrentPosition
            // 
            this._CurrentPosition.AccessibleName = "Position";
            this._CurrentPosition.AutoSize = false;
            this._CurrentPosition.BackColor = System.Drawing.Color.GhostWhite;
            this._CurrentPosition.Font = new System.Drawing.Font("Verdana", 7F);
            this._CurrentPosition.Name = "_CurrentPosition";
            this._CurrentPosition.Size = new System.Drawing.Size(40, 19);
            this._CurrentPosition.Text = "0";
            this._CurrentPosition.ToolTipText = "Current position";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
            // 
            // _NextCallButton
            // 
            this._NextCallButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._NextCallButton.Image = ((System.Drawing.Image)(resources.GetObject("_NextCallButton.Image")));
            this._NextCallButton.Name = "_NextCallButton";
            this._NextCallButton.RightToLeftAutoMirrorImage = true;
            this._NextCallButton.Size = new System.Drawing.Size(23, 27);
            this._NextCallButton.Text = "Move next";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 30);
            // 
            // _WorkReadyTimerDisplay
            // 
            this._WorkReadyTimerDisplay.AutoSize = false;
            this._WorkReadyTimerDisplay.BackColor = System.Drawing.Color.LightGray;
            this._WorkReadyTimerDisplay.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this._WorkReadyTimerDisplay.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this._WorkReadyTimerDisplay.Font = new System.Drawing.Font("Verdana", 7F);
            this._WorkReadyTimerDisplay.ForeColor = System.Drawing.Color.DarkSlateGray;
            this._WorkReadyTimerDisplay.Margin = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this._WorkReadyTimerDisplay.Name = "_WorkReadyTimerDisplay";
            this._WorkReadyTimerDisplay.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this._WorkReadyTimerDisplay.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this._WorkReadyTimerDisplay.Size = new System.Drawing.Size(150, 20);
            this._WorkReadyTimerDisplay.Text = "Work Ready: 00:00";
            this._WorkReadyTimerDisplay.Click += new System.EventHandler(this._WorkReadyTimerDisplay_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.flowLayoutPanel4);
            this.MainPanel.Controls.Add(this.ServiceTypePanel);
            this.MainPanel.Controls.Add(this.FaultPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(2, 3);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(580, 216);
            this.MainPanel.TabIndex = 30;
            this.MainPanel.WrapContents = false;
            // 
            // _WorkReadyTimer
            // 
            this._WorkReadyTimer.Interval = 1000;
            this._WorkReadyTimer.Tick += new System.EventHandler(this._WorkReadyTimer_Tick);
            // 
            // EditContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EditContact";
            this.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Size = new System.Drawing.Size(584, 222);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrayBorderMain);
            ((System.ComponentModel.ISupportInitialize)(servicesDataSet)).EndInit();
            this.FaultPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.HfcPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerContactsBindingSource)).EndInit();
            this._ServiceMenu.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this._PRContextMenu.ResumeLayout(false);
            this._SeverityMenuStrip.ResumeLayout(false);
            this._NewCallMenuStrip.ResumeLayout(false);
            this._CallHistoryContextMenu.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this._DialContextMenu.ResumeLayout(false);
            this.ServiceTypePanel.ResumeLayout(false);
            this.ServiceTypePanel.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this._notePanel.ResumeLayout(false);
            this._NoteContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FaultPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel HfcPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel ServiceTypePanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel MainPanel;
        public System.Windows.Forms.BindingSource customerContactsBindingSource;
        private System.Windows.Forms.RichTextBox _Note;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip _DialContextMenu;
        private System.Windows.Forms.ToolStripMenuItem dialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip _CallHistoryContextMenu;
        private System.Windows.Forms.ToolStripMenuItem callHistoryToolStripMenuItem;
        public System.Windows.Forms.CheckBox _LAT;
        public System.Windows.Forms.CheckBox _LIP;
        public System.Windows.Forms.CheckBox _ONC;
        public System.Windows.Forms.CheckBox _NBF;
        public System.Windows.Forms.CheckBox _DTV;
        public System.Windows.Forms.CheckBox _MTV;
        public System.Windows.Forms.CheckBox _NFV;
        public System.Windows.Forms.ContextMenuStrip _ServiceMenu;
        public System.Windows.Forms.ToolStripMenuItem _ServiceMenuLAT;
        public System.Windows.Forms.ToolStripMenuItem _ServiceMenuLIP;
        public System.Windows.Forms.ToolStripMenuItem _ServiceMenuONC;
        public System.Windows.Forms.ToolStripMenuItem _ServiceMenuNFV;
        public System.Windows.Forms.ToolStripMenuItem _ServiceMenuNBF;
        public System.Windows.Forms.ToolStripMenuItem _ServiceMenuDTV;
        public System.Windows.Forms.ToolStripMenuItem _ServiceMenuMTV;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip _OutcomeTooltip;
        private System.Windows.Forms.ContextMenuStrip _NoteContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem noteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateICONNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip _NewCallMenuStrip;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem iToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hToolStripMenuItem;
        internal System.Windows.Forms.ContextMenuStrip _SeverityMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewPRToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem dispatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAndCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stapleToParentToolStripMenuItem;
        internal System.Windows.Forms.ContextMenuStrip _PRContextMenu;
        private LabelledTextBox _PR;
        private LabelledTextBox _NPR;
        internal LabelledComboBox _Symptom;
        
        private LabelledComboBox _Outcome;
        private LabelledTextBoxLong _Icon;
        private LabelledTextBoxLong _Cmbs;
        private LabelledTextBoxLong _Username;
        private LabelledTextBoxLong _Dn;
        private LabelledTextBoxLong _Name;
        private LabelledTextBoxLong _Mobile;
        private LabelledTextBoxLong _Address;
        private System.Windows.Forms.Panel _notePanel;
        internal LabelledComboBoxLong _Equipment;
        private LabelledTextBox _Itcase;
        internal LabelledComboBox _BookingType;
        internal LabelledComboBox _BookingTimeSlot;
        private LabelledTextField labelledTextField1;
        private LabelledTextField labelledTextField2;
        private LabelledDatePicker _BookingDate;
        private BindingNavigatorIgnoreFocus bindingNavigator1;
        private System.Windows.Forms.ToolStripButton _NewCallButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton _PrevCallButton;
        private System.Windows.Forms.ToolStripTextBox _CurrentPosition;
        private System.Windows.Forms.ToolStripButton _NextCallButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem pRTemplateToolStripMenuItem;
        internal System.Windows.Forms.ToolStripStatusLabel _WorkReadyTimerDisplay;
        internal System.Windows.Forms.Timer _WorkReadyTimer;
    }
}
