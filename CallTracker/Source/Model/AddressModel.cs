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

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class ContactAddress
    {
        [ProtoMember(1)]
        public string Unit { get; set; }
        [ProtoMember(2)]
        public string Number { get; set; }
        [ProtoMember(3)]
        public string Street { get; set; }
        [ProtoMember(4)]
        public string Type { get; set; }
        [ProtoMember(5)]
        public string Suburb { get; set; }
        [ProtoMember(6)]
        public string State { get; set; }
        [ProtoMember(7)]
        public string Postcode { get; set; }

        protected Dictionary<Func<string>, string> AddressFields;
        
        public ContactAddress()
        {
            AddressFields = new Dictionary<Func<string>, string>
            {
                {() => Unit, "/"},
                {() => Number, " "},
                {() => Street, " "},
                {() => Type, " "},
                {() => Suburb, " "},
                {() => State, " "},
                {() => Postcode, ""}
            };
        }
        private List<string> PropList = new List<string>() {"Number", "Street", "Type", "Suburb", "State", "Postcode" };
        private string address;
        public string Address
        {
            get
            {
                return address;
                //StringBuilder _address = new StringBuilder();

                //foreach (var field in AddressFields)
                //{
                //    string key = field.Key.Invoke();
                //    if (!String.IsNullOrEmpty(key))
                //        _address.Append(key + field.Value);
                //}

                //return _address.ToString();
            }
            set 
            {
                address = value;
                //MatchCollection address = Regex.Matches(value, @"[Unit|Level]?([-|/]?:\d+)?\w+");

                //for (var i = 0; i < address.Count; i++)
                //{

                //    if (address[i].Value == "Unit" || address[i].Value == "Level")
                //    {
                //        i++;
                //        continue;
                //    }
                //    else if (char.IsDigit(address[i].Value, 0) && char.IsDigit(address[i + 1].Value, 0))
                //        continue;

                //    PropertyInfo prop = this.GetType().GetProperty(PropList[i]);
                //    prop.SetValue(this, address[i].Value, null);

                //}
                //if (address != null)
                //    if (address[0].Value == "Unit" || address[0].Value == "Level")
                //        Number = address[0].Value;
                //Street = address[1].Value;
                //Type = address[2].Value;
                //Suburb = address[3].Value;
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
