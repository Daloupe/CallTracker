using CallTracker.Model;
using CallTracker.View;
using Shortcut;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CallTracker.Helpers
{
    public partial class HotkeyController
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Smart Copy ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void OnSmartCopy(HotkeyPressedEventArgs e)
        {
            if (parent.SelectedContact == null)
            {
                EventLogger.LogAndSaveNewEvent("Smart Copy Error: No Contact Selected", EventLogLevel.Brief);
                return;
            }
            //StopwatchTester.Reset();
            //StopwatchTester.Start();
            EventLogger.LogNewEvent(Environment.NewLine + "Starting Smart Copy", EventLogLevel.Brief);

            var oldClip = String.Empty;
            if (Clipboard.ContainsText())
            {
                oldClip = Clipboard.GetText();
                Clipboard.Clear();
            }

            SendKeys.Send("^(c)");
            SendKeys.Flush();
            var sw = new Stopwatch();
            sw.Start();
            while (!Clipboard.ContainsText() && sw.ElapsedMilliseconds <= 100)
                SendKeys.Flush();
            sw.Stop();

            var text = Clipboard.GetText().Trim();
            var textlen = text.Length;
            if (textlen == 0)
            {
                EventLogger.LogNewEvent("Smart Copy Error: Nothing Selected in " + sw.ElapsedTicks + " ticks", EventLogLevel.Brief);
                Main.FadingToolTip.ShowandFade("Nothing selected");
                return;
            }

            var contact = parent.SelectedContact;
            if (WindowHelper.GetActiveWindowTitle().Contains("Service Instance Search") && text.Contains('\t'))
            {
                Main.FadingToolTip.SupressToolTips = true;
                var split = text.Split('\t');
                var sb = new StringBuilder("OPOM: ");
                if (split[0].IsDigits())
                {
                    contact.FindDNMatch(split[0]);
                    sb.Append("DN");
                }
                else
                {
                    contact.FindUsernameMatch(split[0]);
                    sb.Append("Username");
                }

                if (!String.IsNullOrEmpty(split[1]))
                {
                    contact.FindNameMatch(split[1]);
                    sb.Append(", Name");
                }
                if (!String.IsNullOrEmpty(split[9]))
                {
                    contact.FindICONMatch(split[9]);
                    sb.Append(", ICON");
                }

                Main.FadingToolTip.SupressToolTips = false;
                Main.FadingToolTip.ShowandFade(sb.ToString());
            }
            else
            {
                SmartCopy(text);
            }

            EventLogger.LogNewEvent(String.Format("{0} copied from the clipboard in {1} ticks", text, sw.ElapsedTicks));
            if (!String.IsNullOrEmpty(oldClip))
                Clipboard.SetText(oldClip);

            parent.AddAppEvent(AppEventTypes.SmartCopy);
            //EventLogger.LogNewEvent(StopwatchTester.ElapsedMilliseconds + "ms", EventLogLevel.Status);
            //StopwatchTester.Stop();
        }

        public static void SmartCopy(string text)
        {
            var contact = parent.SelectedContact;
            var textlen = text.Length;
            if (text.IsDigits())
            {
                if (contact.Fault.FindPRMatch(text)) { }
                else if (contact.FindDNMatch(text)) { }
                else if (contact.FindCMBSMatch(text)) { }
                else if (contact.FindICONMatch(text)) { }
                else if (contact.FindMobileMatch(text)) { }
                //else if (contact.Service.FindNTDSNMatch(text)) { }
                else if (contact.Service.FindAddressIdMatch(text)) { }
                else if (contact.Service.FindGSIDMatch(text)) { }
                else if (contact.Service.FindIPMatch(text)) { }
                else if (contact.Fault.FindITCaseMatch(text)) { }
                else
                    contact.AddToNote(text);
            }
            else if (text.IsLetters())
            {
                if (contact.FindNameMatch(text)) { }
                else if (contact.FindUsernameMatch(text)) { }
                else
                    contact.AddToNote(text);
            }
            else if (Char.IsLetter(text, 0))
            {
                if (contact.Service.FindEquipmentMatch(parent.editContact._ServicePanel._Equipment._ComboBox.GetDataSource, text)) { }
                else if (contact.Service.FindNBNMatch(text)) { }
                else if (contact.Service.FindBRASMatch(text)) { }
                else if (contact.Service.FindMACMatch(text)) { }
                else if (contact.FindUsernameMatch(text)) { }
                else if (contact.Address.FindAddressMatch(text)) { }
                else
                    contact.AddToNote(text);
            }
            else
            {
                if (contact.Service.FindNodeMatch(text)) { }
                else if (contact.Service.FindMACMatch(text)) { }
                else if (contact.Service.FindESNMatch(text)) { }
                else if (contact.Address.FindAddressMatch(text)) { }
                else
                    contact.AddToNote(text);
            }
        }
    }
}