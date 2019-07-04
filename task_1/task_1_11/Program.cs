using System;

namespace task_1_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите текст: ");
            string text = Console.ReadLine();

            Console.WriteLine("\nВаш текст: " + text + "\n");

            string[] splitText;

            splitText = text.Split(" ");

            float average = 0;
            int splitTextLength = splitText.Length;

            for (int i = 0; i < splitText.Length; i++)
            {
                if (splitText[i].Length == 0)
                    splitTextLength--;

                for (int j = 0; j < splitText[i].Length; j++)
                    if (!Char.IsPunctuation(splitText[i][j])) 
                        average++;
            }

            average = (float)(average) / splitTextLength;

            Console.WriteLine("Средняя длина слова: " + average + "\nКоличество слов: " + splitTextLength);
        }
    }
}
