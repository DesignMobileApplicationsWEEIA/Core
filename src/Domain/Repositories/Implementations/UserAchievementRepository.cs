using Domain.Database.Interfaces;
using Domain.Model.Database;
using Domain.Repositories.Abstractions;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Implementations
{
    public class UserAchievementRepository : Repository<UserAchievement>,IUserAchievementRepository
    {
        public UserAchievementRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}