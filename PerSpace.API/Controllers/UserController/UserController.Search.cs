using Microsoft.AspNetCore.Mvc;

namespace PerSpace.API.Controllers.UserController
{
    public partial class UserController
    {
        //GET: /user/{userId}
        /// <summary>
        /// Action to download user data.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> Search([FromRoute] Guid userId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _userSrevice.Get(userId);
                return Ok("User data was downloaded");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
