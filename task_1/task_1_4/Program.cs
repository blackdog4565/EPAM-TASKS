using System;

namespace task_1_4
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
                Console.WriteLine("");
            }
            for (int i = 0; i <= N; i++)
            {
                int z = 1;

                for (int l = 0; l <= i; l++)
                {
                    for (int j = 0; j <= N + l - z; j++)
                        Console.Write(" ");

                    for (int j = 1; j <= z; j++)
                        Console.Write("*");

                    z += 2;
                    Console.Write("\n");
                }
            }
        }
    }
}
