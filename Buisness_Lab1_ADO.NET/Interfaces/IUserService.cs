using System;
using System.Collections.Generic;
using DAL_Lab1_ADO.NET.Models;

namespace Buisness_Lab1_ADO.NET.Interfaces
{
    public interface IUserService
    {
        void AddUser(string username, string email, string passwordHash, Role role);
        void UpdateUser(int id, string username, string email, string passwordHash, Role role);
        void DeleteUser(int id);
        List<User> GetAllUsers();
        User GetUserById(int id);
        bool UserExistsByUsername(string username);
        bool UserExistsByEmail(string email);
        bool ValidateCredentials(string usernameOrEmail, string password);
        bool VerifyPassword(string password, string passwordHash);
        string HashPassword(string password);
    }
}
