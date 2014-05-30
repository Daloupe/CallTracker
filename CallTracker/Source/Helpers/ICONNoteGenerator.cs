using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CallTracker.Model;
using CallTracker.View;

namespace CallTracker.Helpers
{
    class ICONNoteGenerator
    {
        public Dictionary<string, string> SymptomSituation = new Dictionary<string, string>
        {
            {"NDT", "No Dial Tone"},
            {"COS", "Cut Off Speaking"},
            {"LIC", "Internet Drop Outs"},
            {"CCI", "Loss of Internet"},
            {"MSG", "Foxtel On Screen Errors"}
        };

        public ICONNoteGenerator(Main _form)
        {
            DataRepository repo = _form.DataStore;
            CustomerContact contact = Main.SelectedContact;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Situation");

            sb.Append("- Customer is ");
            
            if (contact.Fault.Severity == "D")
                sb.Append("Intermittantly ");

            sb.Append("experiancing ");

            sb.Append(SymptomSituation[contact.Fault.Symptom]);

            sb.AppendLine("Action");

           
        }
    }
}
