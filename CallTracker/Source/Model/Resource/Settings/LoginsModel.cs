using System;
//using System.Threading.Tasks;

using PropertyChanged;
using ProtoBuf;

using WatiN.Core;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class LoginsModel : IEInteractBase
    {
        public LoginsModel() : base()
        {
            SubmitFormConstraint = new Func<Browser, Element>(b => b.ElementOfType<Form>(Find.ByName(FormElement)));
            SubmitClickConstraint = new Func<Browser, Element>(b => b.ElementOfType<Element>(Find.ByName(SubmitElement)));

            IESubmitConstraint = SubmitClickConstraint;
            IESubmit = SubmitClick;

            Username = String.Empty;
            Password = String.Empty;
            SubmitElement = String.Empty;
            UsernameElement = String.Empty;
            PasswordElement = String.Empty;

            SubmitAsForm = false;
        }

        [ProtoMember(1)]
        public string UsernameElement { get; set; }
        [ProtoMember(2)]
        public string PasswordElement { get; set; }
        [ProtoMember(3)]
        public string Username { get; set; }
        [ProtoMember(4)]
        public string Password{ get; set; }
        [ProtoMember(5)]
        public string SubmitElement { get; set; }
        [ProtoMember(6)]
        public bool SubmitAsForm
        {
            get { return submitAsForm; }
            set
            {
                submitAsForm = value;
                if (submitAsForm)
                {
                    IESubmitConstraint = SubmitFormConstraint;
                    IESubmit = SubmitForm;
                }
                else
                {
                    IESubmitConstraint = SubmitClickConstraint;
                    IESubmit = SubmitClick;
                }
            }
        }
        private bool submitAsForm { get; set; }

        public void Submit(Browser _browser)
        {
            Element elem = IESubmitConstraint(_browser);
            if(elem.Exists)
                IESubmit(elem);
        }

        protected Func<Browser, Element> IESubmitConstraint;
        protected Func<Browser, Element> SubmitFormConstraint;
        protected Func<Browser, Element> SubmitClickConstraint;

        protected Action<Element> IESubmit;
        protected static Action<Element> SubmitForm = new Action<Element>(e => ((Form)e).Submit());
        protected static Action<Element> SubmitClick = new Action<Element>(e => e.ClickNoWait());
    }
}