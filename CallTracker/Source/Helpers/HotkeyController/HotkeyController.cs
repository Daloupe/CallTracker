using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

using Shortcut;
using WatiN.Core;
using SHDocVw;

using CallTracker.View;
using CallTracker.Model;
using WatiN.Core.Native.Windows;

namespace CallTracker.Helpers
{
    public delegate void ActionEventHandler(string _event, EventLogLevel _logLevel = EventLogLevel.Verbose);

    public partial class HotkeyController : IDisposable
    {
        private static Main parent;
        public static IE browser;
        private static HotKeyManager HotKeyManager;
        //public static event ActionEventHandler OnAction;
        //private static readonly Stopwatch StopwatchTester = new Stopwatch();

        public HotkeyController(Main _parent)
        {
            parent = _parent;

            HotKeyManager = new HotKeyManager();
            HotKeyManager.AddOrReplaceHotkey("wintest", Modifiers.Win, Keys.N, OnTest);
            //HotKeyManager.AddOrReplaceHotkey("wintest2", Modifiers.Win, Keys.G, OnTest2);
            HotKeyManager.AddOrReplaceHotkey("DataDrop", Modifiers.Control, Keys.Space, DataDrop);
            HotKeyManager.AddOrReplaceHotkey("SmartCopy", Modifiers.Win, Keys.C, OnSmartCopy);
            HotKeyManager.AddOrReplaceHotkey("SmartPaste", Modifiers.Win, Keys.V, OnSmartPaste);
            HotKeyManager.AddOrReplaceHotkey("BindSmartPaste", Modifiers.Win | Modifiers.Shift, Keys.V, OnBindSmartPaste);
            HotKeyManager.AddOrReplaceHotkey("AutoLogin", Modifiers.Win, Keys.Oemtilde, OnAutoLogin);
            HotKeyManager.AddOrReplaceHotkey("AutoFill", Modifiers.Win | Modifiers.Control, Keys.V, OnAutoFill);
            HotKeyManager.AddOrReplaceHotkey("AddARO", Modifiers.Win | Modifiers.Shift, Keys.C, OnAddARO);
            foreach (var dataPasteHotkey in DataPasteHotkeys)
                HotKeyManager.AddOrReplaceHotkey(dataPasteHotkey.Value, Modifiers.Control | Modifiers.Shift, dataPasteHotkey.Key, OnDataPaste);
            foreach (var gridLinkHotKey in GridLinkHotkeys)
            {
                HotKeyManager.AddOrReplaceHotkey("GL" + gridLinkHotKey.Value, Modifiers.Win, gridLinkHotKey.Key, OnGridLinks);
                HotKeyManager.AddOrReplaceHotkey("GLS" + gridLinkHotKey.Value, Modifiers.Win | Modifiers.Control, gridLinkHotKey.Key, OnGridLinksSearch);
            }

            Settings.AutoStartDialogWatcher = false;
            Settings.AutoMoveMousePointerToTopLeft = false;
            Settings.AutoCloseDialogs = false;
            Settings.AttachToBrowserTimeOut = 3;
            Settings.WaitForCompleteTimeOut = 3;
            Settings.WaitUntilExistsTimeOut = 3;
            Settings.HighLightElement = false;
        }

        public void Dispose()
        {
            HotKeyManager.UnbindHotkeys();
            
            if (browser != null)
                browser.Dispose();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // TEST  ////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void OnTest(HotkeyPressedEventArgs e)
        {
            //if (!GetActiveBrowser())
            //    return;
            //ICONAutoFill.Go(parent);

            //browser.Dispose();
        }
        private static void OnTest2(HotkeyPressedEventArgs e)
        {
            if (!GetActiveBrowser())
                return;
            IFMSAutoFill.Go(parent);
            browser.Dispose();
        }

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

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // ARO //////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void OnAddARO(HotkeyPressedEventArgs e)
        {
            Main.ShowPopupForm<AddAROForm>();
        }

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
            var systemItem = parent.BindsDataStore.GridLinks.GetSystemItem(Convert.ToInt32(e.Name.Remove(0,2)));
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

            //var oldClip = String.Empty;
            //if (Clipboard.ContainsText())
            //{
            //    oldClip = Clipboard.GetText();
            //    Clipboard.Clear();
            //}

            //Clipboard.SetText(dataToPaste);
            //SendKeys.Send("+^");
            //SendKeys.Send("^(v)");
            SendKeys.Send(dataToPaste);
            //Application.DoEvents();
            //SendKeys.Flush();

            //Stopwatch.Reset();
            //Stopwatch.Start();
            //while (Clipboard.GetText() == dataToPaste && Stopwatch.ElapsedMilliseconds <= 100)
            //    SendKeys.Flush();
            //Stopwatch.Stop();

            //Clipboard.SetText(oldClip);
            parent.AddAppEvent(AppEventTypes.DataPaste);
        }

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
                SendKeys.Send("0"+dataToPaste);//"^(v)");
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

