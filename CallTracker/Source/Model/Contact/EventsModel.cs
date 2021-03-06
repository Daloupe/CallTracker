﻿using System;
using System.Collections.Generic;
using System.Linq;
using CallTracker.Helpers;
using ProtoBuf;

namespace CallTracker.Model
{
    [ProtoContract(SkipConstructor = true)]
    public class EventsModel<T> where T : StatsModel, new()
    {      
        [ProtoMember(1)]
        protected bool IsDirty;
        [ProtoMember(2)]
        internal List<EventModel<CallEventTypes>> CallEvents { get; set; }
        [ProtoMember(3)]
        internal List<EventModel<AppEventTypes>> AppEvents { get; set; }
        [ProtoMember(4)]
        internal T Statistics { get; set; }

        internal EventModel<CallEventTypes> LastCallEvent { get; set; }

        private bool _deserializing;

        public EventsModel()
        {
            CallEvents = new List<EventModel<CallEventTypes>>();
            AppEvents = new List<EventModel<AppEventTypes>>();
            Statistics = new T();
            //if (!_deserializing)
            //{
                AddCallEvent(CallEventTypes.RecordCreated);
                AddAppEvent(AppEventTypes.RecordCreated);
            //}
            IsDirty = true;
        }

        [ProtoBeforeDeserialization]
        private void PreDes()
        {
            CallEvents = new List<EventModel<CallEventTypes>>();
            AppEvents = new List<EventModel<AppEventTypes>>();
            Statistics = new T();
            //_deserializing = true;
        }

        [ProtoAfterDeserialization]
        private void PostDes()
        {
            //_deserializing = false;
            LastCallEvent = CallEvents.Last();
        }

        internal T ComputeStatistics()
        {
            //if (Statistics.IsDirty == false)
            //    return Statistics;

            var stats = (T)Statistics.Clone();

            if (LastCallEvent != null)
            {
                var lastEventTime = DateTime.Now.Subtract(LastCallEvent.Timestamp);
                switch (LastCallEvent.EventType)
                {
                    case CallEventTypes.Hold:
                        stats.Hold += lastEventTime;
                        stats.HandlingTime += lastEventTime;
                        break;
                    case CallEventTypes.NotReady:
                        stats.NotReady += lastEventTime;
                        stats.HandlingTime += lastEventTime;
                        break;
                    case CallEventTypes.CallStart:
                    case CallEventTypes.Talking:
                        stats.TalkTime += lastEventTime;
                        stats.HandlingTime += lastEventTime;
                        break;
                    case CallEventTypes.Wrapup:
                        stats.Wrapup += lastEventTime;
                        stats.HandlingTime += lastEventTime;
                        break;
                }

                //if (LastCallEvent.EventType.IsNot(CallEventTypes.CallEnd))
                //{
                //    var lastOrDefault = CallEvents.LastOrDefault(x => x.EventType.Is(CallEventTypes.CallStart));
                //    if (lastOrDefault != null)
                //        stats.HandlingTime += DateTime.Now.Subtract(lastOrDefault.Timestamp);
                //}

            }

            return stats;

            //Statistics.IsDirty = false;
        }

        internal void AddCallEvent(CallEventTypes newEvent)
        {
            //if (_deserializing) return;
            if (LastCallEvent != null)
            {
                var lastEventTime = DateTime.Now.Subtract(LastCallEvent.Timestamp);
                switch (LastCallEvent.EventType)
                {
                    case CallEventTypes.Hold:
                        Statistics.Hold += lastEventTime;
                        Statistics.HandlingTime += lastEventTime;
                        break;
                    case CallEventTypes.NotReady:
                        Statistics.NotReady += lastEventTime;
                        Statistics.HandlingTime += lastEventTime;
                        break;
                    case CallEventTypes.CallStart:
                    case CallEventTypes.Talking:
                        Statistics.TalkTime += lastEventTime;
                        Statistics.HandlingTime += lastEventTime;
                        break;
                    case CallEventTypes.Wrapup:
                        Statistics.Wrapup += lastEventTime;
                        Statistics.HandlingTime += lastEventTime;
                        break;
                }
            }

            LastCallEvent = new EventModel<CallEventTypes>(newEvent);
            CallEvents.Add(LastCallEvent);
            
            IsDirty = true;
        }
        public void ImportCallEvent(EventModel<CallEventTypes> callEvent)
        {
            //if (_deserializing) return;
            if (LastCallEvent != null)
            {
                var lastEventTime = callEvent.Timestamp.Subtract(LastCallEvent.Timestamp);
                switch (LastCallEvent.EventType)
                {
                    case CallEventTypes.Hold:
                        Statistics.Hold += lastEventTime;
                        Statistics.HandlingTime += lastEventTime;
                        break;
                    case CallEventTypes.NotReady:
                        Statistics.NotReady += lastEventTime;
                        Statistics.HandlingTime += lastEventTime;
                        break;
                    case CallEventTypes.CallStart:
                    case CallEventTypes.Talking:
                        Statistics.TalkTime += lastEventTime;
                        Statistics.HandlingTime += lastEventTime;
                        break;
                    case CallEventTypes.Wrapup:
                        Statistics.Wrapup += lastEventTime;
                        Statistics.HandlingTime += lastEventTime;
                        break;
                }
            }

            LastCallEvent = callEvent;
            CallEvents.Add(callEvent);

            IsDirty = true;
        }

