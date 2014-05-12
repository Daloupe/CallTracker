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

    public partial class Main : System.Windows.Forms.Form
    {
        internal DataRepository DataStore;
        internal CustomerContact SelectedContact { get; set; }
        private HotkeyController HotKeys;

        public Main()
        {
            InitializeComponent();

            if(Properties.Settings.Default.Main_Position != Point.Empty)
            {
                StartPosition = FormStartPosition.Manual;
                Location = Properties.Settings.Default.Main_Position;
            }

            if(!File.Exists("Data.bin"))
                File.Create("Data.bin").Close();
            using (var file = File.OpenRead("Data.bin"))
                DataStore = Serializer.Deserialize<DataRepository>(file);

            DataStore.CurrentUser = StringCipher.Decrypt(DataStore.CurrentUser, "2point71828");
            if (DataStore.CurrentUser != Environment.UserName)
            {
                foreach(var login in DataStore.Logins)
                    login.Password = "";
                DataStore.CurrentUser = Environment.UserName;
            }
            else
            {
                foreach (var login in DataStore.Logins)
                    login.Password = StringCipher.Decrypt(login.Password, "2point71828");
            }

            DataStore.Contacts.Add(new CustomerContact() { Id = DataStore.Contacts.Count });

            contactsListBindingSource.PositionChanged += contactsListBindingSource_PositionChanged;
            contactsListBindingSource.DataSource = DataStore.Contacts;
            contactsListBindingSource.Position = DataStore.Contacts.Count;

            HotKeys = new HotkeyController(this);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ViewSmartPasteBinds_Position == Point.Empty)
                Properties.Settings.Default.ViewSmartPasteBinds_Position = DesktopLocation;
            if (Properties.Settings.Default.Logins_Position == Point.Empty)
                Properties.Settings.Default.Logins_Position = DesktopLocation;

            splitContainer2.MouseWheel += splitContainer2_MouseWheel;
            HfcPanel.MouseEnter += splitContainer2_MouseEnter;
            NbnPanel.MouseEnter += splitContainer2_MouseEnter;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            toolStripProgressBar1.Value = 10;
            Properties.Settings.Default.Save();

            toolStripProgressBar1.Value = 20;

            foreach (var login in DataStore.Logins)
                login.Password = StringCipher.Encrypt(login.Password, "2point71828");
            DataStore.CurrentUser = StringCipher.Encrypt(DataStore.CurrentUser, "2point71828");
            using (var file = File.Create("Data.bin"))
                Serializer.Serialize<DataRepository>(file, DataStore);
            
            toolStripProgressBar1.Value = 70;
            HotKeys.Dispose();

            toolStripProgressBar1.Value = 90;
        }

        // Contact Navigator ////////////////////////////////////////////////////////////////////////////////
        void contactsListBindingSource_PositionChanged(object sender, EventArgs e)
        {
            SelectedContact = DataStore.Contacts[Convert.ToInt32(bindingNavigator1.PositionItem.Text) - 1];
            customerContactsBindingSource.DataSource = SelectedContact;
            contactAddressBindingSource.DataSource = SelectedContact.Address;
            customerServiceBindingSource.DataSource = SelectedContact.Service;
            faultModelBindingSource.DataSource = SelectedContact.Fault;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DataStore.Contacts.Add(new CustomerContact() { Id = DataStore.Contacts.Count });
            contactsListBindingSource.Position = DataStore.Contacts.Count;
        }

        public void RemovePasteBind(PasteBind _bind)
        {
            if (DataStore.PasteBinds.Contains(_bind))
                DataStore.PasteBinds.Remove(_bind);
        }

        // Splitter ////////////////////////////////////////////////////////////////////////////////
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (splitContainer1.SplitterDistance > 180)
                splitContainer1.SplitterDistance = 180;
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (splitContainer2.SplitterDistance > 272)
                splitContainer2.SplitterDistance = 272;
            else if (splitContainer2.SplitterDistance < 70)
                splitContainer2.SplitterDistance = 70;
        }

        void splitContainer2_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((splitContainer2.SplitterDistance > 268 && e.Delta > 0) || (splitContainer2.SplitterDistance < 74 && e.Delta < 0))
                return;
            splitContainer2.SplitterDistance += e.Delta/6;
        }

        void splitContainer2_MouseEnter(object sender, EventArgs e)
        {
            splitContainer2.Focus();
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
            contactsListBindingSource.DataSource = DataStore.Contacts;
            contactsListBindingSource.Position = DataStore.Contacts.Count;
        }
        
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.Show();
        }

        private void loginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettingsForm<ViewLogins>();
        }

        private void smartPasteBindsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettingsForm<ViewSmartPasteBinds>();
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
            }
        }

        private void Main_Move(object sender, EventArgs e)
        {
            Properties.Settings.Default.Main_Position = Location;
        }
    }
}
