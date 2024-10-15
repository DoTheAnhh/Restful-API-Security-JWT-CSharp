using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_01.Models;

[Table(name: "ProductDetail")]
public class ProductDetail : PrimaryEntity
{
    [Required(ErrorMessage = "Product quantity is required")]
    public int Quantity { get; set; }
    
    [Required(ErrorMessage = "Product price is required")]
    [Range(0, double.MaxValue)]
    public double Price { get; set; }
    
    [Required(ErrorMessage = "Status is required")]
    public bool Status { get; set; } = true;
    
    [Required(ErrorMessage = "Color is required")]
    public int ColorId { get; set; }

    [ForeignKey("ColorId")]
    public Color Color { get; set; }
        
    [Required(ErrorMessage = "Size is required")]
    public int SizeId { get; set; }

    [ForeignKey("SizeId")]
    public Size Size { get; set; }
    
    [Required(ErrorMessage = "Product is required")]
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }
    
    [Required(ErrorMessage = "Cart is required")]
    public int CartId { get; set; }
    
    [ForeignKey("CartId")]
    public Cart Cart { get; set; }
}

