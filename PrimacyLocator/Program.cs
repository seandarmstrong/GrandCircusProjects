using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimacyLocator
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                var primeNumber = new PrimeNumber();
                var primeList = new List<int>();
                var start = 2;

                int inputAsInt;
                do
                {
                    try
                    {
                        Console.Write("Select the nth prime number you want: ");
                        var userSelection = Console.ReadLine();
                        inputAsInt = primeNumber.CheckUserInput(userSelection);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.GetType()} says {ex.Message}");
                    }

                } while (true);

                //while loop that determines if a number is prime, adds it to a list if it is, and continues incrementing and running until the
                //list is one less than the user inputted int
                while (primeList.Count < inputAsInt)
                {
                    if (primeNumber.IsPrime(start))
                    {
                        primeList.Add(start);
                    }

                    start++;
                }

                Console.WriteLine($"The prime number at {inputAsInt}th position in the sequence is {primeList[inputAsInt - 1]}.");
                Console.WriteLine("Continue? (y/n)");

            } while (App.ContinueProgram(Console.ReadLine().ToLower().Trim()));

            Console.WriteLine("Have a nice day");
        }

    }
}
