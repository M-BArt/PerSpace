using Microsoft.AspNetCore.Mvc;
using PerSpace.Application.ApiModel;
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

        // GET: /Todo/
        /// <summary>
        /// Akcja do pobierania wszystkich aktywnych zadań (Tasks).
        /// </summary>
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


        // POST: /Todo/
        /// <summary>
        /// Akcja do tworzenia nowego zadania (Task) w bazie danych.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("Todo")]
        public async Task<IActionResult> Create(TodoCreateRequest request)
        {
            try
            {
                await _todoService.Create(request);
                return Ok("Stworzono nowe zadanie.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }
    }
}
