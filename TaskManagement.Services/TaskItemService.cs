using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;
using TaskManagement.Services.DTOs.TaskItem;
using TaskManagement.Services.Interfaces;

namespace TaskManagement.Services
{
    public class TaskItemService : ITaskItemService
    {
        public readonly ITaskItemRepository _repo;
        public readonly IUserService _userService;
        public TaskItemService(ITaskItemRepository repo, IUserService userService)
        {
            _repo = repo;
            _userService = userService;
        }
        public async Task<bool> AddTaskItemAsync(AddTaskItemDTO model)
        {
            if(model != null)
            {
                TaskItem taskItem = new TaskItem()
                {
                    UserId = _userService.GetCurrentUserId,
                    Title = model.Title,
                    Description = model.Description,
                    IsCompleted = false,
                    DueDate = model.DueDate
                };
                await _repo.Add(taskItem);

                int result = await _repo.SaveChangesAsync();

                return result > 0;
            } 
            return false;
        }

        Task<bool> ITaskItemService.DeleteTaskItemAsync(int taskId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<TaskItemDTO>> ITaskItemService.GetAllTaskItemAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TaskItem> GetTaskItemAsync(int taskId)
        {
            return await _repo.GetById(taskId);
        }

        public async Task<bool> UpdateTaskitemAsync(EditTaskItemDTO model)
        {
            if(model != null)
            {
                var taskItem = await _repo.GetById(model.Id);
                if(taskItem != null)
                {
                    taskItem.Title = model.Title;
                    taskItem.Description = model.Description;
                    taskItem.DueDate = model.DueDate;

                    _repo.Update(taskItem);

                    int result = await _repo.SaveChangesAsync();

                    return result > 0;
                }
            }
            return false;
        }
    }
}
