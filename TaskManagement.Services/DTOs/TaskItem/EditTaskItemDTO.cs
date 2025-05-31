using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Services.DTOs.TaskItem
{
    public class EditTaskItemDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }
    }
}
