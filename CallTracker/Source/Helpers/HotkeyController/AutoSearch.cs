using System;
using System.Text.RegularExpressions;
using System.Timers;

using WatiN.Core;
using SHDocVw;

using CallTracker.Model;

namespace CallTracker.Helpers
{
    public partial class HotkeyController
    {
        //WindowHelper.ShowWindow(browser.hWnd, WindowHelper.SW_SHOWNORMAL);
        //WindowHelper.SetForegroundWindow(browser.hWnd);
        //SendKeys.SendWait("^{t}");
        //FindIEByUrl("about:blank");

        /// <summary>
        /// Searches a system.
        /// </summary>
        public static bool AutoSearch(string search, string title, string url, bool titleFirst = true, string dataType = "")
        {
            var outcome = false;
            var activeWindowTitle = Regex.Match(WindowHelper.GetActiveWindowTitle(), @"(\w+)(?:\s-(?: Windows)? Internet Explorer)?", RegexOptions.IgnoreCase).Groups[1].Value;

            switch (title)
            {
                case "SCAMPS":
                    _scampsSearching = dataType;
                    if (_scampsTimer != null)
                        _scampsTimer.Stop();
                    else
                    {
                        _scampsTimer = new Timer(1000) { SynchronizingObject = parent };
                        _scampsTimer.Elapsed += ScampsTimerElapsed;
                    }
                    break;
                case "DIMPS":
                    _dimpsSearching = dataType;
                    if (_dimpsTimer != null)
                        _dimpsTimer.Stop();
                    else
                    {
                        _dimpsTimer = new Timer(1500) { SynchronizingObject = parent };
                        _dimpsTimer.Elapsed += DimpsTimerElapsed;
                    }
                    break;
                case "NSI":
                    _nsiSearching = dataType;
                    if (_nsiTimer != null)
                        _nsiTimer.Stop();
                    else
                    {
                        _nsiTimer = new Timer(2000) { SynchronizingObject = parent };
                        _nsiTimer.Elapsed += NsiTimerElapsed;
                    }
                    break;
            }

            if (titleFirst)
            {
                if (AutoSearchByTitle(search, title, activeWindowTitle))//, ref toBrowser))
                    outcome = true;
                else if (AutoSearchByUrl(search, url, activeWindowTitle))//, ref toBrowser))
                    outcome = true;
            }
            else
            {
                if (AutoSearchByUrl(search, url, activeWindowTitle))//, ref toBrowser))
                    outcome = true;
                else if (AutoSearchByTitle(search, title, activeWindowTitle))//, ref toBrowser))
                    outcome = true;
            }

            if (!outcome && Properties.Settings.Default.AutoSearchOpenNew)
            {
                CreateNewIE(search);
                AutoSearchByUrl(search, url, activeWindowTitle);//, ref toBrowser);
                EventLogger.LogNewEvent("Creating New and Searching: " + search, EventLogLevel.Brief);
                parent.AddAppEvent(AppEventTypes.AutoSearch);
                outcome = true;
            }

            if (!outcome) return false;

            switch (title)
            {
                case "SCAMPS":
                    EventLogger.LogNewEvent(Environment.NewLine + "SCAMPS AutoSearch Starting: " + search, EventLogLevel.Brief);
                    _scampsBrowser = browser;
                    _scampsSearchStarted = DateTime.Now;
                    _scampsTimer.Start();
                    break;
                case "DIMPS":
                    EventLogger.LogNewEvent(Environment.NewLine + "DIMPS AutoSearch Starting: " + search, EventLogLevel.Brief);
                    _dimpsBrowser = browser;
                    _dimpsSearchStarted = DateTime.Now;
                    _dimpsTimer.Start();
                    break;
                case "NSI":
                    EventLogger.LogNewEvent(Environment.NewLine + "NSI AutoSearch Starting: " + search, EventLogLevel.Brief);
                    _nsiBrowser = browser;
                    _nsiSearchStarted = DateTime.Now;
                    _nsiTimer.Start();
                    break;
                default:
                    if (browser != null)
                        browser.Dispose();
                    break;
            }
            return true;
        }







