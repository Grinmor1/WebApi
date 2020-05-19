using Microsoft.EntityFrameworkCore;
using WebApiDataLayer.Models;

namespace WebApiDataLayer
{
    public class EfDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public EfDbContext(DbContextOptions<EfDbContext> options)
            : base(options)
        {
        }

    }
}