using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.ComponentModel;
using Shortcut;

using WatiN.Core;

using CallTracker.View;
using CallTracker.Model;
using Utilities.RegularExpressions;

namespace CallTracker.Helpers
{
    public delegate void ActionEventHandler(string _event, EventLogLevel _logLevel = EventLogLevel.Verbose);

    public class HotkeyController : IDisposable
    {
        // HotkeyController Methods:
            // HotKey Methods:
                // private void OnGridLinks(HotkeyPressedEventArgs e)
                // private void OnDataPaste(HotkeyPressedEventArgs e)
                // private void OnSmartPaste(HotkeyPressedEventArgs e)
                // private void OnBindSmartPaste(HotkeyPressedEventArgs e)
                // private void OnAutoFill(HotkeyPressedEventArgs e)
                // private void OnAutoLogin(HotkeyPressedEventArgs e)
                // private void OnSmartCopy(HotkeyPressedEventArgs e)
            // Browser Methods:
                // private bool FindIEByHWND(IntPtr _HWND)
                // private bool FindIEByTitle(string _title)
            // Object Methods:
                // public static string FollowPropertyPath(object value, string path)
                // public static string FollowPropertyPath(object value, string path, string altPath)
        private static Main parent;
        public static IE browser;
        //public static string PreviousIEMatch;
        private static HotKeyManager HotKeyManager;
        private static PropertyDescriptorCollection props;

        public static event ActionEventHandler OnAction;
        
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
                HotKeyManager.AddOrReplaceHotkey(GridLinkHotKey.Value, Modifiers.Win, GridLinkHotKey.Key, OnGridLinks);

            Settings.Instance.AutoMoveMousePointerToTopLeft = false;
            Settings.Instance.AutoCloseDialogs = false;
            Settings.Instance.AttachToBrowserTimeOut = 3;
            Settings.Instance.WaitForCompleteTimeOut = 3;
            Settings.Instance.WaitUntilExistsTimeOut = 3;

            props = TypeDescriptor.GetProperties(parent.SelectedContact.Service);

            //bgw.DoWork += bgw_DoWork;
            //bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
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
        private Dictionary<Keys, string> GridLinkHotkeys = new Dictionary<Keys, string>()
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
            SystemItem systemItem = parent.UserDataStore.GridLinks.GetSystemItem(Convert.ToInt32(e.Name));
            parent.SetProgressBarStep(4, String.Format("Switching to: {0}", systemItem.Url), EventLogLevel.Verbose);

