using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Windows.Forms.VisualStyles;
using ProtoBuf;
using PropertyChanged;

using System.Collections.Generic;

using CallTracker.Helpers;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class GridLinksModel
    {
        [ProtoMember(1)]
        public List<GridLinksItem> GridLinkList { get; set; }
        [ProtoMember(2)]
        public List<SystemItem> SystemItems { get; set; }
 
        public GridLinksModel()
        {
            SystemItems = new List<SystemItem>();
            GridLinkList = new List<GridLinksItem>();
        }

        public void PopulateIfEmpty()
        {
            if (SystemItems.Count == 0)
            {
                SystemItems = new List<SystemItem>
                {
                    new SystemItem { System = "ICON", Title = "Interactive Contact Management", Url = "http://icon.optus.com.au/icon/cm/login/main.aspx"},
                    new SystemItem { System = "WOBS", Title = "Optus - WOBS", Url = "http://ohun8442:7001/problemReport/jsp/TroubleCallLogin.jsp"},
                    
                    
                    new SystemItem { System = "IFMS", Title = "IFMS", Url = "https://ifmsprod.optus.com.au/IFMSWeb1P/Secure/SignIn.aspx", 
                        Searches = new List<SearchItem>
                        {
                            new SearchItem{SearchURL = "http://ifmsprod.optus.com.au/IFMSWeb1P/PR%20Manage/F012_ProblemDetail.aspx?SD_NO=", SearchData = new[]{"Fault.PR"}},
                            new SearchItem{SearchURL = "http://ifmsprod.optus.com.au/IFMSWeb1P/PR%20Manage/F139_SearchByNode.aspx?id=", SearchData = new[]{"Service.Node"}}
                        }},
                    
                        
                    new SystemItem { System = "SCAMPS", Title = "SCaMPS", Url = "https://scamps.optusnet.com.au/", 
                        Searches = new List<SearchItem>
                        {
                            new SearchItem{SearchURL = "https://scamps.optusnet.com.au/cm.html?q=", SearchData = new[]{"Username", "DN"}},
                        }},
                    
                        
                    new SystemItem { System = "DIMPS", Title = "DIMPS", Url = "https://dimps.optusnet.com.au/search.html", 
                        Searches = new List<SearchItem>
                        {
                            new SearchItem{SearchURL = "https://dimps.optusnet.com.au/display.html?username=", SearchData = new[]{"Username"}},
                            new SearchItem{SearchURL = "https://dimps.optusnet.com.au/search/servno?servno=", SearchData = new[]{"DN|0$1$2$3"}},
                            new SearchItem{SearchURL = "https://dimps.optusnet.com.au/search/account?account_no=", SearchData = new[]{"CMBS|3$1${2}0$3"}}
                        }},
                    
                        
                     new SystemItem { System = "Nexus", Title = "Nexus", Url = "http://nexus.optus.com.au", 
                        Searches = new List<SearchItem>
                        {
                            new SearchItem{SearchURL = "http://nexus.optus.com.au/index.php?#service/", SearchData = new[]{"DN|0$1$2$3"}},
                            new SearchItem{SearchURL = "http://nexus.optus.com.au/index.php?#account/", SearchData = new[]{"ICON", "CMBS|3$1${2}0$3"}},
                            new SearchItem{SearchURL = "http://nexus.optus.com.au/index.php?#service/", SearchData = new[]{"Mobile|0$1$2"}},
                        }},
                    
                        
                    new SystemItem { System = "NSI", Title = "NSI", Url = "https://staff.optusnet.com.au/tools/nsi/", 
                        Searches = new List<SearchItem>
                        {
                            new SearchItem{SearchURL = "https://staff.optusnet.com.au/tools/nsi/avc_detail.html?gsid=", SearchData = new[]{"Service.PRI|$2"}},
                            new SearchItem{SearchURL = "https://staff.optusnet.com.au/tools/nsi/avc_detail.html?avcid=", SearchData = new[]{"Service.AVC|$1$2"}},
                            new SearchItem{SearchURL = "https://staff.optusnet.com.au/tools/nsi/avc_detail.html?cvcid=", SearchData = new[]{"Service.CVC|$1$2"}}
                        }},
                    new SystemItem { System = "SoftAct", Title = "Softact", Url = "http://opmprdapph001.optus.com.au:8032/"},
                    new SystemItem { System = "Yahoo", Title = "Yahoo", Url = "http://www.yahoo.com"},
                    new SystemItem { System = "MAD", Title = "Oracle Forms Runtime", Url = "http://www.yahoo.com"}
                };
            }

            if (GridLinkList.Count == 0)
            {
                Populate();
            }
        }

        public void Populate()
        {
            GridLinkList.Clear();

            int index = 0;
            foreach (var SystemItem in SystemItems)
            {
                GridLinkList.Add(new GridLinksItem { System = SystemItem.System, Index = index });
                index++;
            }
        }

        public SystemItem GetSystemItem(int _index)
        {
            return SystemItems.Find(s => s.System == GridLinkList[_index].System);   
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
        public string[] SearchData { get; set; }

        public SearchItem()
        {
            SearchURL = String.Empty;
        }


    }
}
