using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;

using CallTracker.Model;
using CallTracker.DataSets;

namespace CallTracker.Helpers
{
    [ProtoContract(SkipConstructor=true)]    
    [ProtoInclude(10, typeof(NoteItemHeading))]
    [ProtoInclude(11, typeof(NoteItemString))]
    [ProtoInclude(12, typeof(NoteItemBool))]
    [ProtoInclude(13, typeof(AltNoteItemString))]
    [ProtoInclude(14, typeof(NoteItemAcronym))]
    [Serializable]
    public abstract class NoteItem
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public string Property { get; set; }
        [ProtoMember(3)]
        public virtual string Value { get; set; }
        [ProtoMember(4)]
        public string Note { get; set; }

        protected NoteItem(string name, string property, string note)
        {
            Name = name;
            Property = property;
            Note = note;
        }

        protected NoteItem() { }//Name = String.Empty; Note = String.Empty; }

        public virtual string GenerateString() 
        { 
            return String.IsNullOrEmpty(Value) ? Note : String.Format(Note, Value); 
        }
    }

    [ProtoContract]  
    public class NoteItemHeading : NoteItem
    {
        public NoteItemHeading(string name, string property, string note)
            : base(name, property, note) { }

        public NoteItemHeading()
            : base() { }

        public override string GenerateString() 
        {
            return String.Format(Note, Property); 
        }
    }

    [ProtoContract]  
    public class NoteItemString : NoteItem
    {
        public NoteItemString(string name, string property, string note)
            : base(name, property, note) { }

        public NoteItemString()
            : base() { }
    }

    [ProtoContract]  
    public class NoteItemBool : NoteItem
    {
        private string _value;
        [ProtoMember(1)]
        public override string Value { get { return _value; } set
        {
            if (value == "True" || value == "Yes") _value = value;
            else _value = String.Empty;
        } }

        public NoteItemBool(string name, string property, string note)
            : base(name, property, note) { }

        public NoteItemBool()
            : base() { }

        public override string GenerateString()
        {
            return Note;
        }
    }

    [ProtoContract]  
    public class AltNoteItemString : NoteItem
    {
        [ProtoMember(1)]//, OverwriteList = true)
        public List<AltNote> AltNotes { get; set;}

        public AltNoteItemString(string name, string property, List<AltNote> altNotes)
            : base(name, property, String.Empty) 
        { 
            AltNotes = altNotes; 
        }

        public AltNoteItemString()
            : base() { AltNotes = new List<AltNote>(); }
        
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

    [ProtoContract]  
    public class NoteItemAcronym : NoteItem
    {
        [ProtoMember(1)] //, OverwriteList = true
        public Dictionary<string, string> AcronymLookup { get; set; }

        public NoteItemAcronym(string name, string property, string note, Dictionary<string, string> acronymLookup)
            : base(name, property, note)
        {
            AcronymLookup = acronymLookup ?? new Dictionary<string,string>();
        }

        public NoteItemAcronym()
            : base() { AcronymLookup = new Dictionary<string, string>(); }

        public override string GenerateString()
        {
            if(AcronymLookup.ContainsKey(Value))
                return String.Format(Note, AcronymLookup[Value]);

            return String.Format(Note, " ");
        }
    }

    [ProtoContract]  
    public class AltNote
    {
        [ProtoMember(1)]
        public string Name;
        [ProtoMember(2)]
        public string Data;
        [ProtoMember(3)]
        public string Result;
        [ProtoMember(4)]
        public string Note;
        public AltNote(string name, string data, string result, string note)
        {
            Name = name;
            Data = data;
            Result = result;
            Note = note;
        }
        public AltNote()
            : base() { }

    }

    public class ICONNoteGenerator
    {
        //private List<NoteItem> NoteItems;
       //// private Main MainForm;

        private Dictionary<string, NoteItem> NoteItems;

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

            //var PRAltNotes = new List<AltNote>
            //{
            //    new AltNote("Booking.Type", "CRQ", "Tech has been booked for customer requested date: {0}"),
            //    new AltNote("Booking.Type", "FAQ", "Tech has been booked for first available date: {0}"),
            //    new AltNote("Booking.Type", "MDQ", "Tech has been booked for must do quota: {0}"),
            //    new AltNote("Booking.Type", "CM", "Case Management callback has been organized for {0}")
            //};
            
            //NoteItems = new Dictionary<string, NoteItem> 
            //{
            //    {"Situation", new NoteItemHeading(@"Situation", "{0}:")},
            //    {"Name", new NoteItemString("Name", "Spoke with {0}.")},
            //    {"Id", new NoteItemBool("IDok", "ID ok.")},
            //    {"Symptom", new NoteItemAcronym("Fault.Symptom", "Customer is experiencing {0}.", ds.Symptoms.ToDictionary(x => x.IFMSCode, x => x.Description))},
                
            //    {"Action", new NoteItemHeading(@"Action", "{0}:")},
            //    {"Powercycled", new NoteItemBool("Fault.Powercycled", "Powercycled.")},
            //    {"FactoryReset", new NoteItemBool("Fault.FactoryReset", "Factory Reset.")},
            //    {"CheckedCables", new NoteItemBool("Fault.CheckedCables", "Checked Cables.")},
            //    {"CheckedNode", new NoteItemBool("Fault.CheckedNodeForOfflines", "Checked Node in SCAMPS for offlines.")},
            //    {"WifiChannel", new NoteItemBool("Fault.ChangedWiFiChannel", "Changed WiFi Channel.")},
            //    {"ModemStatus", new NoteItemString("Service.ModemStatus", "Modem is {0}.")},
            //    {"RFIssues", new NoteItemBool("Service.RFIssues", "Systems show RF Issues.")},
            //    {"SpeedTest", new NoteItemString("Service.DownloadSpeed", "Speed test shows download speed of {0}mbps.")},
            //    {"Throttled", new NoteItemString("Service.Throttled", "Service is currently {0}.")},
            //    {"ErrorMessage", new NoteItemString("Service.DTVMsg", "Customer is seeing error message: {0}.")},
            //    {"ARO", new NoteItemString("Fault.NPR", "Area Outage PR#{0} is currently open.")},
                
            //    {"Outcome", new NoteItemHeading(@"Outcome", "{0}:")},
            //    {"PR", new NoteItemString("Fault.PR", "PR#{0} has been raised.")},
            //    {"Booking", new AltNoteItemString("Booking.GetDateAndTimeslot", PRAltNotes)}
            //};

            //NoteItems = new List<NoteItem>
            //{
            //    new NoteItemHeading(@"Situation", "{0}:"),
            //    new NoteItemString("Name", "Spoke with {0}."),
            //    new NoteItemBool("IDok", "ID ok."),
            //    new NoteItemAcronym("Fault.Symptom", "Customer is experiencing {0}.", ds.Symptoms.ToDictionary(x => x.IFMSCode, x => x.Description)),
                
            //    new NoteItemHeading(@"Action", "{0}:"),
            //    new NoteItemBool("Fault.Powercycled", "Powercycled."),
            //    new NoteItemBool("Fault.FactoryReset", "Factory Reset."),
            //    new NoteItemBool("Fault.CheckedCables", "Checked Cables."),
            //    new NoteItemBool("Fault.CheckedNodeForOfflines", "Checked Node in SCAMPS for offlines."),
            //    new NoteItemBool("Fault.ChangedWiFiChannel", "Changed WiFi Channel."),
            //    new NoteItemString("Service.ModemStatus", "Modem is {0}."),
            //    new NoteItemBool("Service.RFIssues", "Systems show RF Issues."),
            //    new NoteItemString("Service.DownloadSpeed", "Speed test shows download speed of {0}mbps."),
            //    new NoteItemString("Service.Throttled", "Service is currently {0}."),
            //    new NoteItemString("Service.DTVMsg", "Customer is seeing error message: {0}."),
            //    new NoteItemString("Fault.NPR", "Area Outage PR#{0} is currently open."),
                
            //    new NoteItemHeading(@"Outcome", "{0}:"),
            //    new NoteItemString("Fault.PR", "PR#{0} has been raised."),
            //    new AltNoteItemString("Booking.GetDateAndTimeslot", PRAltNotes)
            //};
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
            var sb = new StringBuilder();
            sb.Append(@"{\rtf1\ansi{\colortbl;\red75\green70\blue85;}");
            sb.Append(CycleNotes(contact.NotesSituation, contact));
            sb.Append(CycleNotes(contact.NotesAction, contact));
            sb.Append(CycleNotes(contact.NotesOutcome, contact));
            sb.Append(@"\cf0}");
            return sb.ToString();
        }

        public string GenerateRTFNote(List<NoteItem> items, CustomerContact contact)
        {
            var sb = new StringBuilder();
            sb.AppendLine(@"{\rtf1\ansi{\colortbl;\red75\green70\blue85;}{\cf0 ");
            foreach (var item in items)
            {
                if (item.GetType() != typeof(NoteItemHeading))
                {
                    if (!String.IsNullOrEmpty(item.Property))
                    {
                        item.Value = FindProperty.FollowPropertyPath(contact, item.Property);

                        if (item.GetType() == typeof(AltNoteItemString))
                            ((AltNoteItemString)item).GenerateNote(contact);

                        if (!String.IsNullOrEmpty(item.Value))
                            sb.AppendLine(@"{\pard\keepn\protect\bullet  \protect0 " + item.GenerateString() + @"{\protect\v |" + item.Name + @"\protect0}\par}"); //{\v " + item.Name + "} 
                    }else
                    {
                        sb.AppendLine(@"{\pard\keepn\protect\bullet  \protect0 " + item.GenerateString() + @"{\protect\v |" + item.Name + @"\protect0}\par}"); //{\v " + item.Name + "}
                    }
                }
            }
            sb.Append(@"\cf0}");
            return sb.ToString();
        }

        private StringBuilder CycleNotes(List<NoteItem> items, CustomerContact contact)
        {
            var sb = new StringBuilder();
            foreach (var item in items)
            {
                if (item.GetType() != typeof(NoteItemHeading))
                {
                    item.Value = FindProperty.FollowPropertyPath(contact, item.Property);

                    if (item.GetType() == typeof(AltNoteItemString))
                        ((AltNoteItemString)item).GenerateNote(contact);

                    if (!String.IsNullOrEmpty(item.Value))
                        sb.AppendLine(@"\line\bullet {\v " + item.Name + "} " + item.GenerateString());
                }
                else
                {
                    sb.Append(@"{\pard\li200\fi-200 ");
                    sb.AppendLine(@"\cf1 " + item.GenerateString() + @"\cf0 ");
                }
            }

            sb.Append(@"\par}");
            return sb;
        }

        public string GenerateHTMLNoteManually(CustomerContact contact)
        {
            var sb = new StringBuilder();
            sb.Append(CycleHTMLNotes(contact.NotesSituation,contact));
            sb.Append(CycleHTMLNotes(contact.NotesAction,contact));
            sb.Append(CycleHTMLNotes(contact.NotesOutcome,contact));
            return sb.ToString();
        }

        public string GenerateHTMLNote(List<NoteItem> items, CustomerContact contact)
        {
            var sb = new StringBuilder();
            sb.Append(CycleHTMLNotes(items, contact));
            return sb.ToString();
        }

        public StringBuilder CycleHTMLNotes(List<NoteItem> items, CustomerContact contact)
        {
            var sb = new StringBuilder();
            foreach (var item in items)
            {
                if (item.GetType() != typeof(NoteItemHeading))
                {
                    item.Value = FindProperty.FollowPropertyPath(contact, item.Property);

                    if (item.GetType() == typeof(AltNoteItemString))
                        ((AltNoteItemString)item).GenerateNote(contact);

                    if (!String.IsNullOrEmpty(item.Value))
                        sb.AppendLine("<li>" + item.GenerateString());
                }
                else
                {
                    sb.AppendLine("<p><b>" + item.GenerateString() + "</b>");
                    sb.AppendLine("<ul>");
                }
            }
            sb.AppendLine("</ul>");

            return sb;
        }
    }
}
