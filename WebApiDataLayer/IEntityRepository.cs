using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiDataLayer
{
    public interface IEntityRepository<T> : IDisposable
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task Create(T model);
        Task Update(T model);
        Task Remove(T model);
        Task Save();
    }
}