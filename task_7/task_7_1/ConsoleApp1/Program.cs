using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "2016 год наступит 01-01-2016";
            Regex regex = new Regex(@"\d{2}-\d{2}-\d{4}");


            MatchCollection matches = regex.Matches(s);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }

            

            Console.WriteLine("Hello World!");
        }
    }
}
