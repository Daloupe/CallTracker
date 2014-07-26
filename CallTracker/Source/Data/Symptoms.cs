using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallTracker.Data
{
    public class Symptoms
    {
        public Symptoms()
        {
            Internet = new List<string>
                {
                    "CCI",
                    "DTR",
                    "LIC"
                };

            Phone = new List<string>
                {
                    "NDT",
                    "COS",
                    "NRR",
                    "DTN"
                };

            TV = new List<string>
                {
                    "NPI",
                    "PPX",
                    "STB",
                    "AUD"
                };

            Foxtel = new List<string>
                {
                    "MSG",
                };

            Fetch = new List<string>
                {
                    "MOD",
                };

            HFC = new List<string>
                {
                    "DRP"
                };
        }

        public static List<string> Internet;

        public static List<string> Phone;

        public static List<string> TV;

        public static List<string> Foxtel;

        public static List<string> Fetch;
        public static List<string> HFC;
    }
    
}