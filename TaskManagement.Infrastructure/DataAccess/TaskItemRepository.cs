using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;
using TaskManagement.Infrastructure.DbContext;

namespace TaskManagement.Infrastructure.DataAccess
{
    public class TaskItemRepository : GenericRepository<TaskItem>, ITaskItemRepository
    {
        private readonly ApplicationDbContext _db;
        public TaskItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._db = dbContext;
        }
        public IQueryable<TaskItem> GetCurrentUserTaskQueryable(string userId)
        {
            return _db.Set<TaskItem>().AsQueryable().Where(task => task.UserId == userId);
        }
    }
}
