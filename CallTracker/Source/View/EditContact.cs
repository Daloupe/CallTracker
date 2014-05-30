using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CallTracker.Model;

namespace CallTracker.View
{
    public partial class EditContact : UserControl
    {
        internal DataRepository DataStore;
        private List<CheckBox> Products;

        public EditContact()
        {
            InitializeComponent();

            splitContainer2.MouseWheel += splitContainer2_MouseWheel;
            HfcPanel.MouseEnter += splitContainer2_MouseEnter;
            NbnPanel.MouseEnter += splitContainer2_MouseEnter;

            Products = new List<CheckBox>
            {
                _LAT, _LIP, _ONC, _NVF, _NBF, _DTV, _MTV
            };
        }
        
        public void Init(Main _parent)
        {

            DataStore = _parent.DataStore;

            contactsListBindingSource.PositionChanged += contactsListBindingSource_PositionChanged;
            contactsListBindingSource.DataSource = DataStore.Contacts;
            contactsListBindingSource.Position = DataStore.Contacts.Count;

            _Severity.DataSource = Enum.GetValues(typeof(FaultSeverity));
            _Outcome.DataSource = Enum.GetValues(typeof(Outcomes));

            
        }

        // Contact Navigator ////////////////////////////////////////////////////////////////////////////////
        void contactsListBindingSource_PositionChanged(object sender, EventArgs e)
        {
            Main.SelectedContact = DataStore.Contacts[contactsListBindingSource.Position];//Convert.ToInt32(bindingNavigator1.PositionItem.Text) - 1];
            customerContactsBindingSource.DataSource = Main.SelectedContact;
            contactAddressBindingSource.DataSource = Main.SelectedContact.Address;
            customerServiceBindingSource.DataSource = Main.SelectedContact.Service;
            faultModelBindingSource.DataSource = Main.SelectedContact.Fault;

            short tPb = Main.SelectedContact.Fault.AffectedServices;
            short tag;
            foreach(var product in Products)
            {
                tag = Convert.ToInt16(product.Tag);
                if ((tPb & tag) == tag)
                    product.Checked = true;
                else
                    product.Checked = false;
            }

            ProductBit = Main.SelectedContact.Fault.AffectedServices;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            CustomerContact newContact = new CustomerContact();
            newContact.Id = DataStore.Contacts.Count;
            newContact.Contacts.StartDate = DateTime.Today;
            newContact.Contacts.StartTime = DateTime.Now.TimeOfDay;

            DataStore.Contacts.Add(newContact);
            contactsListBindingSource.Position = DataStore.Contacts.Count;
        }

        public void DeleteCalls()
        {
            contactsListBindingSource.DataSource = DataStore.Contacts;
            contactsListBindingSource.Position = DataStore.Contacts.Count;
        }

        // Splitter ////////////////////////////////////////////////////////////////////////////////
        private const int SPLITTER_1_MIN = 0;
        private const int SPLITTER_1_MAX = 176;
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (splitContainer1.SplitterDistance > SPLITTER_1_MAX)
                splitContainer1.SplitterDistance = SPLITTER_1_MAX;
        }

        private void splitContainer1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int dist = splitContainer1.SplitterDistance;

            if (dist == SPLITTER_1_MAX)
                dist = SPLITTER_1_MIN;
            else if (dist == SPLITTER_1_MIN)
                dist = SPLITTER_1_MAX;
            else if (dist < SPLITTER_1_MAX/2)
                dist = SPLITTER_1_MIN;
            else
                dist = SPLITTER_1_MAX;

