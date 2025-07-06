using System.ComponentModel.DataAnnotations;

namespace PolimericosInventoryAPI.DTOs
{
    public class ProductCreateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ProductType { get; set; }

        [Required]
        public string Unit { get; set; }

        [Required]
        public decimal QuantityInStock { get; set; }

        [Required]
        public decimal MinimumStock { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        public int? CategoryId { get; set; }

        [MaxLength(200)]
        public string? Note { get; set; }
    }
}