        private static bool AutoSearchByTitle(string search, string title, string activeWindowTitle)//, ref IE toBrowser)
        {
            if (!FindIEByTitle(title)) return false;

            if (browser.Title == activeWindowTitle && Properties.Settings.Default.AutoSearchIgnoreActiveWindow)
            {
                EventLogger.LogAndSaveNewEvent("Cancelling Search as Matched Window is Active Window.", EventLogLevel.Brief);
                return false;
            }
            EventLogger.LogNewEvent("Searching: " + search, EventLogLevel.Brief);

            if (browser.Title.Contains("IFMS"))
            {
                browser.GoTo(search);
                if (browser.Title.Contains("Error"))
                {
                    EventLogger.LogAndSaveNewEvent("IFMS Search return error.", EventLogLevel.Brief);
                    browser.Back();
                }
            }
            else
            {
                browser.GoToNoWait(search);
            }
            parent.AddAppEvent(AppEventTypes.AutoSearch);
            return true;
        }
        private static bool AutoSearchByUrl(string search, string url, string activeWindowTitle)//, ref IE toBrowser)
        {
            if (!FindIEByUrl(url)) return false;

            if (browser.Title == activeWindowTitle && Properties.Settings.Default.AutoSearchIgnoreActiveWindow)
            {
                EventLogger.LogAndSaveNewEvent("Cancelling Search as Matched Window is Active Window.", EventLogLevel.Brief);
                return false;
            }
            EventLogger.LogNewEvent("Searching: " + search, EventLogLevel.Brief);

            if (browser.Title.Contains("IFMS"))
            {
                browser.GoTo(search);
                if (browser.Title.Contains("Error"))
                {
                    EventLogger.LogAndSaveNewEvent("IFMS Search return error.", EventLogLevel.Brief);
                    browser.Back();
                }
            }
            else
            {
                browser.GoToNoWait(search);
            }

            browser.GoToNoWait(search);
            parent.AddAppEvent(AppEventTypes.AutoSearch);
            return true;
        }






        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get Data Methods /////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static string GetTableCell(IE fromBrowser, string id)
        {
            var cell = fromBrowser.ElementOfType<TableCell>(Find.ById(id));
            return cell.Exists ? cell.InnerHtml : null;
        }

        private static string GetHidden(IE fromBrowser, string id)
        {
            var hidden = fromBrowser.TextField(Find.ById(id));
            return hidden.Exists ? hidden.GetAttributeValue("value") : null;
        }

        private static string GetTextField(IE fromBrowser, string id)
        {
            var textfield = fromBrowser.TextField(Find.ById(id));
            return textfield.Exists ? textfield.GetAttributeValue("value") : null;
        }







        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // SCAMPS Search ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static Timer _scampsTimer;
        private static IE _scampsBrowser;
        private static String _scampsSearching;
        private static DateTime _scampsSearchStarted;

        private static void DisposeScampsBrowser()
        {
            if (_scampsTimer != null)
            {
                _scampsTimer.Dispose();
                _scampsTimer = null;
            }
            if (_scampsBrowser != null)
            {
                _scampsBrowser.Dispose();
                _scampsBrowser = null;
            }
        }
        private static void ScampsTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if ((e.SignalTime - _scampsSearchStarted).TotalSeconds > 10)
            {
                DisposeScampsBrowser();
                _scampsSearching = string.Empty;
                parent.SelectedContact.Service.WasSearched["SCAMPSDN"] = true;
                parent.SelectedContact.Service.WasSearched["SCAMPSUsername"] = true;
                EventLogger.LogAndSaveNewEvent("AutoSearching SCAMPS " + _scampsSearching + " Error: Timeout", EventLogLevel.Brief);
                return;
            }

            if (_scampsBrowser == null)
            {
                FindIEByUrl("https://scamps.optusnet.com.au", ref _scampsBrowser);
                if (_scampsBrowser == null)
                    return;
            }
            var ieBrowser = ((IWebBrowser2)(_scampsBrowser.InternetExplorer));
            if (ieBrowser.Busy) return;

            var contact = parent.SelectedContact;

            if (_scampsBrowser.Title.Contains("Message"))
            {
                switch (_scampsSearching)
                {
                    case "DN":
                        if (contact.Service.WasSearched["DIMPSDN"] &&
                            contact.Fault.AffectedServiceType.IsNot(ServiceTypes.NFV))
                            contact.Fault.LAT = true;
                        contact.Service.WasSearched["SCAMPSDN"] = true;
                        break;
                    case "Username":
                        contact.Service.WasSearched["SCAMPSUsername"] = true;
                        break;
                }
                _scampsBrowser.GoToNoWait("https://scamps.optusnet.com.au");
            }
            else
            {
                switch (_scampsSearching)
                {
                    case "DN":
                        contact.Fault.LIP = true;
                        break;
                    case "Username":
                        contact.Fault.ONC = true;
                        break;
                }
                contact.Service.WasSearched["SCAMPSDN"] = true;
                contact.Service.WasSearched["SCAMPSUsername"] = true;
            }

