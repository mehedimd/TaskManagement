using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
