using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiDataLayer.Models;

namespace WebApiDataLayer
{
    public abstract class EntityRepository<T> : IEntityRepository<T> where T : class, IDataBaseModel
    {
        protected readonly EfDbContext Context;
        protected abstract DbSet<T> DbSet { get; }

        protected EntityRepository(EfDbContext context)
        {
            Context = context;
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
            Context.Add(model);
            await Save();
        }

        public async Task Update(T model)
        {
            DbSet.Update(model);
            await Save();
        }

        public async Task Remove(T model)
        {
            DbSet.Remove(model);
            await Save();
        }

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }
        private bool _disposed;
        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
