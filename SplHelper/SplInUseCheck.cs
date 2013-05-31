using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace splhelper
{
    internal static class SplInUseCheck
    {
        public static string XmlLineValidator(string matchedString, string searchPathAdfString)
        { 
            if (Regex.IsMatch(matchedString, @"[,/<>:\\\|\?\*]"))
            {
                return "    **Cannot use, invalid Characters found**";
            }
            string[] adfFound = null;
            try
            {
                adfFound = Directory.GetFiles(searchPathAdfString, matchedString + ".Selector.ini");
            }
            catch (DirectoryNotFoundException dirEx)
            {
                Console.WriteLine("Well that just derped! "+ dirEx);
                throw;
            }
            
            if (!adfFound.Any())
            {
                return "    **Not in Use**";
            }
            return "   **Already Used**";
        }
    }
}