using System.ComponentModel.DataAnnotations;

namespace Project_01.DTO.Product;

public class ProductRequest
{
    [Required(ErrorMessage = "Product name is required")]
    [MaxLength(100)]
    public string ProductName { get; set; }
        
    [Required(ErrorMessage = "Product code is required")]
    public string ProductCode { get; set; }
    
    public string ProductDescription { get; set; }
    
    [Required(ErrorMessage = "Type is required")]
    public int TypeId { get; set; }
    
    [Required(ErrorMessage = "Brand is required")]
    public int BrandId { get; set; }
}