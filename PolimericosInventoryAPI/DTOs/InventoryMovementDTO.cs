namespace PolimericosInventoryAPI.DTOs
{
    public class InventoryMovementDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string MovementType { get; set; } // "Entry" o "Exit"
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public string? Note { get; set; }
    }
}
