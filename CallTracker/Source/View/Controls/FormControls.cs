using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace CallTracker.View
{

    public class BorderedTextBox : TextBox
    {
        private Color _borderColor = Color.Gray;
        private ButtonBorderStyle _buttonBorderStyle = ButtonBorderStyle.Solid;
        private static int WM_PAINT = 0x000F;

        public BorderedTextBox() : base()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
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
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
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

    public class BorderedCombobox : ComboBox
    {
        private Color _borderColor = Color.Gray;
        private ButtonBorderStyle _buttonBorderStyle = ButtonBorderStyle.Solid;
        private static int WM_PAINT = 0x000F;

        public BorderedCombobox()
            : base()
        {
            this.FlatStyle = FlatStyle.Popup;
            this.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            //this.DropDownStyle = ComboBoxStyle.DropDown;
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


}
