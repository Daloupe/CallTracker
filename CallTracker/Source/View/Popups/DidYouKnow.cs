using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CallTracker.Source.Helpers.Type;
using ESCommon;
using ESCommon.Rtf;
using CallTracker.Helpers;

namespace CallTracker.View
{
    public partial class DidYouKnow : Form
    {
        public DidYouKnow()
        {
            InitializeComponent();
            var rtf = new RtfDocument();
            rtf.FontTable.Add(new RtfFont("Verdana"));
            rtf.FontTable.Add(new RtfFont("Gautami"));
            rtf.ColorTable.AddRange(new[] {
                new RtfColor(255,228,162),
                new RtfColor(255, 198, 0)
            });
            //var header = new RtfFormattedParagraph(new RtfParagraphFormatting(7, RtfTextAlign.Left));
            //header.Formatting.SpaceAfter = TwipConverter.ToTwip(5F, MetricUnit.Point);
            //header.AppendText(new RtfFormattedText("Tips:", RtfCharacterFormatting.Bold, 2));
            //rtf.Contents.Add(header);

            var formatting = new RtfParagraphFormatting()
            {
                FontSize = 7,
                Align = RtfTextAlign.Left,
                FontIndex = 0,
                TextColorIndex = 1,
                FirstLineIndent = -TwipConverter.ToTwip(6.0F, MetricUnit.Point),
                IndentLeft = TwipConverter.ToTwip(9.0F, MetricUnit.Point),
                IndentRight = TwipConverter.ToTwip(3.0F, MetricUnit.Point),
                SpaceAfter = TwipConverter.ToTwip(2.5F, MetricUnit.Point),
                SpaceBefore = TwipConverter.ToTwip(2.5F, MetricUnit.Point)
            };

            
            var p = new RtfFormattedParagraph(formatting);
            RtfHelpers.Parse(ref p, "- <Smart Copy> will recognize data in multiple formats. eg: <CMBS> will be detected as either 31-123456-7, 31123456 7, 3112345607, or 1123456076.");
            rtf.Contents.Add(p);

            p = new RtfFormattedParagraph(formatting);
            RtfHelpers.Parse(ref p, "- When copying information like <DN> and <CMBS>, <Smart Copy> will also infer the NBN <SIP> server and <State>.");
            rtf.Contents.Add(p);

            
            var rtfWriter = new RtfWriter();
            richTextBox1.Rtf = rtfWriter.Write(rtf);
        }

        private void PaintGrayBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(13, 83, 109)),
             0,
             0,
             ((Control)sender).Width - 1,
             ((Control)sender).Height - 1);
            //base.OnPaint(e);
        }

        private void MenuPaintGrayBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(13, 83, 109)),
             0,
             0,
             ((Control)sender).Width - 1,
             ((Control)sender).Height);
            //base.OnPaint(e);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Move Window //////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void _MainMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            Properties.Settings.Default.Main_Position = Location;
        }

        private void ok_MouseUp(object sender, MouseEventArgs e)
        {
            tipsPanel.Focus();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //e.ClickedItem.GetCurrentParent().Focus();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            tipsPanel.Focus();
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (richTextBox1.SelectionLength == 0)
                tipsPanel.Focus();
        }

        private void DidYouKnow_Load(object sender, EventArgs e)
        {
            tipsPanel.Focus();
        }
    }
}
