using Microsoft.EntityFrameworkCore;
using WebApiDataLayer.Models;

namespace WebApiDataLayer
{
    public class UserEntityRepository : EntityRepository<User>
    {
        public UserEntityRepository(EfDbContext context) : base(context)
        {
        }

        protected override DbSet<User> DbSet => Context.Users;
    }
}