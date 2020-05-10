using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclesAreaCircum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Circle Tester");
            var counter = 0;
            //initiates a new instance of the Validator class
            var validatedRadius = new Validator();
            do
            {
                //calls ValidateRadius method in Validator class to receive user input, validate it as a double, and return number as radius
                var radius = validatedRadius.ValidateRadius();
                //initiates new instance of Circle class after passing through required parameter of radius
                var circleRadius = new Circle(radius);
                Console.WriteLine(circleRadius.CalculateFormattedCircumference());
                Console.WriteLine(circleRadius.CalculateFormattedArea());
                //counter keeps track of number of times the loop is executed to display back to user at end
                counter++;
                Console.Write("\nWould you like to find the information of another circle? (\"yes\" or \"no\"): ");
            } while (ContinueProgram(Console.ReadLine().ToLower().Trim()));
            Console.WriteLine($"Goodbye. You created {counter} Circle object(s).");
            Console.ReadKey();
        }

        //this function returns boolean value based on user input to continue program or exit
        public static bool ContinueProgram(string userResponse)
        {
            if (userResponse == "yes" || userResponse == "y")
            {
                return true;
            }
            else if (userResponse == "no" || userResponse == "n")
            {
                return false;
            }
            else
            {
                Console.Write("That response didn't make sense. Would you like to continue? (\"yes\" or \"no\"): ");
                return ContinueProgram(Console.ReadLine().ToLower().Trim());
            }
        }
    }
}
