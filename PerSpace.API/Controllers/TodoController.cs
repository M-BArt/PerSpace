using Microsoft.AspNetCore.Mvc;

using PerSpace.Application.Services;

namespace PerSpace.API.Controllers
{
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<TodoController> _logger;

        public TodoController(ITodoService todoService, ILogger<TodoController> logger)
        {
            _todoService = todoService;
            _logger = logger;
        }

        [HttpGet("Todo")]
        public async Task<IActionResult> GetTodoList()
        {
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
