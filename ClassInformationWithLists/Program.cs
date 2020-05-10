using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInformationWithLists
{
    class Program
    {
        static List<StudentInfo> students = StudentData();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our C# Class!");
            do
            {
                string userPath = GetUserPath();
                if (userPath == "learn")
                {
                    LearnAboutStudent();
                }
                else if (userPath == "add")
                {
                    AddStudent();
                }
                Console.WriteLine("Would you like to start again? (\"yes\" or \"no\"): ");
            } while (ContinueProgram(Console.ReadLine()));
            Console.WriteLine("Goodbye");
            Console.ReadKey();
        }

        //this function asks the user what path in the application they would like to take and then returns the input if one of the two options.
        public static string GetUserPath()
        {
            Console.Write("\nWould you like to (learn) more a student or would you like to (add) a new student?: ");
            while (true)
            {
                string userPath = Console.ReadLine().ToLower().Trim();
                if (CheckUserEntry(userPath) && userPath == "add" || userPath == "learn")
                {
                    return userPath;

                }
                else
                {
                    return GetUserPath();
                }
            }
        }

        //this function verifies that the user has entered text for a path and passes the value of true back to the GetUserPath method.
        public static bool CheckUserEntry(string userInput)
        {
            return !string.IsNullOrWhiteSpace(userInput);
        }

        //this function handles the learn about student path if selected by the user
        public static void LearnAboutStudent()
        {
            Console.Write($"\nWhich student would you like to learn more about? (enter a number 1 - {students.Count}): ");

            //try-catch block to catch any instances when the user enters an integer outside of the range of the list at time of entry.
            try
            {
                int userInput = GetStudentNumber(Console.ReadLine());
                StudentInfo student = students[userInput - 1];
                var firstName = student.Name.Split(' ');
                Console.Write($"\nStudent {userInput} is {student.Name}. ");
                do
                {
                    Console.WriteLine($"\nWhat would you like to know about {firstName[0]}? (Enter \"hometown\", \"favorite food\", or \"favorite color\"): ");
                    string userRequest = GetStudentInfo(Console.ReadLine().ToLower());
                    if (userRequest == "hometown")
                    {
                        Console.WriteLine($"{firstName[0]} is from {student.Hometown}. Would you like to know more about {firstName[0]}? (enter \"yes\" or \"no\"): ");
                    }
                    else if (userRequest == "favorite food")
                    {
                        Console.WriteLine($"{firstName[0]}'s favorite food is {student.FavoriteFood}. Would you like to know more? (enter \"yes\" or \"no\"): ");
                    }
                    else if (userRequest == "favorite color")
                    {
                        Console.WriteLine($"{firstName[0]}'s favorite color is {student.FavoriteColor}. Would you like to know more? (enter \"yes\" or \"no\"): ");
                    }
                } while (ContinueProgram(Console.ReadLine()));
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"That student does not exist. Please enter a number between 1-{students.Count}: ");
            }
        }

        //this function verifies that the user has enetered a valid integer and passes it back to the try block in the LearnAboutStudent method
        //to be caught if falls outside of the index range
        public static int GetStudentNumber(string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch (FormatException)
            {
                Console.Write($"That is not a valid integer. Please try again! (enter a number 1-{students.Count}): ");
                return GetStudentNumber(Console.ReadLine());
            }
        }

        //this function verifies the entry that the user made for the type of data that they want from the student and passes it back to the
        //LearnAboutStudent method.
        public static string GetStudentInfo(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (input == "hometown")
                {
                    return "hometown";
                }
                else if (input == "favorite food")
                {
                    return "favorite food";
                }
                else if (input == "favorite color")
                {
                    return "favorite color";
                }
                else
                {
                    Console.Write("That data does not exist. Please try again. (Enter \"hometown\", \"favorite food\", or \"favorite color\": ");
                    return GetStudentInfo(Console.ReadLine());
                }
            }
            else
            {
                Console.Write("Oh come on! You didn't even try to enter data. Let's try this again!\n(Enter \"hometown\", \"favorite food\", or \"favorite color\": ");
                return GetStudentInfo(Console.ReadLine().ToLower());
            }
        }

        //this function handles the adding a new student to the list
        public static void AddStudent()
        {
            do
            {
                Console.Write("Please enter the student's name: ");
                string name = ValidateStudentData(Console.ReadLine().Trim());
                Console.Write("\nPlease enter the student's hometown: ");
                string hometown = ValidateStudentData(Console.ReadLine().Trim());
                Console.Write("\nPlease enter the student's favorite food: ");
                string favoriteFood = ValidateStudentData(Console.ReadLine().Trim());
                Console.Write("\nPlease enter the student's favorite color: ");
                string favoriteColor = ValidateStudentData(Console.ReadLine().Trim());

                students.Add(new StudentInfo
                {
                    Name = name,
                    Hometown = hometown,
                    FavoriteFood = favoriteFood,
                    FavoriteColor = favoriteColor
                });
                //splits the Name index of the StudentInfo list class and then sorts the new list by last name
                students.Sort(delegate (StudentInfo x, StudentInfo y)
                {
                    if (x.Name.Split(' ')[1] == null && y.Name.Split(' ')[1] == null) return 0;
                    else if (x.Name.Split(' ')[1] == null) return -1;
                    else if (y.Name.Split(' ')[1] == null) return 1;
                    else return x.Name.Split(' ')[1].CompareTo(y.Name.Split(' ')[1]);
                });
                Console.Write("Would you like to add another student to the list? (Enter \"yes\" or \"no\"): ");
            } while (ContinueProgram(Console.ReadLine()));
        }

        //this function validates that the user has entered data into each field during the AddStudent method
        public static string ValidateStudentData(string input)
        {
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("The entry cannot be blank. You must input data!: ");
                input = (Console.ReadLine());
            }
            return input;
        }

        //this function builds the initial list using the structs of the StudentInfo class
        public static List<StudentInfo> StudentData()
        {
            var students = new List<StudentInfo>();
            students.Add(new StudentInfo
            {
                Name = "Sean Armstrong",
                Hometown = "Grand Rapids, MI",
                FavoriteFood = "ramen noodles",
                FavoriteColor = "blue"
            });
            students.Add(new StudentInfo
            {
                Name = "Aquionette Blair",
                Hometown = "Kentwood, MI",
                FavoriteFood = "lasagna",
                FavoriteColor = "purple"
            });
            students.Add(new StudentInfo
            {
                Name = "Chris Butcher",
                Hometown = "Allendale, MI",
                FavoriteFood = "chicken salad",
                FavoriteColor = "green"
            });
            students.Add(new StudentInfo
            {
                Name = "Mike Cacciano",
                Hometown = "Hartford, CT",
                FavoriteFood = "Jimmy John's",
                FavoriteColor = "orange"
            });
            students.Add(new StudentInfo
            {
                Name = "Michael Clark",
                Hometown = "Flint, MI",
                FavoriteFood = "chicken schwarma",
                FavoriteColor = "white"
            });
            students.Add(new StudentInfo
            {
                Name = "Bradley Freestone",
                Hometown = "Grand Rapids, MI",
                FavoriteFood = "Electric Hero",
                FavoriteColor = "red"
            });
            students.Add(new StudentInfo
            {
                Name = "Jacob Hands",
                Hometown = "Chicago, IL",
                FavoriteFood = "steak",
                FavoriteColor = "green"
            });
            students.Add(new StudentInfo
            {
                Name = "Ross Hinman",
                Hometown = "Grand Rapids, MI",
                FavoriteFood = "brownies",
                FavoriteColor = "brown"
            });
            students.Add(new StudentInfo
            {
                Name = "Rabin Rai",
                Hometown = "Nepal",
                FavoriteFood = "chicken curry",
                FavoriteColor = "red"
            });
            students.Add(new StudentInfo
            {
                Name = "Sean Sculley",
                Hometown = "Vail, CO",
                FavoriteFood = "chinese food",
                FavoriteColor = "blue"
            });
            students.Add(new StudentInfo
            {
                Name = "Catherine Stafford",
                Hometown = "Grand Rapids, MI",
                FavoriteFood = "Mountain Dew Kickstart",
                FavoriteColor = "black"
            });
            students.Add(new StudentInfo
            {
                Name = "Bruce Vongphrachanh",
                Hometown = "Laos",
                FavoriteFood = "pizza",
                FavoriteColor = "brown"
            });
            return students;
        }

        //this function validates the user's entry to continue in multipe points of the application and passes the logic back to the loops
        private static bool ContinueProgram(string input)
        {
            //if statement will use user's input and determine whether or not to change the value of program in the while loop.
            if (input == "y" | input == "yes")
            {
                return true;
            }
            else if (input == "n" | input == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please only enter \"yes\" or \"no\"!");
                return ContinueProgram(Console.ReadLine().ToLower());
            }
            //end of if statement
        }

    }

    //this class sets the constructs of the list for the students and allows a single list entry to hold multiple pieces of add
    public class StudentInfo
    {
        public string Name { get; set; }
        public string Hometown { get; set; }
        public string FavoriteFood { get; set; }
        public string FavoriteColor { get; set; }
    }
}
