using System;
using System.Collections.Generic;
using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    [ProtoContract]
    [ImplementPropertyChanged]
    public class RateplanModel
    {
        [ProtoMember(1)]
        public string RateCode { get; set; }
        [ProtoMember(2)]
        public string PlanName { get; set; }
        [ProtoMember(3)]
        public string COSLAT { get; set; }
        [ProtoMember(4)]
        public string COSLIP { get; set; }
        [ProtoMember(5)]
        public string NILAT { get; set; }
        [ProtoMember(6)]
        public string NILIP { get; set; }

        public RateplanModel()
        {
            RateCode = String.Empty;
            PlanName = String.Empty;
            COSLAT = String.Empty;
            COSLIP = String.Empty;
            NILAT = String.Empty;
            NILIP = String.Empty;
        }

        public RateplanModel(string data)
        {
            char columnSplitter = '\t';
            string[] valuesInRow = data.Split(columnSplitter);
            List<Action<string>> datas = new List<Action<string>> { x => RateCode = x, x => PlanName = x, x => COSLAT = x, x => COSLIP = x, x => NILAT = x, x => NILIP = x };
            for (var i = 0; i < valuesInRow.Length - 1; i++ )
            {
                datas[i].Invoke(valuesInRow[i+1]);
            }
        }
    }
}
