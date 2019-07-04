using System;

namespace task_1_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Random R = new Random();

            int[] mas = new int[4];

            for (int i = 0; i < mas.Length; i++)
                mas[i] = R.Next(-100, 100);

            int temp = 0;

            for (int i = 0; i < mas.Length; i++)
                if (i == mas.Length - 1)
                    Console.WriteLine(mas[i]);
                else
                    Console.Write(mas[i] + ", ");

            Console.WriteLine(" ");

            for (int i = 0; i < mas.Length; i++)
                for (int j = 0; j < mas.Length - 1; j++)
                    if (mas[j] > mas[j + 1])
                    {
                        temp = mas[j + 1];
                        mas[j + 1] = mas[j];
                        mas[j] = temp;
                    }

            for (int i = 0; i < mas.Length; i++)
                if (i == mas.Length - 1)
                    Console.Write(mas[i]);
                else
                    Console.Write(mas[i] + ", ");

            Console.WriteLine("\n\nmin = " + mas[0] + "\nmax = " + mas[mas.Length - 1]);
        }
    }
}
