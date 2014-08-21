using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CallTracker.Model;

namespace CallTracker.Helpers
{
    public static class PRGenerators
    {
        public static string Generate(CustomerContact _service, List<PRTemplateModel> _replacementQuestions)
        {
            // Remove Missed Dependanices.
            List<PRTemplateModel> newTemplate = PRTemplate.Where(x => (_service.Fault.AffectedServices & x.ServiceRestrictions) != 0 
                                                                      || x.ServiceRestrictions.Is(ServiceTypes.NONE))
                                                                      .ToList();

            foreach (PRTemplateModel model in _replacementQuestions)
            {
                var query = newTemplate.Exists(x => x.Question == model.Question);
                if (query != false)
                {
                    int idx = newTemplate.IndexOf(newTemplate.First(x => x.Question == model.Question));
                    newTemplate[idx] = model;
                }
            }

            foreach (PRTemplateModel model in newTemplate)
            {
                if (model.RequiresObject)
                    model.SetObject(_service);
            }

            // Remove Case Management Callback Time.
            if(_service.Booking.Type != "CM")
                  newTemplate.RemoveAt(newTemplate.Count-1);

            StringBuilder sb = new StringBuilder();
            foreach (PRTemplateModel line in newTemplate)
            {
                sb.Append(line.Question);
                sb.AppendLine(line.GetAnswer());
            };
                
            return sb.ToString();
            
        }

        public static ServiceTypes NBNOnly = (ServiceTypes.NBF | ServiceTypes.NFV);
        public static List<PRTemplateModel> PRTemplate = new List<PRTemplateModel>
        {
            new PRTemplateFindProperty("Name: ", "Name"),
            new PRTemplateFunc("Contact Number: ", (x) => 
            { 
                string mobile = FindProperty.FollowPropertyPath(x, "Mobile");
                return String.IsNullOrEmpty(mobile) ? FindProperty.FollowPropertyPath(x, "DN") + "- No Alt" : mobile;
            }),
            new PRTemplateFindProperty("Symptoms: ", "Fault.SymptomFull"),
            new PRTemplateFunc("Configuration: ", (x) => 
            {
                string output = FindProperty.FollowPropertyPath(x, "Service.Equipment");
                string username = FindProperty.FollowPropertyPath(x, "Username");
                if (!String.IsNullOrEmpty(username))
                    output += Environment.NewLine + username;
                return output;
            }),
            new PRTemplateString("Testing/Outcome: "),
            new PRTemplateString("Issue/Root Cause: "),
            new PRTemplateFindProperty("AVC ID: ", "Service.AVC", NBNOnly),
            new PRTemplateFindProperty("CVC ID: ", "Service.CVC", NBNOnly),
            new PRTemplateFindProperty("BRAS: ", "Service.Bras", NBNOnly),
            new PRTemplateFindProperty("CSA: ", "Service.CSA", NBNOnly),
            new PRTemplateFindProperty("NNI: ", "Service.NNI", NBNOnly),
            new PRTemplateFindProperty("SIP: ", "Service.Sip", NBNOnly),
            new PRTemplateString("Next Action: "),
            new PRTemplateFunc("Callback Window ", (x) =>  
            { 
                StringBuilder sb = new StringBuilder();
                sb.Append(FindProperty.FollowPropertyPath(x, "Booking.Type"));
                sb.Append(": ");
                DateTime bookingDate = new DateTime();
                DateTime.TryParse(FindProperty.FollowPropertyPath(x, "Booking.Date"), out bookingDate);
                sb.Append(bookingDate.ToString("yyyy-MM-dd"));
                sb.AppendLine(" " + FindProperty.FollowPropertyPath(x, "Booking.Timeslot"));
                return sb.ToString();
            })
        };

        public static List<PRTemplateModel> AROAnswers = new List<PRTemplateModel>
        {
            new PRTemplateString("Testing/Outcome: ", "ARO on node, customers address affected."),
            new PRTemplateString("Issue/Root Cause: ", "Outage"),
            new PRTemplateString("Next Action: ", "SMS")
        };
    }
}
