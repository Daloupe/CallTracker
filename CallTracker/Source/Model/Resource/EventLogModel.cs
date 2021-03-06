﻿using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ProtoBuf;
using PropertyChanged;

namespace CallTracker.Model
{
    //[ImplementPropertyChanged]
    public static class EventLogger
    {
        private static List<EventLogModel> EventLog { get; set; }
        private static ToolStripStatusLabel StatusLabel { get; set; }
        public static bool ClearMessage = true;

        //static EventLogger()
        //{
        //    EventLog = new List<EventLogModel>();
        //    ClearMessage = true;
        //}

        public static void Init(ToolStripStatusLabel statusLabel)
        {
            StatusLabel = statusLabel;
            EventLog = new List<EventLogModel>();
            ClearMessage = true;
        }

        public static void LogNewEvent(string eventString, EventLogLevel logLevel = EventLogLevel.Verbose)
        {
            EventLog.Add(new EventLogModel(eventString, logLevel));
            if (logLevel.CompareTo(StatusLabel.Tag) >= 0)
                StatusLabel.Text = eventString;
            else if(logLevel == EventLogLevel.ClearStatus && ClearMessage)
                StatusLabel.Text = String.Empty;

            //Console.WriteLine(eventString);
        }

        public static void LogAndSaveNewEvent(string eventString, EventLogLevel logLevel = EventLogLevel.Verbose)
        {
            LogNewEvent(eventString, logLevel);
            SaveLog();
        }

        public static void SaveLog()
        {
            var sb = new StringBuilder();
            foreach (var entry in EventLog)
            {
                sb.AppendLine(entry.GetLogEntry());
            }
            File.AppendAllText("Log.txt", sb.ToString());
            EventLog.Clear();
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
        public DateTime TimeStamp { get; set; }
        [ProtoMember(2)]
        public string Event{ get; set; }
        [ProtoMember(3)]
        public EventLogLevel LogLevel { get; set; }

        public EventLogModel(string _event, EventLogLevel logLevel)
        {
            TimeStamp = DateTime.Now;
            Event = _event;
            LogLevel = logLevel;
        }

        public string GetLogEntry()
        {
            return String.Format("{0}: {1}", TimeStamp.ToString("dd/MM/yy hh:mm:ss"), Event);
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
