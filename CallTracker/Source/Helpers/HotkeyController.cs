using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Input;

using Shortcut;
using WatiN.Core;

using CallTracker.View;
using CallTracker.Model;

namespace CallTracker.Helpers
{
    public class HotkeyController : IDisposable
    {
        private static IE browser;
        private static string PreviousIEMatch;
        private static Main parent;
        private static HotKeyManager HotKeyManager;

        public HotkeyController(Main _parent)
        {
            parent = _parent;
            HotKeyManager = new HotKeyManager();

            HotKeyManager.AddOrReplaceHotkey("SmartCopy", Modifiers.Win, Keys.C, OnSmartCopy);
            HotKeyManager.AddOrReplaceHotkey("SmartPaste", Modifiers.Win, Keys.V, OnSmartPaste);
            HotKeyManager.AddOrReplaceHotkey("BindSmartPaste", Modifiers.Win | Modifiers.Shift, Keys.B, OnBindSmartPaste);

            foreach (var DataPasteHotkey in DataPasteHotkeys)
                HotKeyManager.AddOrReplaceHotkey(DataPasteHotkey.Value, Modifiers.Shift | Modifiers.Control, DataPasteHotkey.Key, DataPaste);

            HotKeyManager.AddOrReplaceHotkey("AutoLogin", Modifiers.Win, Keys.Oemtilde, AutoLogin);

            foreach (var GridLinkHotKey in GridLinkHotkeys)
                HotKeyManager.AddOrReplaceHotkey(GridLinkHotKey.Value, Modifiers.Win, GridLinkHotKey.Key, GridLinks);
        }

        public void Dispose()
        {
            HotKeyManager.UnbindHotkeys();

            if (browser != null)
            {
                browser.Dispose();
            }
        }

        // Grid Links ///////////////////////////////////////////////////////////////////////////////////////
        private Dictionary<Keys, string> GridLinkHotkeys = new Dictionary<Keys, string>()
        {
            {Keys.Q, "0"},
            {Keys.W, "1"},
            {Keys.NumPad2, "2"},
            {Keys.NumPad3, "3"},
            {Keys.NumPad4, "4"},
            {Keys.NumPad5, "5"},
            {Keys.NumPad6, "6"},
            {Keys.NumPad7, "7"},
            {Keys.NumPad8, "8"},
            {Keys.NumPad9, "9"}
        };

        private void GridLinks(HotkeyPressedEventArgs e)
        {
            if (!FindIEByTitle(parent.DataStore.GridLinks.GridLinkList[Convert.ToInt32(e.Name)].System))
                return;
            browser.BringToFront();
        }

