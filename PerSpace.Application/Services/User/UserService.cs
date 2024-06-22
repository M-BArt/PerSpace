using System.Security.Cryptography;
using PerSpace.Application.ApiModel.User;
using PerSpace.Domain.DataModels.User;
using PerSpace.Domain.Interfaces.User;

namespace PerSpace.Application.Services.User
{
    internal class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Delete(Guid userId)
        {
            await _userRepository.Delete(userId);
        }

        public async Task<UserProfile> Get(Guid userId)
        {
            return await _userRepository.GetProfile(userId);
        }

        public async Task<IEnumerable<UserProfile>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task Update(UserUpdateRequest request, Guid userId)
        {
            var user = new UserProfile
            {
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
            };
            
            
            await _userRepository.Update(user, userId);
        }

        public Task Login(UserLoginRequest request, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task Register(UserRegisterRequest request)
        {

            var UserAccount = _userRepository.GetUserAccount(request.Email);

            if (!(UserAccount is null)) throw new Exception("Adres email istnieje juz w bazie");

            var user = new UserCreate
            {
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
            };

            CreateHashPassword(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _userRepository.Create(user);
        }

        private static (byte[], byte[]) CreateHashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA256 hmac = new())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return (passwordSalt, passwordHash);
        }
    }
}
