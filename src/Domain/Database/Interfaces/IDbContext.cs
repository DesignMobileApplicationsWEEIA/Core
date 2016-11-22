using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Model.Database;
using Microsoft.EntityFrameworkCore;

namespace Domain.Database.Interfaces
{
    public interface IDbContext : IDisposable
    {
        DbSet<Place> Places { get; set; }

        DbSet<Building> Buildings { get; set; }

        DbSet<Faculty> Faculties { get; set; }

        DbSet<Achievement> Achievements { get; set; }

        DbSet<Logo> Logos { get; set; }
          
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
