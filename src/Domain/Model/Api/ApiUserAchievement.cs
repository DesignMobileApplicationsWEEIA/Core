using Domain.Model.Database;

namespace Domain.Model.Api
{
    public class ApiUserAchievement
    {
        public long AchievementId { get; set; }
        public string MacAddress { get; set; }

        public static UserAchievement ToUserAchievement(ApiUserAchievement userAchievement)
        {
            return new UserAchievement()
            {
                AchievementId = userAchievement.AchievementId,
                MacAddress = userAchievement.MacAddress
            };
        }
    }
}
