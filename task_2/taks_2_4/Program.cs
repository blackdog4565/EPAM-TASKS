using System;

namespace taks_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первую строку: ");
            MyString a = new MyString(Console.ReadLine());

            Console.Write("Введите вторую строку: ");
            MyString b = new MyString(Console.ReadLine());

            Console.WriteLine("Ваши строки: \n" + a + "\n" + b);
        }
    }
    class MyString
    {
        private char[] _string;
        private int _length;
        public MyString()
        {
            _string = new char[1] { '\0' };
        }
        public MyString(string value)
        {
            _string = new char[value.Length];

            for (int i = 0; i < value.Length; i++)
                _string[i] = value[i];
        }
        public MyString(char[] value)
        {
            _string = new char[value.Length];

            for (int i = 0; i < value.Length; i++)
                _string[i] = value[i];
        }
        public int Length // Длина строки MyString 
        {
            get
            {
                _length = 0;

                foreach (var item in _string)
                {
                    _length++;
                }

                return _length;
            }
        }
        public MyString Сoncatenation(MyString valF, MyString valS) // Сложение двух строк MyString 
        {
            char[] tempValF = valF.ToCharArray();
            char[] tempValS = valS.ToCharArray();
            char[] tempChar = new char[tempValF.Length + tempValS.Length];

            for (int i = 0; i < tempValF.Length; i++)
            {
                tempChar[i] = tempValF[i];
            }
            for (int i = tempValF.Length; i < tempChar.Length; i++)
            {
                tempChar[i] = tempValS[i - tempValF.Length];
            }

            MyString newMyString = new MyString(tempChar);

            return newMyString;
        }
        public override string ToString() // Перевод MyString в String 
        {
            string newString = "";

            for (int i = 0; i < _string.Length; i++)
                newString += _string[i];

            return newString;
        }
        public char[] ToCharArray() // Первод MyString в CharArray 
        {
            char[] newCharArray = new char[_string.Length];

            for (int i = 0; i < _string.Length; i++)
                newCharArray[i] = _string[i];

            return newCharArray;
        }
        public int FindChar(char c) // Поиск заданного символа в строке MyString. Возвращает позицию найденного символа, но если такой символ отсутствует в строке, то возвращает "-1" 
        {
            int position = -1;

            for (int i = 0; i < _string.Length; i++)
                if (_string[i] == c)
                {
                    position = i;
                    return position;
                }
            return position;

        }
        public int FindChar(char c, int pos) // Поиск заданного символа в строке MyString, начиная с позиции "pos". Возвращает позицию найденного символа, но если такой символ отсутствует в строке, то возвращает "-1" 
        {
            int position = -1;

            for (int i = pos; i < _string.Length; i++)
                if (_string[i] == c)
                    position = i;

            return position;
        }
        public bool Contains(string valS) // Возвращает "true", если в строке MyString содержится искомая строка, иначе "false" 
        {
            if (this.Length < valS.Length)
                return false;

            int indexFirstSymbol = this.FindChar(valS[0]);

            char[] tempValF = this.ToCharArray();
            char[] tempValS = valS.ToCharArray();

            if (indexFirstSymbol != -1)
            {
                while (indexFirstSymbol != -1)
                {
                    for (int i = indexFirstSymbol, j = 0; i < indexFirstSymbol + valS.Length; i++, j++)
                    {
                        Console.WriteLine(i + " " + (indexFirstSymbol + valS.Length));
                        Console.WriteLine(i + " " + (j));
                        if (i > this.Length - valS.Length + j)
                            return false;
                        else
                        {
                            Console.WriteLine(tempValF[i] + " " + tempValS[j]);
                            if (tempValF[i] == tempValS[j])
                            {
                                if (j == valS.Length)
                                    return true;
                            }
                            else
                            {
                                if (indexFirstSymbol + 1 > this.Length)
                                    return false;
                                else
                                {
                                    indexFirstSymbol = this.FindChar(valS[0], indexFirstSymbol + 1);
                                    break;
                                }
                            }
                            if (this.Length < indexFirstSymbol + valS.Length)
                                return false;
                        }
                    }
                }
                if (indexFirstSymbol == -1)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
        public bool Compare(MyString valS) // Сравнивает две строки MyString 
        {
            if (this.Length != valS.Length)
                return false;

            char[] tempValF = this.ToCharArray();
            char[] tempValS = valS.ToCharArray();

            for (int i = 0; i < tempValF.Length; i++)
            {
                if (tempValF[i] == tempValS[i])
                    continue;
                else
                    return false;
            }

            return true;
        }
    }
}
