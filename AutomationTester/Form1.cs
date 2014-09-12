using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.ScreenMap;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;
using TestStack.White.UIItems.WPFUIItems;
using Application = TestStack.White.Application;

using Shortcut;

namespace AutomationTester
{
    public partial class Form1 : Form
    {
        BindingList<Application> _applications = new BindingList<Application>();
        BindingSource _applicationsBindingSource = new BindingSource();
        BindingList<Window> _windows = new BindingList<Window>();
        BindingSource _windowsBindingSource = new BindingSource();
        BindingList<Window> _modalWindows = new BindingList<Window>();
        BindingSource _modalWindowsBindingSource = new BindingSource();
        BindingList<UIItemContainer> _mdiChildren = new BindingList<UIItemContainer>();
        BindingSource _mdiChildrenBindingSource = new BindingSource();
        BindingList<TestStack.White.UIItems.TableItems.Table> _tables = new BindingList<TestStack.White.UIItems.TableItems.Table>();
        BindingSource _tablesBindingSource = new BindingSource();
        BindingList<UIItem> _controls = new BindingList<UIItem>();
        BindingSource _controlsBindingSource = new BindingSource();
        BindingList<ControlType> _controlTypes = new BindingList<ControlType> { ControlType.Button, ControlType.CheckBox, ControlType.ComboBox, ControlType.Custom, ControlType.DataItem, ControlType.DataGrid, ControlType.Document, ControlType.Edit, ControlType.Group, ControlType.List, ControlType.ListItem, ControlType.Pane, ControlType.RadioButton, ControlType.StatusBar, ControlType.Table, ControlType.Text, ControlType.Window };
        BindingSource _controlTypesBindingSource = new BindingSource();

        public static HotKeyManager HotKeyManager;
        public Form1()
        {
            InitializeComponent();

            _applicationsBindingSource.DataSource = _applications;        
            applicationsCombo.DataSource = _applicationsBindingSource;
            applicationsCombo.DisplayMember = "Name";

            _windowsBindingSource.DataSource = _windows;
            windowsCombo.DataSource = _windowsBindingSource;
            windowsCombo.DisplayMember = "Name";

            controlTypeCombo.DataSource = _controlTypes;
            controlTypeCombo.DisplayMember = "ProgrammaticName";

            HotKeyManager = new HotKeyManager();
            HotKeyManager.AddOrReplaceHotkey("Controls", Modifiers.Control | Modifiers.Shift, Keys.T, getControlValue);

            //_modalWindowsBindingSource.DataSource = _modalWindows;
            //_mdiChildrenBindingSource.DataSource = _mdiChildren;
            //_tablesBindingSource.DataSource = _tables;
            //_controlsBindingSource.DataSource = _controls;
            //_controlTypesBindingSource.DataSource = _controlTypes;

            //foreach (Process pList in Process.GetProcesses())
            //    if (pList.MainWindowTitle.Contains("IPCC Agent Desktop"))
            //    {
            //        _ipccProcess = pList;
            //        break;
            //    }

            //if (_ipccProcess == null)
            //{
            //    EventLogger.LogNewEvent("Unable to Find IPCC", EventLogLevel.Status);
            //    return false;
            //}

            //_ipccProcess.Exited += IPCCProcess_Exited;
            //_ipccApplication = TestStack.White.Application.Attach(_ipccProcess);
            //_ipccWindow = _ipccApplication.GetWindow(SearchCriteria.ByAutomationId("SoftphoneForm"), InitializeOption.NoCache);
            //_ipccCallStatus = _ipccWindow.Get<TestStack.White.UIItems.TextBox>(SearchCriteria.ByAutomationId("StatusBar.Pane3"));
            //_ipccDialButton = _ipccWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnDial"));
            //_ipccTransferButton = _ipccWindow.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnTransfer"));
            //var dialPadWindow = _ipccWindow.Get<Window>(SearchCriteria.ByAutomationId("DialPadForm"));
            //if (dialPadWindow == null)
            //{
            //    EventLogger.LogNewEvent("Unable to Find CTI Dial Pad", EventLogLevel.Status);
            //    return;
            //}

            //var dialPadNumber = dialPadWindow.Get<TestStack.White.UIItems.ListBoxItems.ComboBox>(SearchCriteria.ByAutomationId("dialedNumberComboBox"));
            //dialPadNumber.SetValue(value);




            //var callGrid = _ipccWindow.Get<TestStack.White.UIItems.TableItems.Table>(SearchCriteria.ByAutomationId("m_callGrid"));
            //var callGridRow = callGrid.Rows[0];
            //// Caller ID
            //if (callGridRow.Cells[3].Value != null)
            //{
            //    SelectedContact.FindMobileMatch(callGridRow.Cells[3].Value.ToString());
            //    SelectedContact.FindDNMatch(callGridRow.Cells[3].Value.ToString());
            //}
            //// Service No
            //if (callGridRow.Cells[4].Value != null)
            //{
            //    SelectedContact.FindMobileMatch(callGridRow.Cells[4].Value.ToString());
            //    SelectedContact.FindDNMatch(callGridRow.Cells[4].Value.ToString());
            //}
            //// Acc No
            //if (callGridRow.Cells[5].Value != null)
            //{
            //    SelectedContact.FindCMBSMatch(callGridRow.Cells[5].Value.ToString());
            //    SelectedContact.FindICONMatch(callGridRow.Cells[5].Value.ToString());
            //}
            //// IVR Selection
            //if (callGridRow.Cells[6].Value != null)
            //{
            //    var selection = callGridRow.Cells[6].Value.ToString();
            //    if (selection.Contains("LAT"))
            //        SelectedContact.Fault.LAT = true;
            //    else if (selection.Contains("LIP"))
            //        SelectedContact.Fault.LIP = true;
            //    else if (selection.Contains("ONC"))
            //        SelectedContact.Fault.ONC = true;
            //    else if (selection.Contains("NBN"))
            //        SelectedContact.Fault.NFV = true;
            //    else if (selection.Contains("MTV"))
            //        SelectedContact.Fault.MTV = true;
            //}
            //// ID ok
            //if (callGridRow.Cells[8].Value != null)
            //{
            //    if (callGridRow.Cells[8].Value.ToString().Contains("OK"))
            //        SelectedContact.IDok = true;
            //}
        }

