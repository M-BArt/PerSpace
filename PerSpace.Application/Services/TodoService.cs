using Microsoft.Extensions.Logging;
using PerSpace.Domain.Interfaces.Todo;
using Shared.Models.Todo.DTOsModel;


namespace PerSpace.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger<TodoService> _logger;
        public TodoService(ITodoRepository todoRepository, ILogger<TodoService> logger)
        {
            _todoRepository = todoRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<TodoGetAllDto>> TodoGetAll()
        {
            var todoTask = await _todoRepository.GetAll();

            return todoTask.Select(todoTask => new TodoGetAllDto
            {
                Id = todoTask.Id,
                Title = todoTask.Title,
                IsCompleted = todoTask.IsCompleted,
                DueDate = todoTask.DueDate,
                CreateTime = todoTask.CreateTime,
                Category = todoTask.Category,
                CompletedDate = todoTask.CompletedDate,
                Recurring = todoTask.Recurring,
                Description = todoTask.Description,
                IsActive = todoTask.IsActive
            }).AsEnumerable();
        }

        public async Task<TodoGetTaskDto> GetTask(Guid taskId)
        {
            var todoTaskData = await _todoRepository.GetTask(taskId);

            var todoTask = new TodoGetTaskDto
            {
                Title = todoTaskData.Title,
                Description = todoTaskData.Description,
                Category = todoTaskData.Category,
                Recurring = todoTaskData.Recurring,
                DueDate = todoTaskData.DueDate,
                IsCompleted = todoTaskData.IsCompleted,
                CompletedDate = todoTaskData.CompletedDate,
                IsActive = todoTaskData.IsActive
            };

            return todoTask;
        }
    }
}
