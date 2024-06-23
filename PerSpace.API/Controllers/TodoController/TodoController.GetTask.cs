using Microsoft.AspNetCore.Mvc;

namespace PerSpace.API.Controllers.Todo
{
    public partial class TodoController
    {
        // GET: /Todo/{taskId}
        /// <summary>
        /// Action to get active task (Task) by Id
        /// </summary>
        [HttpGet("Todo/{taskId}")]
        public async Task<IActionResult> GetTask([FromRoute] Guid taskId)
        {
            try
            {
                return Ok(await _todoService.GetTask(taskId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
