using System.ComponentModel.DataAnnotations;

namespace Project_01.DTO.Size;

public class SizeRequest
{
    [Required(ErrorMessage = "Size name is required")]
    [MaxLength(100)]
    public string SizeName { get; set; }
}