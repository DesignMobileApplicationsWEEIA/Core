using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Database.Interfaces
{
    public interface IDbManager : IDisposable
    {
        DbSet<Place> Places { get; set; }

        DbSet<Building> Buildings { get; set; }

        DbSet<Faculty> Faculties { get; set; }
          
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
