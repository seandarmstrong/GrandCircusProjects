using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimacyLocator
{
    public class PrimeNumber
    {
        //this function validates the user input as an integer and a positive number over 0
        public int CheckUserInput(string input)
        {
            if (int.TryParse(input, out var number))
            {
                if (number == 0)
                {
                    throw new Exception("Cannot find the 0th prime number");
                }
                if (number < 0)
                {
                    throw new Exception("Integer must be positive");
                }
                return number;
            }
            else
            {
                throw new Exception("The input must be an integer");
            }

            throw new System.NotImplementedException();
        }

        //this function determines if a number is prime and when all true returns added to the prime number list and false returns are skipped
        public bool IsPrime(int number)
        {
            if (number == 2 || number == 3)
            {
                return true;
            }

            if (number % 2 == 0 || number % 3 == 0)
            {
                return false;
            }

            if (number < 2)
            {
                return false;
            }

            var ceiling = Math.Sqrt(number);
            for (int i = 3; i <= ceiling; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
