using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PerSpace.Application.ApiModel;
using PerSpace.Application.DTOsModel;
using PerSpace.Domain.DataModels;
using PerSpace.Domain.Interfaces;
using PerSpace.Domain.Services;


namespace PerSpace.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly TodoDomainService _todoDomainService;
        private readonly ILogger<TodoService> _logger;
        public TodoService(ITodoRepository todoRepository,TodoDomainService todoDomainService, ILogger<TodoService> logger)
        {
            _todoRepository = todoRepository;
            _todoDomainService = todoDomainService;
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

        public async Task Create(TodoCreateRequest request)
        {
            var todoTask = new TodoCreate
            {
                Title = request.Title,
                Description = request.Description,
                Category = request.Category,
                Recurring = request.Recurring,
                DueDate = request.DueDate
            };

            await _todoDomainService.DateValidation(todoTask.DueDate);

            await _todoRepository.Create(todoTask);
        }

        public async Task Delete(Guid taskId)
        {
            await _todoRepository.Delete(taskId);
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

        public async Task Update(TodoUpdateRequest request, Guid taskId)
        {

            var todoTask = new TodoUpdate
            {
                Title = request.Title,
                Recurring = request.Recurring,
                Description = request.Description,
                Category = request.Category,
                DueDate = request.DueDate
            };

            await _todoRepository.Update(todoTask, taskId);
        }

        public async Task CompleteTask(Guid taskId)
        {
            TodoGetTask task = await _todoRepository.GetTask(taskId);

            var completeTask = new TodoCompleteTask
            {
                IsCompleted = task.IsCompleted,
                CompletedDate = task.CompletedDate,
                IsActive = task.IsActive,
            };

            completeTask = await _todoDomainService.MarkCompleteTask(completeTask);

            await _todoRepository.CompleteTask(completeTask, taskId);
        }
    }
}
