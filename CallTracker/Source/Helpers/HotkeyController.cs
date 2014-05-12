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

        public HotkeyController(Main _parent)
        {
            parent = _parent;

            HotKeyManager.AddOrReplaceHotkey("SmartCopy", Modifiers.Win, Keys.C, OnSmartCopy);
            HotKeyManager.AddOrReplaceHotkey("SmartPaste", Modifiers.Win, Keys.V, OnSmartPaste);
            HotKeyManager.AddOrReplaceHotkey("BindSmartPaste", Modifiers.Win | Modifiers.Shift, Keys.B, OnBindSmartPaste);

            HotKeyManager.AddOrReplaceHotkey("ICON", Modifiers.Shift | Modifiers.Control, Keys.D1, DataPaste);
            HotKeyManager.AddOrReplaceHotkey("CMBS", Modifiers.Shift | Modifiers.Control, Keys.D2, DataPaste);
            HotKeyManager.AddOrReplaceHotkey("UN", Modifiers.Shift | Modifiers.Control, Keys.Q, DataPaste);
            HotKeyManager.AddOrReplaceHotkey("DN", Modifiers.Shift | Modifiers.Control, Keys.W, DataPaste);
            HotKeyManager.AddOrReplaceHotkey("Name", Modifiers.Shift | Modifiers.Control, Keys.A, DataPaste);
            HotKeyManager.AddOrReplaceHotkey("Mobile", Modifiers.Shift | Modifiers.Control, Keys.S, DataPaste);
            HotKeyManager.AddOrReplaceHotkey("PR", Modifiers.Shift | Modifiers.Control, Keys.Z, DataPaste);
            HotKeyManager.AddOrReplaceHotkey("Node", Modifiers.Shift | Modifiers.Control, Keys.X, DataPaste);

            HotKeyManager.AddOrReplaceHotkey("AutoLogin", Modifiers.Win, Keys.Oemtilde, AutoLogin);
        }

        public void Dispose()
        {
            HotKeyManager.UnbindHotkeys();

            if (browser != null)
            {
                browser.Dispose();
            }
        }

        // Auto Login ///////////////////////////////////////////////////////////////////////////////////////
        private void AutoLogin(HotkeyPressedEventArgs e)
        {
            if (!FindActiveIEByTitle())
                return;

            string title = browser.Title;
            string url = browser.Url;

            LoginsModel query = (from   login in parent.DataStore.Logins
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
        private Dictionary<Keys, Func<string>> DataPasteValues = new Dictionary<Keys, Func<string>>()
        {
            {Keys.D1, () => parent.SelectedContact.ICON},
            {Keys.D2, () => parent.SelectedContact.CMBS},
            {Keys.Q , () => parent.SelectedContact.Username},
            {Keys.W , () => parent.SelectedContact.DN},
            {Keys.A , () => parent.SelectedContact.Name},
            {Keys.S , () => parent.SelectedContact.Mobile},
            {Keys.Z , () => parent.SelectedContact.Fault.PR},
            {Keys.X , () => parent.SelectedContact.Service.Node}
        };

        private void DataPaste(HotkeyPressedEventArgs e)
        {
            string dataToPaste = DataPasteValues[e.HotkeyCombination.Key].Invoke();
            if(!String.IsNullOrEmpty(dataToPaste))
            {
                Clipboard.SetText(dataToPaste);
                SendKeys.SendWait("^(v)");
            } 
        }

        // Smart Paste ///////////////////////////////////////////////////////////////////////////////////////
        private void OnSmartPaste(HotkeyPressedEventArgs e)
        {
            if (!FindActiveIEByTitle())
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
                string data = String.Empty;
                data = FollowPropertyPath(parent.SelectedContact, query.Data).ToString();
                if (String.IsNullOrEmpty(data) && query.AltData != null)
                    data = FollowPropertyPath(parent.SelectedContact, query.AltData).ToString();
                
                if (!String.IsNullOrEmpty(data))
                    SetValueByIdOrName(element, data);
            }
        }

        private void OnBindSmartPaste(HotkeyPressedEventArgs e)
        {
            if (!FindActiveIEByTitle())
                return;

            string url = browser.Url;
            string title = browser.Title;
            string element = browser.ActiveElement.IdOrName;

            PasteBind query = (from   bind in parent.DataStore.PasteBinds
                               where  bind.Element == element &&
                                     (bind.Url == url || title.Contains(bind.Title))
                               select bind)
                               .FirstOrDefault();

            if (query == null)
            {
                query = new PasteBind(url, title, element);
                parent.DataStore.PasteBinds.Add(query);
            }

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
                PropertyInfo prop = parent.SelectedContact.Service.GetType().GetProperty(firstThree);
                prop.SetValue(parent.SelectedContact.Service, text, null);
                
            }
            else if (Char.IsLetter(text, 0))
            {
                if (Regex.IsMatch(text, @"(\b[A-Z][a-z]+(-|\s)?){2,}"))
                    parent.SelectedContact.Name = text;
                else if (Regex.IsMatch(text, @"\A[a-z]+([a-z]?[0-9]?\.?_?)*\z") || Regex.IsMatch(text, @"\A[A-Z]+([A-Z]?[0-9]?\.?_?)*\z"))
                    parent.SelectedContact.Username = text;
                else if (Regex.Matches(text, @"\w+").Count > 3)
                    parent.SelectedContact.Address.Address = text;
            }

            else if ((firstchar == "0" && textlen == 10) || (text.Substring(0, 2) == "61" && textlen == 11))
            {
                if (Regex.IsMatch(text, @"^(0|61)4\d{8}$"))
                    parent.SelectedContact.Mobile = text;
                else if (Regex.IsMatch(text, @"^(0|61)[2378]\d{8}$"))
                    parent.SelectedContact.DN = text;
            }

            else if (firstchar == "3")
            {
                if (Regex.IsMatch(text, @"\A\d\d(?i)[a-z]{2}_??\d\d\z"))
                    parent.SelectedContact.Service.Node = text;
                else if (Regex.IsMatch(text, @"\A3[1-3]-??\d{5}(-|0|\s)\d\z"))
                    parent.SelectedContact.CMBS = text;
            }

            else if (firstchar == "1" && textlen == 8)
                parent.SelectedContact.Fault.PR = text;

            else if (Regex.IsMatch(text, @"\A(1|5|8|9)\d{13}\z"))
                parent.SelectedContact.ICON = text;

            else if (Regex.Matches(text, @"\w+").Count > 3)
                parent.SelectedContact.Address.Address = text;//[Unit|Level]?([-|/]?:\d+)?\w+
            
            else
                parent.SelectedContact.Note += text;
        }

        // Misc Methods ///////////////////////////////////////////////////////////////////////////////////////
        private bool FindActiveIEByHWND()
        {
            string currentHWND = ActiveWindow.HWND().ToString();

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

        private bool FindActiveIEByTitle()
        {
            string currentTitle = Regex.Split(ActiveWindow.Title(), " - Internet Explorer")[0];

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

        public static object FollowPropertyPath(object value, string path)
        {
            Type currentType = value.GetType();

            foreach (string propertyName in path.Split('.'))
            {
                PropertyInfo property = currentType.GetProperty(propertyName);
                value = property.GetValue(value, null);
                currentType = property.PropertyType;
            }
            return value;
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
