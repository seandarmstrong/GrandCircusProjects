using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDiagramClasses
{
    class Program
    {
        static List<Person> people = new List<Person>();

        static void Main(string[] args)
        {
            CreateList();
            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
            Console.ReadKey();

        }

        //this function creates a list to run through the main method to show how the inheritance and overrides work in the different classes
        static List<Person> CreateList()
        {
            people.Add(new Person("Billy Hoho", "1234 Getaway St, Grand Rapids, MI 49505"));
            people.Add(new Person("Tom Thimble", "456 Little Way, Grand Rapids, MI 49525"));
            people.Add(new Student("Sean Armstrong", "150 Main St, Grand Rapids, MI 49505", "Computer Science", 2019, 25000.34));
            people.Add(new Student("Michael Cacciano", "812 Michael Ave, Wyoming, MI 49418", "Computer Science", 2020, 35000.25));
            people.Add(new Student("Michael Clark", "612 State St, Grand Rapids, MI 49503", "Data Science", 2019, 45000));
            people.Add(new Student("Jacob Hands", "444 Wheel Ave, Comstock Park, MI 49346", "Computer Information Systems", 2021, 37560));
            people.Add(new Student("Sean Sculley", "65 Main St, Rockford, MI 49341", "Computer Science", 2019, 12400));
            people.Add(new Staff("Brian Gardner", "1124 Blossom Rd, Hudsonville, MI 49426", "Grand Circus", 10000));
            people.Add(new Staff("Justin Jones", "1356 Front St, Grand Rapids, MI 49504", "Grand Circus", 8000));
            people.Add(new Staff("Kelsey Perdue", "806 Monroe St, Grand Rapids, MI 49503", "Grand Circus", 45000));
            people.Add(new Staff("Amy Hinman", "356 Benjamin Ave, Grand Rapids, MI 49506", "Grand Circus", 22500));
            people.Add(new Staff("John Rumery", "2873 Alson Dr, Grand Rapids, MI 49505", "Grand Circus", 55000));
            return people;
        }
    }
}
