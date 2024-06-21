using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerSpace.Domain.DataModels.User;
using PerSpace.Domain.Interfaces;

namespace PerSpace.Infrastructure.Data.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public Task Delete(UserDelete user, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserGet> Get(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserGetAll>> GetAll(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task Login(UserLogin user, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task Register(UserRegister user, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
