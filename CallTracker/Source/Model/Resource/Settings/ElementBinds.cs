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

        public PasteBind(string system, string url, string title, Element activeElement)
            : base()
        {
            Data = String.Empty;
            AltData = String.Empty;

            System = system ?? String.Empty;
            Url = url ?? String.Empty;
            Title = title ?? String.Empty;

            Element = activeElement.IdOrName;
            Name = Element;

            FindByName = String.IsNullOrEmpty(activeElement.Id);
            SetTypeAndMethod(activeElement);
            FindForm(activeElement);
        }

        private void SetTypeAndMethod(Element activeElement)
        {
            switch (activeElement.GetAttributeValue("type"))
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

        private void FindForm(Element activeElement)
        {
            if (!activeElement.Ancestor<Form>().Exists) return;

            var form = activeElement.Ancestor<Form>();
            FormElement = form.IdOrName;

            if (String.IsNullOrEmpty(FormElement)) return;

            FindInForm = true;
            IEFormConstraint = String.IsNullOrEmpty(form.Name) ? ConstraintByName : ConstraintById;
        }

        //public void Paste(string value)
        //{
        //    Console.WriteLine("Overridden");
        //    PasteMethod.Invoke(this, new object[] {value});
        //}

        //public void PasteData<T>(string value) where T : Element
        //{
        //    Console.WriteLine("Overridden");
        //    var browserElement = IEContext(HotkeyController.browser).ElementOfType<T>(IEConstraint(Element));
        //    //if (!browserElement.Exists)
        //    //{
        //    //    EventLogger.LogNewEvent("Smart Paste Error: BrowserElement Doesn't Exist.");
        //    //    return;
        //    //}

        //    //browserElement.FindNativeElement().SetFocus();
        //    IEMethod(browserElement, value);
        //    if (FireOnChange)
        //        browserElement.FireEvent("onchange");
        //    else if (FireOnChangeNoWait)
        //        browserElement.FireEventNoWait("onchange");
        //}
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
