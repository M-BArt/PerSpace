using PerSpace.Application.ApiModel;
using ReverseProxy.Interfaces.User;
using Shared.Models.User.User;
using System.Security.Cryptography;

namespace ReverseProxy.Services
{
    internal class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task Delete(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserGet> Get(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserGetAll>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserGetAll>> GetAll(Guid userId)
        {
            throw new NotImplementedException();
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

        private static void EmailValidation(string email)
        {

        }
    }
}
