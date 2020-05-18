using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiDataLayer
{
    public interface IContext<T> : IDisposable where T : class
    {
        DbSet<T> DbSet { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default (CancellationToken));
    }
}