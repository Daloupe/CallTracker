using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;

using Shortcut;
using WatiN.Core;
//using WatiN.Core.Constraints;
//using WatiN.Core.Interfaces;
//using SHDocVw;

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

        public Stopwatch sw = new Stopwatch();

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
        private void OnTest(HotkeyPressedEventArgs e)
        {
           //Console.WriteLine(WindowHelper.GetActiveWindowTitle());
           ICONAutoFill.Go(parent);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // ARO //////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void OnAddARO(HotkeyPressedEventArgs e)
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

        private void OnGridLinks(HotkeyPressedEventArgs e)
        {
            SystemItem systemItem = parent.DataStore.GridLinks.GetSystemItem(Convert.ToInt32(e.Name));
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
                else
                    if (NavigateOrNewIE(systemItem.Title, systemItem.Url))
                        AutoLogin();   
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

        private void OnDataPaste(HotkeyPressedEventArgs e)
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
        private void OnSmartPaste(HotkeyPressedEventArgs e)
        {
            EventLogger.LogNewEvent("Searching for SmartPaste Matches", EventLogLevel.Brief);
            if (!FindBrowser())
                return;

            string url = browser.Url;
            string title = browser.Title;
            string element = browser.ActiveElement.IdOrName;

            PasteBind query = (from   
                                   bind in parent.DataStore.PasteBinds
                               where  
                                   bind.Element == element &&
                                   (url.Contains(bind.Url) || 
                                    title.Contains(bind.Title))
                               select 
                                   bind)
                               .FirstOrDefault();

            if (query != null)
            {
                query.Paste(browser, element, FindProperty.FollowPropertyPath(parent.SelectedContact, query.Data, query.AltData));
                EventLogger.LogNewEvent("Match Found");
            }

            browser.Dispose();
        }

        private void OnBindSmartPaste(HotkeyPressedEventArgs e)
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

            var UrlOrTitleMatches =  from
                                        bind in parent.DataStore.PasteBinds
                                     where
                                        url.Contains(bind.Url) ||
                                        title.Contains(bind.Title)
                                     select
                                        bind;

            PasteBind ElementMatch = UrlOrTitleMatches.FirstOrDefault(bind => bind.Element == element);

            if (ElementMatch == null)
            {
                string system = UrlOrTitleMatches.Count() > 0 ? UrlOrTitleMatches.ElementAtOrDefault(0).System : String.Empty;
                ElementMatch = new PasteBind(system, url, title, browser.ActiveElement);
                parent.DataStore.PasteBinds.Add(ElementMatch);
                EventLogger.LogNewEvent("New Bind Created");
            }

            parent.editSmartPasteBinds.SelectQuery(ElementMatch);
            Main.ShowPopupForm<BindSmartPasteForm>().SelectQuery(ElementMatch);

            browser.Dispose();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // AutoFill /////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void OnAutoFill(HotkeyPressedEventArgs e)
        {
            EventLogger.LogNewEvent("Searching for AutoFill Matches", EventLogLevel.Brief);
            if (!FindBrowser())
                return;

            string url = browser.Url;
            string title = browser.Title;

            var query = from
                            bind in parent.DataStore.PasteBinds
                        where
                            url.Contains(bind.Url) ||
                            title.Contains(bind.Title)
                        select
                            bind;

            if (query != null)
            {
                EventLogger.LogNewEvent(String.Format("{0} found.", query.Count()));
                foreach (PasteBind bind in query)
                    bind.Paste(browser, bind.Element, FindProperty.FollowPropertyPath(parent.SelectedContact, bind.Data, bind.AltData));
            }
            if (browser.Url.Contains("http://ifmsprod.optus.com.au/IFMSWeb1P/PR%20Manage/F001_CreatePR"))
                IFMSAutoFill.Go(parent);
            if (browser.Url.Contains("http://icon.optus.com.au/icon/Activity/NewActivity.aspx"))
                ICONAutoFill.Go(parent);

            //PreviousIEMatch = browser.Title;
            browser.Dispose();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Auto Login ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void OnAutoLogin(HotkeyPressedEventArgs e)
        {
            parent.SetProgressBarStep(2, "Attempting Autologin", EventLogLevel.Brief);
            AutoLogin();
            parent.UpdateProgressBar(0, "Finished Autologin", EventLogLevel.ClearStatus);
        }

        private void AutoLogin()
        {
            OnAction("Searching for matches");
            if (!FindBrowser())
                return;

            string title = browser.Title;
            string url = browser.Url;

            LoginsModel query = (from
                                     login in parent.DataStore.Logins
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
        private void OnSmartCopy(HotkeyPressedEventArgs e)
        {
            //string oldClip = Clipboard.GetText();
            EventLogger.LogNewEvent("Starting Smart Copy", EventLogLevel.Brief);
            SendKeys.SendWait("^c");
            Application.DoEvents();
            SendKeys.Flush();
            string text = Clipboard.GetText().Trim();
            EventLogger.LogNewEvent(String.Format("{0} copied from the clipboard.", text));
            int textlen = text.Length;
            if (textlen == 0)
                return;
            string firstchar = text.Substring(0, 1);

            
            
            if(new DigitPattern().IsMatch(text))
            {
                if (firstchar == "1" && textlen == 8)                       parent.SelectedContact.Fault.PR = text; 
                else if ((firstchar == "0" && textlen == 10) 
                     || (text.Substring(0, 2) == "61" && textlen == 11))
                {
                    if (CustomerContact.MobilePattern.IsMatch(text))        parent.SelectedContact.Mobile = text;
                    else if (CustomerContact.DNPattern.IsMatch(text))
                    {
                        parent.SelectedContact.DN = CustomerContact.DNPattern.Replace(text,"0$1$2$3");
                        parent.SelectedContact.Address.State = (from a in Main.ServicesStore.servicesDataSet.States
                                                                where a.Areacode == parent.SelectedContact.DN.Substring(1,1)
                                                                select a).First().NameShort; 
                    };
                }
                else if (CustomerContact.CMBSPattern.IsMatch(text)) 
                { 
                    parent.SelectedContact.CMBS = CustomerContact.CMBSPattern.Replace(text, "3$1$2 $3"); 
                    parent.SelectedContact.Address.State = (from a in Main.ServicesStore.servicesDataSet.States
                                                            where a.CMBScode == CustomerContact.CMBSPattern.Replace(text, "$1")
                                                            select a).First().NameShort; 
                }
                else if (CustomerContact.ICONPattern.IsMatch(text)) parent.SelectedContact.ICON = text;
                else if (FaultModel.ITCasePattern.IsMatch(text)) parent.SelectedContact.Fault.ITCase = text;
                else parent.SelectedContact.Note += text;
            }
            else if (new AlphaPattern().IsMatch(text))
            {
                if (NameModel.Pattern.IsMatch(text))                        parent.SelectedContact.Name = text;
                else if (CustomerContact.UNLowerPattern.IsMatch(text)
                      || CustomerContact.UNLowerPattern.IsMatch(text))      parent.SelectedContact.Username = text;
                else                                                        parent.SelectedContact.Note += text;
            }
            else
            {
                if (Char.IsLetter(text, 0))
                {
                    if (new BRASPattern().IsMatch(text))                    parent.SelectedContact.Service.Bras = text;
                    else if (new CommonNBNPattern().IsMatch(text))          parent.SelectedContact.SetProperty("Service." + text.Substring(0, 3), text);
                    else if (CustomerContact.UNLowerPattern.IsMatch(text)
                        ||   CustomerContact.UNLowerPattern.IsMatch(text))  parent.SelectedContact.Username = text;
                    else if (ContactAddress.Pattern.IsMatch(text))          parent.SelectedContact.Address.Address = text;
                }
                else
                {
                    if (new NodePattern().IsMatch(text))                    parent.SelectedContact.Service.Node = text;
                    else if (CustomerContact.CMBSPattern.IsMatch(text))     parent.SelectedContact.CMBS = CustomerContact.CMBSPattern.Replace(text, "3$1$2 $3");
                    else if (ContactAddress.Pattern.IsMatch(text))          parent.SelectedContact.Address.Address = text;
                    else                                                    parent.SelectedContact.Note += text;
                }    
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Browser Methods //////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool FindBrowser()
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
                browser = Browser.AttachToNoWait<IE>(Find.By("hwnd", currentHWND));
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
                browser = Browser.AttachToNoWait<IE>(Find.ByTitle(currentTitle));
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
                browser = Browser.AttachToNoWait<IE>(Find.ByUrl(new Regex("(http(s)?://)?.*" + _url + ".*", RegexOptions.IgnoreCase)));
                browser.AutoClose = false;
                //PreviousIEMatch = _url;
            //}

            return true;
        }

        //private static Process m_Proc;
        public static bool CreateNewIE(string _url, string _title)
        {
            OnAction("Unhooking brower");
            if (browser != null)
                browser.Dispose();

            OnAction("Creating brower");

            Process m_Proc = System.Diagnostics.Process.Start("IExplore.exe", _url);
            m_Proc.Dispose();
            //m_Proc.EnableRaisingEvents = true;
            //m_Proc.Exited += m_Proc_Exited;
            return true;
            //using (Process m_Proc = System.Diagnostics.Process.Start("IExplore.exe", _url))
            //{
            //    try
            //    {
            //        browser = Browser.AttachTo<IE>(Find.ByUrl(_url)); //new IE(_url);//
            //        browser.AutoClose = false;
            //        //PreviousIEMatch = _title;
            //        return true;
            //    }
            //    catch (WatiN.Core.Exceptions.TimeoutException)
            //    {
            //        return false; 
            //    }
            //}
        }

        //static void m_Proc_Exited(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Exited");
        //}

        public static bool NavigateOrNewIE(string title, string url)
        {
            if (FindIEByTitle(title))
            {
                new IETabActivator(browser).ActivateByTabsUrl(browser.Url);
                if (browser.Url == url)
                    return true;
            }
            else
            {
                if (CreateNewIE(url, title))
                    return true;
            }

            if (browser != null)
                browser.Dispose();
            return false;
        }
    }

}
