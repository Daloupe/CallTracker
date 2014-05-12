using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using ProtoBuf;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

using CallTracker.Model;
using CallTracker.Helpers;

using PropertyChanged;

namespace CallTracker.View
{
    [ImplementPropertyChanged]
    public partial class Main : System.Windows.Forms.Form
    {
        internal List<PasteBind> PasteBinds;
        internal List<CustomerContact> Contacts;
        public CustomerContact SelectedContact { get; set; }

        //internal BindSmartPasteForm bspf;
        //internal ViewSmartPasteBinds vspb;

        private HotkeyController HotKeys;

        public Main()
        {
            InitializeComponent();

            if(Properties.Settings.Default.Main_Position != Point.Empty)
            {
                StartPosition = FormStartPosition.Manual;
                Location = Properties.Settings.Default.Main_Position;
            }

            HotKeys = new HotkeyController(this);

            using (var file = File.OpenRead("Bindings.bin"))
                PasteBinds = Serializer.Deserialize<List<PasteBind>>(file);
            using (var file = File.OpenRead("Contacts.bin"))
                Contacts = Serializer.Deserialize<List<CustomerContact>>(file);
            Contacts.Add(new CustomerContact() { Id = Contacts.Count });

            contactsListBindingSource.PositionChanged += contactsListBindingSource_PositionChanged;
            contactsListBindingSource.DataSource = Contacts;
            contactsListBindingSource.Position = Contacts.Count; 
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ViewSmartPasteBinds_Position == Point.Empty)
                Properties.Settings.Default.ViewSmartPasteBinds_Position = DesktopLocation;

            //bspf = new BindSmartPasteForm(this);

            // Enable split panel scrolling.
            // TODO: pas back focus to previous control after scrolling.
            splitContainer2.MouseWheel += splitContainer2_MouseWheel;
            panel1.MouseEnter += splitContainer2_MouseEnter;
            splitContainer2.Panel2.MouseEnter += splitContainer2_MouseEnter;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            toolStripProgressBar1.Value = 10;
            Properties.Settings.Default.Save();
            
            toolStripProgressBar1.Value = 30;
            using (var file = File.Create("Bindings.bin"))
                Serializer.Serialize<List<PasteBind>>(file, PasteBinds);
            
            toolStripProgressBar1.Value = 50;
            using (var file = File.Create("Contacts.bin"))
                Serializer.Serialize<List<CustomerContact>>(file, Contacts);
            
            toolStripProgressBar1.Value = 70;
            HotKeys.Dispose();

            toolStripProgressBar1.Value = 90;
            //if (bspf != null)
            //    bspf.Dispose();
        }

        void contactsListBindingSource_PositionChanged(object sender, EventArgs e)
        {
            SelectedContact = Contacts[Convert.ToInt32(bindingNavigator1.PositionItem.Text) - 1];
            customerContactsBindingSource.DataSource = SelectedContact;
            contactAddressBindingSource.DataSource = SelectedContact.Address;
            customerServiceBindingSource.DataSource = SelectedContact.Service;
            faultModelBindingSource.DataSource = SelectedContact.Fault;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            Contacts.Add(new CustomerContact() { Id = Contacts.Count });
            contactsListBindingSource.Position = Contacts.Count;
        }

        public void RemovePasteBind(PasteBind _bind)
        {
            if (PasteBinds.Contains(_bind))
                PasteBinds.Remove(_bind);
        }

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

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.Show();
        }

        private void loginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewLogins logins = new ViewLogins();
            logins.Show();
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

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Move Window ///////////////
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
