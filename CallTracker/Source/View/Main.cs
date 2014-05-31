using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.ComponentModel;

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

        internal DataRepository DataStore;
        private HotkeyController HotKeys;
        internal ICONNoteGenerator NoteGen;

        internal EditLogins editLogins;
        internal EditGridLinks editGridLinks;
        internal EditSmartPasteBinds editSmartPasteBinds;
        internal EditContact editContact;
        internal HelpKeyCommands helpKeyCommands;

        public Main()
        {
            InitializeComponent();
            SelectedContact = new CustomerContact();

            SetAppLocation();
            DataStore = DataRepository.ReadFile();
            HotKeys = new HotkeyController(this);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            NoteGen = new ICONNoteGenerator(this);

            Point offset = new Point(0, 18);
            editLogins = new EditLogins();
            editLogins.Location = offset;
            editGridLinks = new EditGridLinks();
            editGridLinks.Location = offset;
            editSmartPasteBinds = new EditSmartPasteBinds();
            editSmartPasteBinds.Location = offset;

            helpKeyCommands = new HelpKeyCommands();
            helpKeyCommands.Location = offset;
            editContact = new EditContact(this);
            editContact.Location = offset;

            Controls.Add(editLogins);
            Controls.Add(editGridLinks);
            Controls.Add(editSmartPasteBinds);
            Controls.Add(helpKeyCommands);
            Controls.Add(editContact);

            editContact.BringToFront();
            editContact.Visible = true;
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

            helpKeyCommands.Init(this, viewKeyCommandsMenuItem);

            IETabActivator.OnAction += UpdateProgressBar;
            HotkeyController.OnAction += UpdateProgressBar;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            DataRepository.SaveFile(DataStore);
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

        private void DeleteCallDataMenuItem_Click(object sender, EventArgs e)
        {
            DataStore.Contacts = new BindingList<CustomerContact>();
            DataStore.Contacts.Add(new CustomerContact() { Id = DataStore.Contacts.Count });
            editContact.DeleteCalls();
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
    }
}
