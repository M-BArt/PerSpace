using Microsoft.AspNetCore.Mvc;
using PerSpace.Application.ApiModel;

namespace PerSpace.API.Controllers.UserController
{
    public partial class UserController
    {
        //POST: /user/login
        /// <summary>
        /// Akcja do logowania się użytkownika.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("user/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                return Ok("Zalogowano użytkownika");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
