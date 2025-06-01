using System.ComponentModel.DataAnnotations;
using TaskManagement.Core.Entities.Identity;

namespace TaskManagement.Core.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } = null!;
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!; // Required

        public string? Description { get; set; } // Optional

        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; } // Optional

        // Navigation property
        public ApplicationUser User { get; set; }
    }
}
