using System;
using System.Linq;
using ProtoBuf;
using PropertyChanged;

using CallTracker.Helpers;
using CallTracker.Helpers.Types;

namespace CallTracker.Model
{

    [ProtoContract(SkipConstructor = true)]
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
        public EventsModel<DailyStats> Events { get; set; }
        [ProtoMember(5)]
        internal bool IsArchived;

        public CallStats CallTotals;

        public DailyModel()
        {
            Date = new DateFilterItem(DateTime.Today);
            Contacts = new FilterableBindingList<CustomerContact>();
            Events = new EventsModel<DailyStats>();
            IsDirty = true;
        }

        //[ProtoAfterDeserialization]
        //private void AfterDeserialization()
        //{
        //    ContactsBindingSource.DataSource = Contacts;
        //    ContactsBindingSource.Position = Position;
        //}

        [ProtoBeforeDeserialization]
        private void PreDes()
        {
            // Edit contacts won't bind properly if not initialized when no contacts have been stored.
            Contacts = new FilterableBindingList<CustomerContact>();
            Events = new EventsModel<DailyStats>();
        }

        internal void ArchiveContacts()
        {
            var archivedContacts = new FilterableBindingList<CustomerContact>();
            foreach (var contact in Contacts)
            {
                archivedContacts.Add(new CustomerContact(contact.GetEvents(), contact.Note, contact.Fault.Symptom,
                    contact.Fault.Action, contact.Fault.Outcome, contact.Fault.AffectedServices));
            }
            Contacts = archivedContacts;
            IsDirty = true;
            IsArchived = true;
        }

        internal DailyStats ComputeStatistics()
        {
            //if (Events.Statistics.IsDirty == false)
            //    return Events.Statistics;

            //var callStats = new List<CallStats>();

            //foreach (var contact in Contacts)
            //{
            //    var callStat = contact.ComputeStatistics();
            //    callStats.Add(callStat);
            //    //Events.Statistics.Calls += 1;
            //}

            //Events.ComputeStatistics(callStats);
            //Events.Statistics.Calls = Contacts.Count;
            CallTotals = new CallStats();

            foreach (var contact in Contacts)
            {
                CallTotals.Add(contact.ComputeStatistics()); 
            }

            var stats = (DailyStats)Events.Statistics.Clone();
            stats.Calls = Contacts.Count;

            var lastEventTime = DateTime.Now.Subtract(Events.LastCallEvent.Timestamp);
            switch (Events.LastCallEvent.EventType)
            {
                case CallEventTypes.Ready:
                    stats.Ready += lastEventTime;
                    stats.Login += lastEventTime;
                    break;
                case CallEventTypes.NotReady:
                    stats.NotReady += lastEventTime;
                    stats.Login += lastEventTime;
                    break;
                case CallEventTypes.CallStart:
                    stats.Login += lastEventTime;
                    break;
                case CallEventTypes.LogIn:
                    stats.Login += lastEventTime;
                    break;
            }

            //Events.Statistics.IsDirty = false;

            return stats;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Events //////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        internal void AddCallEvent(CallEventTypes newEvent)
        {
            var lastEventTime = DateTime.Now.Subtract(Events.LastCallEvent.Timestamp);
            switch (Events.LastCallEvent.EventType)
            {
                case CallEventTypes.Ready:
                    Events.Statistics.Ready += lastEventTime;
                    Events.Statistics.Login += lastEventTime;
                    break;
                case CallEventTypes.NotReady:
                    Events.Statistics.Login += lastEventTime;
                    break;
                case CallEventTypes.CallStart:
                    Events.Statistics.Login += lastEventTime;
                    break;
                case CallEventTypes.LogIn:
                    Events.Statistics.Login += lastEventTime;
                    break;
            }

            //if (newEvent.Is(CallEventTypes.LogOut) && Events.LastCallEvent.EventType.IsNot(CallEventTypes.LogOut))
            //{
            //    var lastOrDefault = Events.CallEvents.LastOrDefault(x => x.EventType.Is(CallEventTypes.LogIn));
            //    if (lastOrDefault != null)
            //        Events.Statistics.Login += DateTime.Now.Subtract(lastOrDefault.Timestamp);
            //}

            Events.AddCallEvent(newEvent);
            
            EventLogger.LogNewEvent("Daily Data: " + Date.ShortDate + " > " +
                                 Enum.GetName(typeof (CallEventTypes), Events.LastCallEvent.EventType) + " at " +
                                 Events.LastCallEvent.Timestamp.ToString("dd/MM/yy hh:mm:ss"));

            IsDirty = true;
        }

        internal void ImportCallEvent(EventModel<CallEventTypes> callEvent)
        {

            var lastEventTime = callEvent.Timestamp.Subtract(Events.LastCallEvent.Timestamp);
            switch (Events.LastCallEvent.EventType)
            {
                case CallEventTypes.Ready:
                    Events.Statistics.Ready += lastEventTime;
                    Events.Statistics.Login += lastEventTime;
                    break;
                case CallEventTypes.NotReady:
                    Events.Statistics.Login += lastEventTime;
                    break;
                case CallEventTypes.CallStart:
                    Events.Statistics.Login += lastEventTime;
                    break;
                case CallEventTypes.LogIn:
                    Events.Statistics.Login += lastEventTime;
                    break;
            }

            //if (callEvent.EventType.Is(CallEventTypes.LogOut))
            //{
            //    var lastOrDefault = Events.CallEvents.LastOrDefault(x => x.EventType.Is(CallEventTypes.LogIn));
            //    if (lastOrDefault != null)
            //        Events.Statistics.Login += callEvent.Timestamp.Subtract(lastOrDefault.Timestamp);
            //}

            Events.ImportCallEvent(callEvent);

            EventLogger.LogNewEvent("Daily Data: " + Date.ShortDate + " > Importing Event > " +
                                 Enum.GetName(typeof(CallEventTypes), Events.LastCallEvent.EventType) + " at " +
                                 Events.LastCallEvent.Timestamp.ToString("dd/MM/yy hh:mm:ss"));

            IsDirty = true;
        }

        internal void AddAppEvent(AppEventTypes newEvent)
        {
            Events.AddAppEvent(newEvent);
            IsDirty = true;
        }
    }

}
