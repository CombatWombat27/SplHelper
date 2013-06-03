using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace splhelper
{
    internal class SplHelperMain
    {
        private static void Main(string[] args)
        {
            Dictionary<string, string> macAndAddresses = TakingInMacAddressAndDirectoryPath.MacNAddy();

            //Commented code allows for searching from Root of a drive, but at this time this is unnecessessary.
            // Additional code needs to be uncommented for this to work in TakingInMacAddressAndDirectoryPath.cs

            //if (macAndAddresses["searchRoot"] == "yes")
            //{
            //    xmlFlows = Directory.GetFiles(macAndAddresses["searchPathString"], macAndAddresses["mac"] + "_Flow.xml", SearchOption.AllDirectories);                
            //}
            //else
            //{
            //    xmlFlows = Directory.GetFiles(macAndAddresses["searchPathTEMPString"], macAndAddresses["mac"] + "_Flow.xml", SearchOption.AllDirectories);
            //}
            string[] xmlFlows = null;
            try
            {
                xmlFlows = Directory.GetFiles(macAndAddresses["searchPathTEMPString"],
                                              macAndAddresses["mac"] + "_Flow.xml", SearchOption.AllDirectories);
            }
            catch (DirectoryNotFoundException dirEx)
            {
                Console.WriteLine(
                    "Search Path Provided did not have a TEMP folder inside it. Please make sure you provide the SDKDB folder path. ");
                Console.WriteLine("");
                Console.WriteLine("Program will terminate upon keypress.");
                Console.ReadLine();
                return;
            }


            var module107 = new Regex("Module ID=\"107\"");
            if (!xmlFlows.Any()) return;
            foreach (string kvp in xmlFlows)
            {
                var streamReader = new StreamReader(kvp);
                string xml = streamReader.ReadToEnd();
                streamReader.Close();
                if (!module107.IsMatch(xml)) continue;


                Console.WriteLine("XML found with Module 107");
                Console.WriteLine("");
                var xmlLineDone = new List<string>();
                xmlLineDone.Add(SplLineFinder.XmlFileReciever(xml, macAndAddresses["searchPathAdfString"]));

          
                foreach (string s in xmlLineDone)
                {
                    Console.WriteLine(s);
                }
                bool rezults = OutputToFile.StringCleaner(xmlLineDone);
                
                while (!Facade.invalidSplCheck)
                {
                    Console.WriteLine("Go ahead and create the spl. When you are done check back here to see if it is created.");
                    System.Threading.Thread.Sleep(10000);
                    Console.WriteLine("Starting the search to confirm proper creation of the SPL");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    while (!File.Exists(macAndAddresses["searchPathAdfString"] + @"\" + Facade.FinalValue + ".Selector.ini"))
                    {
                    }
                    Facade.invalidSplCheck = true;
                    Console.WriteLine("         Spl Created Successfully.");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
          

                
                if (rezults)
                {
                    Console.WriteLine("              !!!!WARNING!!!! ");
                    Console.WriteLine("COPY OUT THE DATA FROM THE TEXT FILE BEFORE ENDING THIS PROGRAM!");
                    Console.WriteLine("        THE TEXT FILE WILL BE DELETED UPON COMPLETION.");
                    Console.WriteLine("");
                    Console.WriteLine("When you are ready to close the program press any key.");
                    Console.ReadLine();

                    File.Delete(EnvironmentVariables.UserProfile + @"\desktop\validspl.txt");
                    File.Delete(EnvironmentVariables.UserProfile + @"\desktop\invalidspl.txt");


                    break;
                }
            }
        }
    }
}