namespace TaskManagement.Services.DTOs.TaskItem
{
    public class TaskFilterDTO
    {
        public string SortOrder { get; set; } = "asc";
        public bool? IsCompleted { get; set; }         // null = all, true = completed, false = not completed
        public IEnumerable<TaskManagement.Core.Entities.TaskItem> Tasks { get; set; } = new List<TaskManagement.Core.Entities.TaskItem>();
    }
}
