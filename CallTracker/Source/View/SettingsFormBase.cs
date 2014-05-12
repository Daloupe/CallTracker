using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

using CallTracker.Model;

namespace CallTracker.View
{
    public partial class SettingsFormBase : Form
    {
        public SettingsFormBase()
        {
        }

        protected virtual void Init()
        {
            Location = Properties.Settings.Default.ViewSmartPasteBinds_Position;
            Size = Properties.Settings.Default.ViewSmartPasteBinds_Size;

            this.Move += new System.EventHandler(this.Form_Move);
            this.Resize += new System.EventHandler(this.Form_Resize);
        }

        protected virtual void Form_Move(object sender, EventArgs e)
        {
            Properties.Settings.Default.ViewSmartPasteBinds_Position = this.Location;
        }

        protected virtual void Form_Resize(object sender, EventArgs e)
        {
            Properties.Settings.Default.ViewSmartPasteBinds_Size = this.Size;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SettingsFormBase
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "SettingsFormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Move += new System.EventHandler(this.Form_Move);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.ResumeLayout(false);

        }

    }
}
