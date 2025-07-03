using Microsoft.EntityFrameworkCore;
using PolimericosInventoryAPI.Models;

namespace PolimericosInventoryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<InventoryMovement> InventoryMovements { get; set; }

    }
}