        public void AddCallEventAtTime(CallEventTypes newEvent, DateTime time)
        {
            //if (_deserializing) return;
            if (LastCallEvent != null)
            {
                var lastEventTime = time.Subtract(LastCallEvent.Timestamp);
                switch (LastCallEvent.EventType)
                {
                    case CallEventTypes.Hold:
                        Statistics.Hold += lastEventTime;
                        Statistics.HandlingTime += lastEventTime;
                        break;
                    case CallEventTypes.NotReady:
                        Statistics.NotReady += lastEventTime;
                        Statistics.HandlingTime += lastEventTime;
                        break;
                    case CallEventTypes.CallStart:
                    case CallEventTypes.Talking:
                        Statistics.TalkTime += lastEventTime;
                        Statistics.HandlingTime += lastEventTime;
                        break;
                    case CallEventTypes.Wrapup:
                        Statistics.Wrapup += lastEventTime;
                        Statistics.HandlingTime += lastEventTime;
                        break;
                }
            }

            LastCallEvent = new EventModel<CallEventTypes>(newEvent, time);
            CallEvents.Add(LastCallEvent);

            IsDirty = true;
        }

        internal void AddAppEvent(AppEventTypes newEvent)
        {
            //if (_deserializing) return;
            switch (newEvent)
            {
                case AppEventTypes.AutoLogin:
                    Statistics.AutoLogins += 1;
                    break;
                case AppEventTypes.Gridlink:
                    Statistics.GridLinks += 1;
                    break;
                case AppEventTypes.AutoFill:
                    Statistics.AutoFills += 1;
                    break;
                case AppEventTypes.AutoSearch:
                    Statistics.AutoSearches += 1;
                    break;
                case AppEventTypes.DataPaste:
                    Statistics.DataPastes += 1;
                    break;
                case AppEventTypes.GridlinkSearch:
                    Statistics.GridLinkSearches += 1;
                    break;
                case AppEventTypes.SmartCopy:
                    Statistics.SmartCopies += 1;
                    break;
                case AppEventTypes.SmartPaste:
                    Statistics.SmartPastes += 1;
                    break;
                case AppEventTypes.BindSmartPaste:
                    Statistics.SmartPasteBinds += 1;
                    break;
                case AppEventTypes.DataDrop:
                    Statistics.DataDrops += 1;
                    break;
            }
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
    public class EventModel<T> : ICloneable
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

        public EventModel(T eventType, DateTime time)
        {
            Timestamp = time;
            EventType = eventType;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public EventModel<T> Copy()
        {
            return (EventModel<T>)Clone();
        }
    }
    [ProtoContract]
    [ProtoInclude(20, typeof(CallStats))]
    [ProtoInclude(30, typeof(DailyStats))]
    public abstract class StatsModel : ICloneable
    {
        [ProtoMember(1)]
        protected bool _isDirty { get; set; }
        [ProtoMember(2)]
        public TimeSpan TalkTime { get; set; }
        [ProtoMember(3)]
        public TimeSpan Wrapup { get; set; }
        [ProtoMember(4)]
        public TimeSpan NotReady { get; set; }
        [ProtoMember(5)]
        public TimeSpan HandlingTime { get; set; }
        [ProtoMember(6)]
        public TimeSpan DNOut { get; set; }
        [ProtoMember(7)]
        public TimeSpan Hold { get; set; }

        [ProtoMember(10)]
        public int AutoLogins { get; set; }
        [ProtoMember(11)]
        public int AutoSearches { get; set; }
        [ProtoMember(12)]
        public int SmartCopies { get; set; }
        [ProtoMember(13)]
        public int SmartPastes { get; set; }
        [ProtoMember(14)]
        public int AutoFills { get; set; }
        [ProtoMember(15)]
        public int DataPastes { get; set; }
        [ProtoMember(16)]
        public int GridLinks { get; set; }
        [ProtoMember(17)]
        public int GridLinkSearches { get; set; }
        [ProtoMember(18)]
        public int SmartPasteBinds { get; set; }
        [ProtoMember(19)]
        public int DataDrops { get; set; }

        protected StatsModel()
        {
            TalkTime = TimeSpan.Zero;
            Wrapup = TimeSpan.Zero;
            NotReady = TimeSpan.Zero;
            HandlingTime = TimeSpan.Zero;
            DNOut = TimeSpan.Zero;
            Hold = TimeSpan.Zero;
            IsDirty = true;
            AutoLogins = 0;
            GridLinks = 0;
            SmartCopies = 0;
            SmartPastes = 0;
            AutoFills = 0;
            DataPastes = 0;
            AutoSearches = 0;
            GridLinkSearches = 0;
            SmartPasteBinds = 0;
            DataDrops = 0;
        }

        public void Add(StatsModel statsModel)
        {
            TalkTime += statsModel.TalkTime;
            Hold += statsModel.Hold;
            NotReady += statsModel.NotReady;
            Wrapup += statsModel.Wrapup;
            HandlingTime += statsModel.HandlingTime;
            AutoFills += statsModel.AutoFills;
            AutoLogins += statsModel.AutoLogins;
            AutoSearches += statsModel.AutoSearches;
            DataPastes += statsModel.DataPastes;
            GridLinkSearches += statsModel.GridLinkSearches;
            GridLinks += statsModel.GridLinks;
            SmartCopies += statsModel.SmartCopies;
            SmartPastes += statsModel.SmartPastes;
            DataDrops += statsModel.DataDrops;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public bool IsDirty { get { return _isDirty; } set { _isDirty = value; }}
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
        [ProtoMember(3)]
        internal int Calls { get; set; }
        [ProtoMember(4)]
        internal TimeSpan Ready { get; set; }

        public DailyStats()
        {
            Login = TimeSpan.Zero;
            Transfers = 0;
            Calls = 0;
            Ready = TimeSpan.Zero;
        }
    }

    [Flags]
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
        BindSmartPaste,
        Gridlink,
        GridlinkSearch,
        AutoLogin,
        AutoFill,
        AutoSearch,
        SystemSearch,
        DataPaste,
        DataDrop
    }

}
