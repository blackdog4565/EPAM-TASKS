using System;

namespace task_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int exit = 0;

            while (exit != 1)
            {
                int choiceAction = 0;

                var t = new Triangle();

                Console.Write("Введите стороны треугольника:\nA = ");
                int.TryParse(Console.ReadLine(), out int newA);

                t.A = newA;

                Console.Write("B = ");
                int.TryParse(Console.ReadLine(), out int newB);

                t.B = newB;

                Console.Write("C = ");
                int.TryParse(Console.ReadLine(), out int newC);

                t.C = newC;

                while (choiceAction < 3)
                {
                    Console.WriteLine("\nДля треугольника с параметрами:\n\tA = " + t.A + "\n\tB = " + t.B + "\n\tC = " + t.C + "\nВыберите действие:\n\t1: Вычислить периметр\n\t2: Вычислить площадь\n\t3: Ввести новые значения треугольника\n\t4: Выйти");

                    int.TryParse(Console.ReadLine(), out choiceAction);

                    switch (choiceAction)
                    {
                        case 1:
                            Console.WriteLine("Периметр треугольника = " + t.GetPerimeter());
                            break;
                        case 2:
                            Console.WriteLine("Площадь треугольника = " + t.GetSquare());
                            break;
                        case 3:
                            break;
                        case 4:
                            exit = 1;
                            break;
                        default:
                            break;
                    }

                    if (choiceAction > 4 || choiceAction < 1)
                        Console.WriteLine("Введены неверные параметры!");
                }
            }
        }
    }
    class Triangle
    {
        private int _a;
        private int _b;
        private int _с;
        public int A
        {
            get
            {
                return _a;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Сторона должна быть положительной.");
                else
                    _a = value;
            }
        }

        public int B
        {
            get
            {
                return _b;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Сторона должна быть положительной.");
                else
                    _b = value;
            }
        }
        public int C
        {
            get
            {
                return _с;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Сторона должна быть положительной.");
                else
                    _с = value;
            }
        }
        public double GetPerimeter() => A + B + C;
        public double HalfPerimeter() => GetPerimeter() / 2;
        public double GetSquare() => Math.Sqrt(HalfPerimeter() * (HalfPerimeter() - A) * (HalfPerimeter() - B) * (HalfPerimeter() - C));
    }
}
