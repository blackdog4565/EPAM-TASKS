using System;

namespace task_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;

            while (N <= 0)
            {
                Console.Write("Введите положительное целое число N: ");
                int.TryParse(Console.ReadLine(), out N);
                Console.WriteLine();
            }
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= i; j++)
                    Console.Write("*");
                Console.Write("\n");
            }
        }
    }
}
