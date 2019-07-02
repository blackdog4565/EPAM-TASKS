using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число N: ");
            int.TryParse(Console.ReadLine(), out int N);
            Console.WriteLine("");

            while (N <= 0)
            {
                Console.Write("Число N не положительное." + "\n" + "Введите положительное число N: ");

                int.TryParse(Console.ReadLine(), out int val);
                N = val;

                Console.WriteLine("");
            }

            Console.WriteLine(WriteNumbers(N));
        }
        static string WriteNumbers(int N)
        {
            string yourString = "";
            for (int i = 1; i <= N; i++)
            {
                if (i == N)
                {
                    yourString += i.ToString();
                }
                else
                {
                    yourString += i.ToString() + ", ";
                }
            }
            return yourString;
        }
    }
}
