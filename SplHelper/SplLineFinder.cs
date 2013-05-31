using System;
using System.Text.RegularExpressions;

namespace splhelper
{
    internal static class SplLineFinder
    {
        public static string XmlFileReciever(string xml, string searchPathAdfString)
        {
            var returnableString = string.Empty;
            var productNumberString = new Regex(@"Product number string in DMI: (.*)$", RegexOptions.Multiline);
            Match matchproductNumberString = productNumberString.Match(xml);
            if (matchproductNumberString.Success)
            {
                string matchedString = matchproductNumberString.Groups[1].Value;
                matchedString = matchedString.Replace("\r", "");
                string validatedString = SplInUseCheck.XmlLineValidator(matchedString, searchPathAdfString);
                returnableString = "Product number string in DMI: " + matchedString + " " + validatedString;
            }
            else
            {
                Console.WriteLine("Failure to Match");
            }

            var skuNumberString = new Regex(@"SKU number string in DMI: (.*)$", RegexOptions.Multiline);
            Match matchskuNumberString = skuNumberString.Match(xml);
            if (matchskuNumberString.Success)
            {
                string matchedString = matchskuNumberString.Groups[1].Value;
                matchedString = matchedString.Replace("\r", "");
                string validatedString = SplInUseCheck.XmlLineValidator(matchedString, searchPathAdfString);
                returnableString = returnableString + "\nSKU number string in DMI: " + matchedString + " " + validatedString;
            }
            else
            {
                Console.WriteLine("Failure to Match");
            }
            var versionNumberString = new Regex(@"Version number string in DMI: (.*)$", RegexOptions.Multiline);
            Match matchversionNumberString = versionNumberString.Match(xml);
            if (matchversionNumberString.Success)
            {
                string matchedString = matchversionNumberString.Groups[1].Value;
                matchedString = matchedString.Replace("\r", "");
                string validatedString = SplInUseCheck.XmlLineValidator(matchedString, searchPathAdfString);
                returnableString = returnableString + "\nVersion number string in DMI: " + matchedString + " " + validatedString;
            }
            else
            {
                Console.WriteLine("Failure to Match");
            }

            return returnableString;
        }
    }
}