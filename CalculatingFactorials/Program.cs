using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingFactorials
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Factorial Calculator!\n");
            string userName = GetUserName();
            Console.WriteLine($"It is so great to meet you {userName}. Let's do some calculations!");
            do
            {
                int maxValue = FindMaxValue();
                int userInteger = GetInteger(userName, maxValue);
                int validInteger = ValidateIntegerRange(userInteger, userName, maxValue);
                Convert.ToInt64(validInteger);
                long factorial = CalculateFactorial(validInteger);
                Console.WriteLine($"{userName}, the factorial of {validInteger} is {factorial}");
            } while (ContinueProgram());
        }

        //this function obtains the name from the user to use throughout the program
        public static string GetUserName()
        {
            Console.Write("And what is your name? ");
            string userName = Console.ReadLine();
            return userName;
        }

        //this function finds the max integer that can be calculated as a factorial before the long datatype is overloaded
        //and becomes a negative number
        public static int FindMaxValue()
        {
            int breakPoint = 1;
            long number = 1;
            while (true)
            {
                if (number < 0)
                {
                    break;
                }
                breakPoint++;
                number = number * breakPoint;
            }
            return breakPoint - 1;
        }

        //this function obtains the integer from the user and either returns the integer if valid or asks for it again if it isn't
        public static int GetInteger(string userName, int maxValue)
        {

            while (true)
            {
                Console.Write($"{userName}, enter an integer that's greater than 0 but less than or equal to {maxValue}: ");
                var integer = Console.ReadLine();
                if (ValidateInteger(integer))
                {
                    return int.Parse(integer);
                }
                Console.WriteLine($"That is not a valid entry {userName}, please try again.");
            }
        }

        //this function validates that the user entered a valid integer, as well as no blank entries
        public static bool ValidateInteger(string number)
        {
            return !string.IsNullOrWhiteSpace(number) && int.TryParse(number, out _);
        }

        //this function determines if the user's integer falls within the acceptable range that can be calculated properly
        public static int ValidateIntegerRange(int number, string userName, int maxValue)
        {
            while (true)
            {
                if (number >= 1 && number <= maxValue)
                {
                    return number;
                }
                else
                {
                    return GetInteger(userName, maxValue);
                }
            }
        }

        //this function calculates a factorial using a recursion loop
        public static long CalculateFactorial(long number)
        {
            if (number == 1)
            {
                return 1;
            }
            return number * CalculateFactorial(number - 1);
        }

        //created program first with a for loop and kept method in to show that it was used first
        /*public static long CalculateFactorial(long number)
        {
            long result = number;
            for (long i = 1; i < number; i++)
            {
                result = result * i;
            }
            return result;
        }*/

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
    }
}
