using System;
using System.Text.RegularExpressions;

namespace task_7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Иван: ivan@mail.ru, Петр: .p_ivanov@mail.rol.ruerqererewr";
            Regex regex1 = new Regex(@"([a-z0-9])+[a-z0-9\-_\.]*@([a-z\.]+[a-z]{2,6})+");

            MatchCollection matches2 = regex1.Matches(s1);

            if (matches2.Count > 0)
            {
                foreach (Match match in matches2)
                    Console.WriteLine(match.Value);
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }
        }
    }
}
