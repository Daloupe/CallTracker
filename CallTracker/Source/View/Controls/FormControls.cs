using System.Drawing.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using CallTracker.Helpers;

namespace CallTracker.View
{
    public class LabelledToolStripProgressBar : ToolStripProgressBar
    {
        public TextBox Label = new TextBox();

        [Category("!Label")]
        public string LabelText
        {
            get { return Label.Text; }
            set { Label.Text = value; }
        }

        public LabelledToolStripProgressBar() : base()
        {
            Label.Text = "test";
            Label.Size = this.Size;
            Label.Location = this.Control.Location;
        }
    }

    public class BorderedTextBox : TextBox
    {
        private Color _borderColor = Color.Gray;
        private ButtonBorderStyle _buttonBorderStyle = ButtonBorderStyle.Solid;
        private static int WM_PAINT = 0x000F;

        public BorderedTextBox() : base()
        {
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            BorderStyle = BorderStyle.FixedSingle;
            DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;         
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                Graphics g = Graphics.FromHwnd(Handle);
                Rectangle bounds = new Rectangle(0, 0, Width, Height);
                ControlPaint.DrawBorder(g, bounds, _borderColor, _buttonBorderStyle);
            }
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    var line = TextRenderer.MeasureText(Text, Font);
        //    //e.Graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
        //    //ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, Width, Height), _borderColor, _buttonBorderStyle);
        //    e.Graphics.DrawString(Text, new Font("Verdana", 7.25f),
        //            new SolidBrush(ForeColor),
        //            new Rectangle(0, 0, line.Width, line.Height));
        //    //e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

        //    //TextRenderer.DrawText(e.Graphics, Text, Font, new Point(0, 0), Color.Black);

        //    e.Graphics.DrawRectangle(new Pen(_borderColor),
        //     0,
        //     0,
        //     Width,
        //     Height);


        //    base.OnPaint(e);

        //}

