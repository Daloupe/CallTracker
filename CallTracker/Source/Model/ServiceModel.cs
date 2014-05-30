
using System.ComponentModel;
using System.Collections.Generic;
using System;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Forms;
//using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class ServiceModel
    {
        public ServiceModel()
        {
            Equipment = String.Empty;
            Node = String.Empty;
        }

        [ProtoMember(1)]
        public string Equipment { get; set; }
        [ProtoMember(2)]
        public string Node { get; set; }
        [ProtoMember(3)]
        public string AVC { get; set; }
        [ProtoMember(4)]
        public string CVC { get; set; }
        [ProtoMember(5)]
        public string CSA { get; set; }
        [ProtoMember(6)]
        public string NNI { get; set; }
        [ProtoMember(7)]
        public string GIS { get; set; }
        [ProtoMember(8)]
        public string Bras { get; set; }

        //public INetworkInfo NetworkInfo { get; set; }
    }
}
