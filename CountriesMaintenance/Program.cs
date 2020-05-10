using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesMaintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            var validate = new Validator();
            Console.WriteLine("Welcome to the Countries Maintenance Application!");
            bool loop = true;
            do
            {
                var menu = new CountriesApp();
                menu.DisplayMenu();
                var userReponse = menu.GetUserResponse();
                loop = menu.HandleUserReponse(userReponse);
            } while (loop);

            Console.WriteLine("Thank you and goodbye!");
            Console.ReadKey();
        }
    }
}
