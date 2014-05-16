using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Shortcut;

namespace CallTracker.Helpers
{
    public static class HotKeyManager
    {
        private static Dictionary<string, HotkeyCombination> HotKeys = new Dictionary<string, HotkeyCombination>();
        private static readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();

        public static void AddOrReplaceHotkey(string _name, Modifiers _mods, Keys _keys, Action<HotkeyPressedEventArgs> _callback)
        {
            if (!HotKeys.ContainsKey(_name))
                HotKeys.Add(_name, new HotkeyCombination(_mods, _keys));
            else
                HotKeys[_name] = new HotkeyCombination(_mods, _keys);
            _hotkeyBinder.Bind(HotKeys[_name]).To(_callback);
        }

        public static void UnbindHotkeys()
        {
            foreach (var hotkey in HotKeys)
            {
                _hotkeyBinder.Unbind(hotkey.Value);
            }
        }

        public static void UnbindHotkey(string _name)
        {
            _hotkeyBinder.Unbind(HotKeys[_name]);
        }
    }
}
