using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerDecisionMaking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! What is your name?");
            string userName = Console.ReadLine();
            userName = userName.Trim();
            Console.WriteLine("Hi {0}, it is great to meet you! Let's begin.", userName);

            do
            {
                Console.WriteLine("Enter a number between 1 and 100, {0}: ", userName);
                int userInput = GetValue(userName);
                IntegerReview(userName, userInput);
            } while (ContinueProgram(userName));
        }

        //this function accepts the validated user input and determines the output to the user
        private static void IntegerReview(string userName, int userInput)
        {
            if (userInput % 2 == 1)
            {
                if (userInput <= 100)
                {
                    Console.WriteLine("{0}: The number is {1} and odd.", userName, userInput);
                }
                else if (userInput > 60)
                {
                    Console.WriteLine("{0}: The number is {1} and odd.", userName, userInput);
                }
            }
            else if (userInput % 2 == 0)
            {
                if (userInput >= 2 && userInput < 25)
                {
                    Console.WriteLine("{0}: The number is even and less than 25.", userName);
                }
                else if (userInput >= 26 && userInput <= 60)
                {
                    Console.WriteLine("{0}: The number is even.", userName);
                }
                else if (userInput > 60)
                {
                    Console.WriteLine("{0}: The number is {1} and even.", userName, userInput);
                }
            }
        }

        //this function confirms if the user would like to continue and either re-runs program or exits
        private static bool ContinueProgram(string userName)
        {
            bool proceed;
            Console.WriteLine("Would you like to continue {0}? (y/n)", userName);
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
                return ContinueProgram(userName);
            }
            //end of if statement
            return proceed;
        }

        //this function obtains the input from the user and validates it as a positive integer
        private static int GetValue(string userName)
        {
            int userInput = 0;
            bool isValid = true;
            while (isValid)
            {
                if (int.TryParse(Console.ReadLine(), out userInput) && userInput >= 1 && userInput <= 100)
                {
                    isValid = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid positive integer between 1 and 100. Please try again {0}!", userName);
                }
            }
            return userInput;
        }
    }
}
