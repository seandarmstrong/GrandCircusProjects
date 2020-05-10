using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int input1;
            int input2;

            Console.WriteLine("This program will output \"True\" if each place in two numbers (ones, tens, thousands, etc.) sums to the same total\n" +
                "and \"False\" if they do not.");
            Console.WriteLine("Please enter two integer numbers with the same number of digits.\nFor example, \"123\" and \"456\" or \"1234\" and \"5678\".");
            UserInput(out input1, out input2);
            int[] firstSet = NumbersIn(input1);
            int[] secondSet = NumbersIn(input2);
            Task(firstSet, secondSet);
        }

        public static void UserInput(out int num1, out int num2)
        {
            ///The UserInput method is accepting the two integers from the user, first validating that the user entered valid integers, and a final
            ///validation that the user entered two integers that are the same number of digits.

            bool lengthMatch = false;

            Console.WriteLine("Please enter your first integer number:");
            while (!int.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("I'm sorry! That is not a valid integer number!");
                Console.WriteLine("Enter your first integer number: ");
            } //End of While loop for first user input that validates their first input is an integer
            num1 = Math.Abs(num1);
            //Absolute value is here to remove negative sign from integer so length of integer is calculated properly

            do
            {
                Console.WriteLine("Please enter a second integer number that is " + num1.ToString().Length + " digits long:");
                while (!int.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("I'm sorry! That is not a valid integer number!");
                    Console.WriteLine("Please enter a second integer number that is " + num1.ToString().Length + " digits long:");
                } //End of While for second user input
                num2 = Math.Abs(num2);
                //Placed absolute value here so user can enter a negative integer second and it still validating the correct
                //number of digits in the next several lines of code

                int length1 = num1.ToString().Length;
                int length2 = num2.ToString().Length;
                if (length1 != length2)
                {
                    lengthMatch = false;
                    Console.WriteLine("The value entered is not " + num1.ToString().Length + " digits long. Please try again!");
                }
                else
                    lengthMatch = true;
            } while (lengthMatch == false);
            //End of Do-While for validating user inputs are the same length (same number of digits) so program runs proerly


        }


        public static int[] NumbersIn(int value)
        {
            ///This method takes the validated input number and puts each digit of the integer into an array
            ///with as many elements as the integer has digits. Then passes the array back to the main method to carry to the Task method
            var numbers = new Stack<int>();

            for (; value > 0; value /= 10)
                numbers.Push(value % 10);

            return numbers.ToArray();
        }

        public static void Task(int[] firstSet, int[] secondSet)
        {
            ///The Task method takes the two arrays pulled from the Main method and confirms if the digit sets all equal each other after
            ///being added together. The method will go through a series of While loops until it finds the  While loop that equals the length
            ///of the arrays that are pushed from the main task.
            int arrayLength = firstSet.Length;
            while (arrayLength == 1)
            {

                if (firstSet[0] == secondSet[0])
                {
                    Console.WriteLine("True");
                    break;
                }
                else
                {
                    Console.WriteLine("False");
                    break;
                }
            }
            while (arrayLength == 2)
            {
                int firstDigitAdd = firstSet[0] + secondSet[0];
                int secondDigitAdd = firstSet[1] + secondSet[1];
                if (firstDigitAdd == secondDigitAdd)
                {
                    Console.WriteLine("True");
                    break;
                }
                else
                {
                    Console.WriteLine("False");
                    break;
                }
            }
            while (arrayLength == 3)
            {
                int firstDigitAdd = firstSet[0] + secondSet[0];
                int secondDigitAdd = firstSet[1] + secondSet[1];
                int thirdDigitAdd = firstSet[2] + secondSet[2];
                if (firstDigitAdd == secondDigitAdd && secondDigitAdd == thirdDigitAdd)
                {
                    Console.WriteLine("True");
                    break;
                }
                else
                {
                    Console.WriteLine("False");
                    break;
                }
            }

            while (arrayLength == 4)
            {
                int firstDigitAdd = firstSet[0] + secondSet[0];
                int secondDigitAdd = firstSet[1] + secondSet[1];
                int thirdDigitAdd = firstSet[2] + secondSet[2];
                int fourthDigitAdd = firstSet[3] + secondSet[3];
                if (firstDigitAdd == secondDigitAdd && secondDigitAdd == thirdDigitAdd && thirdDigitAdd == fourthDigitAdd)
                {
                    Console.WriteLine("True");
                    break;
                }
                else
                {
                    Console.WriteLine("False");
                    break;
                }
            }

            while (arrayLength == 5)
            {
                int firstDigitAdd = firstSet[0] + secondSet[0];
                int secondDigitAdd = firstSet[1] + secondSet[1];
                int thirdDigitAdd = firstSet[2] + secondSet[2];
                int fourthDigitAdd = firstSet[3] + secondSet[3];
                int fifthDigitAdd = firstSet[4] + secondSet[4];
                if (firstDigitAdd == secondDigitAdd && secondDigitAdd == thirdDigitAdd && thirdDigitAdd == fourthDigitAdd && fourthDigitAdd == fifthDigitAdd)
                {
                    Console.WriteLine("True");
                    break;
                }
                else
                {
                    Console.WriteLine("False");
                    break;
                }
            }

            while (arrayLength == 6)
            {
                int firstDigitAdd = firstSet[0] + secondSet[0];
                int secondDigitAdd = firstSet[1] + secondSet[1];
                int thirdDigitAdd = firstSet[2] + secondSet[2];
                int fourthDigitAdd = firstSet[3] + secondSet[3];
                int fifthDigitAdd = firstSet[4] + secondSet[4];
                int sixthDigitAdd = firstSet[5] + secondSet[5];
                if (firstDigitAdd == secondDigitAdd && secondDigitAdd == thirdDigitAdd && thirdDigitAdd == fourthDigitAdd && fourthDigitAdd == fifthDigitAdd
                    && fifthDigitAdd == sixthDigitAdd)
                {
                    Console.WriteLine("True");
                    break;
                }
                else
                {
                    Console.WriteLine("False");
                    break;
                }
            }

            while (arrayLength == 7)
            {
                int firstDigitAdd = firstSet[0] + secondSet[0];
                int secondDigitAdd = firstSet[1] + secondSet[1];
                int thirdDigitAdd = firstSet[2] + secondSet[2];
                int fourthDigitAdd = firstSet[3] + secondSet[3];
                int fifthDigitAdd = firstSet[4] + secondSet[4];
                int sixthDigitAdd = firstSet[5] + secondSet[5];
                int seventhDigitAdd = firstSet[6] + secondSet[6];
                if (firstDigitAdd == secondDigitAdd && secondDigitAdd == thirdDigitAdd && thirdDigitAdd == fourthDigitAdd && fourthDigitAdd == fifthDigitAdd
                    && fifthDigitAdd == sixthDigitAdd && sixthDigitAdd == seventhDigitAdd)
                {
                    Console.WriteLine("True");
                    break;
                }
                else
                {
                    Console.WriteLine("False");
                    break;
                }
            }

            while (arrayLength == 8)
            {
                int firstDigitAdd = firstSet[0] + secondSet[0];
                int secondDigitAdd = firstSet[1] + secondSet[1];
                int thirdDigitAdd = firstSet[2] + secondSet[2];
                int fourthDigitAdd = firstSet[3] + secondSet[3];
                int fifthDigitAdd = firstSet[4] + secondSet[4];
                int sixthDigitAdd = firstSet[5] + secondSet[5];
                int seventhDigitAdd = firstSet[6] + secondSet[6];
                int eighthDigitAdd = firstSet[7] + secondSet[7];
                if (firstDigitAdd == secondDigitAdd && secondDigitAdd == thirdDigitAdd && thirdDigitAdd == fourthDigitAdd && fourthDigitAdd == fifthDigitAdd
                    && fifthDigitAdd == sixthDigitAdd && sixthDigitAdd == seventhDigitAdd && seventhDigitAdd == eighthDigitAdd)
                {
                    Console.WriteLine("True");
                    break;
                }
                else
                {
                    Console.WriteLine("False");
                    break;
                }
            }

            while (arrayLength == 9)
            {
                int firstDigitAdd = firstSet[0] + secondSet[0];
                int secondDigitAdd = firstSet[1] + secondSet[1];
                int thirdDigitAdd = firstSet[2] + secondSet[2];
                int fourthDigitAdd = firstSet[3] + secondSet[3];
                int fifthDigitAdd = firstSet[4] + secondSet[4];
                int sixthDigitAdd = firstSet[5] + secondSet[5];
                int seventhDigitAdd = firstSet[6] + secondSet[6];
                int eighthDigitAdd = firstSet[7] + secondSet[7];
                int ninthDigitAdd = firstSet[8] + secondSet[8];
                if (firstDigitAdd == secondDigitAdd && secondDigitAdd == thirdDigitAdd && thirdDigitAdd == fourthDigitAdd && fourthDigitAdd == fifthDigitAdd
                    && fifthDigitAdd == sixthDigitAdd && sixthDigitAdd == seventhDigitAdd && seventhDigitAdd == eighthDigitAdd && eighthDigitAdd == ninthDigitAdd)
                {
                    Console.WriteLine("True");
                    break;
                }
                else
                {
                    Console.WriteLine("False");
                    break;
                }
            }

            while (arrayLength == 10)
            {
                int firstDigitAdd = firstSet[0] + secondSet[0];
                int secondDigitAdd = firstSet[1] + secondSet[1];
                int thirdDigitAdd = firstSet[2] + secondSet[2];
                int fourthDigitAdd = firstSet[3] + secondSet[3];
                int fifthDigitAdd = firstSet[4] + secondSet[4];
                int sixthDigitAdd = firstSet[5] + secondSet[5];
                int seventhDigitAdd = firstSet[6] + secondSet[6];
                int eighthDigitAdd = firstSet[7] + secondSet[7];
                int ninthDigitAdd = firstSet[8] + secondSet[8];
                int tenthDigitAdd = firstSet[9] + secondSet[9];
                if (firstDigitAdd == secondDigitAdd && secondDigitAdd == thirdDigitAdd && thirdDigitAdd == fourthDigitAdd && fourthDigitAdd == fifthDigitAdd
                    && fifthDigitAdd == sixthDigitAdd && sixthDigitAdd == seventhDigitAdd && seventhDigitAdd == eighthDigitAdd && eighthDigitAdd ==
                    ninthDigitAdd && ninthDigitAdd == tenthDigitAdd)
                {
                    Console.WriteLine("True");
                    break;
                }
                else
                {
                    Console.WriteLine("False");
                    break;
                }
            }
        }
    }
}
