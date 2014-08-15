using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

using CallTracker.View;
using CallTracker.Helpers;

namespace CallTracker
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew = true;
            SplashScreen Splash;
            using (Mutex mutex = new Mutex(true, "CallTracker", out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Splash = new SplashScreen();
                    //Splash._Version.Text = "Version " + Properties.Settings.Default.Version;
                    Splash.Show();
                    Application.DoEvents();
                    Application.Run(new Main(Splash));
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcessesByName(current.ProcessName))
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
