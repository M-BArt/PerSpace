using Microsoft.AspNetCore.Mvc;

namespace PerSpace.API.Controllers.Todo
{
    public partial class TodoController
    {
        // POST: /Todo/{taskId}/complete
        /// <summary>
        /// Action to complete the task (Task)
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
                return Ok("Task completed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
