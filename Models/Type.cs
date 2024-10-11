﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_01.Models
{
    [Table(name: "Type")]
    public class Type
    {
        [Key]
        public int TypeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