            splitContainer1.SplitterDistance = dist;
        }

        private const int SPLITTER_2_MIN = 70;
        private const int SPLITTER_2_MAX = 258;
        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (splitContainer2.SplitterDistance > SPLITTER_2_MAX)
                splitContainer2.SplitterDistance = SPLITTER_2_MAX;
            else if (splitContainer2.SplitterDistance < SPLITTER_2_MIN)
                splitContainer2.SplitterDistance = SPLITTER_2_MIN;
        }

        private void splitContainer2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int dist = splitContainer2.SplitterDistance;

            if (dist == SPLITTER_2_MAX)
                dist = SPLITTER_2_MIN;
            else if (dist == SPLITTER_2_MIN)
                dist = SPLITTER_2_MAX;
            else if (dist < SPLITTER_2_MAX - SPLITTER_2_MIN)
                dist = SPLITTER_2_MIN;
            else
                dist = SPLITTER_2_MAX;

            splitContainer2.SplitterDistance = dist;
        }

        void splitContainer2_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((splitContainer2.SplitterDistance > 254 && e.Delta > 0) || (splitContainer2.SplitterDistance < 74 && e.Delta < 0))
                return;
            splitContainer2.SplitterDistance += e.Delta / 8;
        }

        void splitContainer2_MouseEnter(object sender, EventArgs e)
        {
            splitContainer2.Focus();
        }

        // Misc ////////////////////////////////////////////////////////////////////////////////
        private void PaintGrayBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.WhiteSmoke,
              0,
              0,
              ((Control)sender).Width - 1,
              ((Control)sender).Height - 1);
            base.OnPaint(e);
        }

        private void _LAT_CheckedChanged(object sender, EventArgs e)
        {
            if (_LIP.Checked)
                _LIP.Checked = !_LAT.Checked;

            _Product_CheckedChanged(sender, e);
        }

        private void _LIP_CheckedChanged(object sender, EventArgs e)
        {
            if (_LAT.Checked)
                _LAT.Checked = !_LIP.Checked;

            _Product_CheckedChanged(sender, e);      
        }

        private short productBit;
        public short ProductBit
        {
            get
            {
                return productBit;
            }
            set
            {
                productBit = value;
                if (Main.SelectedContact != null)
                    Main.SelectedContact.Fault.AffectedServices = productBit;

                if ((productBit & 1) == 1)
                {
                    _Symptom.DataSource = LATSymptoms;
                }
                else if ((productBit & 2) == 2)
                {
                    _Symptom.DataSource = ONCSymptoms;
                }
                else if ((productBit & 4) == 4)
                {
                    _Symptom.DataSource = NVFSymptoms;
                }
                else if ((productBit & 8) == 8)
                {
                    _Symptom.DataSource = NBFSymptoms;
                }
                else if ((productBit & 16) == 16)
                {
                    _Symptom.DataSource = DTVSymptoms;
                }
                else if ((productBit & 32) == 32)
                {
                    _Symptom.DataSource = MTVSymptoms;
                }
                else
                {
                    _Symptom.DataSource = null;
                }

            }
        }
        private void _Product_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            if (checkbox.Checked)
                ProductBit += Convert.ToInt16(checkbox.Tag);
            else
                ProductBit -= Convert.ToInt16(checkbox.Tag);

            //Console.WriteLine(GetIntBinaryString(ProductBit));
        }

        static string GetIntBinaryString(int n)
        {
            char[] b = new char[16];
            int pos = 15;
            int i = 0;

            while (i < 16)
            {
                if ((n & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            }
            return new string(b);
        }

        public static List<string> LATSymptoms = new List<string>
        {
            "NDT",
            "COS",
            "NRR",
            "DTN",
            "DRP"
        };

        public static List<string> ONCSymptoms = new List<string>
        {
            "CCI",
            "DTR",
            "DRP",
            "LIC"
        };

        public static List<string> NVFSymptoms = new List<string>
        {
            "NDT",
            "COS",
            "NRR",
            "DTN"
        };

        public static List<string> NBFSymptoms = new List<string>
        {
            "CCI",
            "DTR",
            "DRP",
            "LIC"
        };

        public static List<string> DTVSymptoms = new List<string>
        {
            "MSG",
            "NPI",
            "PPX",
            "DRP"
        };

        public static List<string> MTVSymptoms = new List<string>
        {
            "NPI",
            "PPX"
        };
    }
}
