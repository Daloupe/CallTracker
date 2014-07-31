using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Utilities.RegularExpressions;
using ProtoBuf;
using PropertyChanged;

using CallTracker.Helpers;
using CallTracker.View;

namespace CallTracker.Model
{
    [ImplementPropertyChanged]
    public static class EventLogger
    {
        public static List<EventLogModel> EventLog { get; set; }
        public static ToolStripStatusLabel StatusLabel { get; set; }

        static EventLogger()
        {
            EventLog = new List<EventLogModel>();
        }

        public static void LogNewEvent(string _event, EventLogLevel _logLevel = EventLogLevel.Verbose)
        {
            EventLog.Add(new EventLogModel(_event, _logLevel));
            File.AppendAllText("Log.txt", String.Format("\r\n{0}: {1}", DateTime.Now.ToString("dd/MM/yy hh:mm:ss"), _event));
            if (_logLevel == EventLogLevel.Status)
                StatusLabel.Text = _event;
        }
    }

    [ImplementPropertyChanged]
    [ProtoContract]
    public class EventLogModel
    {
        [ProtoMember(1)]
        public string DateStamp { get; set; }
        [ProtoMember(2)]
        public string TimeStamp { get; set; }
        [ProtoMember(3)]
        public string Event{ get; set; }
        [ProtoMember(4)]
        public EventLogLevel LogLevel { get; set; }

        public EventLogModel(string _event, EventLogLevel _logLevel)
        {
            DateStamp = DateTime.Now.ToLongDateString();
            TimeStamp = DateTime.Now.ToLongTimeString();
            Event = _event;
            LogLevel = _logLevel;
        }

    }    
    public enum EventLogLevel
    {
        Brief,
        Verbose,
        Status
    }
}
