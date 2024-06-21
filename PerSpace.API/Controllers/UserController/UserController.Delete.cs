using Microsoft.AspNetCore.Mvc;

namespace PerSpace.API.Controllers.UserController
{
    public partial class UserController
    {
        //PUT: /user/{userId}
        /// <summary>
        /// Akcja do usuwania użytkownika.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut("user/{userId}")]
        public async Task<IActionResult> Delete()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                return Ok("Usunięto użytkownika");

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }

    }
}