        private void listDesktopWindows_Click(object sender, EventArgs e)
        {
            _log.AppendText("Getting Desktop Windows" + Environment.NewLine);
             ListWindows("Desktop", TestStack.White.Desktop.Instance.Windows(), listModalWindowsCheckBox.Checked);
        }

        private void listApplicationWindows_Click(object sender, EventArgs e)
        {
            _log.AppendText("Getting " + applicationName.Text +" Windows" + Environment.NewLine);
            ListApplicationWindowsFromProcessTitle(applicationName.Text, applicationTitle.Text);
        }

        private void listMdiChildButton_Click(object sender, EventArgs e)
        {
            _log.AppendText("Getting " + applicationName.Text + " MdiChild" + controlName.Text + Environment.NewLine);
            ListMdiChildWindow(applicationTitle.Text, (ControlType)controlTypeCombo.SelectedItem, controlName.Text);
        }

        private void listExeWindowsButton_Click(object sender, EventArgs e)
        {
            _log.AppendText("Getting " + applicationName.Text + " Windows" + Environment.NewLine);
            ListApplicationWindowsFromExeName(applicationName.Text, applicationTitle.Text);
        }


        private void listWindowControlsButton_Click(object sender, EventArgs e)
        {
            _log.AppendText("Getting " + applicationName.Text + " Controls with type" + controlTypeCombo.Text + Environment.NewLine);
            ListControls(applicationTitle.Text, (ControlType)controlTypeCombo.SelectedItem);
        }

        private void listWindowControlsButton2_Click(object sender, EventArgs e)
        {
            _log.AppendText("Getting " + applicationName.Text + " Controls with type" + controlTypeCombo.Text + Environment.NewLine);
            ListControls2(applicationTitle.Text, (ControlType)controlTypeCombo.SelectedItem);
        }

        private void listWindowControls(HotkeyPressedEventArgs e)
        {
            _log.AppendText("Getting " + applicationName.Text + " Controls with type " + controlTypeCombo.Text + Environment.NewLine);
            ListControls(applicationTitle.Text, (ControlType)controlTypeCombo.SelectedItem);
        }

        private void getControlValue(HotkeyPressedEventArgs e)
        {
            _log.AppendText("Getting " + applicationName.Text + " Control with name " + controlName.Text + Environment.NewLine);
            GetControlValue(applicationTitle.Text, (ControlType)controlTypeCombo.SelectedItem, controlName.Text);
        }

