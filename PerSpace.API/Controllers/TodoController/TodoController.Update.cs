using Microsoft.AspNetCore.Mvc;
using PerSpace.Application.ApiModel.Todo;

namespace PerSpace.API.Controllers.Todo
{
    public partial class TodoController
    {
        // PATCH: /Todo/{taskid}
        /// <summary>
        /// Action to update a task (Task) in the database.
        /// </summary>
        /// /// <param name="taskId"></param>
        [HttpPatch("Todo/{taskId}")]
        public async Task<IActionResult> Update([FromBody] TodoUpdateRequest request, [FromRoute] Guid taskId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _todoService.Update(request, taskId);
                return Ok("Task updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
