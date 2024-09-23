using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Lab1_ADO.NET.Models;

namespace Buisness_Lab1_ADO.NET.Interfaces
{
    public interface IStudentService
    {
        void AddStudent(string firstName, string lastName );
        void UpdateStudent(int id, string firstName, string lastName);
        void DeleteStudent(int id);
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
    }
}
