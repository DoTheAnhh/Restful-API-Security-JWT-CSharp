using System.ComponentModel.DataAnnotations;

namespace Project_01.DTO.User;

public class RegisterRequest
{
    [Required]
    public string? UserName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    
    public string? Password { get; set; }
}