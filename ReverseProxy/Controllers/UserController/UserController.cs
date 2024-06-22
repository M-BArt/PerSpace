using Microsoft.AspNetCore.Mvc;
using ReverseProxy.Services;

namespace PerSpace.API.Controllers.UserController
{
    public partial class UserController : ControllerBase
    {
        private readonly IUserServices _userSrevice;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserServices userSrevice, ILogger<UserController> logger)
        {
            _userSrevice = userSrevice;
            _logger = logger;
        }
    }
}
