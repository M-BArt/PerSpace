using Microsoft.AspNetCore.Mvc;

namespace PerSpace.API.Controllers.UserController
{
    public partial class UserController
    {
        //POST: /user/{userId}
        /// <summary>
        /// Akcja do aktualizowania danych użytkownika.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("user/{userId}")]
        public async Task<IActionResult> Update([FromRoute] Guid userId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                return Ok("Zaktualizowano dane użytkownika");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
