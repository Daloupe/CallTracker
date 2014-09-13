using System;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using System.Diagnostics;

using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

using CallTracker.Model;
using CallTracker.Helpers;
using CallTracker.Properties;

namespace CallTracker.View
{
    public partial class Main
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // IPCC Monitor ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private Process _ipccProcess = null;
        private TestStack.White.Application _ipccApplication;
        private Window _ipccWindow;
        private TestStack.White.UIItems.TextBox _ipccCallStatus;
        private TestStack.White.UIItems.Button _ipccDialButton;
        private TestStack.White.UIItems.Button _ipccTransferButton;

        private AutomationElement _ipccCallDataTable;
        //private string[,] _gridData;

        private UIItemContainer _ipccDialWindow;
        private TestStack.White.UIItems.ListBoxItems.ComboBox _ipccDialNumberComboBox;

        //private TimeSpan _callStateTimeElapsed;

        private bool CheckForIpcc()
        {
            if (monitorIPCCToolStripMenuItem.Checked)
            {
                if (_ipccProcess == null)
                {
                    EventLogger.LogNewEvent("Trying to find IPCC", EventLogLevel.Status);
                    if (InitIpccMonitor() == false)
                    {
                        _IPCCState.Text = Resources.IPCC_Unmonitored_String;
                        return false;
                    }
                }
                EventLogger.LogNewEvent("Monitoring IPCC", EventLogLevel.ClearStatus);
                return true;
            }
            EventLogger.LogNewEvent("Monitoring Not Enabled", EventLogLevel.Brief);
            return false;
        }

        private bool InitIpccMonitor()
        {
            foreach (var pList in Process.GetProcesses())
                if (pList.MainWindowTitle.Contains("IPCC Agent Desktop"))
                {
                    _ipccProcess = pList;
                    break;
                }

            if (_ipccProcess == null)
            {
                EventLogger.LogNewEvent("Unable to Find IPCC", EventLogLevel.Status);
                return false;
            }

            _ipccProcess.Exited += IPCCProcess_Exited;
            _ipccApplication = TestStack.White.Application.Attach(_ipccProcess);
            //Must be NoCache.
            _ipccWindow = _ipccApplication.GetWindow(SearchCriteria.ByAutomationId("SoftphoneForm"), InitializeOption.NoCache);
            _ipccDialButton = _ipccWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnDial"));
            _ipccTransferButton = _ipccWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnTransfer"));
            _ipccCallStatus = _ipccWindow.Get<TestStack.White.UIItems.TextBox>(SearchCriteria.ByAutomationId("StatusBar.Pane3"));

            //InitIPCCCallDataGrid();
            _ipccCallDataTable = _ipccWindow.Get<TestStack.White.UIItems.TableItems.Table>(SearchCriteria.ByAutomationId("m_callGrid")).AutomationElement;

            _ipccDialWindow = null;
            _ipccDialNumberComboBox = null;

            return true;
        }

        //private void InitIPCCCallDataGrid()
        //{
        //    _ipccCallDataTable = _ipccWindow.Get<TestStack.White.UIItems.TableItems.Table>(SearchCriteria.ByAutomationId("m_callGrid")).AutomationElement;
        //    var headerLine = _ipccCallDataTable.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Header));

        //    _gridData = new string[headerLine.Count, 2];
        //    var headerIndex = 0;
        //    foreach (AutomationElement header in headerLine)
        //    {
        //        _gridData[headerIndex++, 0] = header.Current.Name;
        //    }
        //}

        void IPCCProcess_Exited(object sender, EventArgs e)
        {
            EventLogger.LogAndSaveNewEvent("IPCC Exited", EventLogLevel.Status);
            //_callStateTimeElapsed = TimeSpan.Zero;
            _CallStateTime.BackColor = Color.WhiteSmoke;
            _CallStateTime.ForeColor = Color.DarkSlateGray;
            _CallStateTime.Text = @"00:00";//TimeSpanToString(_callStateTimeElapsed);
            monitorIPCCToolStripMenuItem.Checked = false;
            _IPCCState.Text = Resources.IPCC_Unmonitored_String;
            DisposeIPCC();
        }

