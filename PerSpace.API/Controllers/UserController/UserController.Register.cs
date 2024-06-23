using Microsoft.AspNetCore.Mvc;
using PerSpace.Application.ApiModel.User;

namespace PerSpace.API.Controllers.UserController
{
    public partial class UserController
    {
        //POST: /user/register
        /// <summary>
        /// Action to register a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("user/register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                return Ok("User registered");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
