using PerSpace.Application.ApiModel.User;
using PerSpace.Domain.DataModels.User;

namespace PerSpace.Application.Services.User
{
    public interface IUserServices
    {
        Task<IEnumerable<UserProfile>> GetAll();
        Task<UserProfile> Get(Guid userId);
        Task Login(UserLoginRequest request, Guid userId);
        Task Register(UserRegisterRequest request);
        Task Delete(Guid userId);
    }
}
