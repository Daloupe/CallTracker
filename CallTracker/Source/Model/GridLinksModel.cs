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
                new SystemItem { System = "Google", Title = "Google", Url = "https://www.google.com.au/"},
                new SystemItem { System = "Yahoo", Title = "Yahoo", Url = "https://login.yahoo.com/config/login_verify2?&.src=ym&.intl=au"},
                new SystemItem { System = "Hotmail", Title = "Hotmail", Url = "http://www.yahoo.com"},
                new SystemItem { System = "ICON", Title = "ICON", Url = "http://www.yahoo.com"},
                new SystemItem { System = "IFMS", Title = "IFMST", Url = "http://www.yahoo.com"},
                new SystemItem { System = "SCAMPS", Title = "SCAMPST", Url = "http://www.yahoo.com"},
                new SystemItem { System = "DIMPS", Title = "DIMPST", Url = "http://www.yahoo.com"},
                new SystemItem { System = "Nexus", Title = "NexusT", Url = "http://www.yahoo.com"},
                new SystemItem { System = "MAD", Title = "MADT", Url = "http://www.yahoo.com"},
                new SystemItem { System = "WOBS", Title = "WobsT", Url = "http://www.yahoo.com"}
            };

            GridLinkList = new List<GridLinksItem>();
        }

        public void PopulateIfEmpty()
        {
            if (GridLinkList.Count == 0)
            {
                int index = 0;
                foreach (var SystemItem in SystemItems)
                {
                    GridLinkList.Add(new GridLinksItem { System = SystemItem.System, Index = index });
                    index++;
                }
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
