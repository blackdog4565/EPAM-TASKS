using System;
using Users.Entities;
using Users.BLL;
using System.Collections.Generic;
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

                        Console.Write("Insert User birth date: ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth);

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
