namespace CallTracker.View
{
    partial class ServicePanel
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
            this._LATPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._Node = new CallTracker.View.LabelledTextBoxLong();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this._CauPing = new CallTracker.View.LabelledComboBoxLong();
            this._NitResults = new CallTracker.View.LabelledTextField();
            this.labelledBase2 = new CallTracker.View.LabelledBase();
            this._ESN = new CallTracker.View.LabelledTextBoxLong();
            this._NBNPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._Bras = new CallTracker.View.LabelledTextBoxLong();
            this._Sip = new CallTracker.View.LabelledComboBoxLong();
            this._AVC = new CallTracker.View.LabelledTextBoxLong();
            this._CSA = new CallTracker.View.LabelledTextBoxLong();
            this._CVC = new CallTracker.View.LabelledTextBoxLong();
            this._NNI = new CallTracker.View.LabelledTextBoxLong();
            this._GSID = new CallTracker.View.LabelledTextBoxLong();
            this._INC = new CallTracker.View.LabelledTextBoxLong();
            this._APT = new CallTracker.View.LabelledTextBoxLong();
            this._NTDSN = new CallTracker.View.LabelledTextBoxLong();
            this._IPNBN = new CallTracker.View.LabelledTextBoxLong();
            this._DTVPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._DTVNode = new CallTracker.View.LabelledTextBoxLong();
            this._DTVMsg = new CallTracker.View.LabelledTextBoxLong();
            this._DTVLights = new CallTracker.View.LabelledComboBoxLong();
            this._STBHeading = new CallTracker.View.LabelledBase();
            this._STBSmartCard = new CallTracker.View.LabelledTextBoxLong();
            this._STBLot = new CallTracker.View.LabelledTextBox();
            this._STBBox = new CallTracker.View.LabelledTextBox();
            this._MTVPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._MTVHeading = new CallTracker.View.LabelledBase();
            this._MTVMac = new CallTracker.View.LabelledTextBoxLong();
            this._MTVSN = new CallTracker.View.LabelledTextBoxLong();
            this._ONCPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._ModemStatus = new CallTracker.View.LabelledComboBoxLong();
            this._ModemRF = new CallTracker.View.LabelledComboBoxLong();
            this._ONCNode = new CallTracker.View.LabelledTextBoxLong();
            this._SpeedTestHeading = new CallTracker.View.LabelledBase();
            this._SpeedTestDown = new CallTracker.View.LabelledTextBoxLong();
            this._SpeedTestUp = new CallTracker.View.LabelledTextBoxLong();
            this._ModemDetailsHeading = new CallTracker.View.LabelledBase();
            this._ModemCMMac = new CallTracker.View.LabelledTextBoxLong();
            this._ModemMTAMac = new CallTracker.View.LabelledTextBoxLong();
            this._ModemSN = new CallTracker.View.LabelledTextBoxLong();
            this.labelledTextBoxLong1 = new CallTracker.View.LabelledTextBoxLong();
            this.labelledBase1 = new CallTracker.View.LabelledBase();
            this._AddressId = new CallTracker.View.LabelledTextBoxLong();
            this._EquipmentMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.userGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._NodeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this._PRIContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nSIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._AVCContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._CVCContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this._Equipment = new CallTracker.View.LabelledComboBoxLong();
            this._ServiceHeading = new CallTracker.View.LabelledBase();
            this._LATPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this._NBNPanel.SuspendLayout();
            this._DTVPanel.SuspendLayout();
            this._MTVPanel.SuspendLayout();
            this._ONCPanel.SuspendLayout();
            this._EquipmentMenu.SuspendLayout();
            this._NodeContextMenu.SuspendLayout();
            this._PRIContextMenu.SuspendLayout();
            this._AVCContextMenu.SuspendLayout();
            this._CVCContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _LATPanel
            // 
            this._LATPanel.Controls.Add(this._Node);
            this._LATPanel.Controls.Add(this._CauPing);
            this._LATPanel.Controls.Add(this._NitResults);
            this._LATPanel.Controls.Add(this.labelledBase2);
            this._LATPanel.Controls.Add(this._ESN);
            this._LATPanel.Location = new System.Drawing.Point(372, 35);
            this._LATPanel.Name = "_LATPanel";
            this._LATPanel.Padding = new System.Windows.Forms.Padding(4, 1, 4, 0);
            this._LATPanel.Size = new System.Drawing.Size(180, 217);
            this._LATPanel.TabIndex = 70;
            // 
            // _Node
            // 
            this._Node.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Node.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._Node.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._Node.ControlHeight = 20;
            this._Node.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._Node.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.Node", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Node.DefaultText = "";
            this._Node.Font = new System.Drawing.Font("Verdana", 7F);
            this._Node.HasContextMenu = false;
            this._Node.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._Node.LabelAutoSize = false;
            this._Node.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._Node.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._Node.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._Node.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._Node.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Node.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._Node.LabelMargin = new System.Windows.Forms.Padding(0);
            this._Node.LabelOffset = new System.Drawing.Point(0, 0);
            this._Node.LabelPadding = new System.Windows.Forms.Padding(0);
            this._Node.LabelSize = new System.Drawing.Size(52, 20);
            this._Node.LabelText = "node";
            this._Node.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Node.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Node.LabelToolTip = "";
            this._Node.LabelVisible = true;
            this._Node.Location = new System.Drawing.Point(4, 1);
            this._Node.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._Node.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._Node.MenuButtonImage = null;
            this._Node.Name = "_Node";
            this._Node.PropertyName = null;
            this._Node.Size = new System.Drawing.Size(171, 20);
            this._Node.TabIndex = 17;
            this._Node.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Node.TextField = "";
            this._Node.TextfieldToolTip = "";
            this._Node.TFBackColor = System.Drawing.SystemColors.Window;
            this._Node.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._Node.TFReadOnly = false;
            this._Node.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(CallTracker.Model.CustomerContact);
            // 
            // _CauPing
            // 
            this._CauPing.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._CauPing.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._CauPing.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._CauPing.ControlHeight = 20;
            this._CauPing.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._CauPing.DataSource = null;
            this._CauPing.DefaultText = "";
            this._CauPing.Font = new System.Drawing.Font("Verdana", 7F);
            this._CauPing.HasContextMenu = false;
            this._CauPing.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._CauPing.LabelAutoSize = true;
            this._CauPing.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._CauPing.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._CauPing.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._CauPing.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._CauPing.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._CauPing.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._CauPing.LabelMargin = new System.Windows.Forms.Padding(0);
            this._CauPing.LabelOffset = new System.Drawing.Point(0, 0);
            this._CauPing.LabelPadding = new System.Windows.Forms.Padding(0);
            this._CauPing.LabelSize = new System.Drawing.Size(52, 23);
            this._CauPing.LabelText = "cau ping";
            this._CauPing.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._CauPing.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._CauPing.LabelToolTip = "";
            this._CauPing.LabelVisible = true;
            this._CauPing.Location = new System.Drawing.Point(4, 22);
            this._CauPing.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._CauPing.MenuButtonDock = System.Windows.Forms.DockStyle.Left;
            this._CauPing.MenuButtonImage = null;
            this._CauPing.Name = "_CauPing";
            this._CauPing.OverlapLabel = false;
            this._CauPing.PropertyName = "Service.CauPing";
            this._CauPing.Size = new System.Drawing.Size(171, 20);
            this._CauPing.TabIndex = 18;
            // 
            // _NitResults
            // 
            this._NitResults.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._NitResults.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._NitResults.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._NitResults.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._NitResults.ControlHeight = 93;
            this._NitResults.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.NitResults", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._NitResults.Font = new System.Drawing.Font("Verdana", 7F);
            this._NitResults.HasContextMenu = false;
            this._NitResults.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._NitResults.LabelAutoSize = false;
            this._NitResults.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._NitResults.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._NitResults.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._NitResults.LabelDock = System.Windows.Forms.DockStyle.Top;
            this._NitResults.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._NitResults.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._NitResults.LabelMargin = new System.Windows.Forms.Padding(0);
            this._NitResults.LabelOffset = new System.Drawing.Point(0, 0);
            this._NitResults.LabelPadding = new System.Windows.Forms.Padding(0);
            this._NitResults.LabelSize = new System.Drawing.Size(171, 17);
            this._NitResults.LabelText = "  nit results";
            this._NitResults.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._NitResults.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._NitResults.LabelToolTip = "";
            this._NitResults.LabelVisible = true;
            this._NitResults.Location = new System.Drawing.Point(4, 43);
            this._NitResults.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._NitResults.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._NitResults.MenuButtonImage = null;
            this._NitResults.Name = "_NitResults";
            this._NitResults.PropertyName = null;
            this._NitResults.Size = new System.Drawing.Size(171, 93);
            this._NitResults.TabIndex = 19;
            this._NitResults.TextField = "";
            // 
            // labelledBase2
            // 
            this.labelledBase2.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledBase2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(30)))));
            this.labelledBase2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelledBase2.ControlHeight = 12;
            this.labelledBase2.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledBase2.HasContextMenu = false;
            this.labelledBase2.LabelActiveColor = System.Drawing.Color.Firebrick;
            this.labelledBase2.LabelAutoSize = true;
            this.labelledBase2.LabelBorderColor = System.Drawing.Color.Empty;
            this.labelledBase2.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.labelledBase2.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.labelledBase2.LabelDock = System.Windows.Forms.DockStyle.None;
            this.labelledBase2.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this.labelledBase2.LabelInactiveColor = System.Drawing.Color.Empty;
            this.labelledBase2.LabelMargin = new System.Windows.Forms.Padding(0);
            this.labelledBase2.LabelOffset = new System.Drawing.Point(1, -2);
            this.labelledBase2.LabelPadding = new System.Windows.Forms.Padding(0);
            this.labelledBase2.LabelSize = new System.Drawing.Size(106, 22);
            this.labelledBase2.LabelText = "//SOFTACT DETAILS";
            this.labelledBase2.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelledBase2.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledBase2.LabelToolTip = "";
            this.labelledBase2.LabelVisible = true;
            this.labelledBase2.Location = new System.Drawing.Point(4, 137);
            this.labelledBase2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.labelledBase2.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this.labelledBase2.MenuButtonImage = null;
            this.labelledBase2.Name = "labelledBase2";
            this.labelledBase2.PropertyName = null;
            this.labelledBase2.Size = new System.Drawing.Size(171, 12);
            this.labelledBase2.TabIndex = 108;
            this.labelledBase2.TabStop = false;
            // 
            // _ESN
            // 
            this._ESN.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._ESN.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._ESN.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._ESN.ControlHeight = 20;
            this._ESN.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._ESN.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.ESN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._ESN.DefaultText = "";
            this._ESN.Font = new System.Drawing.Font("Verdana", 7F);
            this._ESN.HasContextMenu = false;
            this._ESN.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._ESN.LabelAutoSize = false;
            this._ESN.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._ESN.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._ESN.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._ESN.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._ESN.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._ESN.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._ESN.LabelMargin = new System.Windows.Forms.Padding(0);
            this._ESN.LabelOffset = new System.Drawing.Point(0, 0);
            this._ESN.LabelPadding = new System.Windows.Forms.Padding(0);
            this._ESN.LabelSize = new System.Drawing.Size(52, 20);
            this._ESN.LabelText = "esn";
            this._ESN.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._ESN.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._ESN.LabelToolTip = "";
            this._ESN.LabelVisible = true;
            this._ESN.Location = new System.Drawing.Point(4, 150);
            this._ESN.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._ESN.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._ESN.MenuButtonImage = null;
            this._ESN.Name = "_ESN";
            this._ESN.PropertyName = null;
            this._ESN.Size = new System.Drawing.Size(171, 20);
            this._ESN.TabIndex = 20;
            this._ESN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._ESN.TextField = "";
            this._ESN.TextfieldToolTip = "";
            this._ESN.TFBackColor = System.Drawing.SystemColors.Window;
            this._ESN.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._ESN.TFReadOnly = false;
            this._ESN.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _NBNPanel
            // 
            this._NBNPanel.Controls.Add(this._Bras);
            this._NBNPanel.Controls.Add(this._Sip);
            this._NBNPanel.Controls.Add(this._AVC);
            this._NBNPanel.Controls.Add(this._CSA);
            this._NBNPanel.Controls.Add(this._CVC);
            this._NBNPanel.Controls.Add(this._NNI);
            this._NBNPanel.Controls.Add(this._GSID);
            this._NBNPanel.Controls.Add(this._INC);
            this._NBNPanel.Controls.Add(this._APT);
            this._NBNPanel.Controls.Add(this._NTDSN);
            this._NBNPanel.Controls.Add(this._IPNBN);
            this._NBNPanel.Location = new System.Drawing.Point(558, 35);
            this._NBNPanel.Name = "_NBNPanel";
            this._NBNPanel.Padding = new System.Windows.Forms.Padding(4, 1, 4, 0);
            this._NBNPanel.Size = new System.Drawing.Size(180, 217);
            this._NBNPanel.TabIndex = 97;
            // 
            // _Bras
            // 
            this._Bras.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Bras.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._Bras.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._Bras.ControlHeight = 20;
            this._Bras.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._Bras.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.Bras", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Bras.DefaultText = "";
            this._Bras.Font = new System.Drawing.Font("Verdana", 7F);
            this._Bras.HasContextMenu = false;
            this._Bras.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._Bras.LabelAutoSize = false;
            this._Bras.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._Bras.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._Bras.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._Bras.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._Bras.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Bras.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._Bras.LabelMargin = new System.Windows.Forms.Padding(0);
            this._Bras.LabelOffset = new System.Drawing.Point(0, 0);
            this._Bras.LabelPadding = new System.Windows.Forms.Padding(0);
            this._Bras.LabelSize = new System.Drawing.Size(40, 20);
            this._Bras.LabelText = "online";
            this._Bras.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Bras.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Bras.LabelToolTip = "";
            this._Bras.LabelVisible = true;
            this._Bras.Location = new System.Drawing.Point(4, 1);
            this._Bras.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._Bras.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._Bras.MenuButtonImage = null;
            this._Bras.Name = "_Bras";
            this._Bras.PropertyName = null;
            this._Bras.Size = new System.Drawing.Size(102, 20);
            this._Bras.TabIndex = 21;
            this._Bras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Bras.TextField = "";
            this._Bras.TextfieldToolTip = "";
            this._Bras.TFBackColor = System.Drawing.SystemColors.Window;
            this._Bras.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._Bras.TFReadOnly = false;
            this._Bras.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _Sip
            // 
            this._Sip.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Sip.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._Sip.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._Sip.ControlHeight = 20;
            this._Sip.ControlMargin = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this._Sip.DataSource = null;
            this._Sip.DefaultText = "";
            this._Sip.Font = new System.Drawing.Font("Verdana", 7F);
            this._Sip.HasContextMenu = false;
            this._Sip.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._Sip.LabelAutoSize = true;
            this._Sip.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._Sip.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._Sip.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._Sip.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._Sip.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Sip.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._Sip.LabelMargin = new System.Windows.Forms.Padding(0);
            this._Sip.LabelOffset = new System.Drawing.Point(0, 0);
            this._Sip.LabelPadding = new System.Windows.Forms.Padding(0);
            this._Sip.LabelSize = new System.Drawing.Size(24, 23);
            this._Sip.LabelText = "sip";
            this._Sip.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Sip.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Sip.LabelToolTip = "";
            this._Sip.LabelVisible = true;
            this._Sip.Location = new System.Drawing.Point(108, 1);
            this._Sip.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this._Sip.MenuButtonDock = System.Windows.Forms.DockStyle.Left;
            this._Sip.MenuButtonImage = null;
            this._Sip.Name = "_Sip";
            this._Sip.OverlapLabel = false;
            this._Sip.PropertyName = "Service.Sip";
            this._Sip.Size = new System.Drawing.Size(67, 20);
            this._Sip.TabIndex = 22;
            // 
            // _AVC
            // 
            this._AVC.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._AVC.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._AVC.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._AVC.ControlHeight = 20;
            this._AVC.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._AVC.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.AVC", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._AVC.DefaultText = "";
            this._AVC.Font = new System.Drawing.Font("Verdana", 7F);
            this._AVC.HasContextMenu = false;
            this._AVC.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._AVC.LabelAutoSize = false;
            this._AVC.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._AVC.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._AVC.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._AVC.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._AVC.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._AVC.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._AVC.LabelMargin = new System.Windows.Forms.Padding(0);
            this._AVC.LabelOffset = new System.Drawing.Point(0, 0);
            this._AVC.LabelPadding = new System.Windows.Forms.Padding(0);
            this._AVC.LabelSize = new System.Drawing.Size(40, 20);
            this._AVC.LabelText = "avc";
            this._AVC.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._AVC.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._AVC.LabelToolTip = "";
            this._AVC.LabelVisible = true;
            this._AVC.Location = new System.Drawing.Point(4, 22);
            this._AVC.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._AVC.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._AVC.MenuButtonImage = null;
            this._AVC.Name = "_AVC";
            this._AVC.PropertyName = null;
            this._AVC.Size = new System.Drawing.Size(171, 20);
            this._AVC.TabIndex = 23;
            this._AVC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._AVC.TextField = "";
            this._AVC.TextfieldToolTip = "";
            this._AVC.TFBackColor = System.Drawing.SystemColors.Window;
            this._AVC.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._AVC.TFReadOnly = false;
            this._AVC.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _CSA
            // 
            this._CSA.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._CSA.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._CSA.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._CSA.ControlHeight = 20;
            this._CSA.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._CSA.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.CSA", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._CSA.DefaultText = "";
            this._CSA.Font = new System.Drawing.Font("Verdana", 7F);
            this._CSA.HasContextMenu = false;
            this._CSA.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._CSA.LabelAutoSize = false;
            this._CSA.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._CSA.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._CSA.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._CSA.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._CSA.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._CSA.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._CSA.LabelMargin = new System.Windows.Forms.Padding(0);
            this._CSA.LabelOffset = new System.Drawing.Point(0, 0);
            this._CSA.LabelPadding = new System.Windows.Forms.Padding(0);
            this._CSA.LabelSize = new System.Drawing.Size(40, 20);
            this._CSA.LabelText = "csa";
            this._CSA.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._CSA.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._CSA.LabelToolTip = "";
            this._CSA.LabelVisible = true;
            this._CSA.Location = new System.Drawing.Point(4, 43);
            this._CSA.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._CSA.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._CSA.MenuButtonImage = null;
            this._CSA.Name = "_CSA";
            this._CSA.PropertyName = null;
            this._CSA.Size = new System.Drawing.Size(171, 20);
            this._CSA.TabIndex = 24;
            this._CSA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._CSA.TextField = "";
            this._CSA.TextfieldToolTip = "";
            this._CSA.TFBackColor = System.Drawing.SystemColors.Window;
            this._CSA.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._CSA.TFReadOnly = false;
            this._CSA.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _CVC
            // 
            this._CVC.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._CVC.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._CVC.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._CVC.ControlHeight = 20;
            this._CVC.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._CVC.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.CVC", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._CVC.DefaultText = "";
            this._CVC.Font = new System.Drawing.Font("Verdana", 7F);
            this._CVC.HasContextMenu = false;
            this._CVC.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._CVC.LabelAutoSize = false;
            this._CVC.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._CVC.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._CVC.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._CVC.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._CVC.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._CVC.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._CVC.LabelMargin = new System.Windows.Forms.Padding(0);
            this._CVC.LabelOffset = new System.Drawing.Point(0, 0);
            this._CVC.LabelPadding = new System.Windows.Forms.Padding(0);
            this._CVC.LabelSize = new System.Drawing.Size(40, 20);
            this._CVC.LabelText = "cvc";
            this._CVC.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._CVC.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._CVC.LabelToolTip = "";
            this._CVC.LabelVisible = true;
            this._CVC.Location = new System.Drawing.Point(4, 64);
            this._CVC.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._CVC.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._CVC.MenuButtonImage = null;
            this._CVC.Name = "_CVC";
            this._CVC.PropertyName = null;
            this._CVC.Size = new System.Drawing.Size(171, 20);
            this._CVC.TabIndex = 25;
            this._CVC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._CVC.TextField = "";
            this._CVC.TextfieldToolTip = "";
            this._CVC.TFBackColor = System.Drawing.SystemColors.Window;
            this._CVC.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._CVC.TFReadOnly = false;
            this._CVC.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _NNI
            // 
            this._NNI.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._NNI.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._NNI.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._NNI.ControlHeight = 20;
            this._NNI.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._NNI.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.NNI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._NNI.DefaultText = "";
            this._NNI.Font = new System.Drawing.Font("Verdana", 7F);
            this._NNI.HasContextMenu = false;
            this._NNI.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._NNI.LabelAutoSize = false;
            this._NNI.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._NNI.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._NNI.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._NNI.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._NNI.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._NNI.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._NNI.LabelMargin = new System.Windows.Forms.Padding(0);
            this._NNI.LabelOffset = new System.Drawing.Point(0, 0);
            this._NNI.LabelPadding = new System.Windows.Forms.Padding(0);
            this._NNI.LabelSize = new System.Drawing.Size(40, 20);
            this._NNI.LabelText = "nni";
            this._NNI.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._NNI.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._NNI.LabelToolTip = "";
            this._NNI.LabelVisible = true;
            this._NNI.Location = new System.Drawing.Point(4, 85);
            this._NNI.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._NNI.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._NNI.MenuButtonImage = null;
            this._NNI.Name = "_NNI";
            this._NNI.PropertyName = null;
            this._NNI.Size = new System.Drawing.Size(171, 20);
            this._NNI.TabIndex = 26;
            this._NNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._NNI.TextField = "";
            this._NNI.TextfieldToolTip = "";
            this._NNI.TFBackColor = System.Drawing.SystemColors.Window;
            this._NNI.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._NNI.TFReadOnly = false;
            this._NNI.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _GSID
            // 
            this._GSID.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._GSID.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._GSID.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._GSID.ControlHeight = 20;
            this._GSID.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._GSID.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.GSID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._GSID.DefaultText = "";
            this._GSID.Font = new System.Drawing.Font("Verdana", 7F);
            this._GSID.HasContextMenu = false;
            this._GSID.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._GSID.LabelAutoSize = false;
            this._GSID.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._GSID.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._GSID.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._GSID.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._GSID.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._GSID.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._GSID.LabelMargin = new System.Windows.Forms.Padding(0);
            this._GSID.LabelOffset = new System.Drawing.Point(0, 0);
            this._GSID.LabelPadding = new System.Windows.Forms.Padding(0);
            this._GSID.LabelSize = new System.Drawing.Size(40, 20);
            this._GSID.LabelText = "gsid";
            this._GSID.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._GSID.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._GSID.LabelToolTip = "";
            this._GSID.LabelVisible = true;
            this._GSID.Location = new System.Drawing.Point(4, 106);
            this._GSID.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._GSID.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._GSID.MenuButtonImage = null;
            this._GSID.Name = "_GSID";
            this._GSID.PropertyName = null;
            this._GSID.Size = new System.Drawing.Size(171, 20);
            this._GSID.TabIndex = 27;
            this._GSID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._GSID.TextField = "";
            this._GSID.TextfieldToolTip = "";
            this._GSID.TFBackColor = System.Drawing.SystemColors.Window;
            this._GSID.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._GSID.TFReadOnly = false;
            this._GSID.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _INC
            // 
            this._INC.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._INC.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._INC.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._INC.ControlHeight = 20;
            this._INC.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._INC.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.INC", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._INC.DefaultText = "";
            this._INC.Font = new System.Drawing.Font("Verdana", 7F);
            this._INC.HasContextMenu = false;
            this._INC.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._INC.LabelAutoSize = false;
            this._INC.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._INC.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._INC.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._INC.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._INC.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._INC.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._INC.LabelMargin = new System.Windows.Forms.Padding(0);
            this._INC.LabelOffset = new System.Drawing.Point(0, 0);
            this._INC.LabelPadding = new System.Windows.Forms.Padding(0);
            this._INC.LabelSize = new System.Drawing.Size(40, 20);
            this._INC.LabelText = "inc";
            this._INC.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._INC.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._INC.LabelToolTip = "";
            this._INC.LabelVisible = true;
            this._INC.Location = new System.Drawing.Point(4, 127);
            this._INC.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._INC.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._INC.MenuButtonImage = null;
            this._INC.Name = "_INC";
            this._INC.PropertyName = null;
            this._INC.Size = new System.Drawing.Size(171, 20);
            this._INC.TabIndex = 28;
            this._INC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._INC.TextField = "";
            this._INC.TextfieldToolTip = "";
            this._INC.TFBackColor = System.Drawing.SystemColors.Window;
            this._INC.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._INC.TFReadOnly = false;
            this._INC.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _APT
            // 
            this._APT.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._APT.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._APT.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._APT.ControlHeight = 20;
            this._APT.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._APT.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.APT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._APT.DefaultText = "";
            this._APT.Font = new System.Drawing.Font("Verdana", 7F);
            this._APT.HasContextMenu = false;
            this._APT.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._APT.LabelAutoSize = false;
            this._APT.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._APT.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._APT.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._APT.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._APT.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._APT.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._APT.LabelMargin = new System.Windows.Forms.Padding(0);
            this._APT.LabelOffset = new System.Drawing.Point(0, 0);
            this._APT.LabelPadding = new System.Windows.Forms.Padding(0);
            this._APT.LabelSize = new System.Drawing.Size(40, 20);
            this._APT.LabelText = "apt";
            this._APT.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._APT.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._APT.LabelToolTip = "";
            this._APT.LabelVisible = true;
            this._APT.Location = new System.Drawing.Point(4, 148);
            this._APT.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._APT.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._APT.MenuButtonImage = null;
            this._APT.Name = "_APT";
            this._APT.PropertyName = null;
            this._APT.Size = new System.Drawing.Size(171, 20);
            this._APT.TabIndex = 29;
            this._APT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._APT.TextField = "";
            this._APT.TextfieldToolTip = "";
            this._APT.TFBackColor = System.Drawing.SystemColors.Window;
            this._APT.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._APT.TFReadOnly = false;
            this._APT.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _NTDSN
            // 
            this._NTDSN.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._NTDSN.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._NTDSN.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._NTDSN.ControlHeight = 20;
            this._NTDSN.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._NTDSN.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.NTDSN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._NTDSN.DefaultText = "";
            this._NTDSN.Font = new System.Drawing.Font("Verdana", 7F);
            this._NTDSN.HasContextMenu = false;
            this._NTDSN.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._NTDSN.LabelAutoSize = false;
            this._NTDSN.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._NTDSN.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._NTDSN.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._NTDSN.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._NTDSN.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._NTDSN.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._NTDSN.LabelMargin = new System.Windows.Forms.Padding(0);
            this._NTDSN.LabelOffset = new System.Drawing.Point(0, 0);
            this._NTDSN.LabelPadding = new System.Windows.Forms.Padding(0);
            this._NTDSN.LabelSize = new System.Drawing.Size(40, 20);
            this._NTDSN.LabelText = "ntd sn";
            this._NTDSN.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._NTDSN.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._NTDSN.LabelToolTip = "";
            this._NTDSN.LabelVisible = true;
            this._NTDSN.Location = new System.Drawing.Point(4, 169);
            this._NTDSN.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._NTDSN.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._NTDSN.MenuButtonImage = null;
            this._NTDSN.Name = "_NTDSN";
            this._NTDSN.PropertyName = null;
            this._NTDSN.Size = new System.Drawing.Size(171, 20);
            this._NTDSN.TabIndex = 30;
            this._NTDSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._NTDSN.TextField = "";
            this._NTDSN.TextfieldToolTip = "";
            this._NTDSN.TFBackColor = System.Drawing.SystemColors.Window;
            this._NTDSN.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._NTDSN.TFReadOnly = false;
            this._NTDSN.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _IPNBN
            // 
            this._IPNBN.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._IPNBN.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._IPNBN.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._IPNBN.ControlHeight = 20;
            this._IPNBN.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._IPNBN.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.ModemIp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._IPNBN.DefaultText = "";
            this._IPNBN.Font = new System.Drawing.Font("Verdana", 7F);
            this._IPNBN.HasContextMenu = false;
            this._IPNBN.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._IPNBN.LabelAutoSize = false;
            this._IPNBN.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._IPNBN.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._IPNBN.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._IPNBN.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._IPNBN.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._IPNBN.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._IPNBN.LabelMargin = new System.Windows.Forms.Padding(0);
            this._IPNBN.LabelOffset = new System.Drawing.Point(0, 0);
            this._IPNBN.LabelPadding = new System.Windows.Forms.Padding(0);
            this._IPNBN.LabelSize = new System.Drawing.Size(40, 20);
            this._IPNBN.LabelText = "ip";
            this._IPNBN.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._IPNBN.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._IPNBN.LabelToolTip = "";
            this._IPNBN.LabelVisible = true;
            this._IPNBN.Location = new System.Drawing.Point(4, 190);
            this._IPNBN.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._IPNBN.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._IPNBN.MenuButtonImage = null;
            this._IPNBN.Name = "_IPNBN";
            this._IPNBN.PropertyName = null;
            this._IPNBN.Size = new System.Drawing.Size(171, 20);
            this._IPNBN.TabIndex = 31;
            this._IPNBN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._IPNBN.TextField = "";
            this._IPNBN.TextfieldToolTip = "";
            this._IPNBN.TFBackColor = System.Drawing.SystemColors.Window;
            this._IPNBN.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._IPNBN.TFReadOnly = false;
            this._IPNBN.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _DTVPanel
            // 
            this._DTVPanel.Controls.Add(this._DTVNode);
            this._DTVPanel.Controls.Add(this._DTVMsg);
            this._DTVPanel.Controls.Add(this._DTVLights);
            this._DTVPanel.Controls.Add(this._STBHeading);
            this._DTVPanel.Controls.Add(this._STBSmartCard);
            this._DTVPanel.Controls.Add(this._STBLot);
            this._DTVPanel.Controls.Add(this._STBBox);
            this._DTVPanel.Location = new System.Drawing.Point(0, 35);
            this._DTVPanel.Name = "_DTVPanel";
            this._DTVPanel.Padding = new System.Windows.Forms.Padding(4, 1, 4, 0);
            this._DTVPanel.Size = new System.Drawing.Size(180, 217);
            this._DTVPanel.TabIndex = 77;
            this._DTVPanel.MouseEnter += new System.EventHandler(this._DTVPanel_MouseEnter);
            // 
            // _DTVNode
            // 
            this._DTVNode.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._DTVNode.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._DTVNode.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._DTVNode.ControlHeight = 20;
            this._DTVNode.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._DTVNode.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.Node", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._DTVNode.DefaultText = "";
            this._DTVNode.Font = new System.Drawing.Font("Verdana", 7F);
            this._DTVNode.HasContextMenu = false;
            this._DTVNode.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._DTVNode.LabelAutoSize = false;
            this._DTVNode.LabelBorderColor = System.Drawing.Color.DarkOliveGreen;
            this._DTVNode.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._DTVNode.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._DTVNode.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._DTVNode.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._DTVNode.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._DTVNode.LabelMargin = new System.Windows.Forms.Padding(0);
            this._DTVNode.LabelOffset = new System.Drawing.Point(0, 0);
            this._DTVNode.LabelPadding = new System.Windows.Forms.Padding(0);
            this._DTVNode.LabelSize = new System.Drawing.Size(44, 20);
            this._DTVNode.LabelText = "node";
            this._DTVNode.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._DTVNode.LabelTextColor = System.Drawing.SystemColors.Info;
            this._DTVNode.LabelToolTip = "";
            this._DTVNode.LabelVisible = true;
            this._DTVNode.Location = new System.Drawing.Point(4, 1);
            this._DTVNode.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._DTVNode.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._DTVNode.MenuButtonImage = null;
            this._DTVNode.Name = "_DTVNode";
            this._DTVNode.PropertyName = null;
            this._DTVNode.Size = new System.Drawing.Size(171, 20);
            this._DTVNode.TabIndex = 1;
            this._DTVNode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._DTVNode.TextField = "";
            this._DTVNode.TextfieldToolTip = "";
            this._DTVNode.TFBackColor = System.Drawing.SystemColors.Window;
            this._DTVNode.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._DTVNode.TFReadOnly = false;
            this._DTVNode.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _DTVMsg
            // 
            this._DTVMsg.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._DTVMsg.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._DTVMsg.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._DTVMsg.ControlHeight = 20;
            this._DTVMsg.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._DTVMsg.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.DTVMsg", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._DTVMsg.DefaultText = "";
            this._DTVMsg.Font = new System.Drawing.Font("Verdana", 7F);
            this._DTVMsg.HasContextMenu = false;
            this._DTVMsg.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._DTVMsg.LabelAutoSize = false;
            this._DTVMsg.LabelBorderColor = System.Drawing.Color.DarkOliveGreen;
            this._DTVMsg.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._DTVMsg.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._DTVMsg.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._DTVMsg.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._DTVMsg.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._DTVMsg.LabelMargin = new System.Windows.Forms.Padding(0);
            this._DTVMsg.LabelOffset = new System.Drawing.Point(0, 0);
            this._DTVMsg.LabelPadding = new System.Windows.Forms.Padding(0);
            this._DTVMsg.LabelSize = new System.Drawing.Size(44, 20);
            this._DTVMsg.LabelText = "msg";
            this._DTVMsg.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._DTVMsg.LabelTextColor = System.Drawing.SystemColors.Info;
            this._DTVMsg.LabelToolTip = "";
            this._DTVMsg.LabelVisible = true;
            this._DTVMsg.Location = new System.Drawing.Point(4, 22);
            this._DTVMsg.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._DTVMsg.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._DTVMsg.MenuButtonImage = null;
            this._DTVMsg.Name = "_DTVMsg";
            this._DTVMsg.PropertyName = null;
            this._DTVMsg.Size = new System.Drawing.Size(171, 20);
            this._DTVMsg.TabIndex = 2;
            this._DTVMsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._DTVMsg.TextField = "";
            this._DTVMsg.TextfieldToolTip = "";
            this._DTVMsg.TFBackColor = System.Drawing.SystemColors.Window;
            this._DTVMsg.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._DTVMsg.TFReadOnly = false;
            this._DTVMsg.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _DTVLights
            // 
            this._DTVLights.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._DTVLights.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._DTVLights.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._DTVLights.ControlHeight = 20;
            this._DTVLights.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._DTVLights.DataSource = null;
            this._DTVLights.DefaultText = "";
            this._DTVLights.Font = new System.Drawing.Font("Verdana", 7F);
            this._DTVLights.HasContextMenu = false;
            this._DTVLights.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._DTVLights.LabelAutoSize = false;
            this._DTVLights.LabelBorderColor = System.Drawing.Color.DarkOliveGreen;
            this._DTVLights.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._DTVLights.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._DTVLights.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._DTVLights.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._DTVLights.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._DTVLights.LabelMargin = new System.Windows.Forms.Padding(0);
            this._DTVLights.LabelOffset = new System.Drawing.Point(0, 0);
            this._DTVLights.LabelPadding = new System.Windows.Forms.Padding(0);
            this._DTVLights.LabelSize = new System.Drawing.Size(44, 20);
            this._DTVLights.LabelText = "lights";
            this._DTVLights.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._DTVLights.LabelTextColor = System.Drawing.SystemColors.Info;
            this._DTVLights.LabelToolTip = "";
            this._DTVLights.LabelVisible = true;
            this._DTVLights.Location = new System.Drawing.Point(4, 43);
            this._DTVLights.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._DTVLights.MenuButtonDock = System.Windows.Forms.DockStyle.Left;
            this._DTVLights.MenuButtonImage = null;
            this._DTVLights.Name = "_DTVLights";
            this._DTVLights.OverlapLabel = false;
            this._DTVLights.PropertyName = "Service.DTVLights";
            this._DTVLights.Size = new System.Drawing.Size(171, 20);
            this._DTVLights.TabIndex = 3;
            // 
            // _STBHeading
            // 
            this._STBHeading.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._STBHeading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(30)))));
            this._STBHeading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._STBHeading.ControlHeight = 12;
            this._STBHeading.Font = new System.Drawing.Font("Verdana", 7F);
            this._STBHeading.HasContextMenu = false;
            this._STBHeading.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._STBHeading.LabelAutoSize = true;
            this._STBHeading.LabelBorderColor = System.Drawing.Color.Empty;
            this._STBHeading.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._STBHeading.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._STBHeading.LabelDock = System.Windows.Forms.DockStyle.None;
            this._STBHeading.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this._STBHeading.LabelInactiveColor = System.Drawing.Color.Empty;
            this._STBHeading.LabelMargin = new System.Windows.Forms.Padding(0);
            this._STBHeading.LabelOffset = new System.Drawing.Point(1, -2);
            this._STBHeading.LabelPadding = new System.Windows.Forms.Padding(0);
            this._STBHeading.LabelSize = new System.Drawing.Size(40, 22);
            this._STBHeading.LabelText = "//STB";
            this._STBHeading.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._STBHeading.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._STBHeading.LabelToolTip = "";
            this._STBHeading.LabelVisible = true;
            this._STBHeading.Location = new System.Drawing.Point(4, 64);
            this._STBHeading.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._STBHeading.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._STBHeading.MenuButtonImage = null;
            this._STBHeading.Name = "_STBHeading";
            this._STBHeading.PropertyName = null;
            this._STBHeading.Size = new System.Drawing.Size(171, 12);
            this._STBHeading.TabIndex = 94;
            this._STBHeading.TabStop = false;
            // 
            // _STBSmartCard
            // 
            this._STBSmartCard.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._STBSmartCard.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._STBSmartCard.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._STBSmartCard.ControlHeight = 20;
            this._STBSmartCard.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._STBSmartCard.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.DTVSmartCard", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._STBSmartCard.DefaultText = "";
            this._STBSmartCard.Font = new System.Drawing.Font("Verdana", 7F);
            this._STBSmartCard.HasContextMenu = false;
            this._STBSmartCard.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._STBSmartCard.LabelAutoSize = false;
            this._STBSmartCard.LabelBorderColor = System.Drawing.Color.DarkOliveGreen;
            this._STBSmartCard.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._STBSmartCard.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._STBSmartCard.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._STBSmartCard.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._STBSmartCard.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._STBSmartCard.LabelMargin = new System.Windows.Forms.Padding(0);
            this._STBSmartCard.LabelOffset = new System.Drawing.Point(0, 0);
            this._STBSmartCard.LabelPadding = new System.Windows.Forms.Padding(0);
            this._STBSmartCard.LabelSize = new System.Drawing.Size(50, 20);
            this._STBSmartCard.LabelText = "smartcard";
            this._STBSmartCard.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._STBSmartCard.LabelTextColor = System.Drawing.SystemColors.Info;
            this._STBSmartCard.LabelToolTip = "";
            this._STBSmartCard.LabelVisible = true;
            this._STBSmartCard.Location = new System.Drawing.Point(4, 77);
            this._STBSmartCard.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._STBSmartCard.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._STBSmartCard.MenuButtonImage = null;
            this._STBSmartCard.Name = "_STBSmartCard";
            this._STBSmartCard.PropertyName = null;
            this._STBSmartCard.Size = new System.Drawing.Size(171, 20);
            this._STBSmartCard.TabIndex = 4;
            this._STBSmartCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._STBSmartCard.TextField = "";
            this._STBSmartCard.TextfieldToolTip = "";
            this._STBSmartCard.TFBackColor = System.Drawing.SystemColors.Window;
            this._STBSmartCard.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._STBSmartCard.TFReadOnly = false;
            this._STBSmartCard.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _STBLot
            // 
            this._STBLot.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._STBLot.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._STBLot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._STBLot.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._STBLot.ControlHeight = 32;
            this._STBLot.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.DTVLot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._STBLot.DefaultText = "";
            this._STBLot.Font = new System.Drawing.Font("Verdana", 7F);
            this._STBLot.HasContextMenu = false;
            this._STBLot.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._STBLot.LabelAutoSize = true;
            this._STBLot.LabelBorderColor = System.Drawing.Color.DarkOliveGreen;
            this._STBLot.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._STBLot.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._STBLot.LabelDock = System.Windows.Forms.DockStyle.None;
            this._STBLot.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._STBLot.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._STBLot.LabelMargin = new System.Windows.Forms.Padding(0);
            this._STBLot.LabelOffset = new System.Drawing.Point(1, -2);
            this._STBLot.LabelPadding = new System.Windows.Forms.Padding(0);
            this._STBLot.LabelSize = new System.Drawing.Size(22, 23);
            this._STBLot.LabelText = "lot";
            this._STBLot.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._STBLot.LabelTextColor = System.Drawing.SystemColors.Info;
            this._STBLot.LabelToolTip = "";
            this._STBLot.LabelVisible = true;
            this._STBLot.Location = new System.Drawing.Point(4, 98);
            this._STBLot.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._STBLot.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._STBLot.MenuButtonImage = null;
            this._STBLot.Name = "_STBLot";
            this._STBLot.PropertyName = null;
            this._STBLot.Size = new System.Drawing.Size(51, 32);
            this._STBLot.TabIndex = 5;
            this._STBLot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._STBLot.TextField = "";
            this._STBLot.TextFieldBackColour = System.Drawing.SystemColors.Window;
            // 
            // _STBBox
            // 
            this._STBBox.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._STBBox.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._STBBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._STBBox.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._STBBox.ControlHeight = 32;
            this._STBBox.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.DTVBox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._STBBox.DefaultText = "";
            this._STBBox.Font = new System.Drawing.Font("Verdana", 7F);
            this._STBBox.HasContextMenu = false;
            this._STBBox.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._STBBox.LabelAutoSize = true;
            this._STBBox.LabelBorderColor = System.Drawing.Color.DarkOliveGreen;
            this._STBBox.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._STBBox.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._STBBox.LabelDock = System.Windows.Forms.DockStyle.None;
            this._STBBox.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._STBBox.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._STBBox.LabelMargin = new System.Windows.Forms.Padding(0);
            this._STBBox.LabelOffset = new System.Drawing.Point(1, -2);
            this._STBBox.LabelPadding = new System.Windows.Forms.Padding(0);
            this._STBBox.LabelSize = new System.Drawing.Size(27, 23);
            this._STBBox.LabelText = "box";
            this._STBBox.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._STBBox.LabelTextColor = System.Drawing.SystemColors.Info;
            this._STBBox.LabelToolTip = "";
            this._STBBox.LabelVisible = true;
            this._STBBox.Location = new System.Drawing.Point(57, 98);
            this._STBBox.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this._STBBox.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._STBBox.MenuButtonImage = null;
            this._STBBox.Name = "_STBBox";
            this._STBBox.PropertyName = null;
            this._STBBox.Size = new System.Drawing.Size(118, 32);
            this._STBBox.TabIndex = 6;
            this._STBBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._STBBox.TextField = "";
            this._STBBox.TextFieldBackColour = System.Drawing.SystemColors.Window;
            // 
            // _MTVPanel
            // 
            this._MTVPanel.Controls.Add(this._MTVHeading);
            this._MTVPanel.Controls.Add(this._MTVMac);
            this._MTVPanel.Controls.Add(this._MTVSN);
            this._MTVPanel.Location = new System.Drawing.Point(744, 35);
            this._MTVPanel.Name = "_MTVPanel";
            this._MTVPanel.Padding = new System.Windows.Forms.Padding(4, 1, 4, 0);
            this._MTVPanel.Size = new System.Drawing.Size(180, 217);
            this._MTVPanel.TabIndex = 100;
            // 
            // _MTVHeading
            // 
            this._MTVHeading.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._MTVHeading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(30)))));
            this._MTVHeading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._MTVHeading.ControlHeight = 12;
            this._MTVHeading.Font = new System.Drawing.Font("Verdana", 7F);
            this._MTVHeading.HasContextMenu = false;
            this._MTVHeading.LabelActiveColor = System.Drawing.Color.Empty;
            this._MTVHeading.LabelAutoSize = true;
            this._MTVHeading.LabelBorderColor = System.Drawing.Color.Empty;
            this._MTVHeading.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._MTVHeading.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._MTVHeading.LabelDock = System.Windows.Forms.DockStyle.None;
            this._MTVHeading.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this._MTVHeading.LabelInactiveColor = System.Drawing.Color.Empty;
            this._MTVHeading.LabelMargin = new System.Windows.Forms.Padding(0);
            this._MTVHeading.LabelOffset = new System.Drawing.Point(1, -2);
            this._MTVHeading.LabelPadding = new System.Windows.Forms.Padding(0);
            this._MTVHeading.LabelSize = new System.Drawing.Size(40, 22);
            this._MTVHeading.LabelText = "//STB";
            this._MTVHeading.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._MTVHeading.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._MTVHeading.LabelToolTip = "";
            this._MTVHeading.LabelVisible = true;
            this._MTVHeading.Location = new System.Drawing.Point(4, 1);
            this._MTVHeading.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._MTVHeading.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._MTVHeading.MenuButtonImage = null;
            this._MTVHeading.Name = "_MTVHeading";
            this._MTVHeading.PropertyName = null;
            this._MTVHeading.Size = new System.Drawing.Size(171, 12);
            this._MTVHeading.TabIndex = 95;
            this._MTVHeading.TabStop = false;
            // 
            // _MTVMac
            // 
            this._MTVMac.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._MTVMac.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._MTVMac.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._MTVMac.ControlHeight = 20;
            this._MTVMac.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._MTVMac.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.MeTVMac", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._MTVMac.DefaultText = "";
            this._MTVMac.Font = new System.Drawing.Font("Verdana", 7F);
            this._MTVMac.HasContextMenu = false;
            this._MTVMac.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._MTVMac.LabelAutoSize = false;
            this._MTVMac.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._MTVMac.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._MTVMac.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._MTVMac.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._MTVMac.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._MTVMac.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._MTVMac.LabelMargin = new System.Windows.Forms.Padding(0);
            this._MTVMac.LabelOffset = new System.Drawing.Point(0, 0);
            this._MTVMac.LabelPadding = new System.Windows.Forms.Padding(0);
            this._MTVMac.LabelSize = new System.Drawing.Size(44, 20);
            this._MTVMac.LabelText = "mac";
            this._MTVMac.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._MTVMac.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._MTVMac.LabelToolTip = "";
            this._MTVMac.LabelVisible = true;
            this._MTVMac.Location = new System.Drawing.Point(4, 14);
            this._MTVMac.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._MTVMac.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._MTVMac.MenuButtonImage = null;
            this._MTVMac.Name = "_MTVMac";
            this._MTVMac.PropertyName = null;
            this._MTVMac.Size = new System.Drawing.Size(171, 20);
            this._MTVMac.TabIndex = 32;
            this._MTVMac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._MTVMac.TextField = "";
            this._MTVMac.TextfieldToolTip = "";
            this._MTVMac.TFBackColor = System.Drawing.SystemColors.Window;
            this._MTVMac.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._MTVMac.TFReadOnly = false;
            this._MTVMac.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _MTVSN
            // 
            this._MTVSN.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._MTVSN.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._MTVSN.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._MTVSN.ControlHeight = 20;
            this._MTVSN.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._MTVSN.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.MeTVSN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._MTVSN.DefaultText = "";
            this._MTVSN.Font = new System.Drawing.Font("Verdana", 7F);
            this._MTVSN.HasContextMenu = false;
            this._MTVSN.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._MTVSN.LabelAutoSize = false;
            this._MTVSN.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._MTVSN.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._MTVSN.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._MTVSN.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._MTVSN.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._MTVSN.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._MTVSN.LabelMargin = new System.Windows.Forms.Padding(0);
            this._MTVSN.LabelOffset = new System.Drawing.Point(0, 0);
            this._MTVSN.LabelPadding = new System.Windows.Forms.Padding(0);
            this._MTVSN.LabelSize = new System.Drawing.Size(44, 20);
            this._MTVSN.LabelText = "serial";
            this._MTVSN.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._MTVSN.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._MTVSN.LabelToolTip = "";
            this._MTVSN.LabelVisible = true;
            this._MTVSN.Location = new System.Drawing.Point(4, 35);
            this._MTVSN.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._MTVSN.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._MTVSN.MenuButtonImage = null;
            this._MTVSN.Name = "_MTVSN";
            this._MTVSN.PropertyName = null;
            this._MTVSN.Size = new System.Drawing.Size(171, 20);
            this._MTVSN.TabIndex = 33;
            this._MTVSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._MTVSN.TextField = "";
            this._MTVSN.TextfieldToolTip = "";
            this._MTVSN.TFBackColor = System.Drawing.SystemColors.Window;
            this._MTVSN.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._MTVSN.TFReadOnly = false;
            this._MTVSN.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _ONCPanel
            // 
            this._ONCPanel.Controls.Add(this._ModemStatus);
            this._ONCPanel.Controls.Add(this._ModemRF);
            this._ONCPanel.Controls.Add(this._ONCNode);
            this._ONCPanel.Controls.Add(this._SpeedTestHeading);
            this._ONCPanel.Controls.Add(this._SpeedTestDown);
            this._ONCPanel.Controls.Add(this._SpeedTestUp);
            this._ONCPanel.Controls.Add(this._ModemDetailsHeading);
            this._ONCPanel.Controls.Add(this._ModemCMMac);
            this._ONCPanel.Controls.Add(this._ModemMTAMac);
            this._ONCPanel.Controls.Add(this._ModemSN);
            this._ONCPanel.Controls.Add(this.labelledTextBoxLong1);
            this._ONCPanel.Controls.Add(this.labelledBase1);
            this._ONCPanel.Controls.Add(this._AddressId);
            this._ONCPanel.Location = new System.Drawing.Point(186, 35);
            this._ONCPanel.Name = "_ONCPanel";
            this._ONCPanel.Padding = new System.Windows.Forms.Padding(4, 1, 4, 0);
            this._ONCPanel.Size = new System.Drawing.Size(180, 217);
            this._ONCPanel.TabIndex = 100;
            // 
            // _ModemStatus
            // 
            this._ModemStatus.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._ModemStatus.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._ModemStatus.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._ModemStatus.ControlHeight = 20;
            this._ModemStatus.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._ModemStatus.DataSource = null;
            this._ModemStatus.DefaultText = "";
            this._ModemStatus.Font = new System.Drawing.Font("Verdana", 7F);
            this._ModemStatus.HasContextMenu = false;
            this._ModemStatus.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._ModemStatus.LabelAutoSize = false;
            this._ModemStatus.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._ModemStatus.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._ModemStatus.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._ModemStatus.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._ModemStatus.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._ModemStatus.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._ModemStatus.LabelMargin = new System.Windows.Forms.Padding(0);
            this._ModemStatus.LabelOffset = new System.Drawing.Point(0, 0);
            this._ModemStatus.LabelPadding = new System.Windows.Forms.Padding(0);
            this._ModemStatus.LabelSize = new System.Drawing.Size(44, 20);
            this._ModemStatus.LabelText = "status";
            this._ModemStatus.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._ModemStatus.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._ModemStatus.LabelToolTip = "";
            this._ModemStatus.LabelVisible = true;
            this._ModemStatus.Location = new System.Drawing.Point(4, 1);
            this._ModemStatus.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._ModemStatus.MenuButtonDock = System.Windows.Forms.DockStyle.Left;
            this._ModemStatus.MenuButtonImage = null;
            this._ModemStatus.Name = "_ModemStatus";
            this._ModemStatus.PropertyName = "Service.ModemStatus";
            this._ModemStatus.Size = new System.Drawing.Size(104, 20);
            this._ModemStatus.TabIndex = 10;
            // 
            // _ModemRF
            // 
            this._ModemRF.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._ModemRF.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._ModemRF.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._ModemRF.ControlHeight = 20;
            this._ModemRF.ControlMargin = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this._ModemRF.DataSource = null;
            this._ModemRF.DefaultText = "";
            this._ModemRF.Font = new System.Drawing.Font("Verdana", 7F);
            this._ModemRF.HasContextMenu = false;
            this._ModemRF.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._ModemRF.LabelAutoSize = true;
            this._ModemRF.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._ModemRF.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._ModemRF.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._ModemRF.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._ModemRF.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._ModemRF.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._ModemRF.LabelMargin = new System.Windows.Forms.Padding(0);
            this._ModemRF.LabelOffset = new System.Drawing.Point(0, 0);
            this._ModemRF.LabelPadding = new System.Windows.Forms.Padding(0);
            this._ModemRF.LabelSize = new System.Drawing.Size(16, 23);
            this._ModemRF.LabelText = "rf";
            this._ModemRF.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._ModemRF.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._ModemRF.LabelToolTip = "";
            this._ModemRF.LabelVisible = true;
            this._ModemRF.Location = new System.Drawing.Point(110, 1);
            this._ModemRF.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this._ModemRF.MenuButtonDock = System.Windows.Forms.DockStyle.Left;
            this._ModemRF.MenuButtonImage = null;
            this._ModemRF.Name = "_ModemRF";
            this._ModemRF.OverlapLabel = false;
            this._ModemRF.PropertyName = "Service.RFIssues";
            this._ModemRF.Size = new System.Drawing.Size(65, 20);
            this._ModemRF.TabIndex = 11;
            // 
            // _ONCNode
            // 
            this._ONCNode.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._ONCNode.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._ONCNode.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._ONCNode.ControlHeight = 20;
            this._ONCNode.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._ONCNode.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.Node", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._ONCNode.DefaultText = "";
            this._ONCNode.Font = new System.Drawing.Font("Verdana", 7F);
            this._ONCNode.HasContextMenu = false;
            this._ONCNode.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._ONCNode.LabelAutoSize = false;
            this._ONCNode.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._ONCNode.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._ONCNode.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._ONCNode.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._ONCNode.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._ONCNode.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._ONCNode.LabelMargin = new System.Windows.Forms.Padding(0);
            this._ONCNode.LabelOffset = new System.Drawing.Point(0, 0);
            this._ONCNode.LabelPadding = new System.Windows.Forms.Padding(0);
            this._ONCNode.LabelSize = new System.Drawing.Size(44, 20);
            this._ONCNode.LabelText = "node";
            this._ONCNode.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._ONCNode.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._ONCNode.LabelToolTip = "";
            this._ONCNode.LabelVisible = true;
            this._ONCNode.Location = new System.Drawing.Point(4, 22);
            this._ONCNode.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._ONCNode.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._ONCNode.MenuButtonImage = null;
            this._ONCNode.Name = "_ONCNode";
            this._ONCNode.PropertyName = null;
            this._ONCNode.Size = new System.Drawing.Size(171, 20);
            this._ONCNode.TabIndex = 7;
            this._ONCNode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._ONCNode.TextField = "";
            this._ONCNode.TextfieldToolTip = "";
            this._ONCNode.TFBackColor = System.Drawing.SystemColors.Window;
            this._ONCNode.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._ONCNode.TFReadOnly = false;
            this._ONCNode.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _SpeedTestHeading
            // 
            this._SpeedTestHeading.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._SpeedTestHeading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(30)))));
            this._SpeedTestHeading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._SpeedTestHeading.ControlHeight = 12;
            this._SpeedTestHeading.Font = new System.Drawing.Font("Verdana", 7F);
            this._SpeedTestHeading.HasContextMenu = false;
            this._SpeedTestHeading.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._SpeedTestHeading.LabelAutoSize = true;
            this._SpeedTestHeading.LabelBorderColor = System.Drawing.Color.Empty;
            this._SpeedTestHeading.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._SpeedTestHeading.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._SpeedTestHeading.LabelDock = System.Windows.Forms.DockStyle.None;
            this._SpeedTestHeading.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this._SpeedTestHeading.LabelInactiveColor = System.Drawing.Color.Empty;
            this._SpeedTestHeading.LabelMargin = new System.Windows.Forms.Padding(0);
            this._SpeedTestHeading.LabelOffset = new System.Drawing.Point(1, -2);
            this._SpeedTestHeading.LabelPadding = new System.Windows.Forms.Padding(0);
            this._SpeedTestHeading.LabelSize = new System.Drawing.Size(161, 22);
            this._SpeedTestHeading.LabelText = "//SPEED TEST RESULTS(MBPS)";
            this._SpeedTestHeading.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._SpeedTestHeading.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._SpeedTestHeading.LabelToolTip = "";
            this._SpeedTestHeading.LabelVisible = true;
            this._SpeedTestHeading.Location = new System.Drawing.Point(4, 43);
            this._SpeedTestHeading.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._SpeedTestHeading.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._SpeedTestHeading.MenuButtonImage = null;
            this._SpeedTestHeading.Name = "_SpeedTestHeading";
            this._SpeedTestHeading.PropertyName = null;
            this._SpeedTestHeading.Size = new System.Drawing.Size(171, 12);
            this._SpeedTestHeading.TabIndex = 105;
            this._SpeedTestHeading.TabStop = false;
            // 
            // _SpeedTestDown
            // 
            this._SpeedTestDown.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._SpeedTestDown.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._SpeedTestDown.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._SpeedTestDown.ControlHeight = 20;
            this._SpeedTestDown.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._SpeedTestDown.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.DownloadSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._SpeedTestDown.DefaultText = "";
            this._SpeedTestDown.Font = new System.Drawing.Font("Verdana", 7F);
            this._SpeedTestDown.HasContextMenu = false;
            this._SpeedTestDown.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._SpeedTestDown.LabelAutoSize = false;
            this._SpeedTestDown.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._SpeedTestDown.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._SpeedTestDown.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._SpeedTestDown.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._SpeedTestDown.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._SpeedTestDown.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._SpeedTestDown.LabelMargin = new System.Windows.Forms.Padding(0);
            this._SpeedTestDown.LabelOffset = new System.Drawing.Point(0, 0);
            this._SpeedTestDown.LabelPadding = new System.Windows.Forms.Padding(0);
            this._SpeedTestDown.LabelSize = new System.Drawing.Size(44, 20);
            this._SpeedTestDown.LabelText = "down";
            this._SpeedTestDown.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._SpeedTestDown.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._SpeedTestDown.LabelToolTip = "";
            this._SpeedTestDown.LabelVisible = true;
            this._SpeedTestDown.Location = new System.Drawing.Point(4, 56);
            this._SpeedTestDown.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._SpeedTestDown.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._SpeedTestDown.MenuButtonImage = null;
            this._SpeedTestDown.Name = "_SpeedTestDown";
            this._SpeedTestDown.PropertyName = null;
            this._SpeedTestDown.Size = new System.Drawing.Size(85, 20);
            this._SpeedTestDown.TabIndex = 8;
            this._SpeedTestDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._SpeedTestDown.TextField = "";
            this._SpeedTestDown.TextfieldToolTip = "";
            this._SpeedTestDown.TFBackColor = System.Drawing.SystemColors.Window;
            this._SpeedTestDown.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._SpeedTestDown.TFReadOnly = false;
            this._SpeedTestDown.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _SpeedTestUp
            // 
            this._SpeedTestUp.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._SpeedTestUp.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._SpeedTestUp.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._SpeedTestUp.ControlHeight = 20;
            this._SpeedTestUp.ControlMargin = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this._SpeedTestUp.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.UploadSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._SpeedTestUp.DefaultText = "";
            this._SpeedTestUp.Font = new System.Drawing.Font("Verdana", 7F);
            this._SpeedTestUp.HasContextMenu = false;
            this._SpeedTestUp.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._SpeedTestUp.LabelAutoSize = false;
            this._SpeedTestUp.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._SpeedTestUp.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._SpeedTestUp.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._SpeedTestUp.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._SpeedTestUp.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._SpeedTestUp.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._SpeedTestUp.LabelMargin = new System.Windows.Forms.Padding(0);
            this._SpeedTestUp.LabelOffset = new System.Drawing.Point(0, 0);
            this._SpeedTestUp.LabelPadding = new System.Windows.Forms.Padding(0);
            this._SpeedTestUp.LabelSize = new System.Drawing.Size(44, 20);
            this._SpeedTestUp.LabelText = "up";
            this._SpeedTestUp.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._SpeedTestUp.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._SpeedTestUp.LabelToolTip = "";
            this._SpeedTestUp.LabelVisible = true;
            this._SpeedTestUp.Location = new System.Drawing.Point(91, 56);
            this._SpeedTestUp.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this._SpeedTestUp.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._SpeedTestUp.MenuButtonImage = null;
            this._SpeedTestUp.Name = "_SpeedTestUp";
            this._SpeedTestUp.PropertyName = null;
            this._SpeedTestUp.Size = new System.Drawing.Size(84, 20);
            this._SpeedTestUp.TabIndex = 9;
            this._SpeedTestUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._SpeedTestUp.TextField = "";
            this._SpeedTestUp.TextfieldToolTip = "";
            this._SpeedTestUp.TFBackColor = System.Drawing.SystemColors.Window;
            this._SpeedTestUp.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._SpeedTestUp.TFReadOnly = false;
            this._SpeedTestUp.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _ModemDetailsHeading
            // 
            this._ModemDetailsHeading.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._ModemDetailsHeading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(30)))));
            this._ModemDetailsHeading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._ModemDetailsHeading.ControlHeight = 12;
            this._ModemDetailsHeading.Font = new System.Drawing.Font("Verdana", 7F);
            this._ModemDetailsHeading.HasContextMenu = false;
            this._ModemDetailsHeading.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._ModemDetailsHeading.LabelAutoSize = true;
            this._ModemDetailsHeading.LabelBorderColor = System.Drawing.Color.Empty;
            this._ModemDetailsHeading.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._ModemDetailsHeading.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._ModemDetailsHeading.LabelDock = System.Windows.Forms.DockStyle.None;
            this._ModemDetailsHeading.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this._ModemDetailsHeading.LabelInactiveColor = System.Drawing.Color.Empty;
            this._ModemDetailsHeading.LabelMargin = new System.Windows.Forms.Padding(0);
            this._ModemDetailsHeading.LabelOffset = new System.Drawing.Point(1, -2);
            this._ModemDetailsHeading.LabelPadding = new System.Windows.Forms.Padding(0);
            this._ModemDetailsHeading.LabelSize = new System.Drawing.Size(101, 22);
            this._ModemDetailsHeading.LabelText = "//MODEM DETAILS";
            this._ModemDetailsHeading.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._ModemDetailsHeading.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._ModemDetailsHeading.LabelToolTip = "";
            this._ModemDetailsHeading.LabelVisible = true;
            this._ModemDetailsHeading.Location = new System.Drawing.Point(4, 77);
            this._ModemDetailsHeading.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._ModemDetailsHeading.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._ModemDetailsHeading.MenuButtonImage = null;
            this._ModemDetailsHeading.Name = "_ModemDetailsHeading";
            this._ModemDetailsHeading.PropertyName = null;
            this._ModemDetailsHeading.Size = new System.Drawing.Size(171, 12);
            this._ModemDetailsHeading.TabIndex = 104;
            this._ModemDetailsHeading.TabStop = false;
            // 
            // _ModemCMMac
            // 
            this._ModemCMMac.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._ModemCMMac.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._ModemCMMac.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._ModemCMMac.ControlHeight = 20;
            this._ModemCMMac.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._ModemCMMac.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.CMMac", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._ModemCMMac.DefaultText = "";
            this._ModemCMMac.Font = new System.Drawing.Font("Verdana", 7F);
            this._ModemCMMac.HasContextMenu = false;
            this._ModemCMMac.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._ModemCMMac.LabelAutoSize = false;
            this._ModemCMMac.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._ModemCMMac.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._ModemCMMac.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._ModemCMMac.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._ModemCMMac.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._ModemCMMac.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._ModemCMMac.LabelMargin = new System.Windows.Forms.Padding(0);
            this._ModemCMMac.LabelOffset = new System.Drawing.Point(0, 0);
            this._ModemCMMac.LabelPadding = new System.Windows.Forms.Padding(0);
            this._ModemCMMac.LabelSize = new System.Drawing.Size(44, 20);
            this._ModemCMMac.LabelText = "cm mac";
            this._ModemCMMac.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._ModemCMMac.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._ModemCMMac.LabelToolTip = "";
            this._ModemCMMac.LabelVisible = true;
            this._ModemCMMac.Location = new System.Drawing.Point(4, 90);
            this._ModemCMMac.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._ModemCMMac.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._ModemCMMac.MenuButtonImage = null;
            this._ModemCMMac.Name = "_ModemCMMac";
            this._ModemCMMac.PropertyName = null;
            this._ModemCMMac.Size = new System.Drawing.Size(171, 20);
            this._ModemCMMac.TabIndex = 12;
            this._ModemCMMac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._ModemCMMac.TextField = "";
            this._ModemCMMac.TextfieldToolTip = "";
            this._ModemCMMac.TFBackColor = System.Drawing.SystemColors.Window;
            this._ModemCMMac.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._ModemCMMac.TFReadOnly = false;
            this._ModemCMMac.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _ModemMTAMac
            // 
            this._ModemMTAMac.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._ModemMTAMac.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._ModemMTAMac.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._ModemMTAMac.ControlHeight = 20;
            this._ModemMTAMac.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._ModemMTAMac.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.MTAMac", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._ModemMTAMac.DefaultText = "";
            this._ModemMTAMac.Font = new System.Drawing.Font("Verdana", 7F);
            this._ModemMTAMac.HasContextMenu = false;
            this._ModemMTAMac.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._ModemMTAMac.LabelAutoSize = false;
            this._ModemMTAMac.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._ModemMTAMac.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._ModemMTAMac.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._ModemMTAMac.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._ModemMTAMac.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._ModemMTAMac.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._ModemMTAMac.LabelMargin = new System.Windows.Forms.Padding(0);
            this._ModemMTAMac.LabelOffset = new System.Drawing.Point(0, 0);
            this._ModemMTAMac.LabelPadding = new System.Windows.Forms.Padding(0);
            this._ModemMTAMac.LabelSize = new System.Drawing.Size(44, 20);
            this._ModemMTAMac.LabelText = "mta mac";
            this._ModemMTAMac.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._ModemMTAMac.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._ModemMTAMac.LabelToolTip = "";
            this._ModemMTAMac.LabelVisible = true;
            this._ModemMTAMac.Location = new System.Drawing.Point(4, 111);
            this._ModemMTAMac.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._ModemMTAMac.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._ModemMTAMac.MenuButtonImage = null;
            this._ModemMTAMac.Name = "_ModemMTAMac";
            this._ModemMTAMac.PropertyName = null;
            this._ModemMTAMac.Size = new System.Drawing.Size(171, 20);
            this._ModemMTAMac.TabIndex = 13;
            this._ModemMTAMac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._ModemMTAMac.TextField = "";
            this._ModemMTAMac.TextfieldToolTip = "";
            this._ModemMTAMac.TFBackColor = System.Drawing.SystemColors.Window;
            this._ModemMTAMac.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._ModemMTAMac.TFReadOnly = false;
            this._ModemMTAMac.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _ModemSN
            // 
            this._ModemSN.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._ModemSN.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._ModemSN.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._ModemSN.ControlHeight = 20;
            this._ModemSN.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._ModemSN.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.ModemSN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._ModemSN.DefaultText = "";
            this._ModemSN.Font = new System.Drawing.Font("Verdana", 7F);
            this._ModemSN.HasContextMenu = false;
            this._ModemSN.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._ModemSN.LabelAutoSize = false;
            this._ModemSN.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._ModemSN.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._ModemSN.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._ModemSN.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._ModemSN.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._ModemSN.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._ModemSN.LabelMargin = new System.Windows.Forms.Padding(0);
            this._ModemSN.LabelOffset = new System.Drawing.Point(0, 0);
            this._ModemSN.LabelPadding = new System.Windows.Forms.Padding(0);
            this._ModemSN.LabelSize = new System.Drawing.Size(44, 20);
            this._ModemSN.LabelText = "serial";
            this._ModemSN.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._ModemSN.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._ModemSN.LabelToolTip = "";
            this._ModemSN.LabelVisible = true;
            this._ModemSN.Location = new System.Drawing.Point(4, 132);
            this._ModemSN.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._ModemSN.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._ModemSN.MenuButtonImage = null;
            this._ModemSN.Name = "_ModemSN";
            this._ModemSN.PropertyName = null;
            this._ModemSN.Size = new System.Drawing.Size(171, 20);
            this._ModemSN.TabIndex = 14;
            this._ModemSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._ModemSN.TextField = "";
            this._ModemSN.TextfieldToolTip = "";
            this._ModemSN.TFBackColor = System.Drawing.SystemColors.Window;
            this._ModemSN.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._ModemSN.TFReadOnly = false;
            this._ModemSN.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // labelledTextBoxLong1
            // 
            this.labelledTextBoxLong1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledTextBoxLong1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBoxLong1.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBoxLong1.ControlHeight = 20;
            this.labelledTextBoxLong1.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.labelledTextBoxLong1.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.ModemIp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelledTextBoxLong1.DefaultText = "";
            this.labelledTextBoxLong1.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledTextBoxLong1.HasContextMenu = false;
            this.labelledTextBoxLong1.LabelActiveColor = System.Drawing.Color.Firebrick;
            this.labelledTextBoxLong1.LabelAutoSize = false;
            this.labelledTextBoxLong1.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this.labelledTextBoxLong1.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.labelledTextBoxLong1.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.labelledTextBoxLong1.LabelDock = System.Windows.Forms.DockStyle.Left;
            this.labelledTextBoxLong1.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this.labelledTextBoxLong1.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this.labelledTextBoxLong1.LabelMargin = new System.Windows.Forms.Padding(0);
            this.labelledTextBoxLong1.LabelOffset = new System.Drawing.Point(0, 0);
            this.labelledTextBoxLong1.LabelPadding = new System.Windows.Forms.Padding(0);
            this.labelledTextBoxLong1.LabelSize = new System.Drawing.Size(44, 20);
            this.labelledTextBoxLong1.LabelText = "ip";
            this.labelledTextBoxLong1.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelledTextBoxLong1.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledTextBoxLong1.LabelToolTip = "";
            this.labelledTextBoxLong1.LabelVisible = true;
            this.labelledTextBoxLong1.Location = new System.Drawing.Point(4, 153);
            this.labelledTextBoxLong1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.labelledTextBoxLong1.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this.labelledTextBoxLong1.MenuButtonImage = null;
            this.labelledTextBoxLong1.Name = "labelledTextBoxLong1";
            this.labelledTextBoxLong1.PropertyName = null;
            this.labelledTextBoxLong1.Size = new System.Drawing.Size(171, 20);
            this.labelledTextBoxLong1.TabIndex = 15;
            this.labelledTextBoxLong1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.labelledTextBoxLong1.TextField = "";
            this.labelledTextBoxLong1.TextfieldToolTip = "";
            this.labelledTextBoxLong1.TFBackColor = System.Drawing.SystemColors.Window;
            this.labelledTextBoxLong1.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this.labelledTextBoxLong1.TFReadOnly = false;
            this.labelledTextBoxLong1.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // labelledBase1
            // 
            this.labelledBase1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.labelledBase1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(30)))));
            this.labelledBase1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelledBase1.ControlHeight = 12;
            this.labelledBase1.Font = new System.Drawing.Font("Verdana", 7F);
            this.labelledBase1.HasContextMenu = false;
            this.labelledBase1.LabelActiveColor = System.Drawing.Color.Firebrick;
            this.labelledBase1.LabelAutoSize = true;
            this.labelledBase1.LabelBorderColor = System.Drawing.Color.Empty;
            this.labelledBase1.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.labelledBase1.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.labelledBase1.LabelDock = System.Windows.Forms.DockStyle.None;
            this.labelledBase1.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this.labelledBase1.LabelInactiveColor = System.Drawing.Color.Empty;
            this.labelledBase1.LabelMargin = new System.Windows.Forms.Padding(0);
            this.labelledBase1.LabelOffset = new System.Drawing.Point(1, -2);
            this.labelledBase1.LabelPadding = new System.Windows.Forms.Padding(0);
            this.labelledBase1.LabelSize = new System.Drawing.Size(106, 22);
            this.labelledBase1.LabelText = "//SOFTACT DETAILS";
            this.labelledBase1.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelledBase1.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelledBase1.LabelToolTip = "";
            this.labelledBase1.LabelVisible = true;
            this.labelledBase1.Location = new System.Drawing.Point(4, 174);
            this.labelledBase1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.labelledBase1.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this.labelledBase1.MenuButtonImage = null;
            this.labelledBase1.Name = "labelledBase1";
            this.labelledBase1.PropertyName = null;
            this.labelledBase1.Size = new System.Drawing.Size(171, 12);
            this.labelledBase1.TabIndex = 107;
            this.labelledBase1.TabStop = false;
            // 
            // _AddressId
            // 
            this._AddressId.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._AddressId.BackColor = System.Drawing.Color.DarkOliveGreen;
            this._AddressId.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._AddressId.ControlHeight = 20;
            this._AddressId.ControlMargin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._AddressId.DataBindings.Add(new System.Windows.Forms.Binding("TextField", this.bindingSource1, "Service.AddressId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._AddressId.DefaultText = "";
            this._AddressId.Font = new System.Drawing.Font("Verdana", 7F);
            this._AddressId.HasContextMenu = false;
            this._AddressId.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._AddressId.LabelAutoSize = false;
            this._AddressId.LabelBorderColor = System.Drawing.Color.OliveDrab;
            this._AddressId.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._AddressId.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._AddressId.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._AddressId.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._AddressId.LabelInactiveColor = System.Drawing.Color.DarkOliveGreen;
            this._AddressId.LabelMargin = new System.Windows.Forms.Padding(0);
            this._AddressId.LabelOffset = new System.Drawing.Point(0, 0);
            this._AddressId.LabelPadding = new System.Windows.Forms.Padding(0);
            this._AddressId.LabelSize = new System.Drawing.Size(54, 20);
            this._AddressId.LabelText = "address id";
            this._AddressId.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._AddressId.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._AddressId.LabelToolTip = "";
            this._AddressId.LabelVisible = true;
            this._AddressId.Location = new System.Drawing.Point(4, 187);
            this._AddressId.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this._AddressId.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._AddressId.MenuButtonImage = null;
            this._AddressId.Name = "_AddressId";
            this._AddressId.PropertyName = null;
            this._AddressId.Size = new System.Drawing.Size(171, 20);
            this._AddressId.TabIndex = 16;
            this._AddressId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._AddressId.TextField = "";
            this._AddressId.TextfieldToolTip = "";
            this._AddressId.TFBackColor = System.Drawing.SystemColors.Window;
            this._AddressId.TFCursor = System.Windows.Forms.Cursors.IBeam;
            this._AddressId.TFReadOnly = false;
            this._AddressId.TFTextColor = System.Drawing.SystemColors.WindowText;
            // 
            // _EquipmentMenu
            // 
            this._EquipmentMenu.Font = new System.Drawing.Font("Verdana", 7F);
            this._EquipmentMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userGuideToolStripMenuItem,
            this.simulatorToolStripMenuItem});
            this._EquipmentMenu.Name = "_EquipmentContextMenu";
            this._EquipmentMenu.Size = new System.Drawing.Size(132, 48);
            // 
            // userGuideToolStripMenuItem
            // 
            this.userGuideToolStripMenuItem.Enabled = false;
            this.userGuideToolStripMenuItem.Name = "userGuideToolStripMenuItem";
            this.userGuideToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.userGuideToolStripMenuItem.Text = "User Guide";
            this.userGuideToolStripMenuItem.Click += new System.EventHandler(this.userGuideToolStripMenuItem_Click);
            // 
            // simulatorToolStripMenuItem
            // 
            this.simulatorToolStripMenuItem.Enabled = false;
            this.simulatorToolStripMenuItem.Name = "simulatorToolStripMenuItem";
            this.simulatorToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.simulatorToolStripMenuItem.Text = "Simulator";
            this.simulatorToolStripMenuItem.Click += new System.EventHandler(this.userGuideToolStripMenuItem_Click);
            // 
            // _NodeContextMenu
            // 
            this._NodeContextMenu.Font = new System.Drawing.Font("Verdana", 7F);
            this._NodeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem13});
            this._NodeContextMenu.Name = "_PRContextMenu";
            this._NodeContextMenu.Size = new System.Drawing.Size(98, 26);
            this._NodeContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._NodeContextMenu_ItemClicked);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Image = global::CallTracker.Properties.Resources.Search;
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(97, 22);
            this.toolStripMenuItem13.Text = "IFMS";
            // 
            // _PRIContextMenu
            // 
            this._PRIContextMenu.Font = new System.Drawing.Font("Verdana", 7F);
            this._PRIContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nSIToolStripMenuItem});
            this._PRIContextMenu.Name = "_PRIContextMenu";
            this._PRIContextMenu.Size = new System.Drawing.Size(90, 26);
            this._PRIContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._NBNContextMenu_ItemClicked);
            // 
            // nSIToolStripMenuItem
            // 
            this.nSIToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 7F);
            this.nSIToolStripMenuItem.Image = global::CallTracker.Properties.Resources.Search;
            this.nSIToolStripMenuItem.Name = "nSIToolStripMenuItem";
            this.nSIToolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.nSIToolStripMenuItem.Text = "NSI";
            // 
            // _AVCContextMenu
            // 
            this._AVCContextMenu.Font = new System.Drawing.Font("Verdana", 7F);
            this._AVCContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this._AVCContextMenu.Name = "_PRIContextMenu";
            this._AVCContextMenu.Size = new System.Drawing.Size(90, 26);
            this._AVCContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._NBNContextMenu_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Verdana", 7F);
            this.toolStripMenuItem1.Image = global::CallTracker.Properties.Resources.Search;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(89, 22);
            this.toolStripMenuItem1.Text = "NSI";
            // 
            // _CVCContextMenu
            // 
            this._CVCContextMenu.Font = new System.Drawing.Font("Verdana", 7F);
            this._CVCContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this._CVCContextMenu.Name = "_PRIContextMenu";
            this._CVCContextMenu.Size = new System.Drawing.Size(90, 26);
            this._CVCContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._NBNContextMenu_ItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Verdana", 7F);
            this.toolStripMenuItem2.Image = global::CallTracker.Properties.Resources.Search;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(89, 22);
            this.toolStripMenuItem2.Text = "NSI";
            // 
            // _Equipment
            // 
            this._Equipment.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._Equipment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(30)))));
            this._Equipment.BorderColour = System.Drawing.Color.DarkOliveGreen;
            this._Equipment.ControlHeight = 20;
            this._Equipment.DataSource = null;
            this._Equipment.DefaultText = "";
            this._Equipment.Font = new System.Drawing.Font("Verdana", 7F);
            this._Equipment.HasContextMenu = false;
            this._Equipment.LabelActiveColor = System.Drawing.Color.Firebrick;
            this._Equipment.LabelAutoSize = false;
            this._Equipment.LabelBorderColor = System.Drawing.Color.DarkOliveGreen;
            this._Equipment.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._Equipment.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._Equipment.LabelDock = System.Windows.Forms.DockStyle.Left;
            this._Equipment.LabelFont = new System.Drawing.Font("Gautami", 8.25F);
            this._Equipment.LabelInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(30)))));
            this._Equipment.LabelMargin = new System.Windows.Forms.Padding(0);
            this._Equipment.LabelOffset = new System.Drawing.Point(2, 0);
            this._Equipment.LabelPadding = new System.Windows.Forms.Padding(0);
            this._Equipment.LabelSize = new System.Drawing.Size(50, 20);
            this._Equipment.LabelText = "equipment";
            this._Equipment.LabelTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Equipment.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._Equipment.LabelToolTip = "";
            this._Equipment.LabelVisible = true;
            this._Equipment.Location = new System.Drawing.Point(4, 14);
            this._Equipment.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._Equipment.MenuButtonImage = null;
            this._Equipment.Name = "_Equipment";
            this._Equipment.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this._Equipment.PropertyName = "Service.Equipment";
            this._Equipment.Size = new System.Drawing.Size(171, 20);
            this._Equipment.TabIndex = 0;
            this._Equipment.SelectedIndexChanged += new System.EventHandler(this._Equipment_SelectedIndexChanged);
            // 
            // _ServiceHeading
            // 
            this._ServiceHeading.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this._ServiceHeading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(79)))), ((int)(((byte)(30)))));
            this._ServiceHeading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._ServiceHeading.ControlHeight = 12;
            this._ServiceHeading.Font = new System.Drawing.Font("Verdana", 7F);
            this._ServiceHeading.HasContextMenu = false;
            this._ServiceHeading.LabelActiveColor = System.Drawing.Color.Empty;
            this._ServiceHeading.LabelAutoSize = true;
            this._ServiceHeading.LabelBorderColor = System.Drawing.Color.Empty;
            this._ServiceHeading.LabelBorderOffset = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._ServiceHeading.LabelBorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this._ServiceHeading.LabelDock = System.Windows.Forms.DockStyle.None;
            this._ServiceHeading.LabelFont = new System.Drawing.Font("Gautami", 7F);
            this._ServiceHeading.LabelInactiveColor = System.Drawing.Color.Empty;
            this._ServiceHeading.LabelMargin = new System.Windows.Forms.Padding(0);
            this._ServiceHeading.LabelOffset = new System.Drawing.Point(1, -2);
            this._ServiceHeading.LabelPadding = new System.Windows.Forms.Padding(0);
            this._ServiceHeading.LabelSize = new System.Drawing.Size(49, 22);
            this._ServiceHeading.LabelText = "//NONE";
            this._ServiceHeading.LabelTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._ServiceHeading.LabelTextColor = System.Drawing.SystemColors.ControlLightLight;
            this._ServiceHeading.LabelToolTip = "";
            this._ServiceHeading.LabelVisible = true;
            this._ServiceHeading.Location = new System.Drawing.Point(0, 0);
            this._ServiceHeading.Margin = new System.Windows.Forms.Padding(0);
            this._ServiceHeading.MenuButtonDock = System.Windows.Forms.DockStyle.Right;
            this._ServiceHeading.MenuButtonImage = null;
            this._ServiceHeading.Name = "_ServiceHeading";
            this._ServiceHeading.PropertyName = null;
            this._ServiceHeading.Size = new System.Drawing.Size(180, 12);
            this._ServiceHeading.TabIndex = 71;
            this._ServiceHeading.TabStop = false;
            // 
            // ServicePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.Controls.Add(this._Equipment);
            this.Controls.Add(this._LATPanel);
            this.Controls.Add(this._ONCPanel);
            this.Controls.Add(this._MTVPanel);
            this.Controls.Add(this._ServiceHeading);
            this.Controls.Add(this._NBNPanel);
            this.Controls.Add(this._DTVPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.Name = "ServicePanel";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(995, 252);
            this._LATPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this._NBNPanel.ResumeLayout(false);
            this._DTVPanel.ResumeLayout(false);
            this._MTVPanel.ResumeLayout(false);
            this._ONCPanel.ResumeLayout(false);
            this._EquipmentMenu.ResumeLayout(false);
            this._NodeContextMenu.ResumeLayout(false);
            this._PRIContextMenu.ResumeLayout(false);
            this._AVCContextMenu.ResumeLayout(false);
            this._CVCContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal LabelledTextBoxLong _AVC;
        internal LabelledTextBoxLong _Bras;
        internal LabelledComboBoxLong _Sip;
        internal LabelledTextBoxLong _CSA;
        internal LabelledTextBoxLong _CVC;
        internal LabelledTextBoxLong _NNI;
        internal LabelledTextBoxLong _GSID;
        internal LabelledTextBoxLong _INC;
        internal LabelledTextBoxLong _APT;
        internal LabelledTextBoxLong _Node;
        internal LabelledComboBoxLong _CauPing;
        internal LabelledTextField _NitResults;
        internal LabelledBase _ServiceHeading;
        internal LabelledTextBoxLong _DTVNode;
        internal LabelledTextBoxLong _DTVMsg;
        internal LabelledComboBoxLong _DTVLights;
        internal LabelledBase _STBHeading;
        internal LabelledTextBoxLong _STBSmartCard;
        internal LabelledTextBox _STBLot;
        internal LabelledTextBox _STBBox;
        internal LabelledBase _MTVHeading;
        internal LabelledTextBoxLong _MTVMac;
        internal LabelledTextBoxLong _MTVSN;
        internal LabelledTextBoxLong _ONCNode;
        internal LabelledBase _SpeedTestHeading;
        internal LabelledTextBoxLong _SpeedTestDown;
        internal LabelledTextBoxLong _SpeedTestUp;
        internal LabelledBase _ModemDetailsHeading;
        internal LabelledComboBoxLong _ModemStatus;
        internal LabelledComboBoxLong _ModemRF;
        internal LabelledTextBoxLong _ModemCMMac;
        internal LabelledTextBoxLong _ModemMTAMac;
        internal LabelledTextBoxLong _ModemSN;
        internal System.Windows.Forms.FlowLayoutPanel _LATPanel;
        internal System.Windows.Forms.FlowLayoutPanel _NBNPanel;
        internal System.Windows.Forms.FlowLayoutPanel _MTVPanel;
        internal System.Windows.Forms.FlowLayoutPanel _ONCPanel;
        internal System.Windows.Forms.FlowLayoutPanel _DTVPanel;
        internal LabelledComboBoxLong _Equipment;
        private System.Windows.Forms.ContextMenuStrip _EquipmentMenu;
        private System.Windows.Forms.ToolStripMenuItem userGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulatorToolStripMenuItem;
        internal System.Windows.Forms.ContextMenuStrip _NodeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ContextMenuStrip _PRIContextMenu;
        private System.Windows.Forms.ToolStripMenuItem nSIToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip _AVCContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip _CVCContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.BindingSource bindingSource1;
        internal LabelledTextBoxLong _ESN;
        internal LabelledTextBoxLong _NTDSN;
        internal LabelledBase labelledBase1;
        internal LabelledTextBoxLong _AddressId;
        internal LabelledBase labelledBase2;
        internal LabelledTextBoxLong _IPNBN;
        internal LabelledTextBoxLong labelledTextBoxLong1;



    }
}
