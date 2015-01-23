using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CallTracker.Model;
using CallTracker.Helpers;
using System.Text.RegularExpressions;
namespace CallTracker.View
{
    public partial class Note : Form
    {
        private int _Offset = 0;
        private Main Main;

        public Note(Point location, Main main)
        {
            InitializeComponent();
            Location = location;
            Main = main;
        }

        public void Init()
        {
            customerContactBindingSource.DataSource = Main.editContact.customerContactsBindingSource;
            Main.editContact.customerContactsBindingSource.PositionChanged += noteCustomerContactsBindingSource_PositionChanged;
        }

        void noteCustomerContactsBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (Main.SelectedContact != null)
                Main.SelectedContact.NestedChange -= SelectedContact_NestedChange; 
            this.customerContactBindingSource.Position = ((BindingSource)sender).Position;
            Main.SelectedContact.NestedChange += SelectedContact_NestedChange; 
            if (customerContactBindingSource.Position < 0) return;

            CustomerContact curr = ((CustomerContact)this.customerContactBindingSource.Current);
            _Situation.Tag = curr.NotesSituation;
            _Action.Tag = curr.NotesAction;
            _Outcome.Tag = curr.NotesOutcome;    
        }

        void SelectedContact_NestedChange(object sender, PropertyChangedEventArgs e)
        {
            customerContactBindingSource.ResetBindings(true);
        }

        public void ResizePanel(int width)
        {
            Width = Math.Max(8, width);
            var textFieldWidth = Math.Max(165, Width - 13);

            _Situation.Width = textFieldWidth;
            _Action.Width = textFieldWidth;
            _Outcome.Width = textFieldWidth;
        }
    
