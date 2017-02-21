using CallTracker.Model;
using Shortcut;
using System;
using System.Linq;

namespace CallTracker.Helpers
{
    public partial class HotkeyController
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // AutoFill /////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void OnAutoFill(HotkeyPressedEventArgs e)
        {
            if (parent.SelectedContact == null)
            {
                EventLogger.LogAndSaveNewEvent("AutoFill Error: No Contact Selected", EventLogLevel.Brief);
                return;
            }

            EventLogger.LogNewEvent(Environment.NewLine + "AutoFill: Searching for AutoFill Matches", EventLogLevel.Brief);
            if (!GetActiveBrowser())
                return;

            var url = browser.Url;
            var title = browser.Title;

            if (title == "Activity - New activity and notes")
            {
                EventLogger.LogAndSaveNewEvent("AutoFill: Attempting ICON AutoFills", EventLogLevel.Status);
                ICONAutoFill.Go(parent);
            }

            var query = (from
                            bind in parent.BindsDataStore.PasteBinds
                         where
                             (url.Contains(bind.Url) ||
                             title.Contains(bind.Title)) &&
                             bind.AutoFill
                         select
                             bind).ToList();

            if (query.Any())
            {
                EventLogger.LogNewEvent(String.Format("AutoFill: {0} found.", query.Count()));
                var affectedService = parent.SelectedContact.Fault.AffectedServiceType.ToString();
                foreach (var bind in query)
                {
                    try
                    {
                        var value = FindProperty.FollowPropertyPath(parent.SelectedContact, bind.Data, affectedService);
                        bind.Paste(bind.Element, value);
                    }
                    catch (Exception ex)
                    {
                        EventLogger.LogAndSaveNewEvent("Exception: " + ex, EventLogLevel.Status);
                    }
                }
            }
            else
                EventLogger.LogAndSaveNewEvent("AutoFill Error: No Matches Found");

            if (title.Contains("F001 Create"))
            {
                EventLogger.LogAndSaveNewEvent("AutoFill: Attempting IFMS AutoFills", EventLogLevel.Status);
                IFMSAutoFill.Go(parent);
            }

            parent.AddAppEvent(AppEventTypes.AutoFill);

            EventLogger.SaveLog();
            browser.Dispose();
        }
    }
}