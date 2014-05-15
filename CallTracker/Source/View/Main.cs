using System;
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
        internal DataRepository DataStore;
        internal static CustomerContact SelectedContact { get; set; }
        private HotkeyController HotKeys;

        public Main()
        {
            InitializeComponent();

            SetAppLocation();

            if (!File.Exists("Data.bin"))
                File.Create("Data.bin").Close();
            using (var file = File.OpenRead("Data.bin"))
                DataStore = Serializer.Deserialize<DataRepository>(file);
            DecryptData();
            DataStore.Contacts.Add(new CustomerContact() { Id = DataStore.Contacts.Count });

            editContact.Init(this);
            editLogins.Init(this);

            HotKeys = new HotkeyController(this);
        }

        private void SetAppLocation()
        {
            Size totalSize = new Size();
            foreach (var screen in Screen.AllScreens)
                totalSize += screen.Bounds.Size;

            if (Properties.Settings.Default.Main_Position.X > totalSize.Width 
             && Properties.Settings.Default.Main_Position.Y > totalSize.Height)
            {
                Properties.Settings.Default.Main_Position = Point.Empty;
                Properties.Settings.Default.ViewSmartPasteBinds_Position = Point.Empty;
                Properties.Settings.Default.Logins_Position = Point.Empty;
            }

            if (Properties.Settings.Default.Main_Position != Point.Empty)
            {
                StartPosition = FormStartPosition.Manual;
                Location = Properties.Settings.Default.Main_Position;
            }
        }

        private void DecryptData()
        {
            string key = StringCipher.Encrypt(Environment.UserName, "2point71828");
            foreach (var login in DataStore.Logins)
                login.Password = StringCipher.Decrypt(login.Password, key);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ViewSmartPasteBinds_Position == Point.Empty)
                Properties.Settings.Default.ViewSmartPasteBinds_Position = DesktopLocation;
            if (Properties.Settings.Default.Logins_Position == Point.Empty)
                Properties.Settings.Default.Logins_Position = DesktopLocation;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //toolStripProgressBar1.Value = 10;
            Properties.Settings.Default.Save();

            //toolStripProgressBar1.Value = 20;
            //DataStore.CurrentUser = StringCipher.Encrypt(DataStore.CurrentUser, "2point71828");

            //toolStripProgressBar1.Value = 30;
            foreach (var login in DataStore.Logins)
                login.Password = StringCipher.Encrypt(login.Password, StringCipher.Encrypt(Environment.UserName, "2point71828"));
            
            //toolStripProgressBar1.Value = 40;
            using (var file = File.Create("Data.bin"))
                Serializer.Serialize<DataRepository>(file, DataStore);
            
            //toolStripProgressBar1.Value = 70;
            HotKeys.Dispose();

            //toolStripProgressBar1.Value = 90;
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
        
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.Show();
        }

        private void loginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ShowSettingsForm<ViewLogins>();
            editLogins.Visible = true;
            editLogins.Enabled = true;    
        }

        private void smartPasteBindsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ShowSettingsForm<ViewSmartPasteBinds>();
            editLogins.Visible = true;
            editLogins.Enabled = true;   
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
    }
}
