using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Services.DTOs.TaskItem
{
    public class AddTaskItemDTO
    {
        [Required]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Due Date")]
        public DateTime? DueDate { get; set; }
    }
}
