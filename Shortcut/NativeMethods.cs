using System;
using System.Runtime.InteropServices;

namespace Shortcut
{
    /// <summary>
    /// Platform Invocation methods are declared by this class.
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// Registers a system-wide hot key.
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool RegisterHotKey(IntPtr windowHandle, int hotkeyId, uint modifier, uint key);

        /// <summary>
        /// Frees a system-wide hot key previously registered by this application.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool UnregisterHotKey(IntPtr windowHandle, int hotkeyId);

        /// <summary>
        /// Sends a keystroke.
        /// </summary>
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        public const uint KEYEVENTF_KEYUP = 0x0002;
        public const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        public const uint VK_LWIN = 0x5B;
        public const uint VK_RWIN = 0x5C;
        public const uint VK_CONTROL = 0x11;
        public const uint VK_LCONTROL = 0xA2;
        public const uint VK_RCONTROL = 0xA3;
        public const uint VK_SHIFT = 0x10;
        public const uint VK_LSHIFT = 0xA0;
        public const uint VK_RSHIFT = 0xA1;
        public const uint VK_ALT = 0x12;
        public const uint VK_LALT = 0xA4;
        public const uint VK_RALT = 0xA5;
    }
}