using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

using System.Windows.Forms;

using CallTracker.Model;
using CallTracker.View;

namespace CallTracker.Helpers
{
    abstract class NoteItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Note { get; set; }

        public NoteItem(string _name, string _note)
        {
            Name = _name;
            Note = _note;
        }

        public virtual string GenerateString() { return String.Format(Note, Value); }
    }

    class NoteItemHeading : NoteItem
    {
        public NoteItemHeading(string _name, string _note)
            : base(_name, _note) { }

        public override string GenerateString() { return String.Format(Note, Name); }
    }

    class NoteItemString : NoteItem
    {
        public NoteItemString(string _name, string _note)
            : base(_name, _note){}
    }

    class NoteItemAcronym : NoteItem
    {
        private Dictionary<string, string> AcronymLookup;

        public NoteItemAcronym(string _name, string _note, Dictionary<string, string> _acronymLookup)
            : base(_name, _note)
        {
            AcronymLookup = _acronymLookup;
        }

        public override string GenerateString()
        {
            return String.Format(Note, AcronymLookup[Value]);
        }
    }

    public class ICONNoteGenerator
    {
        private List<NoteItem> NoteItems;
        private Main MainForm;

        public ICONNoteGenerator(Main _mainForm)
        {
            MainForm = _mainForm;

            Dictionary<string, string> Symptoms= new Dictionary<string, string>
            {
                {"NDT", "No Dial Tone"},
                {"COS", "Cut Off Speaking"},
                {"LIC", "Internet Drop Outs"},
                {"CCI", "Loss of Internet"},
                {"MSG", "Foxtel On Screen Errors"}
            };

            NoteItems = new List<NoteItem>();
            NoteItems.Add(new NoteItemHeading("Situation", "{0}:"));
            NoteItems.Add(new NoteItemAcronym("Fault.Symptom",  "- Customer is experiencing {0}", Symptoms));
            NoteItems.Add(new NoteItemHeading("Action", "{0}:"));
            NoteItems.Add(new NoteItemString("Name", "- Name:{0}"));
            NoteItems.Add(new NoteItemHeading("Outcome", "{0}:"));
            //NoteItems.Add(new NoteItemString("", "- "));

        }

        public void OnContactChange(object sender, EventArgs args)
        {
            foreach(var nitem in NoteItems)
                nitem.Value = FindProperty.FollowPropertyPath(((BindingSource)sender).Current, nitem.Name);
            Console.WriteLine(GenerateNote());
        }

        public void OnDataFieldChange(object sender, ListChangedEventArgs args)
        {
            if (args.ListChangedType != ListChangedType.ItemChanged)
                return;

            NoteItem _item = NoteItems.Find(x => x.Name == args.PropertyDescriptor.Name);
            if (_item != null)
            {
                _item.Value = args.PropertyDescriptor.GetValue(((BindingSource)sender).Current).ToString();
                Console.WriteLine(GenerateNote());
            }
        }

        public string GenerateNote()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var noteItem in NoteItems)
                if (!String.IsNullOrEmpty(noteItem.Value))
                    sb.AppendLine(noteItem.GenerateString());
                else if(noteItem.GetType() == typeof(NoteItemHeading))
                    sb.AppendLine(noteItem.GenerateString());

            return sb.ToString();
        }
    }
}
