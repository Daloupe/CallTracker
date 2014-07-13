﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.ComponentModel;

using System.Diagnostics;

using ProtoBuf;
using PropertyChanged;

using CallTracker.Model;
using CallTracker.Helpers;

namespace CallTracker.View
{
    [ImplementPropertyChanged]
    public partial class Main : Form
    {
        internal CustomerContact SelectedContact { get; set; }

        internal UserDataStore DataStore = new UserDataStore();
        internal ResourceData ResourceStore = new ResourceData();

        private HotkeyController HotKeys;
        internal static ICONNoteGenerator NoteGen = new ICONNoteGenerator();

        internal EditLogins editLogins;
        internal EditGridLinks editGridLinks;
        internal EditSmartPasteBinds editSmartPasteBinds;
        internal EditContact editContact;
        internal CallHistory callHistory;
        internal HelpKeyCommands helpKeyCommands;

        internal LATRatecodes latRateCodes;

        private AutoCompleteStringCollection systemAutoCompleteSource = new AutoCompleteStringCollection();

        public Point ControlOffset = new Point(0, 18);

        public Main()
        {
            InitializeComponent();
            SelectedContact = new CustomerContact();

            SetAppLocation();
            DataStore = DataStore.ReadFile();
            ResourceStore = ResourceStore.ReadFile();
            HotKeys = new HotkeyController(this);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            editContact = new EditContact(this);

            editLogins = new EditLogins();
            editGridLinks = new EditGridLinks();
            editSmartPasteBinds = new EditSmartPasteBinds();
            callHistory = new CallHistory();
            helpKeyCommands = new HelpKeyCommands();

            latRateCodes = new LATRatecodes();
            

            Controls.Add(editLogins);
            Controls.Add(editGridLinks);
            Controls.Add(editSmartPasteBinds);
            Controls.Add(callHistory);
            Controls.Add(helpKeyCommands);
            Controls.Add(editContact);
            Controls.Add(latRateCodes);

            editContact.BringToFront();
            editContact.Visible = true;
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
            editContact.Init();

            editLogins.Init(this, loginsViewMenuItem);
            editSmartPasteBinds.Init(this, pasteBindsViewMenuItem);
            editGridLinks.Init(this, gridLinksViewMenuItem);
            callHistory.Init(this, callHistoryToolStripMenuItem);
            helpKeyCommands.Init(this, viewKeyCommandsMenuItem);
            latRateCodes.Init(this, LATRatecodeMenuItem);

            IETabActivator.OnAction += UpdateProgressBar;
            HotkeyController.OnAction += UpdateProgressBar;


        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            DataStore.SaveFile(DataStore);
            ResourceStore.SaveFile(ResourceStore);
            HotKeys.Dispose();
        }

        public void RemovePasteBind(PasteBind _bind)
        {
            if (DataStore.PasteBinds.Contains(_bind))
            {
                DataStore.PasteBinds.Remove(_bind);
                //editSmartPasteBinds.pasteBindBindingSource.ResetBindings(true);
            }
        }

        // Menu Bar ////////////////////////////////////////////////////////////////////////////////
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private ViewControlBase _VisibleSetting;
        public ViewControlBase VisibleSetting 
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
            VisibleSetting = item.Tag as ViewControlBase;
        }

        public static T ShowPopupForm<T>() where T : Form, new()
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
            e.Graphics.DrawRectangle(Pens.WhiteSmoke,
             0,
             0,
             ((Control)sender).Width - 1,
             ((Control)sender).Height - 1);
            base.OnPaint(e);
        }

        public void UpdateProgressBar(int percent)
        {
            editContact.toolStripProgressBar1.Value = percent;
        }

        public void UpdateProgressBar()
        {
            editContact.toolStripProgressBar1.PerformStep();
        }

        public void SetProgressBarStep(int _steps)
        {
            editContact.toolStripProgressBar1.Maximum = _steps + 1;
            UpdateProgressBar();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        
        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
            {
                settingMenuItem_Click(LATRatecodeMenuItem, new EventArgs());
                latRateCodes.Search(((ToolStripTextBox)sender).Text);
                LatRatecodeSearch.PerformClick();
                
            };
        }

        public void UpdateAutoComplete()
        {
            LatRatecodeSearch.AutoCompleteCustomSource = systemAutoCompleteSource;
            systemAutoCompleteSource.Clear();
            systemAutoCompleteSource.AddRange(ResourceStore.LATRatePlans.Select(p => p.RateCode).ToArray());
        }
    }
}
