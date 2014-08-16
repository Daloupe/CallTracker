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
        public static bool ClearMessage;

        static EventLogger()
        {
            EventLog = new List<EventLogModel>();
            ClearMessage = true;
        }

        public static void LogNewEvent(string _event, EventLogLevel _logLevel = EventLogLevel.Verbose)
        {
            EventLog.Add(new EventLogModel(_event, _logLevel));
            File.AppendAllText("Log.txt", String.Format("\r\n{0}: {1}", DateTime.Now.ToString("dd/MM/yy hh:mm:ss"), _event));
            if (_logLevel.CompareTo(StatusLabel.Tag) >= 0)
                StatusLabel.Text = _event;
            else if(_logLevel == EventLogLevel.ClearStatus && ClearMessage == true)
                StatusLabel.Text = String.Empty;
        }

        public static void ClearStatusBar()
        {
            StatusLabel.Text = String.Empty;
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
        ClearStatus = 0,
        Verbose = 1 << 1,
        Brief = 1 << 2,
        Status = 1 << 3
    }
}