        private void getWindowControlButton_Click(object sender, EventArgs e)
        {
            _log.AppendText("Getting " + applicationName.Text + " Control with name " + controlName.Text + Environment.NewLine);
            GetControlValue(applicationTitle.Text, (ControlType)controlTypeCombo.SelectedItem, controlName.Text);
        }




        public void ListApplicationWindowsFromProcessTitle(string name, string title)
        {
            var process = Process.GetProcesses().FirstOrDefault(pList => pList.MainWindowTitle.Contains(title));
            if (process == null)
            {
                _log.AppendText("Unable to Find " + name + " Process" + Environment.NewLine);
                return;
            }

            var application = Application.Attach(process);
            if (application == null)
            {
                _log.AppendText("Unable to Find " + name + " Application" + Environment.NewLine);
                return;
            }

            ListWindows(name, application.GetWindows(), true);
        }

        public void ListApplicationWindowsFromExeName(string name, string title)
        {
            var application = Application.Attach(title);
            if (application == null)
            {
                _log.AppendText("Unable to Find " + name + " Application" + Environment.NewLine);
                return;
            }

            ListWindows(name, application.GetWindows(), listModalWindowsCheckBox.Checked);
        }

        public void ListWindows(string name, List<Window> windows, bool getModalWindows = false)
        {
            foreach (var window in windows)
            {
                _log.AppendText(name + " Window: " + window.Name + Environment.NewLine);
                if (getModalWindows)
                    ListWindows(window.Name + " Modal", window.ModalWindows());
            }
        }

        public void ListMdiChildWindow(string windowTitle, ControlType controlType, string controlText)
        {
            var window = TestStack.White.Desktop.Instance.Windows().Find(obj => obj.Title.Contains(windowTitle));
            if (window == null)
            {
                _log.AppendText("Window Not Found: " + windowTitle + Environment.NewLine);
                return;
            }

            var mdiChild = window.MdiChild(SearchCriteria.ByControlType(controlType).AndByText(controlText));
            if (mdiChild == null) return;
            _log.AppendText(windowTitle + " has MdiChild: " + controlText + " at x: " + mdiChild.Bounds.Left + " y: " + mdiChild.Bounds.Top + Environment.NewLine);
        }


