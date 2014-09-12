using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Outlook=Microsoft.Office.Interop.Outlook;

using CallTracker.Model;

namespace CallTracker.View
{
    public partial class BugReport : Form
    {
        public BugReport()
        {
            InitializeComponent();
        }

        private void _Cancel_Click(object sender, EventArgs e)
        {
            Hide();
            _Info.Text = String.Empty;
        }

        private void _Ok_Click(object sender, EventArgs e)
        {
            EventLogger.SaveLog();
            if (!IsOutlookInstalled()) return;

            var objApp = new Outlook.Application();
            var mail = (Outlook.MailItem)objApp.CreateItem(Outlook.OlItemType.olMailItem);

            mail.To = "jesse.poulton@optus.com.au";
            mail.Subject = "Wingman Bug Report";
            mail.HTMLBody = _Info.Text;
            mail.Attachments.Add(Application.StartupPath + @"\Log.txt", Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
            mail.Display();
            
            objApp = null;
            mail = null;

            Hide();
            _Info.Text = String.Empty;
        }

        public static bool IsOutlookInstalled()
        {
            try
            {
                var type = Type.GetTypeFromCLSID(new Guid("0006F03A-0000-0000-C000-000000000046")); //Outlook.Application
                if (type == null) return false;
                var obj = Activator.CreateInstance(type);
                Marshal.ReleaseComObject(obj);
                return true;
            }
            catch (COMException)
            {
                EventLogger.LogAndSaveNewEvent("Bug Report Error: Outlook Not Detected", EventLogLevel.Status);
                MessageBox.Show(@"Unable to Send: Outlook Not Detected", @"Bug Report Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
