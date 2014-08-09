using System;
using System.Collections.Generic;

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
            get { return Date.ToShortDateString() + " " + Timeslots[Timeslot].Split(new char[1] { "-"[0] })[0].Trim(); }
        }
        public string GetShortDate
        {
            get { return Date.ToString("dd/MM"); }
        }
        [ProtoMember(3)]
        public string Timeslot { get; set; }

        public BookingModel()
        {
            Date = DateTime.Today;
            Timeslot = "AM";
        }

        public Dictionary<string, string> Timeslots = new Dictionary<string, string>
        {
            {"AM", "7:31 - 12:00"},
            {"PM", "12:00 - 16:00"},
            {"EVE", "16:00 - 18:00"}
        };
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
