using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using WatiN.Core;
using WatiN.Core.Constraints;
using ProtoBuf;

namespace CallTracker.Model
{
    // Context.Type(Constraint).Action:
    // IEMethod(IEContext.ElementOfType<T>(IEConstraint(tag)), value);
    // Which is called in a generic function through reflection to enable IEType to select the element type.

    [ProtoContract]
    [ProtoInclude(9, typeof(LoginsModel))]
    [ProtoInclude(10, typeof(PasteBind))]
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
            TypeText = false;
            FindByName = false;
            FindAsTextField = false;
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
        
        [ProtoMember(6)]
        public bool TypeText
        {
            get { return typeText; }
            set
            {
                typeText = value;
                if (typeText)
                    IEMethod = MethodTypeText;
                else
                    IEMethod = MethodValue;
            }
        }
        protected bool typeText { get; set; }
        
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
        
        [ProtoMember(8)]
        public bool FindAsTextField
        {
            get { return findAsTextField; }
            set
            {
                findAsTextField = value;
                if (findAsTextField)
                {
                    IEType = typeof(TextField);
                    TypeText = typeText;
                }
                else
                {
                    IEType = typeof(Element);
                    IEMethod = MethodSetAttributeValue;
                }
            }
        }
        protected bool findAsTextField { get; set; }

        public virtual void Paste(Browser _browser, string _element, string _value)
        {
            MethodInfo paste = this.GetType().GetMethod("PasteData").MakeGenericMethod(IEType);
            paste.Invoke(this, new object[] { _browser, _element, _value });
        }

        public virtual void PasteData<T>(Browser _browser, string _element, string _value) where T : Element
        {
            Element elem = IEContext(_browser).ElementOfType<T>(IEConstraint(_element));
            if (elem.Exists)
                IEMethod(elem, _value);
        }

        protected Func<Browser, IElementContainer> IEContext;
        protected Func<Browser, IElementContainer> ContextForm;
        protected static Func<Browser, IElementContainer> ContextBrowser = new Func<Browser, IElementContainer>(b => b);

        protected Type IEType = typeof(Element);

        protected Func<string, Constraint> IEConstraint;
        protected Func<string, Constraint> IEFormConstraint;
        protected static Func<string, Constraint> ConstraintById = new Func<string, Constraint>(s => Find.ById(s));
        protected static Func<string, Constraint> ConstraintByName = new Func<string, Constraint>(s => Find.ByName(s));

        protected Action<Element, string> IEMethod;
        protected static Action<Element, string> MethodTypeText = new Action<Element, string>((e, s) => ((TextField)e).TypeText(s));
        protected static Action<Element, string> MethodValue = new Action<Element, string>((e, s) => ((TextField)e).Value = s);
        protected static Action<Element, string> MethodSetAttributeValue = new Action<Element, string>((e, s) => e.SetAttributeValue("value", s));
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