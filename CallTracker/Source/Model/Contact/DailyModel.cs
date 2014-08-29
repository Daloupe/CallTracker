using System;
using System.Collections.Generic;
using ProtoBuf;
using PropertyChanged;

using CallTracker.Helpers;
using CallTracker.Helpers.Types;

namespace CallTracker.Model
{

    [ProtoContract]
    [ImplementPropertyChanged]
    public class DailyModel
    {
        [ProtoMember(1)]
        internal bool IsDirty;
        [ProtoMember(2)]
        internal DateFilterItem Date { get; set; }
        [ProtoMember(3)]
        internal FilterableBindingList<CustomerContact> Contacts { get; set; }
        [ProtoMember(4)]
        private EventsModel<DailyStats> Events { get; set; }

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

        internal void ArchiveContacts()
        {
            
        }

        internal void ComputeStatistics()
        {
            var callStats = new List<CallStats>();
            //foreach (var contact in Contacts)
            //{
            //    callStats.Add(contact.Events.ComputeStatistics());
            //}
            Events.ComputeStatistics(callStats);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Events //////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        internal void AddCallEvent(CallEventTypes newEvent)
        {
            Events.AddCallEvent(newEvent);
            
            EventLogger.LogNewEvent("Daily Data: " + Date.ShortDate + " > " +
                                 Enum.GetName(typeof (CallEventTypes), Events.LastCallEvent.EventType) + " at " +
                                 Events.LastCallEvent.Timestamp.ToString("dd/MM/yy hh:mm:ss"), EventLogLevel.Status);
        }

        internal void AddAppEvent(AppEventTypes newEvent)
        {
            Events.AddAppEvent(newEvent);
        }
    }

}
