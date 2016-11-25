using System.Collections.Generic;
using Domain.Model.Api;
using Domain.Model.Database;

namespace Domain.Services.Interfaces
{
    public interface IUserAchievementService : IService
    {
        Result<IEnumerable<UserAchievement>> GetAll();
        Result<bool> Add(ApiUserAchievement apiUserAchievement);
    }
}