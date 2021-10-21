using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlSmartCopyPaste.Services
{
    public class ClipboardService
    {
        public static string GetTextFromClipboard()
        {
            try
            {
              
                if (Clipboard.ContainsText())
                {
                     return Clipboard.GetText(TextDataFormat.UnicodeText);
                }

                return null;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}
