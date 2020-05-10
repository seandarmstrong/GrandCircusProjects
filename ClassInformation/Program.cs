using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInformation
{
    class Program
    {
        const int MAX_INDEX = 12;
        const int HOMETOWN_INDEX = 1;
        const int FAVORITE_INDEX = 2;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our C# class.");
            do
            {
                string[,] students = new string[MAX_INDEX, 3]
                {
                {"Sean Armstrong", "Grand Rapids, MI", "Ramen Noodles" },
                {"Aquionette Blair", "Grand Rapids, MI", "Lasagna" },
                {"Chris Butcher", "Allendale, MI", "Sandwiches" },
                {"Mike Cacciano", "Alpena, MI", "Electric Hero" },
                {"Michael Clark", "Grand Rapids, MI", "Chicken Schwarma" },
                {"Bradley Freeston", "Grandville, MI" , "Chicken Curry" },
                {"Jacob Hands", "Flint, MI", "Jimmy Johns" },
                {"Ross Hinman", "East Grand Rapids, MI", "Brownies" },
                {"Rabin Rai", "Nepal", "Fruit Juice" },
                {"Sean Sculley", "Vail, CO", "Steak" },
                {"Catherine Stafford", "Grand Rapids, MI", "Monster" },
                {"Bruce Vongphrachanh", "Laos", "Pizza" }
                };
                Console.Write("Which student would you like to learn more about? (enter a number 1-12): ");
                int userInput = GetStudentNumber(Console.ReadLine());
                try
                {
                    var firstName = students[userInput - 1, 0].Split(' ');
                    Console.WriteLine($"Student {userInput} is {students[userInput - 1, 0]}. What would you like to know about {firstName[0]}?\nEnter \"hometown\" or \"favorite food\"): ");
                    int userRequest = GetStudentInfo(Console.ReadLine().ToLower());
                    if (userRequest == HOMETOWN_INDEX)
                    {
                        Console.WriteLine($"{firstName[0]} is from {students[userInput - 1, HOMETOWN_INDEX]}. Would you like to know more? (enter \"yes\" or \"no\"): ");
                        if (ContinueProgram(Console.ReadLine().ToLower()))
                        {
                            Console.WriteLine($"{firstName[0]}'s favorite food is {students[userInput - 1, FAVORITE_INDEX]}.");
                        }
                    }
                    else if (userRequest == FAVORITE_INDEX)
                    {
                        Console.WriteLine($"{firstName[0]}'s favorite food is {students[userInput - 1, FAVORITE_INDEX]}. Would you like to know more? (enter \"yes\" or \"no\"): ");
                        if (ContinueProgram(Console.ReadLine().ToLower()))
                        {
                            Console.WriteLine($"{firstName[0]} is from {students[userInput - 1, HOMETOWN_INDEX]}.");
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"That student does not exist. Please enter a number between 1-{MAX_INDEX}: ");
                }
                Console.WriteLine("Would you like to lookup another student?(\"yes\" or \"no\"): ");
            } while (ContinueProgram(Console.ReadLine().ToLower()));
            Console.WriteLine("\nThanks!");
        }

        //this function receives input from the user and validates it within the range of the array and that it is an integer
        public static int GetStudentNumber(string input)
        {
            try
            {
                return int.Parse(input);
                /*if (userInput >= 1 && userInput <= MAX_INDEX)
                {
                    return userInput;
                }
                else
                {
                    Console.Write($"That student does not exist. Please try again. (enter a number 1-{MAX_INDEX}): ");
                    return GetStudentNumber(Console.ReadLine());
                }*/
            }
            catch (FormatException)
            {
                Console.Write($"That is not a valid integer. Please try again! (enter a number 1-{MAX_INDEX}): ");
                return GetStudentNumber(Console.ReadLine());
            }
        }

        //this function retrieves the indexes needed to pull the requested data
        public static int GetStudentInfo(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (input == "hometown")
                {
                    return HOMETOWN_INDEX;
                }
                else if (input == "favorite food")
                {
                    return FAVORITE_INDEX;
                }
                else
                {
                    Console.Write("That data does not exist. Please try again. (enter \"hometown\" or \"favorite food\"):");
                    return GetStudentInfo(Console.ReadLine());
                }
            }
            else
            {
                Console.Write("Oh come on! You didn't even try to enter data. Let's try this again! (enter \"hometown\" or \"favorite food\"):");
                return GetStudentInfo(Console.ReadLine().ToLower());
            }
        }

        private static bool ContinueProgram(string input)
        {
            //if statement will use user's input and determine whether or not to change the value of program in the while loop.
            if (input == "y" | input == "yes")
            {
                return true;
            }
            else if (input == "n" | input == "no")
            {
                return false;
            }
            else
            {
                return ContinueProgram(input);
            }
            //end of if statement
        }
    }
}
