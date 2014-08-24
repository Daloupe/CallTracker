using System;
using System.Collections.Generic;

using WatiN.Core;

using CallTracker.View;
using CallTracker.Model;

namespace CallTracker.Helpers
{
    public static class IFMSAutoFill
    {
        public class IFMSDropdownElement
        {
            public string Field {get; set;}
            public string Button {get; set;}
            public IFMSDropdownElement(string field, string button)
            {
                Field = field;
                Button = button;
            }
        }
        public static Dictionary<string, IFMSDropdownElement> IFMSDropdownElements = new Dictionary<string, IFMSDropdownElement>
        {
            {"A", new IFMSDropdownElement("ctl00_cphPage_F001_Aff_Svc_ProxyPR1_F001_Aff_Svc_Phone1_tx_affsvc_phA", "ctl00_cphPage_F001_Aff_Svc_ProxyPR1_btnAddPhone")},
            {"CBM", new IFMSDropdownElement("ctl00_cphPage_F001_Aff_Svc_ProxyPR1_F001_Aff_Svc_STU1_tx_EquipNo", "ctl00_cphPage_F001_Aff_Svc_ProxyPR1_Button2")},
            {"SUMM", new IFMSDropdownElement("ctl00_cphPage_F001_Aff_Svc_ProxyPR1_F001_Aff_Svc_Generic1_tx_GenericValue", "ctl00_cphPage_F001_Aff_Svc_ProxyPR1_btnAddGen")},
            {"USER", new IFMSDropdownElement("ctl00_cphPage_F001_Aff_Svc_ProxyPR1_F001_Aff_Svc_Generic1_tx_GenericValue", "ctl00_cphPage_F001_Aff_Svc_ProxyPR1_btnAddGen")},
            {"NREF", new IFMSDropdownElement("ctl00_cphPage_F001_Aff_Svc_ProxyPR1_F001_Aff_Svc_Generic1_tx_GenericValue", "ctl00_cphPage_F001_Aff_Svc_ProxyPR1_btnAddGen")},
            {"IUN", new IFMSDropdownElement("ctl00_cphPage_F001_Aff_Svc_ProxyPR1_F001_Aff_Svc_Acct1_tx_affsvc_number", "ctl00_cphPage_F001_Aff_Svc_ProxyPR1_btnAddACCT")},
            {"STU", new IFMSDropdownElement("ctl00_cphPage_F001_Aff_Svc_ProxyPR1_F001_Aff_Svc_STU1_tx_EquipNo", "ctl00_cphPage_F001_Aff_Svc_ProxyPR1_Button2")}, //ctl00_cphPage_F001_Aff_Svc_ProxyPR1_F001_Aff_Svc_STU1_tx_EquipNo
            {"STB", new IFMSDropdownElement("ctl00_cphPage_F001_Aff_Svc_ProxyPR1_F001_Aff_Svc_STU1_tx_EquipNo", "ctl00_cphPage_F001_Aff_Svc_ProxyPR1_Button2")}
        };

        public static void Go(Main _mainForm)
        {
            EventLogger.LogNewEvent("Attempting IFMS Create AutoFill", EventLogLevel.Brief);
            var data = _mainForm.SelectedContact;
            var affectedServices = data.Fault.AffectedServices;
            var outcome = _mainForm.SelectedContact.Fault.Outcome;
            
            var firstFault = false;
            var bundleFault = false; 

            // LAT ////////////////////////////////////////////////////////////////////////////////////////////////
            if (affectedServices.Has(ServiceTypes.LAT) || affectedServices.Has(ServiceTypes.LIP))
            {
                firstFault = true;

                DropdownTextfieldButton("A", data.DN);
            }

            // ONC ////////////////////////////////////////////////////////////////////////////////////////////////
            if (affectedServices.Has(ServiceTypes.ONC))
            {
                if (firstFault)
                    bundleFault = true;
                firstFault = true;

                DropdownTextfieldButton("CBM", StringHelpers.RemoveColons(data.Service.CMMac));
                DropdownTextfieldButton("USER", data.Username);
                if(outcome != "ARO")
                    DropdownTextfieldButton("SUMM", "RF Tap Down");
                else if(outcome != "PR")
                {
                    HotkeyController.browser.TextField(Find.ByName("ctl00_cphPage_tx_TruckRollStatus")).Value = Enum.GetName(typeof(BookingType), data.Booking.Type);
                    HotkeyController.browser.TextField(Find.ByName("ctl00_cphPage_tx_ScheduleStartTime")).Value = data.Booking.GetDate;
                }
            }

            // DTV ////////////////////////////////////////////////////////////////////////////////////////////////
            if (affectedServices.Has(ServiceTypes.DTV))
            {
                if (firstFault)
                    bundleFault = true;
                firstFault = true;

                DropdownTextfieldButton(bundleFault ? "STU" : "STB", data.Service.DTVSmartCard);

                if(data.Fault.Symptom == "MSG")
                    DropdownTextfieldButton("SUMM", data.Service.DTVMsg);
                if (data.Service.Equipment != "Standard")
                    DropdownTextfieldButton("SUMM", data.Service.Equipment);
            }

            // NBN ////////////////////////////////////////////////////////////////////////////////////////////////
            if (affectedServices.Has(ServiceTypes.NFV) || affectedServices.Has(ServiceTypes.NBF))
            {
                DropdownTextfieldButton("UIN", data.Username);
                if (!String.IsNullOrEmpty(data.Fault.INC))
                    DropdownTextfieldButton("UIN", data.Fault.INC);
            }

            // NFV ////////////////////////////////////////////////////////////////////////////////////////////////
            if (affectedServices.Has(ServiceTypes.NFV))
            {
                if (firstFault)
                    bundleFault = true;
                firstFault = true;
                DropdownTextfieldButton("A", data.DN);             
            }

            // NBF ////////////////////////////////////////////////////////////////////////////////////////////////
            if (affectedServices.Has(ServiceTypes.NBF))
            {
                if (firstFault)
                    bundleFault = true;
                firstFault = true;
            }

            // MTV ////////////////////////////////////////////////////////////////////////////////////////////////
            if (affectedServices.Has(ServiceTypes.MTV))
            {
                if (firstFault)
                    bundleFault = true;
                firstFault = true;

                DropdownTextfieldButton("SUMM", data.Service.MeTVSN);
            }

            // MISC ///////////////////////////////////////////////////////////////////////////////////////////////
            if (bundleFault)
                DropdownTextfieldButton("SUMM", "Bundle Fault");
        }

        public static void DropdownTextfieldButton(string dropdown, string field)
        {
            if (String.IsNullOrEmpty(field)) return;

            HotkeyController.browser.SelectList(Find.ById("ctl00_cphPage_F001_Aff_Svc_ProxyPR1_ddAffectedServices")).Select(dropdown);
            HotkeyController.browser.TextField(Find.ById(IFMSDropdownElements[dropdown].Field)).Value = field;
            HotkeyController.browser.Button(Find.ById(IFMSDropdownElements[dropdown].Button)).Click();
        }
    }
}
