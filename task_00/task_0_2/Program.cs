﻿using System;

namespace task_0_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;

            while ((N <= 0))
            {
                Console.Write("Введите положительное целое число N: ");
                int.TryParse(Console.ReadLine(), out N);
                Console.WriteLine("");

                if (N <= 0)
                    Console.WriteLine("Введены неверные значения");
            }

            if (IsSimple(N) == true)
                Console.WriteLine("Простое");
            else
                Console.WriteLine("Составное");
        }
        static bool IsSimple(int N)
        {
            if (N == 1)
                return true;

            int d = 2;

            while (N % d != 0)
                d += 1;

            return d == N;
        }
    }
}
