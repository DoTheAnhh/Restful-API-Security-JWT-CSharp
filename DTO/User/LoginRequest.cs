﻿using System.ComponentModel.DataAnnotations;

namespace Project_01.DTO.User;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password  { get; set; }
}