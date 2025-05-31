using TaskManagement.Core.Entities;
using TaskManagement.Services.DTOs.TaskItem;

namespace TaskManagement.Services.Interfaces
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItemDTO>> GetAllTaskItemAsync();
        Task<TaskItem> GetTaskItemAsync(int taskId);
        Task<bool> AddTaskItemAsync(AddTaskItemDTO model);
        Task<bool> UpdateTaskitemAsync(EditTaskItemDTO model);
        Task<bool> DeleteTaskItemAsync(int taskId);
    }
}
