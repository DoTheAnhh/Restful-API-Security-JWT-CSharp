using System.ComponentModel.DataAnnotations;

namespace Project_01.DTO.Color;

public class ColorRequest
{
    [Required(ErrorMessage = "Color name is required")]
    [MaxLength(100)]
    public string ColorName { get; set; }
}