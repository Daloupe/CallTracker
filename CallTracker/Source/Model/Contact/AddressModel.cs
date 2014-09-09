using PropertyChanged;
using System;
using System.Linq;

using ProtoBuf;
using System.Text.RegularExpressions;
using Utilities.RegularExpressions;

using CallTracker.View;
namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]//(SkipConstructor = true)]
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

        //[ProtoBeforeDeserialization]
        //private void FieldInitializer()
        //{

        //}

        [ProtoMember(9)]
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

                //var split1 = Regex.Split(value, @".(\d{4})$");

                //if (split1.Length > 1)
                //{ 
                //    Postcode = split1[1];
                //    var query = (from a in Main.ServicesStore.servicesDataSet.States
                //                where a.Postcode == Postcode.Substring(0,1) ||
                //                      a.Postcode == Postcode.Substring(0,2)
                //                select a).OrderBy(x => x.Postcode.Length).LastOrDefault();
                //    if(query != null)
                //        State = query.NameShort;
                //}

                //var split2 = Regex.Split(split1[0], @"(Victoria|Tasmania|Queensland|New South Wales|(?:South|Western) Australia|(?:Northern|Australian Capital) Territory|VIC|NSW|SA|WA|NT|TAS|ACT|QLD)", RegexOptions.IgnoreCase);

                //if (split2.Length > 1)
                //{
                //    var query = (from a in Main.ServicesStore.servicesDataSet.States
                //                 where a.NameShort.ToLower() == split2[1].ToLower() ||
                //                       a.NameLong.ToLower() == split2[1].ToLower()
                //                 select a).First();
                //    if(query != null)
                //        State = query.NameShort;
                //}

                //var addressMatch = new AddressPattern().Match(split2[0]);

                ////Console.WriteLine();
                ////Match AddressMatch = Pattern.Match(value);
                ////if (AddressMatch.Success == false)
                ////    return;

                var addressMatch = new Address2Pattern().Match(value);

                PropertyType = addressMatch.Groups["PropertyType"].Value;
                UnitNumber = addressMatch.Groups["Unit"].Value;
                PropertyNumber = addressMatch.Groups["Number"].Value;
                StreetName = addressMatch.Groups["Street"].Value;
                StreetType = addressMatch.Groups["StreetType"].Value;
                Suburb = addressMatch.Groups["Suburb"].Value;
                State = addressMatch.Groups["State"].Value;
                Postcode = addressMatch.Groups["Postcode"].Value;

                Console.WriteLine("PropertyType:{0}", PropertyType);
                Console.WriteLine("UnitNumber:{0}", UnitNumber);
                Console.WriteLine("PropertyNumber:{0}", PropertyNumber);
                Console.WriteLine("StreetName:{0}", StreetName);
                Console.WriteLine("StreetType:{0}", StreetType);
                Console.WriteLine("Suburb:{0}", Suburb);
                Console.WriteLine("State:{0}", State);
                Console.WriteLine("Postcode:{0}", Postcode);
                ////Console.WriteLine("6:{0}", addressMatch.Groups[9].Value);
                ////Console.WriteLine("6:{0}", addressMatch.Groups[10].Value);
                ////Console.WriteLine("6:{0}", addressMatch.Groups[11].Value);
                //address = split2[0];

                address = value;
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

        public bool FindAddressMatch(string text)
        {
            var match = Pattern.Match(text);
            if (match.Success)
            {
                Address = text;
                Main.FadingToolTip.ShowandFade("Address: " + Address);
                return true;
            };
            return false;
        }
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
