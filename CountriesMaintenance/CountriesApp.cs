using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesMaintenance
{
    public class CountriesApp
    {
        //this function displays the menu for the user to choose the input
        public void DisplayMenu()
        {
            Console.WriteLine("1 - See the list of countries\n2 - Add a country\n3 - Delete a country\n4 - Exit");
        }

        //this function accepts the user's menu selection while converting to an integer and catching exceptions for non-integer inputs
        public int GetUserResponse()
        {
            try
            {
                Console.Write("\nEnter menu number: ");
                return Convert.ToInt32(Console.ReadLine().Trim());
            }
            catch (FormatException)
            {
                Console.WriteLine("I'm sorry. That is not a valid integer. Try again.");
                return GetUserResponse();
            }
        }

        //this function handles the input from the user and calls the necessary functions
        public bool HandleUserReponse(int userInput)
        {
            var country = new CountriesTextFile();
            var validate = new Validator();
            switch (userInput)
            {
                case 1:
                    country.ReadCountriesFile();
                    return true;
                case 2:
                    country.WriteCountriesFile();
                    return true;
                case 3:
                    country.DeleteCountry();
                    return true;
                case 4:
                    return validate.QuitProgram();

                default:
                    Console.WriteLine("That is not a proper response. Please try again.\n");
                    break;
            }

            return true;
        }
    }
}
