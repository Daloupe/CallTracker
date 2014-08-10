using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

using System.Diagnostics;

using ProtoBuf;
using PropertyChanged;

using CallTracker.Model;
using CallTracker.Helpers;
using CallTracker.Data;

using System.Windows.Automation;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Recording;
using TestStack.White.UIItemEvents;
using TestStack.White.UIItems.Actions;

namespace CallTracker.Helpers
{
    class MADElementOffset
    {
        public string Name {get; set;}
        public Vector Offset { get; set; }
        public int X {get; set;}
        public int Y {get; set;}

        public MADElementOffset(string _name, int _x, int _y)
        {
            Name = _name;
            X = _x;
            Y = _y;
            Offset = new Vector(X, Y);
        }
    }

    public static class MadSmartPaste
    {
        private static Process MADProcess;
        private static TestStack.White.Application MADApplication;
        private static Window MADWindow;
        private static TestStack.White.UIItems.TextBox MADActiveElement;

        private static List<MADElementOffset> ElementOffsets = new List<MADElementOffset>
        {
            new MADElementOffset("DN", 11, 212),
            new MADElementOffset("ICON", 343, 212),
            new MADElementOffset("CMBS", 343, 161),
            new MADElementOffset("Username", 343, 108),
            new MADElementOffset("NameSplit.First", 11, 53),
            new MADElementOffset("NameSplit.Last", 126, 53),
            new MADElementOffset("Address.UnitNumber", 11, 108),
            new MADElementOffset("Address.StreetNumber", 70, 108),
            new MADElementOffset("Address.StreetName", 124, 108),
            new MADElementOffset("Address.Suburb", 11, 161),
            new MADElementOffset("Address.Postcode", 171, 162),
        };

        public static string GetActiveElement()
        {
            if (MADProcess == null)
                if (InitMADMonitor() == false)
                    return String.Empty;
            
            MADActiveElement = MADWindow.Get<TestStack.White.UIItems.TextBox>(SearchCriteria.ByAutomationId("1"));
            
            return ElementOffsets.First(x => x.Offset == MADWindow.Bounds.Location - MADActiveElement.Bounds.Location).Name;
        }

        public static void SetElementValue(string _value)
        {
            MADActiveElement.SetValue(_value);
        }

        public static void SetElementText(string _value)
        {
            MADActiveElement.Text = _value;
        }

        private static bool InitMADMonitor()
        {
            foreach (Process pList in Process.GetProcesses())
                if (pList.MainWindowTitle.Contains("Oracle Forms Runtime"))
                    MADProcess = pList;

            if (MADProcess == null)
            {
                EventLogger.LogNewEvent("Unable to Find MAD", EventLogLevel.Status);
                return false;
            }

            MADProcess.Exited += MADProcess_Exited;
            MADApplication = TestStack.White.Application.Attach(MADProcess);
            MADWindow = MADApplication.GetWindow(SearchCriteria.ByAutomationId("60016"), InitializeOption.NoCache);
            return true;
        }

        static void MADProcess_Exited(object sender, EventArgs e)
        {
            MADProcess.Exited -= MADProcess_Exited;
            MADProcess.Dispose();
            MADProcess = null;
        }

    }
}

//Telephony 11,212

//Cass 343,212

//CMBS 343,161

//Login 343, 108

//FirstName 11, 53

//Surname 126, 53

//Unit 11, 108

//No 70, 108

//Street 124, 108

//Suburb 11,161

//Postcode 171,162