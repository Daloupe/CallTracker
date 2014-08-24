using System;

using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    //[ImplementPropertyChanged]
    [ProtoContract]
    public class ContactStatistics
    {
        [ProtoMember(1)]
        public DateTime StartDate { get; set; }
        [ProtoMember(2)]
        public TimeSpan StartTime { get; set; }
        //[ProtoMember(3)]
        //public List<CallStatistics> Call { get; set; }

        public string GetDate 
        {
            get
            {
                return StartDate.ToShortDateString();
            }
        }

        public ContactStatistics()
        {
            StartDate = new DateTime();
            StartTime = new TimeSpan();
        }
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
