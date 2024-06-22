using Microsoft.AspNetCore.Mvc;
using ReverseProxy.Services;

namespace ReverseProxy.Controllers.Todo
{
    public partial class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<TodoController> _logger;

        public TodoController(ITodoService todoService, ILogger<TodoController> logger)
        {
            _todoService = todoService;
            _logger = logger;
        }
    }
}
