using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PerSpace.Domain.Interfaces;
using Shared.Models.User.User;

namespace PerSpace.Infrastructure.Data.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }

        public async Task Delete(Guid userId)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE User SET IsActive = 0 FROM User WHERE Id = @userId";
                await connection.ExecuteAsync(query, userId);
            }
        }

        public async Task<UserGet> GetProfile(Guid userId)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM User WHERE Id = @userId";
                return await connection.QuerySingleAsync<UserGet>(query, userId);
            }
        }

        public async Task<IEnumerable<UserGetAll>> GetAll()
        {
            using (SqlConnection connection = new(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM User";
                return await connection.QueryAsync<UserGetAll>(query);
            }
        }

        public async Task<UserAccount> GetUserAccount(string email)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, Email, PasswordHash, PasswordSalt FROM User WHERE Email = @email";
                return await connection.QuerySingleAsync<UserAccount>(query, email);
            }
        }

        public async Task Create(UserCreate user)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO Tasks (Email, Password, Firstname, Lastname) VALUES(@Email, @Password, @Firstname, @Lastname)";
                await connection.ExecuteAsync(query, user);
            }
        }
    }
}
