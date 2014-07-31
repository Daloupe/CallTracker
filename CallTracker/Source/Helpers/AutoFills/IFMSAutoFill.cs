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
        public class IFMSDropdownElement
        {
            public string Field {get; set;}
            public string Button {get; set;}
            public IFMSDropdownElement(string _field, string _button)
            {
                Field = _field;
                Button = _button;
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
                DropdownTextfieldButton("USER", data.Username);
                if(Outcome != "ARO")
                    DropdownTextfieldButton("SUMM", "RF Tap Down");
                else if(Outcome != "PR")
                {
                    HotkeyController.browser.TextField(Find.ByName("ctl00_cphPage_tx_TruckRollStatus")).Value = Enum.GetName(typeof(BookingType), data.Booking.Type);
                    HotkeyController.browser.TextField(Find.ByName("ctl00_cphPage_tx_ScheduleStartTime")).Value = data.Booking.GetDate;
                }
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
                DropdownTextfieldButton("UIN", data.Username);
                if (!String.IsNullOrEmpty(data.Fault.INC))
                    DropdownTextfieldButton("UIN", data.Fault.INC);
            }

            // NFV ////////////////////////////////////////////////////////////////////////////////////////////////
            if (AffectedServices.Has(ServiceTypes.NFV))
            {
                if (firstFault == true)
                    bundleFault = true;
                firstFault = true;
                DropdownTextfieldButton("A", data.DN);             
            }

            // NBF ////////////////////////////////////////////////////////////////////////////////////////////////
            if (AffectedServices.Has(ServiceTypes.NBF))
            {
                if (firstFault == true)
                    bundleFault = true;
                firstFault = true;
            }

            // MTV ////////////////////////////////////////////////////////////////////////////////////////////////
            if (AffectedServices.Has(ServiceTypes.MTV))
            {
                if (firstFault == true)
                    bundleFault = true;
                firstFault = true;

                DropdownTextfieldButton("SUMM", data.Service.MeTVSN);
            }

            // MISC ///////////////////////////////////////////////////////////////////////////////////////////////
            if (bundleFault == true)
                DropdownTextfieldButton("SUMM", "Bundle Fault");
        }

        public static void DropdownTextfieldButton(string _dropdown, string _field)
        {
            if(!String.IsNullOrEmpty(_field))
            {
                HotkeyController.browser.SelectList(Find.ById("ctl00_cphPage_F001_Aff_Svc_ProxyPR1_ddAffectedServices")).Select(_dropdown);
                HotkeyController.browser.TextField(Find.ById(IFMSDropdownElements[_dropdown].Field)).Value = _field;
                HotkeyController.browser.Button(Find.ById(IFMSDropdownElements[_dropdown].Button)).Click();
            }
        }
    }
}
