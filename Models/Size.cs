using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_01.Models;

[Table(name: "Size")]
public class Size : PrimaryEntity
{
    [Required(ErrorMessage = "Size name is required")]
    [MaxLength(100)]
    public string SizeName { get; set; }

    public virtual ICollection<ProductDetail> ProductDetails { get; set; }
}