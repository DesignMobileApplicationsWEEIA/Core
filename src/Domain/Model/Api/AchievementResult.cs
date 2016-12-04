using Domain.Model.Database;

namespace Domain.Model.Api
{
    public class AchievementResult: Achievement
    {
        public bool Completed { get; set; }
    }
}