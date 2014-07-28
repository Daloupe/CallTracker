﻿
using System.ComponentModel;
using System.Collections.Generic;
using System;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Forms;
//using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class ServiceModel
    {
  
        public ServiceModel()
        {
            Equipment = String.Empty;
            Node = String.Empty;
        }

        public object GetValue(string property)
        {
            PropertyInfo prop = this.GetType().GetProperty(property);
            return prop.GetValue(this, null);
        }

        public void SetValue(string property, string value)
        {
            PropertyInfo prop = this.GetType().GetProperty(property);
            prop.SetValue(this, value, null);
        }

        [ProtoMember(1)]
        public string Equipment { get; set; }
        [ProtoMember(2)]
        public string Node { get; set; }

        [ProtoMember(3)]
        public string AVC { get; set; }
        [ProtoMember(4)]
        public string CVC { get; set; }
        [ProtoMember(5)]
        public string CSA { get; set; }
        [ProtoMember(6)]
        public string NNI { get; set; }
        [ProtoMember(7)]
        public string GIS { get; set; }
        [ProtoMember(8)]
        public string Bras { get; set; }

        [ProtoMember(10)]
        public string CauPing { get; set; }
        [ProtoMember(11)]
        public string NitResults { get; set; }

        [ProtoMember(15)]
        public string ModemStatus { get; set; }
        [ProtoMember(16)]
        public string RFIssues { get; set; }
        [ProtoMember(17)]
        public string CMMac { get; set; }
        [ProtoMember(18)]
        public string MTAMac { get; set; }
        [ProtoMember(19)]
        public string ModemSN { get; set; }

        [ProtoMember(20)]
        public string DownloadSpeed { get; set; }
        [ProtoMember(21)]
        public string UploadSpeed { get; set; }
        [ProtoMember(22)]
        public string Throttled { get; set; }
        [ProtoMember(23)]
        public string ModemIP { get; set; }

        [ProtoMember(25)]
        public string DTVMsg { get; set; }
        [ProtoMember(26)]
        public string DTVSmartCard { get; set; }
        [ProtoMember(27)]
        public string DTVLot { get; set; }
        [ProtoMember(28)]
        public string DTVBox { get; set; }
        [ProtoMember(29)]
        public string ConnectionType { get; set; }

        [ProtoMember(30)]
        public string MeTVMac { get; set; }
        [ProtoMember(31)]
        public string MeTVSN { get; set; }

        //public INetworkInfo NetworkInfo { get; set; }
    }
}