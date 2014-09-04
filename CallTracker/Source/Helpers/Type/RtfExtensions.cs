using System;
using System.Linq;
using ESCommon.Rtf;

namespace CallTracker.Source.Helpers.Type
{
    class RtfHelpers
    {
        public static void Parse(ref RtfFormattedParagraph p, string s)
        {
            var fontSplits = s.Split('|');
            var fontColor = p.Formatting.TextColorIndex;
            //var fontIndex = p.Formatting.FontIndex;
            //var fontSize = p.Formatting.FontSize;
            if (fontSplits.Count() > 1)
            {
                if (!s.StartsWith("|"))
                {
                    ParseBold(ref p, fontSplits[0], fontColor);
                }
                for (var index = 1; index < fontSplits.Count(); ++index)
                {
                    fontColor = Convert.ToInt32(fontSplits[index].Substring(0,1));
                    //var formatSplit = fontSplits[index].Split(',');
                    //fontIndex = Convert.ToInt32(formatSplit[0]);
                    //fontSize = Convert.ToSingle(formatSplit[1]);

                    ParseBold(ref p, fontSplits[index].Remove(0, 1), fontColor);
                }
            }
            else
                ParseBold(ref p, fontSplits[0], fontColor);
        }

        //public static void ParseBold(ref RtfFormattedParagraph p, string s)
        //{
        //    var substring = s;
        //    while (substring.Contains('<'))
        //    {
        //        var indexLeft = substring.IndexOf('<');
        //        var indexRight = substring.IndexOf('>', indexLeft);
        //        var text = substring.Substring(0, indexLeft);
        //        if (!String.IsNullOrEmpty(text))
        //            p.AppendText(text);

        //        text = substring.Substring(indexLeft + 1, indexRight - indexLeft - 1);
        //        p.AppendText(new RtfHyperlink("test1", new RtfFormattedText(text, RtfCharacterFormatting.Bold)));
                
        //        substring = substring.Remove(0, indexRight + 1);
        //    }
        //    if (!String.IsNullOrEmpty(substring))
        //        p.AppendText(substring);
        //}

        public static void ParseBold(ref RtfFormattedParagraph p, string s, int fontColor)//, float fontSize)
        {
            var substring = s;
            while (substring.Contains('<'))
            {
                var indexLeft = substring.IndexOf('<');
                var indexRight = substring.IndexOf('>', indexLeft);
                
                var text = substring.Substring(0, indexLeft);
                if (!String.IsNullOrEmpty(text))
                    p.AppendText(new RtfFormattedText(text, fontColor));

                text = substring.Substring(indexLeft + 1, indexRight - indexLeft - 1);
                p.AppendText(new RtfFormattedText(text, RtfCharacterFormatting.Bold, fontColor));

                substring = substring.Remove(0, indexRight + 1);
            }
            if (!String.IsNullOrEmpty(substring))
                p.AppendText(new RtfFormattedText(substring, fontColor));
        }
    }
}
