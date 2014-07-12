using PropertyChanged;
using System.ComponentModel;
using System.Collections.Generic;
using System;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Forms;
//using System.Collections.Generic;
using System.Reflection;

using ProtoBuf;
using System.Text.RegularExpressions;
using Utilities.RegularExpressions;


namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class ContactAddress
    {
        [ProtoMember(1)]
        public string PropertyType { get; set; }
        [ProtoMember(2)]
        public string UnitNumber { get; set; }
        [ProtoMember(3)]
        public string PropertyNumber { get; set; }
        [ProtoMember(4)]
        public string StreetName { get; set; }
        [ProtoMember(5)]
        public string StreetType { get; set; }
        [ProtoMember(6)]
        public string Suburb { get; set; }
        [ProtoMember(7)]
        public string State { get; set; }
        [ProtoMember(8)]
        public string Postcode { get; set; }

        //protected Dictionary<Func<string>, string> AddressFields;
        
        public ContactAddress()
        {
            //AddressFields = new Dictionary<Func<string>, string>
            //{
            //    {() => PropertyType, ""},
            //    {() => UnitNumber, "/"},
            //    {() => PropertyNumber, " "},
            //    {() => StreetName, " "},
            //    {() => StreetType, " "},
            //    {() => Suburb, " "},
            //    {() => State, " "},
            //    {() => Postcode, ""}
            //};
        }
        //private List<string> PropList = new List<string>() {"Number", "Street", "Type", "Suburb", "State", "Postcode" };
        private string address;
        public string Address
        {
            get { return address; }
            set 
            {
                AddressPattern rgxAddress = new AddressPattern();
                Match AddressMatch = rgxAddress.Match(value);
                //if (AddressMatch.Success == false)
                //    return;
                PropertyType = AddressMatch.Groups[1].Value;
                UnitNumber = AddressMatch.Groups[2].Value;
                PropertyNumber = AddressMatch.Groups[3].Value;
                StreetName = AddressMatch.Groups[4].Value;
                StreetType = AddressMatch.Groups[5].Value;
                Suburb = AddressMatch.Groups[6].Value;
                State = AddressMatch.Groups[7].Value;
                Postcode = AddressMatch.Groups[8].Value;

                address = value;
            }            
        }
    }

    public enum AddressType
    {
        st, rd, ave, cct
    }

    public enum AddressState
    {
        VIC, NSW, QLD, SA, TAS, NT, WA, ACT
    }

}
