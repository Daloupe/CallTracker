using System;
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
            var objApp = new Outlook.Application();
            Outlook.MailItem mail = null;
            mail = (Outlook.MailItem)objApp.CreateItem(Outlook.OlItemType.olMailItem);
            mail.To = "jesse.poulton@optus.com.au";
            mail.Subject = "Wingman Bug Report";
            mail.HTMLBody = _Info.Text;
            mail.Attachments.Add(@".\Data\Log.txt", Outlook.OlAttachmentType.olEmbeddeditem, 1, "Log.txt");
            mail.Display();

            Hide();
            _Info.Text = String.Empty;
        }

    }
}
