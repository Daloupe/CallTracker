//using System.ComponentModel;
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
    [ProtoContract]
    public class FaultModel
    {
        public static ITCasePattern ITCasePattern = new ITCasePattern();

        [ProtoMember(1)]
        public string NPR { get; set; }
        [ProtoMember(2)]
        public string PR { get; set; }
        [ProtoMember(3)]
        public string INC { get; set; }
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
            get { return affectedServiceType; }
            set 
            { 
                affectedServiceType = value;
                ProductCode = Enum.GetName(typeof(ServiceTypes), affectedServiceType);
            }
        }
        public ServiceTypes affectedServiceType { get; set; }
        
        [ProtoMember(10)]
        public string Severity { get; set; }
        [ProtoMember(11)]
        public string Symptom { get; set; }
        [ProtoMember(12)]
        public string Outcome { get; set; }
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
                    Service = query.First();
                }
            }
        }
        public string ProblemStyle 
        { 
            get 
            {
                if (AffectedServiceType == ServiceTypes.NONE)
                    return String.Empty;
                return (from a in Main.ServicesStore.servicesDataSet.ProblemStyles
                        where a.Id == Service.ProblemStyleId
                        select a).First().IFMSCode; 
            } 
        }

        public string SymptomGroup 
        { 
            get 
            {
                if (AffectedServiceType == ServiceTypes.NONE)
                    return String.Empty;
                return (from a in Main.ServicesStore.servicesDataSet.SymptomGroups
                        from b in a.GetServiceSymptomGroupMatchRows()
                        from c in a.GetSymptomGroupSymptomMatchRows()
                        where b.ServiceId == Service.Id &&
                              c.SymptomsRow.IFMSCode == Symptom
                        select a).First().IFMSCode;
            } 
        }

        //[ProtoMember(15)]
        //public BookingModel Booking { get; set; }       

        public static List<string> FaultSeverity = new List<string>
        {
            "I", "D", "N", "H"
        };

        public FaultModel()
        {
            PR = String.Empty;
            NPR = String.Empty;
            ITCase = String.Empty;
            Severity = String.Empty;
            Symptom = String.Empty;
            Outcome = String.Empty;
            //Booking = new BookingModel();
            AffectedServices = AffectedServiceType = ServiceTypes.NONE;
        }

        public bool LAT
        {
            get { return AffectedServices.Has(ServiceTypes.LAT); }
            set 
            {
                if (value)
                    AffectedServices = RemoveNBN(AffectedServices.Remove(ServiceTypes.LIP)
                                                                 .Add(ServiceTypes.LAT));
                else
                    AffectedServices = RemoveNBN(AffectedServices.Remove(ServiceTypes.LAT));        
            }
        }

        public bool LIP
        {
            get { return AffectedServices.Has(ServiceTypes.LIP); }
            set 
            {
                if (value)
                    AffectedServices = RemoveNBN(AffectedServices.Remove(ServiceTypes.LAT)
                                                                 .Add(ServiceTypes.LIP)); 
                else
                    AffectedServices = RemoveNBN(AffectedServices.Remove(ServiceTypes.LIP));    
            }
        }

        public bool ONC
        {
            get { return AffectedServices.Has(ServiceTypes.ONC); }
            set { AffectedServices = RemoveNBN(AffectedServices.Change(ServiceTypes.ONC, value)); }
        }

        public bool DTV
        {
            get { return AffectedServices.Has(ServiceTypes.DTV); }
            set { AffectedServices = RemoveNBN(AffectedServices.Change(ServiceTypes.DTV, value)); }
        }

        public bool NBF
        {
            get { return AffectedServices.Has(ServiceTypes.NBF); }
            set { AffectedServices = RemoveHFC(AffectedServices.Change(ServiceTypes.NBF, value)); }
        }

        public bool NFV
        {
            get { return AffectedServices.Has(ServiceTypes.NFV); }
            set { AffectedServices = RemoveHFC(AffectedServices.Change(ServiceTypes.NFV, value)); }
        }

        public bool MTV
        {
            get { return AffectedServices.Has(ServiceTypes.MTV); }
            set { AffectedServices = AffectedServices.Change(ServiceTypes.MTV, value); }
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
    }    

}
