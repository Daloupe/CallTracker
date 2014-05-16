using System;
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
    public class LoginsModel
    {
        [ProtoMember(1)]
        public string System { get; set; }
        [ProtoMember(2)]
        public string Url { get; set; }
        [ProtoMember(3)]
        public string Title { get; set; }
        [ProtoMember(4)]
        public string UsernameElement { get; set; }
        [ProtoMember(5)]
        public string PasswordElement { get; set; }
        [ProtoMember(6)]
        public string Username { get; set; }
        [ProtoMember(7)]
        public string Password{ get; set; }
        [ProtoMember(8)]
        public string SubmitElement { get; set; }

        public LoginsModel()
        {

        }

        public LoginsModel(string _url, string _title, string _element)
        {
            UsernameElement = _element;
            Title = _title;
            Url = _url;
            System = String.Empty;
            Username = String.Empty;
            Password = String.Empty;
            SubmitElement = String.Empty;
            UsernameElement = String.Empty;
            PasswordElement = String.Empty;
            //Data = "Name";
        }
    }
}
