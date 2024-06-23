﻿using Microsoft.AspNetCore.Mvc;

namespace PerSpace.API.Controllers.Todo
{
    public partial class TodoController
    {
        // GET: /Todo/
        /// <summary>
        /// Action to download all active tasks (Tasks).
        /// </summary>
        [HttpGet("Todo")]
        public async Task<IActionResult> GetTodoList()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                return Ok(await _todoService.TodoGetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