            var urlOrTitleMatches =  (from
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Auto Login ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void OnAutoLogin(HotkeyPressedEventArgs e)
        {
            AutoLogin();
        }

        /// <summary>
        /// Attempts to AutoLogin. Set useCurrentBrowser to true to avoid refinding and disposing browser.
        /// </summary>
        private static void AutoLogin(bool useCurrentBrowser = false)
        {
            EventLogger.LogNewEvent(Environment.NewLine + "AutoLogin: Searching for matches");
            if (!useCurrentBrowser)
                if (!GetActiveBrowser())
                    return;

            var title = browser.Title;
            var url = browser.Url;

            var query = (from
                            login in parent.LoginsDataStore.Logins
                        where
                            title.Contains(login.Title) ||
                            url.Contains(login.Url)
                        select
                            login)
                        .FirstOrDefault();


            if (query == null)
            {
                EventLogger.LogAndSaveNewEvent("AutoLogin Error: No matches found");
                return;
            }

            EventLogger.LogNewEvent("AutoLogin: Actioning matches");
            query.Paste(query.UsernameElement, query.Username);
            query.Paste(query.PasswordElement, query.Password);
            query.Submit(browser);
            
            parent.AddAppEvent(AppEventTypes.AutoLogin);

            if (!useCurrentBrowser)
                browser.Dispose();
        }

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
                var split = text.Split('\t');
                var sb = new StringBuilder("OPOM: ");
                if (split[0].IsDigits())
                {
                    contact.DN = split[0];
                    sb.Append("DN");
                }
                else
                {
                    contact.Username = split[0];
                    sb.Append("Username");
                }

                if (!String.IsNullOrEmpty(split[1]))
                {
                    contact.Name = split[1];
                    sb.Append(", Name");
                }
                if (!String.IsNullOrEmpty(split[9]))
                {
                    contact.ICON = split[9];
                    sb.Append(", ICON");
                }
                
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


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        //// System Search /////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //public static void SearchSystem(string url, string searchValue, string searchElement, string submitElement = "")
        //{
        //    EventLogger.LogNewEvent("Searching System", EventLogLevel.Brief);

        //    if (!FindIEByUrl(url))
        //        NavigateOrNewIE(url);

        //    // Fill Search field ////////////////////////////////////////////////////////
        //    var query = (from
        //                    bind in parent.BindsDataStore.PasteBinds
        //                where
        //                    bind.Element == searchElement &&
        //                    (url.Contains(bind.Url))
        //                select
        //                    bind)
        //                .FirstOrDefault();

        //    if (query != null)
        //    {
        //        EventLogger.LogNewEvent("Element Match Found");
        //        query.Paste(searchElement, searchValue);        
        //    };

        //    // Click Submit /////////////////////////////////////////////////////////////
        //    if (!String.IsNullOrEmpty(submitElement))
        //    {
        //        query = (from bind in parent.BindsDataStore.PasteBinds
        //                where
        //                    bind.Element == submitElement &&
        //                    (url.Contains(bind.Url))
        //                select
        //                    bind)
        //                .FirstOrDefault();
                
        //        if (query != null)
        //        {
        //            EventLogger.LogNewEvent("Button Match Found");
        //            query.Paste(submitElement, "");
        //        }
        //    }
        //    parent.AddAppEvent(AppEventTypes.SystemSearch);
        //    browser.Dispose();
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Browser Methods //////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Waits for async post back to complete.
        /// </summary>
        /// <param name="ie">The ie instance to use.</param>
        public static void WaitForAsyncPostBackToComplete()
        {
            EventLogger.LogAndSaveNewEvent("WaitForAsyncPostBackToComplete Called", EventLogLevel.Status);
            var startWait = 5000;
            var isInPostback = true;
            while (startWait > 0)
            {
                isInPostback = Convert.ToBoolean(browser.Eval("Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack();"));
                if (!isInPostback) break;
                Thread.Sleep(200); //sleep for 200ms and query again 
                Application.DoEvents();
                startWait -= 200;
            }
            EventLogger.LogNewEvent(String.Format("WaitForAsyncPostBackToComplete isInPostback: {0} in: {1} ms", isInPostback, startWait), EventLogLevel.Status);
        }
        
        public static bool WaitForBrowserBusy()
        {
            EventLogger.LogAndSaveNewEvent("WaitForBrowserBusy Called", EventLogLevel.Status);
            var sw = new Stopwatch();//.Reset();
            sw.Start();
            var ieBrowser = (IWebBrowser2)browser.InternetExplorer;
            while (ieBrowser.Busy)
            {
                if (sw.ElapsedMilliseconds > 5000) break;
            }
            EventLogger.LogNewEvent(String.Format("Browser busy: {0} with: {1} ms remaining", ieBrowser.Busy, sw.ElapsedMilliseconds), EventLogLevel.Status);
            return !ieBrowser.Busy;
        }
        
        public static bool GetActiveBrowser()
        {
            var title = WindowHelper.GetActiveWindowTitle();
            if (FindIEByTitle(title)) return true;
            EventLogger.LogAndSaveNewEvent(String.Format("Unable to find page by title: {0}", title));

            var hwnd = WindowHelper.GetActiveWindowHWND();
            if (FindIEByHWND(hwnd)) return true;
            EventLogger.LogAndSaveNewEvent(String.Format("Unable to find page by HWND: {0}", hwnd));

            return false;
        }

        public static bool FindIEByHWND(IntPtr hwnd)
        {
            var currentHWND = hwnd.ToString();

            if (!Browser.Exists<IE>(Find.By("hwnd", currentHWND)))
                return false;

            //if (PreviousIEMatch != currentHWND)
            //{
                //if (browser != null)
                //    browser.Dispose();
                browser = Browser.AttachToNoWait<IE>(Find.By("hwnd", currentHWND));
                browser.AutoClose = false;
                //PreviousIEMatch = currentHWND;
            //}

            return true;
        }

        public static bool FindIEByTitle(string title)
        {      
            var currentTitle = Regex.Match(title, @"(?:http(?:s)?://[\w\./]+ - )?(\w+)(?:\s-(?: Windows)? Internet Explorer)?", RegexOptions.IgnoreCase).Groups[1].Value;
            //var currentTitle = new Regex(".*" + title + ".*", RegexOptions.IgnoreCase);//new Regex("(http(s)?://)?.*" + title + ".*", RegexOptions.IgnoreCase); 
            if (!Browser.Exists<IE>(Find.ByTitle(currentTitle)))
            {
                EventLogger.LogAndSaveNewEvent("Unable to Find IE by Title: " + title, EventLogLevel.Brief);
                return false;
            }
            EventLogger.LogNewEvent("Found IE by Title: " + title, EventLogLevel.Brief);

            browser = Browser.AttachToNoWait<IE>(Find.ByTitle(currentTitle));
            browser.AutoClose = false;

            return true;
        }

        public static bool FindIEByTitle(string title, ref IE toBrowser)
        {
            var currentTitle = Regex.Match(title, @"(?:http(?:s)?://[\w\./]+ - )?(\w+)(?:\s-(?: Windows)? Internet Explorer)?", RegexOptions.IgnoreCase).Groups[1].Value;
            //var currentTitle = new Regex(".*" + title + ".*", RegexOptions.IgnoreCase);//new Regex("(http(s)?://)?.*" + title + ".*", RegexOptions.IgnoreCase); 
            if (!Browser.Exists<IE>(Find.ByTitle(currentTitle)))
            {
                EventLogger.LogAndSaveNewEvent("Unable to Find IE by Title: " + title, EventLogLevel.Brief);
                return false;
            }
            EventLogger.LogNewEvent("Found IE by Title: " + title, EventLogLevel.Brief);

            toBrowser = Browser.AttachToNoWait<IE>(Find.ByTitle(currentTitle));
            toBrowser.AutoClose = false;

            return true;
        }

        public static bool FindIEByUrl(string url)
        {
            var urlRegex = new Regex("(http(s)?://)?.*" + url + ".*", RegexOptions.IgnoreCase);
            
            if (!Browser.Exists<IE>(Find.ByUrl(urlRegex)))
            {
                EventLogger.LogAndSaveNewEvent("Unable to Find IE by URL: " + url, EventLogLevel.Brief);
                return false;
            }
            EventLogger.LogNewEvent("Found IE by URL: " + url, EventLogLevel.Brief);

            browser = Browser.AttachToNoWait<IE>(Find.ByUrl(urlRegex));
            browser.AutoClose = false;

            return true;
        }

        public static bool FindIEByUrl(string url, ref IE toBrowser)
        {
            //var urlRegex = new Regex("(http(s)?://)?.*" + url + ".*", RegexOptions.IgnoreCase);

            var urlRegex = new Regex(url + ".*", RegexOptions.IgnoreCase);

            if (!Browser.Exists<IE>(Find.ByUrl(urlRegex)))
            {
                EventLogger.LogAndSaveNewEvent("Unable to Find IE by URL: " + url, EventLogLevel.Brief);
                return false;
            }
            EventLogger.LogNewEvent("Found IE by URL: " + url, EventLogLevel.Brief);

            toBrowser = Browser.AttachToNoWait<IE>(Find.ByUrl(urlRegex));
            toBrowser.AutoClose = false;

            return true;
        }

        //private static Process m_Proc;
        public static bool CreateNewIE(string url)
        {
            EventLogger.LogNewEvent("Unhooking brower");
            if (browser != null)
                browser.Dispose();

            EventLogger.LogNewEvent("Creating brower");

            //browser = new IE(url, true){AutoClose = false};
            var mProc = Process.Start("IExplore.exe", url);
            if (mProc != null)
                mProc.Dispose();
            return true;
        }

        /// <summary>
        /// Navigates to IE tab, or creates a new one if not found. Call browser.dispose() after calling this method.
        /// </summary>
        public static bool NavigateOrNewIE(string url, string title = "", string searchUrl = "")
        {
            EventLogger.LogNewEvent("NavigateOrNewIE Starting", EventLogLevel.Brief);
            var outcome = false;
            if (FindIEByUrl(url))
            {
                browser.ShowWindow(NativeMethods.WindowShowStyle.Restore);
                new IETabActivator(browser).ActivateByTabsUrl(browser.Url);// This Line might be why WOBS isn't activating?
                if (!String.IsNullOrEmpty(searchUrl))
                {                 
                    EventLogger.LogNewEvent("NavigateOrNewIE navigating to URL: " + searchUrl);
                    browser.GoToNoWait(searchUrl);
                }
                outcome = true;
            }
            else if (!String.IsNullOrEmpty(title))
            {
                if (FindIEByTitle(title))
                {
                    browser.ShowWindow(NativeMethods.WindowShowStyle.Restore);
                    new IETabActivator(browser).ActivateByTabsUrl(browser.Url);
                    if (!String.IsNullOrEmpty(searchUrl))
                    {                  
                        EventLogger.LogNewEvent("NavigateOrNewIE navigating to URL: " + searchUrl);
                        browser.GoToNoWait(searchUrl);
                    }
                    outcome = true;
                }
            }

            if (!outcome)
            {
                EventLogger.LogNewEvent("NavigateOrNewIE: Creating new IE window", EventLogLevel.Brief);
                if (!String.IsNullOrEmpty(searchUrl))
                {
                    if (CreateNewIE(searchUrl))
                        outcome = true;
                }
                else if (CreateNewIE(url))
                    outcome = true;
            }

            return outcome;
        }
    }


}