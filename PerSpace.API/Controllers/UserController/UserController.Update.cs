using Microsoft.AspNetCore.Mvc;
using PerSpace.Application.ApiModel.User;

namespace PerSpace.API.Controllers.UserController
{
    public partial class UserController
    {
        //POST: /user/{userId}
        /// <summary>
        /// Action to update user data.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("user/{userId}")]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequest request, [FromRoute] Guid userId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                return Ok("User data updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
