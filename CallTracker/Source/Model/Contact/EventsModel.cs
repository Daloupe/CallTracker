using System;
using System.Collections.Generic;

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
        public bool IsDirty;
        [ProtoMember(2)]
        public List<EventModel<CallEventTypes>> CallEvents { get; set; }
        [ProtoMember(3)]
        public List<EventModel<AppEventTypes>> AppEvents { get; set; }
        [ProtoMember(4)]
        public T Statistics { get; set; }

        public EventsModel()
        {
            CallEvents = new List<EventModel<CallEventTypes>>();
            AppEvents = new List<EventModel<AppEventTypes>>();
            Statistics = default(T);
            IsDirty = true;
        }

        public T ComputeStatistics()
        {
            if (Statistics.IsDirty == false)
                return Statistics;
            // Cycle through events and add data to statistics.
            Statistics.IsDirty = false;
            return Statistics;
        }

        public T ComputeStatistics(List<CallStats> callStats)
        {
            if (Statistics.IsDirty == false)
                return Statistics;
            // Cycle through events and add data to statistics.
            // Add call stats in.
            Statistics.IsDirty = false;
            return Statistics;
        }

        public void AddCallEvent(EventModel<CallEventTypes> newEvent)
        {
            CallEvents.Add(newEvent);
            IsDirty = true;
        }

        public void AddAppEvent(EventModel<AppEventTypes> newEvent)
        {
            AppEvents.Add(newEvent);
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
        public DateTime Timestamp { get; set; }
        [ProtoMember(2)]
        public T EventType { get; set; }

        public EventModel(DateTime timeStamp, T eventType)
        {
            Timestamp = timeStamp;
            EventType = eventType;
        }
    }
    [ProtoContract]
    [ProtoInclude(10, typeof(CallStats))]
    [ProtoInclude(20, typeof(DailyStats))]
    public abstract class StatsModel
    {
        [ProtoMember(1)]
        public bool IsDirty;
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
    }

    public class CallStats : StatsModel
    {
        public CallStats()
            : base()
        {
        }
    }

    public class DailyStats : StatsModel
    {
        [ProtoMember(1)]
        public TimeSpan Login { get; set; }
        [ProtoMember(2)]
        public int Transfers { get; set; }

        public DailyStats() : base()
        {
            Login = TimeSpan.Zero;
            Transfers = 0;
        }
    }

    public enum CallEventTypes
    {
        LogIn,
        LogOut,
        Talking,
        Ready,
        NotReady,
        Wrapup,
        Reserved,
        Hold
    }

    public enum AppEventTypes
    {
        SmartCopy,
        SmartPaste,
        Gridlink,
        DataPaste
    }

}
