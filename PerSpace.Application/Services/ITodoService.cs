using PerSpace.Application.DTOsModel;

namespace PerSpace.Application.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoGetAllDto>> TodoGetAll();
    }
}
