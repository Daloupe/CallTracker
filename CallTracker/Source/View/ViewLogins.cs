using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallTracker.View
{
    public partial class ViewLogins : SettingsFormBase
    {
        public ViewLogins()
        {
            InitializeComponent();

            GetPosition = () => Properties.Settings.Default.Logins_Position;
            GetSize = () => Properties.Settings.Default.Logins_Size;
            SetPosition = value => Properties.Settings.Default.Logins_Position = value;
            SetSize = value => Properties.Settings.Default.Logins_Size = value;

            base.Init();

            
            loginsModelBindingSource.DataSource = MainForm.Logins;
        }

    }
}
