﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

using PropertyChanged;
using ProtoBuf;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class PasteBind
    {
        [ProtoMember(1)]
        public string System { get; set; }
        [ProtoMember(2)]
        public string Element { get; set; }
        [ProtoMember(3)]
        public string Title { get; set; }
        [ProtoMember(4)]
        public string Url { get; set; }
        [ProtoMember(5)]
        public string Data { get; set; }
        [ProtoMember(6)]
        public string AltData { get; set; }

        public PasteBind()
        {

        }

        public PasteBind(string _url, string _title, string _element)
        {
            Element = _element;
            Title = _title;
            Url = _url;
            //Data = "Name";
        }
    }
}
