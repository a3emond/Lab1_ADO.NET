using System;
using System.Collections.Generic;
using DAL_Lab1_ADO.NET.Models;

namespace Buisness_Lab1_ADO.NET.Interfaces
{
    internal interface IUserService
    {
        void AddUser(string username, string email, string passwordHash, Role role);
        void UpdateUser(int id, string username, string email, string passwordHash, Role role);
        void DeleteUser(int id);
        List<User> GetAllUsers();
        User GetUserById(int id);
    }
}
