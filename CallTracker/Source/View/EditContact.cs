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
        internal static NBFPanel NVFPanel;
        internal static NBFPanel NBFPanel;
        internal static LATPanel LATPanel;
        internal static LIPPanel LIPPanel;
        internal static ONCPanel ONCPanel;
        internal static DTVPanel DTVPanel;
        internal static MTVPanel MTVPanel;

        public EditContact()
        {
            InitializeComponent();

            splitContainer2.MouseWheel += splitContainer2_MouseWheel;

            //Products = new List<CheckBox>
            //{
            //    _LAT, _LIP, _ONC, _NVF, _NBF, _DTV, _MTV
            //};

            Products = new List<CheckBox>
            {
                _MTV, _DTV, _NBF, _NVF, _ONC, _LIP, _LAT 
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
            //customerServiceBindingSource.DataSource = Main.SelectedContact.Service;
            faultModelBindingSource.DataSource = Main.SelectedContact.Fault;

            short tPb = Main.SelectedContact.Fault.AffectedServices;
            short tag;
            foreach(var product in Products)
            {
                product.CheckedChanged -= _Product_CheckedChanged;
                tag = Convert.ToInt16(product.Tag);
                if ((tPb & tag) == tag)
                    product.Checked = true;
                else
                    product.Checked = false;

                product.CheckedChanged += _Product_CheckedChanged;
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
        private const int SPLITTER_1_MAX = 180;
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

        private PanelBase CurrentPanel;
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
                    if (LATPanel == null)
                        LATPanel = new LATPanel();
                    if (!splitContainer2.Panel2.Controls.Contains(LATPanel))
                    {
                        splitContainer2.Panel2.Controls.Add(LATPanel);
                        splitContainer2.Panel2.Controls.Remove(CurrentPanel);
                        CurrentPanel = LATPanel;
                    }
                }
                else if ((productBit & 2) == 2)
                {
                    _Symptom.DataSource = LATSymptoms;
                    if (LIPPanel == null)
                        LIPPanel = new LIPPanel();
                    if (!splitContainer2.Panel2.Controls.Contains(LIPPanel))
                    {
                        splitContainer2.Panel2.Controls.Add(LIPPanel);
                        splitContainer2.Panel2.Controls.Remove(CurrentPanel);
                        CurrentPanel = LIPPanel;
                    }
                }
                else if ((productBit & 4) == 4)
                {
                    _Symptom.DataSource = ONCSymptoms;
                    if (ONCPanel == null)
                        ONCPanel = new ONCPanel();
                    if (!splitContainer2.Panel2.Controls.Contains(ONCPanel))
                    {
                        splitContainer2.Panel2.Controls.Add(ONCPanel);
                        splitContainer2.Panel2.Controls.Remove(CurrentPanel);
                        CurrentPanel = ONCPanel;
                    }
                }
                else if ((productBit & 8) == 8)
                {
                    _Symptom.DataSource = NVFSymptoms;
                    if (NVFPanel == null)
                        NVFPanel = new NBFPanel();
                    if (!splitContainer2.Panel2.Controls.Contains(NVFPanel))
                    {
                        splitContainer2.Panel2.Controls.Add(NVFPanel);
                        splitContainer2.Panel2.Controls.Remove(CurrentPanel);
                        CurrentPanel = NVFPanel;
                    }
                }
                else if ((productBit & 16) == 16)
                {
                    _Symptom.DataSource = NBFSymptoms;
                    if (NBFPanel == null)
                        NBFPanel = new NBFPanel();
                    if (!splitContainer2.Panel2.Controls.Contains(NBFPanel))
                    {
                        splitContainer2.Panel2.Controls.Add(NBFPanel);
                        splitContainer2.Panel2.Controls.Remove(CurrentPanel);
                        CurrentPanel = NBFPanel;
                    }
                }
                else if ((productBit & 32) == 32)
                {
                    _Symptom.DataSource = DTVSymptoms;
                    if (DTVPanel == null)
                        DTVPanel = new DTVPanel();
                    if(!splitContainer2.Panel2.Controls.Contains(DTVPanel))
                    {
                        splitContainer2.Panel2.Controls.Add(DTVPanel);
                        splitContainer2.Panel2.Controls.Remove(CurrentPanel);
                        CurrentPanel = DTVPanel;
                    }              
                }
                else if ((productBit & 64) == 64)
                {
                    _Symptom.DataSource = MTVSymptoms;
                    if (MTVPanel == null)
                        MTVPanel = new MTVPanel();
                    if (!splitContainer2.Panel2.Controls.Contains(MTVPanel))
                    {
                        splitContainer2.Panel2.Controls.Add(MTVPanel);
                        splitContainer2.Panel2.Controls.Remove(CurrentPanel);
                        CurrentPanel = MTVPanel;
                    }
                }
                else
                {
                    _Symptom.DataSource = null;
                    splitContainer2.Panel2.Controls.Clear();
                    CurrentPanel = null;
                }

                if (CurrentPanel != null)
                    CurrentPanel.SetDataSource(Main.SelectedContact.Service);
            }
        }
        private void _Product_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            short tag = Convert.ToInt16(checkbox.Tag);
            if (tag == 1)
            {
                if (_LIP.Checked)
                    _LIP.Checked = !_LAT.Checked;
            }
            else if (tag == 2)
                if (_LAT.Checked)
                    _LAT.Checked = !_LIP.Checked;

            if (checkbox.Checked)
                ProductBit += Convert.ToInt16(checkbox.Tag);   
            else
                ProductBit -= Convert.ToInt16(checkbox.Tag);

            //if tag > CurrProduct, don't Add/Remove.
                //if tag > CurrProduct, ignore/

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
