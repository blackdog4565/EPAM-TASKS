using System;
using System.Collections;
using System.Collections.Generic;
namespace task_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] ar = {'r', 'e'};

            foreach (var item in ar)
            {
                Console.WriteLine(item);
            }

            Sort(ar, (a, b) => a > b);
            Console.WriteLine();

            foreach (var item in ar)
            {
                Console.WriteLine(item);
            }
        }
        
        private static void Sort<T>(T[] array, Func<T, T, bool> comp)
        {
            if (comp == null)
            {
                throw new ArgumentNullException("Delegate is null");
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    T temp;
                    if (comp(array[j], array[j + 1]))
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
