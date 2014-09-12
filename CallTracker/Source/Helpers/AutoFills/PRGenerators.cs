using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Timers;

using CallTracker.Model;

namespace CallTracker.Helpers
{
    public static class PRGenerators
    {
        public static string Generate(CustomerContact service, List<PRTemplateModel> replacementQuestions)
        {
            //Console.WriteLine("Generating PR");

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
            sb.Append(@"{\rtf1\ansi{\colortbl;\red75\green70\blue85;}");
            foreach (var line in newTemplate)
            {
                sb.Append(@"\cf1 ");
                sb.Append(line.Question);
                sb.Append(@"\cf0 ");
                sb.Append(line.GetAnswer());
                sb.Append(@"\line");
            };

            sb.Append(@"\cf0}");
            return sb.ToString();          
        }

        public static ServiceTypes NBNOnly = (ServiceTypes.NBF | ServiceTypes.NFV);
        public static List<PRTemplateModel> PRTemplate = new List<PRTemplateModel>
        {
            new PRTemplateFindProperty("Name: ", "Name"),
            new PRTemplateFunc("Contact Number: ", (x) => 
            { 
                var mobile = FindProperty.FollowPropertyPath(x, "Mobile");
                return String.IsNullOrEmpty(mobile) ? FindProperty.FollowPropertyPath(x, "DN") + "- No Alt" : mobile;
            }),
            new PRTemplateFindProperty("Symptoms: ", "Fault.SymptomFull"),
            new PRTemplateFunc("Configuration: ", (x) => 
            {
                var output = FindProperty.FollowPropertyPath(x, "Service.Equipment");          
                var username = FindProperty.FollowPropertyPath(x, "Username");
                if (String.IsNullOrEmpty(username)) return output;
                if (!String.IsNullOrEmpty(output))
                    output += @"\line ";
                output += username;
                return output;
            }),
            new PRTemplateFunc("Testing/Outcome: ", (x) =>
            {
                var sb = new StringBuilder();
                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.Powercycled")))
                    sb.AppendLine("Powercycled; ");
                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.FactoryReset")))
                    sb.AppendLine("Factory Reset; ");
                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.CheckedCables")))
                    sb.AppendLine("Checked Cables; ");
                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.CheckedNodeForOfflines")))
                    sb.AppendLine("Checked Node in SCAMPS for offlines; ");
                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.ChangedWiFiChannel")))
                    sb.AppendLine("Changed WiFi Channel; ");
                return sb.ToString();
            }),
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
                var sb = new StringBuilder();
                sb.Append(FindProperty.FollowPropertyPath(x, "Booking.Type"));
                sb.Append(": ");
                DateTime bookingDate;// = new DateTime();
                DateTime.TryParse(FindProperty.FollowPropertyPath(x, "Booking.Date"), out bookingDate);
                sb.Append(bookingDate.ToString("yyyy-MM-dd"));
                sb.AppendLine(" " + FindProperty.FollowPropertyPath(x, "Booking.Timeslot"));
                return sb.ToString();
            })
        };

        public static List<PRTemplateModel> AROAnswers = new List<PRTemplateModel>
        {
            //new PRTemplateString("Testing/Outcome: ", "ARO on node, customers address affected."),
            new PRTemplateFunc("Testing/Outcome: ", (x) =>
            {
                var sb = new StringBuilder();
                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.Powercycled")))
                    sb.AppendLine("Powercycled; ");
                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.FactoryReset")))
                    sb.AppendLine("Factory Reset; ");
                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.CheckedCables")))
                    sb.AppendLine("Checked Cables; ");
                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.CheckedNodeForOfflines")))
                    sb.AppendLine("Checked Node in SCAMPS for offlines; ");
                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.ChangedWiFiChannel")))
                    sb.AppendLine("Changed WiFi Channel; ");
                sb.AppendLine("ARO on node, customers address affected.");
                return sb.ToString();
            }),
            new PRTemplateString("Issue/Root Cause: ", "Outage"),
            new PRTemplateString("Next Action: ", "SMS")
        };
    }
}
