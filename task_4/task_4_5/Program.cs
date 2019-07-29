using System;

namespace task_4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            Console.WriteLine("s = " + s + "\n\rПоложительное число: " + s.IntOrNot() + "\n\r");
            s = "2";
            Console.WriteLine("s = " + s + "\n\rПоложительное число: " + s.IntOrNot() + "\n\r");
            s = "-2";
            Console.WriteLine("s = " + s + "\n\rПоложительное число: " + s.IntOrNot() + "\n\r");
            s = "0";
            Console.WriteLine("s = " + s + "\n\rПоложительное число: " + s.IntOrNot() + "\n\r");
            s = "0ф";
            Console.WriteLine("s = " + s + "\n\rПоложительное число: " + s.IntOrNot() + "\n\r");
        }

    }
    public static class StringExtension
    {
        public static bool IntOrNot(this string str)
        {
            if (str.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]) || str[i] == '0')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
