using System;

namespace task_1_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString, secondString;

            Console.Write("Введите первую строку: ");
            firstString = Console.ReadLine();

            Console.Write("Введите вторую строку: ");
            secondString = Console.ReadLine();

            for (int i = 0; i < firstString.Length; i++)
                if (secondString.IndexOf(firstString[i]) != -1)
                {
                    firstString = firstString.Insert(i, firstString[i] + "");
                    i++;
                }

            Console.WriteLine("Результат: " + firstString);
        }
    }
}
