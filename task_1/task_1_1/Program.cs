using System;

namespace task_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0, 
                b = 0;

            while ((a <= 0) || (b <= 0))
            {
                Console.Write("Введите стороны прямоугольника a и b \n\ta: ");
                int.TryParse(Console.ReadLine(), out a);
                Console.Write("\tb: ");
                int.TryParse(Console.ReadLine(), out b);

                if ((a <= 0) || (a <= 0))
                    Console.WriteLine("Введены неверные значения");
            }
            Console.WriteLine("Площадь заданного прямоугольника равна " + square(a,b));
        }
        static int square(int a, int b)
        {
            return a * b;
        }
    }
}
