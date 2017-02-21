using System;
using System.Drawing;
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
        internal static PrivateFontCollection Fonts;
        //internal static Font Optus40;
        //internal static Font Optus20;
        //internal static Font Optus18;
        //internal static Font TradeGothic12;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var createdNew = true;
            using (var mutex = new Mutex(true, "Wingman", out createdNew))
            {
                if (createdNew)
                {
                    Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException); //it must be before Application.Run
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    Fonts = new PrivateFontCollection();
                    
                        if (File.Exists("Data\\Fonts\\OptusVoiceBETA-Bold.ttf"))
                        {
                            Fonts.AddFontFile("Data\\Fonts\\OptusVoiceBETA-Bold.ttf");
                            //Optus40 = new Font(fonts.Families[0], 40, FontStyle.Bold);
                            //Optus20 = new Font(fonts.Families[0], 20, FontStyle.Bold);
                            //Optus18 = new Font(fonts.Families[0], 18, FontStyle.Bold);
                        }

                        if (File.Exists("Data\\Fonts\\trade-gothic-lt-1361519976.ttf"))
                        {
                            Fonts.AddFontFile("Data\\Fonts\\trade-gothic-lt-1361519976.ttf");
                            //TradeGothic12 = new Font(fonts.Families[1], 12, FontStyle.Regular);
                        }
                    

                    if (File.Exists(@".\Change Log.txt"))
                        using (var file = new StreamReader(@".\Change Log.txt"))
                            Properties.Settings.Default.Version = file.ReadLine();

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

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger.Log(e.Exception.ToString());
        }

        public static class Logger
        {
            public static void Log(string message)
            {
                File.AppendAllText(@".\ExceptionLog.txt", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ":\t" + message + Environment.NewLine);
            }
        }
    }
}
