﻿using BackOffice.ApiModel;
using Shared.Models.Todo.DTOsModel;

namespace BackOffice.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoGetAllDto>> TodoGetAll();
        Task Create(TodoCreateRequest request);
        Task Delete(Guid taskId);
        Task<TodoGetTaskDto> GetTask(Guid taskId);
        Task Update(TodoUpdateRequest request, Guid taskId);
        Task CompleteTask(Guid taskId);
    }
}
