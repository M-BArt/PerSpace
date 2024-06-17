using PerSpace.Domain.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using PerSpace.Application.DTOsModel;
using PerSpace.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace PerSpace.Infrastructure.Data.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly string _connectionString;

        public TodoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
            
            if (_connectionString == null)
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
            }
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            using (SqlConnection connection = new (_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Tasks";
                var todoItems = await connection.QueryAsync<TodoItem>(query);
                return todoItems;
            }
        }
    }
}
