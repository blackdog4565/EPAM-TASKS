using System;
using System.Collections;
using System.Collections.Generic;
namespace task_4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = { "f", "r", "2efwe" };
            string sum = s.Sum();
            Console.WriteLine(sum);
        }
    }
    public static class ArrayExtension
    {
        public static T Sum<T>(this T[] array)
        {
            return SumFull(array, (a, b) => a as dynamic + b as dynamic);
        }
        private static T SumFull<T>(T[] array, Func<T, T, T> comp)
        {
            if (comp == null)
            {
                throw new ArgumentNullException("Delegate is null");
            }
            T sum = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sum = comp(sum, array[i]);
            }
            return sum;
        }
        
    }
}
