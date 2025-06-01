using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Interfaces
{
    public interface ITaskItemRepository : IGenericRepository<TaskItem>
    {
        IQueryable<TaskItem> GetCurrentUserTaskQueryable(string userId);
    }
}
