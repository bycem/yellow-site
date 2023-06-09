﻿using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "User Name is required")]
    public string? Username { get; set; }

    [MinLength(3), MaxLength(128)]
    [Required(ErrorMessage = "Full Name is required")]
    public string? FullName { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
    
}