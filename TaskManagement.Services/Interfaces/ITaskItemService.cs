using TaskManagement.Core.Entities;
using TaskManagement.Services.DTOs.TaskItem;

namespace TaskManagement.Services.Interfaces
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItem>> GetAllTaskItemAsync();
        Task<TaskFilterDTO> GetAllAsQueryable(TaskFilterDTO filter);
        Task<TaskItemDTO> GetTaskItemAsync(int taskId);
        Task<bool> AddTaskItemAsync(TaskItemDTO model);
        Task<bool> UpdateTaskitemAsync(TaskItemDTO model);
        Task<bool> DeleteTaskItemAsync(int taskId);
        Task ToggleIsCompletedAsync(int id);
    }
}
