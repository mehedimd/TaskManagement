using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Services.DTOs.Account
{
    public class RegisterDTO
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare("Password", ErrorMessage = "Password do not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
