using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_01.Models;

[Table(name: "Product")]
public class Product : PrimaryEntity
{
    [Required(ErrorMessage = "Product name is required")]
    [MaxLength(100)]
    public string ProductName { get; set; }
    
    [Required(ErrorMessage = "Product code is required")]
    public string ProductCode { get; set; }

    public string ProductDescription { get; set; }

    [Required(ErrorMessage = "Type is required")]
    public int TypeId { get; set; }

    [ForeignKey("TypeId")]
    public Type Type { get; set; }
    
    [Required(ErrorMessage = "Brand is required")]
    public int BrandId { get; set; }

    [ForeignKey("BrandId")]
    public Brand Brand { get; set; }
    
    public virtual ICollection<ProductDetail> ProductDetails { get; set; }
}

