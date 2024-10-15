using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_01.Models;

[Table(name: "Cart")]
public class Cart : PrimaryEntity
{
    public int Quantity { get; set; }
    
    public float TotalPrice { get; set; }
    
    [Required(ErrorMessage = "User is required")]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    public virtual ICollection<ProductDetail> ProductDetails { get; set; }
}