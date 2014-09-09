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

        //[ProtoBeforeDeserialization]
        //private void Initializer()
        //{
        //    Contacts = new FilterableBindingList<CustomerContact>();
        //}

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

            var stats = (DailyStats)Events.Statistics.Clone();

            foreach (var contact in Contacts)
            {
                stats.Add(contact.ComputeStatistics());
                Console.WriteLine(stats.HandlingTime);  
            }
            stats.Calls = Contacts.Count;

            var lastLogInIndex = Events.CallEvents.IndexOf(Events.CallEvents.LastOrDefault(x => x.EventType.Is(CallEventTypes.LogIn)));
            var lastLogOutIndex = Events.CallEvents.IndexOf(Events.CallEvents.LastOrDefault(x => x.EventType.Is(CallEventTypes.LogOut)));
            if (lastLogInIndex > lastLogOutIndex)
            {
                stats.Login = Events.Statistics.Login.Add(DateTime.Now.Subtract(Events.CallEvents[lastLogInIndex].Timestamp));
            }
            if (Events.LastCallEvent.EventType.Is(CallEventTypes.Ready))
            {
                stats.Ready = stats.Ready.Add(DateTime.Now.Subtract(Events.LastCallEvent.Timestamp));
            }

            //Events.Statistics.IsDirty = false;

            return stats;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Events //////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        internal void AddCallEvent(CallEventTypes newEvent)
        {
            if (Events.LastCallEvent != null)
            {
                var lastEventTime = DateTime.Now.Subtract(Events.LastCallEvent.Timestamp);
                switch (Events.LastCallEvent.EventType)
                {
                    case CallEventTypes.Ready:
                        Events.Statistics.Ready += lastEventTime;
                        break;
                }
            }

            if (newEvent.Is(CallEventTypes.LogOut))
            {
                var lastOrDefault = Events.CallEvents.LastOrDefault(x => x.EventType.Is(CallEventTypes.LogIn));
                if (lastOrDefault != null)
                    Events.Statistics.Login += DateTime.Now.Subtract(lastOrDefault.Timestamp);
            }

            Events.AddCallEvent(newEvent);
            
            EventLogger.LogNewEvent("Daily Data: " + Date.ShortDate + " > " +
                                 Enum.GetName(typeof (CallEventTypes), Events.LastCallEvent.EventType) + " at " +
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
