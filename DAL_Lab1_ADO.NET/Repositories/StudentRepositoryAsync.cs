using System;
using System.Collections.Generic;
using DAL_Lab1_ADO.NET.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL_Lab1_ADO.NET.Repositories
{
    public class StudentRepositoryAsync : IRepositoryAsync<Student>
    {
        private readonly string _connectionString = DataAccess.ConnectionHelper.GetConnectionString();

        public async Task AddAsync(Student entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("INSERT INTO Students (FirstName, LastName) VALUES (@FirstName, @LastName)", connection);
                command.Parameters.AddWithValue("@FirstName", entity.FirstName);
                command.Parameters.AddWithValue("@LastName", entity.LastName);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("DELETE FROM Students WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    students.Add(new Student
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2)
                    });
                }
            }
            return students;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SELECT * FROM Students WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return new Student
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2)
                    };
                }
                return null;
            }
        }

        public async Task UpdateAsync(Student entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("UPDATE Students SET FirstName = @FirstName, LastName = @LastName WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@FirstName", entity.FirstName);
                command.Parameters.AddWithValue("@LastName", entity.LastName);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
