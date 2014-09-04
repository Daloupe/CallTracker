using System;
using System.Collections.Generic;
using System.Linq;
using CallTracker.Helpers;
using ProtoBuf;

namespace CallTracker.Model
{
    [ProtoContract]
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

        public EventsModel()
        {
            CallEvents = new List<EventModel<CallEventTypes>>();
            AppEvents = new List<EventModel<AppEventTypes>>();
            Statistics = new T();
            AddCallEvent(CallEventTypes.RecordCreated);
            AddAppEvent(AppEventTypes.RecordCreated);
            IsDirty = true;
        }

        internal T ComputeStatistics()
        {
            //if (Statistics.IsDirty == false)
            //    return Statistics;

            var stats = Statistics;

            var lastLogInIndex = CallEvents.IndexOf(CallEvents.LastOrDefault(x => x.EventType.Is(CallEventTypes.CallStart)));
            var lastLogOutIndex = CallEvents.IndexOf(CallEvents.LastOrDefault(x => x.EventType.Is(CallEventTypes.CallEnd)));
            if (lastLogInIndex > lastLogOutIndex)
            {
                stats = (T)Statistics.Clone();
                stats.HandlingTime = Statistics.HandlingTime.Add(DateTime.Now.Subtract(CallEvents[lastLogInIndex].Timestamp));
            }

            return stats;

            //Statistics.IsDirty = false;
        }

        //internal T ComputeStatistics(List<CallStats> callStats)
        //{
        //    //if (Statistics.IsDirty == false)
        //    //    return Statistics;
        //    Statistics.TalkTime = TimeSpan.Zero;
        //    Statistics.Hold = TimeSpan.Zero;
        //    Statistics.NotReady = TimeSpan.Zero;
        //    Statistics.Wrapup = TimeSpan.Zero;
        //    Statistics.HandlingTime = TimeSpan.Zero;
        //    Statistics.AutoFills = 0;
        //    Statistics.AutoLogins = 0;
        //    Statistics.AutoSearches = 0;
        //    Statistics.DataPastes = 0;
        //    Statistics.GridLinkSearches = 0;
        //    Statistics.GridLinks = 0;
        //    Statistics.SmartCopies = 0;
        //    Statistics.SmartPastes = 0;
        //    foreach (var call in callStats)
        //    {
        //        Statistics.TalkTime = Statistics.TalkTime.Add(call.TalkTime);
        //        Statistics.Hold = Statistics.Hold.Add(call.Hold);
        //        Statistics.NotReady = Statistics.NotReady.Add(call.NotReady);
        //        Statistics.Wrapup = Statistics.Wrapup.Add(call.Wrapup);
        //        Statistics.HandlingTime = Statistics.Hold.Add(call.HandlingTime);
        //        Statistics.AutoFills += call.AutoFills;
        //        Statistics.AutoLogins += call.AutoLogins;
        //        Statistics.AutoSearches += call.AutoSearches;
        //        Statistics.DataPastes += call.DataPastes;
        //        Statistics.GridLinkSearches += call.GridLinkSearches;
        //        Statistics.GridLinks += call.GridLinks;
        //        Statistics.SmartCopies += call.SmartCopies;
        //        Statistics.SmartPastes += call.SmartPastes;
        //    }

        //    //Statistics.IsDirty = false;
        //    return Statistics;
        //}

        internal void AddCallEvent(CallEventTypes newEvent)
        {
            if (LastCallEvent != null)
            {
                var lastEventTime = DateTime.Now.Subtract(LastCallEvent.Timestamp);
                switch (LastCallEvent.EventType)
                {
                    case CallEventTypes.Hold:
                        Statistics.Hold = Statistics.Hold.Add(lastEventTime);
                        break;
                    case CallEventTypes.NotReady:
                        Statistics.NotReady = Statistics.NotReady.Add(lastEventTime);
                        break;
                    case CallEventTypes.CallStart:
                    case CallEventTypes.Talking:
                        Statistics.TalkTime = Statistics.TalkTime.Add(lastEventTime);
                        break;
                    case CallEventTypes.Wrapup:
                        Statistics.Wrapup = Statistics.Wrapup.Add(lastEventTime);
                        break;
                }
            }

            if (newEvent.Is(CallEventTypes.CallEnd))
            {
                var lastOrDefault = CallEvents.LastOrDefault(x => x.EventType.Is(CallEventTypes.CallStart));
                if (lastOrDefault != null)
                    Statistics.HandlingTime = Statistics.HandlingTime.Add(DateTime.Now.Subtract(lastOrDefault.Timestamp));
            }

            CallEvents.Add(new EventModel<CallEventTypes>(newEvent));
            LastCallEvent = CallEvents.LastOrDefault();
            IsDirty = true;
        }

        internal void AddAppEvent(AppEventTypes newEvent)
        {
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
        }

        public void Add(StatsModel statsModel)
        {
            TalkTime = TalkTime.Add(statsModel.TalkTime);
            Hold = Hold.Add(statsModel.Hold);
            NotReady = NotReady.Add(statsModel.NotReady);
            Wrapup = Wrapup.Add(statsModel.Wrapup);
            HandlingTime = Hold.Add(statsModel.HandlingTime);
            AutoFills += statsModel.AutoFills;
            AutoLogins += statsModel.AutoLogins;
            AutoSearches += statsModel.AutoSearches;
            DataPastes += statsModel.DataPastes;
            GridLinkSearches += statsModel.GridLinkSearches;
            GridLinks += statsModel.GridLinks;
            SmartCopies += statsModel.SmartCopies;
            SmartPastes += statsModel.SmartPastes;
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
        DataPaste
    }

}
