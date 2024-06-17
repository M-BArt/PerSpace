using Microsoft.Extensions.Logging;
using PerSpace.Application.DTOsModel;
using PerSpace.Domain.Interfaces;


namespace PerSpace.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger<TodoService> _logger;
        public TodoService(ITodoRepository todoRepository, ILogger<TodoService> logger)
        {
            _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
            _logger = logger;
        }

        public async Task<IEnumerable<TodoGetAllDto>> TodoGetAll()
        {
            var todoItem = await _todoRepository.GetAll();

            return todoItem.Select(todoItem => new TodoGetAllDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                IsCompleted = todoItem.IsCompleted,
                DueDate = todoItem.DueDate,
                CreateTime = todoItem.CreateTime,
                Category = todoItem.Category,
                CompletedDate = todoItem.CompletedDate,
                Recurring = todoItem.Recurring,
                Description = todoItem.Description,
                IsActive = todoItem.IsActive
            }).AsEnumerable();
        }
    }
}
