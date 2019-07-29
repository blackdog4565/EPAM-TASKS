using System;
using System.Linq;

namespace task_4_6
{
    class Program
    {
        delegate bool Condition<T>(T item);
        static void Main(string[] args)
        {
            Predicate<int> pred = IsPositive;
            Condition<int> cond = delegate (int t)
            {
                return t > 0;
            };

            int[] a = { -1, 2, 1, 3, -5 };

            int[] def = SearchPositive(a);
            int[] del = SearchWithDelegate(a, pred);
            int[] anon = SearchWithAnon(a, cond);
            int[] lymb = SearchWithLymb(a, (b) => b > 0);
            int[] linq = SearchWithLinq(a);

            foreach (var item in def)
            {
                Console.WriteLine(item);
            }
            foreach (var item in del)
            {
                Console.WriteLine(item);
            }
            foreach (var item in anon)
            {
                Console.WriteLine(item);
            }
            foreach (var item in lymb)
            {
                Console.WriteLine(item);
            }
            foreach (var item in linq)
            {
                Console.WriteLine(item);
            }
        }
        static bool IsPositive<T>(T item)
        {
            if (item as dynamic > 0)
            {
                return true;
            }
            return false;
        }
        static T[] SearchWithLymb<T>(T[] array, Func<T, bool> condition)
        {
            T[] PositiveElements = new T[0];

            foreach (T item in array)
            {
                if (condition != null)
                {
                    if (condition.Invoke(item))
                    {
                        PositiveElements = AddPositiveElem(PositiveElements, item);
                    }
                }
            }

            return PositiveElements;
        }
        static T[] SearchWithAnon<T>(T[] array, Condition<T> condition)
        {
            T[] PositiveElements = new T[0];

            foreach (T item in array)
            {
                if (condition != null)
                {
                    if (condition(item))
                    {
                        PositiveElements = AddPositiveElem(PositiveElements, item);
                    }
                }
            }

            return PositiveElements;
        }
        static T[] SearchWithDelegate<T>(T[] array, Predicate<T> condition)
        {
            T[] PositiveElements = new T[0];

            foreach (T item in array)
            {
                if (condition != null)
                {
                    if (condition.Invoke(item))
                    {
                        PositiveElements = AddPositiveElem(PositiveElements, item);
                    }
                }
            }

            return PositiveElements;
        }
        static T[] SearchPositive<T>(T[] array)
        {
            T[] PositiveElements = new T[0];

            foreach (T item in array)
            {
                if (item as dynamic > 0)
                {
                    PositiveElements = AddPositiveElem(PositiveElements, item);
                }
            }

            return PositiveElements;
        }
        static int[] SearchWithLinq(int[] array)
        {
            int count = 0;
            var PositiveElements = from t in array
                                   where t > 0
                                   select t;

            int[] temp = new int[PositiveElements.Count()];

            foreach (var item in PositiveElements)
            {
                temp[count] = item;
                count++;
            }

            return temp;
        }
        private static T[] AddPositiveElem<T>(T[] array, T item)
        {
            T[] arr = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                arr[i] = array[i];
            }

            arr[array.Length] = item;

            return arr;
        }
    }
}
