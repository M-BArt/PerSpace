using Microsoft.AspNetCore.Mvc;

namespace PerSpace.API.Controllers.Todo
{
    public partial class TodoController
    {
        // DELETE: /Todo/{task_id}
        /// <summary>
        /// Action to delete a task (Task) in the database.
        /// </summary>
        /// /// <param name="taskId"></param>
        [HttpPut("Todo/{taskId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid taskId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _todoService.Delete(taskId);
                return Ok("Deleted task from database");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
