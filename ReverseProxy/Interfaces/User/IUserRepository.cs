using Shared.Models.User.User;

namespace ReverseProxy.Interfaces.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserGetAll>> GetAll();
        Task<UserGet> GetProfile(Guid userId);
        Task<UserAccount> GetUserAccount(string email);
        Task Create(UserCreate user);
        Task Delete(Guid userId);
    }
}
