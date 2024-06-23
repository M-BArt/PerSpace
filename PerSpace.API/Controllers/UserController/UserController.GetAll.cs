using Microsoft.AspNetCore.Mvc;

namespace PerSpace.API.Controllers.UserController
{
    public partial class UserController
    {
        //GET: /user
        /// <summary>
        /// Action to get the list of users.
        /// </summary>
        /// <returns></returns>
        [HttpGet("users")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _userSrevice.GetAll();
                return Ok("Downloaded all users");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
