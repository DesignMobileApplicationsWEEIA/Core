using Core.Domain.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Database.Implementations
{
    public class DefaultPostgreDbManager : DbContext, IDbManager
    {
        private string _connectionString = string.Empty;

        public DefaultPostgreDbManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
