//using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using ProtoBuf;
using PropertyChanged;

using CallTracker.Helpers;
using CallTracker.View;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class FaultModel
    {
        [ProtoMember(1)]
        public string NPR { get; set; }
        [ProtoMember(2)]
        public string PR { get; set; }
        [ProtoMember(3)]
        public string INC { get; set; }

        public ServiceTypes AffectedServices { get; set; }
        [ProtoMember(5)]
        private int AffectedServicesSerialized
        {
            get { return (int)AffectedServices; }
            set { AffectedServices = (ServiceTypes)value; }
        }
        [ProtoMember(6), DefaultValue(ServiceTypes.NONE)]
        public ServiceTypes AffectedServiceType { get; set; }

        
        [ProtoMember(10)]
        public string Severity { get; set; }
        [ProtoMember(11)]
        public string Symptom { get; set; }
        [ProtoMember(12)]
        public string Outcome { get; set; }
        public string ProductCode { get { return AffectedServiceType != ServiceTypes.NONE ? EditContact.ServiceViews[AffectedServiceType].ProductCode : String.Empty; } }
        public string ProblemStyle { get { return AffectedServiceType != ServiceTypes.NONE ? EditContact.ServiceViews[AffectedServiceType].ProblemStyle : String.Empty; } }
        public string SymptomGroup { get { return AffectedServiceType != ServiceTypes.NONE ? EditContact.ServiceViews[AffectedServiceType].SymptomGroup : String.Empty; } }

        [ProtoMember(15)]
        public BookingModel Booking { get; set; }       

        public static List<string> FaultSeverity = new List<string>
        {
            "I", "D", "N", "H"
        };

        public FaultModel()
        {
            PR = String.Empty;
            NPR = String.Empty;
            Severity = String.Empty;
            Symptom = String.Empty;
            Outcome = String.Empty;
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

    public enum ServiceTypes
    {
        NONE = 0,
        LAT = 1,
        LIP = 1 << 2,
        ONC = 1 << 3,
        NFV = 1 << 4,
        NBF = 1 << 5,
        DTV = 1 << 6,
        MTV = 1 << 7
    }

    public enum FaultSeverity
    {
        I, D, N, H
    }

    public enum Outcomes
    {
        PR, ARO, CM, CPE, NFF
    }

}
