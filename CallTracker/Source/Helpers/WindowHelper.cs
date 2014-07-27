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

        public static IntPtr ActivateWindowByTitle(string _title)
        {
            var prc = Process.GetProcessesByName(_title);
            if (prc.Length > 0)
            {
                SetForegroundWindow(prc[0].MainWindowHandle);
                return prc[0].MainWindowHandle;
            }
            return IntPtr.Zero;
        }

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
                public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className,  string  windowTitle);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
    }
}
