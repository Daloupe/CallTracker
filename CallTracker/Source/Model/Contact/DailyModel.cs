using System;
using System.Collections.Generic;
using CallTracker.View;
using ProtoBuf;
using PropertyChanged;

using CallTracker.Helpers.Types;

namespace CallTracker.Model
{

    [ProtoContract(SkipConstructor = true)]
    [ImplementPropertyChanged]
    public class DailyModel
    {
        [ProtoMember(1)]
        public bool IsDirty;
        [ProtoMember(2)]
        public DateFilterItem Date { get; set; }
        [ProtoMember(3)]
        public FilterableBindingList<CustomerContact> Contacts { get; set; }
        [ProtoMember(4)]
        public EventsModel<DailyStats> Events { get; set; }

        public DailyModel()
        {
            Date = new DateFilterItem(DateTime.Today);
            Contacts = new FilterableBindingList<CustomerContact>();
            Events = new EventsModel<DailyStats>();
            IsDirty = true;
        }

        [ProtoBeforeDeserialization]
        private void Initializer()
        {
            Contacts = new FilterableBindingList<CustomerContact>();
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
