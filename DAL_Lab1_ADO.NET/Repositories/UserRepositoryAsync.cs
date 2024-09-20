using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DAL_Lab1_ADO.NET.Models;

namespace DAL_Lab1_ADO.NET.Repositories
{
    public class UserRepositoryAsync : IRepositoryAsync<User>
    {
        private readonly string _connectionString = DataAccess.ConnectionHelper.GetConnectionString();

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    users.Add(new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Email = reader.GetString(2),
                        PasswordHash = reader.GetString(3),
                        Role = (Role)reader.GetInt32(4)
                    });
                }
            }

            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
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

        public async Task AddAsync(User entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("INSERT INTO Users (Username, Email, PasswordHash, Role) VALUES (@Username, @Email, @PasswordHash, @Role)", connection);
                command.Parameters.AddWithValue("@Username", entity.Username);
                command.Parameters.AddWithValue("@Email", entity.Email);
                command.Parameters.AddWithValue("@PasswordHash", entity.PasswordHash);
                command.Parameters.AddWithValue("@Role", entity.Role);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(User entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("UPDATE Users SET Username = @Username, Email = @Email, PasswordHash = @PasswordHash, Role = @Role WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@Username", entity.Username);
                command.Parameters.AddWithValue("@Email", entity.Email);
                command.Parameters.AddWithValue("@PasswordHash", entity.PasswordHash);
                command.Parameters.AddWithValue("@Role", entity.Role);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("DELETE FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
