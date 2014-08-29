using System;
using System.Collections.Generic;
using ProtoBuf;
using PropertyChanged;

using CallTracker.Helpers;
using CallTracker.Helpers.Types;

namespace CallTracker.Model
{

    [ProtoContract(SkipConstructor = true)]
    [ImplementPropertyChanged]
    internal class DailyModel
    {
        [ProtoMember(1)]
        internal bool IsDirty;
        [ProtoMember(2)]
        internal DateFilterItem Date { get; set; }
        [ProtoMember(3)]
        internal FilterableBindingList<CustomerContact> Contacts { get; set; }
        [ProtoMember(4)]
        internal EventsModel<DailyStats> Events { get; set; }

        internal DailyModel()
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

        internal void ArchiveContacts()
        {
            
        }

        internal void ComputeStatistics()
        {
            var callStats = new List<CallStats>();
            foreach (var contact in Contacts)
            {
                callStats.Add(contact.Events.ComputeStatistics());
            }
            Events.ComputeStatistics(callStats);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Events //////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        internal void AddCallEvent(CallEventTypes newEvent)
        {
            Events.AddCallEvent(newEvent);
            EventLogger.LogNewEvent(Date.ShortDate + " > " + Enum.GetName(typeof(CallEventTypes), Events.LastCallEvent));
        }

        internal void AddAppEvent(AppEventTypes newEvent)
        {
            Events.AddAppEvent(newEvent);
        }
    }

}
