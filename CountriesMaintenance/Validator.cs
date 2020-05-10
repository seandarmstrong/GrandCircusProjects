using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountriesMaintenance
{
    public class Validator
    {
        public bool Continue { get; set; }
        private string _path =
            @"C:\Users\armst\Documents\Grand_Circus\Lab_16\ListOfCountries\Country.Library\countries.txt";

        //this function validates the country name, mainly no punctuation and no numbers
        public string ValidateCountry()
        {
            var pattern = new Regex(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$");
            Console.Write("Enter country: ");
            string name = Console.ReadLine().Trim();
            while (true)
            {
                if (pattern.IsMatch(name))
                {
                    return name;
                }
                else
                {
                    Console.WriteLine("Sorry, country name is not valid!");
                    return ValidateCountry();
                }
            }
        }

        //this function verifies that the requested country to be deleted is in the file before returning it for deletion
        public string VerifyCountryOnList(string input)
        {
            string readText = File.ReadAllText(_path);
            if (readText.Contains(input))
            {
                return input;
            }
            else
            {
                Console.Write("I'm sorry, that country isn't in the file. Please re-type the country: ");
                return VerifyCountryOnList(Console.ReadLine().Trim());
            }
        }

        //this function verifies the input for y/n questions and returns the boolean value respective to their input
        public bool ContinueProgram(string input)
        {
            if (input == "y" || input == "yes")
            {
                return true;
            }
            else if (input == "n" || input == "no")
            {
                return false;
            }
            else
            {
                Console.Write("Not valid response. Try again - (y/n): ");
                return ContinueProgram(Console.ReadLine().ToLower().Trim());
            }
        }

        //this function validates that the user really wants to quit the program
        public bool QuitProgram()
        {
            Console.Write("Are you sure you want to quit the program? (y/n): ");
            bool valid = ContinueProgram(Console.ReadLine().ToLower().Trim());
            Continue = !valid;
            return Continue;
        }
    }
}
