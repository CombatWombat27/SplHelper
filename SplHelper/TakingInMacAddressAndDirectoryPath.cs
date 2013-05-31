using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;



namespace splhelper
{
    internal static class TakingInMacAddressAndDirectoryPath
    {
        public static Dictionary<string,string> MacNAddy()
        {
            string searchPathString = "";
            string searchPathTEMPString = "";

            Console.Write("Give me a mac address: ");

            string mac = Console.ReadLine();
            mac = mac.Replace(" ", "").Replace(":", "").Replace("-", "");

            var r = new Regex("^[a-fA-F0-9]{12}$");

            while (!r.IsMatch(mac))
            {
                Console.Write("Invalid Mac Address. Reenter: ");
                mac = Console.ReadLine();
            }

            Console.Write("Enter Search Path: ");
            string givenSearchPathString = Console.ReadLine();
            if (!Directory.Exists(givenSearchPathString))
            {
                Console.WriteLine("Invalid Search Path! Reenter: ");
                givenSearchPathString = Console.ReadLine();
            }
            
            // The following variables are for the test invironment so I don't have to 
            // type them each time!!
           // var mac = "e0db559000de";
            //var givenSearchPathString = @"c:\users\zac\desktop\sdkdb";
           
            
            //Commented code allows for searching from Root of a drive, but at this time this is unnecessessary.
           //Additional code needs to be uncommented in MAIN to use this functionality.
            // Console.WriteLine("Do you want the search to be from the root of the drive instead of the TEMP directory inside of SDKDB?(Y/N) ");
           // var acknowledgement = Console.ReadLine();
            var acknowledgement = "n";
            while (acknowledgement.ToLower() != "y" && acknowledgement.ToLower() != "n")
            {
                Console.WriteLine("Invalid Y/N, Re-enter: ");
                acknowledgement = Console.ReadLine();
            }
            var searchRoot = "no";
            if (acknowledgement.ToLower() == "y")
            {
                searchRoot = "yes";
                searchPathString = givenSearchPathString[0] + ":\\TEMP";
            }
            else
            { 
                searchPathTEMPString = givenSearchPathString + "\\TEMP";
            }

            givenSearchPathString = givenSearchPathString.TrimEnd('/');
            
            
            
            string searchPathAdfString = givenSearchPathString + "\\ADF";
            var returnables = new Dictionary<string, string>();
            returnables.Add("mac",mac);
            returnables.Add("searchPathAdfString",searchPathAdfString);
            returnables.Add("searchPathString",searchPathString);
            returnables.Add("searchPathTEMPString",searchPathTEMPString);
            returnables.Add("searchRoot",searchRoot);
            return returnables;
        }
    }
}