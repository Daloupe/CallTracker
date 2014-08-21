using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using WatiN.Core;
using WatiN.Core.Constraints;
using ProtoBuf;

using CallTracker.View;

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
        public IEInteractBase()
        {
            ContextForm = new Func<Browser, IElementContainer>(b => b.Form(IEFormConstraint(FormElement)));

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
        [ProtoMember(4)]
        public string FormElement
        {
            get { return formElement; }
            set
            {
                formElement = value;
                if (String.IsNullOrEmpty(formElement))
                    FindInForm = false;
            }
        }
        public string formElement { get; set; }

        [ProtoMember(5)]
        public bool FindInForm
        {
            get { return findInForm; }
            set
            {
                findInForm = value;
                if (findInForm)
                    IEContext = ContextForm;
                else
                    IEContext = ContextBrowser;
            }
        }
        protected bool findInForm { get; set; }
        
        [ProtoMember(7)]
        public bool FindByName
        {
            get { return findByName; }
            set
            {
                findByName = value;
                if (findByName)
                    IEConstraint = ConstraintByName;
                else
                    IEConstraint = ConstraintById;
            }
        }
        protected bool findByName { get; set; }

        [ProtoMember(11)]
        public ElementTypes ElementType 
        { 
            get 
            { 
                return elementType; 
            } 
            set
            {
                elementType = value;
                switch (elementType)
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
            }
        }
        protected ElementTypes elementType { get; set; }

        public virtual void Paste(Browser browser, string element, string value)
        {
            MethodInfo paste = this.GetType().GetMethod("PasteData").MakeGenericMethod(IEType);
            paste.Invoke(this, new object[] { browser, element, value });
        }

        public virtual void PasteData<T>(Browser browser, string element, string value) where T : Element
        {
            Element elem = IEContext(browser).ElementOfType<T>(IEConstraint(element));
            if (!elem.Exists) return;
            
            elem.FindNativeElement().SetFocus();
            IEMethod(elem, value);
            Main.FadingToolTip.ShowandFade("Pasting " + element + ": " + value);
            browser.WaitForComplete(5000);
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