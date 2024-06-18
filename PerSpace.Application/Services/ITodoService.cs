using PerSpace.Application.ApiModel;
using PerSpace.Application.DTOsModel;

namespace PerSpace.Application.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoGetAllDto>> TodoGetAll();
        Task Create(TodoCreateRequest request);
        Task Delete(Guid taskId);
    }
}
