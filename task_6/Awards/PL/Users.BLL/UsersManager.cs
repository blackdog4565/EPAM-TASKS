using Users.Entities;
using Users.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Users.BLL
{
    public class UsersManager
    {
        public void AddUser(User user)
        {
            UsersStorage.AddUser(user);
        }
        public void DeleteUser(int userId)
        {
            UsersStorage.DeleteUserById(userId);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return UsersStorage.SelectAllUsers();
        }
    }
}
