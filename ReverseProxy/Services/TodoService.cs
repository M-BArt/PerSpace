using System.Collections.Generic;
using System.Text.Json;
using ReverseProxy.ApiModel;
using Shared.Models.Todo.DTOsModel;


namespace ReverseProxy.Services
{
    public class TodoService : ITodoService
    {
        private readonly IHttpClientFactory _httpClientFactory = null!;
        private readonly ILogger<TodoService> _logger = null!;

        public TodoService(IHttpClientFactory httpClientFactory, ILogger<TodoService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IEnumerable<TodoGetAllDto>> TodoGetAll()
        {
            using HttpClient client = _httpClientFactory.CreateClient("TodoAppClient");

            try
            {
                // Make HTTP GET request
                // Parse JSON response deserialize into Todo type
                IEnumerable<TodoGetAllDto>? todos = await client.GetFromJsonAsync<IEnumerable<TodoGetAllDto>>(
                    $"Todo",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));

                return todos ?? [];
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting something fun to say: {Error}", ex);
            }

            return [];
        }

        //public async Task Create(TodoCreateRequest request)
        //{
        //    var todoTask = new TodoCreate
        //    {
        //        Title = request.Title,
        //        Description = request.Description,
        //        Category = request.Category,
        //        Recurring = request.Recurring,
        //        DueDate = request.DueDate
        //    };

        //    if (todoTask.DueDate <= DateTime.Now)
        //        throw new Exception("Invalid date");

        //    await _todoRepository.Create(todoTask);
        //}

        //public async Task Delete(Guid taskId)
        //{
        //    await _todoRepository.Delete(taskId);
        //}

        //public async Task<TodoGetTaskDto> GetTask(Guid taskId)
        //{
        //    var todoTaskData = await _todoRepository.GetTask(taskId);

        //    var todoTask = new TodoGetTaskDto
        //    {
        //        Title = todoTaskData.Title,
        //        Description = todoTaskData.Description,
        //        Category = todoTaskData.Category,
        //        Recurring = todoTaskData.Recurring,
        //        DueDate = todoTaskData.DueDate,
        //        IsCompleted = todoTaskData.IsCompleted,
        //        CompletedDate = todoTaskData.CompletedDate,
        //        IsActive = todoTaskData.IsActive
        //    };

        //    return todoTask;
        //}

        //public async Task Update(TodoUpdateRequest request, Guid taskId)
        //{

        //    var todoTask = new TodoUpdate
        //    {
        //        Title = request.Title,
        //        Recurring = request.Recurring,
        //        Description = request.Description,
        //        Category = request.Category,
        //        DueDate = request.DueDate
        //    };

        //    await _todoRepository.Update(todoTask, taskId);
        //}

        //public async Task CompleteTask(Guid taskId)
        //{
        //    TodoGetTask task = await _todoRepository.GetTask(taskId);

        //    var completeTask = new TodoCompleteTask
        //    {
        //        IsCompleted = task.IsCompleted,
        //        CompletedDate = task.CompletedDate,
        //        IsActive = task.IsActive,
        //    };

        //    if (!completeTask.IsActive) throw new Exception("Zadanie nie istnieje w bazie danych");

        //    if (completeTask.IsCompleted == true) throw new Exception("Zadanie jest już wykonane");

        //    completeTask.IsCompleted = true;

        //    completeTask.CompletedDate = DateTime.Now;

        //    await _todoRepository.CompleteTask(completeTask, taskId);
        //}
    }
}
