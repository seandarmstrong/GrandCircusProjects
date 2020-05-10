using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Age Calculator");
            Console.WriteLine("\n");
            Console.WriteLine("To begin, lets get a little personal. What is your name?");
            string userName = Console.ReadLine();
            Console.WriteLine($"Welcome {userName}, it is very nice to meet you!");
            int yearBirth = GetBirthYear(userName);
            int monthBirth = GetBirthMonth(userName);
            int dayBirth = GetBirthDay(userName, monthBirth);
            CultureInfo provider = CultureInfo.InvariantCulture;
            string birthString = $"{monthBirth}{dayBirth}{yearBirth}";
            string format = "MMddyyyy";
            DateTime birthday = DateTime.ParseExact(birthString, format, provider);
            DateTime current = DateTime.Now;

            int ageDays = GetAgeInDays(birthday, current);
            int years = CalculateYears(ageDays);

            Console.WriteLine($"{userName}, I have calculated that you are {years} years old.\nAnd you are {ageDays} days old");

        }

        public static int GetBirthYear(string userName)
        {
            int yearBirth = 0;
            bool proceed = true;
            var yearCurrent = DateTime.Now.Year;
            Console.WriteLine($"What year were you born in {userName}?");
            while (proceed)
            {
                if (!int.TryParse(Console.ReadLine(), out yearBirth))
                {
                    Console.WriteLine("That is not a valid integer. Please enter a valid integer for birth year.");
                }
                else if (yearBirth < (yearCurrent - 123))
                {
                    Console.WriteLine("I'm sorry but no one is over 123 years old. The Guinness book of world records for age is 122 years and 164 days.\nI doubt that is you, please try again!");
                }
                else
                {
                    proceed = false;
                }
            }
            return yearBirth;

        }

        public static int GetBirthMonth(string userName)
        {
            int monthBirth = 0;
            bool proceed = true;
            Console.WriteLine($"Great! Now, what month were you born in {userName} (represented by a number)?");
            while (proceed)
            {
                if (!int.TryParse(Console.ReadLine(), out monthBirth))
                {
                    Console.WriteLine("That is not a valid integer. Please enter a valid integer for birth month.");
                }
                else if (monthBirth < 1 && monthBirth > 12)
                {
                    Console.WriteLine("I'm sorry, months cannot be less than 1 and over 12. Please try again");
                }
                else
                {
                    proceed = false;
                }
            }
            return monthBirth;

        }

        public static int GetBirthDay(string userName, int monthBirth)
        {
            int dayBirth = 0;
            bool proceed = true;
            Console.WriteLine($"Now we are cooking! Now, what day were you born on {userName}?");
            while (proceed)
            {
                if (!int.TryParse(Console.ReadLine(), out dayBirth))
                {
                    Console.WriteLine("That is not a valid integer. Please enter a valid integer for birth month.");
                }
                else if (dayBirth > 0)
                {
                    if (monthBirth == 4 || monthBirth == 6 || monthBirth == 9 || monthBirth == 11 && dayBirth > 30)
                    {
                        Console.WriteLine("You cannot have over 30 days in that month. Please try again!");
                    }
                    else if (monthBirth == 2 && dayBirth > 29)
                    {
                        Console.WriteLine("You cannot have over 29 days in that month. Please try again!");
                    }
                    else if (monthBirth == 1 || monthBirth == 3 || monthBirth == 5 || monthBirth == 7 || monthBirth == 8 || monthBirth == 10 || monthBirth == 12 && dayBirth > 31)
                    {
                        Console.WriteLine("You cannot have over 31 days in that month. Please try again!");
                    }
                    else if (dayBirth < 1)
                    {
                        Console.WriteLine("You cannot havr less than 1 day in any month. Please try again!");
                    }
                    else
                        return dayBirth;
                }
                else
                {
                    proceed = false;
                }
            }
            return dayBirth;

        }

        public static int GetAgeInDays(DateTime result1, DateTime result2)
        {
            TimeSpan interval = result2 - result1;
            return interval.Days;
        }

        public static int CalculateYears(int years)
        {
            return years / 365;
        }

        /*public static int ValidateBirthYear()
        {
            bool proceed = true;
            int yearBirth = 0;
            var yearCurrent = DateTime.Now.Year;
            while (proceed)
            {
                if (!int.TryParse(Console.ReadLine(), out yearBirth))
                {
                    Console.WriteLine("That is not a valid integer. Please enter a valid integer for birth year.");
                }
                else if (yearBirth < (yearCurrent - 123))
                {
                    Console.WriteLine("I'm sorry but no one is over 123 years old. The Guinness book of world records for age is 122 years and 164 days.\nI doubt that is you, please try again!");
                }
                else
                {
                    proceed = false;
                }
            }
            return yearBirth;
        }*/
    }
}
