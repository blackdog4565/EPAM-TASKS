using System;

namespace task_1_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Random R = new Random();

            int[] mas = new int[8];

            int sum = 0;

            for (int i = 0; i < mas.Length; i++)
                mas[i] = R.Next(-10, 10);

            for (int i = 0; i < mas.Length; i++)
                Console.Write(mas[i] + " ");

            Console.WriteLine();
            
            for (int i = 0; i < mas.Length; i++)
                sum = mas[i] > 0 ? sum + mas[i] : sum;

            Console.WriteLine("sum = " + sum);
        }
    }
}
