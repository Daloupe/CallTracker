using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using CallTracker.Model;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;

using Window = TestStack.White.UIItems.WindowItems.Window;

namespace CallTracker.Helpers
{
    public class MADElementOffset
    {
        public string Name {get; set;}
        public Vector Offset { get; set; }
        public int X {get; set;}
        public int Y {get; set;}

        public MADElementOffset(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
            Offset = new Vector(X, Y);
        }
    }

    public static class MadSmartPaste
    {
        //private static Process MADProcess = null;
        //private static TestStack.White.Application MADApplication;
        private static Window _madWindow;
        private const string WindowTitle = "Oracle";
        private static TestStack.White.UIItems.UIItemContainer _madSearchWindow;
        private const string ControlText = "Search";
        private static TestStack.White.UIItems.IUIItem _madEdit;

        private static readonly List<MADElementOffset> ElementOffsets = new List<MADElementOffset>
        {
            new MADElementOffset("DN|0$2$3$4", 11, 212),
            new MADElementOffset("ICON", 343, 212),
            new MADElementOffset("CMBS|$2", 343, 161),
            new MADElementOffset("Username", 343, 108),
            new MADElementOffset("NameSplit.First", 11, 53),
            new MADElementOffset("NameSplit.Last", 126, 53),
            new MADElementOffset("Address.UnitNumber", 11, 108),
            new MADElementOffset("Address.StreetNumber", 70, 108),
            new MADElementOffset("Address.StreetName", 124, 108),
            new MADElementOffset("Address.Suburb", 11, 161),
            new MADElementOffset("Address.Postcode", 171, 162),
        };

        public static void Dispose()
        {
            _madEdit = null;
            _madSearchWindow = null;
            _madWindow = null;
        }

        private static bool GetMADWindow()
        {
            _madWindow = TestStack.White.Desktop.Instance.Windows().Find(obj => obj.Title.Contains(WindowTitle));
            if (_madWindow == null)
            {
                EventLogger.LogAndSaveNewEvent("MAD Smart Paste Error: Window Not Found: " + WindowTitle);
                return false;
            }
            EventLogger.LogNewEvent("MAD Smart Paste: Window Found: " + WindowTitle + Environment.NewLine);
            return GetMADSearchWindow();            
        }

        private static bool GetMADSearchWindow()
        {
            _madSearchWindow = _madWindow.MdiChild(SearchCriteria.ByControlType(ControlType.Window).AndByText(ControlText));
            if (_madSearchWindow == null)
            {
                EventLogger.LogAndSaveNewEvent("MAD Smart Paste Error: MDIChild Not Found: " + ControlText + Environment.NewLine);
                return false;
            }
            EventLogger.LogNewEvent("MAD Smart Paste: MDIChild Found: " + ControlText);
            EventLogger.LogNewEvent("MAD Smart Paste: Edit Bounds: " + _madSearchWindow.Bounds.Location.X + "," + _madSearchWindow.Bounds.Location.Y);
            return true;
        }

        private static bool GetMADEdit()
        {
            _madEdit = _madSearchWindow.Get(SearchCriteria.ByControlType(ControlType.Edit));
            if (_madEdit == null)
            {
                EventLogger.LogAndSaveNewEvent("MAD Smart Paste Error: Edit Not Found" + Environment.NewLine);
                return false;
            }
            EventLogger.LogNewEvent("MAD Smart Paste: Edit Found");

            return true;
        }

