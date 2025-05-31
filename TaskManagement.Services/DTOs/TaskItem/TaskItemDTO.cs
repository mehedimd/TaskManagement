using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Services.DTOs.TaskItem
{
    public class TaskItemDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; } 
        public string Title { get; set; } 
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