        // Auto Login ///////////////////////////////////////////////////////////////////////////////////////
        private void AutoLogin(HotkeyPressedEventArgs e)
        {
            if (!FindIEByTitle(ActiveWindow.Title()))
                return;

            string title = browser.Title;
            string url = browser.Url;
            LoginsModel query = (from login in parent.DataStore.Logins
                                 where  title.Contains(login.Title) ||
                                        login.Url == url
                                 select login)
                                 .FirstOrDefault();
            if (query == null)
                return;

            SetValueByIdOrName(query.UsernameElement, query.Username);
            SetValueByIdOrName(query.PasswordElement, query.Password);
            ClickElementByIdOrName(query.SubmitElement);
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

        private void DataPaste(HotkeyPressedEventArgs e)
        {
            string dataToPaste = FollowPropertyPath(Main.SelectedContact, e.Name);

            if (!String.IsNullOrEmpty(dataToPaste))
            {
                Clipboard.SetText(dataToPaste);
                SendKeys.Send("^(v)");
            } 
        }

        // Smart Paste ///////////////////////////////////////////////////////////////////////////////////////
        private void OnSmartPaste(HotkeyPressedEventArgs e)
        {
            if (!FindIEByTitle(ActiveWindow.Title()))
                return;

            string url = browser.Url;
            string title = browser.Title;
            string element = browser.ActiveElement.IdOrName;

            PasteBind query = (from   bind in parent.DataStore.PasteBinds
                               where  bind.Element == element &&
                                     (bind.Url == url || title.Contains(bind.Title))
                               select bind)
                               .FirstOrDefault();

            if (query != null)
            {
                string data = FollowPropertyPath(Main.SelectedContact, query.Data);
                if (String.IsNullOrEmpty(data) && query.AltData != null)
                    data = FollowPropertyPath(Main.SelectedContact, query.AltData);
                
                if (!String.IsNullOrEmpty(data))
                    SetValueByIdOrName(element, data);
            }
        }

        private void OnBindSmartPaste(HotkeyPressedEventArgs e)
        {
            if (!FindIEByTitle(ActiveWindow.Title()))
                return;

            string url = browser.Url;
            string title = browser.Title;
            string element = browser.ActiveElement.IdOrName;

            PasteBind query = (from bind in parent.DataStore.PasteBinds
                               where  bind.Element == element &&
                                     (bind.Url == url || title.Contains(bind.Title))
                               select bind)
                               .FirstOrDefault();

            if (query == null)
            {
                query = new PasteBind(url, title, element);
                parent.DataStore.PasteBinds.Add(query);
                parent.editSmartPasteBinds.pasteBindBindingSource.ResetBindings(true);
            }

            parent.editSmartPasteBinds.SelectQuery(query);

            Main.ShowSettingsForm<BindSmartPasteForm>().UpdateFields(query);
        }

        // Smart Copy ///////////////////////////////////////////////////////////////////////////////////////
        private void OnSmartCopy(HotkeyPressedEventArgs e)
        {
            string oldClip = Clipboard.GetText();
            SendKeys.SendWait("^(c)");
            string text = Clipboard.GetText().Trim();
            int textlen = text.Length;
            string firstchar = text.Substring(0, 1);

            if (Regex.IsMatch(text, @"^[AVCSNIG]{3}\d{15}"))
            {
                string firstThree = text.Substring(0, 3);
                PropertyInfo prop = Main.SelectedContact.Service.GetType().GetProperty(firstThree);
                prop.SetValue(Main.SelectedContact.Service, text, null);
                
            }
            else if (Char.IsLetter(text, 0))
            {
                if (Regex.IsMatch(text, @"(\b[A-Z][a-z]+(-|\s)?){2,}"))
                    Main.SelectedContact.Name = text;
                else if (Regex.IsMatch(text, @"\A[a-z]+([a-z]?[0-9]?\.?_?)*\z") || Regex.IsMatch(text, @"\A[A-Z]+([A-Z]?[0-9]?\.?_?)*\z"))
                    Main.SelectedContact.Username = text;
                else if (Regex.Matches(text, @"\w+").Count > 3)
                    Main.SelectedContact.Address.Address = text;
            }

            else if ((firstchar == "0" && textlen == 10) || (text.Substring(0, 2) == "61" && textlen == 11))
            {
                if (Regex.IsMatch(text, @"^(0|61)4\d{8}$"))
                    Main.SelectedContact.Mobile = text;
                else if (Regex.IsMatch(text, @"^(0|61)[2378]\d{8}$"))
                    Main.SelectedContact.DN = text;
            }

            else if (firstchar == "3")
            {
                if (Regex.IsMatch(text, @"\A\d\d(?i)[a-z]{2}_??\d\d\z"))
                    Main.SelectedContact.Service.Node = text;
                else if (Regex.IsMatch(text, @"\A3[1-3]-??\d{5}(-|0|\s)\d\z"))
                    Main.SelectedContact.CMBS = text;
            }

            else if (firstchar == "1" && textlen == 8)
                Main.SelectedContact.Fault.PR = text;

            else if (Regex.IsMatch(text, @"\A(1|5|8|9)\d{13}\z"))
                Main.SelectedContact.ICON = text;

            else if (Regex.Matches(text, @"\w+").Count > 3)
                Main.SelectedContact.Address.Address = text;//[Unit|Level]?([-|/]?:\d+)?\w+
            
            else
                Main.SelectedContact.Note += text;
        }

        // Misc Methods ///////////////////////////////////////////////////////////////////////////////////////
        private bool FindActiveIEByHWND(IntPtr _HWND)
        {
            string currentHWND = _HWND.ToString();

            if (!Browser.Exists(typeof(IE), Find.By("hwnd", currentHWND)))
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
            string[] titleRegex = Regex.Split(_title, " -( Windows)? Internet Explorer");
            
            string currentTitle = titleRegex[0];

            if (!Browser.Exists(typeof(IE), Find.ByTitle(currentTitle)))
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

        public static string FollowPropertyPath(object value, string path)
        {
            Type currentType = value.GetType();

            foreach (string propertyName in path.Split('.'))
            {
                PropertyInfo property = currentType.GetProperty(propertyName);
                value = property.GetValue(value, null);
                currentType = property.PropertyType;
            }

            return value.ToString();
        }

        public static void SetValueByIdOrName(string _element, string _data)
        {
            if (String.IsNullOrEmpty(_element))
                return;
            Element inputField = browser.Element(Find.ById(_element));
            if (inputField == null)
                inputField = browser.Element(Find.ByName(_element));
            if (inputField != null)
                inputField.SetAttributeValue("Value", _data);
        }
        public static void ClickElementByIdOrName(string _element)
        {
            if (String.IsNullOrEmpty(_element))
                return;
            Element inputField = browser.Element(Find.ById(_element));
            if (inputField == null)
                inputField = browser.Element(Find.ByName(_element));
            if (inputField != null)
                inputField.Click();
        }
    }
}
