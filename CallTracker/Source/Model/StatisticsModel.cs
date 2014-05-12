using System;
using System.Collections.Generic;

using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class ContactStatistics
    {
        [ProtoMember(1)]
        public DateTime Start { get; set; }
        [ProtoMember(2)]
        public DateTime End { get; set; }
        [ProtoMember(3)]
        public List<CallStatistics> Call { get; set; }
    }

    [ImplementPropertyChanged]
    [ProtoContract]
    public class CallStatistics
    {
        [ProtoMember(1)]
        public DateTime Start { get; set; }
        [ProtoMember(2)]
        public DateTime End { get; set; }
        [ProtoMember(3)]
        public int DialledNumber { get; set; }
    }
}
