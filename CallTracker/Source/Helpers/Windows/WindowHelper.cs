using System;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace CallTracker.Helpers
{
    public static class WindowHelper
    {
        // P/Invoke declarations
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point pt);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_MOUSEWHEEL = 0x20a;

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

        const int CHARS = 256;
        public static string GetActiveWindowTitle()
        {
            var buff = new StringBuilder(CHARS);

            // Obtain the handle of the active window.
            var handle = GetForegroundWindow();

            // Update the controls.
            return GetWindowText(handle, buff, CHARS) > 0 ? buff.ToString() : String.Empty;
        }

        public static IntPtr GetActiveWindowHWND()
        {
            return GetForegroundWindow();
        }

        public static IntPtr FindHWNDByTitle(string wName)
        {
            var hWnd = IntPtr.Zero;
            foreach (Process pList in Process.GetProcesses())
                if (pList.MainWindowTitle.Contains(wName))
                {
                    hWnd = pList.MainWindowHandle;
                    break;
                }

            return hWnd;
        }

        public static IntPtr ActivateWindowByProcessName(string title)
        {
            var prc = Process.GetProcessesByName(title);
            if (prc.Length > 0)
            {
                SetForegroundWindow(prc[0].MainWindowHandle);
                return prc[0].MainWindowHandle;
            }
            return IntPtr.Zero;
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }
        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }

        //[DllImport("user32.dll")]
        //public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        //public struct Rect
        //{
        //    public int Left { get; set; }
        //    public int Top { get; set; }
        //    public int Right { get; set; }
        //    public int Bottom { get; set; }
        //}

        //[DllImport("user32.dll", CharSet=CharSet.Auto)]
        //public static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, IntPtr lParam);

        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className,  string  windowTitle);

        //[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        //public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        //public const int MOUSEEVENTF_LEFTUP = 0x04;
        //public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        //public const int MOUSEEVENTF_RIGHTUP = 0x10;

       //// public static Point NumberOffset = new Point();
       // public static void IPCCAutomation(string _number, Point _buttonOffsets)
       // {
       //     string title = "IPCC"; //IPCC Agent Desktop for Fusion: v5.2.1 (c2)
       //     Point buttonOffsets = _buttonOffsets;

       //     IntPtr hwnd = FindHWNDByTitle(title);
       //     SetForegroundWindow(hwnd);
       //     Rect rect = new Rect();
       //     GetWindowRect(hwnd, ref rect);
       //     Console.WriteLine("{0} {1}", rect.Top, rect.Left);
       //     Point transfer = new Point() { X = rect.Left + buttonOffsets.X, Y = rect.Top + buttonOffsets.Y };

       //     Cursor.Position = transfer;
       //     int X = Cursor.Position.X;
       //     int Y = Cursor.Position.Y;
       //     mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);

       //     ////////////////////////////////////////////

       //     title = "CTI";
       //     buttonOffsets = new Point();
       //     string[] offsetFile = File.ReadAllLines("IPCCOffsets.txt");

       //     buttonOffsets.X = Convert.ToInt16(Regex.Split(offsetFile[2], ",")[1]);
       //     buttonOffsets.Y = Convert.ToInt16(Regex.Split(offsetFile[2], ",")[2]);

       //     hwnd = FindHWNDByTitle(title);
       //     SetForegroundWindow(hwnd);
       //     rect = new Rect();
       //     GetWindowRect(hwnd, ref rect);
       //     transfer = new Point() { X = rect.Left + buttonOffsets.X, Y = rect.Top + buttonOffsets.Y };

       //     Cursor.Position = transfer;
       //     X = Cursor.Position.X;
       //     Y = Cursor.Position.Y;
       //     mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, 0, 0);

       //     SendKeys.Send(_number);
       // }
    }
}
