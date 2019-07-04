using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;

            while (N <= 0)
            {
                Console.Write("Введите число N: ");
                int.TryParse(Console.ReadLine(), out N);
                Console.WriteLine("");

                if (N <= 0)
                    Console.WriteLine("Введены неверные значения");

            }

            Console.WriteLine(WriteNumbers(N));
        }
        static string WriteNumbers(int N)
        {
            string yourString = "";

            for (int i = 1; i <= N; i++)
                if (i == N)
                    yourString += i.ToString();
                else
                    yourString += i.ToString() + ", ";

            return yourString;
        }
    }
}
