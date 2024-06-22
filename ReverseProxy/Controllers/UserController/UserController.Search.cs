using Microsoft.AspNetCore.Mvc;

namespace PerSpace.API.Controllers.UserController
{
    public partial class UserController
    {
        //GET: /user/{userId}
        /// <summary>
        /// Akcja do pobierania danych o użytkowniku.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> Search([FromRoute] Guid userId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                return Ok("Pobrano dane użytkownika");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
