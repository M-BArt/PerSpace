using Azure.Core;
using Newtonsoft.Json;
using Shared.Models.Todo.ApiModels;
using Shared.Models.Todo.DTOsModel;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


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

        public async Task CompleteTask(Guid taskId)
        {
            try
            {
                using HttpClient client = _httpClientFactory.CreateClient("TodoAppBackoffice");

                using var httpResponseMessage =
                 await client.PostAsync($"Todo/{taskId}/complete",null);

                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting something fun to say: {Error}", ex);
            }
        }

        public async Task Create(TodoCreateRequest request)
        {
            try
            {
                using HttpClient client = _httpClientFactory.CreateClient("TodoAppBackoffice");

                StringContent content = new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    Application.Json);

                using var httpResponseMessage =
                 await client.PostAsync($"Todo", content);

                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting something fun to say: {Error}", ex);
            }
        }

        public Task Delete(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public async Task<TodoGetTaskDto> GetTask(Guid taskId)
        {
            using HttpClient client = _httpClientFactory.CreateClient("TodoAppClient");

            try
            {
                TodoGetTaskDto? todo = await client.GetFromJsonAsync<TodoGetTaskDto>(
                    $"Todo/{taskId}",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));

                return todo;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting something fun to say: {Error}", ex);
            }

            return null;
        }

        public async Task<IEnumerable<TodoGetAllDto>> TodoGetAll()
        {
            using HttpClient client = _httpClientFactory.CreateClient("TodoAppClient");

            try
            {
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

        public async Task Update(TodoUpdateRequest request, Guid taskId)
        {
            try
            {
                using HttpClient client = _httpClientFactory.CreateClient("TodoAppBackoffice");

                StringContent content = new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    Application.Json);

                using var httpResponseMessage =
                 await client.PutAsync($"Todo/{taskId}", content);

                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting something fun to say: {Error}", ex);
            }
        }
    }
}
