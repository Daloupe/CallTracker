//using System.ComponentModel;

using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class FaultModel
    {
        [ProtoMember(1)]
        public string PR { get; set; }
        [ProtoMember(2)]
        public string INC { get; set; }

        [ProtoMember(3)]
        public AffectedService AffectedServices { get; set; }
        [ProtoMember(4)]
        public FaultSeverity Severity { get; set; }
        [ProtoMember(5)]
        public string Symptom { get; set; }
        [ProtoMember(6)]
        public BookingModel Booking { get; set; }
    }

    public enum AffectedService
    {
        LAT, LIP, ONC, MTV, DTV
    }

    public enum FaultSeverity
    {
        I, D, N, H
    }
}
