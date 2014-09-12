using System;
using System.Collections.Generic;

using WatiN.Core;

using CallTracker.View;
using CallTracker.Model;

namespace CallTracker.Helpers
{
    public static class IFMSAutoFill
    {
        private static SelectList _affectedServicesSelectList;

        public static void Go(Main mainForm)
        {
            EventLogger.LogNewEvent("Attempting IFMS Create AutoFill", EventLogLevel.Brief);

            var contact = mainForm.SelectedContact;
            if (contact == null)
            {
                EventLogger.LogAndSaveNewEvent("IFMS AutoFill Error: Selected Contact is Null");
                return;
            }

            var affectedServices = contact.Fault.AffectedServices;
            if (affectedServices.Is(ServiceTypes.NONE))
            {
                EventLogger.LogAndSaveNewEvent("IFMS AutoFill Error: Affected Service is None");
                return;
            }    

            var outcome = mainForm.SelectedContact.Fault.Outcome;
            if (outcome == null)
            {
                outcome = String.Empty;
                EventLogger.LogNewEvent("IFMS AutoFill Error: Outcome is Null");
            }

            _affectedServicesSelectList = HotkeyController.browser.SelectList(Find.ById("ctl00_cphPage_F001_Aff_Svc_ProxyPR1_ddAffectedServices"));
            if (!_affectedServicesSelectList.Exists)
            {
                EventLogger.LogAndSaveNewEvent(String.Format("IFMS AutoFill Error: ComboBox '{0}' Doesn't Exists", _affectedServicesSelectList));
                return;
            }    

            var firstFault = false;
            var bundleFault = false;





            // LAT ////////////////////////////////////////////////////////////////////////////////////////////////
            if (affectedServices.Has(ServiceTypes.LAT | ServiceTypes.LIP))
            {
                firstFault = true;

                DropdownTextfieldButton("A", contact.DN);
            }




            // ONC ////////////////////////////////////////////////////////////////////////////////////////////////
            if (affectedServices.Has(ServiceTypes.ONC))
            {
                if (firstFault)
                    bundleFault = true;
                firstFault = true;

                DropdownTextfieldButton("CBM", StringHelpers.RemoveColons(contact.Service.CMMac));
                DropdownTextfieldButton("USER", contact.Username);
                if(outcome != "Outage")
                    DropdownTextfieldButton("SUMM", "RF Tap Down");
                else if(outcome != "Fault")
                {
                    HotkeyController.browser.TextField(Find.ByName("ctl00_cphPage_tx_TruckRollStatus")).Value = Enum.GetName(typeof(BookingType), contact.Booking.Type);
                    HotkeyController.browser.TextField(Find.ByName("ctl00_cphPage_tx_ScheduleStartTime")).Value = contact.Booking.GetDate;
                }
            }




            // DTV ////////////////////////////////////////////////////////////////////////////////////////////////
            if (affectedServices.Has(ServiceTypes.DTV))
            {
                if (firstFault)
                    bundleFault = true;
                firstFault = true;

                DropdownTextfieldButton(bundleFault ? "STU" : "STB", contact.Service.DTVSmartCard);

                if(contact.Fault.Symptom == "MSG")
                    DropdownTextfieldButton("SUMM", contact.Service.DTVMsg);
                if (contact.Service.Equipment != "Standard")
                    DropdownTextfieldButton("SUMM", contact.Service.Equipment);
            }




            // NBN ////////////////////////////////////////////////////////////////////////////////////////////////
            if (affectedServices.Has(ServiceTypes.NFV | ServiceTypes.NBF))
            {
                DropdownTextfieldButton("UIN", contact.Username);
                if (!String.IsNullOrEmpty(contact.Fault.INC))
                    DropdownTextfieldButton("UIN", contact.Fault.INC);
            }




            // NFV ////////////////////////////////////////////////////////////////////////////////////////////////
            if (affectedServices.Has(ServiceTypes.NFV))
            {
                if (firstFault)
                    bundleFault = true;
                firstFault = true;
                DropdownTextfieldButton("A", contact.DN);             
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
                //firstFault = true;

                DropdownTextfieldButton("SUMM", contact.Service.MeTVSN);
            }




            // MISC ///////////////////////////////////////////////////////////////////////////////////////////////
            if (bundleFault)
                DropdownTextfieldButton("SUMM", "Bundle Fault");

            EventLogger.SaveLog();
        }

        

        public static void DropdownTextfieldButton(string dropdown, string field)
        {
            if (String.IsNullOrEmpty(field))
            {
                EventLogger.LogNewEvent(String.Format("IFMS AutoFill Error: Data for Dropdown '{0}' is NullOrEmpty", dropdown));
                return;
            }

            var ifmsDropdownElement = IFMSDropdownElements[dropdown];
            if (ifmsDropdownElement == null)
            {
                EventLogger.LogNewEvent(String.Format("IFMS AutoFill Error: Dropdown '{0}' is Null", dropdown));
                return;
            }
            _affectedServicesSelectList.Focus();
            var option = _affectedServicesSelectList.Option(dropdown);
            if (!option.Exists)
            {
                EventLogger.LogNewEvent(String.Format("IFMS AutoFill Error: SelectList Option '{0}' Doesn't Exist", dropdown));
                return;
            }
            option.Select();     

            HotkeyController.WaitForAsyncPostBackToComplete();

            var textfield = HotkeyController.browser.TextField(Find.ById(ifmsDropdownElement.Field));
            if (!textfield.Exists)
            {
                EventLogger.LogNewEvent(String.Format("IFMS AutoFill Error: TextField '{0}' Doesn't Exist", ifmsDropdownElement.Field));
                return;
            }
            textfield.Value = field;

            var button = HotkeyController.browser.Button(Find.ById(ifmsDropdownElement.Button));
            if (!button.Exists)
            {
                EventLogger.LogNewEvent(String.Format("IFMS AutoFill Error: Button '{0}' Doesn't Exist", ifmsDropdownElement.Button));
                return;
            }       
            button.Click();
        }


        public class IFMSDropdownElement
        {
            public string Field { get; set; }
            public string Button { get; set; }
            public IFMSDropdownElement(string field, string button)
            {
                Field = field;
                Button = button;
            }
        }

        private static readonly Dictionary<string, IFMSDropdownElement> IFMSDropdownElements = new Dictionary<string, IFMSDropdownElement>
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
    }
}
