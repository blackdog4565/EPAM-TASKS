using System;
using System.Threading;

namespace task_4_3
{
    static class SortingUnit
    {
        public delegate void SortInfo(string mes);
        public static event SortInfo info;
        public static void Sort<T>(T[] array)
        {
            SortFull(array, (a, b) => a as dynamic > b as dynamic);
        }
        public static void SortFull<T>(T[] array, Func<T, T, bool> comp)
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
        public static void SortThread<T>(T[] array)
        {
            Thread th = new Thread(() =>
            {
                info?.Invoke("Сортировка началась");
                SortFull(array, (a, b) => a as dynamic > b as dynamic);
                info?.Invoke("Сортировка закончилась");
            });
            th.Start();
        }
    }
}

