using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiDataLayer.Models;

namespace WebApiDataLayer
{

    public sealed class EntityRepository<T> : BasicEntityRepository where T : class, IDataBaseModel
    {
        public DbSet<T> DbSet { get; set; }
        public EntityRepository(DbContextOptions<BasicEntityRepository> options)
            : base(options)
        {
            
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task Create(T model)
        {
            DbSet.Add(model);
            await SaveChangesAsync();
        }

        public async Task Update(T model)
        {
            DbSet.Update(model);
            await SaveChangesAsync();
        }

        public async Task Remove(T model)
        {
            DbSet.Remove(model);
            await SaveChangesAsync();
        }
    }
}
