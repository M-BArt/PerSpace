using PerSpace.Domain.DataModels.Todo;

namespace PerSpace.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoGetAll>> GetAll();
        Task Create(TodoCreate task);
        Task Delete(Guid id);
        Task<TodoGetTask> GetTask(Guid taskId);
        Task Update(TodoUpdate todoTask, Guid taskId);
        Task CompleteTask(TodoCompleteTask todoTask, Guid taskId);
    }
}
 
