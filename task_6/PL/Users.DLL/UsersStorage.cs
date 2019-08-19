using Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Users.DAL
{
    public static class UsersStorage
    {
        private static List<User> Users { get; set; }
        private static string Path { get; } = "G:\\EPAM TRANING\\APPS\\PL\\Users.DLL\\users.txt";

        static UsersStorage()
        {
            Users = new List<User>();

            string[] NewFile = File.ReadAllLines(Path);

            foreach (var item in NewFile)
            {
                string[] userInfo = item.Split(' ');
                User user = new User(int.Parse(userInfo[0]), userInfo[1], DateTime.Parse(userInfo[2]));
                Users.Add(user);
            }
        }
        private static void UpdateUsersInfo()
        {
            Users = new List<User>();

            string[] NewFile = File.ReadAllLines(Path);

            foreach (var item in NewFile)
            {
                string[] userInfo = item.Split(' ');
                User user = new User(int.Parse(userInfo[0]), userInfo[1], DateTime.Parse(userInfo[2]));
                Users.Add(user);
            }
        }
        public static bool AddUser(User user)
        {
            if (Users.Any(n => n.ID == user.ID))
            {
                return false;
            }

            string writeUser = $"{user.ID} {user.Name} {user.DateOfBirth} {user.Age}\n";
            File.AppendAllText(Path, writeUser);

            return true;
        }
        public static void DeleteUserById(int id)
        {
            List<User> newUsersList = new List<User>();
            newUsersList = Users;
            foreach (var item in newUsersList)
            {
                if (item.ID == id)
                {
                    newUsersList.Remove(item);
                    break;
                }
            }
            File.Delete(Path);
            foreach (var item in newUsersList)
            {
                string writeUser = $"{item.ID} {item.Name} {item.DateOfBirth} {item.Age}\n";
                File.AppendAllText(Path, writeUser);
            }
        }
        public static IEnumerable<User> SelectAllUsers()
        {
            UpdateUsersInfo();
            return Users;
        }
    }
}
