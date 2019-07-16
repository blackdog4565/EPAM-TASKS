using System;

namespace task_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int exit = 0;

            while (exit != 1)
            {
                int choiceAction = 0;

                int newY, newD, newM;
                string newFirstName, newSecondName, newPatronymic;

                DateTime newBornDate = new DateTime();

                var t = new User();

                bool next_step = true;

                Console.Write("Введите фамилию: ");
                newSecondName = Console.ReadLine();

                t.SecondName = newSecondName;

                Console.Write("Введите имя: ");
                newFirstName = Console.ReadLine();

                t.FirstName = newFirstName;

                Console.Write("Введите отчество: ");
                newPatronymic = Console.ReadLine();

                t.Patronymic = newPatronymic;

                do
                {
                    Console.Write("Введите дату рождения:\nЧисло = ");
                    int.TryParse(Console.ReadLine(), out newD);

                    Console.Write("Введите дату рождения:\nМесяц = ");
                    int.TryParse(Console.ReadLine(), out newM);

                    Console.Write("Введите дату рождения:\nГод = ");
                    int.TryParse(Console.ReadLine(), out newY);
                    try
                    {
                        newBornDate = new DateTime(newY, newM, newD);

                        if (newBornDate > DateTime.Today)
                            throw new Exception("Введены неверные значения!");
                        else
                            next_step = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        next_step = false;
                    }
                } while (next_step == false);
                
                t.BornDate = newBornDate;
                
                Console.WriteLine("\nПользователь создан");

                while (choiceAction < 4)
                {
                    Console.WriteLine("\nВыберите действие:\n\t1: Вывести инициалы пользователя\n\t2: Вывести дату рождения пользователя\n\t3: Вывести возраст пользователя\n\t4: Ввести данные нового пользователя\n\t5: Выйти");

                    int.TryParse(Console.ReadLine(), out choiceAction);

                    switch (choiceAction)
                    {
                        case 1:
                            t.ShowInitials();
                            break;
                        case 2:
                            t.ShowBirth();
                            break;
                        case 3:
                            t.ShowAge();
                            break;
                        case 4:
                            break;
                        case 5:
                            exit = 1;
                            break;
                        default:
                            break;
                    }

                    if (choiceAction > 5 || choiceAction < 1)
                        Console.WriteLine("Введены неверные параметры!");
                }
            }
        }
    }
    class User
    {
        private string _fName;
        private string _sName;
        private string _patr;
        private DateTime _bornDate;
        public DateTime BornDate
        {
            get
            {
                return _bornDate;
            }
            set
            {
                _bornDate = value;
            }
        }
        public string FirstName
        {
            get
            {
                return _fName;
            }
            set
            {
                if (value.Trim().Length != 0)
                {
                    if (value.Length > 1)
                    {
                        _fName = value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1).ToLower();
                    }
                    else
                        _fName = value.ToUpper();

                }
                else
                    throw new ArgumentException("Пустое поле!");
            }
        }
        public string SecondName
        {
            get
            {
                return _sName;
            }
            set
            {
                if (value.Trim().Length != 0)
                {
                    if (value.Length > 1)
                    {
                        _sName = value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1).ToLower();
                    }
                    else
                        _sName = value.ToUpper();

                }
                else
                    throw new ArgumentException("Пустое поле!");
            }
        }
        public string Patronymic
        {
            get
            {
                return _patr;
            }
            set
            {
                if (value.Length > 1)
                {
                    _patr = value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1).ToLower();
                }
                else
                    _patr = value.ToUpper();
            }
        }
        private int GetAge()
        {
            DateTime today = DateTime.Today;

            int _age = today.Year - BornDate.Year;
            if (BornDate > today.AddYears(-_age))
            {
                _age--;
            }
            return _age;

        }
        public void ShowBirth()
        {
            Console.WriteLine("{0:D}", BornDate);
        }
        public void ShowAge()
        {
            Console.WriteLine(GetAge());
        }
        public void ShowInitials()
        {
            Console.WriteLine("Имя: " + FirstName + "\nФамилия: " + SecondName + "\nОтчество: " + Patronymic);
        }

    }
}
