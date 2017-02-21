using System;
using PropertyChanged;

using CallTracker.Helpers;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    public abstract class PRTemplateModel
    {
        public abstract bool RequiresObject { get; }
        public string Question{ get; set; }
        protected CustomerContact TargetObject;
        public ServiceTypes ServiceRestrictions { get; set; }

        public PRTemplateModel(string _question, ServiceTypes _serviceRestrictions)
        {
            Question = _question;
            ServiceRestrictions = _serviceRestrictions;
        }

        public virtual string GetAnswer() { return String.Empty; }
        public virtual void SetObject(CustomerContact _value) { TargetObject = _value; }
    }

    public class PRTemplateString: PRTemplateModel
    {
        public string Answer { get; set; }

        public const bool Constant = false;
        public override bool RequiresObject { get { return Constant; } }

        public PRTemplateString(string _question, ServiceTypes _serviceRestrictions = ServiceTypes.NONE) : base(_question, _serviceRestrictions)
        {
            Answer = String.Empty;
        }
        public PRTemplateString(string _question, string _answer, ServiceTypes _serviceRestrictions = ServiceTypes.NONE): base(_question, _serviceRestrictions)
        {
            Answer = _answer;
        }

        public override string GetAnswer() 
        { 
            return Answer; 
        }

    }

    public class PRTemplateFindProperty : PRTemplateModel
    {
        public string PropertyPath { get; set; }

        public const bool Constant = true;
        public override bool RequiresObject { get { return Constant; } }

        public PRTemplateFindProperty(string _question, ServiceTypes _serviceRestrictions = ServiceTypes.NONE): base(_question, _serviceRestrictions) {}

        public PRTemplateFindProperty(string _question, string _propertyPath, ServiceTypes _serviceRestrictions = ServiceTypes.NONE) : base(_question, _serviceRestrictions) 
        {
            PropertyPath = _propertyPath;
        }


        public override string GetAnswer()
        {
            return FindProperty.FollowPropertyPath(TargetObject, PropertyPath);
        }
    }

    public class PRTemplateFunc : PRTemplateModel
    {
        public Func<CustomerContact, string> AnswerFunc { get; set; }

        public const bool Constant = true;
        public override bool RequiresObject{ get { return Constant; }}


        public PRTemplateFunc(string _question, ServiceTypes _serviceRestrictions = ServiceTypes.NONE) : base(_question, _serviceRestrictions) {}

        public PRTemplateFunc(string _question, Func<CustomerContact, string> _answer, ServiceTypes _serviceRestrictions = ServiceTypes.NONE) : base(_question, _serviceRestrictions) 
        {
            AnswerFunc = _answer;
        }


        public override string GetAnswer()
        {
            return AnswerFunc.Invoke(TargetObject);
        }
    }  

}
