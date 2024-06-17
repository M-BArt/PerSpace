using PerSpace.Domain.Models;

namespace PerSpace.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAll();
    }
}
 
