using PerSpace.Application.ApiModel;
using Shared.Models.User.User;

namespace ReverseProxy.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<UserGetAll>> GetAll(Guid userId);
        Task<UserGet> Get(Guid userId);
        Task Login(UserLoginRequest request, Guid userId);
        Task Register(UserRegisterRequest request);
        Task Delete(Guid userId);
    }
}
