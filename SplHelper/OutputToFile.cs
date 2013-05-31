using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace splhelper
{
    internal static class OutputToFile
    {

        public static bool StringCleaner(List<string> xmlLineDone)
        {
            string[] lines = Regex.Split(xmlLineDone[0], "\n");
            Choices(lines);
            return true;
        }


        private static void Choices(string[] lines)
        {
            Console.WriteLine("");
            Console.WriteLine("Can a valid spl be created?(Y/N): ");
            bool acknowledgementBool = true;
            acknowledgementBool = InputValidator.CheckYN(acknowledgementBool,Console.ReadLine());
            bool invalidFileCreated = false;
            var searchValues = new List<string>();
            int a = 1;
            if (acknowledgementBool)
            {
                Console.WriteLine("");
                Console.WriteLine("Which will you use as a search value? Chose from the numbers below.: ");


                var toTextFile = new Regex(@":\s+(.*?)\s*(?:$|\*)");

                for (int i = 0; i < 3; i++)
                {
                    Match matchedString = toTextFile.Match(lines[i]);
                    if (matchedString.Success)
                    {
                        searchValues.Add(matchedString.Groups[1].Value);
                    }
                }
            
            }
            else
            {
                PrintInvalid();
                return;
            }
            foreach (string searchValue in searchValues)
            {
                Console.WriteLine(a + ") " + searchValues[a - 1]);
                a++;
            }
            int perm123 = InputValidator.Check123(Console.ReadLine(), searchValues.Count);
            PrintValid(perm123, searchValues, lines);
        }


        private static void PrintValid(int perm123, List<string> searchValues, string[] lines)
        {
            perm123 = perm123 - 1;
            Facade.FinalValue = searchValues[perm123];
          
            using (var file = new StreamWriter(EnvironmentVariables.UserProfile + @"\desktop\validspl.txt", true))
            {
                file.WriteLine("Spl Search Value: " + searchValues[perm123]);
                int b = 0;
                file.WriteLine("");
                file.WriteLine("All XML search values:");
                file.WriteLine("");
                foreach (string line in lines)
                {
                    var printableValues = new Regex(@"^((?:(?!\s{4}).)*)");
                    Match matchedString = printableValues.Match(lines[b]);
                    if (matchedString.Success)
                    {
                        file.WriteLine(matchedString);
                    }

                    b++;
                }
                
            }
            System.Diagnostics.Process.Start(EnvironmentVariables.UserProfile + @"\desktop\validspl.txt");
        }


        private static void PrintInvalid()
        {
            
            using (var file = new StreamWriter(EnvironmentVariables.UserProfile + @"\desktop\invalidspl.txt", true))
            {
                file.WriteLine("SPL Could not be created. No valid, unique search values found.");
                file.WriteLine("(ENTER A MORE DETAILED EXPLANATION HERE");
                file.WriteLine("This make/model will need to be MANUALLY DEPLOYED.");
            }
            System.Diagnostics.Process.Start(EnvironmentVariables.UserProfile+ @"\desktop\invalidspl.txt");
        }
    }
}