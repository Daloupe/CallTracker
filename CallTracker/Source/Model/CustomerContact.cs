using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using PropertyChanged;
using ProtoBuf;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    public class ContactsList : List<CustomerContact>
    {
        public ContactsList() : base()
        {
            //this.Add(new CustomerContact(0));
            //InsertItem(0, new CustomerContact(0) { Name = "Dick", DN = "0294813387", ICON = "40", Address = new ContactAddress { Number = "6", Street = "ho street", Type = "st" } });
            //Add(new CustomerContact(1) { Name = "Harry", DN = "0294813388", ICON = "60", Address = new ContactAddress { Number = "7", Street = "lo street" } });
        }
    }
    
        
        
    [ImplementPropertyChanged]
    [ProtoContract]
    public class CustomerContact
    {
//#pragma warning disable 67
//        public event PropertyChangedEventHandler PropertyChanged;
//#pragma warning restore 67

        //public static List<string> ContactDataStrings = new List<string>()
        //{ "Name", "Username", "DN", "Mobile", "CMBS", "ICON", "Note", "Address", "PR", "Node"};
        public static List<string> ContactDataOldStrings = new List<string>()
        { "Name", "Username", "DN", "Mobile", "CMBS", 
          "ICON", "Note", "Address", "PR", "Node",
          "AVC", "CVC", "CSA", "NNI", "GSI", "Equipment"};

        public static List<DataBindType> PropertyStrings = new List<DataBindType>()
            {
                new DataBindType("Name", "Name"),
                new DataBindType("Username","Username"),
                new DataBindType("DN","DN"),
                new DataBindType("Mobile","Mobile"),
                new DataBindType("CMBS","CMBS"),
                new DataBindType("ICON", "ICON"),
                new DataBindType("Note", "Note"),
                new DataBindType("Address", "Address"),
                new DataBindType("PR", "Fault.PR"),
                new DataBindType("Node","Service.Node"),
                new DataBindType("AVC","Service.AVC"),
                new DataBindType("CVC","Service.CVC"),
                new DataBindType("CSA","Service.CSA"),
                new DataBindType("NNI","Service.NNI"),
                new DataBindType("GSI","Service.GSI"),
                new DataBindType("Equipment","Service.Equipment"),
            };

        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string Username { get; set; }
        [ProtoMember(4)]
        public string DN { get; set; }
        [ProtoMember(5)]
        public string Mobile { get; set; }
        [ProtoMember(6)]
        public string CMBS { get; set; }
        [ProtoMember(7)]
        public string ICON { get; set; }
        [ProtoMember(8)]
        public string Note { get; set; }
        [ProtoMember(9)]
        public ContactAddress Address { get; set; }
        [ProtoMember(10)]
        public ServiceModel Service { get; set; }
        [ProtoMember(11)]
        public FaultModel Fault { get; set; }
        [ProtoMember(12)]
        public List<ContactStatistics> Contacts { get; set; }

        public CustomerContact()
        {
            Name = String.Empty;
            Username = String.Empty;
            DN = String.Empty;
            Mobile = String.Empty;
            CMBS = String.Empty;
            ICON = String.Empty;

            Address = new ContactAddress();
            Service = new ServiceModel();
            Fault = new FaultModel();
            Contacts = new List<ContactStatistics>();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Situation");
            sb.AppendLine("- ");
            sb.AppendLine("Action");
            sb.AppendLine("- ");
            sb.AppendLine("Outcome");
            sb.AppendLine("- ");
            Note = sb.ToString();

            
        }
    }
}
