using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerSpace.Application.ApiModel;
using Shared.Models.User.User;

namespace PerSpace.Application.Services
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