        [Category("Appearance")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate(); // causes control to be redrawn
            }
        }   
    }

    public class BorderedTextField : RichTextBox
    {
        private Color _borderColor = Color.Gray;
        private ButtonBorderStyle _buttonBorderStyle = ButtonBorderStyle.Solid;
        private static int WM_PAINT = 0x000F;

        public BorderedTextField()
            : base()
        {
            //SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            BorderStyle = BorderStyle.FixedSingle;
            DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
        }

        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    var g = Graphics.FromHwnd(Handle);
        //    var bounds = new Rectangle(0, 0, Width, Height);
        //    ControlPaint.DrawBorder(g, bounds, _borderColor, _buttonBorderStyle);
        //}
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                Graphics g = Graphics.FromHwnd(Handle);
                Rectangle bounds = new Rectangle(0, 0, Width, Height);
                ControlPaint.DrawBorder(g, bounds, _borderColor, _buttonBorderStyle);
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate(); // causes control to be redrawn
            }
        }
    }

    public class BorderedDateTimePicker: DateTimePicker
    {
        #region ComboInfoHelper
        internal class ComboInfoHelper
        {
            [DllImport("user32")]
            private static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref ComboBoxInfo info);

            #region RECT struct
            [StructLayout(LayoutKind.Sequential)]
            private struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
            #endregion

            #region ComboBoxInfo Struct
            [StructLayout(LayoutKind.Sequential)]
            private struct ComboBoxInfo
            {
                public int cbSize;
                public RECT rcItem;
                public RECT rcButton;
                public IntPtr stateButton;
                public IntPtr hwndCombo;
                public IntPtr hwndEdit;
                public IntPtr hwndList;
            }
            #endregion

            public static int GetComboDropDownWidth()
            {
                ComboBox cb = new ComboBox();
                int width = GetComboDropDownWidth(cb.Handle);
                cb.Dispose();
                return width;
            }
            public static int GetComboDropDownWidth(IntPtr handle)
            {
                ComboBoxInfo cbi = new ComboBoxInfo();
                cbi.cbSize = Marshal.SizeOf(cbi);
                GetComboBoxInfo(handle, ref cbi);
                int width = cbi.rcButton.Right - cbi.rcButton.Left;
                return width;
            }
        }
        #endregion

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, object lParam);

        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        const int WM_ERASEBKGND = 0x14;
        const int WM_PAINT = 0xF;
        const int WM_NC_HITTEST = 0x84;
        const int WM_NC_PAINT = 0x85;
        const int WM_PRINTCLIENT = 0x318;
        const int WM_SETCURSOR = 0x20;


        private Pen BorderPen = new Pen(Color.Black, 2);
        private Pen BorderPenControl = new Pen(SystemColors.ControlDark, 2);
        private bool DroppedDown = false;
        private int InvalidateSince = 0;
        private static int DropDownButtonWidth = 17;


        [Category("Appearance")]
        public Color BorderColor
        {
            get { return BorderPen.Color; }
            set
            {
                BorderPen.Color = value;
                BorderPenControl.Color = value;
                Invalidate(); // causes control to be redrawn
            }
        }
        //private Color _borderColor = Color.Gray;
        //private ButtonBorderStyle _buttonBorderStyle = ButtonBorderStyle.Solid;
        //private static int WM_PAINT = 0x000F;

        static BorderedDateTimePicker()
		{
			// 2 pixel extra is for the 3D border around the pulldown button on the left and right
            DropDownButtonWidth = ComboInfoHelper.GetComboDropDownWidth() + 3;	
		}

        public BorderedDateTimePicker()
            : base()
        {
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            //this.DropDownStyle = ComboBoxStyle.DropDown;
        }
        protected override void OnValueChanged(EventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
            Invalidate();
        }
        protected override void WndProc(ref Message m)
        {
            IntPtr hDC = IntPtr.Zero;
            Graphics gdc = null;
            switch (m.Msg)
            {
                case WM_NC_PAINT:
                    hDC = GetWindowDC(m.HWnd);
                    gdc = Graphics.FromHdc(hDC);
                    SendMessage(this.Handle, WM_ERASEBKGND, hDC, 0);
                    SendPrintClientMsg();
                    SendMessage(this.Handle, WM_PAINT, IntPtr.Zero, 0);
                    OverrideControlBorder(gdc);
                    m.Result = (IntPtr)1;	// indicate msg has been processed
                    ReleaseDC(m.HWnd, hDC);
                    gdc.Dispose();
                    break;
                case WM_PAINT:
                    base.WndProc(ref m);
                    hDC = GetWindowDC(m.HWnd);
                    gdc = Graphics.FromHdc(hDC);
                    OverrideDropDown(gdc);
                    OverrideControlBorder(gdc);
                    ReleaseDC(m.HWnd, hDC);
                    gdc.Dispose();
                    break;
                /*
                // We don't need this anymore, handle by WM_SETCURSOR
                case WM_NC_HITTEST: 
                    base.WndProc(ref m);
                    if (DroppedDown)
                    {
                        OverrideDropDown(gdc);
                        OverrideControlBorder(gdc);
                    }
                    break;
                */
                case WM_SETCURSOR:
                    base.WndProc(ref m);
                    // The value 3 is discovered by trial on error, and cover all kinds of scenarios
                    // InvalidateSince < 2 wil have problem if the control is not in focus and dropdown is clicked
                    if (DroppedDown && InvalidateSince < 3)
                    {
                        Invalidate();
                        InvalidateSince++;
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void SendPrintClientMsg()
        {
            // We send this message for the control to redraw the client area
            Graphics gClient = this.CreateGraphics();
            IntPtr ptrClientDC = gClient.GetHdc();
            SendMessage(this.Handle, WM_PRINTCLIENT, ptrClientDC, 0);
            gClient.ReleaseHdc(ptrClientDC);
            gClient.Dispose();
        }

        private void OverrideDropDown(Graphics g)
        {
            if (!this.ShowUpDown)
            {
                Rectangle rect = new Rectangle(this.Width - DropDownButtonWidth, 0, DropDownButtonWidth, this.Height);
                ControlPaint.DrawComboButton(g, rect, ButtonState.Flat);
            }
        }

        private void OverrideControlBorder(Graphics g)
        {
            if (this.Focused == false || this.Enabled == false)
                g.DrawRectangle(BorderPenControl, new Rectangle(0, 0, this.Width, this.Height));
            else
                g.DrawRectangle(BorderPen, new Rectangle(0, 0, this.Width, this.Height));
        }

        protected override void OnDropDown(EventArgs eventargs)
        {
            InvalidateSince = 0;
            DroppedDown = true;
            base.OnDropDown(eventargs);
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            DroppedDown = false;
            base.OnCloseUp(eventargs);
        }

        protected override void OnLostFocus(System.EventArgs e)
        {
            base.OnLostFocus(e);
            this.Invalidate();
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }

    public class BorderedCombobox : ComboBox
    {
        private Color _borderColor = Color.Gray;
        private ButtonBorderStyle _buttonBorderStyle = ButtonBorderStyle.Solid;
        private static int WM_PAINT = 0x000F;

        public BorderedCombobox()
            : base()
        {
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            FlatStyle = FlatStyle.Popup;
            DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            //this.DropDownStyle = ComboBoxStyle.DropDown;
        }

        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    var g = Graphics.FromHwnd(Handle);
        //    var bounds = new Rectangle(0, 0, Width, Height);
        //    ControlPaint.DrawBorder(g, bounds, _borderColor, _buttonBorderStyle);
        //}

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                Graphics g = Graphics.FromHwnd(Handle);
                Rectangle bounds = new Rectangle(0, 0, Width, Height);
                ControlPaint.DrawBorder(g, bounds, _borderColor, _buttonBorderStyle);
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate(); // causes control to be redrawn
            }
        }

        #region fields

        /// <summary>
        /// DataSource
        /// </summary>
        private IList _dataSource;

        /// <summary>
        /// The name of the property of the object we bind to
        /// </summary>
        private string _propertyName;

        /// <summary>
        /// Name of the proeprty which is shown in the combo box
        /// </summary>
        private string _displayMember;

        /// <summary>
        /// Flag if comboBox is in normal or nullable mode
        /// </summary>
        public bool NullableMode = false;

        private BindingSource _bindingSource;
        private object _selectedItem;
        private bool _active;
        #endregion

        #region methods

        /// <summary>
        /// Method to bind data in nullable mode to the combo box
        /// </summary>
        /// <param name="dataSource">DataSource (IList)</param>
        /// <param name="bindingSource">Object we bind to</param>
        /// <param name="propertyName">Name of the property of the object we bind to</param>
        /// <param name="displayMember">Name of the proeprty which is shown in the combo box</param>
        public void SetDataBinding(IList dataSource, BindingSource bindingSource, string propertyName, string displayMember)
        {
            _active = true;
            // init combo box and delete all databinding stuff
            if (DataSource != null)
                DataSource = null;
            DisplayMember = String.Empty;
            Items.Clear();
            ValueMember = String.Empty;
            Text = String.Empty;

            _bindingSource = bindingSource;
            _bindingSource.CurrentChanged += mBindingSource_CurrentChanged;
            // init private fields
            _dataSource = dataSource;
            _propertyName = propertyName;
            _displayMember = displayMember;
            NullableMode = true;

            // get selected item
            GetCurrentObject();       
        }

        public void UnSetDataBinding()
        {
            _active = false;
            _bindingSource = null;
            DataSource = null;
        }

        void mBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            GetCurrentObject();
        }

        public void UpdateNullableBindingSource(BindingSource bindingSource)
        {
            _bindingSource = bindingSource;
            GetCurrentObject();
        }

        private void GetCurrentObject()
        {
            if (_active == false)
                return;
            if (_bindingSource.Count > 0)
            {
                _selectedItem = FindProperty.FollowPropertyPath(_bindingSource.Current, _propertyName);
                // if not null, bind to it
                if (!String.IsNullOrEmpty(_selectedItem.ToString()))
                {
                    DataSource = _dataSource;
                    SelectedItem = _selectedItem;
                }
                // do nothing and set datasource to null
                else
                    DataSource = null;
            }
            else
                DataSource = null;
        }

        #endregion

        #region events

        /// <summary>
        /// On drop down event
        /// </summary>
        protected override void OnDropDown(EventArgs e)
        {
            // if no datasource is set, set it
            if (NullableMode && _dataSource != null && DataSource == null)
                DataSource = _dataSource;

            base.OnDropDown(e);
        }

        /// <summary>
        /// On data source changed event
        /// </summary>
        protected override void OnDataSourceChanged(EventArgs e)
        {
            // reset display member
            if (NullableMode && _active)
            {
                DisplayMember = _displayMember;
                GetCurrentObject();
            }

            base.OnDataSourceChanged(e);
        }

        /// <summary>
        /// On selected index changed event
        /// </summary>
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            // set property to new value
            if (NullableMode && _active)
                FindProperty.SetPropertyFromPath(_bindingSource.Current, _propertyName, SelectedItem);

            base.OnSelectedIndexChanged(e);
        }

        /// <summary>
        /// On key down event
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // if DEL or BACK is pressed set property to null and data source to null
            if (NullableMode && (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back))
            {
                // next line is very important: without you may get an OutOfRangeException
                DroppedDown = false;
                DataSource = null;
            }

            base.OnKeyDown(e);
        }

        #endregion
    }
}
