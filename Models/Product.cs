using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_01.Models
{
    [Table(name: "Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double ProductPrice { get; set; }

        public string ProductDescription { get; set; }

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public Type Type { get; set; }
    }
}
