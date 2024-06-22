using Shared.Models.User.User;

namespace PerSpace.Domain.Interfaces
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
