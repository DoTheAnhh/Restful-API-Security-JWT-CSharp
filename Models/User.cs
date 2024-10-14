using System.ComponentModel.DataAnnotations.Schema;

namespace Project_01.Models;

[Table(name: "User")]
public class User : PrimaryEntity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}