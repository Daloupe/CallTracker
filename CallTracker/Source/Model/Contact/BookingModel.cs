﻿using System;
using System.Collections.Generic;

using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]//(SkipConstructor = true)]
    public class BookingModel
    {
        [ProtoMember(1)]
        public string Type { get; set; }

        [ProtoMember(2)]
        public DateTime Date { get; set; }
        public string GetDate
        {
            get { return Date.ToShortDateString() + " " + Timeslots[Timeslot].Split(new char[1] { "-"[0] })[0].Trim(); }
        }
        public string GetDateAndTimeslot
        {
            get { return Date.ToShortDateString() + " " + Timeslot; }
        }
        public string GetIFMSDate
        {
            get { return Date.ToString("dd/MM/yyyy") + " " + Timeslots[Timeslot].Split(new char[1] { "-"[0] })[0].Trim() + ":00"; }
        }
        public string GetShortDate
        {
            get { return Date.ToString("dd/MM"); }
        }
        [ProtoMember(3)]
        public string Timeslot { get; set; }

        public BookingModel()
        {
            Date = DateTime.Now;
            Timeslot = "AM";
        }

        //[ProtoBeforeDeserialization]
        //private void FieldInitializer()
        //{
        //    Date = DateTime.Today;
        //}

        public Dictionary<string, string> Timeslots = new Dictionary<string, string>
        {
            {"AM", "7:31 - 12:00"},
            {"PM", "12:00 - 16:00"},
            {"EVE", "16:00 - 18:00"}
        };
    }

    public enum BookingType
    {
        NRQ, FAQ, CRQ, MDQ, CM
    }

    public enum BookingTimeslot
    {
        AM, PM, EVE
    }
}
