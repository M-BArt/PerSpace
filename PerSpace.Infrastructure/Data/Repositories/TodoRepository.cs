using PerSpace.Domain.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using PerSpace.Application.DTOsModel;
using PerSpace.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using PerSpace.Domain.DataModels;

namespace PerSpace.Infrastructure.Data.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly string _connectionString;

        public TodoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }

        public async Task Create(TodoCreate task)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO Tasks (Title, Description, Category, Recurring, DueDate) VALUES(@Title, @Description, @Category, @Recurring, @DueDate)";
                var todoItems = await connection.ExecuteAsync(query, task);
            }
        }

        public async Task<IEnumerable<TodoGetAll>> GetAll()
        {
            using (SqlConnection connection = new (_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Tasks";
                var todoItems = await connection.QueryAsync<TodoGetAll>(query);
                return todoItems;
            }
        }
    }
}
