using PropertyChanged;
using System.ComponentModel;
using System.Collections.Generic;
using System;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Forms;
//using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using ProtoBuf;
using System.Text.RegularExpressions;
using Utilities.RegularExpressions;

using CallTracker.View;
namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class ContactAddress
    {
        public static Address2Pattern Pattern = new Address2Pattern();

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

        public ContactAddress()
        {
        }
        
        private string address;
        public string Address
        {
            get { return address; }
            set 
            {
                PropertyType = String.Empty;
                UnitNumber = String.Empty;
                PropertyNumber = String.Empty;
                StreetName = String.Empty;
                StreetType = String.Empty;
                Suburb = String.Empty;
                //State = String.Empty;
                Postcode = String.Empty;

                string[] split1 = Regex.Split(value, @".(\d{4})$");

                if (split1.Length > 1)
                { 
                    Postcode = split1[1];
                    State = (from a in Main.ServicesStore.servicesDataSet.States
                            where a.Postcode == Postcode.Substring(0,1) ||
                                  a.Postcode == Postcode.Substring(0,2)
                            select a).OrderBy(x => x.Postcode.Length).Last().NameShort;
                }

                string[] split2 = Regex.Split(split1[0], @"(Victoria|Tasmania|Queensland|New South Wales|(?:South|Western) Australia|(?:Northern|Australian Captial) Territory|VIC|NSW|SA|WA|NT|TAS|ACT|QLD)", RegexOptions.IgnoreCase);

                if (split2.Length > 1)
                    State = (from a in Main.ServicesStore.servicesDataSet.States
                             where a.NameShort.ToLower() == split2[1].ToLower() ||
                                   a.NameLong.ToLower() == split2[1].ToLower()
                             select a).First().NameShort;

                Match AddressMatch = new AddressPattern().Match(split2[0]);

                //Console.WriteLine();
                //Match AddressMatch = Pattern.Match(value);
                //if (AddressMatch.Success == false)
                //    return;
                PropertyType = AddressMatch.Groups[1].Value;
                UnitNumber = AddressMatch.Groups[2].Value;
                PropertyNumber = AddressMatch.Groups[3].Value;
                StreetName = AddressMatch.Groups[4].Value;
                StreetType = AddressMatch.Groups[5].Value;
                Suburb = AddressMatch.Groups[6].Value;
                //State = AddressMatch.Groups[7].Value;
                //Postcode = AddressMatch.Groups[8].Value;

                //Console.WriteLine("1:{0}", PropertyType);
                //Console.WriteLine("2:{0}", UnitNumber);
                //Console.WriteLine("3:{0}", PropertyNumber);
                //Console.WriteLine("4:{0}", StreetName);
                //Console.WriteLine("4:{0}", StreetType);
                //Console.WriteLine("4:{0}", Suburb);
                //Console.WriteLine("5:{0}", State);
                //Console.WriteLine("6:{0}", Postcode);
                //Console.WriteLine("6:{0}", AddressMatch.Groups[9].Value);
                //Console.WriteLine("6:{0}", AddressMatch.Groups[10].Value);
                //Console.WriteLine("6:{0}", AddressMatch.Groups[11].Value);
                address = split2[0];
            } 
        }
        //public List<String> States = new List<string>{
        //        "Victoria", "New South Wales", "Queensland", "South Australia", "Northern Territory", "Western Australia", "Australian Capital Territory",
        //        "VIC", "NSW", "QLD", "SA", "TAS", "NT", "WA", "ACT"
        //};
        //public List<String> Streets = new List<string>{
        //        "st", "rd", "ave", "hwy", "cct", "ct", "cl","gr",
        //        "street","road","avenue", "highway","circuit","court","close","grove"
        //};
    }

    //public enum AddressType
    //{
    //    st, rd, ave, cct
    //}

    //public enum AddressState
    //{
    //    VIC, NSW, QLD, SA, TAS, NT, WA, ACT
    //}

}
