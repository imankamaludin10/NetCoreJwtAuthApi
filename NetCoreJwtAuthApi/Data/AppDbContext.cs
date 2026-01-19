using NetCoreJwtAuthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace NetCoreJwtAuthApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
    }
}
