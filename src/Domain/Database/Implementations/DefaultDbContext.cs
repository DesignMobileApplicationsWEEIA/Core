using Core.Domain.Database.Interfaces;
using Core.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Database.Implementations
{
    public class DefaultDbContext : DbContext, IDbManager
    {
        public DbSet<Building> Buildings { get; set; }

        public DbSet<FacultyWreaper> FacultyWreapers { get; set; }

        public DbSet<Place> Places { get; set; }

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }
    }
}
