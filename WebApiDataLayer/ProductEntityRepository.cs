using Microsoft.EntityFrameworkCore;
using WebApiDataLayer.Models;

namespace WebApiDataLayer
{
    public class ProductEntityRepository : EntityRepository<Product>
    {
        public ProductEntityRepository(EfDbContext context) : base(context)
        {
        }

        protected override DbSet<Product> DbSet => Context.Products;
    }
}