            _scampsBrowser.Dispose();
            _scampsBrowser = null;
            _scampsTimer.Dispose();
            _scampsTimer = null;
            _scampsSearching = null;
        }








        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // DIMPS Search /////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static Timer _dimpsTimer;
        private static IE _dimpsBrowser;
        private static String _dimpsSearching;
        private static DateTime _dimpsSearchStarted;

        private static void DisposeDimpsBrowser()
        {
            if (_dimpsTimer != null)
            {
                _dimpsTimer.Dispose();
                _dimpsTimer = null;
            }
            if (_dimpsBrowser != null)
            {
                _dimpsBrowser.Dispose();
                _dimpsBrowser = null;
            }
        }
        private static void DimpsTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if ((e.SignalTime - _dimpsSearchStarted).TotalSeconds > 10)
            {
                DisposeDimpsBrowser();
                _dimpsSearching = string.Empty;
                parent.SelectedContact.Service.WasSearched["DIMPSDN"] = true;
                parent.SelectedContact.Service.WasSearched["DIMPSUsername"] = true;
                EventLogger.LogAndSaveNewEvent("AutoSearching DIMPS " + _dimpsSearching + " Error: Timeout", EventLogLevel.Brief);
                return;
            }

            if (_dimpsBrowser == null)
            {
                FindIEByUrl("https://dimps.optusnet.com.au", ref _dimpsBrowser);
                if (_dimpsBrowser == null)
                    return;
            }
            var ieBrowser = ((IWebBrowser2)(_dimpsBrowser.InternetExplorer));
            if (ieBrowser.Busy) return;

            var contact = parent.SelectedContact;

