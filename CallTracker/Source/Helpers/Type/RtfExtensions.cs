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
            var fontIndex = p.Formatting.FontIndex;
            var fontSize = p.Formatting.FontSize;
            if (fontSplits.Count() > 1)
            {
                //var i = 0;
                if (!s.StartsWith("|"))
                {
                    ParseBold(ref p, fontSplits[0], fontIndex, fontSize);
                    //i = 1;
                }
                for (var index = 1; index < fontSplits.Count(); index += 2)
                {
                    var formatSplit = fontSplits[index].Split(',');
                    fontIndex = Convert.ToInt32(formatSplit[0]);
                    fontSize = Convert.ToSingle(formatSplit[1]);

                    ParseBold(ref p, fontSplits[index + 1], fontIndex, fontSize);
                }
            }
            else
            {
                ParseBold(ref p, fontSplits[0], fontIndex, fontSize);
            }
        }

        public static void ParseBold(ref RtfFormattedParagraph p, string s)
        {
            var substring = s;
            while (substring.Contains('<'))
            {
                var indexLeft = substring.IndexOf('<');
                var indexRight = substring.IndexOf('>', indexLeft);
                var prebold = substring.Substring(0, indexLeft);
                if (!String.IsNullOrEmpty(prebold))
                    p.AppendText(prebold);
                p.AppendText(new RtfHyperlink("test1", new RtfFormattedText(
                    substring.Substring(indexLeft + 1, indexRight - indexLeft - 1),
                    RtfCharacterFormatting.Bold)));
                substring = substring.Remove(0, indexRight + 1);
            }
            if (!String.IsNullOrEmpty(substring))
                p.AppendText(substring);
        }

        public static void ParseBold(ref RtfFormattedParagraph p, string s, int fontIndex, float fontSize)
        {
            var substring = s;
            while (substring.Contains('<'))
            {
                var indexLeft = substring.IndexOf('<');
                var indexRight = substring.IndexOf('>', indexLeft);
                var prebold = substring.Substring(0, indexLeft);
                if (!String.IsNullOrEmpty(prebold))
                    p.AppendText(new RtfFormattedText(prebold, fontIndex, fontSize));
                p.AppendText(new RtfFormattedText(
                    substring.Substring(indexLeft + 1, indexRight - indexLeft - 1),
                    RtfCharacterFormatting.Bold, p.Formatting.FontIndex, p.Formatting.FontSize));
                substring = substring.Remove(0, indexRight + 1);
            }
            if (!String.IsNullOrEmpty(substring))
                p.AppendText(new RtfFormattedText(substring, fontIndex, fontSize));
        }
    }
}
