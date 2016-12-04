using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Model.Api;
using Domain.Model.Database;
using Domain.Model.Math;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using Math = Domain.Utils.Math;

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

        public Result<List<AchievementResult>> GetUserAchievements(string macAddress)
        {
            var ids = _unitOfWork.UserAchievements.FindAll().Where(x => x.MacAddress == macAddress).Select(x => x.AchievementId).ToList();
            var result =  _unitOfWork.Achievements.FindAll().Select(x => new AchievementResult()
            {
                Completed = ids.Any(y => y == x.Id),
                Id = x.Id,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Name = x.Name
            }).ToList();
            return Result<IEnumerable<AchievementResult>>.Wrap(result);
        }

        public Result<bool> StoreAchievement(PhoneData phoneData)
        {
            var achievements = _unitOfWork.Achievements.FindAll().ToList();
            var userPoint = new Point(phoneData.PhoneLocation.Latitude, phoneData.PhoneLocation.Longitude);
            var achievement =
                achievements.FirstOrDefault(
                    x => Math.IsInPointOfView(userPoint, new Point(x.Latitude, x.Longitude), phoneData.Direction));

            if (achievement != null)
            {
                var result = _unitOfWork.UserAchievements.Add(new UserAchievement()
                {
                    AchievementId = achievement.Id,
                    MacAddress = phoneData.MacAddress
                });

                return Result<bool>.WrapValue(result.HasValue);
            }
            return Result<bool>.Error("No Achievement");
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