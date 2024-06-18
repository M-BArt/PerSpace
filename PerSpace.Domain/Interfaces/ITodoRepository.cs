using PerSpace.Domain.DataModels;
using PerSpace.Domain.Models;

namespace PerSpace.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoGetAll>> GetAll();
        Task Create(TodoCreate task);
        Task Delete(Guid id);
        Task<TodoGetTask> GetTask(Guid taskId);
    }
}
 
