using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclesAreaCircum
{
    public class Circle
    {
        //creates constructor with required parameter of radius pass through from main method
        public Circle(double radius)
        {
            Radius = radius;
        }

        //sets property of Circle class
        private double Radius { get; }

        //this function calculates the circumference of the circle and returns a double number
        public double CalculateCircumference()
        {
            return 2 * Math.PI * Radius;
        }

        //this function sets the formatting of the circumference for approxiate user viewing on the console
        public string CalculateFormattedCircumference()
        {
            return String.Format("{0, -15} {1,-10}", "Circumference: ", FormatNumber(CalculateCircumference()));
        }

        //this function calculates the area of the circle and returns a double number
        public double CalculateArea()
        {
            return Math.PI * (Math.Pow(Radius, 2));
        }

        //this function sets the formatting of the area for approxiate user viewing on the console
        public string CalculateFormattedArea()
        {
            return String.Format("{0, -15} {1,-10}", "Area: ", FormatNumber(CalculateArea()));
        }

        //this function accepts a double number and returns a string with the double number formatted to 2 decimal places
        private string FormatNumber(double x)
        {

            return string.Format($"{Math.Round(x, 2, MidpointRounding.AwayFromZero)}");
        }
    }
}
