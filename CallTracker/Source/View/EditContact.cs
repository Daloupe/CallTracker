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

        public EditContact()
        {
            InitializeComponent();

            splitContainer2.MouseWheel += splitContainer2_MouseWheel;
            HfcPanel.MouseEnter += splitContainer2_MouseEnter;
            NbnPanel.MouseEnter += splitContainer2_MouseEnter;
        }

        public void Init(Main _parent)
        {
            DataStore = _parent.DataStore;
            contactsListBindingSource.PositionChanged += contactsListBindingSource_PositionChanged;
            contactsListBindingSource.DataSource = DataStore.Contacts;
            contactsListBindingSource.Position = DataStore.Contacts.Count;
        }

        // Contact Navigator ////////////////////////////////////////////////////////////////////////////////
        void contactsListBindingSource_PositionChanged(object sender, EventArgs e)
        {
            Main.SelectedContact = DataStore.Contacts[Convert.ToInt32(bindingNavigator1.PositionItem.Text) - 1];
            customerContactsBindingSource.DataSource = Main.SelectedContact;
            contactAddressBindingSource.DataSource = Main.SelectedContact.Address;
            customerServiceBindingSource.DataSource = Main.SelectedContact.Service;
            faultModelBindingSource.DataSource = Main.SelectedContact.Fault;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DataStore.Contacts.Add(new CustomerContact() { Id = DataStore.Contacts.Count });
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
            splitContainer2.SplitterDistance += e.Delta / 6;
        }

        void splitContainer2_MouseEnter(object sender, EventArgs e)
        {
            splitContainer2.Focus();
        }

        // Misc ////////////////////////////////////////////////////////////////////////////////
        private void PaintGrayBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.WhiteSmoke,
              e.ClipRectangle.Left,
              e.ClipRectangle.Top,
              e.ClipRectangle.Width - 1,
              e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }
    }
}
