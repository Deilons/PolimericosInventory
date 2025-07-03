using Microsoft.EntityFrameworkCore;

namespace PolimericosInventoryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
