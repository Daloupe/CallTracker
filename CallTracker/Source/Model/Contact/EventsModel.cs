using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.RegularExpressions;
using ProtoBuf;
using PropertyChanged;

using CallTracker.Helpers.Types;
using WatiN.Core;

namespace CallTracker.Model
{
    [ProtoContract]
    public class EventsModel<T> where T : StatsModel
    {      
        [ProtoMember(1)]
        protected bool IsDirty;
        [ProtoMember(2)]
        protected List<EventModel<CallEventTypes>> CallEvents { get; set; }
        [ProtoMember(3)]
        protected List<EventModel<AppEventTypes>> AppEvents { get; set; }
        [ProtoMember(4)]
        internal T Statistics { get; set; }

        internal EventModel<CallEventTypes> LastCallEvent { get; set; }

        public EventsModel()
        {
            CallEvents = new List<EventModel<CallEventTypes>>();
            AppEvents = new List<EventModel<AppEventTypes>>();
            Statistics = default(T);
            AddCallEvent(CallEventTypes.RecordCreated);
            AddAppEvent(AppEventTypes.RecordCreated);
            IsDirty = true;
        }

        internal T ComputeStatistics()
        {
            if (Statistics.IsDirty == false)
                return Statistics;
            // Cycle through events and add data to statistics.
            Statistics.IsDirty = false;
            return Statistics;
        }

        internal T ComputeStatistics(List<CallStats> callStats)
        {
            if (Statistics.IsDirty == false)
                return Statistics;
            // Cycle through events and add data to statistics.
            // Add call stats in.
            Statistics.IsDirty = false;
            return Statistics;
        }

        internal void AddCallEvent(CallEventTypes newEvent)
        {
            CallEvents.Add(new EventModel<CallEventTypes>(newEvent));
            LastCallEvent = CallEvents.LastOrDefault();
            Console.WriteLine("Last event set to: " + Enum.GetName(typeof(CallEventTypes), LastCallEvent.EventType));
            IsDirty = true;
        }

        internal void AddAppEvent(AppEventTypes newEvent)
        {
            AppEvents.Add(new EventModel<AppEventTypes>(newEvent));

            //EventLogger.LogNewEvent(typeof(T).ToString() + " > " + Enum.GetName(typeof(AppEventTypes), newEvent));
            IsDirty = true;
        }

        public void Saved()
        {
            IsDirty = false;
        }
    }

    [ProtoContract]
    public class EventModel<T>
    {
        [ProtoMember(1)]
        internal DateTime Timestamp { get; set; }
        [ProtoMember(2)]
        internal T EventType { get; set; }

        public EventModel()
        { }

        public EventModel(T eventType)
        {
            Timestamp = DateTime.Now;
            EventType = eventType;
        }
    }
    [ProtoContract]
    [ProtoInclude(10, typeof(CallStats))]
    [ProtoInclude(20, typeof(DailyStats))]
    public abstract class StatsModel
    {
        [ProtoMember(1)]
        protected bool _isDirty;
        [ProtoMember(2)]
        public TimeSpan TalkTime;
        [ProtoMember(3)]
        public TimeSpan Wrapup;
        [ProtoMember(4)]
        public TimeSpan NotReady;
        [ProtoMember(5)]
        public TimeSpan HandlingTime;
        [ProtoMember(6)]
        public TimeSpan DNOut;

        protected StatsModel()
        {
            TalkTime = TimeSpan.Zero;
            Wrapup = TimeSpan.Zero;
            NotReady = TimeSpan.Zero;
            HandlingTime = TimeSpan.Zero;
            DNOut = TimeSpan.Zero;
            IsDirty = true;
        }

        public bool IsDirty { get { return IsDirty; } set { _isDirty = value; }}
    }

    [ProtoContract]
    public class CallStats : StatsModel
    {
        public CallStats()
        {
        }
    }

    [ProtoContract]
    public class DailyStats : StatsModel
    {
        [ProtoMember(1)]
        internal TimeSpan Login { get; set; }
        [ProtoMember(2)]
        internal int Transfers { get; set; }

        public DailyStats()
        {
            Login = TimeSpan.Zero;
            Transfers = 0;
        }
    }

    public enum CallEventTypes
    {
        None,
        RecordCreated,
        LogIn,
        LogOut,
        CallStart,
        CallEnd,
        Talking,
        Ready,
        NotReady,
        Wrapup,
        Reserved,
        Hold,
    }

    public enum AppEventTypes
    {
        None,
        RecordCreated,
        SmartCopy,
        SmartPaste,
        Gridlink,
        DataPaste
    }

}
