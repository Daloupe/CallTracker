using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PropertyChanged;
using ProtoBuf;

namespace CallTracker.Model
{
    public class DataBindType
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public DataBindType(string _name, string _path)
        {
            Name = _name;
            Path = _path;
        }
    }

    [ImplementPropertyChanged]
    [ProtoContract]
    public class PasteBind
    {
        [ProtoMember(1)]
        public string System { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string Element { get; set; }
        [ProtoMember(4)]
        public string Title { get; set; }
        [ProtoMember(5)]
        public string Url { get; set; }
        [ProtoMember(6)]
        public string Data { get; set; }
        [ProtoMember(7)]
        public string AltData { get; set; }

        public PasteBind()
        {
            System = String.Empty;
            Name = String.Empty;
            Element = String.Empty;
            Title = String.Empty;
            Url = String.Empty;
            Data = String.Empty;
            AltData = String.Empty;
        }

        public PasteBind(string _url, string _title, string _element)
        {
            System = String.Empty;
            Name = String.Empty;
            Element = _element ?? String.Empty;
            Title = _title ?? String.Empty;
            Url = _url ?? String.Empty;
            Data = String.Empty;
            AltData = String.Empty;
        }
    }
}
