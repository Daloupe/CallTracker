using ProtoBuf;

namespace CallTracker.Model
{
    partial class FaultModel
    {
        [ProtoMember(100)]
        public bool Powercycled { get; set; }
        [ProtoMember(101)]
        public bool FactoryReset { get; set; }
        [ProtoMember(102)]
        public bool CheckedCables { get; set; }
        [ProtoMember(103)]
        public bool CheckedNodeForOfflines { get; set; }
        [ProtoMember(104)]
        public bool ChangedWiFiChannel { get; set; }
    }
}
