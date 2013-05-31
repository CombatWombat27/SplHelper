using System;

namespace splhelper
{
    internal class InputValidator
    {
        public static int Check123(string temp123, int lengthofList)
        {
            int perm123 = 99;
            while (Math.Abs(perm123) > lengthofList)
            {
                while (!int.TryParse(temp123, out perm123))
                {
                    Console.WriteLine("That wasn't a valid number, please use a number from 1 to " + lengthofList +
                                      " Try Again! :  ");
                    temp123 = Console.ReadLine();
                }
                if (perm123 > lengthofList || perm123 < 1)
                {
                    Console.WriteLine("That number was not a number from 1 to " + lengthofList + " Try again! : ");
                    temp123 = Console.ReadLine();
                }
            }
            return perm123;
        }

        public static bool CheckYN(bool acknowledgementBool, string acknowledgement)
      {
          while (acknowledgement.ToLower() != "y" && acknowledgement.ToLower() != "n")
          {
              Console.WriteLine("Invalid Y/N, Re-enter: ");
              acknowledgement = Console.ReadLine();
          }
          if (acknowledgement.ToLower().Contains("n"))
          {
              acknowledgementBool = false;
          }
            return acknowledgementBool;
      }

    }
}

