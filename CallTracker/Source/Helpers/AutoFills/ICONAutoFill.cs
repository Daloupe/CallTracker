using System;
using System.Linq;

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
            var tier1Query = (from a in Main.ServicesStore.servicesDataSet.IFMSTier1
                             where a.ServiceId == data.Fault.Service.Id
                             select a).ToList();
            if (!tier1Query.Any())
            {
                EventLogger.LogAndSaveNewEvent("ICON AutoFill Error: No Tier 1 Option Found");
                return;
            }
            var tier1 = tier1Query.First();
            //HotkeyController.browser.SelectList(Find.ById("usr_NewActivityDetails_DropDownListProduct")).Select(tier1.Option);
            var form = HotkeyController.browser.Form(Find.ById("Form1"));
            var list = HotkeyController.browser.SelectList(Find.ById("usr_NewActivityDetails_DropDownListProduct"));
            var listInForm = form.SelectList(Find.ById("usr_NewActivityDetails_DropDownListProduct"));
            var option = listInForm.Option(tier1.Option);
            option.Select();
            listInForm.FireEvent("onchange");
            EventLogger.LogAndSaveNewEvent(String.Format("Product: {0}, Form Exists: {1}, List Exists: {2}, List In Form Exists: {3}, Option Exists{4}", tier1.Option, form.Exists, list.Exists, listInForm.Exists, option.Exists));

            HotkeyController.WaitForBrowserBusy();




            // Tier 2 //////////////////////////////////////////////////////////////////////////////////////////////////// 
            if (outcome == null)
            {
                EventLogger.LogAndSaveNewEvent("ICON AutoFill Error: Outcome Is Null");
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
                EventLogger.LogAndSaveNewEvent("ICON AutoFill Error: No Tier 2 Option Found");
                return;
            }
            var tier2 = tier2Query.First();
            list = HotkeyController.browser.SelectList(Find.ById("usr_NewActivityDetails_DropDownListCallDriver"));
            list.Select(tier2.Option);
            list.FireEvent("onchange");
            HotkeyController.WaitForBrowserBusy();


            // Tier 3 //////////////////////////////////////////////////////////////////////////////////////////////////// 
            if (symptom == null)
            {
                EventLogger.LogAndSaveNewEvent("ICON AutoFill Error: Symptom Is Null");
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
                EventLogger.LogAndSaveNewEvent("ICON AutoFill Error: No Tier 3 Option Found");
                return;
            }
            var tier3 = tier3Query.First();
            list = HotkeyController.browser.SelectList(Find.ById("usr_NewActivityDetails_DropDownListReason"));
            list.Select(tier3.Option);
            list.FireEvent("onchange");
            HotkeyController.WaitForBrowserBusy();




            // Tier 4 //////////////////////////////////////////////////////////////////////////////////////////////////// 
            var tier4Query = (from a in Main.ServicesStore.servicesDataSet.IFMSTier4
                         from b in a.GetIFMSTier3IFMSTier4MatchRows()
                         from c in a.GetIFMSTier4OutcomeMatchRows()
                        where b.IFMSTier3Id == tier3.Id &&
                              c.OutcomeId == outcome.Id                              
                        select a).ToList();
            if (!tier4Query.Any())
            {
                EventLogger.LogAndSaveNewEvent("ICON AutoFill Error: No Tier 4 Option Found");
                return;
            }
            var tier4 = tier4Query.First();
            list = HotkeyController.browser.SelectList(Find.ById("usr_NewActivityDetails_DropDownListOutcome"));
            list.Select(tier4.Option);
            list.FireEvent("onchange");
            HotkeyController.WaitForBrowserBusy();

            EventLogger.SaveLog();
        }
    }
}
