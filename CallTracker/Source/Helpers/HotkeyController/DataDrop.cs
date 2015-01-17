using CallTracker.Model;
using CallTracker.View;
using Shortcut;

namespace CallTracker.Helpers
{
    public partial class HotkeyController
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Data Drop  ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void DataDrop(HotkeyPressedEventArgs e)
        {
            if (parent.SelectedContact == null)
            {
                EventLogger.LogAndSaveNewEvent("Data Drop Error: No Contact Selected", EventLogLevel.Status);
                return;
            }
            Main.DataDrop.Show();
            parent.SelectedContact.AddAppEvent(AppEventTypes.DataDrop);
        }
    }
}