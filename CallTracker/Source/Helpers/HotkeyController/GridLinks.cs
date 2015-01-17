using CallTracker.Model;
using Shortcut;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CallTracker.Helpers
{
    public partial class HotkeyController
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Grid Links ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static readonly Dictionary<Keys, string> GridLinkHotkeys = new Dictionary<Keys, string>
        {
            {Keys.NumPad0, "0"},
            {Keys.NumPad1, "1"},
            {Keys.NumPad2, "2"},
            {Keys.NumPad3, "3"},
            {Keys.NumPad4, "4"},
            {Keys.NumPad5, "5"},
            {Keys.NumPad6, "6"},
            {Keys.NumPad7, "7"},
            {Keys.NumPad8, "8"},
            {Keys.NumPad9, "9"}
        };

        private static void OnGridLinks(HotkeyPressedEventArgs e)
        {
            var systemItem = parent.BindsDataStore.GridLinks.GetSystemItem(Convert.ToInt32(e.Name.Remove(0, 2)));
            EventLogger.LogNewEvent(Environment.NewLine + "GridLinks Starting: " + systemItem.Url, EventLogLevel.Brief);

            if (systemItem.System == "MAD" || systemItem.System == "OPOM")
            {
                var hWnd = IntPtr.Zero;
                hWnd = WindowHelper.FindHWNDByTitle(systemItem.Title);

                if (hWnd == IntPtr.Zero)
                    hWnd = WindowHelper.FindHWNDByTitle(systemItem.Url);

                if (hWnd == IntPtr.Zero) return;

                WindowHelper.ShowWindow(hWnd, WindowHelper.SW_RESTORE);
                WindowHelper.SetForegroundWindow(hWnd);
            }
            else if (NavigateOrNewIE(systemItem.Url, systemItem.Title))
            {
                //if (!Browser.Exists<IE>(Find.ByTitle(systemItem.Title))) return;
                if (browser != null)
                {
                    AutoLogin(true);
                    browser.Dispose();
                }
            }

            parent.AddAppEvent(AppEventTypes.Gridlink);
            EventLogger.LogNewEvent(String.Format("Switched to: {0}", systemItem.Url), EventLogLevel.ClearStatus);
        }

        private static void OnGridLinksSearch(HotkeyPressedEventArgs e)
        {
            if (parent.SelectedContact == null)
            {
                EventLogger.LogAndSaveNewEvent("GridLinks Search Error: No Contact Selected", EventLogLevel.Brief);
                return;
            }

            var systemItem = parent.BindsDataStore.GridLinks.GetSystemItem(Convert.ToInt32(e.Name.Remove(0, 3)));
            EventLogger.LogNewEvent(Environment.NewLine + "Starting Grid Link Search: " + systemItem.Url, EventLogLevel.Brief);
            var url = String.Empty;

            if (systemItem.System == "MAD" || systemItem.System == "OPOM")
            {
                var hWnd = IntPtr.Zero;
                hWnd = WindowHelper.FindHWNDByTitle(systemItem.Title);

                if (hWnd == IntPtr.Zero) return;

                WindowHelper.ShowWindow(hWnd, WindowHelper.SW_RESTORE);
                WindowHelper.SetForegroundWindow(hWnd);

                url = systemItem.System;
            }
            else
            {
                var productContext = parent.SelectedContact.Fault.AffectedServiceType.ToString();
                foreach (var search in systemItem.Searches)
                {
                    var data = FindProperty.FollowPropertyPath(parent.SelectedContact, search.SearchData, productContext);
                    if (String.IsNullOrEmpty(data)) continue;
                    url = search.SearchURL + data;
                    EventLogger.LogAndSaveNewEvent("GridLinks Search: Found Data: " + data, EventLogLevel.Brief);
                    break;
                }

                if (NavigateOrNewIE(systemItem.Url, systemItem.Title, url))
                {
                    if (String.IsNullOrEmpty(url))
                    {
                        EventLogger.LogAndSaveNewEvent("GridLinks Search Error: No relevant data found",
                            EventLogLevel.Brief);
                        url = systemItem.Url;
                    }

                    //if (!Browser.Exists<IE>(Find.ByUrl(url))) return;
                    if (browser != null)
                    {
                        AutoLogin(true);
                        browser.Dispose();
                    }
                }
            }

            parent.AddAppEvent(AppEventTypes.GridlinkSearch);
            EventLogger.LogNewEvent(String.Format("GridLinks Search: Switched to: {0}", url), EventLogLevel.ClearStatus);
        }
    }
}