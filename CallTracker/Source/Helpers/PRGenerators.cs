using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CallTracker.Model;

namespace CallTracker.Helpers
{
    public static class PRGenerators
    {
        public static string Generate(CustomerContact service, List<PRTemplateModel> replacementQuestions)
        {
            Console.WriteLine("Generating PR");

            // Remove Missed Dependanices.
            var newTemplate = PRTemplate.Where(x => (service.Fault.AffectedServices & x.ServiceRestrictions) != 0 
                                                                      || x.ServiceRestrictions.Is(ServiceTypes.NONE))
                                                                      .ToList();
            newTemplate.AddRange(replacementQuestions);
            newTemplate = newTemplate.GroupBy(a => a.Question)
                                     .Select(b => b.Last())
                                     .ToList();

            foreach (var model in newTemplate.Where(model => model.RequiresObject))
                model.SetObject(service);

            // Remove Case Management Callback Time.
            if(service.Booking.Type != "CM")
                  newTemplate.RemoveAt(newTemplate.Count-1);

            var sb = new StringBuilder();
            sb.Append(@"{\rtf1\ansi {\colortbl;\red0\green0\blue0;\red85\green85\blue85;}");
            foreach (var line in newTemplate)
            {
                sb.Append(line.Question);
                sb.AppendLine(line.GetAnswer());
            };

            sb.Append(@"}");
            return sb.ToString();          
        }

        public static ServiceTypes NBNOnly = (ServiceTypes.NBF | ServiceTypes.NFV);
        public static List<PRTemplateModel> PRTemplate = new List<PRTemplateModel>
        {
            new PRTemplateFindProperty(@"\cf2\b Name\b0\cf1: ", "Name"),
            new PRTemplateFunc(@"\line\cf2\b Contact Number\b0\cf1: ", (x) => 
            { 
                var mobile = FindProperty.FollowPropertyPath(x, "Mobile");
                return String.IsNullOrEmpty(mobile) ? FindProperty.FollowPropertyPath(x, "DN") + "- No Alt" : mobile;
            }),
            new PRTemplateFindProperty(@"\line\cf2\b Symptoms\b0\cf1: ", "Fault.SymptomFull"),
            new PRTemplateFunc(@"\line\cf2\b Configuration\b0\cf1: ", (x) => 
            {
                var output = FindProperty.FollowPropertyPath(x, "Service.Equipment");
                var username = FindProperty.FollowPropertyPath(x, "Username");
                if (!String.IsNullOrEmpty(username))
                    output += @"\line" + username;
                return output;
            }),
            new PRTemplateString(@"\line\cf2\b Testing/Outcome\b0\cf1: "),
            new PRTemplateString(@"\line\cf2\b Issue/Root Cause\b0\cf1: "),
            new PRTemplateFindProperty(@"\line\cf2\b AVC ID\b0\cf1: ", "Service.AVC", NBNOnly),
            new PRTemplateFindProperty(@"\line\cf2\b CVC ID\b0\cf1: ", "Service.CVC", NBNOnly),
            new PRTemplateFindProperty(@"\line\cf2\b BRAS\b0\cf1: ", "Service.Bras", NBNOnly),
            new PRTemplateFindProperty(@"\line\cf2\b CSA\b0\cf1: ", "Service.CSA", NBNOnly),
            new PRTemplateFindProperty(@"\line\cf2\b NNI\b0\cf1: ", "Service.NNI", NBNOnly),
            new PRTemplateFindProperty(@"\line\cf2\b SIP\b0\cf1: ", "Service.Sip", NBNOnly),
            new PRTemplateString(@"\line\cf2\b Next Action\b0\cf1: "),
            new PRTemplateFunc(@"\line\cf2\b Callback Window ", (x) =>  
            { 
                var sb = new StringBuilder();
                sb.Append(FindProperty.FollowPropertyPath(x, "Booking.Type"));
                sb.Append(@"\b0\cf1: ");
                var bookingDate = new DateTime();
                DateTime.TryParse(FindProperty.FollowPropertyPath(x, "Booking.Date"), out bookingDate);
                sb.Append(bookingDate.ToString("yyyy-MM-dd"));
                sb.AppendLine(" " + FindProperty.FollowPropertyPath(x, "Booking.Timeslot"));
                return sb.ToString();
            })
        };

        public static List<PRTemplateModel> AROAnswers = new List<PRTemplateModel>
        {
            new PRTemplateString(@"\line\cf2\b Testing/Outcome\b0\cf1: ", "ARO on node, customers address affected."),
            new PRTemplateString(@"\line\cf2\b Issue/Root Cause\b0\cf1: ", "Outage"),
            new PRTemplateString(@"\line\cf2\b Next Action\b0\cf1: ", "SMS")
        };
    }
}
