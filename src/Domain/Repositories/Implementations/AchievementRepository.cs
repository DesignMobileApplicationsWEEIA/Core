using Domain.Database.Interfaces;
using Domain.Model.Database;
using Domain.Repositories.Abstractions;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Implementations
{
    public class AchievementRepository : Repository<Achievement>, IAchievementRepository
    {
        public AchievementRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}