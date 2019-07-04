using System;

namespace task_0_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;

            while ((N <= 0) || (N % 2 == 0))
            {
                Console.Write("Введите положительное нечетное целое число N: ");
                int.TryParse(Console.ReadLine(), out N);
                Console.WriteLine("");

                if ((N <= 0) || (N % 2 == 0))
                    Console.WriteLine("Введены неверные значения");
            }

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                    if ((i == (N / 2) + 1) && (j == (N / 2) + 1))
                        Console.Write("  ");
                    else
                        Console.Write("* ");
                Console.Write("\n");
            }
        }
    }
}
