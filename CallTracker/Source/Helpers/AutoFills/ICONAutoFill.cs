﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WatiN.Core;

using CallTracker.View;
using CallTracker.Model;

namespace CallTracker.Helpers
{
    public static class ICONAutoFill
    {
        public static void Go(Main mainForm)
        {
            EventLogger.LogNewEvent("Attempting ICON Note AutoFill", EventLogLevel.Brief);
            var data = mainForm.SelectedContact;
            //var AffectedServices = data.Fault.AffectedServices;
            //var Outcome = data.Fault.Outcome;

            //var severity = (from a in Main.ServicesStore.servicesDataSet.SeverityCodes
            //               where a.IFMSCode == data.Fault.Severity
            //               select a).First();

            var symptom = (from a in Main.ServicesStore.servicesDataSet.Symptoms
                           where a.IFMSCode == data.Fault.Symptom
                           select a).FirstOrDefault();

            var outcome = (from a in Main.ServicesStore.servicesDataSet.Outcomes
                           where a.Acronym == data.Fault.Outcome
                           select a).FirstOrDefault();



            // Tier 1 //////////////////////////////////////////////////////////////////////////////////////////////////// 
            EventLogger.LogAndSaveNewEvent("Attempting Tier 1");
            var tier1Query = (from a in Main.ServicesStore.servicesDataSet.IFMSTier1
                             where a.ServiceId == data.Fault.Service.Id
                             select a).ToList();
            if (!tier1Query.Any())
            {
                EventLogger.LogAndSaveNewEvent("ICON AutoFill Error: No Tier 1 Option Found", EventLogLevel.Status);
                return;
            }
            var tier1 = tier1Query.First();

            HotkeyController.browser.SelectList(Find.ById("usr_NewActivityDetails_DropDownListProduct")).Option(tier1.Option).Select();

            // Tier 2 //////////////////////////////////////////////////////////////////////////////////////////////////// 
            EventLogger.LogAndSaveNewEvent("Attempting Tier 2");
            if (outcome == null)
            {
                EventLogger.LogAndSaveNewEvent("ICON AutoFill Error: Outcome Is Null", EventLogLevel.Status);
                return;
            }
            var tier2Query = (from a in Main.ServicesStore.servicesDataSet.IFMSTier2
                             from b in a.GetIFMSTier1IFMSTier2MatchRows()
                             from c in a.GetIFMSTier2OutcomeMatchRows()
                             where b.IFMSTier1Id == tier1.Id &&
                                   c.OutcomeId == outcome.Id
                             select a).ToList();
            if (!tier2Query.Any())
            {
                EventLogger.LogAndSaveNewEvent("ICON AutoFill Error: No Tier 2 Option Found", EventLogLevel.Status);
                return;
            }
            var tier2 = tier2Query.First();
            HotkeyController.browser.SelectList(Find.ById("usr_NewActivityDetails_DropDownListCallDriver")).Option(tier2.Option).Select();


            // Tier 3 //////////////////////////////////////////////////////////////////////////////////////////////////// 
            EventLogger.LogAndSaveNewEvent("Attempting Tier 3");
            if (symptom == null)
            {
                EventLogger.LogAndSaveNewEvent("ICON AutoFill Error: Symptom Is Null", EventLogLevel.Status);
                return;
            }
            var tier3Query = (from a in Main.ServicesStore.servicesDataSet.IFMSTier3
                             from b in a.GetIFMSTier2IFMSTier3MatchRows()
                             //from c in a.SymptomsRow.GetSeverityCodeSymptomMatchRows()
                             where b.IFMSTier2Id == tier2.Id &&
                                   //c.SeverityCodeId == severity.Id &&
                                   a.SymptomId == symptom.Id       
                             select a).ToList();
            if (!tier3Query.Any())
            {
                EventLogger.LogAndSaveNewEvent("ICON AutoFill Error: No Tier 3 Option Found", EventLogLevel.Status);
                return;
            }
            var tier3 = tier3Query.First();
            HotkeyController.browser.SelectList(Find.ById("usr_NewActivityDetails_DropDownListReason")).Option(tier3.Option).Select();

            // Tier 4 //////////////////////////////////////////////////////////////////////////////////////////////////// 
            EventLogger.LogAndSaveNewEvent("Attempting Tier 4");
            var tier4Query = (from a in Main.ServicesStore.servicesDataSet.IFMSTier4
                         from b in a.GetIFMSTier3IFMSTier4MatchRows()
                         from c in a.GetIFMSTier4OutcomeMatchRows()
                        where b.IFMSTier3Id == tier3.Id &&
                              c.OutcomeId == outcome.Id                              
                        select a).ToList();
            if (!tier4Query.Any())
            {
                EventLogger.LogAndSaveNewEvent("ICON AutoFill Error: No Tier 4 Option Found", EventLogLevel.Status);
                return;
            }
            var tier4 = tier4Query.First();
            HotkeyController.browser.SelectList(Find.ById("usr_NewActivityDetails_DropDownListOutcome")).Option(tier4.Option).Select();

            EventLogger.SaveLog();
        }
    }
}
