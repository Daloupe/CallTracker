using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using ProtoBuf;
using PropertyChanged;
using Utilities.RegularExpressions;

using CallTracker.Helpers;
using CallTracker.View;
using CallTracker.DataSets;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]//(SkipConstructor = true)]
    public partial class FaultModel
    {
        public FaultModel()
        {
            PR = String.Empty;
            NPR = String.Empty;
            ITCase = String.Empty;
            Severity = String.Empty; // "I";
            Symptom = String.Empty; //"NDT";
            Outcome = "Fault"; //"PR";
            Action = String.Empty;
            //Booking = new BookingModel();
            AffectedServices = ServiceTypes.NONE;
            AffectedServiceType = ServiceTypes.NONE;
        }

        public FaultModel(string symptom, string action, string outcome, ServiceTypes affectedService)
        {
            PR = String.Empty;
            NPR = String.Empty;
            ITCase = String.Empty;
            Symptom = symptom;
            Action = action;
            Outcome = outcome;
            AffectedServices = affectedService;

        }

        //[ProtoBeforeDeserialization]
        //private void FieldInitializer()
        //{
        //    AffectedServices = ServiceTypes.NONE;
        //    AffectedServiceType = ServiceTypes.NONE;
        //}

        public static ITCasePattern ITCasePattern = new ITCasePattern();

        [ProtoMember(1)]
        public string NPR { get; set; }
        [ProtoMember(2)]
        public string PR { get; set; }
        [ProtoMember(3)]
        public string INC { get; set; }
        [ProtoMember(20)]
        public string APT { get; set; }
        [ProtoMember(4)]
        public string ITCase { get; set; }

        public ServiceTypes AffectedServices { get; set; }
        [ProtoMember(5)]
        private int AffectedServicesSerialized
        {
            get { return (int)AffectedServices; }
            set { AffectedServices = (ServiceTypes)value; }
        }

        [ProtoMember(6), DefaultValue(ServiceTypes.NONE)]
        public ServiceTypes AffectedServiceType
        {
            get { return _affectedServiceType; }
            set 
            { 
                _affectedServiceType = value;
                ProductCode = Enum.GetName(typeof(ServiceTypes), _affectedServiceType);
            }
        }
        private ServiceTypes _affectedServiceType;
        
        [ProtoMember(10)]
        public string Severity { get; set; }
        [ProtoMember(11)]
        public string Symptom { get; set; }
        [ProtoMember(12)]
        public string Outcome { get; set; }
        [ProtoMember(13)]
        public string Action { get; set; }

        //public string ProductCode { get { return AffectedServiceType != ServiceTypes.NONE ? EditContact.ServiceViews[AffectedServiceType].ProductCode : String.Empty; } }
        public ServicesDataSet.ServicesRow Service { get; set; }
        public string ProductCode
        {
            get
            {
                if (AffectedServiceType != ServiceTypes.NONE && Service != null)
                    return Service.ProductCode;
                return String.Empty;
            }
            set
            {
                if (value != "NONE")
                {
                    var query = from a in Main.ServicesStore.servicesDataSet.Services
                                where a.ProductCode == value
                                select a;
                    Service = query.FirstOrDefault();
                }
            }
        }
        public string ProblemStyle 
        { 
            get
            {
                if (AffectedServiceType == ServiceTypes.NONE)
                    return String.Empty;
                var problemStylesRow = (from a in Main.ServicesStore.servicesDataSet.ProblemStyles
                    where a.Id == Service.ProblemStyleId
                    select a).FirstOrDefault();

                return problemStylesRow != null ? problemStylesRow.IFMSCode : String.Empty;
            }
        }

        public string SymptomGroup 
        { 
            get
            {
                if (AffectedServiceType == ServiceTypes.NONE)
                    return String.Empty;
                
                var symptomGroupsRow = (from a in Main.ServicesStore.servicesDataSet.SymptomGroups
                    from b in a.GetServiceSymptomGroupMatchRows()
                    from c in a.GetSymptomGroupSymptomMatchRows()
                    where b.ServiceId == Service.Id &&
                          c.SymptomsRow.IFMSCode == Symptom
                    select a).FirstOrDefault();

                return symptomGroupsRow != null ? symptomGroupsRow.IFMSCode : String.Empty;
            }
        }

        public string SymptomFull
        {
            get
            {
                if (AffectedServiceType == ServiceTypes.NONE || Symptom == null)
                    return String.Empty;

                var firstOrDefault = (from a in Main.ServicesStore.servicesDataSet.Symptoms
                    where a.IFMSCode == Symptom
                    select a).FirstOrDefault();
                if (firstOrDefault != null)
                    return Symptom + " - " + firstOrDefault.Description;
                
                return String.Empty;
            }
        }

        //[ProtoMember(15)]
        //public BookingModel Booking { get; set; }       

        public static List<string> FaultSeverity = new List<string>
        {
            "I", "D", "N", "H"
        };

        public bool LAT
        {
            get { return AffectedServices.Has(ServiceTypes.LAT); }
            set 
            {
                var temp = AffectedServices;
                if (value)
                    temp = RemoveNBN(temp.Add(ServiceTypes.LAT)
                                         .Remove(ServiceTypes.LIP));

                else
                    temp = RemoveNBN(temp.Remove(ServiceTypes.LAT));

                AffectedServices = temp;
            }
        }

        public bool LIP
        {
            get { return AffectedServices.Has(ServiceTypes.LIP); }
            set 
            {
                var temp = AffectedServices;
                if (value)
                    temp = RemoveNBN(temp.Remove(ServiceTypes.LAT)
                                         .Add(ServiceTypes.LIP)); 
                else
                    temp = RemoveNBN(temp.Remove(ServiceTypes.LIP));
                AffectedServices = temp;
            }
        }

        public bool ONC
        {
            get { return AffectedServices.Has(ServiceTypes.ONC); }
            set { var temp = AffectedServices; temp = RemoveNBN(temp.Change(ServiceTypes.ONC, value)); AffectedServices = temp; }
        }

        public bool DTV
        {
            get { return AffectedServices.Has(ServiceTypes.DTV); }
            set { var temp = AffectedServices; temp = RemoveNBN(temp.Change(ServiceTypes.DTV, value)); AffectedServices = temp; }
        }

        public bool NBF
        {
            get { return AffectedServices.Has(ServiceTypes.NBF); }
            set { var temp = AffectedServices; temp = RemoveHFC(temp.Change(ServiceTypes.NBF, value)); AffectedServices = temp; }
        }

        public bool NFV
        {
            get { return AffectedServices.Has(ServiceTypes.NFV); }
            set { var temp = AffectedServices; temp = RemoveHFC(temp.Change(ServiceTypes.NFV, value)); AffectedServices = temp; }
        }

        public bool MTV
        {
            get { return AffectedServices.Has(ServiceTypes.MTV); }
            set { var temp = AffectedServices; temp = temp.Change(ServiceTypes.MTV, value); AffectedServices = temp; }
        }

        public ServiceTypes RemoveNBN(ServiceTypes services)
        {
            return services.Remove(ServiceTypes.NBF)
                           .Remove(ServiceTypes.NFV);
        }

        public ServiceTypes RemoveHFC(ServiceTypes services)
        {
            return services.Remove(ServiceTypes.LAT)
                           .Remove(ServiceTypes.LIP)
                           .Remove(ServiceTypes.ONC)
                           .Remove(ServiceTypes.DTV);
        }

        public bool FindITCaseMatch(string text)
        {
            var match = ITCasePattern.Match(text);
            if (match.Success)
            {
                ITCase = text;

                Main.FadingToolTip.ShowandFade("IT Case: " + ITCase);
                return true;
            };
            return false;
        }

        public bool FindPRMatch(string text)
        {
            if (text.Substring(0, 1) == "1" && text.Length == 8)
            {
                PR = text;
                Main.FadingToolTip.ShowandFade("PR: " + PR);

                return true;
            }
            return false;
        }
    }    

}
