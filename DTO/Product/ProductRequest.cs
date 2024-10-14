using System.ComponentModel.DataAnnotations;

namespace Project_01.DTO.Product;

public class ProductRequest
{
    [Required]
    [MaxLength(100)]
    public string ProductName { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public double ProductPrice { get; set; }

    public string ProductDescription { get; set; }
    
    [Required]
    public int TypeId { get; set; }
}