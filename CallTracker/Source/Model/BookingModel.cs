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
        public string GetDate
        {
            get { return Date.ToShortDateString() + " " + Timeslot; }
        }
        [ProtoMember(3)]
        public string Timeslot { get; set; }

        public BookingModel()
        {
            Date = DateTime.Today;
            Timeslot = String.Empty;
        }
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
