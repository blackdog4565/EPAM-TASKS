using System;
using Users.Entities;
using Users.BLL;
using System.Collections.Generic;
using UsersAwards;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        public static UsersManager UsersManager { get; } = new UsersManager();

        static void Main(string[] args)
        {
            MakeChoice();
        }

        private static void MakeChoice()
        {
            Console.WriteLine($"" +
                            $"Select an action: {Environment.NewLine}" +
                            $" 1. Create User {Environment.NewLine}" +
                            $" 2. Delete User {Environment.NewLine}" +
                            $" 3. Show all Users {Environment.NewLine}" +
                            $" 4. Exit");

            var input = Console.ReadLine();

            if (int.TryParse(input, out int selectedAction)
                && selectedAction > 0
                && selectedAction < 5)
            {
                switch (selectedAction)
                {
                    case 1:
                        Console.Write("Insert User name: ");
                        var name = Console.ReadLine();
                        name = name.Replace(" ", "");

                        Console.Write("Insert User birth date: ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth);

                        string yesOrNot = string.Empty;

                        while (yesOrNot != "y" && yesOrNot != "n")
                        {
                            Console.Write("Does your user have awards? (y/n)");
                            yesOrNot = Console.ReadLine();
                        }

                        if (yesOrNot == "y")
                        {
                            List<int> awardsIdList = new List<int>();
                            string awardsIdString = "";
                            Console.Write("Insert user's awards id with space: ");
                            awardsIdString = Console.ReadLine();

                            foreach (var item in awardsIdString.Split(' '))
                            {
                                if (int.TryParse(item, out int awardId) 
                                    && awardId > 9 
                                    && awardId < 100)
                                {

                                }

                            }
                        }

                        Random random = new Random();
                        int id = random.Next(10, 99);

                        var newUser = new User(id, name, dateOfBirth);

                        UsersManager.AddUser(newUser);

                        MakeChoice();
                        break;
                    case 2:
                        Console.Write("Insert User ID: ");
                        var userId = Console.ReadLine();

                        if (int.TryParse(userId, out int userIdToDelete)
                            && userIdToDelete > 9
                            && userIdToDelete < 100)
                        {
                            UsersManager.DeleteUser(userIdToDelete);
                        }

                        MakeChoice();
                        break;
                    case 3:
                        IEnumerable<User> users = UsersManager.GetAllUsers();

                        ShowAllUsers(users);

                        MakeChoice();
                        break;
                    case 4:
                        return;
                }
            }
        }
        public static void ShowAllUsers(IEnumerable<User> users)
        {
            foreach (var item in users)
            {
                Console.WriteLine($"{item.ID} --- {item.Name} --- {item.DateOfBirth} --- {item.Age}");
            }
        }
    }
}
