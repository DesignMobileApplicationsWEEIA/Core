using Core.Domain.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Database.Implementations
{
    public class DefaultDbContext : DbContext, IDbManager
    {
        public DefaultDbContext(DbContextOptions<DefaultPostgreDbManager> options) : base(options)
        {
        }
    }
}
