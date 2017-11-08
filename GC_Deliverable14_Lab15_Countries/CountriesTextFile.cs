using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_Deliverable14_Lab15_Countries
{
    class CountriesTextFile
    {
        private const string TXTFILE = "countries.txt";
        private static StreamReader infile;
        private static StreamWriter outfile;

        private CountriesTextFile ()
        {
            infile = null;
            outfile = null;
        }

        public static List<string> ReadDb ()
        {
            //catch file access errors. exit if any are found.
            try
            {
                infile = new StreamReader(TXTFILE);
            }
            catch (SystemException e)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR READING FILE: Country DB does not exist.");
                Console.WriteLine("Add a country (option #2) and the database will be created for you.");
                //Console.WriteLine($"DETAILS: {e.Message}");
                return null;
            }

            List<string> countries = new List<string>();
            if (infile.EndOfStream && countries.Count == 0)
            {
                Console.WriteLine("End of file reached. No records exist in the database!");
                return null;
            }
            else
            {
                string input;
                while (infile.EndOfStream == false)
                {
                    input = infile.ReadLine();
                    if (input != "")
                    {
                        countries.Add(input.Trim());
                    }
                }

                infile.Close();
                return countries;
            }
        }

        public static void AddCountry ()
        {
            try
            {
                outfile = new StreamWriter(TXTFILE, true);
            }
            catch (SystemException e)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WRITING TO FILE: Please make sure the countries.txt exists or it has the proper permissions set. Consult your systems administrator for help.");
                Console.WriteLine($"DETAILS: {e.Message}");
            }

            Console.Write("Add a country: ");
            outfile.WriteLine(Console.ReadLine());
            Console.WriteLine("The country has been added to the database.");
            outfile.Close();
        }
    }
}
