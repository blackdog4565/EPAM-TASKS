using System;

namespace task_2_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Field f = new Field(800, 800); // Создание поля

            Point monsterBase = new Point(200, 200, f); // База монстров

            Character player = new Character(f); // Создание персонажа

            MonsterRangeBear m = new MonsterRangeBear(monsterBase, f); // Создание монстра на его базе

            while (true) // Основной цикл с небольшой реализацией
            {
                if (m.Position.Distance(player.Position) > Math.Abs(m.AttackRange)) // Поведение монстра  
                {
                    if (m.X < player.X)
                        m.MoveUp();
                    else
                        m.MoveDown();

                    if (m.Y < player.Y)
                        m.MoveRight();
                    else
                        m.MoveLeft();
                }
                else
                {
                    player.Health = player.Health - m.Attack;
                }
                if (Console.KeyAvailable == true) // Управление персонажем  
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.LeftArrow:
                        {
                            player.MoveLeft();

                            break;
                        }
                        case ConsoleKey.RightArrow:
                        {
                            player.MoveRight();
                            break;
                        }
                        case ConsoleKey.UpArrow:
                        {
                            player.MoveUp();
                            break;
                        }
                        case ConsoleKey.DownArrow:
                        {
                            player.MoveDown();
                            break;
                        }
                        case ConsoleKey.Escape:
                        {
                            return;
                        }
                        default:
                            break;
                    }
                };
                Console.WriteLine(player.Position + " " + m.Position);
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
        }
    }
    class Field // Игровое поле, где располагаются объекты 
    {
        public Field()
        {
            Width = 800;
            Height = 600;
        }
        public Field(double width, double height)
        {
            if (width > 0)
                Width = width;
            else
                throw new ArgumentException("Неверные значения ширины поля");

            if (height > 0)
                Height = height;
            else
                throw new ArgumentException("Неверные значения высоты поля");
        }
        public double Width { get; private set; }
        public double Height { get; private set; }
        public override string ToString()
        {
            return Width + " x " + Height;
        }
    }
    class Point // Координата объектов 
    {
        public Point()
        {
            X = 0;
            Y = 0;
        }
        public Point(double x, double y, Field field)
        {
            if ((double)Math.Abs(x) > field.Width / 2)
                throw new ArgumentException("Вышли за пределы поля по оси OX");
            else
                X = x;

            if ((double)Math.Abs(y) > field.Height / 2)
                throw new ArgumentException("Вышли за пределы поля по оси OY");
            else
                Y = y;
        }
        
        public double X { get; private set; }
        public double Y { get; private set; }
        public override string ToString()
        {
            return "(" + X + "; " + Y + ")";
        }
        public double Distance(Point endPoint)
        {
            return Math.Sqrt(Math.Pow(this.X - endPoint.X, 2) + Math.Pow(this.Y - endPoint.Y, 2)); 
        }
    }
    abstract class Unit // Юнит 
    {
        private double _x;
        private double _y;
        private Field _field;
        public Unit(Field field)
        {
            _x = 0;
            _y = 0;
            _field = field;
        }
        public Unit(Point position, Field field)
        {
            _x = position.X;
            _y = position.Y;
            _field = field;
        }
        public double X
        {
            get => _x;
            set
            {
                if (Math.Abs(value) < _field.Width / 2)
                    _x = value;
            }
        }
        public double Y
        {
            get => _y;
            set
            {
                if (Math.Abs(value) < _field.Height / 2)
                    _y = value;
            }
        }
        public Point Position
        {
            get => new Point(X, Y, _field);
        }
        public virtual void MoveDown() { }
        public virtual void MoveUp() { }
        public virtual void MoveLeft() { }
        public virtual void MoveRight() { }
        public virtual void MakeAttack() { }
    }
    abstract class Bonus // Бонус 
    {
        private double _x;
        private double _y;
        private Field _field;
        public Bonus(Field field)
        {
            _x = 0;
            _y = 0;
            _field = field;
        }
        public Bonus(Point position, Field field)
        {
            _x = position.X;
            _y = position.Y;
            _field = field;
        }
        public double X
        {
            get => _x;
            set
            {
                if (Math.Abs(value) < _field.Width / 2)
                    _x = value;
            }
        }
        public double Y
        {
            get => _y;
            set
            {
                if (Math.Abs(value) < _field.Height / 2)
                    _y = value;
            }
        }
        public Point Position
        {
            get => new Point(X, Y, _field);
        }
    }
    abstract class Barrier // Препятствие 
    {
        private double _x;
        private double _y;
        private Field _field;
        public Barrier(Field field)
        {
            _x = 0;
            _y = 0;
            _field = field;
        }
        public Barrier(Point position, Field field)
        {
            _x = position.X;
            _y = position.Y;
            _field = field;
        }
        public double X
        {
            get => _x;
            set
            {
                if (Math.Abs(value) < _field.Width / 2)
                    _x = value;
            }
        }
        public double Y
        {
            get => _y;
            set
            {
                if (Math.Abs(value) < _field.Height / 2)
                    _y = value;
            }
        }
        public Point Position { get => new Point(X, Y, _field); }
    }
    class ArmorApple : Bonus 
    {
        public double SpeedReduct { get; set; }
        public double Strength { get; set; }
        public ArmorApple(Field field) : base(field)
        {
            this.Strength = 3;
            this.SpeedReduct = 1;
        }
        public ArmorApple(Point position, Field field) : base(position, field)
        {
            this.Strength = 3;
            this.SpeedReduct = 1;
        }
    } // Бонус к защите персонажа
    class SpeedChery : Bonus
    {
        public double SpeedBoost { get; set; }
        public double StrengthReduct { get; set; }
        public SpeedChery(Field field) : base(field)
        {
            this.SpeedBoost = 3;
            this.StrengthReduct = 1;
        }
        public SpeedChery(Point position, Field field) : base(position, field)
        {
            this.SpeedBoost = 3;
            this.StrengthReduct = 1;
        }
    } // Бонус к скорости персонажа
    class Tree : Barrier 
    {
        public double R { get; set; }
        public Tree (Field field) : base(field)
        {
            R = 20;
        }
        public Tree (Point position, Field field) : base(position, field)
        {
            R = 20;
        }
        public double Square { get => Math.PI * R * R; }
    } // Препятствие дерево
    class Stone : Barrier
    {
        public double R { get; set; }
        public Stone(Field field) : base(field)
        {
            R = 10;
        }
        public Stone(Point position, Field field) : base(position, field)
        {
            R = 10;
        }
        public double Square { get => Math.PI * R * R; }

    } // Препятствие камень
    class Character : Unit
    {
        public double Armor { get; set; }
        public double Health { get; set; }
        public double Speed { get; set; }
        public Character(Field field) : base(field)
        {
            Speed = 5;
            Health = 10;
            Armor = 0;
        }
        public Character(Point position, Field field) : base(position, field)
        {
            Speed = 5;
            Health = 10;
            Armor = 0;
        }
        public new void MoveDown()
        {
            this.X -= Speed;
        }
        public new void MoveUp()
        {
            this.X += Speed;
        }
        public new void MoveLeft()
        {
            this.Y -= Speed;
        }
        public new void MoveRight()
        {
            this.Y += Speed;
        }

    } // Наш персонаж
    class MonsterRangeBear : Unit
    {
        public double Health { get; private set; }
        public double Speed { get; private set; }
        public double Attack { get; private set; }
        public double AttackRange { get; private set; }

        public MonsterRangeBear(Field field) : base(field)
        {
            Speed = 4;
            Health = 6;
            Attack = 2;
            AttackRange = 10;
        }
        public MonsterRangeBear(Point position, Field field) : base(position, field) { }
        public new void MoveDown()
        {
            this.X -= Speed;
        }
        public new void MoveUp()
        {
            this.X += Speed;
        }
        public new void MoveLeft()
        {
            this.Y -= Speed;
        }
        public new void MoveRight()
        {
            this.Y += Speed;
        }
    } // Монстр-медведь с дальней атакой
    class MonsterMeleeWolf : Unit
    {
        public double Health { get; private set; }
        public double Speed { get; private set; }
        public double Attack { get; private set; }
        public double AttackRange { get; private set; }

        public MonsterMeleeWolf(Field field) : base(field)
        {
            Speed = 4;
            Health = 8;
            Attack = 4;
            AttackRange = 3;
        }
        public MonsterMeleeWolf(Point position, Field field) : base(position, field) { }
        public new void MoveDown()
        {
            this.X -= Speed;
        }
        public new void MoveUp()
        {
            this.X += Speed;
        }
        public new void MoveLeft()
        {
            this.Y -= Speed;
        }
        public new void MoveRight()
        {
            this.Y += Speed;
        }
    } // Монстр-волк с ближней атакой
    
}
