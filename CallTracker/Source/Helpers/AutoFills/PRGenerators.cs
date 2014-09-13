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
            new PRTemplateFunc("Contact Number: ", (contact) => 
            {
                var mobile = contact.Mobile;
                return String.IsNullOrEmpty(mobile) ? contact.DN + "- No Alt" : mobile;
            }),
            new PRTemplateFindProperty("Symptoms: ", "Fault.SymptomFull"),
            new PRTemplateFunc("Configuration: ", (contact) => 
            {
                var output = contact.Service.Equipment;          
                var username = contact.Username;
                if (String.IsNullOrEmpty(username)) return output;
                if (!String.IsNullOrEmpty(output))
                    output += @"\line ";
                output += username;
                return output;
            }),
            new PRTemplateFunc("Testing/Outcome: ", (contact) =>
            {
                var sb = new StringBuilder();
                if (Convert.ToBoolean(contact.Fault.Powercycled))
                    sb.AppendLine("Powercycled; ");
                if (Convert.ToBoolean(contact.Fault.FactoryReset))
                    sb.AppendLine("Factory Reset; ");
                if (Convert.ToBoolean(contact.Fault.CheckedCables))
                    sb.AppendLine("Checked Cables; ");
                if (Convert.ToBoolean(contact.Fault.CheckedNodeForOfflines))
                    sb.AppendLine("Checked Node in SCAMPS for offlines; ");
                if (Convert.ToBoolean(contact.Fault.ChangedWiFiChannel))
                    sb.AppendLine("Changed WiFi Channel; ");
                if (contact.Service.RFIssues == "Yes")
                    sb.AppendLine("SCAMPS shows RF Issues; ");

                if (!String.IsNullOrEmpty(contact.Service.NitResults))
                    sb.AppendLine("Nit Results: " + contact.Service.NitResults + "; ");

                if (!String.IsNullOrEmpty(contact.Service.CauPing))
                    sb.AppendLine("CAU is Pinging " + contact.Service.CauPing + "; ");

                if (!String.IsNullOrEmpty(contact.Service.DownloadSpeed) && !String.IsNullOrEmpty(contact.Service.UploadSpeed))
                    sb.AppendLine("SpeedTest shows " + contact.Service.DownloadSpeed + " down " + contact.Service.UploadSpeed + "up" + "; ");

                if (!String.IsNullOrEmpty(contact.Service.DTVLights))
                    sb.AppendLine("STB Standby light is" + contact.Service.DTVLights + "; ");

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
            new PRTemplateFunc("Callback Window ", (contact) =>  
            { 
                var sb = new StringBuilder();
                sb.Append(contact.Booking.Type);
                sb.Append(": ");
                sb.Append(contact.Booking.Date.ToString("yyyy-MM-dd"));
                sb.AppendLine(" " + contact.Booking.Timeslot);
                return sb.ToString();
            })
        };

        public static List<PRTemplateModel> AROAnswers = new List<PRTemplateModel>
        {
            //new PRTemplateString("Testing/Outcome: ", "ARO on node, customers address affected."),
            new PRTemplateFunc("Testing/Outcome: ", (contact) =>
            {
                var sb = new StringBuilder();
                if (Convert.ToBoolean(contact.Fault.Powercycled))
                    sb.AppendLine("Powercycled; ");
                if (Convert.ToBoolean(contact.Fault.FactoryReset))
                    sb.AppendLine("Factory Reset; ");
                if (Convert.ToBoolean(contact.Fault.CheckedCables))
                    sb.AppendLine("Checked Cables; ");
                if (Convert.ToBoolean(contact.Fault.CheckedNodeForOfflines))
                    sb.AppendLine("Checked Node in SCAMPS for offlines; ");
                if (Convert.ToBoolean(contact.Fault.ChangedWiFiChannel))
                    sb.AppendLine("Changed WiFi Channel; ");
                if (contact.Service.RFIssues == "Yes")
                    sb.AppendLine("SCAMPS shows RF Issues; ");

                if (!String.IsNullOrEmpty(contact.Service.NitResults))
                    sb.AppendLine("Nit Results: " + contact.Service.NitResults + "; ");

                if (!String.IsNullOrEmpty(contact.Service.CauPing))
                    sb.AppendLine("CAU is Pinging " + contact.Service.CauPing + "; ");

                if (!String.IsNullOrEmpty(contact.Service.DownloadSpeed) && !String.IsNullOrEmpty(contact.Service.UploadSpeed))
                    sb.AppendLine("SpeedTest shows " + contact.Service.DownloadSpeed + " down " + contact.Service.UploadSpeed + "up" + "; ");

                if (!String.IsNullOrEmpty(contact.Service.DTVLights))
                    sb.AppendLine("STB Standby light is" + contact.Service.DTVLights + "; ");

                sb.AppendLine("ARO on node, customers address affected.");
                return sb.ToString();
            }),
            new PRTemplateString("Issue/Root Cause: ", "Outage"),
            new PRTemplateString("Next Action: ", "SMS")
        };
    }
}





//if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.Powercycled")))
//                    sb.AppendLine("Powercycled; ");
//                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.FactoryReset")))
//                    sb.AppendLine("Factory Reset; ");
//                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.CheckedCables")))
//                    sb.AppendLine("Checked Cables; ");
//                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.CheckedNodeForOfflines")))
//                    sb.AppendLine("Checked Node in SCAMPS for offlines; ");
//                if (Convert.ToBoolean(FindProperty.FollowPropertyPath(x, "Fault.ChangedWiFiChannel")))
//                    sb.AppendLine("Changed WiFi Channel; ");
//                if (FindProperty.FollowPropertyPath(x, "Service.RFIssues") == "Yes")
//                    sb.AppendLine("SCAMPS shows RF Issues; ");

//                var s = FindProperty.FollowPropertyPath(x, "Service.NitResults");
//                if (!String.IsNullOrEmpty(s))
//                    sb.AppendLine(s+"; ");

//                s = FindProperty.FollowPropertyPath(x, "Service.CauPing");
//                if (!String.IsNullOrEmpty(s))
//                    sb.AppendLine("CAU is Pinging " + s + "; ");

//                s = FindProperty.FollowPropertyPath(x, "Service.DownloadSpeed");
//                var s2 = FindProperty.FollowPropertyPath(x, "Service.UploadSpeed");
//                if (!String.IsNullOrEmpty(s) && !String.IsNullOrEmpty(s2))
//                    sb.AppendLine("SpeedTest shows " + s + " down " + s2 + "up" + "; ");

//                s = FindProperty.FollowPropertyPath(x, "Service.DTVLights");
//                if (!String.IsNullOrEmpty(s))
//                    sb.AppendLine("STB Standby light is" + s + "; ");
