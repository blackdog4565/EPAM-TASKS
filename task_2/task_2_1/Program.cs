using System;

namespace task_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int exit = 0;

            while (exit != 1)
            {
                int choiceAction = 0;

                var c = new Round();

                Console.Write("Введите координаты центра круга:\nX = ");
                int.TryParse(Console.ReadLine(), out int newX);

                Console.Write("Y = ");
                int.TryParse(Console.ReadLine(), out int newY);

                c.X = newX;
                c.Y = newY;

                Console.Write("\nВведите радиус круга:\nR = ");
                int.TryParse(Console.ReadLine(), out int newR);

                c.Radius = newR;

                while (choiceAction < 3)
                {
                    Console.WriteLine("\nДля окружности с параметрами:\n\tX = " + c.X + "\n\tY = " + c.Y + "\n\tR = " + c.Radius + "\nВыберите действие:\n\t1: Вычислить длину окружности\n\t2: Вычислить площадь кргуа\n\t3: Ввести новые значения круга\n\t4: Выйти");

                    int.TryParse(Console.ReadLine(), out choiceAction);

                    switch (choiceAction)
                    {
                        case 1:
                            Console.WriteLine("Длина окружности = " + c.GetLength());
                            break;
                        case 2:
                            Console.WriteLine("Площадь круга = " + c.GetSquare());
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
    
    class Round
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
                    throw new ArgumentException("Радиус должен быть неотрецательным.");
                else
                    _r = value;
            }
        }
        public int GetRadius() => _r;

        public double GetLength() => 2 * Math.PI * Radius;
        public double GetSquare() => Math.PI * Radius * Radius;
    }
}
