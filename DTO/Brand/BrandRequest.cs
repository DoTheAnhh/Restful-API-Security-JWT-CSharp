using System.ComponentModel.DataAnnotations;

namespace Project_01.DTO.Brand;

public class BrandRequest
{
    [Required(ErrorMessage = "Brand name is required")]
    [MaxLength(100)]
    public string BrandName { get; set; }
}