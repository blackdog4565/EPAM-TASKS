using System;
using System.Collections.Generic;

namespace task_1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> paramsList = new List<string>();

            int exit = 0,
                choiceParam = 0,
                choiceAction = 0;

            while (exit != 1)
            {
                choiceParam = 0;
                choiceAction = 0;

                Console.Write("Параметры надписи: ");
                if (paramsList.Count == 0)
                    Console.WriteLine("None");
                else
                {
                    foreach (string i in paramsList)
                        Console.Write(i + " ");

                    Console.Write("\n");
                }

                while (choiceParam > 3 || choiceParam< 1)
                {
                    Console.WriteLine("Выберите параметр:\n\t1: bold\n\t2: italic\n\t3: underline");

                    int.TryParse(Console.ReadLine(), out choiceParam);
                    if (choiceParam > 3 || choiceParam < 1)
                        Console.WriteLine("Введены неверные параметры!");
                }
                
                switch (choiceParam)
                {
                    case 1:
                        if (!paramsList.Contains("Bold"))
                            paramsList.Add("Bold");
                        break;
                    case 2:
                        if (!paramsList.Contains("Italic"))
                            paramsList.Add("Italic");
                        break;
                    case 3:
                        if (!paramsList.Contains("Underline"))
                            paramsList.Add("Underline");
                        break;
                    default:
                        break;
                }               

                Console.Write("Параметры надписи: ");
                foreach (string i in paramsList)
                    Console.Write(i + " ");
                
                Console.Write("\n");

                while (choiceAction > 4 || choiceAction < 1)
                {
                    Console.WriteLine("Выберите действие:\n\t1: Добавить параметр\n\t2: Очистить список и добавить параметр\n\t3: Очистить список и выйти\n\t4: Сохранить и выйти");

                    int.TryParse(Console.ReadLine(), out choiceAction);

                    if (choiceAction > 4 || choiceAction < 1)
                        Console.WriteLine("Введены неверные параметры!");
                }

                switch (choiceAction)
                {
                    case 1:
                        break;
                    case 2:
                        paramsList.Clear();
                        break;
                    case 3:
                        paramsList.Clear();
                        exit = 1;
                        break;
                    case 4:
                        exit = 1;
                        break;
                    default:
                        break;
                }
            }
            Console.Write("Параметры надписи: ");

            if (paramsList.Count == 0)
                Console.WriteLine("None");
            else
                foreach (string i in paramsList)
                    Console.Write(i + " ");
        }
    }
}
