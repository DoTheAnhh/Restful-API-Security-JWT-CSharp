using System.ComponentModel.DataAnnotations;

namespace Project_01.DTO.Type;

public class TypeResponse
{
    [Required]
    [MaxLength(100)]
    public string TypeName { get; set; }
}