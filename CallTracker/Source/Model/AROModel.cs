using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    [ProtoContract]
    [ImplementPropertyChanged]
    class AROModel
    {
        [ProtoMember(1)]
        public string Suburb { get; set; }
        [ProtoMember(2)]
        public string Node { get; set; }
        [ProtoMember(3)]
        public string PR { get; set; }
        [ProtoMember(4)]
        public string Date { get; set; }
        [ProtoMember(5)]
        public int AffectedServices { get; set; }
    }

    public enum ServiceTypes
    {
        LAT = 1,
        LIP = 1 << 2,
        ONC = 1 << 3,
        NBN = 1 << 4,
        NVF = 1 << 5,
        DTV = 1 << 6,
        MTV = 1 << 7
    }
}
