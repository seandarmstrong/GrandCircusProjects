using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskManager
{
    class Program
    {
        private const string MENU_FORMAT = "{0, -4}{1, -20}";
        private const string LIST_FORMAT = "{0, -6}{1, -8}{2, -13}{3, -18}{4,-35}";
        private const string CONFIRM_FORMAT = "{0, -8}{1, -13}{2, -15}{3,-35}";
        public static List<Task> _taskList = new List<Task>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Task Manager!");
            var keepRunning = true;
            while (keepRunning)
            {
                DisplayMenu();
                switch (Console.ReadLine().Trim())
                {
                    case "1":
                        ListTasks();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        DeleteTask();
                        break;
                    case "4":
                        MarkTaskComplete();
                        break;
                    case "5":
                        EditTask();
                        break;
                    case "6":
                        keepRunning = QuitProgram();
                        break;
                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;
                }
            }
            Console.WriteLine("Goodbye. Have a great day!");
            Console.ReadKey();
        }

        //this function displays the main menu and asks for user input
        public static void DisplayMenu()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine(MENU_FORMAT, "\t1.", "List tasks");
            Console.WriteLine(MENU_FORMAT, "\t2.", "Add task");
            Console.WriteLine(MENU_FORMAT, "\t3.", "Delete task");
            Console.WriteLine(MENU_FORMAT, "\t4.", "Mark task complete");
            Console.WriteLine(MENU_FORMAT, "\t5.", "Edit task");
            Console.WriteLine(MENU_FORMAT, "\t6.", "Quit");
            Console.Write("What would you like to do? ");
        }

        //this method will display the tasks that are entered. it provides a menu for the user to decide how they want to view the tasks
        public static void ListTasks()
        {
            Console.WriteLine("\nLIST TASKS");

            if (_taskList.Count > 0)
            {
                Console.WriteLine(MENU_FORMAT, "\t1.", "View All");
                Console.WriteLine(MENU_FORMAT, "\t2.", "View By Name");
                Console.WriteLine(MENU_FORMAT, "\t3.", "View Due By Specific Date");
                Console.Write("Would you like to view all, view by name, or view tasks due by specific date? ");
                switch (Console.ReadLine().Trim())
                {
                    case "1":
                        ViewAll();
                        break;
                    case "2":
                        ViewByName();
                        break;
                    case "3":
                        ViewByDate();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nClose your eyes, what do you see? That's right, there's nothing here! Please enter a task first.");
            }
            Console.WriteLine("\nPress any key to go back to the main menu when ready.\n");
            Console.ReadKey();
        }

        //this function handles the view all option in list tasks
        public static void ViewAll()
        {
            Console.WriteLine("\nVIEW ALL TASKS");
            Console.WriteLine(LIST_FORMAT, "Task", "Done?", "Due Date", "Team Member", "Description");
            foreach (var task in _taskList)
            {
                Console.WriteLine(LIST_FORMAT, (_taskList.IndexOf(task) + 1), task.Status, task.DueDate, task.Name, task.Description);
            }
        }

        //this function handles the view by name option in list tasks
        public static void ViewByName()
        {
            Console.WriteLine("\nVIEW TASKS BY NAME");
            Console.Write("Which team member would you like to view? ");
            var teamMember = Console.ReadLine().Trim();
            Console.WriteLine(LIST_FORMAT, "Task", "Done?", "Due Date", "Team Member", "Description");
            foreach (var task in _taskList)
            {
                if (task.Name.Contains(teamMember))
                {
                    Console.WriteLine(LIST_FORMAT, (_taskList.IndexOf(task) + 1), task.Status, task.DueDate, task.Name, task.Description);
                }
            }
        }

        //this function determines the tasks that are due BEFORE the entered due date (not on) and display them from the list tasks method
        public static void ViewByDate()
        {
            Console.WriteLine("\nVIEW TASKS BY DUE DATE");
            Console.Write("View tasks due before what date? ");
            var dateToCompare = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(LIST_FORMAT, "Task", "Done?", "Due Date", "Team Member", "Description");
            foreach (var task in _taskList)
            {
                var date = Convert.ToDateTime(task.DueDate);
                int result = DateTime.Compare(date, dateToCompare);
                if (result < 0)
                {
                    Console.WriteLine(LIST_FORMAT, (_taskList.IndexOf(task) + 1), task.Status, task.DueDate, task.Name, task.Description);
                }
            }

        }

        //this function handles the addition of adding tasks to the task manager list, only accepting valid data
        public static void AddTask()
        {
            Console.WriteLine("\nADD A TASK");
            Console.Write("Team Member Name: ");
            var name = ValidateName(Console.ReadLine().Trim());
            Console.Write("Task Description: ");
            var description = Console.ReadLine().Trim();
            //do-while loop that verifies that the due date is in the future and won't allow dates in the past
            do
            {
                Console.Write("Due Date: ");
                try
                {
                    var inputDate = DateTime.Parse(Console.ReadLine());
                    int result = DateTime.Compare(inputDate, DateTime.Now.AddDays(-1));
                    if (result > 0)
                    {
                        var date = inputDate.Date.ToString("d");
                        _taskList.Add(new Task(date, name, description) { Status = false });
                        Console.WriteLine("\nTask has been entered! Press any key to go back to the main menu.\n");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The due date must be on or after today. Due dates cannot be in the past.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("That is not a date! Let's try this again.\n");
                }
            } while (true);
        }

        //this function valids the name entered in AddTask method or EditTask method. It allows first name only or first and last name but does
        //not allow numbers or special characters.
        public static string ValidateName(string name)
        {
            var firstAndLast = new Regex(@"^[A-Z]{1}[a-z]{1,29}\s[A-Z]{1}[a-z]{1,29}$");
            var firstOnly = new Regex(@"^[A-Z]{1}[a-z]{1,29}$");
            while (true)
            {
                if (firstAndLast.IsMatch(name) || firstOnly.IsMatch(name))
                {
                    return name;
                }
                else
                {
                    Console.Write("Sorry, name is not valid!\nTeam Member Name: ");
                    return ValidateName(Console.ReadLine().Trim());
                }
            }
        }

        //this function will delete the task the user chooses after they confirm deletion. it only shows task numbers that are in the list
        public static void DeleteTask()
        {
            Console.WriteLine("\nDELETE A TASK");
            do
            {
                if (_taskList.Count == 0)
                {
                    Console.WriteLine("It doesn't appear that any tasks have been added yet. Please add a task to delete a task.\n");
                    Console.WriteLine("\nPress any key to go back to the main menu when ready.\n");
                    Console.ReadKey();
                    break;
                }
                Console.Write($"Please enter the task number that you would like to delete from the list (1 - {_taskList.Count}): ");
                var taskIndex = ValidateEntryNumber(Console.ReadLine()) - 1;
                foreach (var task in _taskList)
                {
                    if (_taskList.IndexOf(task) == taskIndex)
                    {
                        Console.WriteLine(CONFIRM_FORMAT, "Done?", "Due Date", "Team Member", "Description");
                        Console.WriteLine(CONFIRM_FORMAT, task.Status, task.DueDate, task.Name, task.Description);
                    }
                }
                Console.Write("\nIs this the task you want deleted? (yes or no): ");
                var userResponse = Console.ReadLine().Trim().ToLower();
                if (userResponse == "yes" || userResponse == "y")
                {
                    _taskList.RemoveAt(taskIndex);
                    Console.WriteLine("\nTask has been deleted! Press any key to go back to the main menu.\n");
                    Console.ReadKey();
                    break;
                }
                else if (userResponse == "no" || userResponse == "n")
                {
                    Console.WriteLine("\nTask has NOT been deleted! Press any key to go back to the main menu.\n");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("That is not a valid response. Please try again.");
                }
            } while (true);
        }

        //this function marks the task the user chooses as completed if they confirm the task selection
        public static void MarkTaskComplete()
        {
            Console.WriteLine("\nMARK TASK COMPLETE");
            do
            {
                if (_taskList.Count == 0)
                {
                    Console.WriteLine("Oops, you can't mark something as completed that doesn't exist. Go add a task first.\n");
                    Console.WriteLine("\nPress any key to go back to the main menu when ready.\n");
                    Console.ReadKey();
                    break;
                }
                Console.Write($"Please enter the task number that you would like to mark as completed (1 - {_taskList.Count}): ");
                var taskIndex = ValidateEntryNumber(Console.ReadLine()) - 1;
                foreach (var task in _taskList)
                {
                    if (_taskList.IndexOf(task) == taskIndex)
                    {
                        Console.WriteLine(CONFIRM_FORMAT, "Done?", "Due Date", "Team Member", "Description");
                        Console.WriteLine(CONFIRM_FORMAT, task.Status, task.DueDate, task.Name, task.Description);
                    }
                }
                Console.Write("\nIs this the task you want to mark as completed? (yes or no): ");
                var userResponse = Console.ReadLine().Trim().ToLower();
                if (userResponse == "yes" || userResponse == "y")
                {
                    foreach (var task in _taskList)
                    {
                        if (_taskList.IndexOf(task) == taskIndex)
                        {
                            task.Status = true;
                        }
                    }
                    Console.WriteLine("The status has changed! Please press any key to go back to the main menu.");
                    Console.ReadKey();
                    break;
                }
                else if (userResponse == "no" || userResponse == "n")
                {
                    Console.WriteLine("\nTask has NOT been marked complete! Press any key to go back to the main menu.\n");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("That is not a valid response. Please try again.");
                }
            } while (true);
        }

        //this function edits the task the user chooses if they confirm the task selection and then enter new information
        public static void EditTask()
        {
            Console.WriteLine("\nEDIT TASK");
            do
            {
                if (_taskList.Count == 0)
                {
                    Console.WriteLine("I don't see any tasks yet to edit. Add one first and then edit away!\n");
                    Console.WriteLine("\nPress any key to go back to the main menu when ready.\n");
                    Console.ReadKey();
                    break;
                }
                Console.Write($"Please enter the task number that you would like to edit (1 - {_taskList.Count}): ");
                var taskIndex = ValidateEntryNumber(Console.ReadLine()) - 1;
                foreach (var task in _taskList)
                {
                    if (_taskList.IndexOf(task) == taskIndex)
                    {
                        Console.WriteLine(CONFIRM_FORMAT, "Done?", "Due Date", "Team Member", "Description");
                        Console.WriteLine(CONFIRM_FORMAT, task.Status, task.DueDate, task.Name, task.Description);
                    }
                }
                Console.Write("\nIs this the task that you would like to edit? (yes or no): ");
                var userResponse = Console.ReadLine().Trim().ToLower();
                if (userResponse == "yes" || userResponse == "y")
                {
                    Console.Write("Team Member: ");
                    var name = ValidateName(Console.ReadLine().Trim());
                    Console.Write("Task Description: ");
                    var description = Console.ReadLine().Trim();
                    //this do-while validates that the date entered is not in the past
                    do
                    {
                        Console.Write("Due Date: ");
                        try
                        {
                            var inputDate = DateTime.Parse(Console.ReadLine());
                            int result = DateTime.Compare(inputDate, DateTime.Now.AddDays(-1));
                            if (result > 0)
                            {
                                var date = inputDate.Date.ToString("d");
                                foreach (var task in _taskList)
                                {
                                    if (_taskList.IndexOf(task) == taskIndex)
                                    {
                                        task.Name = name;
                                        task.Description = description;
                                        task.DueDate = date;
                                    }
                                }
                                Console.WriteLine("The task has been edited! Please press any key to go back to the main menu.");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("The due date must be on or after today. Due dates cannot be in the past. ");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("That is not a date! Let's try this again.\n");
                        }
                    } while (true);
                    break;
                }
                else if (userResponse == "no" || userResponse == "n")
                {
                    Console.WriteLine("\nTask has NOT been edited! Press any key to go back to the main menu.\n");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("That is not a valid response. Please try again.");
                }
            } while (true);
        }

        //this function confirms that the user wants to exit the program and then exits if they confirm
        public static bool QuitProgram()
        {
            Console.Write("Are you sure you want to exit the program? (yes or no): ");
            var userResponse = Console.ReadLine().Trim().ToLower();
            if (userResponse == "yes" || userResponse == "y")
            {
                return false;
            }
            else if (userResponse == "no" || userResponse == "n")
            {
                return true;
            }
            else
            {
                Console.WriteLine("That response didn't make sense.\n");
                return QuitProgram();
            }
        }

        //this function is validating that the number entered in the delete, mark complete, and edit tasks are within the range of the list
        //at the time of request
        public static int ValidateEntryNumber(string userInput)
        {
            int number = 0;
            if (int.TryParse(userInput, out number) && number > 0 && number <= _taskList.Count)
            {
                return number;
            }
            else
            {
                Console.Write($"That entry is not within the correct range. Enter a number 1 to {_taskList.Count}: ");
                return ValidateEntryNumber(Console.ReadLine());
            }
        }
    }
}
