using System;
using System.Collections.Generic;
using System.Linq;
using DAL_Lab1_ADO.NET.Models;
using DAL_Lab1_ADO.NET.Repositories;

namespace Buisness_Lab1_ADO.NET.Services
{
    public class StudentService : Interfaces.IStudentService
    {
        // use interface instead of concrete class to separate concerns
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }
        public void AddStudent(string firstName, string lastName)
        {
            // use the constructor without id to create a new instance of Student
            var student = new Student(firstName, lastName);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.Delete(id);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll().ToList();
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public void UpdateStudent(int id, string firstName, string lastName)
        {
            
            _studentRepository.Update(new Student(_studentRepository.GetById(id).Id, firstName, lastName));
        }
    }
}
