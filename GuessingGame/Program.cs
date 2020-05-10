using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd;
            int integerInput, randomInteger, tryCounter = 0;
            string equivelency;
            bool playAgain, equal;
            do
            {
                tryCounter = 0;
                rnd = new Random();
                randomInteger = rnd.Next(1, 100);
                Console.WriteLine(randomInteger);
                equal = false;
                do
                {
                    integerInput = NumberEvaluation.ValidateNumber();
                    equivelency = NumberEvaluation.CheckEquivelency(ref tryCounter, integerInput, randomInteger);

                    if (equivelency == "vHigh")
                    {
                        Console.WriteLine("Way High");
                    }
                    else if (equivelency == "High")
                    {
                        Console.WriteLine("High");
                    }
                    else if (equivelency == "Low")
                    {
                        Console.WriteLine("Low");
                    }
                    else if (equivelency == "vLow")
                    {
                        Console.WriteLine("Way Low");
                    }
                    else if (equivelency == "Equal")
                    {
                        Console.WriteLine("You guessed it!");
                        equal = true;
                    }
                } while (equal == false);

                Console.WriteLine($"It took you {tryCounter} guesses!");
                playAgain = UserInput.PlayAgain();
            } while (playAgain == true);
        }
        public static class UserInput
        {
            //evaluate and return user input as a integer back to the main function
            public static int GetInteger()
            {
                Console.WriteLine("\nEnter your lousy guess: ");
                string integerInput = Console.ReadLine();
                if (IsInteger(integerInput))
                {
                    return int.Parse(integerInput);
                }
                Console.WriteLine("\nEnsure that your lousy guess is an integer.");
                return GetInteger();
            }
            public static bool EvaluateIntegerRange(int integerInput)
            {
                if ((integerInput >= 1) && (integerInput <= 100))
                {
                    return true;
                }
                Console.WriteLine("Make sure your lousy guess is between 1 and 100");
                return false;
            }
            public static bool IsInteger(string integerInput)
            {
                return int.TryParse(integerInput, out int integerOutput);
            }

            //Determines whether or not the user wants to continue running the program and will call itself recursively if the user doesn't
            //enter y or n
            public static bool PlayAgain()
            {
                Console.WriteLine("\nPlay Again?(y/n)");
                char continueStatus = Console.ReadKey().KeyChar;
                String input = continueStatus.ToString().ToUpper();
                if (input == "Y")
                {
                    return true;
                }
                else if (input == "N")
                {
                    return false;
                }
                else
                {
                    return PlayAgain();
                }
            }
        }
        public static class NumberEvaluation
        {
            public static int ValidateNumber()
            {
                int integerInput;
                do
                {
                    integerInput = UserInput.GetInteger();
                } while (!UserInput.EvaluateIntegerRange(integerInput));
                return integerInput;
            }
            public static string CheckEquivelency(ref int tryCounter, int integerInput, int randomNumber)
            {
                tryCounter++;

                if (integerInput > randomNumber)
                {

                    if (integerInput > (randomNumber + 10))
                    {
                        return "vHigh";
                    }
                    else
                    {
                        return "High";
                    }
                }
                if (integerInput < randomNumber)
                {


                    if (integerInput < (randomNumber - 10))
                    {
                        return "vLow";
                    }
                    else
                    {
                        return "Low";
                    }
                }
                else
                {
                    return "Equal";
                }
            }
        }
    }
}
