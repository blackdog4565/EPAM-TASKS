using System;

namespace task_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ar = { "ag", "b", "a" };
            foreach (var item in ar)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Sort(ar, Compare);
            foreach (var item in ar)
            {
                Console.WriteLine(item);
            }
        }
        static bool Compare(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return true;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > b[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static void Sort(string[] array, Func<string, string, bool> comp)
        {
            if (comp == null)
            {
                throw new ArgumentNullException("Delegate is null");
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    string temp;
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
