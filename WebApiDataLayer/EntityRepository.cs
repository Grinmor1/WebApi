using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiDataLayer.Models;

namespace WebApiDataLayer
{

    public sealed class EntityRepository<T> : IEntityRepository<T> where T : class, IDataBaseModel
    {
        private readonly UserContext _userContext;
        public EntityRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _userContext.DbSet.ToListAsync();
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

        public Task Save()
        {
            throw new NotImplementedException();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _userContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
