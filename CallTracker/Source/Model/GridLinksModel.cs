using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    [ProtoContract]
    public class GridLinksModel
    {
        [ProtoMember(1)]
        public string System { get; set; }
        [ProtoMember(2)]
        public string Title { get; set; }

        public GridLinksModel()
        {
            System = String.Empty;
            Title = String.Empty;
        }
    }
}
