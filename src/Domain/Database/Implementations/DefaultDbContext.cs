using Core.Domain.Database.Interfaces;
using Core.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Database.Implementations
{
    public class DefaultDbContext : DbContext, IDbManager
    {
        public DbSet<Building> Buildings { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Place> Places { get; set; }

        public DefaultDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
