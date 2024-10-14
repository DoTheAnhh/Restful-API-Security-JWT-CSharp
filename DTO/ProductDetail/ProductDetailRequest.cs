using System.ComponentModel.DataAnnotations;

namespace Project_01.DTO.ProductDetail;

public class ProductDetailRequest
{
    [Required(ErrorMessage = "Product quantity is required")]
    public int Quantity;
    
    [Required(ErrorMessage = "Product price is required")]
    [Range(0, double.MaxValue)]
    public double Price { get; set; }
    
    [Required(ErrorMessage = "Product price is required")]
    public bool Status { get; set; } = true;
    
    [Required(ErrorMessage = "Color is required")]
    public int ColorId { get; set; }
        
    [Required(ErrorMessage = "Size is required")]
    public int SizeId { get; set; }
    
    [Required(ErrorMessage = "Product is required")]
    public int ProductId { get; set; }
}