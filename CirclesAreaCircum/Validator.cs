using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclesAreaCircum
{
    public class Validator
    {
        //default constructor inputted for furture use if needed
        public Validator()
        {

        }

        //sets the properties of the Validator class
        public double Radius { get; set; }

        //this function asks for user inputs and then validates the user input as a double number. It returns the value if validated
        public double ValidateRadius()
        {
            double input = 0.0;
            Console.Write("\nEnter radius: ");
            string r = Console.ReadLine().Trim();
            if (double.TryParse(r, out input) && input > 0)
            {
                Radius = input;
                return Radius;
            }
            else
            {
                Console.Write("That is not a valid positive number. Please try again! Enter a positive number: ");
                return ValidateRadius();
            }
        }

    }
}
