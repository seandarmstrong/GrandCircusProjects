using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exponents
{
    class Program
    {
        static void Main(string[] args)
        {
            int value;

            Console.WriteLine("Please enter a whole number: ");
            value = Convert.ToInt32(Console.ReadLine());

            int squared = Square(value);
            int cubed = Cube(value);

            Console.WriteLine("The square of {0} is {1}", value, squared);
            Console.WriteLine("The cube of {0} is {1}", value, cubed);
        }

        private static int Square(int number)
        {
            int numSquared = number * number;
            return numSquared;
        }

        private static int Cube(int number)
        {
            int numCubed = Square(number) * number;
            return numCubed;
        }
    }
}
