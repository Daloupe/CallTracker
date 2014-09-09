using System;
using System.Reflection;
using System.Windows.Forms;
using CallTracker.Helpers;
using WatiN.Core;
using WatiN.Core.Constraints;
using ProtoBuf;
using Button = WatiN.Core.Button;

namespace CallTracker.Model
{
    // Context.Type(Constraint).Action:
    // IEMethod(IEContext.ElementOfType<T>(IEConstraint(tag)), value);
    // Which is called in a generic function through reflection to enable IEType to select the element type.

    [ProtoContract]
    [ProtoInclude(15, typeof(LoginsModel))]
    [ProtoInclude(16, typeof(PasteBind))]
    public class IEInteractBase
    {
        protected MethodInfo PasteMethod;
        public IEInteractBase()
        {
            ContextForm = b => b.Form(IEFormConstraint(FormElement));

            IEContext = ContextBrowser;
            IEType = typeof(Element);
            IEConstraint = ConstraintById;
            IEFormConstraint = ConstraintById;
            IEMethod = MethodSetAttributeValue;

            Title = String.Empty;
            Url = String.Empty;
            System = String.Empty;
            FormElement = String.Empty;

            FindInForm = false;
            FindByName = false;
            FireOnChange = false;
            FireOnChangeNoWait = false;
            //FindAsTextField = false;
            //TypeText = false;
            //ClickButton = false;
            //SelectFromList = false;
        }

        [ProtoMember(1)]
        public string System { get; set; }
        [ProtoMember(2)]
        public string Url { get; set; }
        [ProtoMember(3)]
        public string Title { get; set; }

        private string _formElement;
        [ProtoMember(4)]
        public string FormElement
        {
            get { return _formElement; }
            set
            {
                _formElement = value;
                if (String.IsNullOrEmpty(_formElement))
                    FindInForm = false;
            }
        }

        private bool _findInForm;
        [ProtoMember(5)]
        public bool FindInForm
        {
            get { return _findInForm; }
            set
            {
                _findInForm = value;
                IEContext = _findInForm ? ContextForm : ContextBrowser;
            }
        }

        private bool _findByName;
        [ProtoMember(7)]
        public bool FindByName
        {
            get { return _findByName; }
            set
            {
                _findByName = value;
                IEConstraint = _findByName ? ConstraintByName : ConstraintById;
            }
        }

        [ProtoMember(8)]
        public bool FireOnChange { get; set; }

        [ProtoMember(9)]
        public bool FireOnChangeNoWait { get; set; }

        [ProtoMember(10)]
        public bool PasteWithSendKeys { get; set; }

        private ElementTypes _elementType;
        [ProtoMember(11)]
        public ElementTypes ElementType 
        { 
            get 
            { 
                return _elementType; 
            } 
            set
            {
                switch (value)
                {
                    case ElementTypes.Textfield:
                        IEType = typeof(TextField);
                        IEMethod = MethodValue;
                        break;
                    case ElementTypes.TypedTextfield:
                        IEType = typeof(TextField);
                        IEMethod = MethodTypeText;
                        break;
                    case ElementTypes.Button:
                        IEType = typeof(Button);
                        IEMethod = MethodClickButton;
                        break;
                    case ElementTypes.Dropdown:
                        IEType = typeof(SelectList);
                        IEMethod = MethodSelectFromList;
                        break;
                    default:
                        IEType = typeof(Element);
                        IEMethod = MethodSetAttributeValue;
                        break;
                }   

                if(_elementType != value)
                    PasteMethod = GetType().GetMethod("PasteData").MakeGenericMethod(IEType);

                _elementType = value;
            }
        }

        public virtual void Paste(string element, string value)
        {
            PasteMethod.Invoke(this, new object[] { element, value });
        }

        public virtual void PasteData<T>(string element, string value) where T : Element
        {
            var browserElement = IEContext(HotkeyController.browser).ElementOfType<T>(IEConstraint(element));
            if (!browserElement.Exists)
            {
                EventLogger.LogNewEvent("Paste Data Error: " + element + " Doesn't Exist.");
                return;
            }
            
            browserElement.Focus();//.FindNativeElement().SetFocus();
            if (PasteWithSendKeys)
            {
                Clipboard.SetText(value);
                SendKeys.Send("^(v)");
                SendKeys.Flush();
                if (FireOnChange)
                    HotkeyController.WaitForBrowserBusy();
            }
            else
            {
                IEMethod(browserElement, value);
                if (FireOnChange)
                {
                    browserElement.FireEvent("onchange");
                    HotkeyController.WaitForBrowserBusy();
                    //May need to tab to next item for IFMS.
                }
                else if (FireOnChangeNoWait)
                    browserElement.FireEventNoWait("onchange");
            }
        }

        protected Func<Browser, IElementContainer> IEContext;
        protected Func<Browser, IElementContainer> ContextForm;
        protected static Func<Browser, IElementContainer> ContextBrowser = b => b;

        protected Type IEType = typeof(Element);

        protected Func<string, Constraint> IEConstraint;
        protected Func<string, Constraint> IEFormConstraint;
        protected static Func<string, Constraint> ConstraintById = s => Find.ById(s);
        protected static Func<string, Constraint> ConstraintByName = s => Find.ByName(s);

        protected Action<Element, string> IEMethod;
        protected static Action<Element, string> MethodTypeText = (e, s) => ((TextField)e).TypeText(s);
        protected static Action<Element, string> MethodValue = (e, s) => ((TextField)e).Value = s;
        protected static Action<Element, string> MethodSetAttributeValue = (e, s) => e.SetAttributeValue("value", s);
        protected static Action<Element, string> MethodSelectFromList = (e, s) => ((SelectList)e).Select(s);
        protected static Action<Element, string> MethodClickButton = (e, s) => e.Click();
    }     

    public enum ElementTypes
    {
        Input,
        Textfield,
        TypedTextfield,
        Button,
        Dropdown
    }
}








//public static MethodInfo IEElementOfType = typeof(IElementContainer)
//                                    .GetMethods()
//                                    .Where(m => m.Name == "ElementOfType")
//                                    .Select(m => new
//                                    {
//                                        Method = m,
//                                        Params = m.GetParameters(),
//                                        Args = m.GetGenericArguments()
//                                    })
//                                    .Where(x => x.Params.Length == 1
//                                                && x.Args.Length == 1
//                                                && x.Params[0].ParameterType == typeof(Constraint))
//                                    .Select(x => x.Method)
//                                    .First();
//public void Paste(Browser _browser, string _element, string _value)
//{
//    //Element elem = IEContext(_browser).ElementOfType<T>(IEConstraint(_element));
//    var elem = IEElementOfType
//                .MakeGenericMethod(IEType)
//                .Invoke(IEContext(_browser), new object[] { IEConstraint(_element) }) as Element;
//    if (!elem.Exists)
//        return;
//    IEMethod(elem, _value);
//}