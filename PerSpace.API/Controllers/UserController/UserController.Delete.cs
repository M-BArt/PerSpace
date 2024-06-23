using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace PerSpace.API.Controllers.UserController
{
    public partial class UserController
    {
        //PUT: /user/{userId}
        /// <summary>
        /// Action to remove the user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut("user/{userId}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _userSrevice.Delete(userId);
                return Ok("User removed");

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }

    }
}
