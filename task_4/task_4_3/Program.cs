﻿using System;
using System.Threading;

namespace task_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startProgram = DateTime.Now;

            int[] r = { 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5 };
            int[] a = { 1, 4, 1, 31, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5 };
            int[] b = { 2, 1, 0, 10, 41, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5, 1, 9, 3, 5 };

            SortingUnit.info += ShowMessage;

            SortingUnit.SortThread(r);
            SortingUnit.SortThread(a);
            SortingUnit.SortThread(b);

            Thread.Sleep(100); // без задержки вывод элементов происходит раньше сортировки

            Console.WriteLine();

            foreach (var item in a)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            foreach (var item in r)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            foreach (var item in b)
            {
                Console.Write(item + " ");
            }

            TimeSpan endProgram = DateTime.Now - startProgram;
            Console.WriteLine();
            Console.WriteLine(endProgram);
        }
        public static void ShowMessage(string mes)
        {
            Console.WriteLine(mes);
        }
    }
}
