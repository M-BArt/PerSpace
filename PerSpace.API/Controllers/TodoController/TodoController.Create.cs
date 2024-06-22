using Microsoft.AspNetCore.Mvc;
using PerSpace.Application.ApiModel.Todo;

namespace PerSpace.API.Controllers.Todo
{
    public partial class TodoController
    {
        // POST: /Todo/
        /// <summary>
        /// Akcja do tworzenia nowego zadania (Task) w bazie danych.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("Todo")]
        public async Task<IActionResult> Create([FromBody] TodoCreateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _todoService.Create(request);
                return Ok("Stworzono nowe zadanie w bazie danych");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
