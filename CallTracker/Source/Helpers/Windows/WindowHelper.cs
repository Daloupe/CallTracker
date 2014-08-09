using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace CallTracker.Helpers
{
    public static class WindowHelper
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public const int SW_SHOWNORMAL = 1;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

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

        public static IntPtr ActivateWindowByProcessName(string _title)
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

       // public static Point NumberOffset = new Point();
        public static void IPCCAutomation(string _number, Point _buttonOffsets)
        {
            string title = "IPCC"; //IPCC Agent Desktop for Fusion: v5.2.1 (c2)
            Point buttonOffsets = _buttonOffsets;

            IntPtr hwnd = FindHWNDByTitle(title);
            SetForegroundWindow(hwnd);
            Rect rect = new Rect();
            GetWindowRect(hwnd, ref rect);
            Console.WriteLine("{0} {1}", rect.Top, rect.Left);
            Point transfer = new Point() { X = rect.Left + buttonOffsets.X, Y = rect.Top + buttonOffsets.Y };

            Cursor.Position = transfer;
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);

            ////////////////////////////////////////////

            title = "CTI Dial Pad";
            buttonOffsets = new Point();
            string[] offsetFile = File.ReadAllLines("IPCCOffsets.txt");

            buttonOffsets.X = Convert.ToInt16(Regex.Split(offsetFile[2], ",")[1]);
            buttonOffsets.Y = Convert.ToInt16(Regex.Split(offsetFile[2], ",")[2]);

            hwnd = FindHWNDByTitle(title);
            SetForegroundWindow(hwnd);
            GetWindowRect(hwnd, ref rect);
            transfer = new Point() { X = rect.Left + buttonOffsets.X, Y = rect.Top + buttonOffsets.Y };

            Cursor.Position = transfer;
            X = Cursor.Position.X;
            Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);

            SendKeys.Send(_number);
        }
    }
}
