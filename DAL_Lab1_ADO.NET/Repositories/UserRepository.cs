using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Lab1_ADO.NET.Models;
using DAL_Lab1_ADO.NET.Repositories;

namespace DAL_Lab1_ADO.NET.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
