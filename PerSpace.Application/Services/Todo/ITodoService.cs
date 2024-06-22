using PerSpace.Application.ApiModel.Todo;
using PerSpace.Application.DTOsModel.Todo;
using PerSpace.Domain.DataModels.Todo;

namespace PerSpace.Application.Services.Todo
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoGetAllDto>> TodoGetAll();
        Task Create(TodoCreateRequest request);
        Task Delete(Guid taskId);
        Task<TodoGetTaskDto> GetTask(Guid taskId);
        Task Update(TodoUpdateRequest request, Guid taskId);
        Task CompleteTask(Guid taskId);
    }
}
