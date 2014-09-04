using System;
using System.Collections.Generic;
using System.Reflection;
using CallTracker.Helpers;
using ProtoBuf;
using PropertyChanged;

using Utilities.RegularExpressions;
using CallTracker.View;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]//(SkipConstructor = true)]
    public class ServiceModel
    {
        public static BRASPattern BRASPattern = new BRASPattern();
        public static CommonNBNPattern NBNPattern = new CommonNBNPattern();
        public static NodePattern NodePattern = new NodePattern();
        public static MACPattern MACPattern = new MACPattern();
        public static IPPattern IPPattern = new IPPattern();
        public static AddressIdPattern AddressIdPattern = new AddressIdPattern();
        public static ESNPattern ESNPattern = new ESNPattern();
        public static NTDSNPattern NTDSNPattern = new NTDSNPattern();
        public static GSIDPattern GSIDPattern = new GSIDPattern();

        public ServiceModel()
        {
            Equipment = String.Empty;
            Node = String.Empty;
            CauPing = String.Empty;
            NitResults = String.Empty;
            ModemStatus = String.Empty;
            RFIssues = String.Empty;
            DTVLights = String.Empty;
            Throttled = String.Empty;
            WasSearched = new Dictionary<string, bool>{ { "IFMS", false }, { "Nexus", false }, { "SCAMPS", false }, { "NSI", false }, { "DIMPS", false }, { "UNMT", false } };
        }

        //[ProtoBeforeDeserialization]
        //private void FieldInitializer()
        //{
        //    WasSearched = new Dictionary<string, bool> { { "IFMS", false }, { "Nexus", false }, { "SCAMPS", false }, { "NSI", false }, { "DIMPS", false }, { "UNMT", false } };
        //}

        public object GetValue(string property)
        {
            var prop = GetType().GetProperty(property);
            return prop.GetValue(this, null);
        }

        public void SetValue(string property, string value)
        {
            var prop = GetType().GetProperty(property);
            prop.SetValue(this, value, null);
        }

        [ProtoMember(1)]
        public string Equipment { get; set; }
        [ProtoMember(2, OverwriteList = true)]
        public Dictionary<string, bool> WasSearched { get; set; }

        // HFC
        [ProtoMember(10)]
        public string Node { get; set; }

        // NBN
        [ProtoMember(20)]
        public string AVC { get; set; }
        [ProtoMember(21)]
        public string CVC { get; set; }
        [ProtoMember(22)]
        public string CSA { get; set; }
        [ProtoMember(23)]
        public string NNI { get; set; }
        [ProtoMember(24)]
        public string PRI { get; set; }
        [ProtoMember(25)]
        public string Bras { get; set; }
        [ProtoMember(26)]
        public string Sip { get; set; }
        [ProtoMember(27)]
        public string NTDSN { get; set; }
        [ProtoMember(28)]
        public string GSID { get; set; }

        // LAT
        [ProtoMember(30)]
        public string CauPing { get; set; }
        [ProtoMember(31)]
        public string NitResults { get; set; }
        [ProtoMember(32)]
        public string ESN { get; set; }

        // LIP
        [ProtoMember(40)]
        public string AddressId { get; set; }
        [ProtoMember(41)]
        public string MTAMac { get; set; }

        // Modem
        [ProtoMember(50)]
        public string ModemStatus { get; set; }
        [ProtoMember(51)]
        public string RFIssues { get; set; }
        [ProtoMember(52)]
        public string CMMac { get; set; }
        [ProtoMember(54)]
        public string ModemSN { get; set; }
        
        // Internet
        [ProtoMember(60)]
        public string DownloadSpeed { get; set; }
        [ProtoMember(61)]
        public string UploadSpeed { get; set; }
        [ProtoMember(62)]
        public string Throttled { get; set; }
        [ProtoMember(63)]
        public string ModemIP { get; set; }

        //DTV
        [ProtoMember(71)]
        public string DTVMsg { get; set; }
        [ProtoMember(72)]
        public string DTVSmartCard { get; set; }
        [ProtoMember(73)]
        public string DTVLot { get; set; }
        [ProtoMember(74)]
        public string DTVBox { get; set; }
        [ProtoMember(75)]
        public string DTVLights { get; set; }

        // MTV
        [ProtoMember(80)]
        public string MeTVMac { get; set; }
        [ProtoMember(81)]
        public string MeTVSN { get; set; }

        //public INetworkInfo NetworkInfo { get; set; }

        public bool FindBRASMatch(string text)
        {
            var match = BRASPattern.Match(text);
            if (match.Success)
            {
                Bras = text;

                Main.FadingToolTip.ShowandFade("BRAS: " + Bras);
                return true;
            };
            return false;
        }

        public bool FindNBNMatch(string text)
        {
            var match = NBNPattern.Match(text);
            if (match.Success)
            {
                FindProperty.SetPropertyFromPath(this, text.Substring(0, 3), text);
                Main.FadingToolTip.ShowandFade(text.Substring(0, 3) + ": " + text);
                return true;
            };
            return false;
        }

        public bool FindNodeMatch(string text)
        {
            var match = NodePattern.Match(text);
            if (match.Success)
            {
                Node = text;
                Main.FadingToolTip.ShowandFade("Node: " + Node);
                return true;
            };
            return false;
        }

        public bool FindMACMatch(string text)
        {
            var match = MACPattern.Match(text);
            if (match.Success)
            {
                CMMac = text;
                Main.FadingToolTip.ShowandFade("MAC: " + CMMac);
                return true;
            };
            return false;
        }

        public bool FindIPMatch(string text)
        {
            var match = IPPattern.Match(text);
            if (match.Success)
            {
                ModemIP = text;
                Main.FadingToolTip.ShowandFade("IP: " + ModemIP);
                return true;
            };
            return false;
        }

        public bool FindNTDSNMatch(string text)
        {
            var match = NTDSNPattern.Match(text);
            if (match.Success)
            {
                NTDSN = text;
                Main.FadingToolTip.ShowandFade("NTD SN: " + NTDSN);
                return true;
            };
            return false;
        }

        public bool FindAddressIdMatch(string text)
        {
            var match = AddressIdPattern.Match(text);
            if (match.Success)
            {
                AddressId = text;
                Main.FadingToolTip.ShowandFade("Address Id: " + AddressId);
                return true;
            };
            return false;
        }

        public bool FindESNMatch(string text)
        {
            var match = ESNPattern.Match(text);
            if (match.Success)
            {
                ESN = text;
                Main.FadingToolTip.ShowandFade("ESN: " + ESN);
                return true;
            };
            return false;
        }

        public bool FindGSIDMatch(string text)
        {
            var match = GSIDPattern.Match(text);
            if (match.Success)
            {
                GSID = text;
                Main.FadingToolTip.ShowandFade("GSID: " + GSID);
                return true;
            };
            return false;
        }
    }
}
