//using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

using Utilities.RegularExpressions;
using ProtoBuf;
using PropertyChanged;

using CallTracker.Helpers;
using CallTracker.View;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class NameModel
    {
        public static NamePattern Pattern = new NamePattern();

        [ProtoMember(1)]
        public string Title{ get; set; }
        [ProtoMember(2)]
        public string First { get; set; }
        [ProtoMember(3)]
        public string Last { get; set; }
        [ProtoMember(4)]
        public string Full 
        { 
            get 
            {
                return full;
            } 
            set 
            {
                Match match = Pattern.Match(value);
                Title = match.Groups[1].Value;
                First = match.Groups[2].Value;
                Last = match.Groups[3].Value;

                full = value;
            } 
        }
        private string full { get; set; }

        public NameModel()
        {
            First = String.Empty;
            Last = String.Empty;
        }

    }    

}
