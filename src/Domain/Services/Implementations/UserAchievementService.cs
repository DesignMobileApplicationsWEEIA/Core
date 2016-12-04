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

        public Result<Chellenges> GetUserChellenges(string macAddress)
        {
            var ids = _unitOfWork.UserAchievements.FindAll().Where(x => x.MacAddress == macAddress).Select(x => x.Id).ToList();
            var achivements = _unitOfWork.Achievements.FindAll().ToList();
            var completedAchievement = achivements.Where(x => ids.Any(y => y == x.Id)).ToList();
            var todo = achivements.Where(x => ids.All(y => y != x.Id)).ToList();
            return Result<Chellenges>.Wrap(new Chellenges()
            {
                Completed = completedAchievement,
                ToDo = todo
            });
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