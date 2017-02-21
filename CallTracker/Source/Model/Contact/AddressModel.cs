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
        public static AddressPattern Pattern = new AddressPattern();

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

        //[ProtoAfterDeserialization]
        //private void PostInit()
        //{
        //    //Don't store each address part, just refind the matches after init.
        //    Address = address;
        //}

        [ProtoMember(9)]
        private string address;
        public string Address
        {
            get { return address; }
            set 
            {
                //PropertyType = String.Empty;
                //UnitNumber = String.Empty;
                //PropertyNumber = String.Empty;
                //StreetName = String.Empty;
                //StreetType = String.Empty;
                //Suburb = String.Empty;
                ////State = String.Empty;
                //Postcode = String.Empty;

                //var split1 = Regex.Split(value, @".((?<Postcode>\d{4})(\s*Australia)?)$", RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);

                //if (split1.Length > 1)
                //{
                //    Postcode = split1[1].Substring(0,4);
                //    var query = (from a in Main.ServicesStore.servicesDataSet.States
                //                 where a.Postcode == Postcode.Substring(0, 1) ||
                //                       a.Postcode == Postcode.Substring(0, 2)
                //                 select a).OrderBy(x => x.Postcode.Length).LastOrDefault();
                //    if (query != null)
                //        State = query.NameShort;
                //}

                //var split2 = Regex.Split(split1[0], @"(Victoria|Tasmania|Queensland|New South Wales|(?:South|Western) Australia|(?:Northern|Australian Capital) Territory|VIC|NSW|SA|WA|NT|TAS|ACT|QLD)", RegexOptions.IgnoreCase);

                //if (split2.Length > 1)
                //{
                //    var query = (from a in Main.ServicesStore.servicesDataSet.States
                //                 where String.Equals(a.NameShort, split2[1], StringComparison.CurrentCultureIgnoreCase) ||
                //                       String.Equals(a.NameLong, split2[1], StringComparison.CurrentCultureIgnoreCase)
                //                 select a).First();
                //    if (query != null)
                //        State = query.NameShort;
                //}

                //if (String.IsNullOrEmpty(value) || address == value)
                //{
                //    address = value;
                //    return;
                //}

                var addressMatch = Pattern.Match(value);//new AddressPattern().Match(split2[0]));

                //PropertyType = addressMatch.Groups["PropertyType"].Value;
                //UnitNumber = addressMatch.Groups["Unit"].Value;
                //PropertyNumber = addressMatch.Groups["Number"].Value;
                //StreetName = addressMatch.Groups["Street"].Value;
                //StreetType = addressMatch.Groups["StreetType"].Value;
                //Suburb = addressMatch.Groups["Suburb"].Value;
                ////if (addressMatch.Groups["State"].Value != String.Empty)
                ////    State = addressMatch.Groups["State"].Value;
                ////Postcode = addressMatch.Groups["Postcode"].Value;

                ////Console.WriteLine();
                ////Match AddressMatch = Pattern.Match(value);
                ////if (AddressMatch.Success == false)
                ////    return;

                //var addressMatch = new Address2Pattern().Match(value);

                //if (!addressMatch.Success) { }

                PropertyType = addressMatch.Groups["PropertyType"].Value;
                UnitNumber = addressMatch.Groups["Unit"].Value;
                PropertyNumber = addressMatch.Groups["Number"].Value;
                StreetName = addressMatch.Groups["Street"].Value;
                StreetType = addressMatch.Groups["StreetType"].Value;
                Suburb = addressMatch.Groups["Suburb"].Value;
                if (addressMatch.Groups["State"].Value != String.Empty)
                    State = addressMatch.Groups["State"].Value;
                Postcode = addressMatch.Groups["Postcode"].Value;

                //Console.WriteLine("PropertyType:{0}", PropertyType);
                //Console.WriteLine("UnitNumber:{0}", UnitNumber);
                //Console.WriteLine("PropertyNumber:{0}", PropertyNumber);
                //Console.WriteLine("StreetName:{0}", StreetName);
                //Console.WriteLine("StreetType:{0}", StreetType);
                //Console.WriteLine("Suburb:{0}", Suburb);
                //Console.WriteLine("State:{0}", State);
                //Console.WriteLine("Postcode:{0}", Postcode);

                address = value;
            } 
        }

        public bool FindAddressMatch(string text)
        {
            var match = Pattern.Match(text);
            if (match.Success)
            {
                //PropertyType = match.Groups["PropertyType"].Value;
                //UnitNumber = match.Groups["Unit"].Value;
                //PropertyNumber = match.Groups["Number"].Value;
                //StreetName = match.Groups["Street"].Value;
                //StreetType = match.Groups["StreetType"].Value;
                //Suburb = match.Groups["Suburb"].Value;
                //if (String.IsNullOrEmpty(match.Groups["State"].Value))
                //    State = match.Groups["State"].Value;
                //Postcode = match.Groups["Postcode"].Value;

                //address = text;
                Address = text;
                Main.FadingToolTip.ShowandFade("Address: " + Address);
                return true;
            };
            return false;
        }
    }
}
