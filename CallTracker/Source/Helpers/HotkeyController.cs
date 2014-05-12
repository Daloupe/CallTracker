using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Input;

using Shortcut;
//using NHotkey;
//using NHotkey.WindowsForms;
using WatiN.Core;

using CallTracker.View;
using CallTracker.Model;

namespace CallTracker.Helpers
{
    class HotkeyController : IDisposable
    {
        private static IE browser;

        private HotkeyCombination SmartCopyHotkey, SmartPasteHotkey, BindSmartPasteHotkey;
        private static readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
        
        private Main parent;
        
        public static List<string> ContactProperties = new List<string>() { "Name", "Username", "DN", "Mobile", "CMBS", "ICON", "Note", "Address" };
        public static List<string> FaultProperties = new List<string>() { "PR", "INC" };
        public static List<string> ServiceProperties = new List<string>() { "Node", "AVC", "CVC", "CSA", "NNI", "GSI", "Equipment" };

        public HotkeyController(Main _parent)
        {
            parent = _parent;
            //HotkeyManager.Current.AddOrReplace("SmartCopy", Keys.Control | Keys.Alt | Keys.C, OnSmartCopy);
            //HotkeyManager.Current.AddOrReplace("SmartPaste", Keys.Control | Keys.Alt | Keys.V, OnSmartPaste);
            //HotkeyManager.Current.AddOrReplace("SmartPasteBind", Keys.Control | Keys.Alt | Keys.Shift | Keys.V, OnBindSmartPaste);
            // HotKeys Init
            //_hotkeyBinder = new HotkeyBinder();


            SmartCopyHotkey = new HotkeyCombination(Modifiers.Win, Keys.C);
            SmartPasteHotkey = new HotkeyCombination(Modifiers.Win, Keys.V);
            BindSmartPasteHotkey = new HotkeyCombination(Modifiers.Win | Modifiers.Shift, Keys.B);

            _hotkeyBinder.Bind(SmartCopyHotkey).To(OnSmartCopy);
            _hotkeyBinder.Bind(SmartPasteHotkey).To(OnSmartPaste);
            _hotkeyBinder.Bind(BindSmartPasteHotkey).To(OnBindSmartPaste);
        }

        public void Dispose()
        {
            _hotkeyBinder.Unbind(SmartCopyHotkey);
            _hotkeyBinder.Unbind(SmartPasteHotkey);
            _hotkeyBinder.Unbind(BindSmartPasteHotkey);


            if (browser != null)
            {
                //browser.AutoClose = false;
                browser.Dispose();
            }
        }

        private void OnSmartPaste()//object sender, HotkeyEventArgs e)
        {
            //string oldClip = Clipboard.GetText();
            //Clipboard.Clear();

            Settings.AttachToBrowserTimeOut = 10;
            Settings.WaitUntilExistsTimeOut = 240;
            Settings.WaitForCompleteTimeOut = 240;
            
            if (!Browser.Exists(typeof(IE), Find.By("hwnd", ActiveWindow.HWND().ToString())))
                return;

            browser = Browser.AttachToNoWait<IE>(Find.By("hwnd", ActiveWindow.HWND().ToString()));         

            string url = browser.Url;
            string title = browser.Title;
            string element = browser.ActiveElement.IdOrName;


            PasteBind query = (from bind in parent.PasteBinds
                               where bind.Element == element &&
                                      bind.Title == title &&
                                      bind.Url == url
                               select bind).FirstOrDefault();
            if (query != null)
            {
                //PropertyInfo prop2 = parent.SelectedContact.GetType().GetProperty("Name");
                //Console.WriteLine(prop2.IsDefined(typeof(string), true));
                Console.WriteLine("yes");
                PropertyInfo prop;
                object dataValue = new object();
                //object model = new object();
                if (ContactProperties.Contains(query.Data))
                {
                    prop = parent.SelectedContact.GetType().GetProperty(query.Data);
                    dataValue = prop.GetValue(parent.SelectedContact, null);
                }
                else if (ServiceProperties.Contains(query.Data))
                {
                    prop = parent.SelectedContact.Service.GetType().GetProperty(query.Data);
                    dataValue = prop.GetValue(parent.SelectedContact.Service, null);
                }
                else if (FaultProperties.Contains(query.Data))
                {
                    prop = parent.SelectedContact.Fault.GetType().GetProperty(query.Data);
                    dataValue = prop.GetValue(parent.SelectedContact.Fault, null);
                }
                //PropertyInfo prop = model.GetType().GetProperty(query.Data);
                //string dataValue = prop.GetValue(parent.SelectedContact).ToString();

                if(dataValue != null)
                    Clipboard.SetText(dataValue.ToString());
                SendKeys.Send("^(v)");
            }
            //if(!String.IsNullOrEmpty(oldClip))
              //  Clipboard.SetText(oldClip);
            //SendKeys.Flush();
        }

        private void OnBindSmartPaste()//object sender, HotkeyEventArgs e)
        {
            Settings.AttachToBrowserTimeOut = 10;
            Settings.WaitUntilExistsTimeOut = 240;
            Settings.WaitForCompleteTimeOut = 240;

            if (!Browser.Exists(typeof(IE), Find.By("hwnd", ActiveWindow.HWND().ToString())))
                return;

            browser = Browser.AttachToNoWait<IE>(Find.By("hwnd", ActiveWindow.HWND().ToString()));

            string url = browser.Url;
            string title = browser.Title;
            string element = browser.ActiveElement.IdOrName;

            PasteBind query = (from bind in parent.PasteBinds
                               where bind.Element == element &&
                                    (bind.Title == title ||
                                     bind.Url == url)
                               select bind).FirstOrDefault();

            if (query == null)
            {
                query = new PasteBind(url, title, element);
                parent.PasteBinds.Add(query);
            }
            ((BindSmartPasteForm)Main.ShowSettingsForm<BindSmartPasteForm>()).UpdateFields(query);
        }

        private void OnSmartCopy()//object sender, HotkeyEventArgs e)
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
    }
}