            //try
            //{
                if (_dimpsBrowser.Url == "https://dimps.optusnet.com.au/search.html")
                {
                    switch (_dimpsSearching)
                    {
                        case "DN":
                            if (contact.Service.WasSearched["SCAMPSDN"] &&
                                contact.Fault.AffectedServiceType.IsNot(ServiceTypes.LIP))
                                contact.Fault.LAT = true;
                            contact.Service.WasSearched["DIMPSDN"] = true;
                            break;
                        case "Username":
                            contact.Service.WasSearched["DIMPSUsername"] = true;
                            break;
                    }
                }
                else
                {
                    var mode = GetHidden(_dimpsBrowser, "init_mode");
                    var value = GetTableCell(_dimpsBrowser, "username");
                    EventLogger.LogAndSaveNewEvent("AutoSearching DIMPS " + _dimpsSearching + " Mode: " + mode,
                        EventLogLevel.Brief);
                    // Assuming only services with a username are found in DIMPS.
                    switch (mode)
                    {
                        case "cable":
                            contact.Service.WasSearched["DIMPSUsername"] = true;
                            contact.Fault.ONC = true;
                            if (_dimpsSearching != "DN") break;
                            contact.Service.WasSearched["DIMPSDN"] = true;
                            contact.Fault.LIP = true;
                            contact.Username = value;
                            break;
                        case "fbb":
                            contact.Service.WasSearched["SCAMPSUsername"] = true;
                            contact.Service.WasSearched["SCAMPSDN"] = true;
                            contact.Service.WasSearched["DIMPSUsername"] = true;
                            contact.Fault.NBF = true;
                            if (_dimpsSearching != "DN") break;
                            contact.Service.WasSearched["DIMPSDN"] = true;
                            contact.Fault.NFV = true;
                            contact.Username = value;
                            break;
                    }

                    value = GetTableCell(_dimpsBrowser, "custname");
                    if (value != null)
                        contact.Name = value;

                    value = GetTableCell(_dimpsBrowser, "servaddr");
                    if (value != null)
                        contact.Address.Address = value;

                    value = GetTableCell(_dimpsBrowser, "macidvendor");
                    if (value != null)
                    {
                        var split = value.Split('/');
                        contact.Service.FindMACMatch(split[0]);
                        if (split.Length > 1)
                            contact.Service.FindEquipmentMatch(
                                parent.editContact._ServicePanel._Equipment._ComboBox.GetDataSource, split[1]);
                    }

                    value = GetTableCell(_dimpsBrowser, "ipaddr");
                    if (value != null)
                        contact.Service.FindIPMatch(value);

                    value = GetTableCell(_dimpsBrowser, "isonline");
                    if (value != null)
                        contact.Service.ModemStatus = value == "Yes" ? "Online" : "Offline";

                    value = GetTableCell(_dimpsBrowser, "throttlingstatus");
                    if (value != null)
                        contact.Service.Throttled = value;

                    if (mode == "fbb")
                    {
                        value = GetTableCell(_dimpsBrowser, "accountno");
                        if (value != null)
                            contact.FindICONMatch(value);

                        value = GetTableCell(_dimpsBrowser, "bras");
                        if (value != null)
                            contact.Service.Bras = value;

                        value = GetTableCell(_dimpsBrowser, "avcid");
                        if (value != null)
                            contact.Service.FindNBNMatch(value);
                    }
                    else
                    {
                        value = GetTableCell(_dimpsBrowser, "accountno");
                        if (value != null)
                            contact.FindCMBSMatch(value);
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    EventLogger.LogAndSaveNewEvent("AutoSearching DIMPS " + _dimpsSearching + " Error: " + ex.Message, EventLogLevel.Status);
            //}

            _dimpsBrowser.Dispose();
            _dimpsBrowser = null;
            _dimpsTimer.Dispose();
            _dimpsTimer = null;
            _dimpsSearching = null;
        }







        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // SCAMPS Search ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static Timer _nsiTimer;
        private static IE _nsiBrowser;
        private static DateTime _nsiSearchStarted;
        private static String _nsiSearching;

        private static void DisposeNsiBrowser()
        {
            if (_nsiTimer != null)
            {
                _nsiTimer.Dispose();
                _nsiTimer = null;
            }
            if (_nsiBrowser != null)
            {
                _nsiBrowser.Dispose();
                _nsiBrowser = null;
            }
        }
        private static void NsiTimerElapsed(object sender, ElapsedEventArgs e)
        {
            parent.SelectedContact.Service.WasSearched["NSI"] = true;
            if ((e.SignalTime - _nsiSearchStarted).TotalSeconds > 60)
            {
                DisposeNsiBrowser();
                _nsiSearching = null;
                EventLogger.LogAndSaveNewEvent("AutoSearching NSI "+ _nsiSearching +" Error: Timeout", EventLogLevel.Brief);
                return;
            }

            if (_nsiBrowser == null)
            {
                FindIEByUrl("https://staff.optusnet.com.au/tools/nsi/", ref _nsiBrowser);
                if (_nsiBrowser == null)
                    return;
            }
            var ieBrowser = ((IWebBrowser2)(_nsiBrowser.InternetExplorer));
            if (ieBrowser.Busy) return;

            var contact = parent.SelectedContact;

            //try
            //{
                if (_nsiSearching == "AVC")
                {
                    EventLogger.LogNewEvent("AutoSearching: NSI AVC", EventLogLevel.Brief);
                    string value;

                    value = GetHidden(_nsiBrowser, "cvcid");
                    if (value != null)
                        contact.Service.CVC = value;

                    value = GetHidden(_nsiBrowser, "gsid");
                    if (value != null)
                        contact.Service.GSID = value;

                    value = GetTableCell(_nsiBrowser, "pii");
                    if (value != null)
                        contact.Service.PRI = value;

                    //parent.SelectedContact.Service.WasSearched["NSI"] = true;
                    _nsiSearchStarted = DateTime.Now;
                    _nsiSearching = "CVC";
                    _nsiBrowser.GoToNoWait("https://staff.optusnet.com.au/tools/nsi/cvc_detail.html?cvcid=" +
                                           contact.Service.CVC);
                }
                else if (_nsiSearching == "CVC")
                {
                    EventLogger.LogNewEvent("AutoSearching: NSI CVC", EventLogLevel.Brief);
                    var top_col = _nsiBrowser.Div(Find.ByClass("top_col")).InnerHtml.Split(':');
                    contact.Service.CSA = top_col[1].Substring(5, 15);
                    contact.Service.NNI = top_col[4].Substring(5, 15);

                    _nsiBrowser.Back();

                    _nsiBrowser.Dispose();
                    _nsiBrowser = null;
                    _nsiTimer.Dispose();
                    _nsiTimer = null;
                    _nsiSearching = null;
                }
            //}
            //catch (Exception ex)
            //{
            //    EventLogger.LogAndSaveNewEvent("AutoSearching NSI " + _nsiSearching + " Error: " + ex.Message,
            //        EventLogLevel.Status);
            //}
            EventLogger.SaveLog();
        }
    }
}
