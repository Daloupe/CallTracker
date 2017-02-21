using CallTracker.Model;
using CallTracker.View;
using SHDocVw;
using Shortcut;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WatiN.Core;
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
            HotKeyManager.AddOrReplaceHotkey("BindSmartPaste", Modifiers.Alt | Modifiers.Control, Keys.V, OnBindSmartPaste); //Modifiers.Win
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

            DisposeScampsBrowser();
            DisposeDimpsBrowser();
            DisposeNsiBrowser();
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
        // ARO //////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void OnAddARO(HotkeyPressedEventArgs e)
        {
            Main.ShowPopupForm<AddAROForm>();
        }

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

            if (FindIEByUrl(url) || (!String.IsNullOrEmpty(title) && FindIEByTitle(title)))
            {
                //browser.ShowWindow(NativeMethods.WindowShowStyle.Restore);
                new IETabActivator(browser.hWnd).ActivateByTabsUrl(browser.Url);
                WindowHelper.ShowWindow(browser.hWnd, WindowHelper.SW_RESTORE);
                WindowHelper.SetForegroundWindow(browser.hWnd);
                if (!String.IsNullOrEmpty(searchUrl))
                {
                    EventLogger.LogNewEvent("NavigateOrNewIE: navigating to URL: " + searchUrl);
                    browser.GoToNoWait(searchUrl);
                }
                return true;
            }else{
                EventLogger.LogNewEvent("NavigateOrNewIE: Creating new IE window", EventLogLevel.Brief);
                if (CreateNewIE(searchUrl != "" ? searchUrl : url))
                    return true;
            }

            return false;
        }
    }
}