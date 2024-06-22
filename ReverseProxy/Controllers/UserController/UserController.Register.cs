using Microsoft.AspNetCore.Mvc;
using PerSpace.Application.ApiModel;

namespace PerSpace.API.Controllers.UserController
{
    public partial class UserController
    {
        //POST: /user/register
        /// <summary>
        /// Akcja do rejestracji użytkownika.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("user/register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                return Ok("Zarejestrowano użytkownika");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
