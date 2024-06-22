using Microsoft.AspNetCore.Mvc;

namespace PerSpace.API.Controllers.UserController
{
    public partial class UserController
    {
        //GET: /user
        /// <summary>
        /// Akcja do pobierania listy użytkowników.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("users")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                return Ok("Pobrano wszystkich użytkowników");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
