﻿using System.Windows.Forms;

namespace CallTracker.View
{
    public class BindingNavigatorIgnoreFocus : BindingNavigator
    {
        private const int WM_MOUSEACTIVATE = 0x21;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE && this.CanFocus && !this.Focused)
                this.Focus();

            base.WndProc(ref m);
        }
    }
}
