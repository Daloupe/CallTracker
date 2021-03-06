﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Shortcut
{
    /// <summary>
    /// Manages <see cref="HotkeyCombination"/> bindings.
    /// </summary>
    public class HotkeyBinder
    {
        /// <summary>
        /// Invisible window used to look-out for Windows messages posted to the application that indicate
        /// that a registered system-wide hot key was pressed.
        /// </summary>
        private readonly HotkeyWindow _hotkeyWindow;// = new HotkeyWindow();

        /// <summary>
        /// Internal container used to map pressed system-wide hot keys to their bound callbacks.
        /// </summary>
        private readonly IDictionary<HotkeyCombination, HotkeyCallback> _hotkeyCallbacks = new Dictionary<HotkeyCombination, HotkeyCallback>();

        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyBinder"/> class.
        /// </summary>
        public HotkeyBinder(HotKeyManager _hotkeymanager)
        {
            _hotkeyWindow = new HotkeyWindow(_hotkeymanager);
            _hotkeyWindow.HotkeyPressed += OnHotkeyPressed;
        }

        /// <summary>
        /// Creates a binding.
        /// </summary>
        public HotkeyCallback Bind(Modifiers modifier, Keys key)
        {
            return Bind(new HotkeyCombination(modifier, key));
        }
        
        /// <summary>
        /// Creates a binding for the specified <paramref name="hotkeyCombination"/>.
        /// </summary>
        public HotkeyCallback Bind(HotkeyCombination hotkeyCombination)
        {
            if (hotkeyCombination == null) throw new ArgumentNullException("hotkeyCombination");

            HotkeyCallback callback = new HotkeyCallback();

            StoreHotkeyCombinationInDictionary(hotkeyCombination, callback);
            RegisterHotkeyCombination(hotkeyCombination);

            return callback;
        }

        /// <summary>
        /// Removes the binding for the specified <paramref name="hotkeyCombination"/>.
        /// </summary>
        public void Unbind(HotkeyCombination hotkeyCombination)
        {
            RemoveHotkeyCombinationFromDictionary(hotkeyCombination);
            UnregisterHotkeyCombination(hotkeyCombination);
        }

        /// <summary>
        /// Stores the specified <paramref name="hotkeyCombination"/> and <paramref name="callback"/>
        /// in the internal container after performing necessary validation.
        /// </summary>
        private void StoreHotkeyCombinationInDictionary(HotkeyCombination hotkeyCombination, HotkeyCallback callback)
        {
            if (_hotkeyCallbacks.ContainsKey(hotkeyCombination)) 
                throw new HotkeyAlreadyBoundException("This HotkeyCombination has already been bound: " + hotkeyCombination.Modifier + hotkeyCombination.Key);

            _hotkeyCallbacks.Add(hotkeyCombination, callback);
        }

        /// <summary>
        /// Removes the specified <paramref name="hotkeyCombination"/> and corresponding 
        /// <see cref="HotkeyCallback"/> from the internal container after performing necessary validation.
        /// </summary>
        private void RemoveHotkeyCombinationFromDictionary(HotkeyCombination hotkeyCombination)
        {
            if (_hotkeyCallbacks.ContainsKey(hotkeyCombination) == false)
                throw new HotkeyNotBoundException("This HotkeyCombination was never bound");

            _hotkeyCallbacks.Remove(hotkeyCombination);
        }

        /// <summary>
        /// Called when any system-wide hot key registered by this application is pressed.
        /// </summary>
        private void OnHotkeyPressed(object sender, HotkeyPressedEventArgs e)
        {
            var callback = _hotkeyCallbacks[e.HotkeyCombination];


            if ((e.HotkeyCombination.Modifier & Modifiers.Win) > 0)
            {
                //Console.WriteLine("Releasing Win");
                NativeMethods.keybd_event((byte) NativeMethods.VK_LWIN, 0, NativeMethods.KEYEVENTF_KEYUP, 0);
            }
            if ((e.HotkeyCombination.Modifier & Modifiers.Control) > 0)
            {
                //Console.WriteLine("Releasing Control");
                NativeMethods.keybd_event((byte) NativeMethods.VK_LCONTROL, 0, NativeMethods.KEYEVENTF_KEYUP, 0);
            }
            if ((e.HotkeyCombination.Modifier & Modifiers.Shift) > 0)
            {
                //Console.WriteLine("Releasing Shift");
                NativeMethods.keybd_event((byte) NativeMethods.VK_LSHIFT, 0, NativeMethods.KEYEVENTF_KEYUP, 0);
            }
            if ((e.HotkeyCombination.Modifier & Modifiers.Alt) > 0)
            {
                //Console.WriteLine("Releasing Alt");
                NativeMethods.keybd_event((byte) NativeMethods.VK_LALT, 0, NativeMethods.KEYEVENTF_KEYUP, 0);
            }

            NativeMethods.keybd_event((byte)e.HotkeyCombination.Key, 0, NativeMethods.KEYEVENTF_KEYUP, 0);
            callback.Invoke(e);
        }

        /// <summary>
        /// Register a system-wide <see cref="HotkeyCombination"/>.
        /// </summary>
        /// <param name="hotkeyCombination"></param>
        private void RegisterHotkeyCombination(HotkeyCombination hotkeyCombination)
        {
            bool success =
                NativeMethods.RegisterHotKey(
                    _hotkeyWindow.Handle, hotkeyCombination.GetHashCode(), (uint) hotkeyCombination.Modifier, (uint) hotkeyCombination.Key);

            if (success == false)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        /// <summary>
        /// Free a system-wide <see cref="HotkeyCombination"/> previously registered.
        /// </summary>
        /// <param name="hotkeyCombination"></param>
        private void UnregisterHotkeyCombination(HotkeyCombination hotkeyCombination)
        {
            bool success =
                NativeMethods.UnregisterHotKey(
                    _hotkeyWindow.Handle, hotkeyCombination.GetHashCode());

            if (success == false)
                throw new HotkeyNotBoundException(Marshal.GetLastWin32Error());
        }

        /// <summary>
        /// Indicates whether a <see cref="HotkeyCombination"/> has already been bound
        /// either by this application or another running application.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the <see cref="HotkeyCombination"/> has not been previously bound and is 
        /// available for binding; otherwise, <c>false</c>.
        /// </returns>
        public bool IsHotkeyAlreadyBound(HotkeyCombination hotkeyCombination)
        {
            bool success = 
                NativeMethods.RegisterHotKey(
                    _hotkeyWindow.Handle, hotkeyCombination.GetHashCode(), (uint) hotkeyCombination.Modifier, (uint) hotkeyCombination.Key);
            
            if (success == false)
                return true;

            NativeMethods.UnregisterHotKey(_hotkeyWindow.Handle, hotkeyCombination.GetHashCode());
            return false;
        }
    }
}