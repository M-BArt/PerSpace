using Shared.Models.Todo.DTOsModel;

namespace PerSpace.Application.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoGetAllDto>> TodoGetAll();
        Task<TodoGetTaskDto> GetTask(Guid taskId);
    }
}
