using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CallTracker.View
{
    [ClassInterface(ClassInterfaceType.AutoDispatch), DefaultBindingProperty("Rtf"), 
	Description("DescriptionRichTextBox"), ComVisible(true), 
	Docking(DockingBehavior.Ask)]
    public class dbRTBox : RichTextBox
    {
        private const int WM_MOUSEACTIVATE = 0x21;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE && CanFocus && !Focused)
                Focus();

            base.WndProc(ref m);
        }

        [Bindable(true), RefreshProperties(RefreshProperties.All), 
	SettingsBindable(true), DefaultValue(""), Category("Appearance")]
        new public string Rtf
        {
            get
            {
                return base.Rtf;
            }
            set
            {
                base.Rtf = value;
            }
        }
    }
} 