        private void resizeHandle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _Offset = Cursor.Position.X;
            }
            else
            {
                if (Width <= 105 || Width > 230)
                    ResizePanel(210);
                else if(Width > 105 && Width <= 230)
                    ResizePanel(8);
            }
        }

        private void resizeHandle_MouseUp(object sender, MouseEventArgs e)
        {
            _Offset = 0;
            CallTracker.Properties.Settings.Default.NoteWidth = Width;
        }

        private void resizeHandle_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Offset != 0)
            {
                var newWidth = Cursor.Position.X - _Offset;
                ResizePanel(Width + newWidth);
                _Offset += newWidth;
            }
        }

        private int lineNum;
        private void getLineNum(dbRTBox textField)
        {
            if (String.IsNullOrEmpty(textField.Text)) return;
            lineNum = textField.Text.Substring(0, textField.SelectionStart).Count(x => x == '\u2022') - 1;
        }

        private void Note_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            //{
            //    Console.WriteLine("Backspace presed");
            //    e.Handled = true;
            //}

        }

        private void Note_KeyUp(object sender, KeyEventArgs e)
        {
            var textField = (dbRTBox)sender;

            var noteItems = (List<NoteItem>)textField.Tag;

            var lineSplit = textField.Lines[lineNum].Split('|');

            var noteItem = noteItems.Where(x => x.Name == lineSplit[1].Trim()).FirstOrDefault();
            var note = lineSplit[0].Remove(0, 1).TrimStart();

            if (!String.IsNullOrEmpty(noteItem.Property)) //&& noteItem.GetType() != typeof(NoteItemBool)
            {
                var prop = FindProperty.FollowPropertyPath(Main.SelectedContact, noteItem.Property);
                note = note.Replace(prop, "{0}");
            }
            noteItem.Note = note;

            textField.ReadOnly = false;
        }

        private void Note_KeyDown(object sender, KeyEventArgs e)
        {
            var textField = (dbRTBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void Note_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var textField = (dbRTBox)sender;
            var noteItems = (List<NoteItem>)textField.Tag;

            if (e.KeyCode == Keys.Enter)
            {
                var newItem = new NoteItemString();
                newItem.Name = newItem.GetHashCode().ToString();
                newItem.Note = ".";

                var currentItemName = textField.Lines[lineNum].Split('|')[1].Trim();
                var currentItemIndex = noteItems.FindIndex(x => x.Name == currentItemName);
                noteItems.Insert(currentItemIndex + 1, newItem);

                var selStart = textField.SelectionStart;
                textField.DataBindings[0].ReadValue();
                textField.SelectionStart = selStart + 3;

                getLineNum(textField);
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                getLineNum(textField);
            }
            else if (e.KeyCode == Keys.Back)
            {        
                if (textField.SelectionStart - textField.GetFirstCharIndexOfCurrentLine() < 3)
                    textField.ReadOnly = true;
            }
            else if(e.KeyCode == Keys.Delete)
            {
                if(textField.Text[textField.SelectionStart+1] == '\u2022')
                    textField.ReadOnly = true;
            }
        }

        private void Note_Enter(object sender, EventArgs e)
        {
            var textField = (dbRTBox)sender;
            textField.SelectionStart = textField.GetCharIndexFromPosition(Cursor.Position);
        }

        private void Note_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Note_MouseDown(object sender, MouseEventArgs e)
        {
            var textField = (dbRTBox)sender;
            if (textField.Text.Length == 0) return;
            if (textField.GetFirstCharIndexOfCurrentLine() != '\u2022')
                textField.SelectionStart = textField.SelectionStart > 0 ? textField.SelectionStart - 1 : 0;
            initIdx.Initialize(textField, textField.GetCharIndexFromPosition(e.Location));
            if (!initIdx.IsNotCloseToLine)
                textField.Select(initIdx.LineIndexStart + 2, 0);
            startIndex = initIdx.Index;

            selecting = true;
        }

        private void Note_MouseUp(object sender, MouseEventArgs e)
        {
            selecting = false;
            var textField = (dbRTBox)sender;

            try
            {
                lineNum = textField.Text.Substring(0, startIndex).Count(x => x == '\u2022') - 1;

            }
            catch (Exception ex)
            {
                EventLogger.LogNewEvent("Error on mouseup finding Line Number: " + e);
            }

            if (textField.SelectionLength == 0)
            {
                selectionLength = 0;
                startIndex = 0;
                if (!initIdx.IsNotCloseToLine)
                    textField.Select(initIdx.LineIndexStart + 2, 0);
            }
            currIdx.CleanLine();
            initIdx.CleanLine();
        }

        private void Note_MouseOver(object sender, MouseEventArgs e)
        {
            if (!selecting) return;

            var textField = (dbRTBox)sender;
            if (textField.Text.Length == 0) return;

            currIdx.Index = textField.GetCharIndexFromPosition(e.Location);

            currIdx.Initialize(textField);

            if (currIdx.Index > initIdx.Index)
            {
                startIndex = initIdx.Index;
                selectionLength = currIdx.LineIndexStart >= initIdx.Index ? currIdx.LineIndexEnd - initIdx.Index : currIdx.Index - initIdx.Index;
            }
            else
            {
                startIndex = initIdx.LineIndexStart + 2 > currIdx.Index ? initIdx.LineIndexEnd : initIdx.Index;
                selectionLength = currIdx.Index - startIndex;
            }
            textField.Select(startIndex, selectionLength);
        }

        SelectionIndexer currIdx = new SelectionIndexer();
        SelectionIndexer initIdx = new SelectionIndexer();
        int startIndex, selectionLength;
        bool selecting;

        private class SelectionIndexer
        {
            private int _index;
            public int Index            { get{ return _index; } set { PreviousIndex = _index; _index = value; }}
            public int PreviousIndex    { get; set; }
            public int LineNumber       { get; set; }
            public int LineIndexStart   { get; set; }
            public int LineIndexEnd     { get; set; }

            public SelectionIndexer() {}

            public void CleanLine()
            {
                Index = 0;
                PreviousIndex = 0;
                LineNumber = 0;
                LineIndexStart = 0;
                LineIndexEnd = 0;
            }

            public void Initialize(dbRTBox textField, int index)
            {
                Index = index;
                InitializeIndex(textField, this);
            }

            public void Initialize(dbRTBox textField)
            {
                InitializeIndex(textField, this);
            }

            private static void InitializeIndex(dbRTBox textField, SelectionIndexer indexer)
            {
                indexer.LineNumber = textField.GetLineFromCharIndex(indexer.Index);

                while (indexer.LineNumber > -1)
                {
                    indexer.LineIndexStart = textField.GetFirstCharIndexFromLine(indexer.LineNumber);
                    if (textField.Text[indexer.LineIndexStart] == '\u2022') break;
                    indexer.LineNumber--;
                }
                indexer.LineIndexEnd = textField.Text.IndexOf('\u2022', indexer.LineIndexStart + 1);
                if (indexer.LineIndexEnd < 0) indexer.LineIndexEnd = textField.TextLength;
            }

            public bool IsNotCloseToLine
            {
                get { return Index - LineIndexStart > 2; }
            }

            public bool LineHasChanged
            {
                get { return Index < LineIndexStart || Index > LineIndexEnd; }
            }

            public bool IndexHasChanged
            {
                get { return PreviousIndex != Index; }
            }
        }
    }
}
