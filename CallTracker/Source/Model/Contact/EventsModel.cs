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
    internal class EventsModel<T> where T : StatsModel
    {      
        [ProtoMember(1)]
        protected bool IsDirty;
        [ProtoMember(2)]
        protected List<EventModel<CallEventTypes>> CallEvents { get; set; }
        [ProtoMember(3)]
        protected List<EventModel<AppEventTypes>> AppEvents { get; set; }
        [ProtoMember(4)]
        internal T Statistics { get; set; }

        internal CallEventTypes LastCallEvent { get; set; }

        internal EventsModel()
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
            LastCallEvent = newEvent;
            IsDirty = true;
        }

        internal void AddAppEvent(AppEventTypes newEvent)
        {
            AppEvents.Add(new EventModel<AppEventTypes>(newEvent));

            EventLogger.LogNewEvent(typeof(T).ToString() + " > " + Enum.GetName(typeof(AppEventTypes), newEvent));
            IsDirty = true;
        }

        public void Saved()
        {
            IsDirty = false;
        }
    }

    [ProtoContract]
    internal class EventModel<T>
    {
        [ProtoMember(1)]
        internal DateTime Timestamp { get; set; }
        [ProtoMember(2)]
        internal T EventType { get; set; }

        internal EventModel(T eventType)
        {
            Timestamp = DateTime.Now;
            EventType = eventType;
        }
    }
    [ProtoContract]
    [ProtoInclude(10, typeof(CallStats))]
    [ProtoInclude(20, typeof(DailyStats))]
    internal abstract class StatsModel
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
    internal class CallStats : StatsModel
    {
        internal CallStats()
        {
        }
    }

    [ProtoContract]
    internal class DailyStats : StatsModel
    {
        [ProtoMember(1)]
        internal TimeSpan Login { get; set; }
        [ProtoMember(2)]
        internal int Transfers { get; set; }

        internal DailyStats()
        {
            Login = TimeSpan.Zero;
            Transfers = 0;
        }
    }

    [Flags]
    internal enum CallEventTypes
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

    [Flags]
    internal enum AppEventTypes
    {
        None,
        RecordCreated,
        SmartCopy,
        SmartPaste,
        Gridlink,
        DataPaste
    }

}
