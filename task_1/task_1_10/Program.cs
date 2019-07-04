using System;

namespace task_1_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Random R = new Random();

            int n = 3,
                m = 4,
                sum = 0;

            int[,] mas = new int[n, m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    mas[i, j] = R.Next(0, 10);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write("\t" + mas[i, j] + " ");

                Console.Write("\n");
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    sum = (i + j) % 2 == 0 ? sum + mas[i, j] : sum;

            Console.Write("sum = "+ sum);
        }
    }
}
