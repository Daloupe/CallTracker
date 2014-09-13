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
                        _dimpsTimer = new Timer(1000) { SynchronizingObject = parent };
                        _dimpsTimer.Elapsed += DimpsTimerElapsed;
                    }
                    break;
                case "NSI":
                    if (_nsiTimer != null)
                        _nsiTimer.Stop();
                    else
                    {
                        _nsiTimer = new Timer(1000) { SynchronizingObject = parent };
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

            if (outcome)
            {
                switch (title)
                {
                    case "SCAMPS":
                        _scampsBrowser = browser;
                        _scampsSearchStarted = DateTime.Now;
                        _scampsTimer.Start();
                        break;
                    case "DIMPS":
                        _dimpsBrowser = browser;
                        _dimpsSearchStarted = DateTime.Now;
                        _dimpsTimer.Start();
                        break;
                    case "NSI":
                        _nsiBrowser = browser;
                        _nsiSearchStarted = DateTime.Now;
                        _nsiTimer.Start();
                        break;
                    default:
                        if (browser != null)
                            browser.Dispose();
                        break;
                }
            }


            return outcome;
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

            browser.GoToNoWait(search);
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

            browser.GoToNoWait(search);
            parent.AddAppEvent(AppEventTypes.AutoSearch);
            return true;
        }






        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get Data Methods /////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static string GetTableCell(string id)
        {
            var cell = _dimpsBrowser.ElementOfType<TableCell>(Find.ById(id));
            return cell.Exists ? cell.InnerHtml : null;
        }

        private static string GetHidden(string id)
        {
            var textfield = _dimpsBrowser.TextField(Find.ById(id));
            return textfield.Exists ? textfield.GetAttributeValue("value") : null;
        }







        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // SCAMPS Search ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static Timer _scampsTimer;
        private static IE _scampsBrowser;
        private static string _scampsSearching;
        private static DateTime _scampsSearchStarted;

        private static void ScampsTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if ((e.SignalTime - _scampsSearchStarted).TotalSeconds > 5)
            {
                if (_scampsBrowser != null)
                {
                    _scampsBrowser.Dispose();
                    _scampsBrowser = null;
                }
                _scampsTimer.Dispose();
                _scampsTimer = null;
                _scampsSearching = string.Empty;
                parent.SelectedContact.Service.WasSearched["SCAMPSDN"] = true;
                parent.SelectedContact.Service.WasSearched["SCAMPSUsername"] = true;
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
            _scampsSearching = string.Empty;
        }








        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // DIMPS Search /////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static Timer _dimpsTimer;
        private static IE _dimpsBrowser;
        private static string _dimpsSearching;
        private static DateTime _dimpsSearchStarted;

        private static void DimpsTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if ((e.SignalTime - _dimpsSearchStarted).TotalSeconds > 5)
            {
                if (_dimpsBrowser != null)
                {
                    _dimpsBrowser.Dispose();
                    _dimpsBrowser = null;
                }
                _dimpsTimer.Dispose();
                _dimpsTimer = null;
                _dimpsSearching = string.Empty;
                parent.SelectedContact.Service.WasSearched["DIMPSDN"] = true;
                parent.SelectedContact.Service.WasSearched["DIMPSUsername"] = true;
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
                var mode = GetHidden("init_mode");
                var value = GetTableCell("username");

                // Assuming only services with a username are found in DIMPS.
                switch (mode)
                {
                    case "cable":
                        contact.Fault.ONC = true;
                        if (_dimpsSearching != "DN") break;
                        contact.Fault.LIP = true;
                        contact.Username = value;
                        break;
                    case "fbb":
                        contact.Fault.NBF = true;
                        if (_dimpsSearching != "DN") break;
                        contact.Fault.NFV = true;
                        contact.Username = value;
                        break;
                }
                //switch (_dimpsSearching)
                //{
                //    case "DN":
                //        //if (contact.Service.WasSearched["SCAMPSDN"] && contact.Fault.AffectedServiceType.IsNot(ServiceTypes.LIP))
                //        //    contact.Fault.NFV = true;

                //        value = GetTableCell("username");

                //        switch (mode)
                //        {
                //            case "cable":
                //                contact.Fault.LIP = true;
                //                if (value == null) break;
                //                contact.Fault.ONC = true;
                //                contact.Username = value;
                //                break;
                //            case "fbb":
                //                contact.Fault.NFV = true;
                //                if (value == null) break;
                //                contact.Fault.NBF = true;
                //                contact.Username = value;
                //                break;
                //        }

                //        break;
                //    case "Username":
                //        //if (contact.Service.WasSearched["SCAMPSUsername"] && contact.Fault.AffectedServiceType.IsNot(ServiceTypes.ONC))
                //        //    contact.Fault.NBF = true;

                //        switch (mode)
                //        {
                //            case "cable":
                //                contact.Fault.ONC = true;
                //                break;
                //            case "fbb":
                //                contact.Fault.NBF = true;
                //                break;
                //        }

                //        break;
                //}
                contact.Service.WasSearched["DIMPSDN"] = true;
                contact.Service.WasSearched["DIMPSUsername"] = true;

                //value = GetTableCell("avc");
                //if (value != null)
                //{
                //    contact.Service.AVC = value;
                //    if (mode == "fbb" && !contact.Service.WasSearched["NSI"])
                //        AutoSearch(
                //            "https://staff.optusnet.com.au/tools/nsi/avc_detail.html?avcid=" + value,
                //            "NSI", "https://staff.optusnet.com.au/tools/nsi/", false);
                //}

                //value = GetTableCell("bras");
                //if (value != null)
                //    contact.Service.Bras = value;

                value = GetTableCell("accountno");
                if (value != null)
                    if(!contact.FindICONMatch(value))
                        contact.FindCMBSMatch(value);

                value = GetTableCell("custname");
                if (value != null)
                    contact.Name = value;

                value = GetTableCell("servaddr");
                if (value != null)
                    contact.Address.Address = value;

                value = GetTableCell("macidvendor");
                if (value != null)
                    contact.Service.FindMACMatch(value);

                value = GetTableCell("ipaddr");
                if (value != null)
                    contact.Service.FindIPMatch(value);

                value = GetTableCell("isonline");
                if (value != null)
                    contact.Service.ModemStatus = value;

                value = GetTableCell("throttlingstatus");
                if (value != null)
                    contact.Service.Throttled = value;
            }

            _dimpsBrowser.Dispose();
            _dimpsBrowser = null;
            _dimpsTimer.Dispose();
            _dimpsTimer = null;
            _dimpsSearching = string.Empty;
        }







        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // SCAMPS Search ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static Timer _nsiTimer;
        private static IE _nsiBrowser;
        private static DateTime _nsiSearchStarted;

        private static void NsiTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if ((e.SignalTime - _nsiSearchStarted).TotalSeconds > 5)
            {
                if (_nsiBrowser != null)
                {
                    _nsiBrowser.Dispose();
                    _nsiBrowser = null;
                }
                _nsiTimer.Dispose();
                _nsiTimer = null;
                parent.SelectedContact.Service.WasSearched["NSI"] = true;
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

            //var contact = parent.SelectedContact;
            //string value;

            //value = GetTableCell("cvc");
            //if (value != null)
            //    contact.Service.FindMACMatch(value);

            //value = GetTableCell("csa");
            //if (value != null)
            //    contact.Service.FindIPMatch(value);

            //value = GetTableCell("gsid");
            //if (value != null)
            //    contact.Service.ModemStatus = value;

            //value = GetTableCell("pri");
            //if (value != null)
            //    contact.Service.Throttled = value;
            // Get CVC?
            // Get CSA
            // Get SIP?
            // Get GSID
            // Get PRI
            // Get NNI?
            // Trigger CVC Search?

            parent.SelectedContact.Service.WasSearched["NSI"] = true;
            _nsiBrowser.Dispose();
            _nsiBrowser = null;
            _nsiTimer.Dispose();
            _nsiTimer = null;
        }
    }
}
