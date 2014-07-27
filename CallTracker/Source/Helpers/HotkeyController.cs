﻿using System;
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
    public delegate void ActionEventHandler();

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
        private static IE browser;
        private static string PreviousIEMatch;
        private static HotKeyManager HotKeyManager;
        private static PropertyDescriptorCollection props;

        public Stopwatch sw = new Stopwatch();

        public static event ActionEventHandler OnAction;
        
        public HotkeyController(Main _parent)
        {
            parent = _parent;

            HotKeyManager = new HotKeyManager();

            HotKeyManager.AddOrReplaceHotkey("SmartCopy", Modifiers.Win, Keys.C, OnSmartCopy);
            HotKeyManager.AddOrReplaceHotkey("SmartPaste", Modifiers.Win, Keys.V, OnSmartPaste);
            HotKeyManager.AddOrReplaceHotkey("BindSmartPaste", Modifiers.Win | Modifiers.Shift, Keys.B, OnBindSmartPaste);
            HotKeyManager.AddOrReplaceHotkey("AutoLogin", Modifiers.Win, Keys.Oemtilde, OnAutoLogin);
            HotKeyManager.AddOrReplaceHotkey("AutoFill", Modifiers.Win | Modifiers.Control, Keys.V, OnAutoFill);
            HotKeyManager.AddOrReplaceHotkey("AddARO", Modifiers.Win | Modifiers.Shift, Keys.C, OnAddARO);
            foreach (var DataPasteHotkey in DataPasteHotkeys)
                HotKeyManager.AddOrReplaceHotkey(DataPasteHotkey.Value, Modifiers.Shift | Modifiers.Control, DataPasteHotkey.Key, OnDataPaste);
            foreach (var GridLinkHotKey in GridLinkHotkeys)
                HotKeyManager.AddOrReplaceHotkey(GridLinkHotKey.Value, Modifiers.Win, GridLinkHotKey.Key, OnGridLinks);

            Settings.Instance.AutoMoveMousePointerToTopLeft = false;
            Settings.Instance.AutoCloseDialogs = false;
            Settings.Instance.AttachToBrowserTimeOut = 10;
            Settings.Instance.WaitForCompleteTimeOut = 10;
            Settings.Instance.WaitUntilExistsTimeOut = 10;

            props = TypeDescriptor.GetProperties(parent.SelectedContact.Service);

        }

        public void Dispose()
        {
            HotKeyManager.UnbindHotkeys();

            if (browser != null)
                browser.Dispose();
        }
        // ARO //////////////////////////////////////////////////////////////////////////////////////////////
        private void OnAddARO(HotkeyPressedEventArgs e)
        {
            Main.ShowPopupForm<AddAROForm>();
        }

        // Grid Links ///////////////////////////////////////////////////////////////////////////////////////
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
            parent.SetProgressBarStep(5);
            SystemItem systemItem = parent.DataStore.GridLinks.GetSystemItem(Convert.ToInt32(e.Name));
            
            OnAction();
            if (systemItem.System == "MAD" || systemItem.System == "OPOM")
            {
                IntPtr hWnd = IntPtr.Zero;
                hWnd = WindowHelper.FindHWNDByTitle(systemItem.Title);
                if (hWnd != IntPtr.Zero)
                    WindowHelper.SetForegroundWindow(hWnd);
            }
            else if (FindIEByTitle(systemItem.Title))
            {
                new IETabActivator(browser).ActivateByTabsUrl(browser.Url);
                if (browser.Url == systemItem.Url)
                    AutoLogin();
            }
            else
            {
                if(CreateNewIE(systemItem.Url, systemItem.Title))
                    AutoLogin();     
            }
            parent.UpdateProgressBar(0);
        }

        // Data Paste ///////////////////////////////////////////////////////////////////////////////////////
        private Dictionary<Keys, string> DataPasteHotkeys = new Dictionary<Keys, string>()
        {
            {Keys.D1, "ICON"},
            {Keys.D2, "CMBS"},
            {Keys.Q , "Username"},
            {Keys.W , "DN"},
            {Keys.A , "Name"},
            {Keys.S , "Mobile"},
            {Keys.Z , "Fault.PR"},
            {Keys.X , "Service.Node"}
        };

        private void OnDataPaste(HotkeyPressedEventArgs e)
        {
            string dataToPaste = FindProperty.FollowPropertyPath(parent.SelectedContact, e.Name);

            if (!String.IsNullOrEmpty(dataToPaste))
            {
                Clipboard.SetText(dataToPaste);
                SendKeys.Send("^(v)");
            } 
        }

        // Smart Paste ///////////////////////////////////////////////////////////////////////////////////////
        private void OnSmartPaste(HotkeyPressedEventArgs e)
        {
            if (!FindIEByTitle(WindowHelper.GetActiveWindowTitle()))
                return;
            //if (!FindIEByHWND(WindowHelper.GetActiveWindowHWND()))
            //    return;

            string url = browser.Url;
            string title = browser.Title;
            string element = browser.ActiveElement.IdOrName;

            PasteBind query = (from   
                                   bind in parent.DataStore.PasteBinds
                               where  
                                   bind.Element == element &&
                                   (bind.Url == url || 
                                    title.Contains(bind.Title) || 
                                    bind.Title.Contains(title))
                               select 
                                   bind)
                               .FirstOrDefault();

            if (query != null)
                query.Paste(browser, element, FindProperty.FollowPropertyPath(parent.SelectedContact, query.Data, query.AltData));
        }

        private void OnBindSmartPaste(HotkeyPressedEventArgs e)
        {
            if (!FindIEByTitle(WindowHelper.GetActiveWindowTitle()))
                return;
            //if (!FindIEByHWND(WindowHelper.GetActiveWindowHWND()))
            //    return;

            string url = browser.Url;
            string title = browser.Title;
            string element = browser.ActiveElement.IdOrName;

            if(String.IsNullOrEmpty(element))
            {
                WindowHelper.SetForegroundWindow(parent.Handle);
                MessageBox.Show(parent, "Unable to bind: Unable to find element name or id");
                return;
            }

            var UrlOrTitleMatches =  from
                                        bind in parent.DataStore.PasteBinds
                                     where
                                        bind.Url == url || 
                                        bind.Title.Contains(title) ||
                                        title.Contains(bind.Title) 
                                     select
                                        bind;

            PasteBind ElementMatch = UrlOrTitleMatches.FirstOrDefault(bind => bind.Element == element);

            if (ElementMatch == null)
            {
                string system = UrlOrTitleMatches.Count() > 0 ? UrlOrTitleMatches.ElementAtOrDefault(0).System : String.Empty;
                ElementMatch = new PasteBind(system, url, title, browser.ActiveElement);
                parent.DataStore.PasteBinds.Add(ElementMatch);
            }

            parent.editSmartPasteBinds.SelectQuery(ElementMatch);
            Main.ShowPopupForm<BindSmartPasteForm>().SelectQuery(ElementMatch);
        }

        // AutoFill /////////////////////////////////////////////////////////////////////////////////////////
        private void OnAutoFill(HotkeyPressedEventArgs e)
        {
            if (!FindIEByTitle(WindowHelper.GetActiveWindowTitle()))
                return;

            string url = browser.Url;
            string title = browser.Title;

            var query = from
                            bind in parent.DataStore.PasteBinds
                        where
                            bind.Url == url ||
                            bind.Title.Contains(title) ||
                            title.Contains(bind.Title)
                        select
                            bind;

            foreach (PasteBind bind in query)
                bind.Paste(browser, bind.Element, FindProperty.FollowPropertyPath(parent.SelectedContact, bind.Data, bind.AltData));
        }

        // Auto Login ///////////////////////////////////////////////////////////////////////////////////////
        private void OnAutoLogin(HotkeyPressedEventArgs e)
        {
            parent.SetProgressBarStep(2);
            AutoLogin();
            parent.UpdateProgressBar(0);
        }

        private void AutoLogin()
        {
            OnAction();
            if (!FindIEByTitle(WindowHelper.GetActiveWindowTitle()))
                return;

            string title = browser.Title;
            string url = browser.Url;

            LoginsModel query = (from
                                     login in parent.DataStore.Logins
                                 where
                                     //title.Contains(login.Title) ||
                                     //login.Title.Contains(title) || 
                                     login.Url == url
                                 select
                                     login)
                                 .FirstOrDefault();
            OnAction();
            if (query == null)
                return;

            query.Paste(browser, query.UsernameElement, query.Username);
            query.Paste(browser, query.PasswordElement, query.Password);
            query.Submit(browser);
        }

        //private AddressPattern rgxAddress = new AddressPattern();
        //private DigitPattern rgxDigit = new DigitPattern();
        //private NodePattern rgxNode = new NodePattern();
        //private CMBSPattern rgxCMBS = new CMBSPattern();
        //private ICONPattern rgxICON = new ICONPattern();
        //private DNPattern rgxDN = new DNPattern();
        //private MobilePattern rgxMobile = new MobilePattern();
        //private AlphaPattern rgxAlpha = new AlphaPattern();
        //private NamePattern rgxName = new NamePattern();
        //private UsernameLowerPattern rgxUNLower = new UsernameLowerPattern();
        //private UsernameUpperPattern rgxUNUpper = new UsernameUpperPattern();
        //private CommonNBNPattern rgxNBN = new CommonNBNPattern();
        //private BRASPattern rgxBras = new BRASPattern();

        // Smart Copy ///////////////////////////////////////////////////////////////////////////////////////
        private void OnSmartCopy(HotkeyPressedEventArgs e)
        {
            string oldClip = Clipboard.GetText();
            SendKeys.SendWait("^(c)");
            string text = Clipboard.GetText().Trim();
            int textlen = text.Length;
            string firstchar = text.Substring(0, 1);

            //check if each if needs returns.
            //parent.SelectedContact.SetProperty("Service." + text.Substring(0, 3), text);
            
            if(new DigitPattern().IsMatch(text))
            {
                if (firstchar == "1" && textlen == 8)                  parent.SelectedContact.Fault.PR = text;
                else if ((firstchar == "0" && textlen == 10) 
                     || (text.Substring(0, 2) == "61" && textlen == 11))
                {
                    if (new MobilePattern().IsMatch(text))             parent.SelectedContact.Mobile = text;
                    else if (new DNPattern().IsMatch(text))            parent.SelectedContact.DN = text;
                }
                else if (new CMBSPattern().IsMatch(text))              parent.SelectedContact.CMBS = text;
                else if (new ICONPattern().IsMatch(text))              parent.SelectedContact.ICON = text;
                else                                                   parent.SelectedContact.Note += text;
            }
            else if (new AlphaPattern().IsMatch(text))
            {
                if (new NamePattern().IsMatch(text))                   parent.SelectedContact.Name = text;
                else if (new UsernameLowerPattern().IsMatch(text) 
                      || new UsernameUpperPattern().IsMatch(text))     parent.SelectedContact.Username = text;
                else                                                   parent.SelectedContact.Note += text;
            }
            else
            {
                if (Char.IsLetter(text, 0))
                {
                    if (new BRASPattern().IsMatch(text))               parent.SelectedContact.Service.Bras = text;
                    else if (new CommonNBNPattern().IsMatch(text))     parent.SelectedContact.SetProperty("Service." + text.Substring(0, 3), text);
                    else if (new UsernameLowerPattern().IsMatch(text) 
                        ||   new UsernameUpperPattern().IsMatch(text)) parent.SelectedContact.Username = text;
                    else if (new AddressPattern().IsMatch(text))       parent.SelectedContact.Address.Address = text;
                }
                else
                {
                    if (new NodePattern().IsMatch(text))               parent.SelectedContact.Service.Node = text;
                    else if (new CMBSPattern().IsMatch(text))          parent.SelectedContact.CMBS = text;
                    else if (new AddressPattern().IsMatch(text))       parent.SelectedContact.Address.Address = text;
                    else                                               parent.SelectedContact.Note += text;
                }      
            }



            //if (Char.IsLetter(text, 0))
            //{
            //    if (new BRASPattern().IsMatch(text))
            //        parent.SelectedContact.Service.Bras = text;
            //    else if (new CommonNBNPattern().IsMatch(text))
            //        parent.SelectedContact.SetProperty("Service." + text.Substring(0, 3), text);
            //    else if (new NamePattern().IsMatch(text))
            //        parent.SelectedContact.Name = text;
            //    else if (new UsernameLowerPattern().IsMatch(text) ||
            //             new UsernameUpperPattern().IsMatch(text))
            //        parent.SelectedContact.Username = text;
            //    else if (new AddressPattern().Matches(text).Count > 3)
            //        parent.SelectedContact.Address.Address = text;
            //}

            //else if ((firstchar == "0" && textlen == 10) || (text.Substring(0, 2) == "61" && textlen == 11))
            //{
            //    if (new MobilePattern().IsMatch(text))
            //        parent.SelectedContact.Mobile = text;
            //    else if (new DNPattern().IsMatch(text))
            //        parent.SelectedContact.DN = text;
            //}

            //else if (firstchar == "2" || firstchar == "3" || firstchar == "4")
            //{
            //    if (new NodePattern().IsMatch(text))
            //        parent.SelectedContact.Service.Node = text;
            //    else if (new CMBSPattern().IsMatch(text))
            //        parent.SelectedContact.CMBS = text;
            //}

            //else if (firstchar == "1" && textlen == 8)
            //    parent.SelectedContact.Fault.PR = text;

            //else if (new ICONPattern().IsMatch(text))
            //    parent.SelectedContact.ICON = text;

            //else if (new AddressPattern().Matches(text).Count > 3)
            //    parent.SelectedContact.Address.Address = text;//[Unit|Level]?([-|/]?:\d+)?\w+

            //else
            //    parent.SelectedContact.Note += text;
        }

        // Browser Methods ///////////////////////////////////////////////////////////////////////////////////////
        private bool FindIEByHWND(IntPtr _HWND)
        {
            string currentHWND = _HWND.ToString();

            if (!Browser.Exists<IE>(Find.By("hwnd", currentHWND)))
                return false;

            if (PreviousIEMatch != currentHWND)
            {
                if (browser != null)
                    browser.Dispose();
                browser = Browser.AttachToNoWait<IE>(Find.By("hwnd", currentHWND));
                browser.AutoClose = false;
                PreviousIEMatch = currentHWND;
            }

            return true;
        }

        private bool FindIEByTitle(string _title)
        {
            string currentTitle = Regex.Split(_title, " -( Windows)? Internet Explorer")[0];

            if (!Browser.Exists<IE>(Find.ByTitle(currentTitle)))
                return false;

            if (PreviousIEMatch != currentTitle)
            {
                if (browser != null)
                    browser.Dispose();
                browser = Browser.AttachToNoWait<IE>(Find.ByTitle(currentTitle));
                browser.AutoClose = false;
                PreviousIEMatch = currentTitle;
            }

            return true;
        }

        private bool FindIEByUrl(string _url)
        {
            //browser = Browser.AttachTo<IE>(Find.ByUrl(new Regex("(http(s)?://)?.*" + _url + ".*", RegexOptions.IgnoreCase)));
            if (!Browser.Exists<IE>(Find.ByUrl(new Regex("(http(s)?://)?.*" + _url + ".*", RegexOptions.IgnoreCase))))
                return false;

            if (PreviousIEMatch != _url)
            {
                if (browser != null)
                    browser.Dispose();
                browser = Browser.AttachToNoWait<IE>(Find.ByUrl(new Regex("(http(s)?://)?.*" + _url + ".*", RegexOptions.IgnoreCase)));
                browser.AutoClose = false;
                PreviousIEMatch = _url;
            }

            return true;
        }

        public bool CreateNewIE(string _url, string _title)
        {
            OnAction();
            if (browser != null)
                browser.Dispose();

            OnAction();
            using (Process m_Proc = System.Diagnostics.Process.Start("IExplore.exe", _url))
            {
                try
                {
                    browser = Browser.AttachToNoWait<IE>(Find.ByTitle(_title));
                    browser.AutoClose = false;
                    PreviousIEMatch = _title;
                    return true;
                }
                catch (WatiN.Core.Exceptions.BrowserNotFoundException)
                {
                    return false; 
                }
            }
        }
    }

}