        void DisposeIPCC()
        {
            _IPCCTimer.Enabled = false;
            if (_ipccProcess == null) return;

            _ipccProcess.Exited -= IPCCProcess_Exited;
            _ipccProcess.Dispose();
            _ipccProcess = null;
        }

        //private static Stopwatch watch = new Stopwatch();
        //watch.Reset();
        //watch.Start();
        //watch.Stop();
        //EventLogger.LogNewEvent("ByAutomationId: " + watch.ElapsedTicks);
        //EventLogger.SaveLog();
        public void DialOrTransfer(string value)
        {
            if (!CheckForIpcc())
                return;

            switch (_IPCCState.Text)
            {
                case "Talking":
                    _ipccTransferButton.Click();
                    break;
                case "NotReady":
                    _ipccDialButton.Click();
                    break;
                default:
                    return;
            }

            if (_ipccDialWindow == null)
            {
                _ipccDialWindow = _ipccWindow.MdiChild(SearchCriteria.ByAutomationId("DialPadForm"));
                if (_ipccDialWindow == null)
                {
                    EventLogger.LogNewEvent("IPCC Dial Error: CTI Dial Pad Not Found", EventLogLevel.Status);
                    return;
                }
                EventLogger.LogNewEvent("IPCC Dial: CTI Dial Pad Found", EventLogLevel.Brief);
            }

            if (_ipccDialNumberComboBox == null)
            {
                _ipccDialNumberComboBox = _ipccDialWindow.Get<TestStack.White.UIItems.ListBoxItems.ComboBox>(SearchCriteria.ByAutomationId("dialedNumberComboBox"));
                if (_ipccDialNumberComboBox == null)
                {
                    EventLogger.LogNewEvent("IPCC Dial Error: Number ComboBox Not Found", EventLogLevel.Status);
                    return;
                }
                EventLogger.LogNewEvent("IPCC Dial: Number ComboBox Found", EventLogLevel.Brief);
            }

            _ipccDialNumberComboBox.EditableText = value;
        }

