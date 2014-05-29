using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace CallTracker.Helpers
{
    public static class WindowHelper
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static string GetActiveWindowTitle()
        {
            int chars = 256;
            StringBuilder buff = new StringBuilder(chars);

            // Obtain the handle of the active window.
            IntPtr handle = GetForegroundWindow();

            // Update the controls.
            if (GetWindowText(handle, buff, chars) > 0)
            {
               return buff.ToString();
               //MessageBox.Show(handle.ToString());
            }

            return String.Empty;
        }

        public static IntPtr GetActiveWindowHWND()
        {
            return GetForegroundWindow();
        }

        public static IntPtr FindHWNDByTitle(string _wName)
        {
            IntPtr hWnd = IntPtr.Zero;
            foreach (Process pList in Process.GetProcesses())
                if(pList.MainWindowTitle.Contains(_wName))
                    hWnd = pList.MainWindowHandle;
            
            return hWnd;
        }
    }
}
