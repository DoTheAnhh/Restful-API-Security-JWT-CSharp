using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_01.Models;

[Table(name: "Color")]
public class Color : PrimaryEntity
{
    [Required(ErrorMessage = "Color name is required")]
    [MaxLength(100)]
    public string ColorName { get; set; }

    public virtual ICollection<ProductDetail> ProductDetails { get; set; }
}