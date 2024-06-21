using Microsoft.AspNetCore.Mvc;

namespace PerSpace.API.Controllers.Todo
{
    public partial class TodoController
    {
        // DELETE: /Todo/{task_id}
        /// <summary>
        /// Akcja do usuwania zadania (Task) w bazie danych.
        /// </summary>
        /// /// <param name="taskId"></param>
        [HttpDelete("Todo/{taskId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid taskId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _todoService.Delete(taskId);
                return Ok("Usunięto zadanie z bazy danych");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
