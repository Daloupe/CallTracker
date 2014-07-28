using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WatiN.Core;

using CallTracker.View;
using CallTracker.Model;

namespace CallTracker.Helpers
{
    public static class IFMSAutoFill
    {
        public static void Go(Main _mainForm)
        {
            CustomerContact data = _mainForm.SelectedContact;
            ServiceTypes AffectedServices = data.Fault.AffectedServices;
            string Outcome = _mainForm.SelectedContact.Fault.Outcome;
            
            bool firstFault = false;
            bool bundleFault = false; 

            // LAT ////////////////////////////////////////////////////////////////////////////////////////////////
            if (AffectedServices.Has(ServiceTypes.LAT) || AffectedServices.Has(ServiceTypes.LIP))
            {
                firstFault = true;

                DropdownTextfieldButton("A", data.DN);
            }

            // ONC ////////////////////////////////////////////////////////////////////////////////////////////////
            if (AffectedServices.Has(ServiceTypes.ONC))
            {
                if (firstFault == true)
                    bundleFault = true;
                firstFault = true;

                DropdownTextfieldButton("CBM", StringHelpers.RemoveColons(data.Service.CMMac));
                DropdownTextfieldButton("SUMM", data.Username);
                if(Outcome != "ARO")
                    DropdownTextfieldButton("SUMM", "RF Tap Down");
            }

            // DTV ////////////////////////////////////////////////////////////////////////////////////////////////
            if (AffectedServices.Has(ServiceTypes.DTV))
            {
                if (firstFault == true)
                    bundleFault = true;
                firstFault = true;

                if(bundleFault == true)
                    DropdownTextfieldButton("STU", data.Service.DTVSmartCard);
                else
                    DropdownTextfieldButton("STB", data.Service.DTVSmartCard);

                if(data.Fault.Symptom == "MSG")
                    DropdownTextfieldButton("SUMM", data.Service.DTVMsg);
                if (data.Service.Equipment != "Standard")
                    DropdownTextfieldButton("SUMM", data.Service.Equipment);
            }

            // NBN ////////////////////////////////////////////////////////////////////////////////////////////////
            if (AffectedServices.Has(ServiceTypes.NFV) || AffectedServices.Has(ServiceTypes.NBF))
            {
                if (firstFault == true)
                    bundleFault = true;
                firstFault = true;

                if (!String.IsNullOrEmpty(data.Fault.INC))
                    DropdownTextfieldButton("UIN", data.Fault.INC);
            }

            // NFV ////////////////////////////////////////////////////////////////////////////////////////////////
            if (AffectedServices.Has(ServiceTypes.NFV))
            {
                DropdownTextfieldButton("A", data.DN);             
            }

            // NBF ////////////////////////////////////////////////////////////////////////////////////////////////
            if (AffectedServices.Has(ServiceTypes.NBF))
            {
                DropdownTextfieldButton("User", data.Username);
            }

            // MTV ////////////////////////////////////////////////////////////////////////////////////////////////
            if (AffectedServices.Has(ServiceTypes.MTV))
            {
                if (firstFault == true)
                    bundleFault = true;
                firstFault = true;

                DropdownTextfieldButton("SUMM", data.Service.MeTVSN);
                DropdownTextfieldButton("User", data.Username);
            }

            // MISC ///////////////////////////////////////////////////////////////////////////////////////////////
            if (bundleFault == true)
                DropdownTextfieldButton("SUMM", "Bundle Fault");
        }

        public static void DropdownTextfieldButton(string _dropdown, string _field)
        {
            if(!String.IsNullOrEmpty(_field))
            {
                HotkeyController.browser.SelectList(Find.ByName("name")).Select(_dropdown);
                HotkeyController.browser.TextField(Find.ByName("name")).Value = _field;
                HotkeyController.browser.Button(Find.ByName("name")).Click();
            }
        }
    }
}
