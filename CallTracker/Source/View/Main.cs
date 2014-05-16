﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

using ProtoBuf;

using CallTracker.Model;
using CallTracker.Helpers;

namespace CallTracker.View
{
    public partial class Main : Form
    {
        internal static CustomerContact SelectedContact { get; set; }

        internal DataRepository DataStore;
        private HotkeyController HotKeys;

        public Main()
        {
            InitializeComponent();

            SetAppLocation();
            DataStore = DataRepository.ReadFile();
            HotKeys = new HotkeyController(this);
        }

        private void SetAppLocation()
        {
            Size totalSize = new Size();
            foreach (var screen in Screen.AllScreens)
                totalSize += screen.Bounds.Size;

            if (Properties.Settings.Default.Main_Position != Point.Empty
             && Properties.Settings.Default.Main_Position.X < totalSize.Width
             && Properties.Settings.Default.Main_Position.Y < totalSize.Height)
            {
                StartPosition = FormStartPosition.Manual;
                Location = Properties.Settings.Default.Main_Position;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            editContact.Init(this);

            editLogins.Init(this, loginsViewMenuItem);
            editSmartPasteBinds.Init(this, pasteBindsViewMenuItem);
            editGridLinks.Init(this, gridLinksViewMenuItem);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //toolStripProgressBar1.Value = 10;
            Properties.Settings.Default.Save();
            DataRepository.SaveFile(DataStore);
            HotKeys.Dispose();
        }

        public void RemovePasteBind(PasteBind _bind)
        {
            if (DataStore.PasteBinds.Contains(_bind))
                DataStore.PasteBinds.Remove(_bind);
        }

        // Menu Bar ////////////////////////////////////////////////////////////////////////////////
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteCallDataMenuItem_Click(object sender, EventArgs e)
        {
            DataStore.Contacts = new List<CustomerContact>();
            DataStore.Contacts.Add(new CustomerContact() { Id = DataStore.Contacts.Count });
            editContact.DeleteCalls();
        }

        private SettingsViewBase _VisibleSetting;
        public SettingsViewBase VisibleSetting 
        {
            get { return _VisibleSetting; }
            set
            {
                if (value != null)
                    value.ShowSetting();

                if (_VisibleSetting != null)
                    _VisibleSetting.HideSetting();

                if (_VisibleSetting == value)
                    _VisibleSetting = null;
                else
                    _VisibleSetting = value;
            }
        }

        private void settingMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            VisibleSetting = item.Tag as SettingsViewBase;
        }

        public static T ShowSettingsForm<T>() where T : Form, new()
        {
            var findForm = Application.OpenForms.OfType<T>();
            if (!findForm.Any())
            {
                T form = new T();
                form.Show();
            }
            else
            {
                findForm.First().Activate();
            }
            return findForm.First();
        }

        // Move Window ////////////////////////////////////////////////////////////////////////////////////
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void _MainMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                Properties.Settings.Default.Main_Position = Location;
            }
        }

        // Misc ////////////////////////////////////////////////////////////////////////////////////
        private void PaintGrayBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Gainsboro,
              e.ClipRectangle.Left,
              e.ClipRectangle.Top,
              e.ClipRectangle.Width - 1,
              e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }
    }
}