            try
            {
                if (systemItem.System == "MAD" || systemItem.System == "OPOM")
                {
                    IntPtr hWnd = IntPtr.Zero;
                    hWnd = WindowHelper.FindHWNDByTitle(systemItem.Title);
                    if (hWnd != IntPtr.Zero)
                    {
                        WindowHelper.ShowWindow(hWnd, WindowHelper.SW_RESTORE);
                        WindowHelper.SetForegroundWindow(hWnd);
                    }
                }
                else if (NavigateOrNewIE(systemItem.Url, systemItem.Title))
                {
                    if (Browser.Exists<IE>(Find.ByTitle(systemItem.Title)))
                        WindowHelper.ShowWindow(browser.hWnd, WindowHelper.SW_RESTORE);
                    AutoLogin();
                }
            }
            finally
            {
                parent.UpdateProgressBar(0, String.Format("Switched to: {0}", systemItem.Url), EventLogLevel.ClearStatus);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Data Paste ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private Dictionary<Keys, string> DataPasteHotkeys = new Dictionary<Keys, string>()
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
            EventLogger.LogNewEvent(String.Format("Pasting: {0}", e.Name), EventLogLevel.Brief);
            string dataToPaste = FindProperty.FollowPropertyPath(parent.SelectedContact, e.Name);

            if (!String.IsNullOrEmpty(dataToPaste))
            {
                Clipboard.SetText(dataToPaste);
                SendKeys.SendWait("+^");
                SendKeys.SendWait("^v");
                Application.DoEvents();
                SendKeys.Flush();
            } 
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        // Smart Paste ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void OnSmartPaste(HotkeyPressedEventArgs e)
        {
            EventLogger.LogNewEvent("Searching for SmartPaste Matches", EventLogLevel.Brief);
            if (WindowHelper.GetActiveWindowTitle().Contains("Oracle Forms Runtime"))
            {
                string activeelem = MadSmartPaste.GetActiveElement();
                if (String.IsNullOrEmpty(activeelem))
                {
                    EventLogger.LogNewEvent("No Active Element Found", EventLogLevel.Status);
                    return;
                }

                var propvalue = FindProperty.FollowPropertyPath(parent.SelectedContact, activeelem);

                EventLogger.LogNewEvent("Trying to set value", EventLogLevel.Status);
                MadSmartPaste.SetElementValue(propvalue);

                //EventLogger.LogNewEvent("Trying to Set Text", EventLogLevel.Status);
                //MadSmartPaste.SetElementText(propvalue);
                
                //EventLogger.LogNewEvent("Ctrl-V in MAD value", EventLogLevel.Status);
                //Clipboard.SetText(propvalue);
                //SendKeys.SendWait("+^");
                //SendKeys.SendWait("^v");
                //Application.DoEvents();
                //SendKeys.Flush();  
            }
            else
            {
                if (!FindBrowser())
                    return;

                var url = browser.Url;
                var title = browser.Title;
                var element = browser.ActiveElement.IdOrName;

                PasteBind query = (from
                                       bind in parent.UserDataStore.PasteBinds
                                   where
                                       bind.Element == element &&
                                       (url.Contains(bind.Url) ||
                                        title.Contains(bind.Title))
                                   select
                                       bind)
                                   .FirstOrDefault();

                if (query != null)
                {
                    query.Paste(browser, element, FindProperty.FollowPropertyPath(parent.SelectedContact, new[]{query.Data, query.AltData}));
                    EventLogger.LogNewEvent("Match Found");
                }

                browser.Dispose();
            }
        }

        private static void OnBindSmartPaste(HotkeyPressedEventArgs e)
        {
            EventLogger.LogNewEvent("Searching for matching binds", EventLogLevel.Brief);
            if (!FindBrowser())
                return;

            string url = browser.Url;
            string title = browser.Title;
            string element = browser.ActiveElement.IdOrName;

            //Console.WriteLine(browser.ActiveElement.GetAttributeValue("type"));

            if(String.IsNullOrEmpty(element))
            {
                WindowHelper.SetForegroundWindow(parent.Handle);
                EventLogger.LogNewEvent("Unable to bind: Unable to find element name or id");
                return;
            }

            var urlOrTitleMatches =  from
                                        bind in parent.UserDataStore.PasteBinds
                                     where
                                        url.Contains(bind.Url) ||
                                        title.Contains(bind.Title)
                                     select
                                        bind;

            PasteBind ElementMatch = urlOrTitleMatches.FirstOrDefault(bind => bind.Element == element);

            if (ElementMatch == null)
            {
                var system = urlOrTitleMatches.Any() ? urlOrTitleMatches.FirstOrDefault().System : String.Empty;
                ElementMatch = new PasteBind(system, url, title, browser.ActiveElement);
                parent.UserDataStore.PasteBinds.Add(ElementMatch);
                EventLogger.LogNewEvent("New Bind Created");
            }

            parent.editSmartPasteBinds.SelectQuery(ElementMatch);
            Main.ShowPopupForm<BindSmartPasteForm>().SelectQuery(ElementMatch);

            browser.Dispose();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // AutoFill /////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void OnAutoFill(HotkeyPressedEventArgs e)
        {
            EventLogger.LogNewEvent("Searching for AutoFill Matches", EventLogLevel.Brief);
            if (!FindBrowser())
                return;

            string url = browser.Url;
            string title = browser.Title;

            var query = from
                            bind in parent.UserDataStore.PasteBinds
                        where
                            url.Contains(bind.Url) ||
                            title.Contains(bind.Title)
                        select
                            bind;

            if (query != null)
            {
                EventLogger.LogNewEvent(String.Format("{0} found.", query.Count()));
                foreach (PasteBind bind in query)
                    bind.Paste(browser, bind.Element, FindProperty.FollowPropertyPath(parent.SelectedContact, new[] { bind.Data, bind.AltData }));
            }
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
            if (!FindBrowser())
                return;

            string title = browser.Title;
            string url = browser.Url;

            LoginsModel query = (from
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

            query.Paste(browser, query.UsernameElement, query.Username);
            query.Paste(browser, query.PasswordElement, query.Password);
            query.Submit(browser);
            //PreviousIEMatch = browser.Title;

            browser.Dispose();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Smart Copy ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static readonly Stopwatch Stopwatch = new Stopwatch();
        private static void OnSmartCopy(HotkeyPressedEventArgs e)
        {
            EventLogger.LogNewEvent("Starting Smart Copy", EventLogLevel.Brief);

            var oldClip = Clipboard.GetText();
            Clipboard.Clear();
            SendKeys.SendWait("^c");
            SendKeys.Flush();

            Stopwatch.Start();
            while (!Clipboard.ContainsText())
            {
                SendKeys.Flush();
                if (Stopwatch.ElapsedMilliseconds > 1000)
                    break;
            }
            var text = Clipboard.GetText().Trim();
            EventLogger.LogNewEvent(String.Format("{0} copied from the clipboard in {1}ticks", text, Stopwatch.ElapsedTicks));
            if (!String.IsNullOrEmpty(oldClip))
                Clipboard.SetText(oldClip);
            Stopwatch.Reset();

            var textlen = text.Length;
            if (textlen == 0)
            {
                Main.FadingToolTip.ShowandFade("Nothing selected");
                return;
            }
            var firstchar = text.Substring(0, 1);

            var contact = parent.SelectedContact;
            
            // If text is all digits ////////////////////////////////////////////////////////////////////////////////
            if(new DigitPattern().IsMatch(text))
            {
                if (firstchar == "1" && textlen == 8)
                {
                    contact.Fault.PR = text;
                    Main.FadingToolTip.ShowandFade("PR: " + contact.Fault.PR);
                    return;
                } 
                if (contact.FindMobileMatch(text)) return;
                if (contact.FindDNMatch(text)) return;
                if (contact.FindCMBSMatch(text)) return;
                if (contact.FindICONMatch(text)) return;
                if (contact.Fault.FindITCaseMatch(text)) return;
            } 
            else if (new AlphaPattern().IsMatch(text))
            {
                if (contact.FindNameMatch(text)) return;
                if (contact.FindUsernameMatch(text)) return;
            } 
            else if (Char.IsLetter(text, 0))
            {
                if (contact.Service.FindBRASMatch(text)) return;
                if (contact.Service.FindNBNMatch(text)) return;
                if (contact.FindUsernameMatch(text)) return;
                if (contact.Address.FindAddressMatch(text)) return;
            }
            else
            {
                if (contact.Service.FindNodeMatch(text)) return;
                if (contact.FindCMBSMatch(text)) return;
                if (contact.Address.FindAddressMatch(text)) return;
            }

            contact.Note += text;
            Main.FadingToolTip.ShowandFade("Added to Note");   
        }








        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        // System Search /////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void SearchSystem(string _url, string _searchValue, string _searchElement, string _submitElement = "")
        {
            EventLogger.LogNewEvent("Searching System", EventLogLevel.Brief);

            if (!FindIEByUrl(_url))
                NavigateOrNewIE(_url);

            // Fill Search field ////////////////////////////////////////////////////////
            PasteBind query = (from
                                    bind in parent.UserDataStore.PasteBinds
                                where
                                    bind.Element == _searchElement &&
                                    (_url.Contains(bind.Url))
                                select
                                    bind)
                                .FirstOrDefault();

            if (query != null)
            {
                EventLogger.LogNewEvent("Element Match Found");
                query.Paste(browser, _searchElement, _searchValue);        
            };

            // Click Submit /////////////////////////////////////////////////////////////
            if (!String.IsNullOrEmpty(_submitElement))
            {
                query = (from bind in parent.UserDataStore.PasteBinds
                        where
                            bind.Element == _submitElement &&
                            (_url.Contains(bind.Url))
                        select
                            bind)
                        .FirstOrDefault();
                
                if (query != null)
                {
                    EventLogger.LogNewEvent("Button Match Found");
                    query.Paste(browser, _submitElement, "");
                }
            }

            browser.Dispose();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Browser Methods //////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static bool FindBrowser()
        {
            string title = WindowHelper.GetActiveWindowTitle();
            if (!FindIEByTitle(title))
            {
                EventLogger.LogNewEvent(String.Format("Unable to find page by title: {0}", title));

                IntPtr hwnd = WindowHelper.GetActiveWindowHWND();
                if (!FindIEByHWND(hwnd))
                {
                    EventLogger.LogNewEvent(String.Format("Unable to find page by HWND: {0}", hwnd.ToString()));
                    return false;
                }
            }
            return true;
        }

        public static bool FindIEByHWND(IntPtr _HWND)
        {
            string currentHWND = _HWND.ToString();

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

        public static bool FindIEByTitle(string _title)
        {
            string currentTitle = Regex.Match(_title, @"(?:http://[\w\./]+ - )?(\w+)(?:\s-(?: Windows)? Internet Explorer)?").Groups[1].Value;


            if (!Browser.Exists<IE>(Find.ByTitle(currentTitle)))
                return false;

            //if (PreviousIEMatch != currentTitle)
            //{
                //if (browser != null)
                //    browser.Dispose();
                browser = Browser.AttachTo<IE>(Find.ByTitle(currentTitle));
                browser.AutoClose = false;
                //PreviousIEMatch = currentTitle;
            //}

            return true;
        }

        public static bool FindIEByUrl(string _url)
        {
            if (!Browser.Exists<IE>(Find.ByUrl(new Regex("(http(s)?://)?.*" + _url + ".*", RegexOptions.IgnoreCase))))
                return false;

            //if (PreviousIEMatch != _url)
            ////{
            //    if (browser != null)
            //        browser.Dispose();
                browser = Browser.AttachTo<IE>(Find.ByUrl(new Regex("(http(s)?://)?.*" + _url + ".*", RegexOptions.IgnoreCase)));
                browser.AutoClose = false;
                //PreviousIEMatch = _url;
            //}

            return true;
        }

        //private static Process m_Proc;
        public static bool CreateNewIE(string _url)
        {
            OnAction("Unhooking brower");
            if (browser != null)
                browser.Dispose();

            OnAction("Creating brower");

            Process m_Proc = System.Diagnostics.Process.Start("IExplore.exe", _url);
            m_Proc.Dispose();
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

            if (CreateNewIE(url))
                return true;

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