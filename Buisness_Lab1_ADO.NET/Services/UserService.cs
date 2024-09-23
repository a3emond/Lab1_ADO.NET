using System;
using System.Collections.Generic;
using System.Linq;
using Buisness_Lab1_ADO.NET.Interfaces;
using DAL_Lab1_ADO.NET.Models;
using DAL_Lab1_ADO.NET.Repositories;

namespace Buisness_Lab1_ADO.NET.Services
{
    public class UserService : IUserService
    {
        //trying to learn how to use interfaces to separate concerns between the business and data access layers

        // use interface instead of concrete class to separate concerns
        private readonly IRepository<User> _userRepository;

        // use constructor injection instead of creating a new instance of UserRepository
        public UserService(IRepository<User> userRepository)
        {
            // throw an exception if userRepository is null
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void AddUser(string username, string email, string passwordHash, Role role)
        {
            // use the constructor to create a new instance of User
            var user = new User(username, email, passwordHash, role);
            // use the Add method of the repository to add the user
            _userRepository.Add(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll().ToList();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void UpdateUser(int id, string username, string email, string passwordHash, Role role)
        {
            _userRepository.Update(new User(_userRepository.GetById(id).Id, username, email, passwordHash, role));
        }
    }
}
