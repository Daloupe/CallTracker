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