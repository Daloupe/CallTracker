using System;

using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class PRTemplateModel
    {
        [ProtoMember(1)]
        public string Question{ get; set; }
        [ProtoMember(2)]
        public string Answer { get; set; }

        public PRTemplateModel()
        {
            Question = String.Empty;
            Answer = String.Empty;
        }

        public PRTemplateModel(string _question)
        {
            Question = _question;
            Answer = String.Empty;
        }

    }    

}
