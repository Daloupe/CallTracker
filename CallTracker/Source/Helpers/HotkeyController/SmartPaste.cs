using CallTracker.Model;
using CallTracker.View;
using Shortcut;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CallTracker.Helpers
{
    public partial class HotkeyController
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        // Smart Paste ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void OnSmartPaste(HotkeyPressedEventArgs e)
        {
            if (parent.SelectedContact == null)
            {
                EventLogger.LogAndSaveNewEvent("SmartPaste Error: No Contact Selected", EventLogLevel.Brief);
                return;
            }
            var activeWindowTitle = WindowHelper.GetActiveWindowTitle();
            EventLogger.LogNewEvent(Environment.NewLine + "Searching for SmartPaste Matches for Window: " + activeWindowTitle, EventLogLevel.Brief);

            var oldClip = String.Empty;
            if (Clipboard.ContainsText())
            {
                oldClip = Clipboard.GetText();
                Clipboard.Clear();
            }

            if (activeWindowTitle == "Oracle Forms Runtime")//.Contains("Oracle Forms Runtime"))
            {
                EventLogger.LogAndSaveNewEvent("Trying to set MAD Active element");
                MadSmartPaste.SetActiveElement(parent.SelectedContact);
            }
            else if (activeWindowTitle == "CTI Dial Pad")
            {
                EventLogger.LogAndSaveNewEvent("Trying to paste into CTI Dial Pad");
                var dataToPaste = FindProperty.FollowPropertyPath(parent.SelectedContact, "DN,Mobile");
                if (String.IsNullOrEmpty(dataToPaste))
                {
                    EventLogger.LogAndSaveNewEvent("SmartPaste Error: No Data to paste.", EventLogLevel.Brief);
                    return;
                }
                //Clipboard.SetText(String.Format("0{0}", dataToPaste));
                //var sw = new Stopwatch();
                //sw.Start();
                //while (!Clipboard.ContainsText() && sw.ElapsedMilliseconds <= 100)
                //    SendKeys.Flush();
                //sw.Stop();
                SendKeys.Send("0" + dataToPaste);//"^(v)");
            }
            else
            {
                if (!GetActiveBrowser())
                    return;

                var url = browser.Url;
                var title = browser.Title;
                var activeElement = browser.ActiveElement;

                var query = (from
                                bind in parent.BindsDataStore.PasteBinds
                             where
                                bind.Element == activeElement.IdOrName &&
                                (url.Contains(bind.Url) ||
                                title.Contains(bind.Title))
                             select
                                bind)
                             .FirstOrDefault();

                if (query != null)
                {
                    var s = FindProperty.FollowPropertyPath(parent.SelectedContact, query.Data,
                        parent.SelectedContact.Fault.AffectedServiceType.ToString());

                    if (query.PasteWithSendKeys)
                    {
                        activeElement.SetAttributeValue("value", "");
                        Clipboard.SetText(s);
                        SendKeys.SendWait("^(v)");
                        if (query.FireOnChange)
                            WaitForBrowserBusy();
                    }
                    else
                    {
                        activeElement.SetAttributeValue("value", s); //query.Paste(browser, element, s);
                        if (query.FireOnChange)
                        {
                            activeElement.FireEvent("onchange");
                            WaitForBrowserBusy();
                        }
                        else if (query.FireOnChangeNoWait)
                            activeElement.FireEventNoWait("onchange");
                    }

                    EventLogger.LogNewEvent("Smart Paste: Match Found: " + s);
                }
                else
                    EventLogger.LogAndSaveNewEvent("Smart Paste Error: No Matches Found");

                browser.Dispose();
            }
            parent.AddAppEvent(AppEventTypes.SmartPaste);
            Clipboard.SetText(oldClip);
        }

        private static void OnBindSmartPaste(HotkeyPressedEventArgs e)
        {
            EventLogger.LogNewEvent(Environment.NewLine + "Searching for matching binds", EventLogLevel.Brief);
            parent.AddAppEvent(AppEventTypes.BindSmartPaste);
            if (!GetActiveBrowser())
                return;

            var url = browser.Url;
            var title = browser.Title;
            var activeElement = browser.ActiveElement;
            //if (activeElement.GetType() == typeof(Frame))
            //{
            //    EventLogger.LogAndSaveNewEvent("Is Frame", EventLogLevel.Status);
            //    //browser.Frames[2].ac
            //}

            //Console.WriteLine(browser.ActiveElement.GetAttributeValue("type"));
            if (activeElement == null)
            {
                EventLogger.LogAndSaveNewEvent("Smart Paste Bind Error: activeElement is Null");
                return;
            }
            EventLogger.LogNewEvent("Smart Paste Bind: activeElement Found");

            if (String.IsNullOrEmpty(activeElement.IdOrName))
            {
                EventLogger.LogAndSaveNewEvent("Smart Paste Bind Error: activeElement.IdOrName is NullOrEmpty");
                return;
            }

            var urlOrTitleMatches = (from
                                       bind in parent.BindsDataStore.PasteBinds
                                     where
                                        url.Contains(bind.Url) ||
                                        title.Contains(bind.Title)
                                     select
                                        bind).ToList();

            var elementMatch = urlOrTitleMatches.FirstOrDefault(bind => bind.Element == activeElement.IdOrName);

            if (elementMatch == null)
            {
                var system = urlOrTitleMatches.Any() ? urlOrTitleMatches.First().System : String.Empty;
                elementMatch = new PasteBind(system, url, title, activeElement);
                parent.BindsDataStore.PasteBinds.Add(elementMatch);
                EventLogger.LogNewEvent("Smart Paste Bind: New Bind Created");
            }

            parent.editSmartPasteBinds.SelectQuery(elementMatch);
            Main.BindSmartPasteForm.SelectQuery(elementMatch);
            Main.BindSmartPasteForm.Show();
            //Main.ShowPopupForm<BindSmartPasteForm>().SelectQuery(elementMatch);

            browser.Dispose();
        }
    }
}