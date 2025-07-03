using System.ComponentModel.DataAnnotations;

namespace PolimericosInventoryAPI.DTOs
{
    public class InventoryMovementCreateDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string MovementType { get; set; } // Entry o Exit

        [Required]
        public decimal Quantity { get; set; }

        [MaxLength(200)]
        public string? Note { get; set; }
    }
}
