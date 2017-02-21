using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Shortcut
{
    public class HotKeyManager
    {
        internal Dictionary<string, HotkeyCombination> HotKeys;
        private readonly HotkeyBinder _hotkeyBinder;

        public HotKeyManager()
        {
            HotKeys = new Dictionary<string, HotkeyCombination>();
            _hotkeyBinder = new HotkeyBinder(this);
        }

        public void AddOrReplaceHotkey(string _name, Modifiers _mods, Keys _keys, Action<HotkeyPressedEventArgs> _callback)
        {
            try
            {
                if (!HotKeys.ContainsKey(_name))
                    HotKeys.Add(_name, new HotkeyCombination(_mods, _keys));
                else
                    HotKeys[_name] = new HotkeyCombination(_mods, _keys);
                _hotkeyBinder.Bind(HotKeys[_name]).To(_callback);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e + " on Keykey: " + _name);
            }
        }

        public void UnbindHotkeys()
        {
            foreach (var hotkey in HotKeys)
            {
                _hotkeyBinder.Unbind(hotkey.Value);
            }
        }

        public void UnbindHotkey(string _name)
        {
            _hotkeyBinder.Unbind(HotKeys[_name]);
        }

        public string GetHotkeyName(HotkeyCombination _combo)
        {
            //string name = String.Empty;
            foreach(var HotKey in HotKeys)
                if (HotKey.Value == _combo)
                    return HotKey.Key;
            return null;   
        }
    }
}
