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
        // Data Paste ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static readonly Dictionary<Keys, string> DataPasteHotkeys = new Dictionary<Keys, string>
        {
            {Keys.D1, "ICON"},
            {Keys.D2, "CMBS"},
            {Keys.Q , "Username"},
            {Keys.W , "DN"},
            {Keys.A , "Name.Full"},
            {Keys.S , "Mobile"},
            {Keys.Z , "Fault.PR"},
            {Keys.X , "Service.Node"}
        };

        private static void OnDataPaste(HotkeyPressedEventArgs e)
        {
            if (parent.SelectedContact == null)
            {
                EventLogger.LogAndSaveNewEvent("DataPaste Error: No Contact Selected", EventLogLevel.Brief);
                return;
            }

            EventLogger.LogNewEvent(String.Format(Environment.NewLine + "Pasting: {0}", e.Name), EventLogLevel.Brief);
            var dataToPaste = FindProperty.FollowPropertyPath(parent.SelectedContact, e.Name);

            if (String.IsNullOrEmpty(dataToPaste))
            {
                EventLogger.LogAndSaveNewEvent("DataPaste Error: No Data to paste.", EventLogLevel.Brief);
                return;
            }

            if (CallTracker.Properties.Settings.Default.dataPasteTypeInput)
            {
                SendKeys.Send(dataToPaste);
            }
            else
            {
                var oldClip = String.Empty;
                if (Clipboard.ContainsText())
                {
                    oldClip = Clipboard.GetText();
                }

                Clipboard.Clear();
                Clipboard.SetText(dataToPaste);
                SendKeys.SendWait("+^");
                SendKeys.SendWait("^(v)");
                Clipboard.SetText(oldClip);
            }

            //Stopwatch.Reset();
            //Stopwatch.Start();
            //while (Clipboard.GetText() == dataToPaste && Stopwatch.ElapsedMilliseconds <= 100)
            //    SendKeys.Flush();
            //Stopwatch.Stop();

            parent.AddAppEvent(AppEventTypes.DataPaste);
        }
    }
}