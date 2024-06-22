using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers.Todo
{
    public partial class TodoController
    {
        // POST: /Todo/{taskId}/complete
        /// <summary>
        /// Akcja do zakończenia zadania (Task).
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpPost("Todo/{taskId}/complete")]
        public async Task<IActionResult> CompleteTask([FromRoute] Guid taskId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _todoService.CompleteTask(taskId);
                return Ok("Zadanie wykonane");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
