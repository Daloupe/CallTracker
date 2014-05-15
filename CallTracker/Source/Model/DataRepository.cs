using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using CallTracker.Model;
//using CallTracker.Helpers;

using ProtoBuf;

namespace CallTracker.Model
{
    [ProtoContract]
    internal class DataRepository
    {
        [ProtoMember(1)]
        internal List<PasteBind> PasteBinds { get; set; }
        [ProtoMember(2)]
        internal List<CustomerContact> Contacts { get; set; }
        [ProtoMember(3)]
        internal List<LoginsModel> Logins { get; set; }
        //[ProtoMember(4)]
        //internal string CurrentUser { get; set; }

        public DataRepository()
        {
            PasteBinds = new List<PasteBind>();
            Contacts = new List<CustomerContact>();
            Logins = new List<LoginsModel>();
        }
    }
}
