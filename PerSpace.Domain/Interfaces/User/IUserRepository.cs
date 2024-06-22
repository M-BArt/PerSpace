using PerSpace.Domain.DataModels.User;

namespace PerSpace.Domain.Interfaces.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserProfile>> GetAll();
        Task<UserProfile> GetProfile(Guid userId);
        Task<UserAccount> GetUserAccount(string email);
        Task Create(UserCreate user);
        Task Delete(Guid userId);
        Task Update(UserProfile user, Guid userId);
    }
}
