using System;
using System.IO;
using System.Collections.Generic;

namespace task_5
{
    class Program
    {
        private static string rootPath = "G:\\EPAM TRANING\\APPS\\task_5\\folder"; // корневой каталог
        private static string rollPath = "G:\\EPAM TRANING\\APPS\\task_5\\folder_roll"; // каталог для отслеживания изменений
        private static List<string> allDirectories = new List<string>(); // список всех каталогов с файлами, включая корневой каталог
        private static List<string> filesNames = new List<string>(); // путь к каждому файлу в корневом каталоге
        static void Main(string[] args)
        {
            #region LOGGING_ORIGINAL_FILES
            
            // поиск каталогов и подкаталогов
            allDirectories.Add(rootPath);

            for (int i = 0; i < allDirectories.Count; i++) 
            {
                allDirectories.AddRange(Directory.GetDirectories(allDirectories[i])); 
            }

            // выборка всех текстовых файлов с расширением .txt
            foreach (var item in allDirectories)
            {
                filesNames.AddRange(Directory.GetFiles(item, "*.txt"));
            }

            // логирование оригинальных файлов, если оно ещё не было выполнено
            string newPath = rootPath.Replace(rootPath, rollPath) + $"\\Original files";

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            foreach (var item in filesNames)
            {
                string fullNewPath = newPath + $"\\{Path.GetFullPath(item).Replace(rootPath, String.Empty)}";

                if (!File.Exists(fullNewPath))
                {
                    Directory.CreateDirectory(newPath + $"\\{Path.GetDirectoryName(item).Replace(rootPath, String.Empty)}");
                    File.Create(fullNewPath).Close();
                    File.Copy(item, fullNewPath, true);
                    Console.WriteLine($"Added new original file \"{Path.GetFileName(item)}\".");
                }
                else
                {
                    Console.WriteLine($"Original file \"{Path.GetFileName(item)}\" was logged already!");
                }
            }

            #endregion

            #region USER_CHOICE

            string choice = "WwRr";
            char cki;
            do
            {
                Console.Write($"Watch (W) or RollBack (R)? {Environment.NewLine}Your choice (R / W): ");
                cki = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine();
            }
            while (!choice.Contains(cki));
            
            if (cki == 'w' || cki == 'W')
            {
                Watch();
            }
            else
            {
                RollBack();
            }

            #endregion
        }

        /// <summary>
        /// Отслеживание изменений файла
        /// </summary>
        public static void Watch()
        {
            Console.WriteLine("Let's watch!");
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = rootPath;
                watcher.IncludeSubdirectories = true;
                watcher.Filter = "*.txt";
                watcher.Changed += OnChanged;
                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press 'q' to quit.");
                Console.WriteLine();

                char choice;
                do
                {
                    choice = Console.ReadKey().KeyChar;
                }
                while (choice != 'q');
            }

        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // формирование нового каталога с указанием времени изменения файлов в названии
            string fmt1 = "dd MMM yyyy h\\.m\\.s";
            string newPath = rootPath.Replace(rootPath, rollPath) + $"\\{DateTime.Now.ToString(fmt1)}";

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            // логирование файлов в созданный каталог
            foreach (var item in filesNames)
            {
                string fullNewPath = newPath + $"\\{Path.GetFullPath(item).Replace(rootPath, String.Empty)}";

                if (!File.Exists(fullNewPath))
                {
                    Directory.CreateDirectory(newPath + $"\\{Path.GetDirectoryName(item).Replace(rootPath, String.Empty)}");
                    File.Create(fullNewPath).Close();
                    File.Copy(item, fullNewPath, true);
                    Console.WriteLine($"Looged file \"{Path.GetFileName(item)}\".");
                }
            }
        }
        /// <summary>
        /// Откат
        /// </summary>
        public static void RollBack()
        {
            Console.WriteLine("Let's rollback!");
            
            List<string> rollBackPaths = new List<string>(); // список каталогов, указывающих на дату изменений
            List<string> rollBackFiles = new List<string>(); // список файлов, которые находятся в выбранном каталоге
            List<string> pathToRollBack = new List<string>(); // список подкаталогов, в которых могут находиться файлы для отката

            rollBackPaths.AddRange(Directory.GetDirectories(rollPath));

            int index = 1;

            foreach (var item in rollBackPaths)
            {
                Console.WriteLine($"({index}) {item.Replace(rollPath, "")}");
                index++;
            }

            int choice;

            do
            {
                Console.WriteLine($"{Environment.NewLine}Choose date to rollback (1-{rollBackPaths.Count})!");

                int.TryParse(Console.ReadLine(), out choice);
            }
            while (choice < 1 || choice > rollBackPaths.Count);

            choice--;

            pathToRollBack.AddRange(Directory.GetDirectories(rollBackPaths[choice]));

            for (int i = 0; i < pathToRollBack.Count; i++)
            {
                pathToRollBack.AddRange(Directory.GetDirectories(pathToRollBack[i])); // список всех проходимых папок
            }

            rollBackFiles.AddRange(Directory.GetFiles(rollBackPaths[choice], "*.txt"));

            foreach (var item in pathToRollBack)
            {
                rollBackFiles.AddRange(Directory.GetFiles(item, "*.txt"));
            }

            Console.WriteLine("Files to rollback");

            foreach (var item in rollBackFiles)
            {
                Console.WriteLine(item);
            }

            foreach (var item in rollBackFiles)
            {
                string fullNewPath = rootPath + $"\\{Path.GetFullPath(item).Replace(rollBackPaths[choice], "")}";

                if (File.Exists(fullNewPath))
                {
                    File.Copy(item, fullNewPath, true);
                    Console.WriteLine($"Rollback file \"{Path.GetFileName(item)}\".");
                }
            }
        }
    }
}
