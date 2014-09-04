using System;
using System.Text.RegularExpressions;

using Utilities.RegularExpressions;
using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    //[ImplementPropertyChanged]
    [ProtoContract]//(SkipConstructor = true)]
    public class NameModel
    {
        public static NamePattern Pattern = new NamePattern();

        [ProtoMember(1)]
        public string Title{ get; set; }
        [ProtoMember(2)]
        public string First { get; set; }
        [ProtoMember(5)]
        public string Initial { get; set; }
        [ProtoMember(3)]
        public string Last { get; set; }
        [ProtoMember(4)]
        public string Full 
        { 
            get 
            {
                return _full;
            } 
            set 
            {
                var match = Pattern.Match(value);
                Title = match.Groups[1].Value;
                First = match.Groups[2].Value;
                Initial = match.Groups[3].Value;
                Last = match.Groups[4].Value;

                _full = value;
            } 
        }

        private string _full;

        public NameModel()
        {
            First = String.Empty;
            Last = String.Empty;
        }
        //[ProtoBeforeDeserialization]
        //private void FieldInitializer()
        //{
          
        //}

        

    }    

}
