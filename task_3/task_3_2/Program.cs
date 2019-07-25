using System;
using System.Collections.Generic;
namespace task_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите текст: ");
            string userText = Console.ReadLine();

            char[] separators = new char[] { ' ', ',' };
            string[] splitText = userText.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordFreq = new Dictionary<string, int> ();

            string lowWord;

            foreach (string word in splitText)
            {
                lowWord = word.ToLower();

                if (wordFreq.ContainsKey(lowWord))
                {
                    wordFreq[lowWord]++;
                }
                else
                {
                    wordFreq.Add(lowWord, 1);
                }
            }

            foreach (string word in wordFreq.Keys)
            {
                Console.WriteLine("Слово: " + word + "\n\rЧастота встречаемости: " + wordFreq[word] + "\n\r");
            }
        }
    }
}