        public static void SetActiveElement(CustomerContact contact)
        {
            EventLogger.LogAndSaveNewEvent("MAD Smart Paste: Starting SetActiveElement");


            if (_madWindow == null)
            {
                if (!GetMADWindow())
                    return;
            }
            else if(!_madWindow.IsClosed)
            {
                if (!GetMADWindow())
                    return;
            }

            if (_madSearchWindow == null)
            {
                if (!GetMADSearchWindow())
                    return;
            }

            if (_madEdit == null)
            {
                if (!GetMADEdit())
                    return;
            }

            //var window = TestStack.White.Desktop.Instance.Windows().Find(obj => obj.Title.Contains(windowTitle));
            //if (window == null)
            //{
            //    EventLogger.LogAndSaveNewEvent("MAD Smart Paste Error: Window Not Found: " + windowTitle);
            //    return;
            //}
            //EventLogger.LogNewEvent("MAD Smart Paste: Window Found: " + windowTitle + Environment.NewLine);

            //var mdiChild = window.MdiChild(SearchCriteria.ByControlType(controlType).AndByText(controlText));
            //if (mdiChild == null)
            //{
            //    EventLogger.LogAndSaveNewEvent("MAD Smart Paste Error: MDIChild Not Found: " + controlText + Environment.NewLine);
            //    return;
            //}
            //EventLogger.LogNewEvent("MAD Smart Paste: MDIChild Found: " + controlText);
            //EventLogger.LogNewEvent("MAD Smart Paste: Edit Bounds: " + mdiChild.Bounds.Location.X + "," + mdiChild.Bounds.Location.Y);

            //var edit = _madSearchWindow.Get(SearchCriteria.ByControlType(ControlType.Edit));
            //if (edit == null)
            //{
            //    EventLogger.LogAndSaveNewEvent("MAD Smart Paste Error: Edit Not Found" + Environment.NewLine);
            //    return;
            //}
            //EventLogger.LogNewEvent("MAD Smart Paste: Edit Found with Bound: " + edit.Bounds.Location.X + "," + edit.Bounds.Location.Y);

            var offset = _madEdit.Bounds.Location - _madSearchWindow.Bounds.Location;//new Point(_madEdit.Bounds.Location.X - _madSearchWindow.Bounds.Location.X, _madEdit.Bounds.Location.Y - _madSearchWindow.Bounds.Location.Y);
            EventLogger.LogNewEvent("MAD Smart Paste: Edit Offset: " + offset.X + "," + offset.Y);
            
            var editMatch = ElementOffsets.FirstOrDefault(x => x.Offset == offset);
            if (editMatch == null)
            {
                EventLogger.LogAndSaveNewEvent("MAD Smart Paste Error: Edit Name Not Found" + Environment.NewLine);
                return;
            }
            EventLogger.LogNewEvent("MAD Smart Paste: Edit Name Found: " + editMatch.Name);

            EventLogger.LogNewEvent("MAD Smart Paste: Trying to set MAD value" + Environment.NewLine);
            _madEdit.SetValue(FindProperty.FollowPropertyPath(contact, editMatch.Name));

            EventLogger.SaveLog();
        }

        //public static void SetElementValue(string _value)
        //{
        //    MADActiveElement.SetValue(_value);
        //}

        //public static void SetElementText(string _value)
        //{
        //    MADActiveElement.Text = _value;
        //}

        //private static bool InitMADMonitor()
        //{
        //    //string windowTitle = "Oracle";
        //    //ControlType controlType = ControlType.Window;
        //    //string controlText = "Search";

        //    //var window = TestStack.White.Desktop.Instance.Windows().Find(obj => obj.Title.Contains(windowTitle));
        //    //if (window == null)
        //    //{
        //    //    EventLogger.LogNewEvent("Window Not Found: " + windowTitle + Environment.NewLine);
        //    //    return false;
        //    //}

        //    //var mdiChild = window.MdiChild(SearchCriteria.ByControlType(controlType).AndByText(controlText));
        //    //if (mdiChild == null){
        //    //    EventLogger.LogNewEvent(controlText + " Not Found");
        //    //    return false;
        //    //}

        //    //var edit = mdiChild.Get(SearchCriteria.ByControlType(ControlType.Edit));
        //    //if (edit == null)
        //    //{
        //    //    EventLogger.LogNewEvent("Edit Not Found");
        //    //    return false;
        //    //}

        //    //return true;

        //    //foreach (Process pList in Process.GetProcesses())
        //    //    if (pList.MainWindowTitle.Contains("Oracle Forms Runtime"))
        //    //        MADProcess = pList;

        //    //if (MADProcess == null)
        //    //{
        //    //    EventLogger.LogNewEvent("Unable to Find MAD", EventLogLevel.Status);
        //    //    return false;
        //    //}

        //    //MADProcess.Exited += MADProcess_Exited;
        //    //MADApplication = TestStack.White.Application.Attach(MADProcess);
            
        //    //MADWindow = MADApplication.GetWindow(SearchCriteria.ByText("Search"), InitializeOption.NoCache);
        //    //if (!MADWindow.Exists(SearchCriteria.ByText("Search")))
        //    //    return false;
        //    //return true;
        //}

        //static void MADProcess_Exited(object sender, EventArgs e)
        //{
        //    MADProcess.Exited -= MADProcess_Exited;
        //    MADProcess.Dispose();
        //    MADProcess = null;
        //}

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