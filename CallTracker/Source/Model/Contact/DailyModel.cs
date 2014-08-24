using System;
using System.Collections.Generic;

using ProtoBuf;
using PropertyChanged;

using CallTracker.Helpers.Types;

namespace CallTracker.Model
{

    [ProtoContract]
    [ImplementPropertyChanged]
    public class DailyModel
    {
        [ProtoMember(1)]
        public bool IsDirty;
        [ProtoMember(2)]
        public DateTime Date { get; set; }
        [ProtoMember(3)]
        public FilterableBindingList<CustomerContact> Contacts { get; set; }
        [ProtoMember(4)]
        public EventsModel<DailyStats> Events { get; set; }

        public DailyModel()
        {
            Date = DateTime.Today;
            Contacts = new FilterableBindingList<CustomerContact>();
            Events = new EventsModel<DailyStats>();
            IsDirty = true;
        }

        public void ArchiveContacts()
        {
            
        }

        public void ComputeStatistics()
        {
            var callStats = new List<CallStats>();
            foreach (var contact in Contacts)
            {
                callStats.Add(contact.Statistics.ComputeStatistics());
            }
            Events.ComputeStatistics(callStats);
        }
    }

}
