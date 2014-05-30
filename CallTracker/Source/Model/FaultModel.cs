//using System.ComponentModel;
using System;
using System.Collections.Generic;

using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class FaultModel
    {
        public FaultModel()
        {
            Severity = String.Empty;
            Symptom = String.Empty;
            Outcome = String.Empty;
            AffectedServices = 1;
        }

        [ProtoMember(1)]
        public string PR { get; set; }
        [ProtoMember(2)]
        public string INC { get; set; }
        [ProtoMember(3)]
        public short AffectedServices { get; set; }
        [ProtoMember(4)]
        public string Severity { get; set; }
        [ProtoMember(5)]
        public string Symptom { get; set; }
        [ProtoMember(6)]
        public string Outcome { get; set; }
        [ProtoMember(7)]
        public BookingModel Booking { get; set; }

        public static List<string> FaultSeverity = new List<string>
        {
            "I", "D", "N", "H"
        };
    }

    public enum AffectedService
    {
        LAT, LIP, ONC, NVF, NBF, DTV, MTV
    }

    public enum FaultSeverity
    {
        I, D, N, H
    }

    public enum Outcomes
    {
        PR, ARO, CM, PC, CPE, NFF
    }

}
