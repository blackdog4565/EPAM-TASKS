using System;

namespace task_1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            for (int i = 1; i < 1000; i++)
                sum = ((i % 3 == 0) || (i % 5 == 0)) ? sum + i : sum;

            Console.WriteLine(sum);
        }
    }
}
