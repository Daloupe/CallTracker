﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Shortcut;

using WatiN.Core;

using CallTracker.View;
using CallTracker.Model;

namespace CallTracker.Helpers
{
    public delegate void ActionEventHandler(string _event, EventLogLevel _logLevel = EventLogLevel.Verbose);

    public class HotkeyController : IDisposable
    {
        private static Main parent;
        public static IE browser;
        private static HotKeyManager HotKeyManager;
        public static event ActionEventHandler OnAction;
        private static readonly Stopwatch StopwatchTester = new Stopwatch();

        public HotkeyController(Main _parent)
        {
            parent = _parent;

            HotKeyManager = new HotKeyManager();

            HotKeyManager.AddOrReplaceHotkey("wintest", Modifiers.Win, Keys.N, OnTest);
            HotKeyManager.AddOrReplaceHotkey("SmartCopy", Modifiers.Win, Keys.C, OnSmartCopy);
            HotKeyManager.AddOrReplaceHotkey("SmartPaste", Modifiers.Win, Keys.V, OnSmartPaste);
            HotKeyManager.AddOrReplaceHotkey("BindSmartPaste", Modifiers.Win | Modifiers.Shift, Keys.V, OnBindSmartPaste);
            HotKeyManager.AddOrReplaceHotkey("AutoLogin", Modifiers.Win, Keys.Oemtilde, OnAutoLogin);
            HotKeyManager.AddOrReplaceHotkey("AutoFill", Modifiers.Win | Modifiers.Control, Keys.V, OnAutoFill);
            HotKeyManager.AddOrReplaceHotkey("AddARO", Modifiers.Win | Modifiers.Shift, Keys.C, OnAddARO);
            foreach (var DataPasteHotkey in DataPasteHotkeys)
                HotKeyManager.AddOrReplaceHotkey(DataPasteHotkey.Value, Modifiers.Control | Modifiers.Shift, DataPasteHotkey.Key, OnDataPaste);
            foreach (var GridLinkHotKey in GridLinkHotkeys)
            {
                HotKeyManager.AddOrReplaceHotkey("GL" + GridLinkHotKey.Value, Modifiers.Win, GridLinkHotKey.Key, OnGridLinks);
                HotKeyManager.AddOrReplaceHotkey("GLS" + GridLinkHotKey.Value, Modifiers.Win | Modifiers.Control, GridLinkHotKey.Key, OnGridLinksSearch);
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
        // TEST  //////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void OnTest(HotkeyPressedEventArgs e)
        {

            if (!GetActiveBrowser())
                return;
            browser.SelectList(Find.ById("location")).Select("Dulles_Mobile");

            //var url = browser.Url;
            //var title = browser.Title;
            //var element = browser.ActiveElement.IdOrName;

            foreach (var option in browser.ActiveElement.FindNativeElement().Options.GetElements())
            {
                Console.WriteLine(option.GetAttributeValue("value"));
                Console.WriteLine(option.GetAttributeValue("innerHTML"));
                Console.WriteLine(option.ToString());
            }

           //Console.WriteLine(WindowHelper.GetActiveWindowTitle());
            ICONAutoFill.Go(parent);
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
            var systemItem = parent.UserDataStore.GridLinks.GetSystemItem(Convert.ToInt32(e.Name.Remove(0,2)));
            parent.SetProgressBarStep(4, String.Format("Switching to: {0}", systemItem.Url));

            try
            {
                if (systemItem.System == "MAD" || systemItem.System == "OPOM")
                {
                    var hWnd = IntPtr.Zero;
                    hWnd = WindowHelper.FindHWNDByTitle(systemItem.Title);
                    
                    if (hWnd == IntPtr.Zero) return;

                    WindowHelper.ShowWindow(hWnd, WindowHelper.SW_RESTORE);
                    WindowHelper.SetForegroundWindow(hWnd);
                }
                else if (NavigateOrNewIE(systemItem.Url, systemItem.Title))
                {
                    if (!Browser.Exists<IE>(Find.ByTitle(systemItem.Title))) return;
                    
                    WindowHelper.ShowWindow(browser.hWnd, WindowHelper.SW_RESTORE);
                    AutoLogin();
                }
            }
            finally
            {
                parent.AddAppEvent(AppEventTypes.Gridlink);
                parent.UpdateProgressBar(0, String.Format("Switched to: {0}", systemItem.Url), EventLogLevel.ClearStatus);
            }
        }

        private static void OnGridLinksSearch(HotkeyPressedEventArgs e)
        {
            if (parent.SelectedContact == null)
            {
                EventLogger.LogAndSaveNewEvent("GridLinks Search Error: Not Contact Selected", EventLogLevel.Brief);
                return;
            }

            var systemItem = parent.UserDataStore.GridLinks.GetSystemItem(Convert.ToInt32(e.Name.Remove(0, 3)));
            EventLogger.LogNewEvent("Starting Grid Link Search: " + systemItem.Url, EventLogLevel.Brief);
            parent.SetProgressBarStep(4, String.Format("Searching: {0}", systemItem.Url));

            try
            {
                if (systemItem.System == "MAD" || systemItem.System == "OPOM")
                {
                    var hWnd = IntPtr.Zero;
                    hWnd = WindowHelper.FindHWNDByTitle(systemItem.Title);

                    if (hWnd == IntPtr.Zero) return;

                    WindowHelper.ShowWindow(hWnd, WindowHelper.SW_RESTORE);
                    WindowHelper.SetForegroundWindow(hWnd);
                }
                else
                {
                    var url = String.Empty;
                    foreach (var search in systemItem.Searches)
                    {
                        var data = FindProperty.FollowPropertyPath(parent.SelectedContact, search.SearchData, parent.SelectedContact.Fault.AffectedServiceType.ToString());
                        if (String.IsNullOrEmpty(data)) continue;
                        url = search.SearchURL + data;
                        break;
                    }

                    if (String.IsNullOrEmpty(url))
                    {
                        EventLogger.LogAndSaveNewEvent("No relevant data found", EventLogLevel.Brief);
                        url = systemItem.Url;
                    }

                    NavigateOrNewIE(url, systemItem.Title);     

                    if (Browser.Exists<IE>(Find.ByTitle(systemItem.Title)))
                    {
                        WindowHelper.ShowWindow(browser.hWnd, WindowHelper.SW_RESTORE);
                        AutoLogin();
                    }
                }
            }
            finally
            {
                parent.AddAppEvent(AppEventTypes.GridlinkSearch);
                parent.UpdateProgressBar(0, String.Format("Switched to: {0}", systemItem.Url), EventLogLevel.ClearStatus);
            }
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
                EventLogger.LogAndSaveNewEvent("DataPaste Error: Not Contact Selected", EventLogLevel.Brief);
                return;
            }

            EventLogger.LogNewEvent(String.Format("Pasting: {0}", e.Name), EventLogLevel.Brief);
            var dataToPaste = FindProperty.FollowPropertyPath(parent.SelectedContact, e.Name);

            if (String.IsNullOrEmpty(dataToPaste))
            {
                EventLogger.LogAndSaveNewEvent("DataPaste Error: No Data to paste.", EventLogLevel.Brief);
                return;
            }

            Clipboard.SetText(dataToPaste);
            SendKeys.SendWait("+^");
            SendKeys.Flush();
            SendKeys.SendWait("^v");
            Application.DoEvents();
            SendKeys.Flush();
            parent.AddAppEvent(AppEventTypes.DataPaste);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        // Smart Paste ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void OnSmartPaste(HotkeyPressedEventArgs e)
        {
            if (parent.SelectedContact == null)
            {
                EventLogger.LogAndSaveNewEvent("SmartPaste Error: Selected Contact is Null", EventLogLevel.Brief);
                return;
            }

            EventLogger.LogNewEvent("Searching for SmartPaste Matches for Window: " + WindowHelper.GetActiveWindowTitle(), EventLogLevel.Brief);
            if (WindowHelper.GetActiveWindowTitle().Contains("Oracle"))
            {
                MadSmartPaste.SetActiveElement(parent.SelectedContact);
            }
            else
            {
                if (!GetActiveBrowser())
                    return;

                var url = browser.Url;
                var title = browser.Title;
                var activeElement = browser.ActiveElement;

                
                var query = (from
                                bind in parent.UserDataStore.PasteBinds
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

                    activeElement.SetAttributeValue("value", s); //query.Paste(browser, element, s);
                    if (query.FireOnChange)
                        activeElement.FireEvent("onchange");
                    else if (query.FireOnChangeNoWait)
                        activeElement.FireEventNoWait("onchange");

                    parent.AddAppEvent(AppEventTypes.SmartPaste);
                    EventLogger.LogNewEvent("Match Found");
                }
                else
                    EventLogger.LogAndSaveNewEvent("No Matches Found");

                browser.Dispose();
            }
        }

        private static void OnBindSmartPaste(HotkeyPressedEventArgs e)
        {
            EventLogger.LogNewEvent("Searching for matching binds", EventLogLevel.Brief);
            parent.AddAppEvent(AppEventTypes.BindSmartPaste);
            if (!GetActiveBrowser())
                return;

            var url = browser.Url;
            var title = browser.Title;
            var activeElement = browser.ActiveElement;

            //Console.WriteLine(browser.ActiveElement.GetAttributeValue("type"));
            if (activeElement == null)
            {
                EventLogger.LogAndSaveNewEvent("Unable to bind: activeElement is Null");
                return;
            }

            if (String.IsNullOrEmpty(activeElement.IdOrName))
            {
                EventLogger.LogAndSaveNewEvent("Unable to bind: activeElement.IdOrName is NullOrEmpty");
                return;
            }

            var urlOrTitleMatches =  (from
                                        bind in parent.UserDataStore.PasteBinds
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
                parent.UserDataStore.PasteBinds.Add(elementMatch);
                EventLogger.LogNewEvent("New Bind Created");
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
                EventLogger.LogAndSaveNewEvent("GridLinks Search Error: Not Contact Selected", EventLogLevel.Brief);
                return;
            }

            EventLogger.LogNewEvent("Searching for AutoFill Matches", EventLogLevel.Brief);
            if (!GetActiveBrowser())
                return;

            var url = browser.Url;
            var title = browser.Title;

            var query = (from
                            bind in parent.UserDataStore.PasteBinds
                        where
                            url.Contains(bind.Url) ||
                            title.Contains(bind.Title)
                        select
                            bind).ToList();

            if (query.Any())
            {
                EventLogger.LogNewEvent(String.Format("{0} found.", query.Count()));
                var affectedService = parent.SelectedContact.Fault.AffectedServiceType.ToString();
                foreach (var bind in query)
                    bind.Paste(bind.Element, FindProperty.FollowPropertyPath(parent.SelectedContact, bind.Data, affectedService));
            }
            else
                EventLogger.LogAndSaveNewEvent("No Matches Found");

            if (browser.Url.Contains("CreatePR"))
            {
                EventLogger.LogNewEvent("Attempting IFMS AutoFills", EventLogLevel.Status);
                IFMSAutoFill.Go(parent);
            }

            if (browser.Url.Contains("NewActivity"))
            {
                EventLogger.LogNewEvent("Attempting ICON AutoFills", EventLogLevel.Status);
                ICONAutoFill.Go(parent);
            }
            parent.AddAppEvent(AppEventTypes.AutoFill);
            //PreviousIEMatch = browser.Title;
            browser.Dispose();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Auto Login ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void OnAutoLogin(HotkeyPressedEventArgs e)
        {
            parent.SetProgressBarStep(2, "Attempting Autologin", EventLogLevel.Brief);
            AutoLogin();
            parent.UpdateProgressBar(0, "Finished Autologin", EventLogLevel.ClearStatus);
        }

        private static void AutoLogin()
        {
            OnAction("Searching for matches");
            if (!GetActiveBrowser())
                return;

            var title = browser.Title;
            var url = browser.Url;

            var query = (from
                                     login in parent.UserDataStore.Logins
                                 where
                                     title.Contains(login.Title) ||
                                     url.Contains(login.Url)
                                 select
                                     login)
                                 .FirstOrDefault();

            OnAction("Actioning matches");
            if (query == null)
                return;

            query.Paste(query.UsernameElement, query.Username);
            query.Paste(query.PasswordElement, query.Password);
            query.Submit(browser);
            //PreviousIEMatch = browser.Title;
            parent.AddAppEvent(AppEventTypes.AutoLogin);
            browser.Dispose();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Smart Copy ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static readonly Stopwatch Stopwatch = new Stopwatch();
        private static void OnSmartCopy(HotkeyPressedEventArgs e)
        {
            //StopwatchTester.Reset();
            //StopwatchTester.Start();
            EventLogger.LogNewEvent("Starting Smart Copy", EventLogLevel.Brief);
            
            var oldClip = String.Empty;
            if (Clipboard.ContainsText())
            {
                oldClip = Clipboard.GetText();
                Clipboard.Clear();
            }

            SendKeys.SendWait("^c");
            SendKeys.Flush();
            Stopwatch.Reset();
            Stopwatch.Start();
            while (!Clipboard.ContainsText() && Stopwatch.ElapsedMilliseconds <= 500)
                SendKeys.Flush();
            Stopwatch.Stop();

            var text = Clipboard.GetText().Trim();
            var textlen = text.Length;
            if (textlen == 0)
            {
                Main.FadingToolTip.ShowandFade("Nothing selected");
                return;
            }

            var contact = parent.SelectedContact;
            if (WindowHelper.GetActiveWindowTitle() == "OPOM" && text.Contains('\t'))
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
                if(text.IsDigits())
                {
                    if (text.Substring(0, 1) == "1" && textlen == 8)
                    {
                        contact.Fault.PR = text;
                        Main.FadingToolTip.ShowandFade("PR: " + contact.Fault.PR);                   
                    }
                    else if (contact.FindDNMatch(text)) { }
                    else if (contact.FindCMBSMatch(text)) { }
                    else if (contact.FindICONMatch(text)) { }
                    else if (contact.FindMobileMatch(text)) { }
                    //else if (contact.Service.FindNTDSNMatch(text)) { }
                    //else if (contact.Service.FindAddressIdMatch(text)) { }
                    //else if (contact.Service.FindGSIDMatch(text)) { }
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
                    if (parent.editContact._ServicePanel._Equipment._ComboBox.Items.Contains(text))
                    {
                        contact.Service.Equipment = text;
                        Main.FadingToolTip.ShowandFade("Equipment: " + text);
                    }
                    else if (contact.FindUsernameMatch(text)) { }
                    else if (contact.Service.FindNBNMatch(text)) { }
                    else if (contact.Service.FindBRASMatch(text)) { }
                    else if (contact.Service.FindMACMatch(text)) { }
                    else if (contact.Address.FindAddressMatch(text)) { }
                    else
                        contact.AddToNote(text);
                }
                else
                {
                    if (contact.Service.FindNodeMatch(text)) { }
                    else if (contact.Service.FindMACMatch(text)) { }
                    //else if (contact.Service.FindESNMatch(text)) { }
                    else if (contact.Address.FindAddressMatch(text)) { }
                    else
                        contact.AddToNote(text);
                }
            }

            EventLogger.LogNewEvent(String.Format("{0} copied from the clipboard in {1}ticks", text, Stopwatch.ElapsedTicks));
            if (!String.IsNullOrEmpty(oldClip))
                Clipboard.SetText(oldClip);

            parent.AddAppEvent(AppEventTypes.SmartCopy);
            //EventLogger.LogNewEvent(StopwatchTester.ElapsedMilliseconds + "ms", EventLogLevel.Status);
            //StopwatchTester.Stop();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        // System Search /////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void SearchSystem(string url, string searchValue, string searchElement, string submitElement = "")
        {
            EventLogger.LogNewEvent("Searching System", EventLogLevel.Brief);

            if (!FindIEByUrl(url))
                NavigateOrNewIE(url);

            // Fill Search field ////////////////////////////////////////////////////////
            var query = (from
                                    bind in parent.UserDataStore.PasteBinds
                                where
                                    bind.Element == searchElement &&
                                    (url.Contains(bind.Url))
                                select
                                    bind)
                                .FirstOrDefault();

            if (query != null)
            {
                EventLogger.LogNewEvent("Element Match Found");
                query.Paste(searchElement, searchValue);        
            };

            // Click Submit /////////////////////////////////////////////////////////////
            if (!String.IsNullOrEmpty(submitElement))
            {
                query = (from bind in parent.UserDataStore.PasteBinds
                        where
                            bind.Element == submitElement &&
                            (url.Contains(bind.Url))
                        select
                            bind)
                        .FirstOrDefault();
                
                if (query != null)
                {
                    EventLogger.LogNewEvent("Button Match Found");
                    query.Paste(submitElement, "");
                }
            }
            parent.AddAppEvent(AppEventTypes.SystemSearch);
            browser.Dispose();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Browser Methods //////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static bool GetActiveBrowser()
        {
            var title = WindowHelper.GetActiveWindowTitle();
            if (FindIEByTitle(title)) return true;
            EventLogger.LogAndSaveNewEvent(String.Format("Unable to find page by title: {0}", title));

            var hwnd = WindowHelper.GetActiveWindowHWND();
            if (FindIEByHWND(hwnd)) return true;
            EventLogger.LogAndSaveNewEvent(String.Format("Unable to find page by HWND: {0}", hwnd.ToString()));

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
                browser = Browser.AttachTo<IE>(Find.By("hwnd", currentHWND));
                browser.AutoClose = false;
                //PreviousIEMatch = currentHWND;
            //}

            return true;
        }

        public static bool FindIEByTitle(string title)
        {      
            var currentTitle = Regex.Match(title, @"(?:http://[\w\./]+ - )?(\w+)(?:\s-(?: Windows)? Internet Explorer)?", RegexOptions.IgnoreCase).Groups[1].Value;
            //var currentTitle = new Regex(".*" + title + ".*", RegexOptions.IgnoreCase);//new Regex("(http(s)?://)?.*" + title + ".*", RegexOptions.IgnoreCase);
            EventLogger.LogNewEvent("Finding IE by Title", EventLogLevel.Brief);
            if (!Browser.Exists<IE>(Find.ByTitle(currentTitle)))
            {
                EventLogger.LogAndSaveNewEvent("Unable to Find IE by Title", EventLogLevel.Brief);
                return false;
            }

            //if (PreviousIEMatch != currentTitle)
            //{
                //if (browser != null)
                //    browser.Dispose();
            browser = Browser.AttachToNoWait<IE>(Find.ByTitle(currentTitle));
            browser.AutoClose = false;
                //PreviousIEMatch = currentTitle;
            //}

            return true;
        }

        public static bool FindIEByUrl(string url)
        {
            var urlRegex = new Regex("(http(s)?://)?.*" + url + ".*", RegexOptions.IgnoreCase);
            EventLogger.LogNewEvent("Finding IE by URL", EventLogLevel.Brief);
            if (!Browser.Exists<IE>(Find.ByUrl(urlRegex)))
            {
                EventLogger.LogAndSaveNewEvent("Unable to Find IE by URL", EventLogLevel.Brief);
                return false;
            }

            //if (PreviousIEMatch != _url)
            ////{
            //    if (browser != null)
            //        browser.Dispose();
            browser = Browser.AttachToNoWait<IE>(Find.ByUrl(urlRegex));
            browser.AutoClose = false;
                //PreviousIEMatch = _url;
            //}

            return true;
        }

        //private static Process m_Proc;
        public static bool CreateNewIE(string url)
        {
            OnAction("Unhooking brower");
            if (browser != null)
                browser.Dispose();

            OnAction("Creating brower");

            var mProc = Process.Start("IExplore.exe", url);
            if (mProc != null) mProc.Dispose();
            return true;
        }

        public static bool NavigateOrNewIE(string url, string title = "")
        {      
            if (FindIEByUrl(url))
            {
                new IETabActivator(browser).ActivateByTabsUrl(browser.Url);
                return true;
            }
            
            if (!String.IsNullOrEmpty(title))
            {
                if (FindIEByTitle(title))
                {
                    new IETabActivator(browser).ActivateByTabsUrl(browser.Url);
                    return true;
                }
            }
            EventLogger.LogNewEvent("Creating new IE window", EventLogLevel.Brief);
            if (CreateNewIE(url))
                return true;

            if (browser != null)
                browser.Dispose();
            return false;
        }

        /// <summary>
        /// Searches a system.
        /// </summary>
        public static bool AutoSearch(string search, string title, string url)
        {
            var activeWindowTitle = Regex.Match(WindowHelper.GetActiveWindowTitle(), @"(\w+)(?:\s-(?: Windows)? Internet Explorer)?", RegexOptions.IgnoreCase).Groups[1].Value;
            if (FindIEByTitle(title))
            {
                if (browser.Title == activeWindowTitle && Properties.Settings.Default.AutoSearchIgnoreActiveWindow)
                {
                    EventLogger.LogAndSaveNewEvent("Cancelling Search as Matched Window is Active Window.", EventLogLevel.Brief);
                    return false;
                }
                browser.GoToNoWait(search);
                EventLogger.LogNewEvent("Searching: "+ search, EventLogLevel.Brief);
                browser.Dispose();
                parent.AddAppEvent(AppEventTypes.AutoSearch);
                return true;
            }

            if (FindIEByUrl(url))
            {
                if (browser.Title == activeWindowTitle && Properties.Settings.Default.AutoSearchIgnoreActiveWindow)
                {
                    EventLogger.LogAndSaveNewEvent("Cancelling Search as Matched Window is Active Window.", EventLogLevel.Brief);
                    return false;
                }
                browser.GoToNoWait(search);
                EventLogger.LogNewEvent("Searching: " + search, EventLogLevel.Brief);
                browser.Dispose();
                parent.AddAppEvent(AppEventTypes.AutoSearch);
                return true;
            }

            if (Properties.Settings.Default.AutoSearchOpenNew)
            {
                CreateNewIE(search);
                EventLogger.LogNewEvent("Creating New and Searching: " + search, EventLogLevel.Brief);
                browser.Dispose();
                parent.AddAppEvent(AppEventTypes.AutoSearch);
                return true;
            }

            if (browser != null)
                browser.Dispose();
            return false;
        }
    }


}




















//if(new DigitPattern().IsMatch(text))
//            {
//                if (firstchar == "1" && textlen == 8)                       parent.SelectedContact.Fault.PR = text; 
//                else if ((firstchar == "0" && textlen == 10) 
//                     || (text.Substring(0, 2) == "61" && textlen == 11))
//                {
//                    if (CustomerContact.MobilePattern.IsMatch(text))        parent.SelectedContact.Mobile = "0" + text;
//                    else if (parent.SelectedContact.FindDNMatch(text)) Main.FadingToolTip.ShowandFade("DN: " + text);
//                    //else if (CustomerContact.DNPattern.IsMatch(text))
//                    //{
//                    //    parent.SelectedContact.DN = CustomerContact.DNPattern.Replace(text,"0$1$2$3");
//                    //    var query = (from a in Main.ServicesStore.servicesDataSet.States
//                    //                                            where a.Areacode == parent.SelectedContact.DN.Substring(1,1)
//                    //                                            select a).First();
//                    //    parent.SelectedContact.Address.State = query.NameShort;
//                    //    parent.SelectedContact.Service.Sip = query.Sip;
//                    //};
//                }
//                else if (CustomerContact.CMBSPattern.IsMatch(text)) 
//                { 
//                    parent.SelectedContact.CMBS = CustomerContact.CMBSPattern.Replace(text, "3$1$2 $3"); 
//                    var query = (from a in Main.ServicesStore.servicesDataSet.States
//                                                            where a.CMBScode == CustomerContact.CMBSPattern.Replace(text, "$1")
//                                                            select a).First();
//                    parent.SelectedContact.Address.State = query.NameShort;
//                    parent.SelectedContact.Service.Sip = query.Sip;
//                }
//                else if (CustomerContact.ICONPattern.IsMatch(text)) parent.SelectedContact.ICON = text;
//                else if (FaultModel.ITCasePattern.IsMatch(text)) parent.SelectedContact.Fault.ITCase = text;
//                else parent.SelectedContact.Note += Environment.NewLine + text;
//            }
//            else if (new AlphaPattern().IsMatch(text))
//            {
//                if (NameModel.Pattern.IsMatch(text))                        parent.SelectedContact.Name = text;
//                else if (CustomerContact.UNLowerPattern.IsMatch(text)
//                      || CustomerContact.UNLowerPattern.IsMatch(text))      parent.SelectedContact.Username = text;
//                else                                                        parent.SelectedContact.Note += text;
//            }
//            else
//            {
//                if (Char.IsLetter(text, 0))
//                {
//                    if (new BRASPattern().IsMatch(text))                    parent.SelectedContact.Service.Bras = text;
//                    else if (new CommonNBNPattern().IsMatch(text))          parent.SelectedContact.SetProperty("Service." + text.Substring(0, 3), text);
//                    else if (CustomerContact.UNLowerPattern.IsMatch(text)
//                        ||   CustomerContact.UNLowerPattern.IsMatch(text))  parent.SelectedContact.Username = text;
//                    else if (ContactAddress.Pattern.IsMatch(text))          parent.SelectedContact.Address.Address = text;
//                }
//                else
//                {
//                    if (new NodePattern().IsMatch(text))                    parent.SelectedContact.Service.Node = text;
//                    else if (CustomerContact.CMBSPattern.IsMatch(text))
//                    { 
//                        parent.SelectedContact.CMBS = CustomerContact.CMBSPattern.Replace(text, "3$1$2 $3"); 
//                        var query = (from a in Main.ServicesStore.servicesDataSet.States
//                                                                where a.CMBScode == CustomerContact.CMBSPattern.Replace(text, "$1")
//                                                                select a).First();
//                        parent.SelectedContact.Address.State = query.NameShort;
//                        parent.SelectedContact.Service.Sip = query.Sip;
//                    }
//                    else if (ContactAddress.Pattern.IsMatch(text))          parent.SelectedContact.Address.Address = text;
//                    else                                                    parent.SelectedContact.Note += text;
//                }    
//            }