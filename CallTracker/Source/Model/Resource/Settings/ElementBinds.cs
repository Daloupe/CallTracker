using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WatiN.Core;
using PropertyChanged;
using ProtoBuf;

using CallTracker.View;
using CallTracker.Helpers;

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
        public string Element { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string Data { get; set; }
        [ProtoMember(4)]
        public string AltData { get; set; }

        public PasteBind()
            : base()
        {
            Element = String.Empty;
            Name = String.Empty;
            Data = String.Empty;
            AltData = String.Empty;
        }

        public PasteBind(string _system, string _url, string _title, Element _activeElement)
            : base()
        {
            System = _system ?? String.Empty;
            Url = _url ?? String.Empty;
            Title = _title ?? String.Empty;

            Element = _activeElement.IdOrName;
            Name = Element;
            Data = String.Empty;
            AltData = String.Empty;

            FindByName = String.IsNullOrEmpty(_activeElement.Id);
            SetTypeAndMethod(_activeElement);
            FindForm(_activeElement);          
        }

        public virtual void SetTypeAndMethod(Element _activeElement)
        {
            switch (_activeElement.GetAttributeValue("type"))
            {
                case "text":
                    ElementType = ElementTypes.Textfield;
                    break;
                case "button":
                case "submit":
                    ElementType = ElementTypes.Button;
                    break;
                case "select-one":
                    ElementType = ElementTypes.Dropdown;
                    break;
                default:
                    ElementType = ElementTypes.Input;
                    break;
            }    
        }

        private void FindForm(Element _activeElement)
        {
            if (_activeElement.Ancestor<Form>().Exists)
            {
                Form form = _activeElement.Ancestor<Form>();
                FormElement = form.IdOrName;

                if (!String.IsNullOrEmpty(FormElement))
                {
                    FindInForm = true;
                    if (String.IsNullOrEmpty(form.Name))
                        IEFormConstraint = ConstraintByName;
                    else
                        IEFormConstraint = ConstraintById;
                }
            }
        }
    }
    
    //public static class IFMSAutofill
    //{
    //    public static void Go(Main _mainForm, string url, string title)
    //    {
    //        foreach (ServiceTypes product in Enum.GetValues(typeof(ServiceTypes)))
    //        {
    //            if (_mainForm.SelectedContact.Fault.AffectedServices.Has<ServiceTypes>(product))
    //            {
    //                var query = from
    //                        bind in _mainForm.DataStore.PasteBinds
    //                            where
    //                                bind.Url == url ||
    //                                bind.Title.Contains(title) ||
    //                                title.Contains(bind.Title) &&
    //                                bind.Name.Contains(product.ToString())
    //                            select
    //                                bind;
    //            }
    //        };
            
    //    }
    //}
}
