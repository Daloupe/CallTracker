using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CallTracker.Model;
using CallTracker.DataSets;

namespace CallTracker.Helpers
{
    abstract class NoteItem
    {
        public string Name { get; set; }
        public virtual string Value { get; set; }
        public string Note { get; set; }

        protected NoteItem(string name, string note)
        {
            Name = name;
            Note = note;
        }

        public virtual string GenerateString() 
        { 
            return String.Format(Note, Value); 
        }
    }

    class NoteItemHeading : NoteItem
    {
        public NoteItemHeading(string name, string note)
            : base(name, note) { }

        public override string GenerateString() 
        { 
            return String.Format(Note, Name); 
        }
    }

    class NoteItemString : NoteItem
    {
        public NoteItemString(string name, string note)
            : base(name, note){}
    }
    class NoteItemBool : NoteItem
    {
        private string _value;
        public override string Value { get { return _value; } set
        {
            if (value == "True" || value == "Yes") _value = value;
            else _value = String.Empty;
        } }

        public NoteItemBool(string name, string note)
            : base(name, note) { }

        public override string GenerateString()
        {
            return Note;
        }
    }

    class AltNoteItemString : NoteItem
    {
        List<AltNote> AltNotes;

        public AltNoteItemString(string name, List<AltNote> altNotes)
            : base(name, String.Empty) 
        { 
            AltNotes = altNotes; 
        }
        
        public void GenerateNote(CustomerContact contact)
        {
            foreach (var alt in AltNotes)
            {
                if (FindProperty.FollowPropertyPath(contact, alt.Data) == alt.Result)
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

        public NoteItemAcronym(string name, string note, Dictionary<string, string> acronymLookup)
            : base(name, note)
        {
            AcronymLookup = acronymLookup ?? new Dictionary<string,string>();
        }

        public override string GenerateString()
        {
            if(AcronymLookup.ContainsKey(Value))
                return String.Format(Note, AcronymLookup[Value]);

            return String.Format(Note, " ");
        }
    }


    public class AltNote
    {
        public string Data;
        public string Result;
        public string Note;
        public AltNote(string data, string result, string note)
        {
            Data = data;
            Result = result;
            Note = note;
        }
    }

    public class ICONNoteGenerator
    {
        private List<NoteItem> NoteItems;
       // private Main MainForm;

        public ICONNoteGenerator(ServicesDataSet ds)
        {
            //MainForm = _mainForm;

            //Dictionary<string, string> Symptoms= new Dictionary<string, string>
            //{
            //    {"NDT", "No Dial Tone"},
            //    {"NRR", "No Rings Recieved"},
            //    {"DTN", "Distortion on the lind"},
            //    {"DRP", "Drop Cable Down"},
            //    {"COS", "Cut Off Speaking"},
            //    {"LIC", "Internet Drop Outs"},
            //    {"CCI", "Loss of Internet"},
            //    {"MSG", "Foxtel On Screen Errors"}
            //};

            var PRAltNotes = new List<AltNote>
            {
                new AltNote("Booking.Type", "CRQ", "- Tech has been booked for customer requested date: {0}"),
                new AltNote("Booking.Type", "FAQ", "- Tech has been booked for first available date: {0}"),
                new AltNote("Booking.Type", "MDQ", "- Tech has been booked for must do quota: {0}"),
                new AltNote("Booking.Type", "CM", "- Case Management callback has been organized for {0}")
            };

            NoteItems = new List<NoteItem>();
            NoteItems.Add(new NoteItemHeading(@"\cf1 Situation\cf0 ", "{0}:"));
            NoteItems.Add(new NoteItemString("Name", "- Spoke with {0}."));
            NoteItems.Add(new NoteItemBool("IDok", "- ID ok."));
            NoteItems.Add(new NoteItemAcronym("Fault.Symptom", "- Customer is experiencing {0}.", ds.Symptoms.ToDictionary(x => x.IFMSCode, x => x.Description)));
            NoteItems.Add(new NoteItemHeading(@"\cf1 Action\cf0 ", "{0}:"));
            NoteItems.Add(new NoteItemBool("Fault.Powercycled", "- Powercycled."));
            NoteItems.Add(new NoteItemBool("Fault.FactoryReset", "- Factory Reset."));
            NoteItems.Add(new NoteItemBool("Fault.CheckedCables", "- Checked Cables."));
            NoteItems.Add(new NoteItemBool("Fault.CheckedNodeForOfflines", "- Checked Node in SCAMPS for offlines."));
            NoteItems.Add(new NoteItemBool("Fault.ChangedWiFiChannel", "- Changed WiFi Channel."));
            NoteItems.Add(new NoteItemString("Service.ModemStatus", "- Modem is {0}."));
            NoteItems.Add(new NoteItemBool("Service.RFIssues", "- Systems show RF Issues."));
            NoteItems.Add(new NoteItemString("Service.DownloadSpeed", "- Speed test shows download speed of {0}mbps."));
            NoteItems.Add(new NoteItemString("Service.Throttled", "- Service is currently throttled."));
            NoteItems.Add(new NoteItemString("Service.DTVMsg", "- Customer is seeing error message: {0}."));
            NoteItems.Add(new NoteItemString("Fault.NPR", "- Area Outage PR#{0} is currently open."));
            NoteItems.Add(new NoteItemHeading(@"\cf1 Outcome\cf0 ", "{0}:"));
            NoteItems.Add(new NoteItemString("Fault.PR", "- PR#{0} has been raised."));
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


        public string GenerateNoteManually(CustomerContact contact)
        {
            //var contact = _contact;

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

            var sb = new StringBuilder();
            sb.Append(@"{\rtf1\ansi{\colortbl;\red75\green70\blue85;}");
            foreach (var noteItem in NoteItems)
            {
                if (!String.IsNullOrEmpty(noteItem.Value))
                {
                    sb.AppendLine(noteItem.GenerateString());
                    sb.Append(@"\line ");
                }
                else if (noteItem.GetType() == typeof (NoteItemHeading))
                {
                    sb.AppendLine(noteItem.GenerateString());
                    sb.Append(@"\line ");
                }

            }

            sb.Append(@"\cf0}");
            return sb.ToString();
        }
    }
}
