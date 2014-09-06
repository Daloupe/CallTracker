using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CallTracker.Source.Helpers.Type;
using ESCommon;
using ESCommon.Rtf;
using CallTracker.Helpers;

//using RichTextBoxLinks;

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

            var fontCount = Program.Fonts.Families.Length;
            if (fontCount > 0)
                heading.Font = new Font(Program.Fonts.Families[0], 40, FontStyle.Bold);

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

            richTextBox1.MouseWheel += richTextBox1_MouseWheel;
        }

        void richTextBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                SendMessage(richTextBox1.Handle, WM_VSCROLL, (IntPtr)SB_LINEDOWN, IntPtr.Zero);// Scrolls down
            }
            else
            {
                SendMessage(richTextBox1.Handle, WM_VSCROLL, (IntPtr)SB_LINEUP, IntPtr.Zero);// Scrolls up
            }
        }

        private void SelectSlide()
        {
            WindowHelper.SuspendDrawing(panel1);
            examplePanel.Hide();
            tipsPanel.Height = 161;
            var slide = TipSlides[Properties.Settings.Default.TipsPosition];
            heading.Text = slide.Heading;
            //subHeading.Text = slide.SubHeading;
            var p = new RtfFormattedParagraph(_formatting);
            
            foreach(var tip in slide.Tips)
            {
                RtfHelpers.Parse(ref p, tip.Tip);
                p.AppendParagraph();
            }
            _rtf.Contents.Add(p);
            richTextBox1.Rtf = _rtfWriter.Write(_rtf);

            var linkPos = 0;
            var split = richTextBox1.Text.Split('\n');
            for(var index = 0; index < slide.Tips.Count; ++index)
            {
                linkPos += split[index].Length;
                if (!String.IsNullOrEmpty(slide.Tips[index].Example))
                {
                    richTextBox1.InsertLink("Example", index.ToString(), linkPos);
                    linkPos += 10;
                }
                else
                    linkPos += 1;
            }
            _rtf.Contents.Clear();
            WindowHelper.ResumeDrawing(panel1);
        }

        private int _currentExample = -1;
        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            var index = Convert.ToInt32(e.LinkText.Split('#')[1]);
            WindowHelper.SuspendDrawing(panel1);
            if (_currentExample == index)
            {
                examplePanel.Hide();
                tipsPanel.Height = 161;
                _currentExample = -1;
            }
            else
            {
                var p = new RtfFormattedParagraph(_formatting);
                RtfHelpers.Parse(ref p, TipSlides[Properties.Settings.Default.TipsPosition].Tips[index].Example);

                _rtf.Contents.Add(p);
                exampleRichTextBox.Rtf = _rtfWriter.Write(_rtf);
                _rtf.Contents.Clear();
                examplePanel.Show();
                tipsPanel.Height = 114;
                _currentExample = index;
            }
            WindowHelper.ResumeDrawing(panel1);     
        }

        private void prevTip_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TipsPosition - 1 < 0) return;
            Properties.Settings.Default.TipsPosition -= 1;
            exampleRichTextBox.Clear();
            _currentExample = -1;
            SelectSlide();
            SendMessage(richTextBox1.Handle, WM_VSCROLL, (IntPtr)SB_TOP, IntPtr.Zero);
        }

        private void nextTip_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TipsPosition + 1 > TipSlides.Count - 1) return;
            Properties.Settings.Default.TipsPosition += 1;
            exampleRichTextBox.Clear();
            _currentExample = -1;
            SelectSlide();
            SendMessage(richTextBox1.Handle, WM_VSCROLL, (IntPtr)SB_TOP, IntPtr.Zero);
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
            richTextBox1.Focus();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Focus();
        }

        private void DidYouKnow_Load(object sender, EventArgs e)
        {
            richTextBox1.Focus();
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

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        uint WM_VSCROLL = 0x115;
        private const uint SB_LINEUP = 0;
        private const uint SB_LINEDOWN = 1;
        private const uint SB_PAGEUP = 2;
        private const uint SB_PAGEDOWN = 3;
        private const uint SB_TOP = 6;
        private const uint SB_BOTTOM = 7;
        private const uint SB_ENDSCROLL = 8;

        

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
            new TipSlide("Overview",
                new List<TipModel>
                {
                    new TipModel("- <Wingman> works by always trying to hand you the best tool for the job, reducing system friction and the need for Notepad."), 
                    new TipModel("- <Smart Copy>(|2<Win+C>|1) copies your selection and pops it straight in to the appropriate field. ", "- Selecting \"0394811234\" and pressing |2<Win+C>|1 will copy it straight into the <DN> field in <Wingman>."),
                    new TipModel("- <Smart Paste>(|2<Win+V>|1) looks at where you're trying to paste and pastes in the most appropriate data. ", "- Clicking on the \"Account Number\" field in ICON and pressing |2<Win+V>|1 will paste in the <CMBS> number, or ICON if <Wingman> doesn't have it."),
                    new TipModel("- <Auto Fill>(|2<Win+Ctrl+V>|1) looks at what page you have active, and triggers all the <Smart Pastes> it knows for that page. ", "- Pressing |2<Win+Ctrl+V>|1 in \"IFMS Create\" will fill all the fields that <Wingman> has data for."),
                    new TipModel("- <Grid Links>(|2<Win+Numpad>|1) will jump straight to the desired system. A different system assigned to each number on the Numpad. ", "- Pressing |2<Win+Numpad2>|1 will activate IFMS and bring it to the front."),
                    new TipModel("- <Monitor IPCC> will tell <Wingman> when your phone state changes. This gives you realtime estimates of your KPIs, lets you keep track of how long you've been in a call state, and resets <Wingmans> fields when a call pops in.")
                }),
            new TipSlide("Smart Copy - Win+C",
                new List<TipModel>
                {
                    new TipModel("- <Smart Copy>(|2<Win+C>|1) copies your selected text in to the appropriate field."),
                    new TipModel("- It will recognize data in multiple formats. ", "- <CMBS> will be detected as either \"31-123456-7\", \"31123456 7\", \"3112345607\", or \"1123456076\"."),
                    new TipModel("- <Smart Copy> won't change what is currently in the copy buffer. ", "- If i |2Ctrl+C|1 \"Some text\", then |2<Win+C>|1 \"61394811234\", pressing |2Ctrl+V|1 will still paste \"Some text\"."),
                    new TipModel("- When copying information like <DN> and <CMBS>, <Smart Copy> will also infer the NBN <SIP> server and <State>.")
                }),
            new TipSlide("Smart Paste - Win+V",
                new List<TipModel>
                {
                    new TipModel("- <Smart Paste>(|2<Win+V>|1) pastes the most appropriate data depending on where you want to paste."),
                    new TipModel("- It picks the most relevant data based on what is available, and which product you've selected. ", "- Pressing |2<Win+V>|1 in ICON's \"Service Number\" field will paste <Username> only if <Wingman> doesn't have <DN>. Vice Versa if the product is <ONC> or <NVF>."),
                    new TipModel("- It will paste data in the appropriate format. ", "- <CMBS> will paste as \"31123456 7\" into <IFMS>, and \"3112345607\" into <ICON>."),
                    new TipModel("- Doesn't yet work in Chrome, or IE pages that use a Chrome Frame like Nexus and the PR Templates, but it will work in MAD!")
                }),
            new TipSlide("Auto Fill - Win+Ctrl+V",
                new List<TipModel>
                {
                    new TipModel("- <Auto Fill>(|2<Win+Ctrl+V>|1) performs all known Smart Pastes on a page."),
                    new TipModel("- Useful for systems with lots of required fields eg IFMS.")
                }),
            new TipSlide("Call History",
                new List<TipModel>
                {
                    new TipModel("- <Call History> keeps track of previous calls, filtered by date."),
                    new TipModel("- Calls can be sorted by <Outcome>, <Time>, <Name>, or <Flagged>."),
                    new TipModel("- Calls are archived after 7 days - only <Symptom>, <Outcome>, <Action>, <Affected Service Type>, <Note>, and <Daily Stats> are kept."),
                    new TipModel("- Calls are deleted after 31 days."),
                    new TipModel("- Can be access from <Wingman> > <Call History>.")
                }),
            new TipSlide("GridLinks - Win+NumPad",
                new List<TipModel>
                {
                    new TipModel("- <GridLinks>(|2<Win+Numpad>|1) jumps straight to the desired system so you don't need to track it down from the taskbar."),
                    new TipModel("- Each number on the NumPad is assigned a different system."),
                    new TipModel("- |2<Win+Ctrl+Numpad>|1 will initiate a <GridLinks Search> which will also attempt to search the selected system."),
                    new TipModel("- System assignment can be changed from <Wingman> > <Settings> > <Grid Links>.")
                }),
            new TipSlide("IPCC Monitor",
                new List<TipModel>
                {
                    new TipModel("- <IPCC Monitor> keeps track of call state changes."),
                    new TipModel("- When a new call pops in, it will automatically create a new record and prefill it with IPCC call data."),
                    new TipModel("- You can see how long you have spent in a call state in the bottom right hand corner of <Wingman>."),
                    new TipModel("- Clicking this timer will give you the <Monitor IPCC> option.")
                }),
            new TipSlide("Context Menus",
                new List<TipModel>
                {
                    new TipModel("- <Wingman> has a lot of functions, but in order to simplfy the interface they are tucked away in context menus."),
                    new TipModel("- Fields with context menus will have an arrow. Right click the field, or click on the arrow to open it up."),
                    new TipModel("- The <DN> and <Mobile> context menus have the <Dial> option, which will pop the number into IPCC for you."),
                    new TipModel("- Right clicking the <Note> field will let you generate ICON and PR templates that have been prefilled with data you've collected."),
                    new TipModel("- Clicking a menu item with the Search Glass icon will perform a <Search>.")
                }),
            new TipSlide("Auto Search",
                new List<TipModel>
                {
                    new TipModel("- When a field is first filled, <Auto Search> will inititate a <Search>. It does so silently - It won't bring the searched system to the front. This means when you get around to needing a system, it should already have the customers infomation loaded."),
                    new TipModel("- Each system will only be searched once per call. ", "- I <Smart Copy> a DN, <Auto Search> searches the <DN> in SCAMPS. I then <Smart Copy> a Username, SCAMPS won't <Auto Search> again (But UNMT still will!)."),
                    new TipModel("- The <Ignore Active Window> option will prevent Auto Search from searching in the window you have focussed."),
                    new TipModel("- The <Open New If None Found> option tells Wingman to open up a new IE window if you don't already have that system open."),
                    new TipModel("- Auto Search and its options can be found in <Wingman> > <Settings> > <Auto Search>.")
                }),
            new TipSlide("Resources Menu",
                new List<TipModel>
                {
                    new TipModel("- The <Resources Menu> is context sensitive - it's items change based on the product you select in this list."),
                    new TipModel("- The departments in the <Numbers To Know> menu will change with the selected product. Hovering over a department will give you their contact numbers, and opening times."),
                    new TipModel("- Clicking on a department will put the number into IPCC, and Prefill the call data section."),
                    new TipModel("- <Rateplans> provides a list of <CMBS> changes codes. Once you open the window, you can just type the product code to start searching. New ratecodes can be added to the last row"),
                    new TipModel("- You can add your own context sensitive <Bookmarks> and <Systems> in their relative menus.")         
                }),
            new TipSlide("Auto Login - Win+`",
                new List<TipModel>
                {
                    new TipModel("- <Auto Login>(|2<Win+`>|1) will detect which system you're trying to log into, and pop your details in."),
                    new TipModel("- You can update your logins from <Wingman> > <Settings> > <Logins>.")
                }),
            new TipSlide("Data Paste - Ctrl+Shift+",
                new List<TipModel>
                {
                    new TipModel("- The most common fields can also be pasted directly with these hotkeys. These are useful for pasting into systems that can't be bound to. "),
                    new TipModel("- They are assigned to 1,2,Q,W,A,S,Z,X.  ", "- Pressing |2<Ctrl+Shift+Q>|1 will paste <Username>"),
                    new TipModel("- Hover over the main data fields to see their hotkey.")
                }),
            new TipSlide("Daily Stats",
                new List<TipModel>
                {
                    new TipModel("- <Daily Stats> gives you an estimate of your KPI's, as long as <IPCC Monitor> is on."),
                    new TipModel("- Stats can be viewed from <Wingman> > <View Stats>.")
                }),
            new TipSlide("Smart Paste Bind - Win+Shift+V",
                new List<TipModel>
                {
                    new TipModel("- Allows you to setup which data is bound to which field."),
                    new TipModel("- Click on the desired field, then hit the Hotkey. Most of the fields will prefill, just type in which data you want it to paste. The help button in the Smart Paste Bind form will tell you what you can type into the data field."),
                    new TipModel("- If the Bind Smart Paste form doens't pop up, it means that page can't be bound to."),
                    new TipModel("- You can view all binds from <Wingman> > <Settings> > <Advanced> > <Smart Paste Binds>.")
                }),
            new TipSlide("Database Editor",
                new List<TipModel>
                {
                    new TipModel("- All data that Wingman uses can be changed eg If a department changes their External contact number, you can update it here."),
                    new TipModel("- If you change something and things stop working, just copy the Data\\Resources.bin from a colleague."),
                    new TipModel("- <Database Editor> can be accessed from <Wingman> > <Settings> > <Advanced> > <Database Editor>.")
                })
        };
    }

    public class TipSlide
    {
        public string Heading { get; set; }
        public List<TipModel> Tips { get; set; }

        public TipSlide(string heading, List<TipModel> tips)
        {
            Heading = heading;
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
            //var boldTags = 0;
            //var colorTags = 0;
            //if (Tip.Contains('<'))
            //    boldTags = (Tip.Split('<').Count() )* 2 - 1;
            //if (Tip.Contains('|'))
            //{
            //    colorTags = (Tip.Split('|').Count()) * 2 - 1;
            //}
            //TipLength = Tip.Length - boldTags - colorTags;
            Example = example;
            TipLength = 0;
        }
    }
}
