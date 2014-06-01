//using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    //[ImplementPropertyChanged]
    //public class Person
    //{
    //    public string GivenNames { get; set; }
    //    public string FamilyName { get; set; }

    //    public string FullName
    //    {
    //        get
    //        {
    //            return string.Format("{0} {1}", GivenNames, FamilyName);
    //        }
    //    }
    //}

    [ImplementPropertyChanged]
    [ProtoContract]
    public class FaultModel
    {
        [ProtoMember(1)]
        public string NPR { get; set; }
        [ProtoMember(8)]
        public string PR { get; set; }
        [ProtoMember(2)]
        public string INC { get; set; }
        [ProtoMember(3)]
        public short AffectedServices { get; set; }
        [ProtoMember(4)]
        public string Severity { get; set; }
        [ProtoMember(5)]
        public string Symptom { get; set; }
        [ProtoMember(6)]
        public string Outcome { get; set; }
        [ProtoMember(7)]
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
            AffectedServices = 1;
            //AffectedProducts = new List<AffectedProduct>();
            //AffectedProducts.Add(new AffectedProduct(AffectedService.LAT, true));
            //AffectedProducts.Add(new AffectedProduct(AffectedService.LIP, false));
            //AffectedProducts.Add(new AffectedProduct(AffectedService.ONC, false));
            //AffectedProducts.Add(new AffectedProduct(AffectedService.NVF, false));
            //AffectedProducts.Add(new AffectedProduct(AffectedService.NBF, false));
            //AffectedProducts.Add(new AffectedProduct(AffectedService.DTV, false));
            //AffectedProducts.Add(new AffectedProduct(AffectedService.MTV, false));

            //AffectedProducts = new AffectedProduct[7]
            //    {
            //        new AffectedProduct(AffectedService.LAT, true),
            //        new AffectedProduct(AffectedService.LIP, false),
            //        new AffectedProduct(AffectedService.ONC, false),
            //        new AffectedProduct(AffectedService.NVF, false),
            //        new AffectedProduct(AffectedService.NBF, false),
            //        new AffectedProduct(AffectedService.DTV, false),
            //        new AffectedProduct(AffectedService.MTV, false)
            //    };
        }
    }

    public enum AffectedService
    {
        LAT, LIP, ONC, NVF, NBF, DTV, MTV, NIL
    }

    public enum FaultSeverity
    {
        I, D, N, H
    }

    public enum Outcomes
    {
        PR, ARO, CM, CPE, NFF
    }

    //public class AffectedProduct
    //{
    //    public AffectedService Name { get; set; }
    //    public bool Selected { get; set; }
    //    public AffectedProduct(AffectedService _name, bool _selected)
    //    {
    //        Name = _name;
    //        Selected = _selected;
    //    }
    //    public AffectedProduct()
    //    {
    //        Name = AffectedService.NIL;
    //        Selected = false;
    //    }
    //}
}
