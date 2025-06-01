using AutoMapper;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;
using TaskManagement.Services.DTOs.TaskItem;
using TaskManagement.Services.Interfaces;

namespace TaskManagement.Services
{
    public class TaskItemService : ITaskItemService
    {
        #region Config
        public readonly ITaskItemRepository _repo;
        public readonly IUserService _userService;
        private readonly IMapper _mapper;
        public TaskItemService(ITaskItemRepository repo, IUserService userService, IMapper map)
        {
            _repo = repo;
            _userService = userService;
            _mapper = map;
        }
        #endregion

        #region Add
        public async Task<bool> AddTaskItemAsync(TaskItemDTO dto)
        {
            if (dto != null)
            {
                var model = _mapper.Map<TaskItem>(dto);
                model.UserId = _userService.GetCurrentUserId;

                await _repo.Add(model);

                int result = await _repo.SaveChangesAsync();

                return result > 0;
            }
            return false;
        }
        #endregion

        #region Delete
        public async Task<bool> DeleteTaskItemAsync(int taskId)
        {
            if (taskId > 0)
            {
                var model = await _repo.GetById(taskId);
                if (model != null)
                {
                    _repo.Delete(model);
                    int result = await _repo.SaveChangesAsync();
                    return result > 0;
                }
            }
            return false;
        }
        #endregion

        #region Get All

        public async Task<IEnumerable<TaskItem>> GetAllTaskItemAsync()
        {
            return await _repo.GetAllAsync();
        }
        #endregion

        #region Get AsQueryable
        public TaskFilterDTO GetAllAsQueryable(TaskFilterDTO filter)
        {
            var query = _repo.GetQueryAble();

            if (filter.IsCompleted.HasValue)
            {
                query = query.Where(task => task.IsCompleted == filter.IsCompleted.Value);
            }

            query = filter.SortOrder == "desc" ? query.OrderByDescending(task => task.DueDate) : query.OrderBy(task => task.DueDate);

            filter.Tasks = query.ToList();

            return filter;
        }
        #endregion

        #region Get by Id
        public async Task<TaskItem> GetTaskItemAsync(int taskId)
        {
            return await _repo.GetById(taskId);
        }
        #endregion

        #region Update
        public async Task<bool> UpdateTaskitemAsync(TaskItemDTO dto)
        {
            if (dto != null)
            {
                var taskItem = await _repo.GetById(dto.Id);
                if (taskItem != null)
                {
                    taskItem.Title = dto.Title;
                    taskItem.Description = dto.Description;
                    taskItem.DueDate = dto.DueDate;

                    _repo.Update(taskItem);

                    int result = await _repo.SaveChangesAsync();

                    return result > 0;
                }
            }
            return false;
        }
        #endregion

        #region Toggle Completed
        public async Task ToggleIsCompletedAsync(int id)
        {
            var task = await _repo.GetById(id);

            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                _repo.Update(task);

                await _repo.SaveChangesAsync();
            }
        }
        #endregion
    }
}
