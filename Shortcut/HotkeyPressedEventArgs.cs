using System;

namespace Shortcut
{
    /// <summary>
    /// Provides data for the <see cref="HotkeyWindow.HotkeyPressed"/> event.
    /// </summary>
    public class HotkeyPressedEventArgs : EventArgs
    {
        /// <summary>
        /// The system-wide hot key pressed.
        /// </summary>
        public HotkeyCombination HotkeyCombination { get; private set; }

        /// <summary>
        /// The name of the hot key.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyPressedEventArgs"/> class.
        /// </summary>
        public HotkeyPressedEventArgs(HotkeyCombination hotkeyCombination, string _name)
        {
            HotkeyCombination = hotkeyCombination;
            Name = _name;
        }
    }
}