        public void ListControls(string windowTitle, ControlType controlType)
        {
            var window = TestStack.White.Desktop.Instance.Windows().Find(obj => obj.Title.Contains(windowTitle));
            if (window == null)
            {
                _log.AppendText("Window Not Found: " + windowTitle + Environment.NewLine);
                return;
            }

            var controls = window.GetMultiple(SearchCriteria.ByControlType(controlType));
            if (!controls.Any()) return;
            _log.AppendText("<" + window.Title + ">\n");
            foreach (var control in controls)
            {
                _log.AppendText("\t(" + controlType.ProgrammaticName + ")" + control.Name + 
                                "\n\t\tLocation = " + control.Bounds.Left + "," + control.Bounds.Top +
                                "\n\t\tIsFocussed = " + control.IsFocussed + "\n");

                if (!controlType.Equals(ControlType.Table)) continue;

                var table = ((TestStack.White.UIItems.TableItems.Table)control).AutomationElement;

                // Now it's using UI Automation
                var headerLine = table.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Header));
                var cacheRequest = new CacheRequest { AutomationElementMode = AutomationElementMode.Full, TreeScope = TreeScope.Children };
                cacheRequest.Add(AutomationElement.NameProperty);
                cacheRequest.Add(ValuePattern.Pattern);
                cacheRequest.Push();
                var gridLines = table.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Custom));
                cacheRequest.Pop();

                var gridData = new string[headerLine.Count, gridLines.Count+1];
                var headerIndex = 0;
                foreach (AutomationElement header in headerLine)
                {
                    
                    _log.AppendText("trying to get header");
                    gridData[headerIndex++, 0] = header.Current.Name;
                    _log.AppendText("\n" + header.Current.Name);
                }

                var rowIndex = 1;
                foreach (AutomationElement row in gridLines)
                {
                    foreach (AutomationElement col in row.CachedChildren)
                    {
                        for (headerIndex = 0; headerIndex < headerLine.Count - 1; headerIndex++)
                        {
                            if (gridData[headerIndex, 0] == col.Cached.Name)
                                break;
                        }
                        try
                        {
                            var value = (col.GetCachedPattern(ValuePattern.Pattern) as ValuePattern);
                            if (value == null)
                                continue;
                            gridData[headerIndex, rowIndex] = value.Current.Value;;
                        }
                        catch (InvalidOperationException e)
                        {
                            _log.AppendText("Exception caught");
                        }
                    }
                    rowIndex++;
                }
            }
        }

        public void ListControls2(string windowTitle, ControlType controlType)
        {
            var window = TestStack.White.Desktop.Instance.Windows().Find(obj => obj.Title.Contains(windowTitle));
            if (window == null)
            {
                _log.AppendText("Window Not Found: " + windowTitle + Environment.NewLine);
                return;
            }

            var controls = window.GetMultiple(SearchCriteria.ByControlType(controlType));
            if (!controls.Any()) return;
            _log.AppendText("<" + window.Title + ">\n");
            foreach (var control in controls)
            {
                _log.AppendText("\t(" + controlType.ProgrammaticName + ")" + control.Name +
                                "\n\t\tLocation = " + control.Bounds.Left + "," + control.Bounds.Top +
                                "\n\t\tIsFocussed = " + control.IsFocussed + "\n");

                if (!controlType.Equals(ControlType.Table)) continue;

                var table = ((TestStack.White.UIItems.TableItems.Table)control).AutomationElement;

                // Now it's using UI Automation
                var headerLine = table.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Header));
                var cacheRequest = new CacheRequest { AutomationElementMode = AutomationElementMode.Full, TreeScope = TreeScope.Children };
                cacheRequest.Add(AutomationElement.NameProperty);
                cacheRequest.Add(ValuePattern.Pattern);
                cacheRequest.Push();
                var gridLines = table.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Custom));
                cacheRequest.Pop();

                var gridData = new string[headerLine.Count, gridLines.Count + 1];
                var headerIndex = 0;
                foreach (AutomationElement header in headerLine)
                {

                    _log.AppendText("trying to get header");
                    gridData[headerIndex++, 0] = header.Current.Name;
                    _log.AppendText("\n" + header.Current.Name);
                }

                //var rowIndex = 1;

                _log.AppendText(((ValuePattern)gridLines[0].CachedChildren[4].GetCachedPattern(ValuePattern.Pattern)).Current.Value);
                _log.AppendText(((ValuePattern)gridLines[0].CachedChildren[5].GetCachedPattern(ValuePattern.Pattern)).Current.Value);
                _log.AppendText(((ValuePattern)gridLines[0].CachedChildren[6].GetCachedPattern(ValuePattern.Pattern)).Current.Value);
                _log.AppendText(((ValuePattern)gridLines[0].CachedChildren[7].GetCachedPattern(ValuePattern.Pattern)).Current.Value);
                _log.AppendText(((ValuePattern)gridLines[0].CachedChildren[9].GetCachedPattern(ValuePattern.Pattern)).Current.Value);
                //foreach (AutomationElement row in gridLines)
                //{
                //    foreach (AutomationElement col in row.CachedChildren)
                //    {
                //        for (headerIndex = 0; headerIndex < headerLine.Count - 1; headerIndex++)
                //        {
                //            if (gridData[headerIndex, 0] == col.Cached.Name)
                //                break;
                //        }
                //        try
                //        {
                //            var value = (col.GetCachedPattern(ValuePattern.Pattern) as ValuePattern);
                //            if (value == null)
                //                continue;
                //            gridData[headerIndex, rowIndex] = value.Current.Value; ;
                //        }
                //        catch (InvalidOperationException e)
                //        {
                //            _log.AppendText("Exception caught");
                //        }
                //    }
                //    rowIndex++;
                //}
            }
        }

        public void GetControlValue(string windowTitle, ControlType controlType, string controlName)
        {
            var window = TestStack.White.Desktop.Instance.Windows().Find(obj => obj.Title.Contains(windowTitle));
            if (window == null)
            {
                _log.AppendText("Window Not Found: " + windowTitle + Environment.NewLine);
                return;
            }

            var control = window.Get(SearchCriteria.ByControlType(controlType).AndByText(controlName));
            //control.LogStructure();
            if(control == null)
            {
                _log.AppendText("Control Not Found: " + controlName + Environment.NewLine);
                return;
            }
            //_log.AppendText(control.CachedChildren.Count + Environment.NewLine);
            //control.GetMultiple(SearchCriteria.All);
            //foreach (var prop in control.Focus())
            _log.AppendText(control + Environment.NewLine);
        }



        private void applicationsGet_Click(object sender, EventArgs e)
        {
            _applicationsBindingSource.SuspendBinding();
            _applicationsBindingSource.RaiseListChangedEvents = false;

            Application application = null;

            switch (applicationsSearchBy.Text)
            {
                case "Process Name":
                    var process = Process.GetProcesses().FirstOrDefault(pList => pList.MainWindowTitle.Contains(applicationsString.Text));
                    if (process == null)
                    {
                        _log.AppendText("Unable to Find Process" + Environment.NewLine);
                        break;
                    }
                    application = Application.Attach(process);
                    break;
                case "Process Id":
                    application = Application.Attach(Convert.ToInt32(applicationsString.Text));
                    break;
                case "Exe Name":
                    application = Application.Attach(applicationsString.Text);
                    break;
            }

            if (application != null)
            {
                if (_applications.Contains(application))
                {
                    application.Dispose();
                    _log.AppendText("Application Already Exists: " + application.Name + Environment.NewLine);
                }
                else
                {
                    _applicationsBindingSource.Add(application);
                    _log.AppendText("Application Added: " + application.Name + Environment.NewLine);
                }
            }
            else
            {
                _log.AppendText("No Application Found " + Environment.NewLine);
            }

            _applicationsBindingSource.ResumeBinding();
            _applicationsBindingSource.RaiseListChangedEvents = true;
            _applicationsBindingSource.ResetBindings(false);
        }

        private void applicationsClear_Click(object sender, EventArgs e)
        {
            _applicationsBindingSource.SuspendBinding();
            _applicationsBindingSource.RaiseListChangedEvents = false;

            foreach (var application in _applications)
            {
                application.Dispose();
            }
            _applications.Clear();

            _applicationsBindingSource.ResumeBinding();
            _applicationsBindingSource.RaiseListChangedEvents = true;
            _applicationsBindingSource.ResetBindings(false);
        }

        private void windowsGet_Click(object sender, EventArgs e)
        {
            _windowsBindingSource.SuspendBinding();
            _windowsBindingSource.RaiseListChangedEvents = false;

            var windows = new List<Window>();

            var currentApplication = (Application)_applicationsBindingSource.Current;

            switch (windowsSearchBy.Text)
            {
                case "Application":
                    if (currentApplication == null)
                    {
                        _log.AppendText("No Application Selected: " + Environment.NewLine);
                        break;
                    }
                    windows = currentApplication.GetWindows();
                    break;
                case "Automation Id":
                    if (currentApplication == null)
                    {
                        _log.AppendText("No Application Selected: " + Environment.NewLine);
                        break;
                    }
                    windows.Add(currentApplication.GetWindow(SearchCriteria.ByAutomationId(windowsString.Text), InitializeOption.NoCache));
                    break;
                case "name":
                    if (currentApplication == null)
                    {
                        _log.AppendText("No Application Selected: " + Environment.NewLine);
                        break;
                    }
                    windows.Add(currentApplication.GetWindow(windowsString.Text, InitializeOption.NoCache));
                    break;
                case "Title":
                    windows.Add(TestStack.White.Desktop.Instance.Windows().Find(obj => obj.Title.Contains(windowsString.Text)));
                    break;
            }

            if (windows.Any())
            {
                foreach (var window in windows)
                {
                    if (_windows.Contains(window))
                    {
                        window.Dispose();
                        _log.AppendText("Window Already Exists: " + window.Name + Environment.NewLine);
                    }
                    else
                    {
                        _windowsBindingSource.Add(window);
                        _log.AppendText("Window Added: " + window.Name + Environment.NewLine);
                    }
                }
            }
            else
            {
                _log.AppendText("No Windows Found" + Environment.NewLine);
            }


            _windowsBindingSource.ResumeBinding();
            _windowsBindingSource.RaiseListChangedEvents = true;
            _windowsBindingSource.ResetBindings(false);
        }

        private void windowsClear_Click(object sender, EventArgs e)
        {
            _windowsBindingSource.SuspendBinding();
            _windowsBindingSource.RaiseListChangedEvents = false;

            foreach (var window in _windows)
            {
                window.Dispose();
            }
            _windows.Clear();

            _windowsBindingSource.ResumeBinding();
            _windowsBindingSource.RaiseListChangedEvents = true;
            _windowsBindingSource.ResetBindings(false);
        }







    }
}
