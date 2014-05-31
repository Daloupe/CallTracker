using System;

namespace Shortcut
{
    /// <summary>
    /// Used to define the target of a <see cref="HotkeyCombination"/> binding.
    /// </summary>
    public class HotkeyCallback
    {
        /// <summary>
        /// The underlying callback.
        /// </summary>
        private Action<HotkeyPressedEventArgs> _callback;

        /// <summary>
        /// Indicates that the <see cref="HotkeyCombination"/> should be bound to the specified
        /// <paramref name="callback"/>.
        /// </summary>
        public void To(Action<HotkeyPressedEventArgs> callback)
        {
            if (callback == null) 
                throw new ArgumentNullException("callback");
            
            _callback = callback;
        }

        /// <summary>
        /// Invoke the callback.
        /// </summary>
        public void Invoke(HotkeyPressedEventArgs e)
        {
            _callback.Invoke(e);
        }
    }
}