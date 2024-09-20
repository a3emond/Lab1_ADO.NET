using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buisness_Lab1_ADO.NET.Interfaces;
using DAL_Lab1_ADO.NET.Models;

namespace Buisness_Lab1_ADO.NET.Services
{
    internal class UserService : IUserService
    {
        public void AddUser(string username, string email, string passwordHash, Role role)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(int id, string username, string email, string passwordHash, Role role)
        {
            throw new NotImplementedException();
        }
    }
}
