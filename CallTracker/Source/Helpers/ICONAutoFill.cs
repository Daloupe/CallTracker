using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WatiN.Core;

using CallTracker.View;
using CallTracker.Model;

namespace CallTracker.Helpers
{
    public static class ICONAutoFill
    {
        public static void Go(Main _mainForm)
        {
            CustomerContact data = _mainForm.SelectedContact;
            ServiceTypes AffectedServices = data.Fault.AffectedServices;
            string Outcome = _mainForm.SelectedContact.Fault.Outcome;

            var severity = (from a in Main.ServicesStore.servicesDataSet.SeverityCodes
                           where a.IFMSCode == data.Fault.Severity
                           select a).First();

            var symptom = (from a in Main.ServicesStore.servicesDataSet.Symptoms
                           where a.IFMSCode == data.Fault.Symptom
                           select a).First();

            var outcome = (from a in Main.ServicesStore.servicesDataSet.Outcomes
                           where a.Acronym == Outcome
                           select a).First();

            var tier1query = from a in Main.ServicesStore.servicesDataSet.IFMSTier1
                             where a.ServiceId == data.Fault.Service.Id
                             select a;
            if (tier1query.Count() == 0)
                return;
            var tier1 = tier1query.FirstOrDefault();
            //HotkeyController.browser.SelectList(Find.ByName("usr_NewActivityDetails_DropDownListProduct")).Select(tier1.Option);
            Console.WriteLine("Tier1: {0}", tier1.Option);

            var tier2query = from a in Main.ServicesStore.servicesDataSet.IFMSTier2
                             from b in a.GetIFMSTier1IFMSTier2MatchRows()
                             from c in a.GetIFMSTier2OutcomeMatchRows()
                             where b.IFMSTier1Id == tier1.Id &&
                                   c.OutcomeId == outcome.Id
                             select a;
            if (tier2query.Count() == 0)
                return;
            var tier2 = tier2query.FirstOrDefault();
            //HotkeyController.browser.SelectList(Find.ByName("usr_NewActivityDetails_DropDownListCallDriver")).Select(tier2.Option);
            Console.WriteLine("Tier2: {0}", tier2.Option);

            var tier3query = from a in Main.ServicesStore.servicesDataSet.IFMSTier3
                             from b in a.GetIFMSTier2IFMSTier3MatchRows()
                             //from c in a.SymptomsRow.GetSeverityCodeSymptomMatchRows()
                             where b.IFMSTier2Id == tier2.Id &&
                                   //c.SeverityCodeId == severity.Id &&
                                   a.SymptomId == symptom.Id       
                             select a;
            if (tier3query.Count() == 0)
                return;
            var tier3 = tier3query.FirstOrDefault();
            //HotkeyController.browser.SelectList(Find.ByName("usr_NewActivityDetails_DropDownListReason")).Select(tier3.Option);
            Console.WriteLine("Tier3: {0}", tier3.Option);

            var tier4 = from a in Main.ServicesStore.servicesDataSet.IFMSTier4
                         from b in a.GetIFMSTier3IFMSTier4MatchRows()
                         from c in a.GetIFMSTier4OutcomeMatchRows()
                        where b.IFMSTier3Id == tier3.Id &&
                              c.OutcomeId == outcome.Id                              
                        select a;
            if (tier4.Count() == 0)
                return;
            
            Console.WriteLine("Tier4: {0}", tier4.First().Option);
            //HotkeyController.browser.SelectList(Find.ByName("usr_NewActivityDetails_DropDownListOutcome")).Select(tier4.Option); 
        }
    }
}
