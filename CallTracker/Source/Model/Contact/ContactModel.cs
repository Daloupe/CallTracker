using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Reflection;

using PropertyChanged;
using ProtoBuf;
using Utilities.RegularExpressions;

using CallTracker.View;

namespace CallTracker.Model
{
    [ProtoContract]
    [ImplementPropertyChanged]
    public class CustomerContact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static DNPattern DNPattern = new DNPattern();
        public static ICONPattern ICONPattern = new ICONPattern();
        public static CMBSPattern CMBSPattern = new CMBSPattern();
        public static MobilePattern MobilePattern = new MobilePattern();
        public static UsernameUpperPattern UNUpperPattern = new UsernameUpperPattern();
        public static UsernameLowerPattern UNLowerPattern = new UsernameLowerPattern();

        public static List<DataBindType> PropertyStrings = new List<DataBindType>()
            {
                new DataBindType("Name", "Name"),
                new DataBindType("Username","Username"),
                new DataBindType("DN","DN"),
                new DataBindType("Mobile","Mobile"),
                new DataBindType("CMBS","CMBS"),
                new DataBindType("ICON", "ICON"),
                new DataBindType("Note", "Note"),
                new DataBindType("ICON Note", "ICONNote"),
                new DataBindType("Address", "Address"),
                new DataBindType("PR", "Fault.PR"),
                new DataBindType("NPR", "Fault.NPR"),
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
        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NameSplit.Full = name;
            }
        }
        public string name { get; set; }
        public NameModel NameSplit { get; set; }
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
        public ContactStatistics Contacts { get; set; }
        public DateTime ContactDate { get { return Contacts.StartDate; } }
        public string ContactTime { get { return String.Format("{0:00}:{1:00}", Contacts.StartTime.TotalHours, Contacts.StartTime.Minutes); } }
        [ProtoMember(13)]
        public BookingModel Booking { get; set; }

        public string ICONNote { get { return Main.NoteGen.GenerateNoteManually(this); } set { ; } }

        public CustomerContact()
        {
            NameSplit = new NameModel();
            Name = String.Empty;
            Username = String.Empty;
            DN = String.Empty;
            Mobile = String.Empty;
            CMBS = String.Empty;
            ICON = String.Empty;
            Note = String.Empty;

            Address = new ContactAddress();
            Service = new ServiceModel();
            Fault = new FaultModel();
            Contacts = new ContactStatistics();
            Booking = new BookingModel();

            ((INotifyPropertyChanged)Fault).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)NameSplit).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)Booking).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)Service).PropertyChanged += CustomerContact_PropertyChanged;
        }

        public event PropertyChangedEventHandler NestedChange;


        void CustomerContact_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(NestedChange != null)
                NestedChange(sender, e);
        }

        public CustomerContact(int _id)
        {
            Id = _id;
            NameSplit = new NameModel();
            Name = String.Empty;
            Username = String.Empty;
            DN = String.Empty;
            Mobile = String.Empty;
            CMBS = String.Empty;
            ICON = String.Empty;
            Note = String.Empty;

            Address = new ContactAddress();
            Service = new ServiceModel();
            Fault = new FaultModel();
            Contacts = new ContactStatistics();
            Booking = new BookingModel();

            Contacts.StartDate = DateTime.Today.ToLocalTime();
            Contacts.StartTime = DateTime.Now.TimeOfDay;//.TimeOfDay();

            ((INotifyPropertyChanged)Fault).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)NameSplit).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)Booking).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)Service).PropertyChanged += CustomerContact_PropertyChanged;
        }

        public object GetProperty(string property)
        {
            if (String.IsNullOrEmpty(property)) return null;

            Type currentType = this.GetType();
            object value = this;

            foreach (string propertyName in property.Split('.'))
            {
                PropertyInfo prop = currentType.GetProperty(propertyName);
                if (prop != null)
                {
                    value = prop.GetValue(value, null);
                    currentType = prop.PropertyType;
                }
            }
            return value;
        }

        public void SetProperty(string property, string value)
        {
            if (String.IsNullOrEmpty(property)) return;

            Type currentType = this.GetType();
            PropertyInfo currentObject = null;
            object nestedObject = this;

            string[] propSplit = property.Split('.');

            for (int i = 0; i < propSplit.Length; i++)
            {
                currentObject = currentType.GetProperty(propSplit[i]);
                if (currentObject != null)
                    currentType = currentObject.PropertyType;
                if (i < propSplit.Length - 1)
                    nestedObject = currentObject.GetValue(nestedObject, null);
            }

            if (currentObject != null)
                currentObject.SetValue(nestedObject, value, null);
        }
    }

    //[ImplementPropertyChanged]
    //public class ContactsList : List<CustomerContact>
    //{
    //    public ContactsList() : base()
    //    {
    //        //this.Add(new CustomerContact(0));
    //        //InsertItem(0, new CustomerContact(0) { Name = "Dick", DN = "0294813387", ICON = "40", Address = new ContactAddress { Number = "6", Street = "ho street", Type = "st" } });
    //        //Add(new CustomerContact(1) { Name = "Harry", DN = "0294813388", ICON = "60", Address = new ContactAddress { Number = "7", Street = "lo street" } });
    //    }
    //}
}
