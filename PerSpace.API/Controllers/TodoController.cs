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
        // GET: /Todo/{taskId}
        /// <summary>
        /// Akcja do pobierania aktywnego zadania (Task) po Id.
        /// </summary>
        [HttpGet("Todo/{taskId}")]
        public async Task<IActionResult> GetTask([FromRoute]Guid taskId)
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
        // POST: /Todo/
        /// <summary>
        /// Akcja do tworzenia nowego zadania (Task) w bazie danych.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("Todo")]
        public async Task<IActionResult> Create([FromBody] TodoCreateRequest request)
        {
            try
            {
                await _todoService.Create(request);
                return Ok("Stworzono nowe zadanie w bazie danych.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Error Server");
            }
        }

        // DELETE: /Todo/{task_id}
        /// <summary>
        /// Akcja do usuwania zadania (Task) w bazie danych.
        /// </summary>
        /// /// <param name="taskId"></param>
        [HttpDelete("Todo/{taskId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid taskId)
        {
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
