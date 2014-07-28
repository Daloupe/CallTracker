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
        public string Full 
        { 
            get 
            { 
                return First + " " + Last; 
            } 
            set 
            {
                Match match = Pattern.Match(value);
                Title = match.Groups[0].Value;
                First = match.Groups[1].Value;
                Last = match.Groups[2].Value;
            } 
        }

        public NameModel()
        {
            First = String.Empty;
            Last = String.Empty;
        }

    }    

}
