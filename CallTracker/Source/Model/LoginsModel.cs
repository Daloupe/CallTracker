using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
//using System.Threading.Tasks;

using PropertyChanged;
using ProtoBuf;

using WatiN.Core;
using WatiN.Core.Constraints;

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
        [ProtoMember(9)]
        public bool SubmitAsForm { get; set; }
        [ProtoMember(10)]
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
        private bool findInForm { get; set; }
        [ProtoMember(11)]
        public string FormElement{ get; set; }
        [ProtoMember(12)]
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
        private bool typeText { get; set; }
        [ProtoMember(13)]
        public bool FindByName
        {
            get{ return findByName; }
            set
            {
                findByName = value;
                if (findByName)
                    IEConstraint = ConstraintByName;
                else
                    IEConstraint = ConstraintById;
            }
        }
        private bool findByName { get; set; }
        [ProtoMember(14)]
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
        private bool findAsTextField { get; set; }

        public LoginsModel()
        {
            ContextForm = new Func<Browser, IElementContainer>(b => b.Form(Find.ByName(FormElement)));

            UsernameElement = String.Empty;
            Title = String.Empty;
            Url = String.Empty;
            System = String.Empty;
            Username = String.Empty;
            Password = String.Empty;
            SubmitElement = String.Empty;
            UsernameElement = String.Empty;
            PasswordElement = String.Empty;
            SubmitAsForm = false;
            FindInForm = false;
            TypeText = false;
            FindByName = false;
            IEMethod = MethodValue;
            IEConstraint = ConstraintById;
            IEContext = ContextForm;
            FormElement = String.Empty;
        }

        public LoginsModel(string _url, string _title, string _element)
        {
            ContextForm = new Func<Browser, IElementContainer>(b => b.Form(Find.ByName(FormElement)));

            UsernameElement = _element ?? String.Empty;
            Title = _title ?? String.Empty;
            Url = _url ?? String.Empty;
            System = String.Empty;
            Username = String.Empty;
            Password = String.Empty;
            SubmitElement = String.Empty;
            UsernameElement = String.Empty;
            PasswordElement = String.Empty;
            SubmitAsForm = false;
            FindInForm = false;
            TypeText = false;
            FindByName = false;
            IEMethod = MethodValue;
            IEConstraint = ConstraintById;
            IEContext = ContextForm;
            FormElement = String.Empty;

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

        public Type IEType = typeof(TextField);

        public Func<Browser, IElementContainer> IEContext;
        public Func<Browser, IElementContainer> ContextForm;
        public static Func<Browser, IElementContainer> ContextBrowser = new Func<Browser, IElementContainer>(b => b);

        public Func<string, Constraint> IEConstraint;
        public static Func<string, Constraint> ConstraintById = new Func<string, Constraint>(s => Find.ById(s));
        public static Func<string, Constraint> ConstraintByName = new Func<string, Constraint>(s => Find.ByName(s));

        public Action<Element, string> IEMethod;
        public static Action<Element, string> MethodTypeText = new Action<Element, string>((e, s) => ((TextField)e).TypeText(s));
        public static Action<Element, string> MethodValue = new Action<Element, string>((e, s) => ((TextField)e).Value = s);
        public static Action<Element, string> MethodSetAttributeValue = new Action<Element, string>((e, s) => e.SetAttributeValue("value", s));
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