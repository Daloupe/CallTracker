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
        protected Func<Point> GetPosition;
        protected Func<Size> GetSize;
        protected Action<Point> SetPosition;
        protected Action<Size> SetSize;

        protected Main MainForm;

        public SettingsFormBase()
        {
        }

        protected virtual void Init()
        {
            Location = GetPosition.Invoke();
            Size = GetSize.Invoke();

            this.Move += new System.EventHandler(this.Form_Move);
            this.Resize += new System.EventHandler(this.Form_Resize);

            MainForm = Application.OpenForms.OfType<Main>().First();
        }

        protected virtual void Form_Move(object sender, EventArgs e)
        {
            SetPosition(this.Location);
        }

        protected virtual void Form_Resize(object sender, EventArgs e)
        {
            SetSize(this.Size);
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
