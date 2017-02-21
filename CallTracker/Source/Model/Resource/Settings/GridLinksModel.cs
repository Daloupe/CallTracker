using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class GridLinksModel
    {
        [ProtoMember(1)]
        public BindingList<GridLinksItem> GridLinkList { get; set; }
        [ProtoMember(2)]
        public BindingList<SystemItem> SystemItems { get; set; }
 
        public GridLinksModel()
        {
            SystemItems = new BindingList<SystemItem>();
            GridLinkList = new BindingList<GridLinksItem>();
        }

        public void PopulateIfEmpty()
        {
            if (GridLinkList.Count == 0 || SystemItems.Count == 0)
            {
                Populate();
            }
        }

        public void Populate()
        {
            SystemItems = new BindingList<SystemItem>
                {
                    new SystemItem { System = "ICON", Title = "Interactive Contact Management", Url = "http://icon.optus.com.au/icon/cm/login/main.aspx"},
                    new SystemItem { System = "WOBS", Title = "Optus - WOBS", Url = "http://ohun8442:7001/problemReport/jsp/TroubleCallLogin.jsp"},
                    
                    
                    new SystemItem { System = "IFMS", Title = "IFMS", Url = "https://ifmsprod.optus.com.au/IFMSWeb1P/Secure/SignIn.aspx", 
                        Searches = new List<SearchItem>
                        {
                            new SearchItem{SearchURL = "http://ifmsprod.optus.com.au/IFMSWeb1P/PR%20Manage/F012_ProblemDetail.aspx?SD_NO=", SearchData = "Fault.PR"},
                            new SearchItem{SearchURL = "http://ifmsprod.optus.com.au/IFMSWeb1P/PR%20Manage/F139_SearchByNode.aspx?id=", SearchData = "Service.Node"}
                        }},
                    
                        
                    new SystemItem { System = "SCAMPS", Title = "SCaMPS", Url = "https://scamps.optusnet.com.au/", 
                        Searches = new List<SearchItem>
                        {
                            new SearchItem{SearchURL = "https://scamps.optusnet.com.au/cm.html?q=", SearchData = "^ONCUsername,DN^LIPDN,Username"},
                        }},
                                         
                    new SystemItem { System = "Nexus", Title = "Nexus", Url = "http://nexus.optus.com.au", 
                        Searches = new List<SearchItem>
                        {
                            new SearchItem{SearchURL = "http://nexus.optus.com.au/index.php?#service/", SearchData = "DN|0$1"},
                            new SearchItem{SearchURL = "http://nexus.optus.com.au/index.php?#account/", SearchData = "ICON,CMBS|3$1${2}0$3"},
                            new SearchItem{SearchURL = "http://nexus.optus.com.au/index.php?#service/", SearchData = "Mobile|0$1"},
                        }},
                        
                    new SystemItem { System = "DIMPS", Title = "DIMPS", Url = "https://dimps.optusnet.com.au/", 
                        Searches = new List<SearchItem>
                        {
                            new SearchItem{SearchURL = "https://dimps.optusnet.com.au/display.html?username=", SearchData = "Username"},
                            new SearchItem{SearchURL = "https://dimps.optusnet.com.au/search/servno?servno=", SearchData = "DN|0$1"},
                            new SearchItem{SearchURL = "https://dimps.optusnet.com.au/search/account?account_no=", SearchData = "CMBS|3$1${2}0$3"}
                        }},               
                        
                    new SystemItem { System = "NSI", Title = "NSI", Url = "https://staff.optusnet.com.au/tools/nsi/", 
                        Searches = new List<SearchItem>
                        {
                            new SearchItem{SearchURL = "https://staff.optusnet.com.au/tools/nsi/avc_detail.html?gsid=", SearchData = "Service.GSID"},
                            new SearchItem{SearchURL = "https://staff.optusnet.com.au/tools/nsi/avc_detail.html?avcid=", SearchData = "Service.AVC|$1$2"},
                            new SearchItem{SearchURL = "https://staff.optusnet.com.au/tools/nsi/avc_detail.html?cvcid=", SearchData = "Service.CVC|$1$2"}
                        }},
                    new SystemItem { System = "SoftAct", Title = "Softact", Url = "http://opmprdapph001.optus.com.au:8032/"},
                    new SystemItem { System = "OPOM", Title = "Service Instance Search", Url = "OPOM"},
                    new SystemItem { System = "MAD", Title = "Oracle Forms Runtime", Url = "MAD"}
                };

            GridLinkList.Clear();

            var index = 0;
            foreach (var systemItem in SystemItems)
            {
                GridLinkList.Add(new GridLinksItem { System = systemItem.System, Index = index });
                index++;
            }
        }

        public SystemItem GetSystemItem(int index)
        {
            return SystemItems.FirstOrDefault(s => s.System == GridLinkList[index].System);   
        }
    }
    
    //[ImplementPropertyChanged]
    [ProtoContract]
    public class GridLinksItem
    {
        [ProtoMember(1)]
        public int Index { get; set; }
        [ProtoMember(2)]
        public string System { get; set; }

        public GridLinksItem()
        {
            System = String.Empty;
            Index = 0;
        }
    }
    [ProtoContract]
    public class SystemItem
    {
        [ProtoMember(1)]
        public string System { get; set; }
        [ProtoMember(2)]
        public string Title { get; set; }
        [ProtoMember(3)]
        public string Url { get; set; }
        [ProtoMember(4)]
        public bool AutoLogin { get; set; }
        [ProtoMember(5)]
        public List<SearchItem> Searches { get; set; }


        public SystemItem()
        {
            System = String.Empty;
            Title = String.Empty;
            Url = String.Empty;
            AutoLogin = true;
            Searches = new List<SearchItem>();
        }
    }
    
    [ProtoContract]
    public class SearchItem
     {
        [ProtoMember(1)]
        public string SearchURL { get; set; }
        [ProtoMember(2)]
        public string SearchData { get; set; }

        public SearchItem()
        {
            SearchURL = String.Empty;
            SearchData = String.Empty;
        }


    }
}
