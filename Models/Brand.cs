using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_01.Models;

[Table(name: "Brand")]
public class Brand : PrimaryEntity
{
    [Required(ErrorMessage = "Brand name is required")]
    [MaxLength(100)]
    public string BrandName { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}