using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallTracker.Model
{
    public static class DataLists
    {
        public static Dictionary<SymptomsEnum, string> SymptomsList = new Dictionary<SymptomsEnum, string>
        {
            {SymptomsEnum.NDT, "No Dial Tone"},
            {SymptomsEnum.COS, "Cut Off Speaking"},
            {SymptomsEnum.NRR, "No Rings Recieved"},
            {SymptomsEnum.DTN, "Distortion on the lind"},
            {SymptomsEnum.CCI, "Loss of Internet"},
            {SymptomsEnum.DTR, "Slow Internet"},
            {SymptomsEnum.LIC, "Internet Drop Outs"},
            {SymptomsEnum.NPI, "No Picture"},
            {SymptomsEnum.PPX, "Pixellation"},
            {SymptomsEnum.STB, "Faulty STB"},
            {SymptomsEnum.AUD, "Audio Problems"},
            {SymptomsEnum.MSG, "Foxtel On Screen Errors"},
            {SymptomsEnum.MOD, "Faulty Modem"},
            {SymptomsEnum.DRP, "Drop Cable Down"}
        };

        public static Dictionary<string, string> DepartmentsList = new Dictionary<string, string>
        {
            {"Cust Care", "Customer Care"},
            {"Faults", "Fault Management"},
            {"Sales", "Sales"},
            {"Retention", "Retention"},
            {"FS", "Financial Services"}
        };
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

    public enum DepartmentTypes
    {
        CustomerCare = 1,
        TechnicalSupport = 1 << 2,
        Sales = 1 << 3,
        Retention = 1 << 4,
        FinancialServices = 1 << 5
    }

    public enum ProductCodes
    {
        LAT,
        ONC,
        DTV,
        NBN,
        DLC,
        DLG
    }

    public enum FaultSeverity
    {
        I, D, N, H
    }

    public enum SymptomGroups : int
    {
        Phone = 3, Onnet = 6, LNP = 7
    }

    public enum SymptomsEnum
    {
        NDT, COS, NRR, DTN, CCI, DTR, LIC, NPI, PPX, STB, AUD, MSG, MOD, DRP
    }
    
    public enum Outcomes
    {
        PR, ARO, FIX, CPE, NFF, CM, XFR
    }
}
