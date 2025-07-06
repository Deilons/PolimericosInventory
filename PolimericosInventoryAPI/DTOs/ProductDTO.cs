namespace PolimericosInventoryAPI.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public string Unit { get; set; }
        public decimal QuantityInStock { get; set; }
        public decimal MinimumStock { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CategoryName { get; set; }
        public string? Note { get; set; }
    }
}
