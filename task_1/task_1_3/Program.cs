using System;

namespace task_1_3
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

            int z = 1;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= N - i; j++)
                    Console.Write(" ");

                for (int j = 1; j <= z; j++)
                    Console.Write("*");

                z += 2;
                Console.Write("\n");
            }
        }
    }
}
