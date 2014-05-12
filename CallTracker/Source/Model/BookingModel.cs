using System;
using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class BookingModel
    {
        [ProtoMember(1)]
        public BookingType Type { get; set; }
        [ProtoMember(2)]
        public DateTime Date { get; set; }
        [ProtoMember(3)]
        public BookingTimeslot Timeslot { get; set; }
    }

    public enum BookingType
    {
        FAQ, CRQ, MDQ, NRQ
    }

    public enum BookingTimeslot
    {
        AM, PM, EVE
    }
}
