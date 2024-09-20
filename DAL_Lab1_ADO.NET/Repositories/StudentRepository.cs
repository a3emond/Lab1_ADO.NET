using System;
using System.Collections.Generic;
using DAL_Lab1_ADO.NET.Models;
using System.Data.SqlClient;


namespace DAL_Lab1_ADO.NET.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        public void Add(Student entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