        private void _CallStateTime_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == monitorIPCCToolStripMenuItem || e.ClickedItem == pullIPCCCallDataToolStripMenuItem) return;

            ChangeCallStateMenuItem((ToolStripMenuItem)e.ClickedItem);
            if (e.ClickedItem == logInToolStripMenuItem)
            {
                _IPCCState.Text = String.Empty;
                ChangeCallStateMenuItem(notReadyToolStripMenuItem);
            }
            if (!monitorIPCCToolStripMenuItem.Checked && !_IPCCTimer.Enabled)
                _IPCCTimer.Enabled = true;
        }

        private void ChangeCallStateMenuItem(string callState)
        {
            foreach (var control in _CallStateTime.DropDownItems.OfType<ToolStripMenuItem>().Where(control => control.Tag.ToString() != "Protected"))
                if (control.Tag.ToString() == callState)
                {
                    CurrentItem = control;
                    CurrentItem.Checked = true;
                }
                else
                    control.Checked = false;
        }

        private void ChangeCallStateMenuItem(ToolStripMenuItem callState)
        {
            foreach (var control in _CallStateTime.DropDownItems.OfType<ToolStripMenuItem>().Where(control => control.Tag.ToString() != "Protected"))
                control.Checked = false;
            CurrentItem = callState;
            CurrentItem.Checked = true;
        }

        private bool DoesIPCCExist()
        {
            if (_ipccProcess == null) return false;
            return !_ipccProcess.HasExited;
        }

        private void _IPCCTimer_Tick(object sender, EventArgs e)
        {
            // Exit if IPCC doesn't exist and IPCC monitoring is on.
            if (!DoesIPCCExist() && monitorIPCCToolStripMenuItem.Checked)
            {
                //_callStateTimeElapsed = TimeSpan.Zero;
                _CallStateTime.BackColor = Color.WhiteSmoke;
                _CallStateTime.ForeColor = Color.DarkSlateGray;
                _CallStateTime.Text = @"00:00";//TimeSpanToString(_callStateTimeElapsed);
                _IPCCTimer.Enabled = false;
                monitorIPCCToolStripMenuItem.Checked = false;
                _IPCCState.Text = Resources.IPCC_Unmonitored_String;
                return;
            }

            //if (CurrentItem.Name == "logInToolStripMenuItem")
            //    ChangeCallStateMenuItem(notReadyToolStripMenuItem);

            // If IPCC monitoring is off, pass in values from IPCC menu for testing.
            string status;
            if (monitorIPCCToolStripMenuItem.Checked)
            {
                status = _ipccCallStatus.Name;
                status = status.Remove(0, Math.Min(13, status.Length));
            }
            else
                status = CurrentItem.Tag.ToString();

            //var dailyData = (DailyModel)_DailyDataBindingSource.Current;

            if (status != _IPCCState.Text)
            {
                EventLogger.LogAndSaveNewEvent("Status Changed: " + status);

                if (String.IsNullOrEmpty(_IPCCState.Text))
                {
                    IsDifferentShift();
                        //dailyData = (DailyModel)_DailyDataBindingSource.Current;
                    CurrentDate.AddCallEvent(CallEventTypes.LogIn);
                    //if (SelectedContact != null)
                    //    if (SelectedContact.Events.LastCallEvent.EventType.Is(CallEventTypes.CallEnd))
                    //        SelectedContact.AddCallEvent((CallEventTypes.CallStart));
                }

                switch (status)
                {
                    case "Wrapup":
                        IPCCLevel("red");
                        if (CurrentContact != null)
                        {
                            CurrentContact.AddCallEvent(CallEventTypes.CallEnd);
                            CurrentContact = null;
                            if (SelectedContact != null)
                                SelectedContact.AddCallEvent((CallEventTypes.CallStart));
                        }
                        if (SelectedContact != null)
                            SelectedContact.AddCallEvent(CallEventTypes.Wrapup);
                        break;
                    case "Reserved":
                        _IPCCTimer.Interval = 125;
                        CurrentDate.AddCallEvent(CallEventTypes.CallStart);
                        if (autoNewCallToolStripMenuItem.Checked)
                        {
                            editContact.bindingNavigatorAddNewItem_Click(_IPCCState, new EventArgs());
                            SelectedContact.AddCallEvent(CallEventTypes.Reserved);
                        }
                        ChangeCallStateMenuItem(talkingToolStripMenuItem);
                        break;
                    case "Talking":
                        IPCCLevel("amber");

                        if (Settings.Default.PullIPCCCallData)
                            PullIPCCCallData();

                        if (CurrentContact != null)
                            CurrentContact.AddCallEvent(CallEventTypes.Talking);
                        else if (SelectedContact != null)
                            SelectedContact.AddCallEvent(CallEventTypes.Talking);
                        break;
                    case "Hold":
                        IPCCLevel("red");
                        if (CurrentContact != null)
                            CurrentContact.AddCallEvent(CallEventTypes.Hold);
                        else if (SelectedContact != null)
                            SelectedContact.AddCallEvent(CallEventTypes.Hold);
                        break;
                    case "NotReady":
                        IPCCLevel("red");
                        if (String.IsNullOrEmpty(_IPCCState.Text) || SelectedContact == null)
                        {
                            CurrentDate.AddCallEvent(CallEventTypes.NotReady);
                            if (SelectedContact != null)
                                SelectedContact.AddCallEvent(CallEventTypes.LogIn);
                        }
                        else
                        {
                            CurrentDate.AddCallEvent(CallEventTypes.CallStart);
                            SelectedContact.AddCallEvent(CallEventTypes.NotReady);
                        }
                        break;
                    case "Ready":
                        IPCCLevel("green");
                        CurrentDate.AddCallEvent(CallEventTypes.Ready);
                        if (SelectedContact != null)
                            SelectedContact.AddCallEvent(CallEventTypes.Ready);
                        break;
                    case "":
                        IPCCLevel("white");
                        FinalizeEvents(CurrentDate);
                        break;
                    default:
                        _IPCCTimer.Interval = 500;
                        break;
                }
                ////_callStateTimeElapsed = TimeSpan.Zero;
                _IPCCState.Text = status;
                ChangeCallStateMenuItem(status);
            }
            //else
            //{
            //    _callStateTimeElapsed = _callStateTimeElapsed.Add(new TimeSpan(0, 0, 0, 0, _IPCCTimer.Interval)); //new TimeSpan(_callStateTimeElapsed.Ticks + _IPCCTimer.Interval * 10000);
            //}

            if (StatsView.Visible)
            {
                if (!((DateTime.Now - _statsViewUpdate).TotalSeconds > 1)) return;
                StatsView.UpdateStats(SelectedDate);
                _statsViewUpdate = DateTime.Now;
            }
            else
                _CallStateTime.Text = SelectedContact != null ? TimeSpanToString(DateTime.Now - SelectedContact.Events.LastCallEvent.Timestamp) : TimeSpanToString(DateTime.Now - SelectedDate.Events.LastCallEvent.Timestamp);
        }
        private DateTime _statsViewUpdate = DateTime.Now;

        private void FinalizeEvents(DailyModel dailyData)
        {
            if (CurrentContact != null)
            {
                if (CurrentContact.Events.LastCallEvent.EventType.Is(CallEventTypes.NotReady))
                {
                    dailyData.ImportCallEvent(SelectedContact.Events.LastCallEvent.Copy());
                    SelectedContact.ChangeLastEventType(CallEventTypes.CallEnd);
                }
                CurrentContact.AddCallEvent(CallEventTypes.LogOut);
                CurrentContact = null;
            }
            else if (SelectedContact != null)
            {
                if (SelectedContact.Events.LastCallEvent.EventType.Is(CallEventTypes.NotReady))
                {
                    dailyData.ImportCallEvent(SelectedContact.Events.LastCallEvent.Copy());
                    SelectedContact.ChangeLastEventType(CallEventTypes.CallEnd);
                }
                SelectedContact.AddCallEvent(CallEventTypes.LogOut);
            }

            dailyData.AddCallEvent(CallEventTypes.LogOut);
        }

        private void PullIPCCCallData()
        {
            if (SelectedContact == null) return;

            var cacheRequest = new CacheRequest { AutomationElementMode = AutomationElementMode.Full, TreeScope = TreeScope.Children };
            cacheRequest.Add(AutomationElement.NameProperty);
            cacheRequest.Add(ValuePattern.Pattern);
            cacheRequest.Push();
            var gridLines = _ipccCallDataTable.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Custom));
            cacheRequest.Pop();

            object cachedPattern;
            string value;
            gridLines[0].CachedChildren[7].TryGetCachedPattern(ValuePattern.Pattern, out cachedPattern);
            if (cachedPattern != null)
            {
                value = ((ValuePattern)cachedPattern).Current.Value;
                if (value.Contains("LAT"))
                {
                    SelectedContact.Fault.LAT = true;
                    SelectedContact.Service.WasSearched["SCAMPSDN"] = true;
                    SelectedContact.Service.WasSearched["DIMPSDN"] = true;
                }
                else if (value.Contains("LIP"))
                {
                    SelectedContact.Fault.LIP = true;
                }
                else if (value.Contains("CAB"))
                {
                    SelectedContact.Fault.ONC = true;
                }
                else if (value.Contains("DTV"))
                {
                    SelectedContact.Fault.DTV = true;
                }
                else if (value.Contains("MTV"))
                {
                    SelectedContact.Fault.MTV = true;
                }
                else if (value.Contains("NBN"))
                {
                    //SelectedContact.Fault.LAT = true;
                }

                if (value.Length > 8)
                {
                    var substring = value.Substring(value.Length - 8, 8);
                    if (substring.IsDigits())
                        SelectedContact.Fault.PR = substring;
                }
            }

            gridLines[0].CachedChildren[4].TryGetCachedPattern(ValuePattern.Pattern, out cachedPattern);
            if (cachedPattern != null)
            {
                value = ((ValuePattern)cachedPattern).Current.Value;
                if (!SelectedContact.FindDNMatch(value))
                    SelectedContact.FindMobileMatch(value);
            }

            gridLines[0].CachedChildren[5].TryGetCachedPattern(ValuePattern.Pattern, out cachedPattern);
            if (cachedPattern != null)
            {
                value = ((ValuePattern)cachedPattern).Current.Value;
                if (!SelectedContact.FindDNMatch(value))
                    SelectedContact.FindMobileMatch(value);
            }

            gridLines[0].CachedChildren[6].TryGetCachedPattern(ValuePattern.Pattern, out cachedPattern);
            if (cachedPattern != null)
            {
                value = ((ValuePattern)cachedPattern).Current.Value;
                if (!SelectedContact.FindICONMatch(value))
                    SelectedContact.FindCMBSMatch(value);
            }

            gridLines[0].CachedChildren[9].TryGetCachedPattern(ValuePattern.Pattern, out cachedPattern);
            if (cachedPattern != null)
            {
                value = ((ValuePattern)cachedPattern).Current.Value;
                if (value.Contains("OK"))
                    SelectedContact.IDok = true;
            }
        }

        private static string TimeSpanToString(TimeSpan time)
        {
            return time.Hours > 0 ? String.Format("{0}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds) : String.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
        }

        private void IPCCLevel(string level)
        {
            switch (level)
            {
                case "white": // logged off.
                    _IPCCTimer.Interval = 500;
                    _CallStateTime.BackColor = Color.WhiteSmoke;
                    _CallStateTime.ForeColor = Color.DarkSlateGray;
                    break;
                case "green": // ready
                    _IPCCTimer.Interval = 250;
                    _CallStateTime.BackColor = Color.OliveDrab;
                    _CallStateTime.ForeColor = Color.PaleGoldenrod;
                    break;
                case "amber": // Talking
                    _IPCCTimer.Interval = 500;
                    _CallStateTime.BackColor = Color.Chocolate;
                    _CallStateTime.ForeColor = Color.PaleGoldenrod;
                    break;
                case "red": // Not Ready, Hold, Wrap Up, 178,34,34
                    _IPCCTimer.Interval = 250;
                    _CallStateTime.BackColor = Color.FromArgb(178, 34, 34);
                    _CallStateTime.ForeColor = Color.FromArgb(178, 34, 34);//.LightGoldenrodYellow;
                    break;
            }
        }
        ToolStripMenuItem _currentItem;
        ToolStripMenuItem CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                switch (_currentItem.Name)
                {
                    case "logInToolStripMenuItem":
                        logInToolStripMenuItem.Enabled = false;
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = false;
                        wrapUpToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = true;
                        notReadyToolStripMenuItem.Enabled = true;
                        break;
                    case "notReadyToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = true;
                        wrapUpToolStripMenuItem.Enabled = true;
                        talkingToolStripMenuItem.Enabled = false;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = true;
                        break;
                    case "readyToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = true;
                        wrapUpToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = false;
                        notReadyToolStripMenuItem.Enabled = true;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = true;
                        break;
                    case "reservedToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = false;
                        wrapUpToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = true;
                        logOutToolStripMenuItem.Enabled = false;
                        notReadyToolStripMenuItem.Enabled = true;
                        break;
                    case "talkingToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = true;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = false;
                        wrapUpToolStripMenuItem.Enabled = true;
                        notReadyToolStripMenuItem.Enabled = false;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = false;
                        break;
                    case "holdToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = true;
                        notReadyToolStripMenuItem.Enabled = false;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = false;
                        break;
                    case "wrapUpToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = true;
                        talkingToolStripMenuItem.Enabled = false;
                        notReadyToolStripMenuItem.Enabled = true;
                        logInToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = true;
                        break;
                    case "logOutToolStripMenuItem":
                        holdToolStripMenuItem.Enabled = false;
                        reservedToolStripMenuItem.Enabled = false;
                        readyToolStripMenuItem.Enabled = false;
                        wrapUpToolStripMenuItem.Enabled = false;
                        talkingToolStripMenuItem.Enabled = false;
                        logInToolStripMenuItem.Enabled = true;
                        notReadyToolStripMenuItem.Enabled = false;
                        break;
                }
            }
        }

        private void monitorIPCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckForIpcc())
            {
                monitorIPCCToolStripMenuItem.Checked = false;
                _CallStateTime.Text = @"00:00";
            }
            else
                _IPCCState.Text = String.Empty;

            _IPCCTimer.Enabled = monitorIPCCToolStripMenuItem.Checked;
        }

        private void pullIPCCCallDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.PullIPCCCallData = pullIPCCCallDataToolStripMenuItem.Checked; //((ToolStripMenuItem)sender).Checked;
        }

        private void autoNewCallToolStripMenuItem1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.AutoNewCall = autoNewCallToolStripMenuItem.Checked;
        }

        private void enableIPCCMonitorOnStartupToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.MonitorIPCC = enableIPCCMonitorOnStartupToolStripMenuItem.Checked;
        }
    }
}
