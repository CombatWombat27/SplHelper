using System.IO;
using System.Linq;

namespace splhelper
{
    internal static class SplInUseCheck
    {
        public static string XmlLineValidator(string matchedString, string searchPathAdfString)
        {
            string[] adfFound = Directory.GetFiles(searchPathAdfString, matchedString + ".Selector.ini");
            if (!adfFound.Any())
            {
                return "    **Not in Use**";
            }
            return "   **Already Used**";
        }
    }
}