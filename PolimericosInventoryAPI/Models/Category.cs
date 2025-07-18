﻿using System.ComponentModel.DataAnnotations;

namespace PolimericosInventoryAPI.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
