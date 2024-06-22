using PerSpace.Application.ApiModel;
using Shared.Models.Todo.DTOsModel;

namespace PerSpace.Application.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoGetAllDto>> TodoGetAll();
        Task Create(TodoCreateRequest request);
        Task Delete(Guid taskId);
        Task<Shared.Models.Todo.DTOsModel.TodoGetTaskDto> GetTask(Guid taskId);
        Task Update(TodoUpdateRequest request, Guid taskId);
        Task CompleteTask(Guid taskId);
    }
}
