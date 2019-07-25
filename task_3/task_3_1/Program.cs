using System;
using System.Collections.Generic;

namespace task_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество людей: ");
            int.TryParse(Console.ReadLine(), out int countPeople);

            List<int> People = new List<int>();

            int random;
            Random r = new Random();

            random = r.Next(1, countPeople);
            People.Add(random);

            for (int i = 1; i < countPeople; i++)
            {
                Console.WriteLine(People.Contains(random));
                random = r.Next(1, countPeople);

                while (People.Contains(random))
                {
                    random = r.Next(1, countPeople + 1);
                }
                People.Add(random);
            }

            //for (int i = 0; i < countPeople; i++)
            //{
            //    People.Add(i + 1);
            //}

            foreach (int man in People)
            {
                Console.Write(man + " ");
            }
            Console.WriteLine("\n");

            int iter = 1;

            while (People.Count != 2)
            {
                People.Remove(People[iter % People.Count]);

                iter++;

                Console.Write("Оставшиеся люди: ");

                foreach (int man in People)
                {
                    Console.Write(man + " ");
                }
                Console.WriteLine("\n");
            }

            if (countPeople % 2 == 0)
            {
                People.Remove(People[0]);
            }
            else
            {
                People.Remove(People[1]);
            }

            foreach (int man in People)
            {
                Console.WriteLine(man);
            }
        }
    }
}
