
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; } = null!;
    }
}