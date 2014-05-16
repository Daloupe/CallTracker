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

        public static List<SystemItem> SystemItems = new List<SystemItem>
        {
            new SystemItem { System = "Google", Title = "Google"},
            new SystemItem { System = "Yahoo", Title = "Yahoo"},
            new SystemItem { System = "Hotmail", Title = "HotmailT"},
            new SystemItem { System = "ICON", Title = "ICONT"},
            new SystemItem { System = "IFMS", Title = "IFMST"},
            new SystemItem { System = "SCAMPS", Title = "SCAMPST"},
            new SystemItem { System = "DIMPS", Title = "DIMPST"},
            new SystemItem { System = "Nexus", Title = "NexusT"},
            new SystemItem { System = "MAD", Title = "MADT"},
            new SystemItem { System = "WOBS", Title = "WobsT"}
        };

        public GridLinksModel()
        {
            GridLinkList = new List<GridLinksItem>();
        }

        public void PopulateIfEmpty()
        {
            if (GridLinkList.Count == 0)
            {
                int index = 0;
                foreach (var SystemItem in SystemItems)
                {
                    GridLinkList.Add(new GridLinksItem { System = SystemItem.Title, Index = index });
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

        public SystemItem()
        {
            System = String.Empty;
            Title = String.Empty;
        }
    }
}
