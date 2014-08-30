using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using Castle.Core.Internal;
using PropertyChanged;
using ProtoBuf;
using Utilities.RegularExpressions;

using CallTracker.View;
using CallTracker.Helpers;

namespace CallTracker.Model
{

    public class SystemModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public List<SearchModel> Searches { get; set; }

        public SystemModel(string name, string title, string url, List<SearchModel> searches)
        {
            Name = name;
            Title = title;
            Url = url;
            Searches = searches;
        }

        public void DoAutoSearch(CustomerContact contact, string dataName)
        {
            var search = Searches.FirstOrDefault(x => x.Name == dataName && x.AutoSearch);
            if (search == null ) return;
            if (contact.Service.WasSearched[Name]) return;

            HotkeyController.AutoSearch(search.GetSearchUrl(contact), Title, Url);
            contact.Service.WasSearched[Name] = true;
        }

        public class SearchModel
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public string Data { get; set; }
            public bool AutoSearch { get; set; }

            public SearchModel(string name, string url, string data, bool autoSearch = false)
            {
                Name = name;
                Url = Url;
                Data = Data;
                AutoSearch = autoSearch;
            }

            public string GetSearchUrl(CustomerContact contact)
            {
                var url = String.Empty;
                var data = FindProperty.FollowPropertyPath(contact, Data);
                if (!String.IsNullOrEmpty(data))
                    url = String.Format(Url, data);
                return url;
            }
        }
    }
}



//    public static List<SystemModel> Systems = new List<SystemModel>
//{
//    new SystemModel("IFMS", "IFMS", "ifmsprod.optus.com.au/IFMSWeb1P/Secure/SignIn.aspx", 
//        new List<SystemModel.SearchModel>
//        {
//            new SystemModel.SearchModel("PR", "http://ifmsprod.optus.com.au/IFMSWeb1P/PR%20Manage/F012_ProblemDetail.aspx?SD_NO={0}", "Fault.PR", true),
//            new SystemModel.SearchModel("Node", "http://ifmsprod.optus.com.au/IFMSWeb1P/PR%20Manage/F139_SearchByNode.aspx?id={0}", "Service.Node"),
//        }),                 
//    new SystemModel("SCAMPS", "SCaMPS", "scamps.optusnet.com.au/", 
//        new List<SystemModel.SearchModel>
//        {
//            new SystemModel.SearchModel("Username", "https://scamps.optusnet.com.au/cm.html?q={0}", "Username", true),
//            new SystemModel.SearchModel("DN", "https://scamps.optusnet.com.au/cm.html?q={0}", "DN", true),
//        }),             
//    new SystemModel("DIMPS", "DIMPS", "dimps.optusnet.com.au/search.html", 
//        new List<SystemModel.SearchModel>
//        {
//            new SystemModel.SearchModel("Username", "https://dimps.optusnet.com.au/display.html?username={0}", "Username", true),
//            new SystemModel.SearchModel("DN", "https://dimps.optusnet.com.au/search/servno?servno={0}", "DN|0$1$2$3", true),
//            new SystemModel.SearchModel("CMBS", "https://dimps.optusnet.com.au/search/account?account_no={0}", "CMBS|3$1${2}0$3")
//        }),       
//    new SystemModel("Nexus", "Nexus", "nexus.optus.com.au", 
//        new List<SystemModel.SearchModel>
//        {
//            new SystemModel.SearchModel("DN", "http://nexus.optus.com.au/index.php?#service/{0}", "DN|0$1$2$3", true),
//            new SystemModel.SearchModel("ICON", "http://nexus.optus.com.au/index.php?#account/{0}", "ICON", true),
//            new SystemModel.SearchModel("CMBS", "http://nexus.optus.com.au/index.php?#account/{0}", "CMBS|3$1${2}0$3", true),
//            new SystemModel.SearchModel("Mobile", "http://nexus.optus.com.au/index.php?#service/{0}", "Mobile|0$1$2"),
//        }),
//    new SystemModel("UNMT", "UNMT", "staff.optusnet.com.au/tools/usernames/", 
//        new List<SystemModel.SearchModel>
//        {
//            new SystemModel.SearchModel("Username", "https://staff.optusnet.com.au/tools/usernames/users.html?username={0}", "Username", true)
//        }),
//    new SystemModel("NSI", "NSI", "staff.optusnet.com.au/tools/nsi/", 
//        new List<SystemModel.SearchModel>
//        {
//            new SystemModel.SearchModel("PRI", "https://staff.optusnet.com.au/tools/nsi/avc_detail.html?gsid={0}", "Service.PRI|$2"),
//            new SystemModel.SearchModel("AVC", "https://staff.optusnet.com.au/tools/nsi/avc_detail.html?avcid={0}", "Service.AVC|$1$2"),
//            new SystemModel.SearchModel("CVC", "https://staff.optusnet.com.au/tools/nsi/avc_detail.html?cvcid={0}", "Service.CVC|$1$2")
//        }),
//    new SystemModel("Google", "Google", "www.google.com", 
//        new List<SystemModel.SearchModel>
//        {
//            new SystemModel.SearchModel("DN", "https://www.google.com/{0}", "DN|0$1$2$3"),
//        })
//};
