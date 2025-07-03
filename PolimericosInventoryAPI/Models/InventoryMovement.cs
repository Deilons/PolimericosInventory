using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolimericosInventoryAPI.Models
{
    public enum MovementType
    {
        Entry,
        Exit
    }

    public class InventoryMovement
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public MovementType MovementType { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Quantity { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        [MaxLength(200)]
        public string? Note { get; set; }
    }
}
