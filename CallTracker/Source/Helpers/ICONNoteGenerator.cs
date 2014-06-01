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

        public virtual string GenerateString() 
        { 
            return String.Format(Note, Value); 
        }
    }

    class NoteItemHeading : NoteItem
    {
        public NoteItemHeading(string _name, string _note)
            : base(_name, _note) { }

        public override string GenerateString() 
        { 
            return String.Format(Note, Name); 
        }
    }

    class NoteItemString : NoteItem
    {
        public NoteItemString(string _name, string _note)
            : base(_name, _note){}
    }

    class AltNoteItemString : NoteItem
    {
        List<AltNote> AltNotes;

        public AltNoteItemString(string _name, List<AltNote> _altNotes)
            : base(_name, String.Empty) 
        { 
            AltNotes = _altNotes; 
        }
        
        public void GenerateNote(CustomerContact _contact)
        {
            foreach (var alt in AltNotes)
            {
                if (FindProperty.FollowPropertyPath(_contact, alt.Data) == alt.Result)
                {
                    Note = alt.Note;
                    return;
                }
            }
            Value = String.Empty;
        }
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


    public class AltNote
    {
        public string Data;
        public string Result;
        public string Note;
        public AltNote(string _data, string _result, string _note)
        {
            Data = _data;
            Result = _result;
            Note = _note;
        }
    }

    public class ICONNoteGenerator
    {
        private List<NoteItem> NoteItems;
       // private Main MainForm;

        public ICONNoteGenerator()//Main _mainForm)
        {
            //MainForm = _mainForm;

            Dictionary<string, string> Symptoms= new Dictionary<string, string>
            {
                {"NDT", "No Dial Tone"},
                {"NRR", "No Rings Recieved"},
                {"DTN", "Distortion on the lind"},
                {"DRP", "Drop Cable Down"},
                {"COS", "Cut Off Speaking"},
                {"LIC", "Internet Drop Outs"},
                {"CCI", "Loss of Internet"},
                {"MSG", "Foxtel On Screen Errors"}
            };

            List<AltNote> PRAltNotes = new List<AltNote>
            {
                new AltNote("Fault.Outcome", "PR", "- Tech has been booked for {0}"),
                new AltNote("Fault.Outcome", "CM", "- Case Management callback has been organized for {0}")
            };

            NoteItems = new List<NoteItem>();
            NoteItems.Add(new NoteItemHeading("Situation", "{0}:"));
            NoteItems.Add(new NoteItemString("Name", "- Spoke with {0}"));
            NoteItems.Add(new NoteItemAcronym("Fault.Symptom", "- Customer is experiencing {0}", Symptoms));
            NoteItems.Add(new NoteItemHeading("Action", "{0}:"));
            NoteItems.Add(new NoteItemString("Fault.NPR", "- Area Outage PR#{0} is currently open."));
            NoteItems.Add(new NoteItemString("Service.DownloadSpeed", "- Speed test shows download speed of {0}mbps."));
            NoteItems.Add(new NoteItemString("Service.Throttled", "- Service is currently throttled."));
            NoteItems.Add(new NoteItemString("Service.DTVMsg", "- Customer is seeing error message: {0}"));
            NoteItems.Add(new NoteItemHeading("Outcome", "{0}:"));
            NoteItems.Add(new NoteItemString("Fault.PR", "- PR#{0} has been raised"));
            NoteItems.Add(new AltNoteItemString("Booking.GetDate", PRAltNotes));
        }

        //public void OnContactChange(object sender, EventArgs args)
        //{
        //    CustomerContact contact = ((BindingSource)sender).Current as CustomerContact;
        //    foreach (var noteItem in NoteItems)
        //        if (noteItem.GetType() != typeof(NoteItemHeading))
        //            noteItem.Value = FindProperty.FollowPropertyPath(contact, noteItem.Name);
        //    //contact.ICONNote = GenerateNote();
        //}

        //public void OnDataFieldChange(object sender, ListChangedEventArgs args)
        //{
        //    if (args.ListChangedType != ListChangedType.ItemChanged)
        //        return;

        //    CustomerContact contact = ((BindingSource)sender).Current as CustomerContact;

        //    NoteItem _item = NoteItems.Find(x => x.Name == args.PropertyDescriptor.Name);
        //    if (_item != null)
        //    {
        //        _item.Value = args.PropertyDescriptor.GetValue(contact).ToString();
        //        //contact.ICONNote = GenerateNote();
        //    }
        //}

        //public string GenerateNote()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    foreach(var noteItem in NoteItems)
        //        if (!String.IsNullOrEmpty(noteItem.Value))
        //            sb.AppendLine(noteItem.GenerateString());
        //        else if (noteItem.GetType() == typeof(NoteItemHeading))
        //            sb.AppendLine(noteItem.GenerateString());
                    

        //    return sb.ToString();
        //}


        public string GenerateNoteManually(CustomerContact _contact)
        {
            CustomerContact contact = _contact;

            foreach (var noteItem in NoteItems)
                if (noteItem.GetType() != typeof(NoteItemHeading))
                {
                    noteItem.Value = FindProperty.FollowPropertyPath(contact, noteItem.Name);
                    if (noteItem.GetType() == typeof(AltNoteItemString))
                        ((AltNoteItemString)noteItem).GenerateNote(contact);
                }

            //if (_contact.Fault.Outcome == Enum.GetName(typeof(Outcomes), Outcomes.PR))
            //    NoteItems.Find(x => x.Name == "Booking.GetDate").Note = "- Tech has been booked for {0}";
            //else if (_contact.Fault.Outcome == Enum.GetName(typeof(Outcomes), Outcomes.CM))
            //    NoteItems.Find(x => x.Name == "Booking.GetDate").Note = "- Case Management callback has been organized for {0}";
            //else
            //    NoteItems.Find(x => x.Name == "Booking.GetDate").Value = String.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (var noteItem in NoteItems)
                if (!String.IsNullOrEmpty(noteItem.Value))
                    sb.AppendLine(noteItem.GenerateString());
                else if (noteItem.GetType() == typeof(NoteItemHeading))
                    sb.AppendLine(noteItem.GenerateString());


            return sb.ToString();
        }
    }
}
