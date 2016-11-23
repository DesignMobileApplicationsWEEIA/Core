using Domain.Database.Interfaces;
using Domain.Model.Database;
using Domain.Repositories.Abstractions;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Implementations
{
    public class LogoRepository: Repository<Logo>, ILogoRepository
    {
        public LogoRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}