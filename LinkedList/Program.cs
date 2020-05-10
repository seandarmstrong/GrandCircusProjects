using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExample
{
    class Program
    {
        private static readonly List<string> Classmates = new List<string>()
        {
            "Rabin",
            "Aquoinette",
            "Chris",
            "Sean A",
            "Sean S",
            "Ross",
            "Dr. Clark",
            "Mike",
            "Catherine",
            "Bradley",
            "Jacob"
        };
        static void Main(string[] args)
        {
            RunLinkedListExample();
            Console.WriteLine("Press any key to continue to Generic Linked List example");
            Console.ReadKey();
            //Console.Clear();
            //RunGenericLinkedListExample();
            //Console.WriteLine("Press any key to exit");
            //Console.ReadKey();
        }

        private static void RunGenericLinkedListExample()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Generic Linked List Example");
            Console.WriteLine("=================================");
            var genericLinkedList = new LinkedList<string>();
            genericLinkedList.PrintAllNodes();
            foreach (var student in Classmates)
            {
                genericLinkedList.AddAtStart(student);
                Console.Write($"After adding {student}: ");
                genericLinkedList.PrintAllNodes();
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("******** Removing Classmates ***********");
            while (true)
            {
                try
                {
                    genericLinkedList.RemoveFromStart();
                    genericLinkedList.PrintAllNodes();
                }
                catch (Exception)
                {
                    genericLinkedList.PrintAllNodes();
                    break;
                }
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.WriteLine();
        }

        private static void RunLinkedListExample()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Linked List Example");
            Console.WriteLine("=================================");
            var objectLinkedList = new LinkedListClass();
            objectLinkedList.PrintAllNodes();
            foreach (var student in Classmates)
            {
                objectLinkedList.AddAtStart(student);
                Console.Write($"After adding {student}: ");
                objectLinkedList.PrintAllNodes();
            }

            //shows that the removeat method that was created for the lab works
            Console.WriteLine(objectLinkedList.RemoveAt(1));
            objectLinkedList.PrintAllNodes();
            Console.ReadKey();

            //shows that the addat method that was created for the lab works
            Console.WriteLine(objectLinkedList.InsertAt(1, "Brian"));
            objectLinkedList.PrintAllNodes();
            Console.ReadKey();

            //prints the list in reservse order
            objectLinkedList.PrintReverse();

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("******** Removing Classmates ***********");
            while (true)
            {
                try
                {
                    objectLinkedList.RemoveFromStart();
                    objectLinkedList.PrintAllNodes();
                }
                catch (Exception)
                {
                    objectLinkedList.PrintAllNodes();
                    break;
                }
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}

//Pseudocode for algorithm to count the occurences of a numer in an array
//Step 1: Create a separate integer array2 to hold the counter numbers that will be generated when looping through the int array with the data.
//Step 2: declare a counter variable.
//Step 3: Create a for loop where i=0, i is less than the length of array1, and i increments
//Step 4: Initialize counter variable to 1.
//Step 5: Create a nested for loop j=i+1, j is less than the length of array1, and j increments
//Step 6: Create an if statement that is true if array1[i] equals array1[j], then increment counter and initialize array2[j] to 0.
//Step 7: Exit the for loop and created an if statement in the first for loop is true when array2[i] does not equal 0.
//Step 8: Initialize array2[i] to a value of the counter
//Step 9: This will irterate for each individual number the loops until all indexes have been searched
//Step 10: The nest for loops will exit and you will create another for loop where i=0, i is lass than the length of array1, and i increments
//Step 11: Create if statement that is true when array2[i] does not equal 0
//Step 12: If if statement is true, display array[i] and array2[i]

//Doing this with a hashmap in C# I have discovered is not possible because that is for Java. I have read that it would need a dictionary
//Step 1: Create a dictionary to hold the keys (the numbers) and their value
//Step 2: declare a counter variable.
//Step 3: Create a for loop where i=0, i is less than the length of array1, and i increments
//Step 4: Initialize counter variable to 1.
//Step 5: Create a nested for loop j=i+1, j is less than the length of array1, and j increments
//Step 6: Create an if statement that is true if array1[i] equals array1[j], then increment counter
//Step 7: Add array[i] and counter value to dictionary with array[i] as key and counter variable as value
//Step 8: Interate through loop until all indexs of array1 have been checked
//Step 9: Create a foreach loop to loop over items in dictionary collection and display the key and the value for each pair in the dictionary

//There my research when dealing with unsorted arrays, which we would have here, there is not much that can be done but for a linear search
//and that means I would estimate the Big-O for the code as O(n).
