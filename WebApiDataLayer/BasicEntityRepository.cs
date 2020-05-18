using Microsoft.EntityFrameworkCore;

namespace WebApiDataLayer
{
    public class BasicEntityRepository : DbContext
    {
        public BasicEntityRepository(DbContextOptions<BasicEntityRepository> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}