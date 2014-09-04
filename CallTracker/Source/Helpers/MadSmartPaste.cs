using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using CallTracker.Model;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;

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
        //private static Window MADWindow;
        //private static TestStack.White.UIItems.TextBox MADActiveElement;

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

        public static void SetActiveElement(CustomerContact contact)
        {           
            var windowTitle = "Oracle";
            var controlType = ControlType.Window;
            var controlText = "Search";

            var window = TestStack.White.Desktop.Instance.Windows().Find(obj => obj.Title.Contains(windowTitle));
            if (window == null)
            {
                EventLogger.LogNewEvent("Window Not Found: " + windowTitle + Environment.NewLine);
                return;
            }

            var mdiChild = window.MdiChild(SearchCriteria.ByControlType(controlType).AndByText(controlText));
            if (mdiChild == null)
            {
                EventLogger.LogNewEvent(controlText + " Not Found");
                return;
            }

            var edit = mdiChild.Get(SearchCriteria.ByControlType(ControlType.Edit));
            if (edit == null)
            {
                EventLogger.LogNewEvent("Edit Not Found");
                return;
            }

            var editName = ElementOffsets.FirstOrDefault(x => x.Offset == mdiChild.Bounds.Location - edit.Bounds.Location).Name;
            if(String.IsNullOrEmpty(editName))
            {
                EventLogger.LogNewEvent("Edit Name Not Found");
                return;
            }

            EventLogger.LogNewEvent("Trying to set MAD value");
            edit.SetValue(FindProperty.FollowPropertyPath(contact, editName));           
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