using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOfMovies
{
    class Program
    {
        //initiates list using properties from the Movie class
        public static List<Movie> _listOfMovies = new List<Movie>();
        const string MAIN_FORMAT = "{0,-6}{1,-12}";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Movie List Application");
            CreateList();
            do
            {
                DisplayMenu();
                switch (Console.ReadLine().Trim())
                {
                    case "1":
                        ViewAnimated();
                        break;
                    case "2":
                        ViewDrama();
                        break;
                    case "3":
                        ViewHorror();
                        break;
                    case "4":
                        ViewScifi();
                        break;
                    default:
                        Console.WriteLine("That is not a valid response. Please try again.");
                        break;
                }
                Console.Write("\nContinue?(y/n): ");
            } while (ContinueProgram(Console.ReadLine().Trim().ToLower()));

        }

        //this function displays the main menu
        public static void DisplayMenu()
        {
            Console.WriteLine($"\nThere are {_listOfMovies.Count} movies in this list.");
            Console.WriteLine(MAIN_FORMAT, "1.", "Animated");
            Console.WriteLine(MAIN_FORMAT, "2.", "Drama");
            Console.WriteLine(MAIN_FORMAT, "3.", "Horror");
            Console.WriteLine(MAIN_FORMAT, "4.", "Scifi");
            Console.Write("What category are you interested in viewing? ");
        }

        //this function calls the functions from Movie class that return the private properties and displays the movies that are labeled as animated.
        public static void ViewAnimated()
        {
            Console.WriteLine("\nANIMATED MOVIES");
            foreach (var movie in _listOfMovies)
            {
                if (movie.ReturnCategory() == "animated")
                {
                    Console.WriteLine(movie.ReturnTitle());
                }
            }
        }

        //this function calls the functions from Movie class that return the private properties and displays the movies that are labeled as drama.
        public static void ViewDrama()
        {
            Console.WriteLine("\nDRAMA MOVIES");
            foreach (var movie in _listOfMovies)
            {
                if (movie.ReturnCategory() == "drama")
                {
                    Console.WriteLine(movie.ReturnTitle());
                }
            }
        }

        //this function calls the functions from Movie class that return the private properties and displays the movies that are labeled as horror.
        public static void ViewHorror()
        {
            Console.WriteLine("\nHORROR MOVIES");
            foreach (var movie in _listOfMovies)
            {
                if (movie.ReturnCategory() == "horror")
                {
                    Console.WriteLine(movie.ReturnTitle());
                }
            }
        }

        //this function calls the functions from Movie class that return the private properties and displays the movies that are labeled as scifi.
        public static void ViewScifi()
        {
            Console.WriteLine("\nSCIFI MOVIES");
            foreach (var movie in _listOfMovies)
            {
                if (movie.ReturnCategory() == "scifi")
                {
                    Console.WriteLine(movie.ReturnTitle());
                }
            }
        }

        //this function tests whether the user wants to continue the program and returns a bool value for the do-while loop in the main method
        public static bool ContinueProgram(string response)
        {
            if (response == "y" || response == "yes")
            {
                return true;
            }
            else if (response == "n" || response == "no")
            {
                return false;
            }
            else
            {
                Console.Write("Not a valid response. Do you want to continue?(y/n): ");
                return ContinueProgram(Console.ReadLine().Trim().ToLower());
            }
        }

        //this function creates the list using the child classes of the Movie class
        public static List<Movie> CreateList()
        {

            _listOfMovies.Add(new Animated("Coco"));
            _listOfMovies.Add(new Animated("Shrek"));
            _listOfMovies.Add(new Drama("Dangerous Minds"));
            _listOfMovies.Add(new Drama("Braveheart"));
            _listOfMovies.Add(new Drama("Shawshank Redemption"));
            _listOfMovies.Add(new Horror("IT"));
            _listOfMovies.Add(new Horror("The Shining"));
            _listOfMovies.Add(new Scifi("Star Wars: A New Hope"));
            _listOfMovies.Add(new Scifi("Cloverfield"));
            _listOfMovies.Add(new Scifi("Aliens"));
            _listOfMovies.Sort((x, y) => string.Compare(x.ReturnTitle(), y.ReturnTitle()));
            return _listOfMovies;
        }
    }
}
