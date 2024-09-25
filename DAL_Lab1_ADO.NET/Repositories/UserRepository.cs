using System.Collections.Generic;
using System.Data.SqlClient;
using DAL_Lab1_ADO.NET.Models;

namespace DAL_Lab1_ADO.NET.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly string _connectionString = DataAccess.ConnectionHelper.GetConnectionString();

        public IEnumerable<User> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Email = reader.GetString(2),
                        PasswordHash = reader.GetString(3),
                        Role = (Role)reader.GetInt32(4)
                    };
                }
            }
        }

        public User GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Email = reader.GetString(2),
                        PasswordHash = reader.GetString(3),
                        Role = (Role)reader.GetInt32(4)
                    };
                }

                return null;
            }
        }
        public User GetByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Email = reader.GetString(2),
                        PasswordHash = reader.GetString(3),
                        Role = (Role)reader.GetInt32(4)
                    };
                }

                return null;
            }
        }
        public User GetByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Email = reader.GetString(2),
                        PasswordHash = reader.GetString(3),
                        Role = (Role)reader.GetInt32(4)
                    };
                }

                return null;
            }
        }
        public void Add(User entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Users (Username, Email, PasswordHash, Role) VALUES (@Username, @Email, @PasswordHash, @Role)", connection);
                command.Parameters.AddWithValue("@Username", entity.Username);
                command.Parameters.AddWithValue("@Email", entity.Email);
                command.Parameters.AddWithValue("@PasswordHash", entity.PasswordHash);
                command.Parameters.AddWithValue("@Role", entity.Role);
                command.ExecuteNonQuery();
            }
        }

        public void Update(User entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Users SET Username = @Username, Email = @Email, PasswordHash = @PasswordHash, Role = @Role WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@Username", entity.Username);
                command.Parameters.AddWithValue("@Email", entity.Email);
                command.Parameters.AddWithValue("@PasswordHash", entity.PasswordHash);
                command.Parameters.AddWithValue("@Role", entity.Role);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
