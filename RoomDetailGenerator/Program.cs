using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomDetailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                double length = GetLength();
                double width = GetWidth();
                double height = GetHeight();
                double area = CalculateArea(length, width);
                double perimeter = CalculatePerimeter(length, width);
                double volume = CalculateVolume(area, height);
                Console.WriteLine($"The area of the room is {area}.");
                Console.WriteLine($"The perimeter of the room is {perimeter}.");
                Console.WriteLine($"The volume of the room is {volume}.");
            } while (ContinueProgram());
            //End do-while loop
        }

        private static double CalculateVolume(double area, double height)
        {
            return area * height;
        }

        private static double CalculatePerimeter(double length, double width)
        {
            return (length * 2) + (width * 2);
        }

        private static double CalculateArea(double length, double width)
        {
            return length * width;
        }

        //The ContinueProgram receives user input and determines if the program should continue running or not
        private static bool ContinueProgram()
        {
            bool proceed;
            Console.WriteLine("Would you like to continue and calculate another room? (Y or N)");
            string input = Console.ReadLine();
            input = input.ToLower();

            //if statement will use user's input and determine whether or not to change the value of program in the while loop.
            if (input == "y")
            {
                proceed = true;
            }
            else
            {
                proceed = false;
            }
            //end of if statement
            return proceed;
        }

        //Recceives user input for height of room and validates it is a valid entry
        private static double GetHeight()
        {
            double height = 0;
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("Please enter the height of the room: ");
                if (double.TryParse(Console.ReadLine(), out height) == false)
                {
                    Console.WriteLine("That is an invalid height and it must be a number. Please try again!");
                }
                else if (height < 0)
                {
                    Console.WriteLine("The height cannot be negative, please try again!");
                }
                else
                {
                    valid = true;
                }
            }
            //End While loop for validation
            return height;
        }

        //Recceives user input for width of room and validates it is a valid entry
        private static double GetWidth()
        {
            double width = 0;
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("Please enter the width of the room: ");
                if (double.TryParse(Console.ReadLine(), out width) == false)
                {
                    Console.WriteLine("That is an invalid width and it must be a number. Please try again!");
                }
                else if (width < 0)
                {
                    Console.WriteLine("The width cannot be negative, please try again!");
                }
                else
                {
                    valid = true;
                }
            }
            return width;
            //End while loop for validation
        }

        //Recceives user input for length of room and validates it is a valid entry
        private static double GetLength()
        {
            double length = 0;
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("Please enter the length of the room: ");
                if (double.TryParse(Console.ReadLine(), out length) == false)
                {
                    Console.WriteLine("That is an invalid length and it must be a number. Please try again!");
                }
                else if (length < 0)
                {
                    Console.WriteLine("The length cannot be negative, please try again!");
                }
                else
                {
                    valid = true;
                }
            }
            //End while loop for validation
            return length;
        }
    }
}
