using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimacyLocator
{
    public static class App
    {
        //this function determines if the program will keep running based on the user input
        public static bool ContinueProgram(string input)
        {
            switch (input)
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    Console.Write("That was not a valid response. Please try again. ");
                    return ContinueProgram(Console.ReadLine().ToLower().Trim());
            }

        }
    }
}
