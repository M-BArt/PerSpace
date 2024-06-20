using Microsoft.AspNetCore.Mvc;
using PerSpace.Domain.DataModels.Todo;

namespace PerSpace.Domain.Services
{
    public class TodoDomainService
    {
        public async Task DateValidation(DateTime? dateTime)
        {
            if (dateTime <= DateTime.Now)
                throw new Exception("Invalid date");
        }

        public async Task<TodoCompleteTask> MarkCompleteTask(TodoCompleteTask task)
        {
            var _task = task ?? throw new ArgumentNullException(nameof(task));
            
            if (!_task.IsActive) throw new Exception("Zadanie nie istnieje w bazie danych");
            
            if (_task.IsCompleted == true) throw new Exception("Zadanie jest już wykonane");

            _task.IsCompleted = true;

            _task.CompletedDate = DateTime.Now;

            return _task;
        }
    }
}
