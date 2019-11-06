using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSmartCopyPaste.Services
{
    public class TextFormatService
    {
        public static string FormatTextAsCSV(string text, bool formatAsString)
        {
            var splitText = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Where(t => t != "NULL" && t != "").ToArray();

            bool isTextAllNumeric = formatAsString ? false : IsTextAllNumeric(splitText);

            return JoinText(splitText, isTextAllNumeric);
        }

        private static bool IsTextAllNumeric(string[] text)
        {
            return text.All(x => long.TryParse(x, out long y) || decimal.TryParse(x, out decimal i) || double.TryParse(x, out double d));
        }

        private static string JoinText(string[] text, bool isTextAllNumeric)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                // Properly Escape apostrophes
                var t = text[i].Replace("\'", "\'\'");

                if (isTextAllNumeric)
                {
                    builder.Append($"{t}");
                }
                else
                {
                    builder.Append($"'{t}'");
                }

                if(!(i == text.Length - 1))
                {
                    builder.Append(",");
                    builder.Append(Environment.NewLine);
                }

               
            }

            return builder.ToString();
        }
    }
}
