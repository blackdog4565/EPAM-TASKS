using System;

namespace task_1_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random R = new Random();

            int[,,] mas = new int[3, 3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        mas[i, j, k] = R.Next(-100, 100);

            showMas(mas);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        if (mas[i, j, k] > 0)
                            mas[i, j, k] = 0;

            Console.WriteLine("\nNew array\n");

            showMas(mas);

        }
        static void showMas(int[,,] mas)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Console.Write(mas[i, j, k] + " ");
                    }
                    Console.WriteLine("");
                }
        }
    }
}
