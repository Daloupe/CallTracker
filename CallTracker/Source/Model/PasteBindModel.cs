using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WatiN.Core;
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
    public class PasteBind : IEInteractBase
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public string Element { get; set; }
        [ProtoMember(3)]
        public string Data { get; set; }
        [ProtoMember(4)]
        public string AltData { get; set; }

        public PasteBind() : base()
        {
            Name = String.Empty;
            Element = String.Empty;
            Data = String.Empty;
            AltData = String.Empty;
        }

        public PasteBind(string _system, string _url, string _title, Element _activeElement) : base()
        {
            System = _system ?? String.Empty;
            Url = _url ?? String.Empty;
            Title = _title ?? String.Empty;
            Element = _activeElement.IdOrName;
            Name = Element;
            Data = String.Empty;
            AltData = String.Empty;

            FindByName = String.IsNullOrEmpty(_activeElement.Id);

            Form form = _activeElement.Ancestor<Form>();
            if (form.Exists)
            {
                FormElement = form.IdOrName;

                if (String.IsNullOrEmpty(FormElement))
                    return;

                if (String.IsNullOrEmpty(form.Id))
                    IEFormConstraint = ConstraintByName;
                else
                    IEFormConstraint = ConstraintById;

                FindInForm = true;
            }
        }
    }

    
}
