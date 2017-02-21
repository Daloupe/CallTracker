using CallTracker.Model;
using Shortcut;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CallTracker.Helpers
{
    public partial class HotkeyController
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Auto Login ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void OnAutoLogin(HotkeyPressedEventArgs e)
        {
            AutoLogin();
        }

        private static Dictionary<string, Action<LoginsModel>> Actions = new Dictionary<string, Action<LoginsModel>>(){
            {"OPOM", TabLogin},
            {"TCP/IP QSPlus for Windows", EnterLogin},
            {"PMS", EnterLogin}
        };
 
        /// <summary>
        /// Attempts to AutoLogin. Set useCurrentBrowser to true to avoid refinding and disposing browser.
        /// </summary>
        private static void AutoLogin(bool useCurrentBrowser = false)
        {
            EventLogger.LogNewEvent(Environment.NewLine + "AutoLogin: Searching for matches");

            var title = WindowHelper.GetActiveWindowTitle();
            var _action = Actions.SkipWhile(x => !title.Contains(x.Key));
            LoginsModel query = null;
            
            if(_action.Any())
            {
                query = parent.LoginsDataStore.Logins.Where(x => title.Contains(x.Title)).FirstOrDefault();
            }
            else
            {
                if (!useCurrentBrowser)
                    if (!GetActiveBrowser())
                        return;

                _action = new Dictionary<string, Action<LoginsModel>>() { { "Browser", BrowserLogin } };
                title = browser.Title;
                var url = browser.Url;
                query = parent.LoginsDataStore.Logins.Where(x => title.Contains(x.Title) || url.Contains(x.Url)).FirstOrDefault();
            }

            if (query == null)
            {
                EventLogger.LogAndSaveNewEvent("AutoLogin Error: No matches found");
                return;
            }

            EventLogger.LogNewEvent("AutoLogin: Actioning matches");
            _action.FirstOrDefault().Value.Invoke(query);

            parent.AddAppEvent(AppEventTypes.AutoLogin);
        }

        private static void TabLogin(LoginsModel query)
        {
            SendKeys.Send(query.Username);
            SendKeys.Send("{TAB}");
            SendKeys.Send(query.Password);
        }

        private static void EnterLogin(LoginsModel query)
        {
            SendKeys.Send(query.Username);
            SendKeys.Send("{Enter}");
            SendKeys.Send(query.Password);
        }

        private static void BrowserLogin(LoginsModel query)
        {
            query.Paste(query.UsernameElement, query.Username);
            query.Paste(query.PasswordElement, query.Password);
            query.Submit(browser);

            //if (!useCurrentBrowser)
            if (browser != null)
                browser.Dispose();
        }
    }
}