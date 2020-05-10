using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresAndCubes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Learn your squares and cubes!");

            do
            {
                Console.WriteLine("Enter an integer: ");
                int userInput = ValidateValue();
                //int userInput = Convert.ToInt32(Console.ReadLine());
                var sb = new StringBuilder();
                var sh = new StringBuilder();
                sb.Append(String.Format("{0, -10} {1, -10} {2, -10}", "Number", "Squared", "Cubed"));
                sh.Append(String.Format("{0, -10} {1, -10} {2, -10}", "=======", "=======", "======="));

                Console.WriteLine($"{sb}\n{sh}");
                CalculateAnswer(userInput);
            } while (ContinueProgram());
        }

        //this function asks the user if they want to continue and determines if the program will continue running based on their inputs
        private static bool ContinueProgram()
        {
            bool proceed;
            Console.WriteLine("Would you like to continue? (y/n)");
            string input = Console.ReadLine();
            input = input.ToLower();

            //if statement will use user's input and determine whether or not to change the value of program in the while loop.
            if (input == "y")
            {
                proceed = true;
            }
            else if (input == "n")
            {
                proceed = false;
            }
            else
            {
                return ContinueProgram();
            }
            //end of if statement
            return proceed;
        }

        //this function takes the user input and then calculates the results for display
        private static void CalculateAnswer(int userInput)
        {
            for (int i = 1; i <= userInput; i++)
            {
                int squared = i * i;
                int cubed = i * i * i;
                var results = new StringBuilder();
                results.Append(String.Format("{0, -10} {1, -10} {2, -10}", i, squared, cubed));
                Console.WriteLine(results);
            }
        }

        //this function validates the user's input as an integer or not
        private static int ValidateValue()
        {
            int userInput = 0;
            bool isValid = true;
            while (isValid)
            {
                if (int.TryParse(Console.ReadLine(), out userInput) && userInput >= 1)
                {
                    isValid = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid positive integer. Please try again!");
                }
            }
            return userInput;
        }
    }
}
