using System;

namespace task_2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int exit = 0;

            while (exit != 1)
            {
                int choiceAction = 0;

                var c = new Ring();

                Console.Write("Введите координаты центра кольца:\nX = ");
                int.TryParse(Console.ReadLine(), out int newX);

                Console.Write("Y = ");
                int.TryParse(Console.ReadLine(), out int newY);

                c.X = newX;
                c.Y = newY;

                Console.Write("\nВведите внешний радиус кольца:\nR = ");
                int.TryParse(Console.ReadLine(), out int newR);

                c.Radius = newR;

                Console.Write("\nВведите внутренний радиус кольца:\nIR = ");
                int.TryParse(Console.ReadLine(), out int newIR);

                c.InnerRadius = newIR;

                while (choiceAction < 3)
                {
                    Console.WriteLine("\nДля кольца с параметрами:\n\tX = " + c.X + "\n\tY = " + c.Y + "\n\tR = " + c.Radius + "(внешний радиус)\n\tIR = " + c.InnerRadius + "(внутренний радиус)\nВыберите действие:\n\t1: Вычислить толщину кольца\n\t2: Вычислить площадь кольца\n\t3: Ввести новые значения\n\t4: Выйти");

                    int.TryParse(Console.ReadLine(), out choiceAction);

                    switch (choiceAction)
                    {
                        case 1:
                            Console.WriteLine("Толщина кольца = " + c.GetWidth());
                            break;
                        case 2:
                            Console.WriteLine("Площадь кольца = " + c.GetSquare());
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

    class RoundFigure
    {
        private int _r;
        public int X { get; set; }
        public int Y { get; set; }

        public int Radius
        {
            get
            {
                return _r;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Радиус должен быть положительным.");
                else
                    _r = value;
            }
        }
    }
    class Ring : RoundFigure
    {
        private int _ir;
        public int InnerRadius
        {
            get
            {
                return _ir;
            }
            set
            {
                if (value <= 0 || value > Radius)
                    throw new ArgumentException("Внутренний радиус не может быть больше внншнего и не может быть неположительным.");
                else
                    _ir = value;
            }
        }
        public double GetSquare() => Math.PI * (Radius * Radius - InnerRadius * InnerRadius);
        public double GetWidth() => Radius - InnerRadius;
    }
}
