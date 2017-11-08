using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_Deliverable14_Lab15_Countries
{
    class Program
    {
        /****************************************************************************/
        static void Main(string[] args)
        {
            Console.WriteLine("/******************************************/");
            Console.WriteLine("/* Nations of Earth DB Management Console */");
            Console.WriteLine("/******************************************/");

            bool keepGoing = true;
            while (keepGoing)
            {
                ListMenu();
                keepGoing = GatherInput();
            }

            Console.WriteLine();
            Console.WriteLine("Thanks for using the DB. Good Bye!");
        }
        /****************************************************************************/
        public static bool GatherInput ()
        {
            MenuOptions m;
            bool validInput;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter menu option: ");
                string userInput = Console.ReadLine();

                validInput = Enum.TryParse(userInput, out m);

           
                if (m == MenuOptions.SEE)
                {
                    List<string> countries = CountriesTextFile.ReadDb();

                    if (countries != null)
                    {
                        foreach (string country in countries)
                        {
                            Console.WriteLine($"{country}");
                        }
                    }

                    return true;
                }
                else if (m == MenuOptions.ADD)
                {
                    CountriesTextFile.AddCountry();
                    return true;
                }
                else if (m == MenuOptions.EXIT)
                {
                    return false;
                }

                Console.WriteLine();
                Console.WriteLine("I'm sorry, but that was not a valid option. Please try again");
                Console.WriteLine();
                ListMenu();
            }
        }

        public static void ListMenu()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++");
            Console.WriteLine("+           Options           +");
            Console.WriteLine("+++++++++++++++++++++++++++++++");
            Console.WriteLine(" 1 -> See list of countries");
            Console.WriteLine(" 2 -> Add a country");
            Console.WriteLine(" 3 -> Exit");
        }
    }
}
