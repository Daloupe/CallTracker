using System;
using System.Drawing;
using System.Windows.Forms;
using CallTracker.Helpers;


namespace CallTracker.View
{
    public partial class DataDrop : Form
    {
        public DataDrop()
        {
            InitializeComponent();
            SetLocation();
        }

        private void DataDrop_Activated(object sender, EventArgs e)
        {
            _Data.Focus();
        }

        private void DataDrop_Leave(object sender, EventArgs e)
        {
            Hide();
            _Data.Text = String.Empty;
        }

        private void _Data_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Hide();
                    _Data.Text = String.Empty;
                    break;
                case Keys.Return:
                    if (!String.IsNullOrEmpty(_Data.Text))
                    {
                        HotkeyController.SmartCopy(_Data.Text);
                        _Data.Text = String.Empty;
                    }
                    Hide();
                    break;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Move Window //////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void _MainMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            Main.ReleaseCapture();
            Main.SendMessage(Handle, Main.WM_NCLBUTTONDOWN, Main.HT_CAPTION, 0);
            Properties.Settings.Default.DataDrop_Position = Location;
        }

        private void SetLocation()
        {
            var totalSize = new Size();
            foreach (var screen in Screen.AllScreens)
                totalSize += screen.Bounds.Size;

            if (Properties.Settings.Default.DataDrop_Position == Point.Empty ||
                Properties.Settings.Default.DataDrop_Position.X >= totalSize.Width ||
                Properties.Settings.Default.DataDrop_Position.Y >= totalSize.Height) return;

            StartPosition = FormStartPosition.Manual;
            Location = Properties.Settings.Default.DataDrop_Position;
        }
    }
}
