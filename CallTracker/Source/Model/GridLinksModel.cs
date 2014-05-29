using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    [ProtoContract]
    public class GridLinksModel
    {
        [ProtoMember(1)]
        public List<GridLinksItem> GridLinkList { get; set; }

        public List<SystemItem> SystemItems { get; set; }

        public GridLinksModel()
        {
            SystemItems = new List<SystemItem>
            {
                new SystemItem { System = "ICON", Title = "Interactive Contact Management", Url = "http://icon.optus.com.au/icon/cm/login/main.aspx"},
                new SystemItem { System = "WOBS", Title = "Optus - WOBS", Url = "http://ohun8442:7001/problemReport/jsp/TroubleCallLogin.jsp"},
                new SystemItem { System = "IFMS", Title = "IFMS", Url = "https://ifmsprod.optus.com.au/IFMSWeb1P/Secure/SignIn.aspx"},
                new SystemItem { System = "SCAMPS", Title = "SCaMPS", Url = "https://scamps.optusnet.com.au/"},
                new SystemItem { System = "DIMPS", Title = "DIMPS", Url = "https://dimps.optusnet.com.au/search.html"},
                new SystemItem { System = "Nexus", Title = "Nexus", Url = "http://nexus.optus.com.au"},
                new SystemItem { System = "NSI", Title = "NSI", Url = "http://www.yahoo.com"},
                new SystemItem { System = "SoftAct", Title = "Softact", Url = "http://opmprdapph001.optus.com.au:8032/"},
                new SystemItem { System = "OPOM", Title = "OPOM", Url = "http://www.yahoo.com"},
                new SystemItem { System = "MAD", Title = "Oracle Forms Runtime", Url = "http://www.yahoo.com"}
            };

            GridLinkList = new List<GridLinksItem>();
        }

        public void PopulateIfEmpty()
        {
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

    public class SystemItem
    {
        public string System { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public SystemItem()
        {
            System = String.Empty;
            Title = String.Empty;
            Url = String.Empty;
        }
    }
}
