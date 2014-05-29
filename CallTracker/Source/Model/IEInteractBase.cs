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
    [ProtoContract]
    [ProtoInclude(9, typeof(LoginsModel))]
    public class IEInteractBase
    {
        public IEInteractBase()
        {
            ContextForm = new Func<Browser, IElementContainer>(b => b.Form(Find.ByName(FormElement)));

            Title = String.Empty;
            Url = String.Empty;
            System = String.Empty;
            FormElement = String.Empty;
            FindInForm = false;
            TypeText = false;
            FindByName = false;
            IEMethod = MethodValue;
            IEConstraint = ConstraintById;
            IEContext = ContextForm;      
        }

        [ProtoMember(1)]
        public string System { get; set; }
        [ProtoMember(2)]
        public string Url { get; set; }
        [ProtoMember(3)]
        public string Title { get; set; }
        [ProtoMember(4)]
        public string FormElement { get; set; }

        protected bool findInForm { get; set; }
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

        protected bool typeText { get; set; }
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

        protected bool findByName { get; set; }
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

        protected bool findAsTextField { get; set; }
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

        public void Paste(Browser _browser, string _element, string _value)
        {
            MethodInfo paste = this.GetType().GetMethod("PasteData").MakeGenericMethod(IEType);
            paste.Invoke(this, new object[] { _browser, _element, _value });
        }

        public void PasteData<T>(Browser _browser, string _element, string _value) where T : Element
        {
            Element elem = IEContext(_browser).ElementOfType<T>(IEConstraint(_element));
            if (!elem.Exists)
                return;
            IEMethod(elem, _value);
        }

        protected Func<Browser, IElementContainer> IEContext;
        protected Func<Browser, IElementContainer> ContextForm;
        protected static Func<Browser, IElementContainer> ContextBrowser = new Func<Browser, IElementContainer>(b => b);

        protected Type IEType = typeof(TextField);

        protected Func<string, Constraint> IEConstraint;
        protected static Func<string, Constraint> ConstraintById = new Func<string, Constraint>(s => Find.ById(s));
        protected static Func<string, Constraint> ConstraintByName = new Func<string, Constraint>(s => Find.ByName(s));

        protected Action<Element, string> IEMethod;
        protected static Action<Element, string> MethodTypeText = new Action<Element, string>((e, s) => ((TextField)e).TypeText(s));
        protected static Action<Element, string> MethodValue = new Action<Element, string>((e, s) => ((TextField)e).Value = s);
        protected static Action<Element, string> MethodSetAttributeValue = new Action<Element, string>((e, s) => e.SetAttributeValue("value", s));
    }

        
}
