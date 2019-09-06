using System;
using System.Text.RegularExpressions;

namespace task_7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(\<(/?[^>]+)>)");
            string s = "<b>Это</b> текст <i>с</i> <font color=\"red\">HTML</font> кодами ";

            MatchCollection matches = regex.Matches(s);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                    s = s.Replace(match.Value, "_");
                }
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }

            Console.WriteLine(s);
        }
    }
}
