using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiDataLayer.Models;

namespace WebApiDataLayer
{
    //This architecture does not allow migrations 
    public sealed class EntityRepository<T> : IEntityRepository<T> where T : class, IDataBaseModel
    {
        private readonly IContext<T> _context;
        public EntityRepository(IContext<T> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _context.DbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.DbSet.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task Create(T model)
        {
            _context.DbSet.Add(model);
            await Save();
        }

        public async Task Update(T model)
        {
            _context.DbSet.Update(model);
            await Save();
        }

        public async Task Remove(T model)
        {
            _context.DbSet.Remove(model);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        private bool _disposed;
        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
