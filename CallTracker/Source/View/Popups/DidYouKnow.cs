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
using System.Windows.Forms.VisualStyles;
using CallTracker.Source.Helpers.Type;
using ESCommon;
using ESCommon.Rtf;
using CallTracker.Helpers;

using RichTextBoxLinks;

namespace CallTracker.View
{
    public partial class DidYouKnow : Form
    {
        private readonly RtfDocument _rtf;
        private readonly RtfParagraphFormatting _formatting;
        private readonly RtfWriter _rtfWriter;

        public DidYouKnow()
        {
            InitializeComponent();

            _rtf = new RtfDocument();
            _rtf.FontTable.Add(new RtfFont("Verdana"));
            _rtf.FontTable.Add(new RtfFont("Gautami"));
            _rtf.ColorTable.AddRange(new[] {
                new RtfColor(255,228,162),
                new RtfColor(255, 198, 0)
            });

            _formatting = new RtfParagraphFormatting()
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

            _rtfWriter = new RtfWriter();

            SelectSlide();
        }

        private void SelectSlide()
        {
            var slide = TipSlides[Properties.Settings.Default.TipsPosition];
            heading.Text = slide.Heading;
            subHeading.Text = slide.SubHeading;
            var p = new RtfFormattedParagraph(_formatting);
            foreach (var tip in slide.Tips)
            {
                RtfHelpers.Parse(ref p, tip.Tip);
                p.AppendParagraph();
            }
            _rtf.Contents.Add(p);
            richTextBox1.Rtf = _rtfWriter.Write(_rtf);

            var linkPos = 0;
            for(var index = 0; index < slide.Tips.Count; ++index)
            {
                if (String.IsNullOrEmpty(slide.Tips[index].Example)) continue;
                linkPos += Convert.ToInt32(slide.Tips[index].TipLength) + (10*index);
                richTextBox1.InsertLink("Example", index.ToString(), linkPos);
            }
            _rtf.Contents.Clear();
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            var p = new RtfFormattedParagraph(_formatting);
            RtfHelpers.Parse(ref p, TipSlides[Properties.Settings.Default.TipsPosition].Tips[Convert.ToInt32(e.LinkText.Split('#')[1])].Example);

            _rtf.Contents.Add(p);
            exampleRichTextBox.Rtf = _rtfWriter.Write(_rtf);
            _rtf.Contents.Clear();
        }

        private void prevTip_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TipsPosition - 1 < 0) return;
            Properties.Settings.Default.TipsPosition -= 1;
            exampleRichTextBox.Clear();
            SelectSlide();
        }

        private void nextTip_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TipsPosition + 1 > TipSlides.Count - 1) return;
            Properties.Settings.Default.TipsPosition += 1;
            exampleRichTextBox.Clear();
            SelectSlide();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Events ///////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ok_MouseUp(object sender, MouseEventArgs e)
        {
            tipsHeadingPanel.Focus();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            tipsHeadingPanel.Focus();
        }

        private void DidYouKnow_Load(object sender, EventArgs e)
        {
            tipsHeadingPanel.Focus();
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
            //Properties.Settings.Default.Main_Position = Location;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Borders //////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Slides ///////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static List<TipSlide> TipSlides = new List<TipSlide>
        {
            new TipSlide("Smart Copy - Win+C", "Analyzes the selected text and copies it in to the appropriate field.",
                new List<TipModel>
                {
                    new TipModel("- <Smart Copy> will recognize data in multiple formats. ", "- <CMBS> will be detected as either 31-123456-7, 31123456 7, 3112345607, or 1123456076."),
                    new TipModel("- When copying information like <DN> and <CMBS>, <Smart Copy> will also infer the NBN <SIP> server and <State>.")
                }),
            new TipSlide("Smart Paste - Win+V", "Pastes the most appropriate data depending on where you want to paste.",
                new List<TipModel>
                {
                    new TipModel("- <Smart Paste> picks the most relevant data based on what is available, and which product you've selected. ", "- The <ICON> Service No. field will paste <Username> only if it doesn't have <DN>. Vice Versa if the product is <ONC> or <NVF>"),
                    new TipModel("- <Smart Paste> will paste data in the appropriate format. ", "- <CMBS> will paste as 31123456 7 into <IFMS>, and 3112345607 into <ICON>."),
                    new TipModel("- Doesn't yet work in Chrome, or IE pages that use a Chrome Frame like Nexus and the PR Templates, but it will work in <MAD>!")
                })
        };
    }

    public class TipSlide
    {
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public List<TipModel> Tips { get; set; }

        public TipSlide(string heading, string subHeading, List<TipModel> tips)
        {
            Heading = heading;
            SubHeading = subHeading;
            Tips = tips;
        }
    }

    public class TipModel
    {
        public string Tip { get; set; }
        public int TipLength { get; set; }
        public string Example { get; set; }

        public TipModel(string tip, string example = "")
        {
            Tip = tip;
            if (!String.IsNullOrEmpty(example))
            {
                var boldTags = 0;
                if(Tip.Contains('<'))
                    boldTags = (Tip.Split('<').Count() - 1)*2;

                Example = example; 
                TipLength = Tip.Length - boldTags;
            }
            else
            {
                Example = String.Empty;
            }
        }
    }
}
