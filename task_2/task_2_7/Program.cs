using System;

namespace task_2_7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Запуск приложения начинается с настройки размера поля для рисования

            #region RES

            string yes = "дДyY";
            string no = "нНnN";

            ScreenResolution yourScreen = new ScreenResolution();
            
            Console.WriteLine("Запуск приложения со стандартным разрешением поля: " + yourScreen + "\n Изменить? (y\\n)");

            char changeRes = Console.ReadKey().KeyChar;

            Console.WriteLine();

            while (!(yes.Contains(changeRes) || no.Contains(changeRes)))
            {
                Console.WriteLine("Введите 'y' или 'n'");
                changeRes = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            if (yes.Contains(changeRes))
            {
                Console.Write("Меняем\nВведите ширину: ");
                int.TryParse(Console.ReadLine(), out int width);

                Console.Write("Введите высоту: ");
                int.TryParse(Console.ReadLine(), out int height);
                
                yourScreen.Height = height;
                yourScreen.Width = width;
            }
            else
            {
                Console.WriteLine("Не меняем");
            }
            Console.WriteLine("Запуск приложения разрешением поля: " + yourScreen);

            #endregion RES

            // Основной цикл

            #region MAIN_LOOP

            bool exit = false;
            int choiceAction = 0;

            while (exit == false)
            {
                while (choiceAction < 5)
                {
                    Console.WriteLine("\nЧто нарисовть? Выберите действие:\n\t1: Круг\n\t2: Кольцо\n\t3: Прямоугольник\n\t4: Линию\n\nЕсли нет желания рисовть, можно выйти. \n\t5: Выход");

                    int.TryParse(Console.ReadLine(), out choiceAction);

                    switch (choiceAction)
                    {
                        case 1:
                            DrawRound(yourScreen);
                            break;
                        case 2:
                            DrawRing(yourScreen);
                            break;
                        case 3:
                            DrawRectangle(yourScreen);
                            break;
                        case 4:
                            DrawLine(yourScreen);
                            break;
                        case 5:
                            exit = true;
                            break;
                        default:
                            break;
                    }

                    if (choiceAction > 5 || choiceAction < 1)
                        Console.WriteLine("Введены неверные параметры!");
                }
            }
            #endregion MAIN_LOOP
        }
        static void DrawRound(ScreenResolution userScreen) // Отрисовка круга
        {
            Console.Write("Введите координаты центра круга: \nX = ");
            double.TryParse(Console.ReadLine(), out double X);

            Console.Write("Y = ");
            double.TryParse(Console.ReadLine(), out double Y);

            Console.Write("Введите радиус: \nR = ");
            double.TryParse(Console.ReadLine(), out double R);

            IDraw f = new Round(X, Y, userScreen)
            {
                Radius = R
            };
            
            f.Draw();
        }
        static void DrawLine(ScreenResolution userScreen) // Отрисовка линиии
        {
            Console.Write("Введите координаты начала линии: \nX1 = ");
            double.TryParse(Console.ReadLine(), out double X1);

            Console.Write("Y1 = ");
            double.TryParse(Console.ReadLine(), out double Y1);

            Point A = new Point(X1, Y1, userScreen);

            Console.Write("Введите координаты конца линии: \nX2 = ");
            double.TryParse(Console.ReadLine(), out double X2);

            Console.Write("Y2 = ");
            double.TryParse(Console.ReadLine(), out double Y2);

            Point B = new Point(X2, Y2, userScreen);

            Console.Write("Задайте ширину линии: \nW = ");
            double.TryParse(Console.ReadLine(), out double W);

            IDraw f = new Line(A, B, userScreen)
            {
                Width = W
            };

            f.Draw();
        } 
        static void DrawRectangle(ScreenResolution userScreen) // Отрисовка прямоугольника
        {
            Console.Write("Введите координаты начальной точки прямоугольника: \nX = ");
            double.TryParse(Console.ReadLine(), out double X);

            Console.Write("Y = ");
            double.TryParse(Console.ReadLine(), out double Y);

            Console.Write("Введите сторону A: \nA = ");
            double.TryParse(Console.ReadLine(), out double userA);

            Console.Write("Введите сторону B: \nA = ");
            double.TryParse(Console.ReadLine(), out double userB);

            IDraw f = new Rectangle(X, Y, userScreen)
            {
                A = userA,
                B = userB
            };

            f.Draw();
        }
        static void DrawRing(ScreenResolution userScreen) // Отрисовка кольца
        {
            Console.Write("Введите координаты центра кольца: \nX = ");
            double.TryParse(Console.ReadLine(), out double X);

            Console.Write("Y = ");
            double.TryParse(Console.ReadLine(), out double Y);

            Console.Write("Введите внешний радиус: \nOR = ");
            double.TryParse(Console.ReadLine(), out double OR);

            Console.Write("Введите внутренний радиус: \nIR = ");
            double.TryParse(Console.ReadLine(), out double IR);

            IDraw f = new Ring(X, Y, userScreen)
            {
                OutterRadius = OR,
                InnerRadius = IR
            };

            f.Draw();
        }
        abstract class Figure 
        {
            public Point FirgureCoordinate;
            public Figure()
            {
                FirgureCoordinate = new Point();
            }
            public Figure(double x, double y, ScreenResolution userScreen)
            {
                FirgureCoordinate = new Point(x, y, userScreen);
            }
            public virtual double Square { get; }
        }
        class Round : Figure, IDraw
        {
            private double _r;
            public Round(double x, double y, ScreenResolution userScreen) : base(x, y, userScreen) { }
            public double Radius
            {
                get
                {
                    return _r;
                }
                set
                {
                    if (value > 0)
                        _r = value;
                    else
                        throw new ArgumentException("Радиус не должен быть меньше 0.");
                }
            }
            public new double Square
            {
                get { return Math.PI * Radius * Radius; }
            }
            public override string ToString()
            {
                return "Circle" + "\nКоординаты: " + FirgureCoordinate + "\nРадиус: " + Radius + "\nЗанимаемая площадь: " + Square;
            }
            public void Draw()
            {
                Console.WriteLine(this);
            }
        }
        class Ring : Figure, IDraw
        {
            private double _oR = 0;
            private double _iR = 0;
            public Ring(double x, double y, ScreenResolution userScreen) : base(x, y, userScreen) { }
            public double OutterRadius
            {
                get
                {
                    return _oR;
                }
                set
                {
                    if (value > 0 && value > InnerRadius)
                        _oR = value;
                    else
                        throw new ArgumentException("Внешний радиус не должен быть меньше внутреннего и не должен быть меньше 0.");
                }
            }
            public double InnerRadius
            {
                get
                {
                    return _iR;
                }
                set
                {
                    if (value > 0 && value < OutterRadius)
                        _iR = value;
                    else
                        throw new ArgumentException("Внутренний не должен быть больше внешнего радиуса и не должен быть меньше 0.");
                }
            }
            public new double Square
            {
                get { return Math.PI * (OutterRadius * OutterRadius - InnerRadius * InnerRadius); }
            }
            public double Thickness
            {
                get { return OutterRadius - InnerRadius; }
            }
            public override string ToString()
            {
                return "Ring" + "\nКоординаты: " + FirgureCoordinate + "\nВнешний радиус: " + InnerRadius + "\nВнутренний радиус: " + OutterRadius + "\nТолщина: " + Thickness + "\nЗанимаемая площадь: " + Square;
            }
            public void Draw()
            {
                Console.WriteLine(this);
            }
        }
        class Rectangle : Figure, IDraw
        {
            private double _a;
            private double _b;
            public Rectangle(double x, double y, ScreenResolution userScreen) : base(x, y, userScreen) { }
            public double A
            {
                get
                {
                    return _a;
                }
                set
                {
                    if (value > 0)
                    {
                        _a = value;
                    }
                }
            }
            public double B
            {
                get
                {
                    return _b;
                }
                set
                {
                    if (value > 0)
                    {
                        _b = value;
                    }
                }
            }
            public new double Square
            {
                get { return A * B; }
            }
            public override string ToString()
            {
                return "Rectangle" + "\nНачальная точка прямоугольника: " + FirgureCoordinate + "\nСторона A: " + A + "\nСторона B: " + B + "\nЗанимаемая площадь: " + Square;
            }
            public void Draw()
            {
                Console.WriteLine(this);
            }
        }
        class Line : Figure, IDraw
        {
            private Point _startPoint;
            private Point _endPoint;
            private ScreenResolution _userScreen;
            private double _width { get; set; }
            public Line(Point userStartPoint, Point userEndPoint, ScreenResolution userScreen)
            {
                _startPoint = userStartPoint;
                _endPoint = userEndPoint;
                _userScreen = userScreen;
            }
            public Point StartPoint
            {
                get { return _startPoint; }
            }
            public Point EndPoint
            {
                get
                {
                    return _endPoint;
                }
            }
            public double Width
            {
                get
                {
                    return _width;
                }
                set
                {
                    if (value > 0)
                        _width = value;
                    else
                        throw new ArgumentException("Ширина линии должна быть больше 0.");
                }
            }
            public double Length
            {
                get { return Math.Sqrt(Math.Pow(StartPoint.X - EndPoint.X, 2) + Math.Pow(StartPoint.Y - EndPoint.Y, 2)); }
            }
            public Point CenterPoint
            {
                get
                {
                    double a = (StartPoint.X + EndPoint.X) / 2;
                    double b = (StartPoint.Y + EndPoint.Y) / 2;

                    return new Point(a, b, _userScreen);
                }
            }
            public override string ToString()
            {
                return "Line" + "\nКоординаты начальной точки: " + StartPoint + "\nКоординаты конечной точки: " + EndPoint + "\nКоординаты центра: " + CenterPoint + "\nШирина линии: " + Width + "\nДлина линии: " + Length;
            }
            public void Draw()
            {
                Console.WriteLine(this);
            }
        }
        class Point
        {
            private double _x;
            private double _y;
            public Point()
            {
                _x = 0;
                _y = 0;
            }
            public Point(double userX, double userY, ScreenResolution userScreen)
            {
                if ((int)Math.Abs(userX) > userScreen.Width)
                    throw new ArgumentException("Вышли за пределы экрана по оси OX");
                else
                    _x = userX;

                if ((int)Math.Abs(userY) > userScreen.Height)
                    throw new ArgumentException("Вышли за пределы экрана по оси OY");
                else
                    _y = userY;
            }
            public double X
            {
                get { return _x; }
            }
            public double Y
            {
                get { return _y; }
            }
            public override string ToString()
            {
                return "(" + X + ";" + Y + ")";
            }
        }
        class ScreenResolution
        {
            private int _width;
            private int _height;
            public ScreenResolution()
            {
                _width = 800;
                _height = 600;
            }
            public ScreenResolution(int width, int height)
            {
                _width = width;
                _height = height;
            }
            public int Width
            {
                get
                {
                    return _width;
                }
                set
                {
                    if (value > 0)
                    {
                        _width = value;
                    }
                }
            }
            public int Height
            {
                get
                {
                    return _height;
                }
                set
                {
                    if (value > 0)
                    {
                        _height = value;
                    }
                }
            }
            public override string ToString()
            {
                return Width + " x " + Height;
            }
        }
        interface IDraw
        {
            void Draw();
        }
    }
}
