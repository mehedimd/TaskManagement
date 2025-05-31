using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;
using TaskManagement.Infrastructure.DbContext;

namespace TaskManagement.Infrastructure.DataAccess
{
    public class TaskItemRepository : GenericRepository<TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
