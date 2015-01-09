using CallTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.UIItems.Finders;
using Window = TestStack.White.UIItems.WindowItems.Window;

namespace CallTracker.Helpers
{
    public class MADElementOffset
    {
        public string Name { get; set; }

        public Vector Offset { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

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
            new MADElementOffset("DN|0$1", 11, 212),
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

        public static void SetActiveElement(CustomerContact contact)
        {
            EventLogger.LogAndSaveNewEvent("MAD Smart Paste: Starting SetActiveElement");

            if (!CacheUIElements()) return;

            var offset = _madEdit.Bounds.Location - _madSearchWindow.Bounds.Location;//new Point(_madEdit.Bounds.Location.X - _madSearchWindow.Bounds.Location.X, _madEdit.Bounds.Location.Y - _madSearchWindow.Bounds.Location.Y);
            EventLogger.LogNewEvent("MAD Smart Paste: Edit Offset: " + offset.X + "," + offset.Y);

            var editMatch = ElementOffsets.FirstOrDefault(x => x.Offset == offset);
            if (editMatch == null)
            {
                EventLogger.LogNewEvent("MAD Smart Paste Error: Edit Name Not Found" + Environment.NewLine);
                return;
            }
            EventLogger.LogNewEvent("MAD Smart Paste: Edit Name Found: " + editMatch.Name);

            EventLogger.LogNewEvent("MAD Smart Paste: Trying to set MAD value" + Environment.NewLine);
            _madEdit.SetValue(FindProperty.FollowPropertyPath(contact, editMatch.Name));

            EventLogger.SaveLog();
        }

        private static bool CacheUIElements()
        {
            if (_madWindow == null)
            {
                if (!GetMADWindow())
                    return false;
            }
            else if (!_madWindow.IsClosed)
            {
                if (!GetMADWindow())
                    return false;
            }

            if (_madSearchWindow == null)
            {
                if (!GetMADSearchWindow())
                    return false;
            }

            if (_madEdit == null)
            {
                if (!GetMADEdit())
                    return false;
            }

            return true;
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