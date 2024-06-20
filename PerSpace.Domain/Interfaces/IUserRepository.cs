using PerSpace.Domain.DataModels.User;

namespace PerSpace.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserGetAll>> GetAll(Guid userId);
        Task<UserGet> Get(Guid userId);
        Task Login(UserLogin user, Guid userId);
        Task Register(UserRegister user, Guid userId);
        Task Delete(Guid userId);
    }
}
