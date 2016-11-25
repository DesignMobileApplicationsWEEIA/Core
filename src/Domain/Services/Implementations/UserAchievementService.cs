using System.Collections.Generic;
using System.Linq;
using Domain.Model.Api;
using Domain.Model.Database;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services.Implementations
{
    public class UserAchievementService : IUserAchievementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private bool _shouldBeDisposed = true;

        public UserAchievementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            if (!_shouldBeDisposed) return;
            _shouldBeDisposed = false;
            _unitOfWork?.Dispose();
        }

        public Result<IEnumerable<UserAchievement>> GetAll()
        {
            return Result<IEnumerable<UserAchievement>>.Wrap(_unitOfWork.UserAchievements.FindAll());
        }

        public Result<bool> Add(ApiUserAchievement apiUserAchievement)
        {
            if (string.IsNullOrEmpty(apiUserAchievement.MacAddress) || _unitOfWork.Achievements.FindAll().All(x => x.Id != apiUserAchievement.AchievementId))
            {
                return Result<bool>.Error();
            }
            var result = _unitOfWork.UserAchievements.Add(ApiUserAchievement.ToUserAchievement(apiUserAchievement));

            return Result<bool>.Wrap(result.HasValue, x => x);
        }
    }
}