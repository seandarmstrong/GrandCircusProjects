using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusOne_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Letter Grade Converter!");
            Converter();
        }

        private static void Converter()
        {
            Boolean valid = true;
            while (valid)
            {
                GradeSwitch();
                Console.WriteLine("\n");
                Console.WriteLine("Continue?(y/n): ");
                string continueInput = Console.ReadLine();
                continueInput = continueInput.ToLower();
                if (continueInput == "y")
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }
            }
        }

        private static void GradeSwitch()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Enter a numerical grade: ");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case int n when (n >= 99 && n < 100):
                    Console.WriteLine("Letter Grade: A+");
                    break;

                case int n when (n >= 91 && n < 99):
                    Console.WriteLine("Letter Grade: A");
                    break;

                case int n when (n >= 88 && n < 90):
                    Console.WriteLine("Letter Grade: A-");
                    break;

                case int n when (n >= 86 && n < 88):
                    Console.WriteLine("Letter Grade: B+");
                    break;

                case int n when (n >= 82 && n < 86):
                    Console.WriteLine("Letter Grade: B");
                    break;

                case int n when (n >= 80 && n < 82):
                    Console.WriteLine("Letter Grade: B-");
                    break;

                case int n when (n >= 78 && n < 80):
                    Console.WriteLine("Letter Grade: C+");
                    break;

                case int n when (n >= 69 && n < 78):
                    Console.WriteLine("Letter Grade: C");
                    break;

                case int n when (n >= 67 && n < 69):
                    Console.WriteLine("Letter Grade: C-");
                    break;

                case int n when (n >= 60 && n < 67):
                    Console.WriteLine("Letter Grade: D");
                    break;

                case int n when (n >= 0 && n < 60):
                    Console.WriteLine("Letter Grade: F");
                    break;
            }
        }
    }
}
