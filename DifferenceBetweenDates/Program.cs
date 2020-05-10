using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferenceBetweenDates
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime result1;
            DateTime result2;

            Console.WriteLine("Hello and welcome! I will calculate the difference between two dates for you, down to hours and minutes.");
            Console.WriteLine("But first I need some information from you.");
            UserInput(out result1, out result2);
            Task(result1, result2);
        }

        /// <summary>
        /// The UserInput method takes two dates from the user as input and validates that they are a valid date and time and confirms they are in
        /// the correct format. The method then passes the outputs back to the Main method.
        /// </summary>
        /// <param name="result1"></param>
        /// <param name="result2"></param>
        public static void UserInput(out DateTime result1, out DateTime result2)
        {
            Console.WriteLine("Please enter your first date and time in the following format, MM-DD-YYYY hh:mm am/pm:");
            while (!DateTime.TryParse(Console.ReadLine(), out result1))
            {
                Console.WriteLine("I'm sorry! That is not a valid date and/or time.");
                Console.WriteLine("Please try again!");
            } //End of While loop for first input
            Console.WriteLine("Great! Now please enter your second date in the same format, MM-DD-YYYY hh:mm am/pm:");
            while (!DateTime.TryParse(Console.ReadLine(), out result2))
            {
                Console.WriteLine("I'm sorry! That is not a valid date and/or time.");
                Console.WriteLine("Please try again!");
            } //End of While loop for second input
        }

        /// <summary>
        /// The task method takes the 2 dates that were passed back to the Main method and calculates the timespan between the between dates.
        /// The highest unit of time is days so the method calculates the years and months and the remaining days.
        /// </summary>
        /// <param name="result1"></param>
        /// <param name="result2"></param>
        public static void Task(DateTime result1, DateTime result2)
        {
            TimeSpan interval = result2 - result1;
            //The absolute value is used so users can input the latest date first and the earliest date second
            int totalYears = Math.Abs(interval.Days / 365);
            int totalMonths = Math.Abs(interval.Days % 365 / 30);
            int totalDays = Math.Abs(interval.Days % 365 % 30);
            Console.WriteLine("Based on your information you are looking for the difference between {0} and {1}\nand the answer is " + totalYears +
                " years, " + totalMonths + " months, " + totalDays + " days, " + interval.Hours + " hours, and " + interval.Minutes + " minutes."
                , result2, result1, interval.ToString());
        }
    }
}
