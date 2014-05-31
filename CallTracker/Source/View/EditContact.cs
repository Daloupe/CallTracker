﻿using System;
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
        internal NBFPanel NVFPanel;
        internal NBFPanel NBFPanel;
        internal LATPanel LATPanel;
        internal LIPPanel LIPPanel;
        internal ONCPanel ONCPanel;
        internal DTVPanel DTVPanel;
        internal MTVPanel MTVPanel;

        public EditContact(Main _mainform)
        {
            InitializeComponent();
            MainForm = _mainform;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            splitContainer2.MouseWheel += splitContainer2_MouseWheel;

            Products = new List<CheckBox>
            {
                _LAT, _LIP, _ONC, _NVF, _NBF, _DTV, _MTV
            };

            NVFPanel = new NBFPanel();
            NBFPanel = new NBFPanel();
            LATPanel = new LATPanel();
            LIPPanel = new LIPPanel();
            ONCPanel = new ONCPanel();
            DTVPanel = new DTVPanel();
            MTVPanel = new MTVPanel();
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var parms = base.CreateParams;
        //        parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
        //        return parms;
        //    }
        //}
        Main MainForm;
        public void Init(Main _parent)
        {
            MainForm = _parent;
            DataStore = _parent.DataStore;

            customerContactsBindingSource.PositionChanged += contactsListBindingSource_PositionChanged;
            customerContactsBindingSource.PositionChanged += MainForm.NoteGen.OnContactChange;
            customerContactsBindingSource.DataSource = DataStore.Contacts;
            customerContactsBindingSource.Position = DataStore.Contacts.Count;
            customerContactsBindingSource.ListChanged += MainForm.NoteGen.OnDataFieldChange;

            _Severity.DataSource = Enum.GetValues(typeof(FaultSeverity));
            _Outcome.DataSource = Enum.GetValues(typeof(Outcomes));
        }

        // Contact Navigator ////////////////////////////////////////////////////////////////////////////////
        void contactsListBindingSource_PositionChanged(object sender, EventArgs e)
        {
            MainForm.SelectedContact = DataStore.Contacts[customerContactsBindingSource.Position];

            short tPb = MainForm.SelectedContact.Fault.AffectedServices;
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

            ProductBit = MainForm.SelectedContact.Fault.AffectedServices;  
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            CustomerContact newContact = new CustomerContact();
            newContact.Id = DataStore.Contacts.Count;
            newContact.Contacts.StartDate = DateTime.Today;
            newContact.Contacts.StartTime = DateTime.Now.TimeOfDay;

            DataStore.Contacts.Add(newContact);
            customerContactsBindingSource.Position = DataStore.Contacts.Count;
        }

        public void DeleteCalls()
        {
            customerContactsBindingSource.DataSource = DataStore.Contacts;
            customerContactsBindingSource.Position = DataStore.Contacts.Count;
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
            splitContainer2.SplitterDistance += e.Delta / 10;
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
                if (MainForm.SelectedContact != null)
                    MainForm.SelectedContact.Fault.AffectedServices = productBit;

                if ((productBit & 1) == 1)
                {
                    _Symptom.DataSource = LATSymptoms;
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
                    CurrentPanel.SetDataSource(MainForm.SelectedContact.Service);
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
