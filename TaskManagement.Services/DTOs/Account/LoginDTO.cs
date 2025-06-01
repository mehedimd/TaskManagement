﻿using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Services.DTOs.Account
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
