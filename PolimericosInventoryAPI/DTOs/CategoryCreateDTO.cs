using System.ComponentModel.DataAnnotations;

namespace PolimericosInventoryAPI.DTOs
{
    public class CategoryCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
