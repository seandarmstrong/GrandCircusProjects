using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{ValidateName()} is a valid name!:");
            Console.WriteLine($"{ValidateEmail()} is a valid email address!");
            Console.WriteLine($"{ValidatePhoneNumber()} is a valid phone number!");
            Console.WriteLine($"{ValidateDate()} is a valid date!");
            Console.WriteLine($"{ValidateHTML()} is a valid HTML tag!");
        }

        //this function validates the user input per the requirements for Name and displays the results if valid
        public static string ValidateName()
        {
            var pattern = new Regex(@"^[A-Z]{1}[a-z]{1,29}$");
            Console.Write("Please enter a valid Name: ");
            string name = Console.ReadLine();
            while (true)
            {
                if (pattern.IsMatch(name))
                {
                    return name;
                }
                else
                {
                    Console.WriteLine("Sorry, name is not valid!");
                    return ValidateName();
                }
            }
        }

        //this function validates the user input per the requirements for Email and displays the results if valid
        public static string ValidateEmail()
        {
            Console.Write("\nPlease enter a valid email: ");
            string email = Console.ReadLine();
            var pattern = new Regex(@"^[a-zA-Z0-9]{5,30}@[a-zA-Z0-9]{5,10}\.[a-zA-Z0-9]{2,3}$");
            while (true)
            {
                if (pattern.IsMatch(email))
                {
                    return email;
                }
                else
                {
                    Console.WriteLine("Sorry, email is not valid!");
                    return ValidateEmail();
                }
            }
        }

        ////this function validates the user input per the requirements for Phone Number and displays the results if valid
        public static string ValidatePhoneNumber()
        {
            Console.Write("\nPlease enter a valid phone number (xxx-xxx-xxxx): ");
            string phone = Console.ReadLine();
            var pattern = new Regex(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$");
            while (true)
            {
                if (pattern.IsMatch(phone))
                {
                    return phone;
                }
                else
                {
                    Console.WriteLine("Sorry, phone number is not valid!");
                    return ValidatePhoneNumber();
                }
            }
        }

        //this function validates the user input per the requirements for Date and displays the results if valid
        public static string ValidateDate()
        {
            Console.Write("\nPlease enter a valid date (mm/dd/yyyy): ");
            string date = Console.ReadLine();
            var pattern = new Regex(@"^[0-9]{2}\/[0-9]{2}\/[0-9]{4}$");
            while (true)
            {
                if (pattern.IsMatch(date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Sorry, date is not valid!");
                    return ValidateDate();
                }
            }
        }

        //this function validates the user input per the requirements for a HTML Element and displays the results if valid
        public static string ValidateHTML()
        {
            Console.Write("\nPlease enter a valid HTML tag: ");
            string html = Console.ReadLine();
            var pattern = new Regex(@"^<(\w*)>.*<\/\1>$");
            while (true)
            {
                if (pattern.IsMatch(html))
                {
                    return html;
                }
                else
                {
                    Console.WriteLine("Sorry, HTML tag is not valid!");
                    return ValidateHTML();
                }
            }
        }
    }
}
