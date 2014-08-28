using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;

using CallTracker.View;
using CallTracker.Helpers;

namespace CallTracker
{
    static class Program
    {
        public static PrivateFontCollection Fonts;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var createdNew = true;
            using (var mutex = new Mutex(true, "CallTracker", out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Fonts = new PrivateFontCollection();
                    if (File.Exists("Fonts\\OptusVoiceBETA-Bold.ttf"))
                        Fonts.AddFontFile("Fonts\\OptusVoiceBETA-Bold.ttf");

                    if (File.Exists("Fonts\\trade-gothic-lt-1361519976.ttf"))
                        Fonts.AddFontFile("Fonts\\trade-gothic-lt-1361519976.ttf");

                    var splash = new SplashScreen();
                    //Splash._Version.Text = "Version " + Properties.Settings.Default.Version;
                    splash.Show();
                    Application.DoEvents();
                    Application.Run(new Main(splash));
                }
                else
                {
                    var current = Process.GetCurrentProcess();
                    foreach (var process in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (process.Id != current.Id)
                        {
                            WindowHelper.SetForegroundWindow(process.MainWindowHandle);
                            break;
                        }
                    }
                }
            }
        }
    }
}
