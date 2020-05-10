using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesMaintenance
{
    public class CountriesTextFile
    {
        private string _path =
            @"C:\Users\armst\Documents\Grand_Circus\Lab_16\ListOfCountries\Country.Library\countries.txt";

        //this function opens the file at the private path above, determines if there is text within the file and then display the countries
        //in the text file. It catches the exception if no file exists at the private path above.
        public void ReadCountriesFile()
        {
            try
            {
                using (var reader = new StreamReader(_path))
                {
                    if (new FileInfo(_path).Length > 0)
                    {
                        Console.WriteLine("");
                        while (true)
                        {
                            string line = reader.ReadLine();
                            Console.WriteLine(line);
                            if (reader.EndOfStream)
                            {
                                break;
                            }
                        }

                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("The file exists but is empty right now. Add a country before viewing the file.\n");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("I'm sorry but that file was not found. Please add a country to create it.\n");
            }

        }

        //this function handles the adding and writing of new countries to the text file found at the private path above
        public void WriteCountriesFile()
        {
            if (!File.Exists(_path))
            {
                using (FileStream file = File.Create(_path))
                {
                }
            }
            var validate = new Validator();
            do
            {
                var countryToAdd = validate.ValidateCountry();
                using (StreamWriter writer = new StreamWriter(_path, append: true))
                {
                    writer.WriteLine(countryToAdd);
                }

                Console.Write("Do you want to add another country? (y/n): ");
            } while (validate.ContinueProgram(Console.ReadLine().ToLower().Trim()));

            Console.WriteLine("");
        }

        //this function deletes a country from the text file that a user inputs. it does this by firsting checking that a file exists, that the
        //country exists in the file, and then copying all of the lines over to a temp file, except the line to be removed, deleting the file,
        //and moving the temp file to the old file location, thus replacing it.
        public void DeleteCountry()
        {
            var validate = new Validator();
            if (File.Exists(_path))
            {
                if (new FileInfo(_path).Length > 0)
                {
                    Console.Write("Enter country to be deleted: ");
                    var countryToDelete = validate.VerifyCountryOnList(Console.ReadLine().Trim());
                    var tempFile =
                        @"C:\Users\armst\Documents\Grand_Circus\Lab_16\ListOfCountries\Country.Library\countries.tmp";
                    using (var reader = new StreamReader(_path))
                    using (var writer = new StreamWriter(tempFile))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line != countryToDelete)
                            {
                                writer.WriteLine(line);
                            }
                        }
                    }

                    Console.WriteLine("The country has been deleted!\n");
                    File.Delete(_path);
                    File.Move(tempFile, _path);
                }
                else
                {
                    Console.WriteLine("The file is empty. You must add a country to it before deleting.\n");
                }
            }
            else
            {
                Console.WriteLine("The file doesn't exist. Please create a file by adding a country.\n");
            }
        }
    }
}
