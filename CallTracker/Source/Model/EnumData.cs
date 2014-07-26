using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallTracker.Model
{
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

    public enum FaultSeverity
    {
        I, D, N, H
    }

    public enum Outcomes
    {
        PR, ARO, CM, CPE, NFF
    }
}
