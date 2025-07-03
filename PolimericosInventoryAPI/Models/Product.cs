using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolimericosInventoryAPI.Models
{
    public enum ProductType
    {
        Pigment,
        Liquid,
        Base
    }

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        [MaxLength(20)]
        public string Unit { get; set; } // grams, liters, parts, etc.

        [Column(TypeName = "decimal(10, 2)")]
        public decimal QuantityInStock { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal MinimumStock { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal UnitPrice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
